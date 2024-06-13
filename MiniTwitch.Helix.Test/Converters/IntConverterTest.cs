using System.Text;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Test.Converters;

public class IntConverterTest
{
    [Fact]
    public void Read_Int()
    {
        var r = IntConverter.ReadInt(Encoding.UTF8.GetBytes("12345"));
        Assert.Equal(12345, r);
    }

    [Fact]
    public void Read_Long()
    {
        var r = IntConverter.ReadInt(Encoding.UTF8.GetBytes("8223372036854780000"));
        Assert.Equal(0, r);
    }

    [Fact]
    public void Read_Empty()
    {
        var r = IntConverter.ReadInt(Span<byte>.Empty);
        Assert.Equal(0, r);
    }

    [Fact]
    public void Read_Null()
    {
        var r2 = IntConverter.ReadInt(Encoding.UTF8.GetBytes("null"));
        Assert.Equal(0, r2);
    }

    [Fact]
    public void Read_Undefined()
    {
        var r2 = IntConverter.ReadInt(Encoding.UTF8.GetBytes("forsen"));
        Assert.Equal(0, r2);
    }
}
