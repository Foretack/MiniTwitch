using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetUserActiveExtensions
{
   [JsonPropertyName("data")]
   public ExtensionsData Data { get; init; }

   public record Component(
       [property: JsonPropertyName("active")] bool Active,
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("version")] string Version,
       [property: JsonPropertyName("name")] string Name,
       [property: JsonPropertyName("x")] int X,
       [property: JsonPropertyName("y")] int Y
   );

   public record Panel(
       [property: JsonPropertyName("active")] bool Active,
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("version")] string Version,
       [property: JsonPropertyName("name")] string Name
   );

   public record Overlay(
       [property: JsonPropertyName("active")] bool Active,
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("version")] string Version,
       [property: JsonPropertyName("name")] string Name
   );

   public record ExtensionsData(
       [property: JsonPropertyName("panel")] Dictionary<int, Panel> Panel,
       [property: JsonPropertyName("overlay")] Dictionary<int, Overlay> Overlay,
       [property: JsonPropertyName("component")] Dictionary<int, Component> Component
   );
}