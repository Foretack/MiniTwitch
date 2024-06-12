using System.Text.Json;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Test.Converters;

public class TimeSpanToSecondsConverterTest
{
    [Fact]
    public void Write()
    {
        TimeSpan ts = TimeSpan.FromSeconds(123456);
        Assert.Equal(123456, TimeSpanToSeconds.AsSeconds(ts));
    }

    [Fact]
    public void Read()
    {
        var ex = Assert.Throws<NotSupportedException>(() =>
        {
            TimeSpanToSeconds ts = new();
            Utf8JsonReader r = default;
            var t = ts.Read(ref r, default!, default!);
        });
    }
}
