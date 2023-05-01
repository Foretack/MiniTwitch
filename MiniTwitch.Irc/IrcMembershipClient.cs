using Microsoft.Extensions.Logging;
using MiniTwitch.Common;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Interfaces;
using MiniTwitch.Irc.Internal;
using MiniTwitch.Irc.Internal.Enums;
using MiniTwitch.Irc.Internal.Parsing;
using MiniTwitch.Irc.Models;

namespace MiniTwitch.Irc;

/// <summary>
/// Listens only to user JOINs or PARTs from channels. Most other IRC messages are ignored 
/// </summary>
public sealed class IrcMembershipClient : IAsyncDisposable
{
    #region Constants
    private const string CONN_URL = "wss://irc-ws.chat.twitch.tv:443";
    private const string LOG_HEADER = "[MiniTwitch:Membership]";
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    public Action<Exception> ExceptionHandler { get; set; } = default!;
    #endregion

    #region Events
    /// <summary>
    /// Invoked upon connecting to TMI
    /// <para>Note: This is only invoked once. Following connections to TMI will invoke <see cref="OnReconnect"/></para>
    /// </summary>
    public event Func<ValueTask> OnConnect = default!;
    /// <summary>
    /// Invoked upon reconnecting to TMI
    /// </summary>
    public event Func<ValueTask> OnReconnect = default!;
    /// <summary>
    /// Invoked upon disconnection from TMI
    /// </summary>
    public event Func<ValueTask> OnDisconnect = default!;
    /// <summary>
    /// Invoked when a user joins a channel
    /// </summary>
    public event Func<MembershipArgs, ValueTask> OnUserJoin = default!;
    /// <summary>
    /// Invoked when a user parts a channel
    /// </summary>
    public event Func<MembershipArgs, ValueTask> OnUserPart = default!;

    internal event Func<ValueTask> OnPing = default!;
    #endregion

    #region Fields
    private readonly SemaphoreSlim _connectionWaiter = new(0);
    private readonly SemaphoreSlim _joinChannelWaiter = new(0);
    private readonly IMembershipClientOptions _options;
    private readonly WebSocketClient _ws = new(TimeSpan.FromSeconds(30), 8192);
    private readonly List<string> _joinedChannels = new();
    private readonly RateLimitManager _manager;
    private bool _connectInvoked;
    #endregion

    #region Init
    /// <summary>
    /// Creates a new instance of <see cref="IrcMembershipClient"/>
    /// </summary>
    public IrcMembershipClient(Action<IMembershipClientOptions> options)
    {
        var clientOptions = new ClientOptions();
        options(clientOptions);
        _options = clientOptions;
        _manager = new(clientOptions);

        InternalInt();
    }

    private void InternalInt()
    {
        this.ExceptionHandler ??= LogEventException;

        OnPing += Ping;
        _ws.OnDisconnect += OnWsDisconnect;
        _ws.OnConnect += Login;
        _ws.OnReconnect += OnWsReconnect;
        _ws.OnData += Parse;
        _ws.OnLog += Log;
        _ws.OnLogEx += LogException;
    }
    #endregion

    #region Connection
    private async Task Login()
    {
        await _ws.SendAsync("CAP REQ :twitch.tv/membership twitch.tv/commands");
        await _ws.SendAsync($"NICK justinfan{Random.Shared.Next(100, 900)}");
    }

    /// <summary>
    /// Attempts connection to TMI like <see cref="ConnectAsync()"/>, but connects in a "fire and forget" style
    /// </summary>
    public void Connect() => ConnectAsync().StepOver();

    /// <summary>
    /// Connects to TMI
    /// </summary>
    /// <returns><see langword="true"/> if the connection is successful; Otherwise, after 15 seconds: <see langword="false"/></returns>
    public async Task<bool> ConnectAsync()
    {
        Uri uri = new(CONN_URL);

        await _ws.Start(uri);

        if (await _connectionWaiter.WaitAsync(TimeSpan.FromSeconds(15)).ConfigureAwait(false))
            return true;

        Log(LogLevel.Critical, "Connection timed out.");
        return false;
    }

    /// <summary>
    /// Disconnects from TMI in a "fire and forget" style
    /// </summary>
    public void Disconnect() => _ws.Disconnect().StepOver();

    /// <summary>
    /// Disconnects from TMI
    /// </summary>
    public Task DisconnectAsync() => _ws.Disconnect();

    private async Task OnWsReconnect()
    {
        await Login();
        foreach (string channel in _joinedChannels)
        {
            await JoinChannel(channel);
            await Task.Delay(1000);
        }
    }

    private Task OnWsDisconnect()
    {
        OnDisconnect?.Invoke().StepOver(this.ExceptionHandler);
        return Task.CompletedTask;
    }
    #endregion

    #region Communication
    private async ValueTask Ping()
    {
        Log(LogLevel.Debug, "PING received. Sending PONG");
        await _ws.SendAsync("PONG");
    }
    #endregion

    #region Channels
    /// <summary>
    /// Used for joining a channel
    /// </summary>
    /// <param name="channel">Username of the channel to join</param>
    /// <returns><see langword="true"/> if the join is successful; Otherwise, after 10 seconds: <see langword="false"/></returns>
    public async Task JoinChannel(string channel)
    {
        if (!_ws.IsConnected)
        {
            Log(LogLevel.Error, "Failed to join channel {channel}:  Not connected.", channel);
            return;
        }

        if (!_manager.CanJoin())
        {
            await Task.Delay(2500);
            Log(LogLevel.Warning, "Waiting to join #{channel}: Configured ratelimit of {rate} joins/10s is hit", channel, _options.JoinRateLimit);
            await JoinChannel(channel);
            return;
        }

        await _ws.SendAsync($"JOIN #{channel}");
        _joinedChannels.Add(channel);
    }

    /// <summary>
    /// Used for joining multiple channels
    /// </summary>
    /// <param name="channels">Usernames of channels to join</param>
    /// <returns><see langword="true"/> if all joins are successful; Otherwise, <see langword="false"/></returns>
    public async Task JoinChannels(params string[] channels)
    {
        if (!_ws.IsConnected)
        {
            Log(LogLevel.Error, "Failed to join channels {channels}:  Not connected.", string.Join(',', channels));
            return;
        }

        foreach (string channel in channels)
        {
            await JoinChannel(channel);
        }
    }

    /// <summary>
    /// Used for leaving/parting a joined channel
    /// </summary>
    /// <param name="channel">name of the channel to part</param>
    public Task PartChannel(string channel)
    {
        if (!_ws.IsConnected)
        {
            Log(LogLevel.Error, "Failed to part channel {channel}: Not connected.", channel);
            return Task.CompletedTask;
        }

        if (_joinedChannels.Remove(channel))
            Log(LogLevel.Debug, "Removed #{channel} from joined channels list.", channel);

        return _ws.SendAsync($"PART #{channel}").AsTask();
    }
    #endregion

    #region Parsing
    internal void Parse(ReadOnlyMemory<byte> data)
    {
        (IrcCommand command, int lfIndex) = IrcParsing.ParseCommand(data.Span);
        int accumulatedIndex = lfIndex;
        ReceiveData(command, data);
        while (lfIndex != 0 && data.Length - accumulatedIndex > 0)
        {
            (command, lfIndex) = IrcParsing.ParseCommand(data.Span[accumulatedIndex..]);
            ReceiveData(command, data[accumulatedIndex..]);
            accumulatedIndex += lfIndex;
        }
    }

    private void ReceiveData(IrcCommand command, ReadOnlyMemory<byte> data)
    {
        switch (command)
        {
            case IrcCommand.Connected:
                if (_connectionWaiter.CurrentCount == 0)
                    _ = _connectionWaiter.Release();

                if (_connectInvoked)
                {
                    OnReconnect?.Invoke().StepOver(this.ExceptionHandler);
                    break;
                }

                _connectInvoked = true;
                OnConnect?.Invoke().StepOver(this.ExceptionHandler);
                break;

            case IrcCommand.RECONNECT:
                Log(LogLevel.Information, "Twitch servers requested a reconnection. Reconnecting ...");
                _ws.Restart(TimeSpan.FromSeconds(30)).StepOver();
                OnReconnect?.Invoke().StepOver(this.ExceptionHandler);
                break;

            case IrcCommand.PING:
                OnPing?.Invoke().StepOver(this.ExceptionHandler);
                break;

            case IrcCommand.JOIN:
                MembershipArgs joinArgs = new()
                {
                    User = new MessageAuthor()
                    {
                        Name = data.Span.FindUsername(noTags: true)
                    },
                    Channel = new IrcChannel()
                    {
                        Name = data.Span.FindChannel(anySeparator: true)
                    }
                };
                OnUserJoin?.Invoke(joinArgs).StepOver(this.ExceptionHandler);
                break;

            case IrcCommand.PART:
                MembershipArgs partArgs = new()
                {
                    User = new MessageAuthor()
                    {
                        Name = data.Span.FindUsername(noTags: true)
                    },
                    Channel = new IrcChannel()
                    {
                        Name = data.Span.FindChannel(anySeparator: true)
                    }
                };
                OnUserPart?.Invoke(partArgs).StepOver(this.ExceptionHandler);
                break;
        }
    }
    #endregion

    #region Utils
    private void LogEventException(Exception ex) => LogException(ex, "🚨 Exception caught in an event:");
    private void Log(LogLevel level, string template, params object[] properties) => _options.Logger?.Log(level, $"{LOG_HEADER} " + template, properties);
    private void LogException(Exception ex, string template, params object[] properties) => _options.Logger?.LogError(ex, $"{LOG_HEADER} " + template, properties);
    #endregion

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        await _ws.DisposeAsync();
        _joinedChannels.Clear();
        _connectionWaiter.Dispose();
        _joinChannelWaiter.Dispose();
    }
}
