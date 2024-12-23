using Advent_of_Code_2024.day04;

namespace Advent_of_Code_2024.day10;

public class DataPoint(int height = 0)
{
    public int Height { get; } = height;

    // using a set which has elements of a record type allows to avoid duplicates
    public HashSet<Pos> Destinations { get; } = new();

    public int Rating { get; set; } = -1;
    
    public int GetScore()
    {
        return Destinations.Count;
    }

    public static DataPoint Parse(char input) => new(height: input - '0');
}