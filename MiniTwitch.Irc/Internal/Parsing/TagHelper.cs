using System.Drawing;
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
            Span<char> charSpan = stackalloc char[span.Length];
            int charsWritten = Encoding.UTF8.GetChars(span, charSpan);
            return bool.Parse(charSpan[..charsWritten]);
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
        Span<char> charSpan = stackalloc char[span.Length];
        int charsWritten = Encoding.UTF8.GetChars(span, charSpan);
        if (useTry)
        {
            if (Enum.TryParse(charSpan[..charsWritten], true, out TEnum result))
            {
                return result;
            }

            return default;
        }

        return Enum.Parse<TEnum>(charSpan[..charsWritten], true);
    }

    public static Color GetColor(ReadOnlySpan<byte> hexBytes)
    {
        const byte zero = (byte)'0';
        const byte nine = (byte)'9';
        const byte leading = (byte)'#';
        const byte A = (byte)'A';

        int hexValue = 0;
        foreach (byte b in hexBytes)
        {
            if (b == leading)
                continue;

            hexValue = (hexValue << 4) | (b is >= zero and <= nine ? b - zero : (b & 0x4F) - A + 10);
        }

        return Color.FromArgb(hexValue);
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
