using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using MiniTwitch.Common;
using MiniTwitch.Common.Extensions;
using MiniTwitch.PubSub.Enums;
using MiniTwitch.PubSub.Interfaces;
using MiniTwitch.PubSub.Internal;
using MiniTwitch.PubSub.Internal.Enums;
using MiniTwitch.PubSub.Internal.Models;
using MiniTwitch.PubSub.Internal.Parsing;
using MiniTwitch.PubSub.Models;
using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub;

public class PubSubClient : IAsyncDisposable
{
    public Action<Exception> ExceptionHandler { get; set; } = default!;
    public IReadOnlyCollection<Topic> ActiveTopics => _topics;
    public DefaultMiniTwitchLogger<PubSubClient> DefaultLogger { get; } = new();

    #region Events
    /// <summary>
    /// Invoked upon connecting to the PubSub service
    /// <para>Note: This is only invoked once. Following connections to PubSub will invoke <see cref="OnReconnect"/></para>
    /// </summary>
    public event Func<ValueTask> OnConnect = default!;
    /// <summary>
    /// Invoked upon reconnecting to PubSub
    /// </summary>
    public event Func<ValueTask> OnReconnect = default!;
    /// <summary>
    /// Invoked upon disconnection from TMI
    /// </summary>
    public event Func<ValueTask> OnDisconnect = default!;
    public event Func<ChannelId, IPredictionStarted, ValueTask> OnPredictionStarted = default!;
    public event Func<ChannelId, IPredictionUpdate, ValueTask> OnPredictionUpdate = default!;
    public event Func<ChannelId, IPredictionWindowClosed, ValueTask> OnPredictionWindowClosed = default!;
    /// <summary>
    /// Invoked when a prediction is ended, an outcome was chosen to be the winner
    /// <para>See <see cref="IPredictionEnded.WinningOutcomeId"/> for chosen outcome</para>
    /// <para> <see cref="ChannelId"/> is the parameter specified in <see cref="Topics.ChannelPredictions(long)"/> </para>
    /// </summary>
    public event Func<ChannelId, IPredictionEnded, ValueTask> OnPredictionEnded = default!;
    public event Func<ChannelId, IPredictionLocked, ValueTask> OnPredictionLocked = default!;
    public event Func<ChannelId, IPredictionCancelled, ValueTask> OnPredictionCancelled = default!;
    public event Func<UserId, ITimeOutData, ValueTask> OnTimedOut = default!;
    public event Func<UserId, IUntimeOutData, ValueTask> OnUntimedOut = default!;
    public event Func<UserId, IBanData, ValueTask> OnBanned = default!;
    public event Func<UserId, IUntimeOutData, ValueTask> OnUnbanned = default!;
    public event Func<UserId, IAliasRestrictedUpdate, ValueTask> OnAliasRestrictionUpdate = default!;
    public event Func<ChannelId, BitsEvents, ValueTask> OnBitsEvent = default!;
    public event Func<ChannelId, BitsBadgeUnlock, ValueTask> OnBitsBadgeUnlock = default!;
    public event Func<ChannelId, ChannelPoints, ValueTask> OnChannelPointsRedemption = default!;
    public event Func<ChannelId, ISubEvent, ValueTask> OnSub = default!;
    public event Func<ChannelId, ISubGiftEvent, ValueTask> OnSubGift = default!;
    public event Func<ChannelId, IAnonSubGiftEvent, ValueTask> OnAnonSubGift = default!;
    public event Func<UserId, ChannelId, AutoModQueue, ValueTask> OnAutoModMessageCaught = default!;
    public event Func<ChannelId, UserId, ILowTrustTreatmentMessage, ValueTask> OnLowTrustTreatmentMessage = default!;
    public event Func<ChannelId, UserId, ILowTrustChatMessage, ValueTask> OnLowTrustChatMessage = default!;
    public event Func<UserId, ChannelId, ModerationNotificationMessage, ValueTask> OnModerationNotificationMessage = default!;
    public event Func<ChannelId, IPinnedMessage, IPinnedMessageData, ValueTask> OnMessagePinned = default!;
    public event Func<ChannelId, IUnpinnedMessage, ValueTask> OnMessageUnpinned = default!;
    public event Func<ChannelId, IPinnedMessageDataUpdate, ValueTask> OnPinnedMessageUpdated = default!;
    public event Func<ChannelId, IStreamUp, ValueTask> OnStreamUp = default!;
    public event Func<ChannelId, IViewerCountUpdate, ValueTask> OnViewerCountUpdate = default!;
    public event Func<ChannelId, ICommercialBreak, ValueTask> OnCommercialBreak = default!;
    public event Func<ChannelId, IStreamDown, ValueTask> OnStreamDown = default!;
    public event Func<ChannelId, BroadcastSettingsUpdate, ValueTask> OnBroadcastSettingsUpdate = default!;
    public event Func<UserId, ChannelId, IUserTimedOut, ValueTask> OnUserTimedOut = default!;
    public event Func<UserId, ChannelId, IUserBanned, ValueTask> OnUserBanned = default!;
    public event Func<UserId, ChannelId, IUserUntimedOut, ValueTask> OnUserUntimedOut = default!;
    public event Func<UserId, ChannelId, IUserUnbanned, ValueTask> OnUserUnbanned = default!;
    public event Func<ChannelId, Poll, ValueTask> OnPollCreated = default!;
    public event Func<ChannelId, Poll, ValueTask> OnPollUpdate = default!;
    public event Func<ChannelId, Poll, ValueTask> OnPollCompleted = default!;
    public event Func<ChannelId, Poll, ValueTask> OnPollArchived = default!;
    #endregion

    #region Fields
    private readonly JsonSerializerOptions _sOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        ReadCommentHandling = JsonCommentHandling.Skip
    };
    private readonly WaitableEvents[] _topicResponses = new[]
    {
        WaitableEvents.ERR_BADAUTH, WaitableEvents.Success, WaitableEvents.ERR_BADMESSAGE,
        WaitableEvents.ERR_BADTOPIC, WaitableEvents.ERR_SERVER
    };
    private readonly AsyncEventCoordinator<WaitableEvents> _coordinator = new();
    private readonly HashSet<Topic> _topics = new(10);
    private readonly MessageTemplates _templates;
    private readonly string _loggingHeader;
    private readonly WebSocketClient _ws;
    private readonly ILogger? _logger;
    private CancellationTokenSource _pingerToken = new();
    private ListenResponse _response = default!;
    private Uri _targetUrl = default!;
    private Task _pinger = default!;
    #endregion

    #region Init
    public PubSubClient(string authToken, ILogger? logger = null)
    {
        _ws = new(TimeSpan.FromMinutes(1));
        _logger = logger;
        _templates = new(authToken);
        Version vers = typeof(PubSubClient).Assembly.GetName().Version ?? new Version();
        _loggingHeader = $"[MiniTwitch.PubSub {vers}]";

        _ws.OnData += ReceiveData;
        _ws.OnConnect += OnWsConnect;
        _ws.OnReconnect += OnWsReconnect;
        _ws.OnDisconnect += OnWsDisconnect;
        _ws.OnLog += Log;
        _ws.OnLogEx += LogException;
    }
    #endregion

    #region Communication
    private async Task Ping()
    {
        await _ws.SendAsync(_templates.Ping());
        if (!await _coordinator.WaitFor(WaitableEvents.PONG, TimeSpan.FromSeconds(5)))
            await ReconnectAsync();
    }

    public async Task<ListenResponse[]> ListenTo(IEnumerable<Topic> topics, CancellationToken cancellationToken = default)
    {
        Topic[] arr = topics is Topic[] array ? array : topics.ToArray();
        var results = new ListenResponse[arr.Length];
        for (int i = 0; i < arr.Length && !cancellationToken.IsCancellationRequested; i++)
        {
            results[i] = await ListenTo(arr[i], cancellationToken);
        }

        return results;
    }

    public async Task<ListenResponse> ListenTo(Topic topic, CancellationToken cancellationToken = default)
    {
        string msg = _templates.Listen(topic);
        await _ws.SendAsync(msg, sensitive: true, cancellationToken: cancellationToken);
        TimeSpan timeout = TimeSpan.FromSeconds(5);
        WaitableEvents returnedEvent;
        try
        {
            returnedEvent = await _coordinator.WaitForAny(_topicResponses, timeout, cancellationToken);
        }
        catch (TimeoutException)
        {
            Log(LogLevel.Error, "Listening to topic '{TopicName}' timed out ({Timeout})", topic.Key, timeout);
            return new() { Error = ResponseError.Response_Timeout, TopicKey = _response.TopicKey };
        }

        if (returnedEvent == WaitableEvents.Success)
            _ = _topics.Add(topic);

        return new() { Error = (ResponseError)returnedEvent, TopicKey = _response.TopicKey };
    }

    public async Task<ListenResponse> UnlistenTo(Topic topic, CancellationToken cancellationToken = default)
    {
        if (!_topics.Contains(topic))
        {
            Log(LogLevel.Warning, "Cannot unlisten to topic {TopicKey} because the client is not listening to it", topic.Key);
            return new() { Error = ResponseError.None, TopicKey = topic.Key };
        }

        string msg = _templates.Unlisten(topic);
        await _ws.SendAsync(msg, sensitive: true, cancellationToken: cancellationToken);
        TimeSpan timeout = TimeSpan.FromSeconds(5);
        WaitableEvents returnedEvent;
        try
        {
            returnedEvent = await _coordinator.WaitForAny(_topicResponses, timeout, cancellationToken);
        }
        catch (TimeoutException)
        {
            return new() { Error = ResponseError.Response_Timeout, TopicKey = _response.TopicKey };
        }

        if (returnedEvent == WaitableEvents.Success)
            _ = _topics.Remove(topic);

        return new() { Error = (ResponseError)returnedEvent, TopicKey = _response.TopicKey };
    }
    #endregion

    #region Connection
    public void Connect(string url = "wss://pubsub-edge.twitch.tv") => ConnectAsync(url).StepOver();

    public async Task<bool> ConnectAsync(string url = "wss://pubsub-edge.twitch.tv",
        CancellationToken cancellationToken = default)
    {
        _targetUrl = new(url);
        await _ws.Start(_targetUrl, cancellationToken);
        if (await _coordinator.WaitFor(WaitableEvents.Connected, TimeSpan.FromSeconds(15), cancellationToken))
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
    public Task DisconnectAsync(CancellationToken cancellationToken = default) => _ws.Disconnect(cancellationToken);

    /// <summary>
    /// Disconnects then reconnects to TMI
    /// </summary>
    public Task ReconnectAsync(CancellationToken cancellationToken = default) => _ws.Restart(TimeSpan.FromSeconds(60), cancellationToken);

    private Task OnWsConnect()
    {
        Log(LogLevel.Information, "Connected");
        _coordinator.Release(WaitableEvents.Connected);
        OnConnect?.Invoke().StepOver(GetExceptionHandler());
        _pinger = Task.Factory.StartNew(PingerTask, TaskCreationOptions.LongRunning);
        Log(LogLevel.Trace, "Started PingerTask");
        return Task.CompletedTask;
    }

    private Task OnWsDisconnect()
    {
        Log(LogLevel.Warning, "Disconnected");
        OnDisconnect?.Invoke().StepOver(GetExceptionHandler());
        return Task.CompletedTask;
    }

    private async Task OnWsReconnect()
    {
        Log(LogLevel.Information, "Reconnected");
        _pinger.Dispose();
        _pingerToken.Cancel();
        _pingerToken.Dispose();
        _pingerToken = new();
        _pinger = Task.Factory.StartNew(PingerTask, TaskCreationOptions.LongRunning);
        foreach (Topic t in _topics)
            _ = await ListenTo(t);

        OnReconnect?.Invoke().StepOver(GetExceptionHandler());
    }

    private Task PingerTask()
    {
        return Task.Run(async () =>
        {
            while (_ws.IsConnected && !_pingerToken.IsCancellationRequested)
            {
                await Ping();
                await Task.Delay(TimeSpan.FromMinutes(4));
            }
        });
    }
    #endregion

    #region Utils
    private ILogger GetLogger() => _logger ?? DefaultLogger;
    private Action<Exception> GetExceptionHandler() => this.ExceptionHandler ??= LogEventException;

    private void LogEventException(Exception ex) => LogException(ex, "🚨 Exception caught in an event:");

    private void Log(LogLevel level, string template, params object[] properties) => GetLogger().Log(level, $"{_loggingHeader} {template}", properties);

    private void LogException(Exception ex, string template, params object[] properties) => GetLogger().LogError(ex, $"{_loggingHeader} {template}", properties);
    #endregion

    #region Parsing
    private void ReceiveData(ReadOnlyMemory<byte> data)
    {
        MessageType type = PubSubParsing.ParseType(data.Span);
        switch (type)
        {
            case MessageType.PONG:
                _coordinator.Release(WaitableEvents.PONG);
                break;

            case MessageType.RECONNECT:
                ReconnectAsync().StepOver(GetExceptionHandler());
                break;

            case MessageType.MESSAGE:
            {
                using TopicInfo info = new(data.Span);
                switch (info.Topic)
                {
                    case MessageTopic.ChannelPredictions:
                        var prediction = data.Span.ReadJsonMessage<ChannelPredictions>(options: _sOptions);
                        if (prediction.Type == "event-created")
                        {
                            OnPredictionStarted?.Invoke(info[0], prediction.Data.Event).StepOver(GetExceptionHandler());
                            return;
                        }

                        switch (prediction.Data.Event.Status)
                        {
                            case "ACTIVE":
                                OnPredictionUpdate?.Invoke(info[0], prediction.Data.Event).StepOver(GetExceptionHandler());
                                break;

                            case "LOCKED":
                                if (!prediction.Data.Event.LockedBy.HasValue)
                                {
                                    OnPredictionWindowClosed?.Invoke(info[0], prediction.Data.Event).StepOver(GetExceptionHandler());
                                    return;
                                }

                                OnPredictionLocked?.Invoke(info[0], prediction.Data.Event).StepOver(GetExceptionHandler());
                                break;

                            case "RESOLVED":
                                OnPredictionEnded?.Invoke(info[0], prediction.Data.Event).StepOver(GetExceptionHandler());
                                break;

                            case "CANCELED":
                                OnPredictionCancelled?.Invoke(info[0], prediction.Data.Event).StepOver(GetExceptionHandler());
                                break;
                        }

                        break;

                    case MessageTopic.ChatroomsUser:
                        var chatrooms = data.Span.ReadJsonMessage<ChatroomsUser>(options: _sOptions);
                        switch (chatrooms.Type)
                        {
                            case "user_moderation_action":
                                switch (chatrooms.Data.Action)
                                {
                                    case "timeout":
                                        OnTimedOut?.Invoke(info[0], chatrooms.Data).StepOver(GetExceptionHandler());
                                        break;

                                    case "untimeout":
                                        OnUntimedOut?.Invoke(info[0], chatrooms.Data).StepOver(GetExceptionHandler());
                                        break;

                                    case "ban":
                                        OnBanned?.Invoke(info[0], chatrooms.Data).StepOver(GetExceptionHandler());
                                        break;

                                    case "unban":
                                        OnUnbanned?.Invoke(info[0], chatrooms.Data).StepOver(GetExceptionHandler());
                                        break;
                                }

                                break;

                            case "channel_banned_alias_restriction_update":
                                OnAliasRestrictionUpdate?.Invoke(info[0], chatrooms.Data).StepOver(GetExceptionHandler());
                                break;
                        }

                        break;

                    case MessageTopic.BitsEventsV1 or MessageTopic.BitsEventsV2:
                        var bits = data.Span.ReadJsonMessage<BitsEvents>(options: _sOptions);
                        OnBitsEvent?.Invoke(info[0], bits).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.BitsBadgeUnlock:
                        var bitBadgeUnlock = data.Span.ReadJsonMessage<BitsBadgeUnlock>(options: _sOptions);
                        OnBitsBadgeUnlock?.Invoke(info[0], bitBadgeUnlock).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.ChannelPoints:
                        var channelPoints = data.Span.ReadJsonMessage<ChannelPoints>(options: _sOptions);
                        OnChannelPointsRedemption?.Invoke(info[0], channelPoints).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.SubscribeEvents:
                        var subEvent = data.Span.ReadJsonMessage<SubscribeEvents>(options: _sOptions);
                        switch (subEvent.Context)
                        {
                            case "sub" or "resub":
                                OnSub?.Invoke(info[0], subEvent).StepOver(GetExceptionHandler());
                                break;

                            case "subgift":
                                OnSubGift?.Invoke(info[0], subEvent).StepOver(GetExceptionHandler());
                                break;

                            case "anonsubgift":
                                OnAnonSubGift?.Invoke(info[0], subEvent).StepOver(GetExceptionHandler());
                                break;
                        }
                        break;

                    case MessageTopic.AutomodQueue:
                        var automod = data.Span.ReadJsonMessage<AutoModQueue>(options: _sOptions);
                        OnAutoModMessageCaught?.Invoke(info[0], info[1], automod).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.LowTrustUsers:
                        var lowTrust = data.Span.ReadJsonMessage<LowTrustUser>(options: _sOptions);
                        if (lowTrust.IsTreatmentMessage)
                            OnLowTrustTreatmentMessage?.Invoke(info[0], info[1], lowTrust).StepOver(GetExceptionHandler());
                        else
                            OnLowTrustChatMessage?.Invoke(info[0], info[1], lowTrust).StepOver(GetExceptionHandler());

                        break;

                    case MessageTopic.ModerationNotifications:
                        var notification = data.Span.ReadJsonMessage<ModerationNotificationMessage>(options: _sOptions);
                        OnModerationNotificationMessage?.Invoke(info[0], info[1], notification).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.PinnedChatUpdates:
                        var pinUpdate = data.Span.ReadJsonMessage<PinnedChatUpdates>(options: _sOptions);
                        switch (pinUpdate.Type)
                        {
                            case "pin-message":
                                OnMessagePinned?.Invoke(info[0], pinUpdate.Data, pinUpdate.Data.Message).StepOver(GetExceptionHandler());
                                break;

                            case "unpin-message":
                                OnMessageUnpinned?.Invoke(info[0], pinUpdate.Data).StepOver(GetExceptionHandler());
                                break;

                            case "update-message":
                                OnPinnedMessageUpdated?.Invoke(info[0], pinUpdate.Data.Message).StepOver(GetExceptionHandler());
                                break;
                        }

                        break;

                    case MessageTopic.VideoPlayback:
                        var videoPlayback = data.Span.ReadJsonMessage<VideoPlayback>(options: _sOptions);
                        switch (videoPlayback.Type)
                        {
                            case "stream-up":
                                OnStreamUp?.Invoke(info[0], videoPlayback).StepOver(GetExceptionHandler());
                                break;

                            case "viewcount":
                                OnViewerCountUpdate?.Invoke(info[0], videoPlayback).StepOver(GetExceptionHandler());
                                break;

                            case "commercial":
                                OnCommercialBreak?.Invoke(info[0], videoPlayback).StepOver(GetExceptionHandler());
                                break;

                            case "stream-down" or "tos-strike":
                                OnStreamDown?.Invoke(info[0], videoPlayback).StepOver(GetExceptionHandler());
                                break;

                            default:
                                Console.WriteLine($"unknown VideoPlayBack type: {videoPlayback.Type} ({videoPlayback.Type.Length})");
                                break;
                        }

                        break;

                    case MessageTopic.BroadcastSettingsUpdate:
                        var settingsUpdate = data.Span.ReadJsonMessage<BroadcastSettingsUpdate>(options: _sOptions);
                        OnBroadcastSettingsUpdate?.Invoke(info[0], settingsUpdate).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.ModeratorActions:
                        var modAction = data.Span.ReadJsonMessage<ModeratorActions>(options: _sOptions);
                        switch (modAction.Data.ModerationAction)
                        {
                            case "timeout":
                                OnUserTimedOut?.Invoke(info[0], info[1], modAction.Data).StepOver(GetExceptionHandler());
                                break;

                            case "ban":
                                OnUserBanned?.Invoke(info[0], info[1], modAction.Data).StepOver(GetExceptionHandler());
                                break;

                            case "untimeout":
                                OnUserUntimedOut?.Invoke(info[0], info[1], modAction.Data).StepOver(GetExceptionHandler());
                                break;

                            case "unban":
                                OnUserUnbanned?.Invoke(info[0], info[1], modAction.Data).StepOver(GetExceptionHandler());
                                break;

                            default:
                                Log(LogLevel.Warning, "Received unknown moderation action: {ModerationAction}", modAction.Data.ModerationAction);
                                break;
                        }
                        break;

                    case MessageTopic.Polls:
                        var poll = data.Span.ReadJsonMessage<Polls>(options: _sOptions);
                        switch (poll.Type)
                        {
                            case "POLL_CREATE":
                                OnPollCreated?.Invoke(info[0], poll.Data.Poll).StepOver(GetExceptionHandler());
                                break;

                            case "POLL_UPDATE":
                                OnPollUpdate?.Invoke(info[0], poll.Data.Poll).StepOver(GetExceptionHandler());
                                break;

                            case "POLL_COMPLETE":
                                OnPollCompleted?.Invoke(info[0], poll.Data.Poll).StepOver(GetExceptionHandler());
                                break;

                            case "POLL_ARCHIVE":
                                OnPollArchived?.Invoke(info[0], poll.Data.Poll).StepOver(GetExceptionHandler());
                                break;

                            default:
                                Log(LogLevel.Warning, "Unknown poll type: {PollType}", poll.Type);
                                break;
                        }

                        break;

                    case MessageTopic.CommunityChannelPoints:
                        var cChannelPoints = data.Span.ReadJsonMessage<ChannelPoints>(options: _sOptions);
                        OnChannelPointsRedemption?.Invoke(info[0], cChannelPoints).StepOver(GetExceptionHandler());
                        break;
                }

                break;
            }

            case MessageType.RESPONSE:
                _response = PubSubParsing.ParseResponse(data.Span);
                _coordinator.Release((WaitableEvents)_response.Error);
                string listenType = _response.TopicKey[0] == '0' ? "listen" : "unlisten";
                string topicKey = _response.TopicKey[2..];
                if (_response.IsSuccess)
                    Log(LogLevel.Information, "Successful {ListenType} to {TopicKey}", listenType, topicKey);
                else
                    Log(LogLevel.Error, "Failed to {ListenType} to {TopicKey}: {ErrorCode}", listenType, topicKey, _response.Error);

                break;
        }
    }
    #endregion

    public async ValueTask DisposeAsync()
    {
        await _ws.DisposeAsync();
        _coordinator.Dispose();
        _pingerToken.Cancel();
        _pingerToken.Dispose();
        _pinger?.Dispose();
        GC.SuppressFinalize(this);
    }
}
