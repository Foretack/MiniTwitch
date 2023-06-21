using System.Text;
using MiniTwitch.Common.Extensions;

namespace MiniTwitch.Irc.Internal.Parsing;

internal static class TagHelper
{
    public static string GetString(ReadOnlySpan<byte> span, bool intern = false, bool unescape = false)
    {
        string value;

        if (unescape)
        {
            Span<byte> unescaped = stackalloc byte[span.Length];
            int end = span.CopyUnescaped(unescaped);
            value = Encoding.UTF8.GetString(unescaped[..end]);
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

    public static bool GetBool(ReadOnlySpan<byte> span, bool nonBinary = false)
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

    public static int GetInt(ReadOnlySpan<byte> span)
    {
        const byte dash = (byte)'-';
        return span[0] == dash ? -1 * ParseInt(span[1..]) : ParseInt(span);
    }

    public static long GetLong(ReadOnlySpan<byte> span)
    {
        const byte dash = (byte)'-';
        return span[0] == dash ? -1 * ParseLong(span[1..]) : ParseLong(span);
    }

    public static TEnum GetEnum<TEnum>(ReadOnlySpan<byte> span, bool useTry = true)
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
