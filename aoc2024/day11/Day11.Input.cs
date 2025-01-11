namespace Advent_of_Code_2024.day11;

public static partial class Day11
{
    public static class Input
    {
        public static string GetInput(bool useExampleData)
        {
            return useExampleData ? GetExampleInput() : GetMyPuzzleInput();
        }

        private static string GetExampleInput() =>
            "125 17";

        private static string GetMyPuzzleInput() =>
            "3 386358 86195 85 1267 3752457 0 741";
    }
}