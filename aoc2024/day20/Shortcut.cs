namespace Advent_of_Code_2024.day20;

public class Shortcut(int saving, Tile startTile, Tile endTile)
{
    private Tile StartTile { get; } = startTile;

    private Tile EndTile { get; } = endTile;
    
    public int Saving { get; } = saving;

    public class HavingHighestSaving : IComparer<Shortcut>
    {
        public int Compare(Shortcut? x, Shortcut? y)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x),
                    "Did not plan to compare null shortcuts");
            if (y == null)
                throw new ArgumentNullException(nameof(y),
                    "Did not plan to compare null shortcuts");

            if (ReferenceEquals(x, y)) return 0;
            return -(x.Saving.CompareTo(y.Saving));
        }
    }

    public class SameStartAndEndPositions : IEqualityComparer<Shortcut>
    {
        public bool Equals(Shortcut? x, Shortcut? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            
            return x.StartTile.Pos.Equals(y.StartTile.Pos)
                && x.EndTile.Pos.Equals(y.EndTile.Pos);
        }

        public int GetHashCode(Shortcut obj)
        {
            return HashCode.Combine(obj.StartTile.Pos, obj.EndTile.Pos);
        }
    }
}