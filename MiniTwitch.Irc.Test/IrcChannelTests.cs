using MiniTwitch.Irc.Internal.Enums;
using MiniTwitch.Irc.Models;
using Xunit;

namespace MiniTwitch.Irc.Test;

public class IrcChannelTests
{
    [Fact]
    public void ChannelOf_USERSTATE()
    {
        string raw = "@badge-info=;badges=broadcaster/1;color=#F2647B;display-name=occluder;emote-sets=0,4236,15961,19194,376284588,385292559,477339272,5fc5e142-d394-481f-a561-5406c2ba3ef0,e21484e8-cf11-48b1-8b67-c180fa39f926;mod=0;subscriber=0;user-type= :tmi.twitch.tv USERSTATE #occluder";
        var userstate = Userstate.Construct(raw);
        var channel = (IrcChannel)userstate.Channel;

        Assert.Equal("occluder", channel.Name);

        Assert.Equal(default, channel.UniqueModeEnabled);
        Assert.Equal(default, channel.EmoteOnlyEnabled);
        Assert.Equal(default, channel.FollowerModeDuration);
        Assert.Equal(default, channel.FollowerModeEnabled);
        Assert.Equal(default, channel.Id);
        Assert.Equal(default, channel.Roomstate);
        Assert.Equal(default, channel.SlowModeEnabled);
        Assert.Equal(default, channel.SlowModeDuration);
        Assert.Equal(default, channel.SubOnlyEnabled);
    }

    [Fact]
    public void ChannelOf_USERNOTICE()
    {
        string raw = "@badge-info=subscriber/13;badges=subscriber/12,premium/1;color=#0000FF;display-name=Goop_456789;emotes=;flags=;id=f27c6766-80b3-4eb5-875e-ec892ca4cb3a;login=goop_456789;mod=0;msg-id=subgift;msg-param-gift-months=1;msg-param-months=12;msg-param-origin-id=a3\\s66\\s1f\\s0f\\sc7\\sb9\\sbb\\sc7\\s82\\sb4\\s8f\\sad\\s7b\\sb0\\s10\\s2c\\sfe\\s0b\\sb2\\sbf;msg-param-recipient-display-name=Zackpanjang;msg-param-recipient-id=412581855;msg-param-recipient-user-name=zackpanjang;msg-param-sender-count=11;msg-param-sub-plan-name=Channel\\sSubscription\\s(mandeow);msg-param-sub-plan=1000;room-id=128856353;subscriber=1;system-msg=Goop_456789\\sgifted\\sa\\sTier\\s1\\ssub\\sto\\sZackpanjang!\\sThey\\shave\\sgiven\\s11\\sGift\\sSubs\\sin\\sthe\\schannel!;tmi-sent-ts=1678876353907;user-id=93668177;user-type= :tmi.twitch.tv USERNOTICE #mande";
        var usernotice = Usernotice.Construct(raw);
        var channel = (IrcChannel)usernotice.Channel;

        Assert.Equal("mande", channel.Name);
        Assert.Equal(128856353, channel.Id);

        Assert.Equal(default, channel.UniqueModeEnabled);
        Assert.Equal(default, channel.EmoteOnlyEnabled);
        Assert.Equal(default, channel.FollowerModeDuration);
        Assert.Equal(default, channel.FollowerModeEnabled);
        Assert.Equal(default, channel.Roomstate);
        Assert.Equal(default, channel.SlowModeEnabled);
        Assert.Equal(default, channel.SlowModeDuration);
        Assert.Equal(default, channel.SubOnlyEnabled);
    }

    [Fact]
    public void ChannelOf_PRIVMSG()
    {
        string raw = "@badge-info=;badges=glitchcon2020/1;color=#008000;display-name=Mm_sUtilityBot;emotes=;first-msg=0;flags=;id=427ec07a-784e-4d5b-85a6-5fa9d25922f7;mod=0;reply-parent-display-name=nerixyz;reply-parent-msg-body=c2#2345;reply-parent-msg-id=dde74aeb-176b-40ad-ae64-60d7a07d01a0;reply-parent-user-id=129546453;reply-parent-user-login=nerixyz;returning-chatter=0;room-id=11148817;subscriber=0;tmi-sent-ts=1680727280734;turbo=0;user-id=442600612;user-type= :mm_sutilitybot!mm_sutilitybot@mm_sutilitybot.tmi.twitch.tv PRIVMSG #pajlada :@nerixyz https://github.com/Chatterino/Chatterino2/issues/2345";
        var privmsg = Privmsg.Construct(raw);
        var channel = (IrcChannel)privmsg.Channel;

        Assert.Equal("pajlada", channel.Name);
        Assert.Equal(11148817, channel.Id);

        Assert.Equal(default, channel.UniqueModeEnabled);
        Assert.Equal(default, channel.EmoteOnlyEnabled);
        Assert.Equal(default, channel.FollowerModeDuration);
        Assert.Equal(default, channel.FollowerModeEnabled);
        Assert.Equal(default, channel.Roomstate);
        Assert.Equal(default, channel.SlowModeEnabled);
        Assert.Equal(default, channel.SlowModeDuration);
        Assert.Equal(default, channel.SubOnlyEnabled);
    }

    [Fact]
    public void ChannelOf_CLEARMSG()
    {
        string raw = "@login=occluder;room-id=;target-msg-id=55dc74c9-a6b2-4443-9b68-3446a5ddb7ed;tmi-sent-ts=1678798254260 :tmi.twitch.tv CLEARMSG #occluder :@emote-only=0;followers-only=-1;r9k=0;room-id=783267696;slow=0;subs-only=0 :tmi.twitch.tv ROOMSTATE #occluder ";
        var clearmsg = Clearmsg.Construct(raw);
        var channel = (IrcChannel)clearmsg.Channel;

        Assert.Equal("occluder", channel.Name);

        Assert.Equal(default, channel.UniqueModeEnabled);
        Assert.Equal(default, channel.EmoteOnlyEnabled);
        Assert.Equal(default, channel.FollowerModeDuration);
        Assert.Equal(default, channel.FollowerModeEnabled);
        Assert.Equal(default, channel.Id);
        Assert.Equal(default, channel.Roomstate);
        Assert.Equal(default, channel.SlowModeEnabled);
        Assert.Equal(default, channel.SlowModeDuration);
        Assert.Equal(default, channel.SubOnlyEnabled);
    }

    [Fact]
    public void ChannelOf_CLEARCHAT()
    {
        string raw = "@ban-duration=30;room-id=11148817;target-user-id=783267696;tmi-sent-ts=1678712873805 :tmi.twitch.tv CLEARCHAT #pajlada :occluder";
        var clearchat = Clearchat.Construct(raw);
        var channel = (IrcChannel)clearchat.Channel;

        Assert.Equal("pajlada", channel.Name);
        Assert.Equal(11148817, channel.Id);

        Assert.Equal(default, channel.UniqueModeEnabled);
        Assert.Equal(default, channel.EmoteOnlyEnabled);
        Assert.Equal(default, channel.FollowerModeDuration);
        Assert.Equal(default, channel.FollowerModeEnabled);
        Assert.Equal(default, channel.Roomstate);
        Assert.Equal(default, channel.SlowModeEnabled);
        Assert.Equal(default, channel.SlowModeDuration);
        Assert.Equal(default, channel.SubOnlyEnabled);
    }

    [Fact]
    public void ChannelOf_ROOMSTATE()
    {
        string raw = "@emote-only=0;followers-only=-1;r9k=0;room-id=783267696;slow=0;subs-only=0 :tmi.twitch.tv ROOMSTATE #occluder";
        var channel = IrcChannel.Construct(raw);

        Assert.Equal("occluder", channel.Name);
        Assert.Equal(783267696, channel.Id);
        Assert.Equal(TimeSpan.FromMinutes(-1), channel.FollowerModeDuration);
        Assert.Equal(RoomstateType.All, channel.Roomstate);
        Assert.Equal(TimeSpan.Zero, channel.SlowModeDuration);
        Assert.False(channel.UniqueModeEnabled);
        Assert.False(channel.EmoteOnlyEnabled);
        Assert.False(channel.FollowerModeEnabled);
        Assert.False(channel.SlowModeEnabled);
        Assert.False(channel.SubOnlyEnabled);
    }

    [Fact]
    public void ChannelOf_NOTICE()
    {
        string raw = "@msg-id=msg_channel_suspended :tmi.twitch.tv NOTICE #foretack :This channel does not exist or has been suspended.";
        var notice = Notice.Construct(raw);
        var channel = (IrcChannel)notice.Channel;

        Assert.Equal("foretack", channel.Name);

        Assert.Equal(default, channel.UniqueModeEnabled);
        Assert.Equal(default, channel.EmoteOnlyEnabled);
        Assert.Equal(default, channel.FollowerModeDuration);
        Assert.Equal(default, channel.FollowerModeEnabled);
        Assert.Equal(default, channel.Id);
        Assert.Equal(default, channel.Roomstate);
        Assert.Equal(default, channel.SlowModeEnabled);
        Assert.Equal(default, channel.SlowModeDuration);
        Assert.Equal(default, channel.SubOnlyEnabled);
    }
}
