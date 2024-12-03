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

    public string Part2(bool useExampleData)
    {
        Report[] reports = ParseInput(Input.GetInput(useExampleData));

        return reports
            .Select(CreateReportVersionsWithOneLevelRemoved)
            .Count(smallerReports => smallerReports.Any(x => x.IsSafe()))
            .ToString();
    }

    private IEnumerable<Report> CreateReportVersionsWithOneLevelRemoved(Report report)
    {
        return Enumerable
            .Range(0, report.LevelCount)
            .Select(report.CopyWithoutSelectedLevel);
    }

    private static Report ParseReport(string line)
    {
        List<Level> levels = line
            .Split(" ")
            .Select(int.Parse)
            .Select(x => new Level(x))
            .ToList();
        return new Report(levels);
    }

    private static Report[] ParseInput(string rawInput)
    {
        return rawInput
            .Split("\n")
            .Select(ParseReport)
            .ToArray();
    }
}

public class Report(List<Level> levels)
{
    public int LevelCount => levels.Count;

    public Report CopyWithoutSelectedLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= LevelCount)
        {
            throw new ArgumentException($"Invalid level index: {levelIndex}");
        }

        return new Report(
            levels.Take(levelIndex)
                .Concat(levels.Skip(levelIndex + 1))
                .ToList());
    }

    public bool IsSafe()
    {
        // from a list of [1,2,3,4,...] make a list of [(1,2), (2,3), (3,4), ...]
        (Level, Level)[] adjacentLevelPairs =
            levels.SkipLast(1)
                .Zip(levels.Skip(1))
                .ToArray();

        bool areAllIncreasing = adjacentLevelPairs
            .Aggregate(true, (current, nextPair) => current && nextPair.Item1 < nextPair.Item2);
        bool areAllDecreasing = adjacentLevelPairs
            .Aggregate(true, (current, nextPair) => current && nextPair.Item1 > nextPair.Item2);
        bool haveAllGoodDistance = adjacentLevelPairs
            .Select(pair => Math.Abs(pair.Item1 - pair.Item2))
            .Aggregate(true, (current, nextDiff) => current && nextDiff is >= 1 and <= 3);

        return (areAllIncreasing || areAllDecreasing) && haveAllGoodDistance;
    }

    public override string ToString()
    {
        return string.Join(" ", levels.Select(level => level.Value));
    }
}

public record Level(int Value)
{
    public static implicit operator int(Level level) => level.Value;
}