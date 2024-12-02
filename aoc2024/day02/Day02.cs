namespace Advent_of_Code_2024.day02;

public partial class Day02
{
    public string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        
        Report[] reports = rawInput
            .Split("\n")
            .Select(ParseReport)
            .ToArray();

        return reports
            .Count(x => x.IsSafe())
            .ToString();
    }

    private Report ParseReport(string line)
    {
        List<Level> levels = line
            .Split(" ")
            .Select(int.Parse)
            .Select(x => new Level(x))
            .ToList();
        return new Report(levels);
    }
}

public class Report(List<Level> levels)
{
    public bool IsSafe()
    {
        // from a list of [1,2,3,4,...] make a list of [(1,2), (2,3), (3,4), ...]
        (Level, Level)[] adjacentLevelPairs = levels.SkipLast(1).Zip(levels.Skip(1)).ToArray();

        bool areAllIncreasing = adjacentLevelPairs
            .Aggregate(true, (current, nextPair) => current && nextPair.Item1 < nextPair.Item2);
        bool areAllDecreasing = adjacentLevelPairs
            .Aggregate(true, (current, nextPair) => current && nextPair.Item1 > nextPair.Item2);
        bool haveAllGoodDistance = adjacentLevelPairs
            .Select(pair => Math.Abs(pair.Item1 - pair.Item2))
            .Aggregate(true, (current, nextDiff) => current && nextDiff is >= 1 and <= 3);

        return (areAllIncreasing || areAllDecreasing) && haveAllGoodDistance;
    }
}

public record Level(int Value)
{
    public static implicit operator int(Level level) => level.Value;
}