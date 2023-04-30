using MiniTwitch.Irc.Models;
using Xunit;

namespace MiniTwitch.Irc.Test;

public class ExceptionTests
{
    [Fact]
    public void Missing_Credentials_Throws_Ex()
    {
        _ = Assert.Throws<MissingCredentialsException>(() =>
        {
            IrcClient client = new(_ => { });
            _ = client;
        });
    }
}
