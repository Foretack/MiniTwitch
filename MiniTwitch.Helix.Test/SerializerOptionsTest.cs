using System.Text.Json;
using MiniTwitch.Helix.Internal;

namespace MiniTwitch.Helix.Test;

public class SerializerOptionsTest
{
    static JsonSerializerOptions options = HelixApiClient.SerializerOptions;

    [Fact]
    public void WhenWritingNull_IgnoreCondition_WriteNull()
    {
        var obj = new
        {
            forsen = (string?)null,
            justinfan = default(string)
        };

        var res = JsonSerializer.Serialize(obj, options);
        Assert.Equal("{}", res);
    }
    [Fact]
    public void WhenWritingNull_IgnoreCondition_WriteDefault()
    {
        var obj = new
        {
            forsen = default(long),
        };

        var res = JsonSerializer.Serialize(obj, options);
        Assert.Equal("""
            {"forsen":0}
            """, res);
    }
    [Fact]
    public void WhenWritingNull_IgnoreCondition_Write()
    {
        var obj = new
        {
            forsen = "Im your number one fan",
        };

        var res = JsonSerializer.Serialize(obj, options);
        Assert.Equal("""
            {"forsen":"Im your number one fan"}
            """, res);
    }
}
