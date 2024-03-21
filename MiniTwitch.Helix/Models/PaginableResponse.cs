using System.Text.Json.Serialization;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Models;

public abstract class PaginableResponse<T> : BaseResponse<T>, IPaginable
{
    public required Pagination Pagination { get; init; }
}
