namespace Advent_of_Code_2024.day13;

public static partial class Day13
{
    const long ADJUSTMENT = 10000000000000;
    
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
        ClawMachine[] machines = Input.GetInput(inputSelector)
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(ClawMachine.FromInput)
            .Select(x => x with { Prize = new(x.Prize.X + ADJUSTMENT, x.Prize.Y + ADJUSTMENT) })
            .ToArray();
        
        return machines
            .Select(x => x.ComputeCost())
            .Sum()
            .ToString();
    }
}