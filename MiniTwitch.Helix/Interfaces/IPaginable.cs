using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Interfaces;

public interface IPaginable
{
    public Pagination Pagination { get; }
}
