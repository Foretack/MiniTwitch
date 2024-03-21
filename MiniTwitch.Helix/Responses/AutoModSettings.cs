using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class AutoModSettings : BaseResponse<AutoModSettings.Settings>
{
    public record Settings(
         long BroadcasterId,
         long ModeratorId,
         int? OverallLevel,
         int Disability,
         int Aggression,
         int SexualitySexOrGender,
         int Misogyny,
         int Bullying,
         int Swearing,
         int RaceEthnicityOrReligion,
         int SexBasedTerms
    );
}