using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace MiniTwitch.Helix.Internal.Json;

internal class OptionalLongConverter : JsonConverter<long?>
{
    public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.ValueSpan.Length == 0)
        {
            return null;
        }

        Span<char> chars = stackalloc char[reader.ValueSpan.Length];
        int written = Encoding.UTF8.GetChars(reader.ValueSpan, chars);
        return long.TryParse(chars, out var l) ? l : null;
    }

    public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStringValue(value.ToString());
    }
}

internal class LongConverter : JsonConverter<long>
{
    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.ValueSpan.Length == 0)
        {
            return default;
        }

        Span<char> chars = stackalloc char[reader.ValueSpan.Length];
        int written = Encoding.UTF8.GetChars(reader.ValueSpan, chars);
        return long.TryParse(chars, out var l) ? l : default;
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
}

internal class IntConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.ValueSpan.Length == 0)
        {
            return default;
        }

        Span<char> chars = stackalloc char[reader.ValueSpan.Length];
        int written = Encoding.UTF8.GetChars(reader.ValueSpan, chars);
        return int.TryParse(chars, out var i) ? i : default;
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
}

internal class EnumConverter<TEnum, ICase> : JsonConverter<TEnum>
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

internal class TimeSpanToSeconds : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotSupportedException("Converter should only be used for writing");

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) => writer.WriteNumberValue((int)value.TotalSeconds);
}