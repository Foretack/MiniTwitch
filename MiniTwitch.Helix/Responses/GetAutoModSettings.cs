using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetAutoModSettings : SingleResponse<GetAutoModSettings.Datum>
{
   public record Datum(
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("moderator_id")] long ModeratorId,
       [property: JsonPropertyName("overall_level")] int? OverallLevel,
       [property: JsonPropertyName("disability")] int Disability,
       [property: JsonPropertyName("aggression")] int Aggression,
       [property: JsonPropertyName("sexuality_sex_or_gender")] int SexualitySexOrGender,
       [property: JsonPropertyName("misogyny")] int Misogyny,
       [property: JsonPropertyName("bullying")] int Bullying,
       [property: JsonPropertyName("swearing")] int Swearing,
       [property: JsonPropertyName("race_ethnicity_or_religion")] int RaceEthnicityOrReligion,
       [property: JsonPropertyName("sex_based_terms")] int SexBasedTerms
   );
}