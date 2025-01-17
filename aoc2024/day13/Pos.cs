namespace Advent_of_Code_2024.day13;

public record Pos(long X, long Y)
{
    public Pos MoveBy(Vector vector)
    {
        return new Pos(X + vector.X, Y + vector.Y);
    }
    
    public static readonly Pos Zero = new Pos(0, 0);
}