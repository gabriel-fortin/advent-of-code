namespace Advent_of_Code_2024.day21;

using InputSet = string;

public static partial class Day21
{
    public static class Input
    {
        public static InputSet GetInput(InputSelector inputSelector)
        {
            return inputSelector switch
            {
                InputSelector.Example1 => GetExample1Input(),
                InputSelector.MyInput => GetMyPuzzleInput(),
                _ => throw new ArgumentOutOfRangeException(nameof(inputSelector), inputSelector, null)
            };
        }

        private static InputSet GetExample1Input() =>
            """
            029A
            980A
            179A
            456A
            379A
            """;

        private static InputSet GetMyPuzzleInput() =>
            """
            463A
            340A
            129A
            083A
            341A
            """;
    }
}