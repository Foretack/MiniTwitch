using System.Net.WebSockets;

namespace MiniTwitch.Common;
public sealed class WebSocketClient
{
    public bool IsConnected => _ws?.State is WebSocketState.Open;
    public WebSocketState State => _ws.State;
    public event Action<WebSocketClient> ReadSignal = default!;

    private readonly Memory<byte> _buffer = new byte[ushort.MaxValue];
    private readonly Uri _uri;
    private readonly SemaphoreSlim _readLock = new(1);
    private readonly SemaphoreSlim _lock = new(1);

    private ClientWebSocket _ws;
    private CancellationTokenSource? _cts = default!;
    private Task? _reader = Task.CompletedTask;
    private ushort _cursor = 0;

    public WebSocketClient(Uri uri)
    {
        _uri = uri;
        _ws = new();
    }

    public async Task<bool> Connect(CancellationToken cancellationToken = default)
    {
        await _lock.WaitAsync(cancellationToken);
        try
        {
            if (this.IsConnected)
            {
                return true;
            }

            if (this.State is WebSocketState.Aborted or WebSocketState.Closed)
            {
                _ws.Dispose();
                _ws = new();
            }

            await _ws.ConnectAsync(_uri, cancellationToken);
            for (int i = 0; i < 25 && !cancellationToken.IsCancellationRequested; i++)
            {
                if (!this.IsConnected)
                {
                    await Task.Delay(100, cancellationToken);
                }
            }

            if (!this.IsConnected)
            {
                return false;
            }

            if (_cts?.IsCancellationRequested is false)
            {
                _cts?.Cancel();
                _cts?.Dispose();
            }

            _cts = new();
            _reader?.Dispose();
            _reader = Task.Factory.StartNew(ReadLoop, TaskCreationOptions.LongRunning);
            return true;
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task Disconnect(CancellationToken cancellationToken = default)
    {
        await _lock.WaitAsync(cancellationToken);
        try
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _reader?.Dispose();
            WebSocketCloseStatus status = _ws.CloseStatus ?? WebSocketCloseStatus.NormalClosure;
            string? description = _ws.CloseStatusDescription;
            if (this.IsConnected)
            {
                await _ws.CloseAsync(status, description, cancellationToken);
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    private async Task ReadLoop()
    {
        while (_cts?.IsCancellationRequested is false)
        {
            await _readLock.WaitAsync(_cts.Token);
            try
            {
                if (!this.IsConnected)
                {
                    continue;
                }

                var r = await _ws.ReceiveAsync(_buffer[_cursor..], _cts.Token);
                int newCursor = _cursor + r.Count;
                _cursor = checked((ushort)newCursor);
                switch (r.MessageType)
                {
                    case WebSocketMessageType.Close:
                        _cts?.Cancel();
                        break;

                    case WebSocketMessageType.Text when r.EndOfMessage:
                        ReadSignal?.Invoke(this);
                        _cursor = 0;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex) when (ex is InvalidOperationException or WebSocketException or TaskCanceledException)
            {
                _cursor = 0;
                if (_cts.IsCancellationRequested)
                {
                    return;
                }

                break;
            }
        }

        await Connect();
    }

    public ReadOnlyMemory<byte> Read()
    {
        if (_readLock.CurrentCount != 0)
        {
            return Array.Empty<byte>();
        }


        try
        {
            return _buffer[.._cursor];
        }
        finally
        {
            _readLock.Release();
        }
    }

    public ValueTask Write(ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
    {
        return _ws.SendAsync(bytes, WebSocketMessageType.Text, true, cancellationToken);
    }
}
