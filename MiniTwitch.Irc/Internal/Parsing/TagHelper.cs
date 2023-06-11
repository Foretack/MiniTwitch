using System.Text;

namespace MiniTwitch.Irc.Internal.Parsing;

internal static class TagHelper
{
    public static string GetString(ref ReadOnlySpan<byte> span, bool intern = false, bool unescape = false)
    {
        string value;

        if (unescape)
        {
            Span<byte> unescaped = stackalloc byte[span.Length];
            Unescape(span, unescaped);
            value = Encoding.UTF8.GetString(unescaped);
        }
        else
        {
            value = Encoding.UTF8.GetString(span);
        }

        if (intern)
        {
            return string.IsInterned(value) ?? string.Intern(value);
        }

        return value;
    }

    public static bool GetBool(ref ReadOnlySpan<byte> span, bool nonBinary = false)
    {
        const byte zero = (byte)'0';
        if (nonBinary)
        {
            string value = Encoding.UTF8.GetString(span);
            string interned = string.IsInterned(value) ?? string.Intern(value);

            return bool.Parse(interned);
        }

        return span[0] != zero;
    }

    public static int GetInt(ref ReadOnlySpan<byte> span)
    {
        const byte dash = (byte)'-';
        return span[0] == dash ? -1 * ParseInt(span[1..]) : ParseInt(span);
    }

    public static long GetLong(ref ReadOnlySpan<byte> span)
    {
        const byte dash = (byte)'-';
        return span[0] == dash ? -1 * ParseLong(span[1..]) : ParseLong(span);
    }

    public static TEnum GetEnum<TEnum>(ref ReadOnlySpan<byte> span, bool useTry = true)
    where TEnum : struct
    {
        string value = Encoding.UTF8.GetString(span);
        string interned = string.IsInterned(value) ?? string.Intern(value);

        if (useTry)
        {
            if (Enum.TryParse(interned, true, out TEnum result))
            {
                return result;
            }

            return default;
        }

        return Enum.Parse<TEnum>(interned, true);
    }

    private static void Unescape(ReadOnlySpan<byte> source, Span<byte> destination)
    {
        const byte backSlash = (byte)'\\';

        const byte s = (byte)'s';
        const byte colon = (byte)':';
        const byte r = (byte)'r';
        const byte n = (byte)'n';

        const byte space = (byte)' ';
        const byte semicolon = (byte)';';
        const byte cr = (byte)'\r';
        const byte lf = (byte)'\n';

        source.CopyTo(destination);
        if (source.IndexOf(backSlash) == -1)
        {
            return;
        }

        int atIndex = 0;
        int slashIndex;
        while ((slashIndex = source[atIndex..].IndexOf(backSlash)) != -1)
        {
            destination[atIndex + slashIndex] = source[atIndex + slashIndex + 1] switch
            {
                s => space,
                colon => semicolon,
                r => cr,
                n => lf,
                _ => backSlash
            };
            destination[atIndex + slashIndex + 1] = 0;

            atIndex += slashIndex + 2;
        }
    }

    private static int ParseInt(ReadOnlySpan<byte> span)
    {
        const byte numBase = (byte)'0';

        int result = 0;
        foreach (byte b in span)
        {
            result *= 10;
            result += b - numBase;
        }

        return result;
    }

    private static long ParseLong(ReadOnlySpan<byte> span)
    {
        const byte numBase = (byte)'0';

        long result = 0;
        foreach (byte b in span)
        {
            result *= 10L;
            result += b - numBase;
        }

        return result;
    }
}
