namespace MiniTwitch.Helix.Requests;

public class ExtensionRequiredConfiguration
{
    public string ExtensionId { get; }
    public string ExtensionVersion { get; }
    public string RequiredConfiguration { get; }

    public ExtensionRequiredConfiguration(string extensionId, string extensionVersion, string requiredConfiguration)
    {
        this.ExtensionId = extensionId;
        this.ExtensionVersion = extensionVersion;
        this.RequiredConfiguration = requiredConfiguration;
    }
}
