using System.Net.WebSockets;
using System.Text;
using Microsoft.Extensions.Logging;
using MiniTwitch.Common.Internal.Models;

namespace MiniTwitch.Common;
public sealed class WebSocketClient : IAsyncDisposable
{
    #region Properties
    public bool IsConnected => _client is not null && _client.State == WebSocketState.Open;
    #endregion

    #region Events
    public event Func<Task> OnConnect = default!;
    public event Func<Task> OnReconnect = default!;
    public event Func<Task> OnDisconnect = default!;
    public event Action<ReadOnlyMemory<byte>> OnData = default!;
    public event Action<LogLevel, string, object[]> OnLog = default!;
    public event Action<Exception, string, object[]> OnLogEx = default!;
    #endregion

    #region Fields
    private readonly CancellationToken _ct = CancellationToken.None;
    private readonly SemaphoreSlim _sendLock = new(1);
    private readonly SemaphoreSlim _reconnectionLock = new(0);
    private readonly TimeSpan _reconnectDelay;
    private readonly ByteBucket _bucket;
    private ClientWebSocket _client = new();
    private Uri _uri = default!;
    private Task _receiveTask = default!;
    private bool _reconnecting = false;
    #endregion

    #region Init
    public WebSocketClient(TimeSpan reconnectionDelay, short bufferSize = 4096)
    {
        _bucket = new ByteBucket(bufferSize);
        _reconnectDelay = reconnectionDelay;
    }
    #endregion

    #region Controls
    public async Task Start(Uri uri, CancellationToken cancellationToken = default)
    {
        // The ClientWebSocket cannot be reused once it is aborted
        if (_client.State == WebSocketState.Aborted)
        {
            Log(LogLevel.Error, "Cannot start WebSocket in aborted state");
            return;
        }

        _uri = uri;
        Log(LogLevel.Trace, "Connecting to {uri} ...", uri);
        await _client.ConnectAsync(uri, cancellationToken);
        _receiveTask = Receive();
        await Task.Delay(500, cancellationToken);
        if (this.IsConnected)
        {
            if (!_reconnecting)
                await OnConnect.Invoke();
            else // This is a reconnect. So we want to invoke OnReconnect instead, which happens in Restart()
                _ = _reconnectionLock.Release();
        }
    }

    private Task Stop(CancellationToken cancellationToken = default) =>
        _client.CloseOutputAsync(_client.CloseStatus ?? WebSocketCloseStatus.NormalClosure, _client.CloseStatusDescription, cancellationToken)
            .WaitAsync(cancellationToken);

    public async Task Disconnect(CancellationToken cancellationToken = default)
    {
        // Need to be connected to do this
        if (this.IsConnected)
            await Stop(cancellationToken);

        _client.Dispose();
        await OnDisconnect.Invoke();
        if (_receiveTask.IsFaulted || _receiveTask.IsCanceled)
            _receiveTask.Dispose();
    }

    public async Task Restart(TimeSpan delay, CancellationToken cancellationToken = default)
    {
        // Sometimes the method gets invoked twice in a short span of time
        // The whole purpose of this _reconnecting field is to stop that
        if (_reconnecting)
            return;

        Log(LogLevel.Critical, "The WebSocket client is restarting in {delay}", delay);
        _reconnecting = true;
        await Disconnect(cancellationToken);
        _client = new ClientWebSocket();
        await Task.Delay(delay, cancellationToken);
        Log(LogLevel.Debug, "Finished waiting for reconnection delay");
        await Start(_uri, cancellationToken);
        Log(LogLevel.Trace, "If the WebSocket doesn't reconnect in 10 seconds you will see a warning");
        // Keep trying until you reconnect
        if (!await _reconnectionLock.WaitAsync(TimeSpan.FromSeconds(10), cancellationToken))
        {
            Log(LogLevel.Warning, "WebSocket reconnect failed. Retrying...");
            _reconnecting = false; // Set to false otherwise the method returns early
            await Restart(delay, cancellationToken);
            return;
        }

        Log(LogLevel.Information, "Successfully reconnected!");
        _reconnecting = false;
        await OnReconnect.Invoke();
    }
    #endregion

    #region Communication
    private Task Receive()
    {
        return Task.Run(async () =>
        {
            while (true)
            {
                if (!this.IsConnected)
                    continue;

                try
                {
                    // TODO: move this to a Thread instead of a Task - then you don't have to deal with long-lived CancellationTokens
                    // + you're not hogging the Task pool
                    bool shouldDrain = await _bucket.FillFrom(_client, CancellationToken.None);
                    if (!shouldDrain)
                        continue;

                    ReadOnlyMemory<byte> message = _bucket.Drain();
                    OnData?.Invoke(message);
                }
                catch (WebSocketException wse)
                {
                    Log(LogLevel.Critical, "An error occurred while receiving data from the WebSocket connection: {msg}", wse.Message);
                    break;
                }
                catch (InvalidOperationException)
                {
                    Log(LogLevel.Warning, "Tried to receive data, but the WebSocket client is not connected");
                    break;
                }
                catch (Exception ex)
                {
                    LogException(ex, "Exception caught in data receiver: ");
                }
            }

            await Restart(_reconnectDelay);
        });
    }

    public async ValueTask SendAsync(string data, bool sensitive = false, CancellationToken cancellationToken = default)
    {
        ReadOnlyMemory<byte> bytes = Encoding.UTF8.GetBytes(data);
        if (!await _sendLock.WaitAsync(TimeSpan.FromSeconds(10), cancellationToken).ConfigureAwait(false))
        {
            Log(LogLevel.Warning, "{method} timed out after 10 seconds.", nameof(SendAsync));
            return;
        }
        else if (!this.IsConnected)
        {
            Log(LogLevel.Warning, "Cannot send data in non-connect state. ({state})", _client.State);
        }

        if (!sensitive)
            Log(LogLevel.Debug, "Sending data: {msg}", data);

        try
        {
            await _client!.SendAsync(bytes, WebSocketMessageType.Text, true, cancellationToken);
        }
        catch (Exception ex)
        {
            LogException(ex, "Exception caught whilst trying to send data.");
        }
        finally
        {
            _ = _sendLock.Release();
        }
    }
    #endregion

    #region Helpers
    private void Log(LogLevel level, string template, params object[] properties) => OnLog?.Invoke(level, template, properties);

    private void LogException(Exception ex, string template, params object[] properties) => OnLogEx?.Invoke(ex, template, properties);
    #endregion

    public async ValueTask DisposeAsync()
    {
        if (this.IsConnected)
        {
            await Disconnect();
            return;
        }

        await OnDisconnect.Invoke();
        Log(LogLevel.Debug, "Disposed {name}", nameof(WebSocketClient));
    }
}
