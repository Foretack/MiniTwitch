using MiniTwitch.Irc.Internal;
using Xunit;

namespace MiniTwitch.Irc.Test;

public class RateLimitManagerTests
{
    [Fact]
    public async Task Spam_RateLimited()
    {
        RateLimitManager manager = new(new() { MessageRateLimit = 30 }) { MessagePeriod = 5000 };
        for (int i = 0; i < 30; i++)
        {
            Assert.True(manager.CanSend("foo", false));
        }

        Assert.False(manager.CanSend("foo", false));
        await Task.Delay(manager.MessagePeriod + 100);
        Assert.True(manager.CanSend("foo", false));
    }

    [Fact]
    public void ModSpam_RateLimited()
    {
        RateLimitManager manager = new(new() { ModMessageRateLimit = 100 }) { MessagePeriod = 5000 };
        for (int i = 0; i < 100; i++)
        {
            Assert.True(manager.CanSend("bar", true));
        }

        Assert.False(manager.CanSend("bar", true));
        Thread.Sleep(manager.MessagePeriod + 100);
        Assert.True(manager.CanSend("bar", true));
    }

    [Fact]
    public void Join_RateLimited()
    {
        RateLimitManager manager = new(new() { JoinRateLimit = 12 }) { JoinPeriod = 1000 };
        for (int i = 0; i < 12; i++)
        {
            Assert.True(manager.CanJoin());
        }

        Assert.False(manager.CanJoin());
        Thread.Sleep(manager.JoinPeriod + 100);
        Assert.True(manager.CanJoin());
    }

    [Fact]
    public async Task Global_Spam_RateLimited()
    {
        RateLimitManager manager = new(new() { MessageRateLimit = 30 }) { MessagePeriod = 5000 };
        for (int i = 0; i < 30; i++)
        {
            Assert.True(manager.CanSend($"foo{i}", false));
        }

        Assert.False(manager.CanSend("foo", false));
        await Task.Delay(manager.MessagePeriod + 100);
        Assert.True(manager.CanSend("foo", false));
    }

    [Fact]
    public async Task Global_ModSpam_RateLimited()
    {
        RateLimitManager manager = new(new() { ModMessageRateLimit = 100 }) { MessagePeriod = 5000 };
        for (int i = 0; i < 100; i++)
        {
            Assert.True(manager.CanSend($"foo{i}", true));
        }

        Assert.False(manager.CanSend("foo", true));
        await Task.Delay(manager.MessagePeriod + 100);
        Assert.True(manager.CanSend("foo", true));
    }

    [Fact]
    public async Task Global_SpamTransition_RateLimited()
    {
        RateLimitManager manager = new(new() { MessageRateLimit = 30, ModMessageRateLimit = 100 }) { MessagePeriod = 5000 };
        // mod to normal
        for (int i = 0; i < 20; i++)
        {
            Assert.True(manager.CanSend($"foo{i}", true));
        }
        for (int i = 0; i < 10; i++)
        {
            Assert.True(manager.CanSend($"{i}oof", false));
        }

        Assert.False(manager.CanSend("fo123oooo", false));
        Assert.True(manager.CanSend("fo123oooo", true));
        await Task.Delay(manager.MessagePeriod + 100);
        Assert.True(manager.CanSend("foo", true));
        Assert.True(manager.CanSend("foo", false));

        manager = new(new() { MessageRateLimit = 30, ModMessageRateLimit = 100 }) { MessagePeriod = 5000 };
        // normal to mod
        for (int i = 0; i < 29; i++)
        {
            Assert.True(manager.CanSend($"foo{i}", false));
        }
        for (int i = 0; i < 70; i++)
        {
            Assert.True(manager.CanSend($"{i}oof", true));
        }

        Assert.True(manager.CanSend("fo123oooo", true));
        Assert.False(manager.CanSend("fo123oooo", false));
        await Task.Delay(manager.MessagePeriod + 100);
        Assert.True(manager.CanSend("foo", true));
        Assert.True(manager.CanSend("foo", false));
    }
}