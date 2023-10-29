using System.Reflection;
using System.Text;
using MiniTwitch.PubSub.Internal.Models;

namespace MiniTwitch.PubSub.Test;

public class TopicInfoParsingTests
{
    [Fact]
    public void ParseTopicInfo()
    {
        foreach (var field in typeof(Payloads).GetFields(BindingFlags.NonPublic | BindingFlags.Static))
        {
            TopicAttribute attribute = (TopicAttribute)Attribute.GetCustomAttribute(field, typeof(TopicAttribute))!;
            var info = new TopicInfo(Encoding.UTF8.GetBytes(attribute.GetJsonMessage(field)));
            Assert.True(attribute.Topic == info.Topic, $"[field: {field.Name}] {info.Topic} is {attribute.Topic} from {attribute.TopicName}");
        }
    }
}