using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Internal.Json;

internal class TimeSpanToSeconds : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotSupportedException("Converter should only be used for writing");

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) => writer.WriteNumberValue((int)value.TotalSeconds);
}
