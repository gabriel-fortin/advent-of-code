using Advent_of_Code_2024.day15;

namespace Advent_of_Code_2024.day16;

/// A Move but with added meaning
public class Direction : Move
{
    public string Name { get; }

    private Direction(int x, int y, string name = "") : base(x, y)
    {
        Name = name;
    }

    public Direction Reverse()
    {
        if (this == East) return West;
        if (this == West) return East;
        if (this == South) return North;
        if (this == North) return South;
        return new Direction(-1 * X, -1 * Y);
    }

    public override string ToString()
    {
        return $"Direction: {Name} ({X}, {Y})";
    }

    public static readonly Direction East = new Direction(1, 0, "East");

    public static readonly Direction South = new Direction(0, 1, "South");

    public static readonly Direction West = new Direction(-1, 0, "West");

    public static readonly Direction North = new Direction(0, -1, "North");

    public static readonly Direction[] All = [East, South, West, North];
}