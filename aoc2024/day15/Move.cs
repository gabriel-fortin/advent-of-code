using System.Diagnostics.CodeAnalysis;

namespace Advent_of_Code_2024.day15;

public class Move
{
    // we use the flyweight design pattern in this class

    public int X { get; set; }
    public int Y { get; set; }

    private Move(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool TryParse(char character, [MaybeNullWhen(false)] out Move move)
    {
        return Map.TryGetValue(character, out move);
    }

    private static readonly Dictionary<char, Move> Map = new()
    {
        { '^', new(0, -1) },
        { 'v', new(0, 1) },
        { '<', new(-1, 0) },
        { '>', new(1, 0) },
    };
}