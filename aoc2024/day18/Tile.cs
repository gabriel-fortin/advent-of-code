using Advent_of_Code_2024.day15;

namespace Advent_of_Code_2024.day18;

public class Tile
{
    public bool IsCorrupted { get; set; }

    public int DistanceFromExit { get; set; } = int.MaxValue;

    public Pos Pos { get; set; }

    public override string ToString()
    {
        return $"{Pos} {(IsCorrupted ? "CORRUPTED" : "")}  dist {DistanceFromExit}";
    }
}