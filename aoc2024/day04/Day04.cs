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
        return AllXMasPatterns
            .Select(pattern => finder.FindAndCount(pattern))
            .Sum()
            .ToString();
    }

    private static readonly Pattern[] AllXMasPatterns = new char[][]
        {
            // @formatter:off
            [
                'M',    'M',
                    'A',
                'S',    'S',
            ],
            [
                'M',    'S',
                    'A',
                'M',    'S',
            ],
            [
                'S',    'M',
                    'A',
                'S',    'M',
            ],
            [
                'S',    'S',
                    'A',
                'M',    'M',
            ],
            // @formatter:on
        }
        .Select(AttachRelativePositions)
        .Select(Pattern.FromEnumerableOfLettersAndPositions)
        .ToArray();

    private static IEnumerable<(char, (int, int))> AttachRelativePositions(char[] letters)
    {
        (int, int)[] relativePositions =
            // @formatter:off
            [
                (0, 0),         (2, 0),
                        (1, 1),
                (0, 2),         (2, 2),
            ];
        // @formatter:on
        return letters.Zip(relativePositions);
    }
}
