namespace Advent_of_Code_2024.day09;

public static partial class Day09
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var disk = new Disk(rawInput);

        disk.DecompressFromDenseFormat();
        disk.CompactFilesByMovingSingleBlocks();
        return disk.ComputeChecksum().ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var disk = new Disk(rawInput);

        disk.DecompressFromDenseFormat();
        disk.CompactFilesByMovingWholeFiles();
        return disk.ComputeChecksum().ToString();
    }
}