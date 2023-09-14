using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Internal.Parsing;

namespace MiniTwitch.PubSub.Test;

// The sole purpose of these tests is to make sure that deserialization doesn't throw exceptions
public class DeserializationTests
{
    private static readonly JsonSerializerOptions _sOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        ReadCommentHandling = JsonCommentHandling.Skip
    };

    [Fact]
    public void DeserializePayloads()
    {
        foreach (var field in typeof(Payloads).GetFields(BindingFlags.NonPublic | BindingFlags.Static))
        {
            TopicAttribute attribute = (TopicAttribute)Attribute.GetCustomAttribute(field, typeof(TopicAttribute))!;
            try
            {
                Assert.NotNull(JsonSerializer.Deserialize(field.GetValue(null)?.ToString()!, attribute.OutType, _sOptions));
            }
            catch (Exception ex)
            {
                Assert.Fail($"[field: {field.Name}] Deserialization to {attribute.OutType.Name} failure! {ex.Message}\n{ex.StackTrace}");
            }
        }
    }

    [Fact]
    public void DeserializePayloads_ReadJsonMessage()
    {
        foreach (var field in typeof(Payloads).GetFields(BindingFlags.NonPublic | BindingFlags.Static))
        {
            TopicAttribute attribute = (TopicAttribute)Attribute.GetCustomAttribute(field, typeof(TopicAttribute))!;
            try
            {
                object? des = PubSubParsing.ReadJsonMessage(Encoding.UTF8.GetBytes(attribute.GetJsonMessage(field)), attribute.OutType, options: _sOptions);
                Assert.NotNull(des);
                if (des is string str)
                {
                    Assert.Fail(str);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"[field: {field.Name}] Deserialization to {attribute.OutType.Name} failure! {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
