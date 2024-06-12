using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Test.Converters;

public class EnumConverterTest
{
    [Fact]
    public void Convert()
    {
        var e = EnumConverter<TestEnum>.ReadEnum("Forsaan");
        Assert.Equal(TestEnum.Forsaan, e);
    }

    [Fact]
    public void Convert_From_SnakeCase()
    {
        var e = EnumConverter<TestEnum>.ReadEnum("i_eat_rocks");
        Assert.Equal(TestEnum.IEatRocks, e);
    }

    [Fact]
    public void Convert_From_Null()
    {
        var e = EnumConverter<TestEnum>.ReadEnum(null);
        Assert.Equal(default(TestEnum), e);
    }

    [Fact]
    public void Convert_From_Undefined()
    {
        var e = EnumConverter<TestEnum>.ReadEnum("my life is doge");
        Assert.Equal(default(TestEnum), e);
    }

    enum TestEnum
    {
        Unknown,
        Forshon,
        Forsen,
        Forsaan,
        IEatRocks,
        XD
    }
}
