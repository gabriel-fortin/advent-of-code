namespace Advent_of_Code_2024.day04;

public record Move(int X, int Y)
{
    public Move((int, int) pair) : this(pair.Item1, pair.Item2)
    {
    }
}