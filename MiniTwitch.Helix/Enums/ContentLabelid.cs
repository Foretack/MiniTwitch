using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContentLabelId
{
    DebatedSocialIssuesAndPolitics,
    DrugsIntoxication,
    Gambling,
    MatureGame,
    ProfanityVulgarity,
    SexualThemes,
    ViolentGraphic,
}
