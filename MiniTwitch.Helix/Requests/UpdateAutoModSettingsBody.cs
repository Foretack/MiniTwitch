using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly record struct UpdateAutoModSettingsBody
{
    [JsonPropertyName("aggression")]
    public int Aggression { get; init; }
    [JsonPropertyName("bullying")]
    public int Bullying { get; init; }
    [JsonPropertyName("disability")]
    public int Disability { get; init; }
    [JsonPropertyName("misogyny")]
    public int Misogyny { get; init; }
    [JsonPropertyName("overall_level")]
    public int OverallLevel { get; init; }
    [JsonPropertyName("race_ethnicity_or_religion")]
    public int RaceEthnicityOrReligion { get; init; }
    [JsonPropertyName("sex_based_terms")]
    public int SexBasedTerms { get; init; }
    [JsonPropertyName("sexuality_sex_or_gender")]
    public int SexualitySexOrGender { get; init; }
    [JsonPropertyName("swearing")]
    public int Swearing {  get; init; }
}
