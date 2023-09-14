using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using MiniTwitch.PubSub.Internal.Enums;

namespace MiniTwitch.PubSub.Test;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
internal class TopicAttribute : Attribute
{
    public readonly string TopicName;
    public readonly Type OutType;
    internal readonly MessageTopic Topic;

    public TopicAttribute(string topicName, MessageTopic topic, Type outType)
    {
        TopicName = topicName;
        Topic = topic;
        OutType = outType;
    }

    public string GetJsonMessage(FieldInfo fieldInfo) => JsonSerializer.Serialize(new
    {
        type = "MESSAGE",
        data = new
        {
            topic = TopicName,
            message = Regex.Replace(fieldInfo.GetValue(null)!.ToString(), "\t|\r|\n", string.Empty)
        }
    }, options: new() { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, WriteIndented = false });
}
