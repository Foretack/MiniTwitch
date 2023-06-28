using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Models;
using Xunit;

namespace MiniTwitch.Irc.Test;
public class MessageAuthorTests
{
    [Fact]
    public void AuthorOf_PRIVMSG()
    {
        string raw = "@badge-info=subscriber/42;badges=subscriber/42,glhf-pledge/1;color=#F97304;display-name=zneix;emotes=;first-msg=0;flags=;id=ffc033d5-862c-413c-8422-72a59aa1b0f1;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1678752306574;turbo=0;user-id=99631238;user-type= :zneix!zneix@zneix.tmi.twitch.tv PRIVMSG #pajlada :btw DFantasy, have you gotten an unused Dragon Hunter Crossbow just laying around by any chance? kkOna";
        var privmsg = Privmsg.Construct(raw);
        MessageAuthor author = privmsg.Author;

        Assert.Equal("subscriber/42", author.BadgeInfo);
        Assert.Equal("subscriber/42,glhf-pledge/1", author.Badges);
        Assert.Equal("f97304", author.ChatColor.Name);
        Assert.Equal("zneix", author.DisplayName);
        Assert.Equal("zneix", author.Name);
        Assert.Equal(99631238, author.Id);
        Assert.Equal(UserType.None, author.Type);
        Assert.True(author.IsSubscriber);
        Assert.False(author.IsTurbo);
        Assert.False(author.IsVip);
        Assert.False(author.IsMod);
    }

    [Fact]
    public void AuthorOf_CLEARCHAT()
    {
        string raw = "@ban-duration=30;room-id=11148817;target-user-id=783267696;tmi-sent-ts=1678712873805 :tmi.twitch.tv CLEARCHAT #pajlada :occluder";
        var clearchat = Clearchat.Construct(raw);
        var author = (MessageAuthor)clearchat.Target;

        Assert.Equal("occluder", author.Name);
        Assert.Equal(783267696, author.Id);
        Assert.False(author.IsVip);
        Assert.False(author.IsSubscriber);
        Assert.False(author.IsTurbo);
        Assert.False(author.IsMod);

        Assert.Equal(default, author.BadgeInfo);
        Assert.Equal(default, author.Badges);
        Assert.Equal(default, author.ChatColor);
        Assert.Equal(default, author.DisplayName);
        Assert.Equal(default, author.Type);
    }

    [Fact]
    public void AuthorOf_USERSTATE()
    {
        string raw = "@badge-info=;badges=broadcaster/1;color=#F2647B;display-name=occluder;emote-sets=0,4236,15961,19194,376284588,385292559,477339272,5fc5e142-d394-481f-a561-5406c2ba3ef0,e21484e8-cf11-48b1-8b67-c180fa39f926;mod=0;subscriber=0;user-type= :tmi.twitch.tv USERSTATE #occluder";
        var userstate = Userstate.Construct(raw);
        var author = (MessageAuthor)userstate.Self;

        Assert.Equal(string.Empty, author.BadgeInfo);
        Assert.Equal("broadcaster/1", author.Badges);
        Assert.Equal("f2647b", author.ChatColor.Name);
        Assert.Equal("occluder", author.Name);
        Assert.Equal("occluder", author.DisplayName);
        Assert.Equal(UserType.None, author.Type);
        Assert.True(author.IsMod);
        Assert.False(author.IsSubscriber);
        Assert.False(author.IsVip);

        Assert.Equal(default, author.IsTurbo);
        Assert.Equal(default, author.Id);
    }

    [Fact]
    public void AuthorOf_CLEARMSG()
    {
        string raw = "@login=occluder;room-id=;target-msg-id=55dc74c9-a6b2-4443-9b68-3446a5ddb7ed;tmi-sent-ts=1678798254260 :tmi.twitch.tv CLEARMSG #occluder :@emote-only=0;followers-only=-1;r9k=0;room-id=783267696;slow=0;subs-only=0 :tmi.twitch.tv ROOMSTATE #occluder ";
        var clearmsg = Clearmsg.Construct(raw);
        var author = (MessageAuthor)clearmsg.Target;

        Assert.Equal("occluder", author.Name);

        Assert.Equal(default, author.BadgeInfo);
        Assert.Equal(default, author.Badges);
        Assert.Equal(default, author.ChatColor);
        Assert.Equal(default, author.DisplayName);
        Assert.Equal(default, author.IsSubscriber);
        Assert.Equal(default, author.IsTurbo);
        Assert.Equal(default, author.Id);
        Assert.Equal(default, author.Type);
        Assert.Equal(default, author.IsVip);
        Assert.Equal(default, author.IsMod);
    }

    [Fact]
    public void AuthorOf_WHISPER()
    {
        string raw = "@badges=;color=#2E8B57;display-name=pajbot;emotes=25:7-11;message-id=7;thread-id=82008718_783267696;turbo=0;user-id=82008718;user-type= :pajbot!pajbot@pajbot.tmi.twitch.tv WHISPER occluder :Riftey Kappa";
        var whisper = Whisper.Construct(raw);
        var author = (MessageAuthor)whisper.Author;

        Assert.Equal(string.Empty, author.Badges);
        Assert.Equal("2e8b57", author.ChatColor.Name);
        Assert.Equal("pajbot", author.DisplayName);
        Assert.Equal("pajbot", author.Name);
        Assert.Equal(82008718, author.Id);
        Assert.Equal(UserType.None, author.Type);

        Assert.Equal(default, author.BadgeInfo);
        Assert.Equal(default, author.IsTurbo);
        Assert.Equal(default, author.IsMod);
        Assert.Equal(default, author.IsVip);
        Assert.Equal(default, author.IsSubscriber);
    }

    [Fact]
    public void AuthorOf_USERNOTICE()
    {
        string raw = "@badge-info=subscriber/13;badges=subscriber/12,premium/1;color=#0000FF;display-name=Goop_456789;emotes=;flags=;id=f27c6766-80b3-4eb5-875e-ec892ca4cb3a;login=goop_456789;mod=0;msg-id=subgift;msg-param-gift-months=1;msg-param-months=12;msg-param-origin-id=a3\\s66\\s1f\\s0f\\sc7\\sb9\\sbb\\sc7\\s82\\sb4\\s8f\\sad\\s7b\\sb0\\s10\\s2c\\sfe\\s0b\\sb2\\sbf;msg-param-recipient-display-name=Zackpanjang;msg-param-recipient-id=412581855;msg-param-recipient-user-name=zackpanjang;msg-param-sender-count=11;msg-param-sub-plan-name=Channel\\sSubscription\\s(mandeow);msg-param-sub-plan=1000;room-id=128856353;subscriber=1;system-msg=Goop_456789\\sgifted\\sa\\sTier\\s1\\ssub\\sto\\sZackpanjang!\\sThey\\shave\\sgiven\\s11\\sGift\\sSubs\\sin\\sthe\\schannel!;tmi-sent-ts=1678876353907;user-id=93668177;user-type= :tmi.twitch.tv USERNOTICE #mande";
        var usernotice = Usernotice.Construct(raw);
        MessageAuthor author = usernotice.Author;

        Assert.Equal("subscriber/13", author.BadgeInfo);
        Assert.Equal("subscriber/12,premium/1", author.Badges);
        Assert.Equal("ff", author.ChatColor.Name);
        Assert.Equal("Goop_456789", author.DisplayName);
        Assert.Equal("goop_456789", author.Name);
        Assert.Equal(93668177, author.Id);
        Assert.Equal(UserType.None, author.Type);
        Assert.True(author.IsSubscriber);
        Assert.False(author.IsVip);
        Assert.False(author.IsMod);

        Assert.Equal(default, author.IsTurbo);
    }
}
