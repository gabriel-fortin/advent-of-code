namespace Advent_of_Code_2024.day13;

public record Vector(long X, long Y)
{
    public static Vector operator *(Vector m, long scalar)
    {
        return new Vector(m.X * scalar, m.Y * scalar);
    }
    
    public static Vector operator *(long scalar, Vector m)
    {
        return new Vector(m.X * scalar, m.Y * scalar);
    }
}