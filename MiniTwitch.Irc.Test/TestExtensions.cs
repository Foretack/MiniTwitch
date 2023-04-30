namespace MiniTwitch.Irc.Test;
internal static class TestExtensions
{
    public static string Unescape(this string str) => str.Replace("\\s", " \0").Replace("\\:", ";\0");
}
