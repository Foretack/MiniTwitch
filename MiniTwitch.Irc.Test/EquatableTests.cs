using MiniTwitch.Irc.Models;
using Xunit;

namespace MiniTwitch.Irc.Test;

public class EquatableTests
{
    [Fact]
    public void Usernotice_Equatable()
    {
        string raw = "@badge-info=subscriber/86;badges=moderator/1,subscriber/3072;color=#2E8B57;display-name=pajbot;emotes=;flags=;id=50f06104-1425-4e61-8d69-19b2e910cc92;login=pajbot;mod=1;msg-id=announcement;msg-param-color=PRIMARY;room-id=11148817;subscriber=1;system-msg=;tmi-sent-ts=1678652624650;user-id=82008718;user-type=mod :tmi.twitch.tv USERNOTICE #pajlada :guh";
        var usernotice = Usernotice.Construct(raw);
        var usernotice2 = Usernotice.Construct(raw);
        Assert.True(usernotice == usernotice2);

        string raw2 = "@badge-info=;badges=broadcaster/1;color=#F2647B;display-name=occluder;emotes=;flags=;id=c10d18ca-c15b-4294-bf17-fe316acd21ff;login=occluder;mod=0;msg-id=announcement;msg-param-color=BLUE;room-id=783267696;subscriber=0;system-msg=;tmi-sent-ts=1678880148283;user-id=783267696;user-type= :tmi.twitch.tv USERNOTICE #occluder :kek";
        var usernotice3 = Usernotice.Construct(raw2);
        Assert.False(usernotice3 == usernotice);
        Assert.False(usernotice3 == usernotice2);
    }

    [Fact]
    public void Privmsg_Equatable()
    {
        string raw = "@badge-info=subscriber/42;badges=subscriber/42,glhf-pledge/1;color=#F97304;display-name=zneix;emotes=;first-msg=0;flags=;id=ffc033d5-862c-413c-8422-72a59aa1b0f1;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1678752306574;turbo=0;user-id=99631238;user-type= :zneix!zneix@zneix.tmi.twitch.tv PRIVMSG #pajlada :btw DFantasy, have you gotten an unused Dragon Hunter Crossbow just laying around by any chance? kkOna";
        var privmsg = Privmsg.Construct(raw);
        var privmsg2 = Privmsg.Construct(raw);
        Assert.True(privmsg == privmsg2);
        Assert.True(privmsg == "btw DFantasy, have you gotten an unused Dragon Hunter Crossbow just laying around by any chance? kkOna");
        Assert.True(privmsg2 == "btw DFantasy, have you gotten an unused Dragon Hunter Crossbow just laying around by any chance? kkOna");

        string raw2 = "@badge-info=subscriber/16;badges=subscriber/12;color=#CC3370;display-name=Bordkaant;emotes=;first-msg=0;flags=;id=3189075d-142b-45d2-9303-9a6dbaf89f8b;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1680352789520;turbo=0;user-id=571734662;user-type= :bordkaant!bordkaant@bordkaant.tmi.twitch.tv PRIVMSG #pajlada :!rq";
        var privmsg3 = Privmsg.Construct(raw2);
        Assert.False(privmsg3 == privmsg);
        Assert.False(privmsg3 == privmsg2);
        Assert.True(privmsg3 == "!rq");
    }
}
