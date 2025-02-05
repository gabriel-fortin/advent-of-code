namespace Advent_of_Code_2024.day17;

public static partial class Day17
{
    public static class Input
    {
        public static (Registers, string) GetInput(InputSelector inputSelector)
        {
            return inputSelector switch
            {
                InputSelector.Example1 => (GetExample1Registers(), GetExample1Input()),
                InputSelector.Example2 => (GetExample2Registers(), GetExample2Input()),
                InputSelector.MyInput => (GetMyPuzzleRegisters(), GetMyPuzzleInput()),
                _ => throw new ArgumentOutOfRangeException(nameof(inputSelector), inputSelector, null)
            };
        }

        private static string GetExample1Input() =>
            "5,0,5,1,5,4";

        private static Registers GetExample1Registers() => new Registers()
        {
            A = 10,
        };

        private static string GetExample2Input() =>
            "0,1,5,4,3,0";

        private static Registers GetExample2Registers() => new Registers()
        {
            A = 2024,
        };

        private static string GetMyPuzzleInput() =>
            "2,4,1,7,7,5,1,7,0,3,4,1,5,5,3,0";

        private static Registers GetMyPuzzleRegisters() => new Registers()
        {
            A = 66752888,
            B = 0,
            C = 0,
        };
    }
}