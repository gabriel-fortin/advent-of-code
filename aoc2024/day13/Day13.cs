namespace Advent_of_Code_2024.day13;

public static partial class Day13
{
    public static string Part1(InputSelector inputSelector)
    {
        ClawMachine[] machines = Input.GetInput(inputSelector)
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(ClawMachine.FromInput)
            .ToArray();

        return machines
            .Select(x => x.ComputeCost())
            .Sum()
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        return "NOT IMPLEMENTED";
    }
}