using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Internal.Json;

internal class EnumToString<TEnum, ICase> : JsonConverter<TEnum>
    where ICase : ICaseConverter, new()
{
    private static readonly ICaseConverter _case = new ICase();

    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string? enumAsString = reader.GetString();
            if (Enum.TryParse(typeof(TEnum), _case.ConvertFromCase(enumAsString), out object? enumMember))
                return (TEnum)enumMember!;
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(_case.ConvertToCase(value.ToString()));
    }
}
