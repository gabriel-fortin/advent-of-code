using Advent_of_Code_2024.day04;

namespace Advent_of_Code_2024.day06;

public class Directions
{
    private Move[] moves = new[]
        {
            (-1, 0),
            (0, 1),
            (1, 0),
            (0, -1),
        }
        .Select(x => new Move(x))
        .ToArray();

    private int index = 0;

    public Move CurrentDirection => moves[index];

    public void RotateRight()
    {
        index = (index + 1) % moves.Length;
    }
}