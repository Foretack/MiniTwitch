namespace MiniTwitch.Helix.Requests;

public readonly record struct NewAutoModSettings
{
    public int? Aggression { get; }
    public int? Bullying { get; }
    public int? Disability { get; }
    public int? Misogyny { get; }
    public int? OverallLevel { get; }
    public int? RaceEthnicityOrReligion { get; }
    public int? SexBasedTerms { get; }
    public int? SexualitySexOrGender { get; }
    public int? Swearing { get; }

    public NewAutoModSettings(
        int? aggression = null,
        int? bullying = null,
        int? disability = null,
        int? misogyny = null,
        int? overallLevel = null,
        int? raceEthnicityOrReligion = null,
        int? sexBasedTerms = null,
        int? sexualitySexOrGender = null,
        int? swearing = null
    )
    {
        this.Aggression = aggression;
        this.Bullying = bullying;
        this.Disability = disability;
        this.Misogyny = misogyny;
        this.OverallLevel = overallLevel;
        this.RaceEthnicityOrReligion = raceEthnicityOrReligion;
        this.SexBasedTerms = sexBasedTerms;
        this.SexualitySexOrGender = sexualitySexOrGender;
        this.Swearing = swearing;
    }
}
