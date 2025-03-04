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

    public class DistanceComparer : IComparer<Tile>
    {
        public int Compare(Tile? x, Tile? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (y is null) return 1;
            if (x is null) return -1;
            var distanceCmp = x.DistanceFromExit.CompareTo(y.DistanceFromExit);
            
            // never return 0 to not overwrite elements in a SortedSet
            if (distanceCmp == 0)
            {
                return x.Pos.CompareTo(y.Pos);
            }
            
            return distanceCmp;
        }
    }
}