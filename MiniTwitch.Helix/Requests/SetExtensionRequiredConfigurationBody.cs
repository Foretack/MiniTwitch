using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct SetExtensionRequiredConfigurationBody : IJsonObject
{
    public required string ExtensionId { get; init; }
    public required string ExtensionVersion { get; init; }
    public required string RequiredConfiguration { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        extension_id = ExtensionId,
        extension_version = ExtensionVersion,
        required_configuration = RequiredConfiguration,
    };
}
