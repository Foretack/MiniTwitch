using MiniTwitch.PubSub.Models;

namespace MiniTwitch.PubSub.Internal;

internal class MessageGenerator
{
    private readonly string _authToken;
    public MessageGenerator(string authToken)
    {
        _authToken = authToken;
    }

    public string Listen(Topic topic) => $"{{ \"type\": \"LISTEN\", \"nonce\": \"key: {topic.Key}\", \"data\": {{ \"topics\": [\"{topic.Key}\"], \"auth_token\": \"{_authToken}\" }}}}";
    public string Unlisten(Topic topic) => $"{{ \"type\": \"UNLISTEN\", \"nonce\": \"key: {topic.Key}\", \"data\": {{ \"topics\": [\"{topic.Key}\"], \"auth_token\": \"{_authToken}\" }}}}";
    public string Ping() => @"{ ""type"": ""PING"" }";
}
