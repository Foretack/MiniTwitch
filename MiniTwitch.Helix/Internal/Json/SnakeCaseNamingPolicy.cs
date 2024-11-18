using System.Text.Json;

namespace MiniTwitch.Helix.Internal.Json;

internal class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        const char underscore = '_';

        ReadOnlySpan<char> chars = name;
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
