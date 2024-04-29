namespace MiniTwitch.Helix.Requests;

public class ExtensionChatMessage
{
    public string Text { get; }
    public string ExtensionId { get; }
    public string ExtensionVersion { get; }

    public ExtensionChatMessage(string text, string extensionId, string extensionVersion)
    {
        this.Text = text;
        this.ExtensionId = extensionId;
        this.ExtensionVersion = extensionVersion;
    }
}
