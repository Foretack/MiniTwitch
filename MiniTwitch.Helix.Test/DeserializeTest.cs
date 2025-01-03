using System.Text.Json;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Test;

public class DeserializeTest
{
    static readonly JsonSerializerOptions options = HelixApiClient.SerializerOptions;

    [Fact]
    public void ChannelsInformation()
    {
        string json = "{\"data\":[{\"broadcaster_id\":\"93300843\",\"broadcaster_login\":\"sneeziu\",\"broadcaster_name\":\"sneeziu\",\"broadcaster_language\":\"en\",\"game_id\":\"66170\",\"game_name\":\"Warframe\",\"title\":\"RISE AND SLIME! MAN I LOVE MICROPLASTICS, YUMMY YUMMY ????\",\"delay\":0,\"tags\":[\"Vtuber\",\"English\",\"Slime\",\"ASMR\",\"ENVtuber\",\"Yapper\",\"LGBTQIAPlus\",\"BrainRot\",\"TennoCreate\",\"Microplastics\"],\"content_classification_labels\":[\"MatureGame\"],\"is_branded_content\":false}]}";
        ChannelsInformation? response = JsonSerializer.Deserialize<ChannelsInformation>(json, options);
        Assert.NotNull(response);
        var info = Assert.Single(response.Data);
        Assert.Equal(93300843, info.Id);
        Assert.Equal("sneeziu", info.Name);
        Assert.Equal("sneeziu", info.DisplayName);
        Assert.Equal("en", info.Language);
        Assert.Equal("Warframe", info.GameName);
        Assert.Equal("66170", info.GameId);
        Assert.Equal("RISE AND SLIME! MAN I LOVE MICROPLASTICS, YUMMY YUMMY ????", info.Title);
        Assert.Equal(0, info.Delay);
        Assert.Equal(["Vtuber", "English", "Slime", "ASMR", "ENVtuber", "Yapper", "LGBTQIAPlus", "BrainRot", "TennoCreate", "Microplastics"], info.Tags);
        Assert.Equal([ContentLabelId.MatureGame], info.ContentClassificationLabels);
        Assert.False(info.IsBrandedContent);
    }
}

