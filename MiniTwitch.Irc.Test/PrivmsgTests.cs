using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Models;
using Xunit;

namespace MiniTwitch.Irc.Test;

public class PrivmsgTests
{
    [Fact]
    public void Construct()
    {
        var privmsg = Privmsg.Construct("@flags=;user-id=49435922;id=235ec71c-f4ed-485b-abd5-e0849d0d6972;emotes=;user-type=;returning-chatter=0;subscriber=1;display-name=synaxl;mod=0;tmi-sent-ts=1687855313886;turbo=0;room-id=11148817;color=#FF782A;badge-info=subscriber/30;first-msg=0;badges=subscriber/24,twitchconEU2019/1 :synaxl!synaxl@synaxl.tmi.twitch.tv PRIVMSG #pajlada :immer gern Evolution57 Okayge");

        // Author
        Assert.Equal(49435922, privmsg.Author.Id);
        Assert.Equal(UserType.None, privmsg.Author.Type);
        Assert.True(privmsg.Author.IsSubscriber);
        Assert.Equal("synaxl", privmsg.Author.DisplayName);
        Assert.Equal("synaxl", privmsg.Author.Name);
        Assert.False(privmsg.Author.IsMod);
        Assert.False(privmsg.Author.IsTurbo);
        Assert.Equal("FF782A".ToLower(), privmsg.Author.ChatColor.Name);
        Assert.Equal("subscriber/30", privmsg.Author.BadgeInfo);
        Assert.Equal("subscriber/24,twitchconEU2019/1", privmsg.Author.Badges);
        Assert.False(privmsg.Author.IsVip);

        // No reply
        Assert.False(privmsg.Reply.HasContent);
        Assert.Equal(string.Empty, privmsg.Reply.ParentMessage);
        Assert.Equal(string.Empty, privmsg.Reply.ParentDisplayName);
        Assert.Equal(string.Empty, privmsg.Reply.ParentUsername);
        Assert.Equal(string.Empty, privmsg.Reply.ParentMessageId);
        Assert.Equal(0, privmsg.Reply.ParentUserId);
        Assert.Equal(string.Empty, privmsg.Reply.ParentThreadMessageId);
        Assert.Equal(string.Empty, privmsg.Reply.ParentThreadUsername);

        // No hypechat
        Assert.False(privmsg.HypeChat.HasContent);
        Assert.Equal(HypeChatLevel.None, privmsg.HypeChat.Level);
        Assert.Equal(CurrencyCode.None, privmsg.HypeChat.Currency);
        Assert.Equal(0, privmsg.HypeChat.Exponent);
        Assert.Equal(0, privmsg.HypeChat.PaidAmount);
        Assert.False(privmsg.HypeChat.IsSystemMessage);
        Assert.Equal(0, privmsg.HypeChat.GetActualAmount());
        Assert.Equal(TimeSpan.Zero, privmsg.HypeChat.GetPinDuration());

        // Channel
        Assert.Equal("pajlada", privmsg.Channel.Name);
        Assert.Equal(11148817, privmsg.Channel.Id);

        // No source
        Assert.Null(privmsg.Source);
        Assert.True(privmsg.ReplyWith(default!, default!).IsCompleted);

        Assert.Equal(0, privmsg.Bits);
        Assert.Equal("immer gern Evolution57 Okayge", privmsg.Content);
        Assert.Equal(string.Empty, privmsg.Emotes);
        Assert.Equal(string.Empty, privmsg.Flags);
        Assert.Equal("235ec71c-f4ed-485b-abd5-e0849d0d6972", privmsg.Id);
        Assert.False(privmsg.IsAction);
        Assert.False(privmsg.IsFirstMessage);
        Assert.False(privmsg.IsReturningChatter);
        Assert.Equal(string.Empty, privmsg.Nonce);
        Assert.Equal(1687855313886, privmsg.TmiSentTs);
    }

    [Fact]
    public void WithReply()
    {
        var privmsg = Privmsg.Construct("@display-name=pajbot;reply-parent-msg-id=c1b51680-dcab-4f31-b928-84c97cdc7654;flags=;user-type=mod;reply-thread-parent-msg-id=c1b51680-dcab-4f31-b928-84c97cdc7654;reply-thread-parent-user-login=occluder;tmi-sent-ts=1687867130401;user-id=82008718;returning-chatter=0;badge-info=subscriber/90;reply-parent-user-login=occluder;first-msg=0;reply-parent-user-id=783267696;id=922a75b1-6896-4f8f-a28a-40a8f341f655;subscriber=1;emotes=;turbo=0;color=#2E8B57;reply-parent-display-name=occluder;badges=moderator/1,subscriber/3072;reply-parent-msg-body=!;room-id=11148817;mod=1 :pajbot!pajbot@pajbot.tmi.twitch.tv PRIVMSG #pajlada :@occluder 󠀀!!!");

        // Author
        Assert.Equal(82008718, privmsg.Author.Id);
        Assert.Equal(UserType.Mod, privmsg.Author.Type);
        Assert.True(privmsg.Author.IsSubscriber);
        Assert.Equal("pajbot", privmsg.Author.DisplayName);
        Assert.Equal("pajbot", privmsg.Author.Name);
        Assert.True(privmsg.Author.IsMod);
        Assert.False(privmsg.Author.IsTurbo);
        Assert.Equal("2E8B57".ToLower(), privmsg.Author.ChatColor.Name);
        Assert.Equal("subscriber/90", privmsg.Author.BadgeInfo);
        Assert.Equal("moderator/1,subscriber/3072", privmsg.Author.Badges);
        Assert.False(privmsg.Author.IsVip);

        // Has a reply
        Assert.True(privmsg.Reply.HasContent);
        Assert.Equal("!", privmsg.Reply.ParentMessage);
        Assert.Equal("occluder", privmsg.Reply.ParentDisplayName);
        Assert.Equal("occluder", privmsg.Reply.ParentUsername);
        Assert.Equal("c1b51680-dcab-4f31-b928-84c97cdc7654", privmsg.Reply.ParentMessageId);
        Assert.Equal(783267696, privmsg.Reply.ParentUserId);
        // Not a nested reply
        Assert.Equal("c1b51680-dcab-4f31-b928-84c97cdc7654", privmsg.Reply.ParentThreadMessageId);
        Assert.Equal("occluder", privmsg.Reply.ParentThreadUsername);

        // No hypechat
        Assert.False(privmsg.HypeChat.HasContent);
        Assert.Equal(HypeChatLevel.None, privmsg.HypeChat.Level);
        Assert.Equal(CurrencyCode.None, privmsg.HypeChat.Currency);
        Assert.Equal(0, privmsg.HypeChat.Exponent);
        Assert.Equal(0, privmsg.HypeChat.PaidAmount);
        Assert.False(privmsg.HypeChat.IsSystemMessage);
        Assert.Equal(0, privmsg.HypeChat.GetActualAmount());
        Assert.Equal(TimeSpan.Zero, privmsg.HypeChat.GetPinDuration());

        // Channel
        Assert.Equal("pajlada", privmsg.Channel.Name);
        Assert.Equal(11148817, privmsg.Channel.Id);

        // No source
        Assert.Null(privmsg.Source);
        Assert.True(privmsg.ReplyWith(default!, default!).IsCompleted);

        Assert.Equal(0, privmsg.Bits);
        Assert.Equal("@occluder \U000e0000!!!", privmsg.Content);
        Assert.Equal(string.Empty, privmsg.Emotes);
        Assert.Equal(string.Empty, privmsg.Flags);
        Assert.Equal("922a75b1-6896-4f8f-a28a-40a8f341f655", privmsg.Id);
        Assert.False(privmsg.IsAction);
        Assert.False(privmsg.IsFirstMessage);
        Assert.False(privmsg.IsReturningChatter);
        Assert.Equal(string.Empty, privmsg.Nonce);
        Assert.Equal(1687867130401, privmsg.TmiSentTs);
    }

    [Fact]
    public void WithNestedReply()
    {
        var privmsg = Privmsg.Construct("@first-msg=0;reply-parent-user-login=treuks;badges=subscriber/12;display-name=occluder;color=#596FA0;emotes=;flags=;reply-thread-parent-user-login=occluder;returning-chatter=0;tmi-sent-ts=1687870580760;user-id=783267696;user-type=;reply-parent-msg-id=4fe6169e-0dab-4c23-b721-d00327e5eba0;reply-thread-parent-msg-id=32916ff4-780e-451e-b6cc-97d0e8b3e8dd;turbo=0;mod=0;reply-parent-display-name=TreuKS;reply-parent-msg-body=@occluder\\sOMEGALUL\\sgood\\sone;reply-parent-user-id=212793593;room-id=11148817;subscriber=1;id=3229c724-cc5e-43ab-82fe-f95da61c3df0;badge-info=subscriber/13 :occluder!occluder@occluder.tmi.twitch.tv PRIVMSG #pajlada :@TreuKS xd");

        // Author
        Assert.Equal(783267696, privmsg.Author.Id);
        Assert.Equal(UserType.None, privmsg.Author.Type);
        Assert.True(privmsg.Author.IsSubscriber);
        Assert.Equal("occluder", privmsg.Author.DisplayName);
        Assert.Equal("occluder", privmsg.Author.Name);
        Assert.False(privmsg.Author.IsMod);
        Assert.False(privmsg.Author.IsTurbo);
        Assert.Equal("596FA0".ToLower(), privmsg.Author.ChatColor.Name);
        Assert.Equal("subscriber/13", privmsg.Author.BadgeInfo);
        Assert.Equal("subscriber/12", privmsg.Author.Badges);
        Assert.False(privmsg.Author.IsVip);

        // Has a reply
        Assert.True(privmsg.Reply.HasContent);
        Assert.Equal("@occluder OMEGALUL good one", privmsg.Reply.ParentMessage);
        Assert.Equal("TreuKS", privmsg.Reply.ParentDisplayName);
        Assert.Equal("treuks", privmsg.Reply.ParentUsername);
        Assert.Equal("4fe6169e-0dab-4c23-b721-d00327e5eba0", privmsg.Reply.ParentMessageId);
        Assert.Equal(212793593, privmsg.Reply.ParentUserId);
        // Nested
        Assert.Equal("32916ff4-780e-451e-b6cc-97d0e8b3e8dd", privmsg.Reply.ParentThreadMessageId);
        Assert.Equal("occluder", privmsg.Reply.ParentThreadUsername);

        // No hypechat
        Assert.False(privmsg.HypeChat.HasContent);
        Assert.Equal(HypeChatLevel.None, privmsg.HypeChat.Level);
        Assert.Equal(CurrencyCode.None, privmsg.HypeChat.Currency);
        Assert.Equal(0, privmsg.HypeChat.Exponent);
        Assert.Equal(0, privmsg.HypeChat.PaidAmount);
        Assert.False(privmsg.HypeChat.IsSystemMessage);
        Assert.Equal(0, privmsg.HypeChat.GetActualAmount());
        Assert.Equal(TimeSpan.Zero, privmsg.HypeChat.GetPinDuration());

        // Channel
        Assert.Equal("pajlada", privmsg.Channel.Name);
        Assert.Equal(11148817, privmsg.Channel.Id);

        // No source
        Assert.Null(privmsg.Source);
        Assert.True(privmsg.ReplyWith(default!, default!).IsCompleted);

        Assert.Equal(0, privmsg.Bits);
        Assert.Equal("@TreuKS xd", privmsg.Content);
        Assert.Equal(string.Empty, privmsg.Emotes);
        Assert.Equal(string.Empty, privmsg.Flags);
        Assert.Equal("3229c724-cc5e-43ab-82fe-f95da61c3df0", privmsg.Id);
        Assert.False(privmsg.IsAction);
        Assert.False(privmsg.IsFirstMessage);
        Assert.False(privmsg.IsReturningChatter);
        Assert.Equal(string.Empty, privmsg.Nonce);
        Assert.Equal(1687870580760, privmsg.TmiSentTs);
    }

    [Fact]
    public void WithBits()
    {
        var privmsg = Privmsg.Construct("@badge-info=subscriber/10;color=#FFE100;badges=subscriber/6;flags=;turbo=0;display-name=demonbajs;tmi-sent-ts=1687597804051;first-msg=0;user-id=112944037;mod=0;emotes=;subscriber=1;id=3ba61bd7-7d13-46a9-8067-b141e6fa59ce;bits=10;user-type=;returning-chatter=0;room-id=11148817 :demonbajs!demonbajs@demonbajs.tmi.twitch.tv PRIVMSG #pajlada :Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1");

        // Author
        Assert.Equal(112944037, privmsg.Author.Id);
        Assert.Equal(UserType.None, privmsg.Author.Type);
        Assert.True(privmsg.Author.IsSubscriber);
        Assert.Equal("demonbajs", privmsg.Author.DisplayName);
        Assert.Equal("demonbajs", privmsg.Author.Name);
        Assert.False(privmsg.Author.IsMod);
        Assert.False(privmsg.Author.IsTurbo);
        Assert.Equal("FFE100".ToLower(), privmsg.Author.ChatColor.Name);
        Assert.Equal("subscriber/10", privmsg.Author.BadgeInfo);
        Assert.Equal("subscriber/6", privmsg.Author.Badges);
        Assert.False(privmsg.Author.IsVip);

        // No reply
        Assert.False(privmsg.Reply.HasContent);
        Assert.Equal(string.Empty, privmsg.Reply.ParentMessage);
        Assert.Equal(string.Empty, privmsg.Reply.ParentDisplayName);
        Assert.Equal(string.Empty, privmsg.Reply.ParentUsername);
        Assert.Equal(string.Empty, privmsg.Reply.ParentMessageId);
        Assert.Equal(0, privmsg.Reply.ParentUserId);
        Assert.Equal(string.Empty, privmsg.Reply.ParentThreadMessageId);
        Assert.Equal(string.Empty, privmsg.Reply.ParentThreadUsername);

        // No hypechat
        Assert.False(privmsg.HypeChat.HasContent);
        Assert.Equal(HypeChatLevel.None, privmsg.HypeChat.Level);
        Assert.Equal(CurrencyCode.None, privmsg.HypeChat.Currency);
        Assert.Equal(0, privmsg.HypeChat.Exponent);
        Assert.Equal(0, privmsg.HypeChat.PaidAmount);
        Assert.False(privmsg.HypeChat.IsSystemMessage);
        Assert.Equal(0, privmsg.HypeChat.GetActualAmount());
        Assert.Equal(TimeSpan.Zero, privmsg.HypeChat.GetPinDuration());

        // Channel
        Assert.Equal("pajlada", privmsg.Channel.Name);
        Assert.Equal(11148817, privmsg.Channel.Id);

        // No source
        Assert.Null(privmsg.Source);
        Assert.True(privmsg.ReplyWith(default!, default!).IsCompleted);

        Assert.Equal(10, privmsg.Bits);
        Assert.Equal("Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1 Cheer1", privmsg.Content);
        Assert.Equal(string.Empty, privmsg.Emotes);
        Assert.Equal(string.Empty, privmsg.Flags);
        Assert.Equal("3ba61bd7-7d13-46a9-8067-b141e6fa59ce", privmsg.Id);
        Assert.False(privmsg.IsAction);
        Assert.False(privmsg.IsFirstMessage);
        Assert.False(privmsg.IsReturningChatter);
        Assert.Equal(string.Empty, privmsg.Nonce);
        Assert.Equal(1687597804051, privmsg.TmiSentTs);
    }
}
