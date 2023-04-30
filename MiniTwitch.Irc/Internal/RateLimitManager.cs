using MiniTwitch.Irc.Models;

namespace MiniTwitch.Irc.Internal;

internal sealed class RateLimitManager
{
    private readonly Dictionary<string, Queue<long>> _messages = new();
    private readonly Queue<long> _joins = new();
    private readonly int _joinC;
    private readonly int _normalC;
    private readonly int _modC;

    public RateLimitManager(ClientOptions options)
    {
        _joinC = options.JoinRateLimit;
        _normalC = options.MessageRateLimit;
        _modC = options.ModMessageRateLimit;
    }

    public bool CanSend(string channel, bool mod)
    {
        if (!_messages.ContainsKey(channel))
        {
            _messages.Add(channel, new());
            RegisterSend(channel);
            return true;
        }

        long unix = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        int sent = _messages[channel].Count(x => unix - x < 30000);
        int old = _messages[channel].Count - sent;

        for (int i = 0; i < old; i++)
        {
            _ = _messages[channel].Dequeue();
        }

        if (mod)
        {
            if (sent < _modC)
            {
                RegisterSend(channel);
                return true;
            }

            return false;
        }

        if (sent < _normalC)
        {
            RegisterSend(channel);
            return true;
        }

        return false;
    }

    public bool CanJoin()
    {
        if (_joins.Count == 0)
        {
            RegisterJoin();
            return true;
        }

        long unix = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        int attempts = _joins.Count(x => unix - x < 10000);
        int old = _joins.Count - attempts;

        for (int i = 0; i < old; i++)
        {
            _ = _joins.Dequeue();
        }

        if (attempts < _joinC)
        {
            RegisterJoin();
            return true;
        }

        return false;
    }

    private void RegisterSend(string channel) => _messages[channel].Enqueue(DateTimeOffset.Now.ToUnixTimeMilliseconds());

    private void RegisterJoin() => _joins.Enqueue(DateTimeOffset.Now.ToUnixTimeMilliseconds());
}
