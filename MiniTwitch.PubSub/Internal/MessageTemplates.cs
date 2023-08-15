using MiniTwitch.PubSub.Models;

namespace MiniTwitch.PubSub.Internal;

internal sealed class MessageTemplates
{
    private readonly string _authToken;
    public MessageTemplates(string authToken)
    {
        _authToken = authToken;
    }

    public string Listen(Topic topic) => $"{{ \"type\": \"LISTEN\", \"nonce\": \"0:{topic.Key}\", \"data\": {{ \"topics\": [\"{topic.Key}\"], \"auth_token\": \"{topic.OverrideToken ?? _authToken}\" }}}}";
    public string Unlisten(Topic topic) => $"{{ \"type\": \"UNLISTEN\", \"nonce\": \"1:{topic.Key}\", \"data\": {{ \"topics\": [\"{topic.Key}\"], \"auth_token\": \"{topic.OverrideToken ?? _authToken}\" }}}}";
    public string Ping() => @"{""type"":""PING""}";
}
