using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using MiniTwitch.Common;
using MiniTwitch.Common.Extensions;
using MiniTwitch.PubSub.Enums;
using MiniTwitch.PubSub.Interfaces;
using MiniTwitch.PubSub.Internal;
using MiniTwitch.PubSub.Internal.Enums;
using MiniTwitch.PubSub.Internal.Parsing;
using MiniTwitch.PubSub.Models;

namespace MiniTwitch.PubSub;

public class PubSubClient
{
    public Action<Exception> ExceptionHandler { get; set; } = default!;

    public event Func<IPredictionStarted, ValueTask> OnPredictionStarted = default!;
    public event Func<ITopPredictorsChanged, ValueTask> OnTopPredictorsChanged = default!;
    public event Func<IPredictionWindowClosed, ValueTask> OnPredictionWindowClosed = default!;
    public event Func<IPredictionEnded, ValueTask> OnPredictionEnded = default!;
    public event Func<IPredictionLocked, ValueTask> OnPredictionLocked = default!;
    public event Func<IPredictionCancelled, ValueTask> OnPredictionCancelled = default!;
    public event Func<ITimeOutData, ValueTask> OnTimedOut = default!;
    public event Func<IUntimeOutData, ValueTask> OnUntimedOut = default!;
    public event Func<IBanData, ValueTask> OnBanned = default!;
    public event Func<IUntimeOutData, ValueTask> OnUnbanned = default!;
    public event Func<IAliasRestrictedUpdate, ValueTask> OnAliasRestrictionUpdate = default!;
    public event Func<BitsEventsPayload, ValueTask> OnBitsEvent = default!;
    public event Func<BitsBadgeUnlockPayload, ValueTask> OnBitsBadgeUnlock = default!;
    public event Func<ChannelPointsPayload, ValueTask> OnChannelPointsRedemption = default!;
    public event Func<ISubEvent, ValueTask> OnSub = default!;
    public event Func<ISubGiftEvent, ValueTask> OnSubGift = default!;
    public event Func<IAnonSubGiftEvent, ValueTask> OnAnonSubGift = default!;
    public event Func<AutoModQueuePayload, ValueTask> OnAutoModMessageCaught = default!;
    public event Func<LowTrustUserPayload, ValueTask> OnLowTrustUserTreatment = default!;

    private readonly JsonSerializerOptions _sOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        ReadCommentHandling = JsonCommentHandling.Skip
    };
    private readonly AsyncEventCoordinator<WaitableEvents> _coordinator = new();
    private readonly string _loggingHeader = "[MiniTwitch:PubSub:]";
    private readonly MessageGenerator _messageGenerator;
    private readonly string _loggerType;
    private readonly WebSocketClient _ws;
    private readonly ILogger? _logger;
    private Task _pinger = default!;
    private Uri _targetUrl = default!;

    public PubSubClient(string authToken, ILogger? logger = null)
    {
        _ws = new(TimeSpan.FromMinutes(1));
        _logger = logger;
        _messageGenerator = new(authToken);

        Type? type = _logger?.GetType().GetGenericArguments().FirstOrDefault();
        _loggerType = type?.Name ?? string.Empty;

        _ws.OnData += Parse;
        _ws.OnConnect += OnWsConnect;
        _ws.OnLog += Log;
        _ws.OnLogEx += LogException;
    }

    private Task Ping()
    {
        return _ws.SendAsync(_messageGenerator.Ping()).AsTask();
    }

    public async IAsyncEnumerable<ListenResponse> ListenTo(IEnumerable<Topic> topics, 
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (Topic topic in topics)
        {
            yield return await ListenTo(topic, cancellationToken);
        }
    }

    public async Task<ListenResponse> ListenTo(Topic topic, CancellationToken cancellationToken = default)
    {
        string a = _messageGenerator.Listen(topic);
        await Console.Out.WriteLineAsync(a);
        await _ws.SendAsync(a, false, cancellationToken);
        if (await _topicWaiter.WaitAsync(TimeSpan.FromSeconds(5), cancellationToken))
            return _response;

        return new() { Error = ResponseError.Unknown, TopicKey = string.Empty };
    }

    public void Connect(string url = "wss://pubsub-edge.twitch.tv") => ConnectAsync(url).StepOver();

    public async Task<bool> ConnectAsync(string url = "wss://pubsub-edge.twitch.tv",
        CancellationToken cancellationToken = default)
    {
        this.ExceptionHandler ??= LogEventException;
        _targetUrl = new(url);
        await _ws.Start(_targetUrl, cancellationToken);
        if (await _connectionWaiter.WaitAsync(TimeSpan.FromSeconds(15), cancellationToken).ConfigureAwait(false))
            return true;

        Log(LogLevel.Critical, "Connection timed out.");
        return false;
    }

    private Task OnWsConnect()
    {
        if (_connectionWaiter.CurrentCount == 0)
            _ = _connectionWaiter.Release();

        _pinger = Task.Factory.StartNew(PingerTask, TaskCreationOptions.LongRunning);
        Log(LogLevel.Trace, "Started PingerTask");
        return Task.CompletedTask;
    }

    private Task PingerTask()
    {
        return Task.Run(async () =>
        {
            while (_ws.IsConnected)
            {
                await Ping();
                await Task.Delay(TimeSpan.FromMinutes(4));
            }
        });
    }

    #region Utils
    private Action<Exception> GetExceptionHandler() => this.ExceptionHandler ??= LogEventException;
    private void LogEventException(Exception ex) => LogException(ex, "🚨 Exception caught in an event:");

    private void Log(LogLevel level, string template, params object[] properties) => _logger?.Log(level, $"{_loggingHeader} " + template, properties);

    private void LogException(Exception ex, string template, params object[] properties) => _logger?.LogError(ex, $"{_loggingHeader} " + template, properties);
    #endregion

    private void Parse(ReadOnlyMemory<byte> data)
    {
        MessageType type = PubSubParsing.ParseType(data.Span);
        ReceiveData(data, type);
    }

    private void ReceiveData(ReadOnlyMemory<byte> data, MessageType type)
    {
        switch (type)
        {
            case MessageType.PONG:
                Console.WriteLine("PONG received");
                break;

            case MessageType.RECONNECT:
                break;

            case MessageType.MESSAGE:
                MessageTopic topic = PubSubParsing.ParseTopic(data.Span);
                if (topic != MessageTopic.ChannelPredictions)
                {
                    Console.WriteLine(Encoding.UTF8.GetString(data.Span));
                }
                Console.WriteLine(topic);
                switch (topic)
                {
                    case MessageTopic.ChannelPredictions:
                        var prediction = data.Span.ReadJsonMessage<ChannelPredictionsPayload>(options: _sOptions);
                        if (prediction.Type == "event-created")
                        {
                            OnPredictionStarted?.Invoke(prediction.Data.Event).StepOver(GetExceptionHandler());
                            return;
                        }

                        switch (prediction.Data.Event.Status)
                        {
                            case "ACTIVE":
                                OnTopPredictorsChanged?.Invoke(prediction.Data.Event).StepOver(GetExceptionHandler());
                                break;

                            case "LOCKED":
                                if (!prediction.Data.Event.LockedBy.HasValue)
                                {
                                    OnPredictionWindowClosed?.Invoke(prediction.Data.Event).StepOver(GetExceptionHandler());
                                    return;
                                }

                                OnPredictionLocked?.Invoke(prediction.Data.Event).StepOver(GetExceptionHandler());
                                break;

                            case "RESOLVE_PENDING" when prediction.Data.Event.Outcomes[0].TopPredictors.Any(x => x.Result?.PointsWon is > 0):
                                OnPredictionEnded?.Invoke(prediction.Data.Event).StepOver(GetExceptionHandler());
                                break;

                            case "CANCELED":
                                OnPredictionCancelled?.Invoke(prediction.Data.Event).StepOver(GetExceptionHandler());
                                break;
                        }

                        break;

                    case MessageTopic.ChatroomsUser:
                        var chatrooms = data.Span.ReadJsonMessage<ChatroomsUserPayload>(options: _sOptions);
                        switch (chatrooms.Type)
                        {
                            case "user_moderation_action":
                                switch (chatrooms.Data.Action)
                                {
                                    case "timeout":
                                        OnTimedOut?.Invoke(chatrooms.Data).StepOver(GetExceptionHandler());
                                        break;

                                    case "untimeout":
                                        OnUntimedOut?.Invoke(chatrooms.Data).StepOver(GetExceptionHandler());
                                        break;

                                    case "ban":
                                        OnBanned?.Invoke(chatrooms.Data).StepOver(GetExceptionHandler());
                                        break;

                                    case "unban":
                                        OnUnbanned?.Invoke(chatrooms.Data).StepOver(GetExceptionHandler());
                                        break;
                                }

                                break;

                            case "channel_banned_alias_restriction_update":
                                OnAliasRestrictionUpdate?.Invoke(chatrooms.Data).StepOver(GetExceptionHandler());
                                break;
                        }

                        break;

                    case MessageTopic.BitsEventsV1 or MessageTopic.BitsEventsV2:
                        var bits = data.Span.ReadJsonMessage<BitsEventsPayload>(options: _sOptions);
                        OnBitsEvent?.Invoke(bits).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.BitsBadgeUnlock:
                        var bitBadgeUnlock = data.Span.ReadJsonMessage<BitsBadgeUnlockPayload>(options: _sOptions);
                        OnBitsBadgeUnlock?.Invoke(bitBadgeUnlock).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.ChannelPoints:
                        var channelPoints = data.Span.ReadJsonMessage<ChannelPointsPayload>(options: _sOptions);
                        OnChannelPointsRedemption?.Invoke(channelPoints).StepOver(GetExceptionHandler());
                        break;

                    case MessageTopic.SubscribeEvents:
                        var subEvent = data.Span.ReadJsonMessage<SubscribeEventsPayload>(options: _sOptions);
                        switch (subEvent.Context)
                        {
                            case "sub" or "resub":
                                OnSub?.Invoke(subEvent).StepOver(GetExceptionHandler());
                                break;

                            case "subgift":
                                OnSubGift?.Invoke(subEvent).StepOver(GetExceptionHandler());
                                break;

                            case "anonsubgift":
                                OnAnonSubGift?.Invoke(subEvent).StepOver(GetExceptionHandler());
                                break;
                        }
                        break;

                    case MessageTopic.AutomodQueue:
                        var automod = data.Span.ReadJsonMessage<AutoModQueuePayload>(options: _sOptions);
                        OnAutoModMessageCaught?.Invoke(automod).StepOver(GetExceptionHandler());
                        break;
                }

                break;

            case MessageType.RESPONSE:
                _response = PubSubParsing.ParseResponse(data.Span);
                if (_topicWaiter.CurrentCount == 0)
                    _ = _topicWaiter.Release();
                break;
        }
    }
}
