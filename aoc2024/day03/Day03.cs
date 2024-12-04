using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.day03;

public static partial class Day03
{
    private static readonly Regex MulStructure = new(@"mul\((\d{1,3}),(\d{1,3})\)");
    
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);

        return MulStructure
            .Matches(rawInput)
            .Select(match => new Mul(match.Value).ComputeValue())
            .Aggregate(0L, (acc, cur) => acc + cur)
            .ToString();
    }

    // public static string Part2(bool useExampleData)
    // {
    // }

    public record Mul
    {
        public int X { get; }
        
        public int Y { get; }

        public Mul(string mulText)
        {
            Match match = MulStructure.Match(mulText);
            if (!match.Success) throw new ArgumentException($"Invalid mul text: {mulText}");
            
            X = int.Parse(match.Groups[1].Value);
            Y = int.Parse(match.Groups[2].Value);
        }

        public int ComputeValue() => X * Y;
    }
}