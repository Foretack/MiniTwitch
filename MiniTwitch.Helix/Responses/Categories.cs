using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Categories : PaginableResponse<Categories.Category>
{
    public record Category(
         string Id,
         string Name,
         string BoxArtUrl
    );
}