using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class ExtensionsCategory
{
    private readonly AllCategories _all;

    internal ExtensionsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<ExtensionTransactions>> GetExtensionTransactions(
        string extensionId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionTransactions(extensionId, id, first, cancellationToken);

    public Task<HelixResult<Responses.ExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        ConfigSegmentType segment,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionConfigurationSegment(extensionId, segment, broadcasterId, cancellationToken);

    public Task<HelixResult<Responses.ExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        IEnumerable<ConfigSegmentType> segments,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionConfigurationSegment(extensionId, segments, broadcasterId, cancellationToken);

    public Task<HelixResult> SetExtensionConfigurationSegment(
        ConfigurationSegment body,
        CancellationToken cancellationToken = default)
    => _all.SetExtensionConfigurationSegment(body, cancellationToken);

    public Task<HelixResult> SetExtensionRequiredConfiguration(
        long broadcasterId,
        ExtensionRequiredConfiguration body,
        CancellationToken cancellationToken = default)
    => _all.SetExtensionRequiredConfiguration(broadcasterId, body, cancellationToken);

    public Task<HelixResult> SendExtensionPubSubMessage(
        ExtensionPubSubMessage body,
        CancellationToken cancellationToken = default)
    => _all.SendExtensionPubSubMessage(body, cancellationToken);

    public Task<HelixResult<ExtensionLiveChannels>> GetExtensionLiveChannels(
        string extensionId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionLiveChannels(extensionId, first, cancellationToken);

    public Task<HelixResult<ExtensionSecrets>> GetExtensionSecrets(
        string extensionId,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionSecrets(extensionId, cancellationToken);

    public Task<HelixResult<ExtensionSecrets>> CreateExtensionSecret(
        string extensionId,
        int? delay = null,
        CancellationToken cancellationToken = default)
    => _all.CreateExtensionSecret(extensionId, delay, cancellationToken);

    public Task<HelixResult> SendExtensionChatMessage(
        long broadcasterId,
        ExtensionChatMessage body,
        CancellationToken cancellationToken = default)
    => _all.SendExtensionChatMessage(broadcasterId, body, cancellationToken);

    public Task<HelixResult<Extensions>> GetExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensions(extensionId, extensionVersion, cancellationToken);

    public Task<HelixResult<ReleasedExtensions>> GetReleasedExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    => _all.GetReleasedExtensions(extensionId, extensionVersion, cancellationToken);
}
