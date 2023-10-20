namespace MiniTwitch.Helix.Requests;

public readonly record struct NewAutoModSettings
{
    public int? Aggression { get; init; }
    public int? Bullying { get; init; }
    public int? Disability { get; init; }
    public int? Misogyny { get; init; }
    public int? OverallLevel { get; init; }
    public int? RaceEthnicityOrReligion { get; init; }
    public int? SexBasedTerms { get; init; }
    public int? SexualitySexOrGender { get; init; }
    public int? Swearing { get; init; }
}
