using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.day15;


public readonly record struct Pos(int X, int Y) : IComparable<Pos>
{
    public Pos After(Move move)
    {
        return new (X+move.X, Y+move.Y);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public int CompareTo(Pos other)
    {
        var yComparison = Y.CompareTo(other.Y);
        if (yComparison != 0) return yComparison;
        return X.CompareTo(other.X);
    }

    private static readonly Regex ParseRegex = new Regex(@"^(?<X>\d+),(?<Y>\d+)$");
    public static Pos Parse(string input)
    {
        Match match = ParseRegex.Match(input);
        if (!match.Success) throw new FormatException();
        var x = int.Parse(match.Groups["X"].Value);
        var y = int.Parse(match.Groups["Y"].Value);
        return new Pos(x, y);
    }
}