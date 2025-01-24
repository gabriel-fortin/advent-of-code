namespace Advent_of_Code_2024.day15;


public record Pos(int X, int Y)
{
    public Pos After(Move move)
    {
        return new (X+move.X, Y+move.Y);
    }
}