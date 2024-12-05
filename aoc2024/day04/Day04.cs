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
        return "NOT IMPLEMENTED YET";
    }
}