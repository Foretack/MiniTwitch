using System.Text;
using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Internal.Parsing;
using Xunit;

namespace MiniTwitch.Irc.Test;

public class TagHelperTests
{
    [Fact]
    public void GetString()
    {
        string raw = "forsenforsen123";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        string result = TagHelper.GetString(span);
        Assert.Equal(raw, result);
    }

    [Fact]
    public void GetString_Interned()
    {
        string raw = "LUL!";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        string result = TagHelper.GetString(span, true);
        Assert.Equal(raw, result);
        Assert.True(string.IsInterned(result) is not null);
    }

    [Fact]
    public void GetString_Escaped()
    {
        string raw = @"i\slolled\sxD";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        string result = TagHelper.GetString(span, unescape: true);
        Assert.Equal(@"i lolled xD", result);

        string raw2 = @"i\slolled\:xD";
        ReadOnlySpan<byte> span2 = Encoding.UTF8.GetBytes(raw2).AsSpan();
        string result2 = TagHelper.GetString(span2, unescape: true);
        Assert.Equal(@"i lolled;xD", result2);
    }

    [Fact]
    public void GetBool()
    {
        string raw = "1";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        bool result = TagHelper.GetBool(span);
        Assert.True(result);
    }

    [Fact]
    public void GetBool_NonBinary()
    {
        string raw = "true";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        bool result = TagHelper.GetBool(span, nonBinary: true);
        Assert.True(result);
    }

    [Fact]
    public void GetInt()
    {
        string raw = "12345678";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        int result = TagHelper.GetInt(span);
        Assert.Equal(int.Parse(raw), result);
    }

    [Fact]
    public void GetInt_Negative()
    {
        string raw = "-12345678";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        int result = TagHelper.GetInt(span);
        Assert.Equal(int.Parse(raw), result);
    }

    [Fact]
    public void GetLong()
    {
        string raw = "12345678901234567";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        long result = TagHelper.GetLong(span);
        Assert.Equal(long.Parse(raw), result);
    }

    [Fact]
    public void GetLong_Negative()
    {
        string raw = "-12345678901234567";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        long result = TagHelper.GetLong(span);
        Assert.Equal(long.Parse(raw), result);
    }

    [Fact]
    public void GetEnum()
    {
        string raw = "admin";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        UserType result = TagHelper.GetEnum<UserType>(span);
        Assert.Equal(UserType.Admin, result);
    }

    [Fact]
    public void GetEnum_Unknown()
    {
        string raw = "xDlolrandomthing";
        ReadOnlySpan<byte> span = Encoding.UTF8.GetBytes(raw).AsSpan();
        UserType result = TagHelper.GetEnum<UserType>(span);
        Assert.Equal(UserType.None, result);
    }
}
