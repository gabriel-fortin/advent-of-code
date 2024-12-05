namespace Advent_of_Code_2024.day04;

public record Pos(int X, int Y)
{
    public Pos MoveBy(Move move)
    {
        return new Pos(X + move.X, Y + move.Y);
    }
}