using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Test;

public class SnakeCaseTest
{
    [Fact]
    public void From_SnakeCase()
    {
        ICaseConverter converter = SnakeCase.Instance;
        string? converted = converter.ConvertFromCase("hello_world");
        Assert.Equal("HelloWorld", converted);
    }

    [Fact]
    public void From_Null_SnakeCase()
    {
        ICaseConverter converter = SnakeCase.Instance;
        string? converted = converter.ConvertFromCase(null);
        Assert.Null(converted);
    }

    [Fact]
    public void From_Empty_SnakeCase()
    {
        ICaseConverter converter = SnakeCase.Instance;
        string? converted = converter.ConvertFromCase(string.Empty);
        Assert.NotNull(converted);
        Assert.Empty(converted);
    }

    [Fact]
    public void From_Space_SnakeCase()
    {
        ICaseConverter converter = SnakeCase.Instance;
        string? converted = converter.ConvertFromCase(" ");
        Assert.NotNull(converted);
        Assert.Equal(" ", converted);
    }

    [Fact]
    public void To_SnakeCase()
    {
        ICaseConverter converter = SnakeCase.Instance;
        string? converted = converter.ConvertToCase("HelloForsenPajladaOne");
        Assert.Equal("hello_forsen_pajlada_one", converted);
    }

    [Fact]
    public void Null_To_SnakeCase()
    {
        ICaseConverter converter = SnakeCase.Instance;
        string? converted = converter.ConvertToCase(null);
        Assert.Null(converted);
    }

    [Fact]
    public void Empty_To_SnakeCase()
    {
        ICaseConverter converter = SnakeCase.Instance;
        string? converted = converter.ConvertToCase(string.Empty);
        Assert.NotNull(converted);
        Assert.Empty(converted);
    }

    [Fact]
    public void Space_To_SnakeCase()
    {
        ICaseConverter converter = SnakeCase.Instance;
        string? converted = converter.ConvertToCase(" ");
        Assert.NotNull(converted);
        Assert.Equal(" ", converted);
    }
}