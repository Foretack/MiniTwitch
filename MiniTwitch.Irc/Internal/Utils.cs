using MiniTwitch.Irc.Models;

namespace MiniTwitch.Irc.Internal;
internal static class Utils
{
    public static string CheckToken(string token) => token.StartsWith("oauth:", StringComparison.CurrentCultureIgnoreCase) ? token[7..] : token;

    public static void CheckCredentials(this ClientOptions options)
    {
        if (!options.Anonymous && (string.IsNullOrEmpty(options.OAuth) || string.IsNullOrEmpty(options.Username)))
        {
            throw new MissingCredentialsException("Username and/or OAuth are missing");
        }
        // https://i.imgur.com/NRGvben.png
        else if (DateTime.Now is { Month: 4, Day: 1 } && Random.Shared.Next(10) == 1)
        {
            throw new MissingCredentialsException("Invalid credentials");
        }
    }
}
