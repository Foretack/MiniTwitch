using MiniTwitch.Irc.Interfaces;
using MiniTwitch.Irc.Models;
using Xunit;

namespace MiniTwitch.Irc.Test;
public class ClearchatTests
{
    [Fact]
    public void Ban_CLEARCHAT()
    {
        string raw = "@room-id=783267696;target-user-id=552216574;tmi-sent-ts=1678822185816 :tmi.twitch.tv CLEARCHAT #occluder :weeb432";
        var clearchat = Clearchat.Construct(raw);
        Assert.True(clearchat.IsBan);
        IUserBan ban = clearchat;

        Assert.Equal(783267696, ban.Channel.Id);
        Assert.Equal(552216574, ban.Target.Id);
        Assert.Equal(1678822185816, ban.TmiSentTs);
        Assert.Equal("occluder", ban.Channel.Name);
        Assert.Equal("weeb432", ban.Target.Name);
    }
    [Fact]
    public void Timeout_CLEARCHAT()
    {
        string raw = "@ban-duration=30;room-id=11148817;target-user-id=783267696;tmi-sent-ts=1678712873805 :tmi.twitch.tv CLEARCHAT #pajlada :occluder";
        var clearchat = Clearchat.Construct(raw);
        Assert.False(clearchat.IsBan);
        Assert.False(clearchat.IsClearChat);
        IUserTimeout timeout = clearchat;

        Assert.Equal(TimeSpan.FromSeconds(30), timeout.Duration);
        Assert.Equal(11148817, timeout.Channel.Id);
        Assert.Equal(783267696, timeout.Target.Id);
        Assert.Equal(1678712873805, timeout.TmiSentTs);
        Assert.Equal("pajlada", timeout.Channel.Name);
        Assert.Equal("occluder", timeout.Target.Name);
    }
    [Fact]
    public void Clear_CLEARCHAT()
    {
        string raw = "@room-id=783267696;tmi-sent-ts=1678822192531 :tmi.twitch.tv CLEARCHAT #occluder";
        var clearchat = Clearchat.Construct(raw);
        Assert.True(clearchat.IsClearChat);
        IChatClear chatclear = clearchat;

        Assert.Equal(783267696, chatclear.Channel.Id);
        Assert.Equal(1678822192531, chatclear.TmiSentTs);
        Assert.Equal("occluder", chatclear.Channel.Name);
    }
}
