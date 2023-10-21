namespace MiniTwitch.Helix.Internal.Json;

internal interface ICaseConverter
{
    string? ConvertToCase(string? str);
    string? ConvertFromCase(string? str);
}
