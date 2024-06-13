using System.Text.Json;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Test.Converters;

public class ConduitTransportConverterTest
{
    static JsonSerializerOptions options = HelixApiClient.SerializerOptions;

    [Fact]
    public void Convert_Webhook()
    {
        string json = """
            {
              "id": "0",
              "status": "enabled",
              "transport": {
                "method": "webhook",
                "callback": "https://this-is-a-callback.com"
              }
            }
            """;

        var element = JsonDocument.Parse(json).RootElement.GetProperty("transport");
        var res = ConduitTransportConverter.ReadTransport(element, options);
        Assert.NotNull(res);
        var t = Assert.IsType<ConduitTransport.Webhook>(res);
        Assert.Equal("https://this-is-a-callback.com", t.Callback);
    }

    [Fact]
    public void Convert_WebSocket_Alive()
    {
        string json = """
            {
              "id": "2",
              "status": "enabled",
              "transport": {
                "method": "websocket",
                "session_id": "9fd5164a-a958-4c60-b7f4-6a7202506ca0",
                "connected_at": "2020-11-10T14:32:18.730260295Z"
              }
            }
            """;

        var element = JsonDocument.Parse(json).RootElement.GetProperty("transport");
        var res = ConduitTransportConverter.ReadTransport(element, options);
        Assert.NotNull(res);
        var t = Assert.IsType<ConduitTransport.WebSocket>(res);
        Assert.Equal("9fd5164a-a958-4c60-b7f4-6a7202506ca0", t.SessionId);
        // DateTime parsing floors 730260295 -> 7302602
        Assert.Equal(DateTime.Parse("2020-11-10T14:32:18.7302602Z").ToUniversalTime(), t.ConnectedAt);
        Assert.Null(t.DisconnectedAt);
    }

    [Fact]
    public void Convert_WebSocket_Dead()
    {
        string json = """
            {
              "id": "4",
              "status": "websocket_disconnected",
              "transport": {
                "method": "websocket",
                "session_id": "ad1c9fc3-0d99-4eb7-8a04-8608e8ff9ec9",
                "connected_at": "2020-11-10T14:32:18.730260295Z",
                "disconnected_at": "2020-11-11T14:32:18.730260295Z"
              }
            }
            """;

        var element = JsonDocument.Parse(json).RootElement.GetProperty("transport");
        var res = ConduitTransportConverter.ReadTransport(element, options);
        Assert.NotNull(res);
        var t = Assert.IsType<ConduitTransport.WebSocket>(res);
        Assert.Equal("ad1c9fc3-0d99-4eb7-8a04-8608e8ff9ec9", t.SessionId);
        // DateTime parsing floors 730260295 -> 7302602
        Assert.Equal(DateTime.Parse("2020-11-10T14:32:18.7302602Z").ToUniversalTime(), t.ConnectedAt);
        Assert.Equal(DateTime.Parse("2020-11-11T14:32:18.7302602Z").ToUniversalTime(), t.DisconnectedAt);
    }

    [Fact]
    public void Convert_Invalid()
    {
        string json = """
            {
              "id": "2",
              "status": "enabled",
              "transport": {
                "method": "melon095",
                "session_id": "9fd5164a-a958-4c60-b7f4-6a7202506ca0",
                "connected_at": "2020-11-10T14:32:18.730260295Z"
              }
            }
            """;

        var element = JsonDocument.Parse(json).RootElement.GetProperty("transport");
        var ex = Assert.Throws<JsonException>(() =>
        {
            var res = ConduitTransportConverter.ReadTransport(element, options);
        });
    }
}
