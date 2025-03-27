namespace Advent_of_Code_2024.day23;

using InputSet = string;

public static partial class Day23
{
    public static class Input
    {
        public static InputSet GetInput(InputSelector inputSelector)
        {
            return inputSelector switch
            {
                InputSelector.Example1 => GetExample1Input(),
                InputSelector.Example2 => GetExample2Input(),
                InputSelector.Example3 => GetExample3Input(),
                InputSelector.MyInput => GetMyPuzzleInput(),
                _ => throw new ArgumentOutOfRangeException(nameof(inputSelector), inputSelector, null)
            };
        }


        private static InputSet GetExample1Input() =>
            """
            x
            """;

        private static InputSet GetExample2Input() =>
            """
            x
            """;

        private static InputSet GetExample3Input() =>
            """
            x
            """;

        private static InputSet GetMyPuzzleInput() =>
            """
            x
            """;
    }
}