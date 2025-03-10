namespace Advent_of_Code_2024.day20;

public class Shortcut(int saving, Tile startTile, Tile endTile)
{
    public int Saving { get; } = saving;

    public class HavingHighestSaving : IComparer<Shortcut>
    {
        public int Compare(Shortcut? x, Shortcut? y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException(nameof(x),
                    "Did not plan to compare null shortcuts");

            if (ReferenceEquals(x, y)) return 0;
            return -(x.Saving.CompareTo(y.Saving));
        }
    }
}