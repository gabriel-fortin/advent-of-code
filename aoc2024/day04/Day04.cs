namespace Advent_of_Code_2024.day04;

public static partial class Day04
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var matrix = new Matrix(rawInput.Split("\n"));

        var finder = new WordFinder(matrix);
        long count = finder.FindAndCount("XMAS");
        return count.ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var matrix = new Matrix(rawInput.Split("\n"));

        var finder = new AdvancedWordFinder(matrix);
        return AllPatterns
            .Select(pattern => finder.FindAndCount(pattern))
            .Sum()
            .ToString();
    }

    private static readonly Pattern[] AllPatterns =
        new (char letter, (int, int) relativePosition)[][]
            {
                // @formatter:off
                [
                    ('M', (0, 0)),                 ('M', (2, 0)),
                                    ('A', (1, 1)),
                    ('S', (0, 2)),                 ('S', (2, 2)),
                ],
                [
                    ('M', (0, 0)),                 ('S', (2, 0)),
                                    ('A', (1, 1)),
                    ('M', (0, 2)),                 ('S', (2, 2)),
                ],
                [
                    ('S', (0, 0)),                 ('M', (2, 0)),
                                    ('A', (1, 1)),
                    ('S', (0, 2)),                 ('M', (2, 2)),
                ],
                [
                    ('S', (0, 0)),                 ('S', (2, 0)),
                                    ('A', (1, 1)),
                    ('M', (0, 2)),                 ('M', (2, 2)),
                ],
                // @formatter:on
            }
            .Select(list => list.Select(x => (x.letter, new Move(x.relativePosition))).ToList())
            .Select(moveList => new Pattern(moveList))
            .ToArray();
}
