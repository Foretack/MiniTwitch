using System.Text;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Test.Converters;

public class OptionalLongConverterTest
{
    [Fact]
    public void Read_Int()
    {
        var r = OptionalLongConverter.ReadLong(Encoding.UTF8.GetBytes("12345"));
        var val = Assert.NotNull(r);
        Assert.Equal(12345, val);
    }

    [Fact]
    public void Read_Long()
    {
        var r = OptionalLongConverter.ReadLong(Encoding.UTF8.GetBytes("8223372036854780000"));
        var val = Assert.NotNull(r);
        Assert.Equal(8223372036854780000, val);
    }

    [Fact]
    public void Read_Empty()
    {
        var r = OptionalLongConverter.ReadLong(Span<byte>.Empty);
        Assert.Null(r);
    }

    [Fact]
    public void Read_Null()
    {
        var r2 = OptionalLongConverter.ReadLong(Encoding.UTF8.GetBytes("null"));
        Assert.Null(r2);
    }

    [Fact]
    public void Read_Undefined()
    {
        var r2 = OptionalLongConverter.ReadLong(Encoding.UTF8.GetBytes("forsen"));
        Assert.Null(r2);
    }
}
