using System.Text;
using MiniTwitch.Irc.Internal.Models;
using MiniTwitch.Irc.Internal.Parsing;
using Xunit;

namespace MiniTwitch.Irc.Test;
public class IrcParsingTests
{
    [Fact]
    public void Find_Channel()
    {
        string raw = ":foo!foo@foo.tmi.twitch.tv JOIN #bar";
        string channel = new IrcMessage(Encoding.UTF8.GetBytes(raw)).GetChannel();

        Assert.Equal("bar", channel);
    }

    [Fact]
    public void Find_Content()
    {
        string raw = "@badge-info=subscriber/11;badges=subscriber/6;color=#F2647B;display-name=occluder;emotes=;first-msg=0;flags=;id=e674e393-1230-4a89-bebc-fae1f925e52c;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1680255594264;turbo=0;user-id=783267696;user-type= :occluder!occluder@occluder.tmi.twitch.tv PRIVMSG #pajlada :Are you on some dank browser jammehcow";
        string content = new IrcMessage(Encoding.UTF8.GetBytes(raw)).GetContent().Content;

        Assert.Equal("Are you on some dank browser jammehcow", content);
    }

    [Fact]
    public void Find_Content_Empty()
    {
        string raw = "@badge-info=subscriber/5;badges=subscriber/3;color=#5F9EA0;display-name=Syn993;emotes=;flags=;id=401d17b8-363a-4f63-85c8-cd5996fbd4e0;login=syn993;mod=0;msg-id=resub;msg-param-cumulative-months=5;msg-param-months=0;msg-param-multimonth-duration=0;msg-param-multimonth-tenure=0;msg-param-should-share-streak=1;msg-param-streak-months=4;msg-param-sub-plan-name=Channel\\sSubscription\\s(mandeow);msg-param-sub-plan=1000;msg-param-was-gifted=false;room-id=128856353;subscriber=1;system-msg=Syn993\\ssubscribed\\sat\\sTier\\s1.\\sThey've\\ssubscribed\\sfor\\s5\\smonths,\\scurrently\\son\\sa\\s4\\smonth\\sstreak!;tmi-sent-ts=1678873100296;user-id=79085174;user-type= :tmi.twitch.tv USERNOTICE #mande";
        string content = new IrcMessage(Encoding.UTF8.GetBytes(raw)).GetContent().Content;

        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public void Find_Content_Action()
    {
        string raw = "@badge-info=subscriber/1;badges=subscriber/0;color=#9ACD32;display-name=FeelsCzechMan;emotes=425671:13-20;first-msg=0;flags=;id=0012619e-8e14-4d51-93c9-e9d6fd5a178b;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1679730451594;turbo=0;user-id=875745889;user-type= :feelsczechman!feelsczechman@feelsczechman.tmi.twitch.tv PRIVMSG #pajlada :\u0001ACTION FeelsDankMan PowerUpR DANK WAVE▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂\u0001";
        (string content, bool action) = new IrcMessage(Encoding.UTF8.GetBytes(raw)).GetContent(maybeAction: true);
        Assert.Equal("FeelsDankMan PowerUpR DANK WAVE▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂", content);
        Assert.True(action);
    }

    [Fact]
    public void Find_Content_InvalidAction()
    {
        string raw = "@badge-info=subscriber/1;badges=subscriber/0;color=#9ACD32;display-name=FeelsCzechMan;emotes=425671:13-20;first-msg=0;flags=;id=0012619e-8e14-4d51-93c9-e9d6fd5a178b;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1679730451594;turbo=0;user-id=875745889;user-type= :feelsczechman!feelsczechman@feelsczechman.tmi.twitch.tv PRIVMSG #pajlada :\u0001ACTION \u0001";
        (string content, bool action) = new IrcMessage(Encoding.UTF8.GetBytes(raw)).GetContent();

        Assert.False(action);
        Assert.Equal("\u0001ACTION \u0001", content);
    }

    [Fact]
    public void Find_Username()
    {
        string raw = "@badge-info=subscriber/1;badges=subscriber/0;color=#9ACD32;display-name=FeelsCzechMan;emotes=425671:13-20;first-msg=0;flags=;id=0012619e-8e14-4d51-93c9-e9d6fd5a178b;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1679730451594;turbo=0;user-id=875745889;user-type= :feelsczechman!feelsczechman@feelsczechman.tmi.twitch.tv PRIVMSG #pajlada :\u0001ACTION FeelsDankMan PowerUpR DANK WAVE▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂▂▃▄▅▆▇██▇▆▅▄▃▂\u0001";
        string username = new IrcMessage(Encoding.UTF8.GetBytes(raw)).GetUsername();

        Assert.Equal("feelsczechman", username);
    }

    [Fact]
    public void Find_Username_NoTags()
    {
        string raw = ":pajapajapaja!pajapajapaja@pajapajapaja.tmi.twitch.tv JOIN #bar";
        string username = new IrcMessage(Encoding.UTF8.GetBytes(raw)).GetUsername();

        Assert.Equal("pajapajapaja", username);
    }
}
