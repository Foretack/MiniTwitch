namespace MiniTwitch.Helix.Internal.Json;

internal class SnakeCase : ICaseConverter
{
    public static SnakeCase Instance { get; } = new();

    public string? ConvertFromCase(string? str)
    {
        if (str is null)
            return null;

        const char underscore = '_';

        ReadOnlySpan<char> chars = str;
        Span<char> replacement = stackalloc char[chars.Length];
        int i = 1;
        int offset = 0;
        replacement[0] = char.ToUpper(chars[0]);
        for (; i < chars.Length - offset; i++)
        {
            char c = chars[i + offset];
            replacement[i] = c == underscore ? char.ToUpper(chars[i + ++offset]) : c;
        }

        return replacement[..i].ToString();
    }

    public string? ConvertToCase(string? str)
    {
        if (str is null)
            return null;

        const char underscore = '_';

        ReadOnlySpan<char> chars = str;
        Span<char> replacement = stackalloc char[chars.Length * 2];
        int i = 1;
        int offset = 0;
        replacement[0] = char.ToLower(chars[0]);
        for (; i < chars.Length; i++)
        {
            char c = chars[i];
            if (char.IsUpper(c))
            {
                replacement[i + offset++] = underscore;
                replacement[i + offset] = char.ToLower(c);
            }
            else
            {
                replacement[i + offset] = c;
            }
        }

        return replacement[..(i + offset)].ToString();
    }
}
