using System.Text.RegularExpressions;
using Advent_of_Code_2024.day04;

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

public record class ClawMachine(Move ButtonA, Move ButtonB, Pos Prize)
{
    public int? RequiredPressesOfA { get; private set; }

    public int? RequiredPressesOfB { get; private set; }

    public void ComputeRequiredNumberOfPresses()
    {
        int a = Prize.X / ButtonA.X + 1;
        int b = 0;
        var currentTarget = new Pos(ButtonA.X * a, ButtonA.Y * a);
        while (a >= 0)
        {
            if (currentTarget.X > Prize.X)
            {
                a--;
            }
            else
            {
                b++;
            }

            currentTarget = new Pos(ButtonA.X * a + ButtonB.X * b, ButtonA.Y * a + ButtonB.Y * b);
            if (currentTarget == Prize)
            {
                RequiredPressesOfA = a;
                RequiredPressesOfB = b;
                return;
            }
        }

        RequiredPressesOfA = -1;
        RequiredPressesOfB = -1;
    }

    public int ComputeCost()
    {
        if (!RequiredPressesOfA.HasValue || !RequiredPressesOfB.HasValue)
        {
            ComputeRequiredNumberOfPresses();
        }

        if (RequiredPressesOfA < 0 || RequiredPressesOfB < 0) return 0;

        return (int)(RequiredPressesOfA! * 3 + RequiredPressesOfB!);
    }


    public static ClawMachine FromInput(string input)
    {
        string[] lines = input.Split(Environment.NewLine);

        Match pairMatch = ButtonPattern.Match(lines[0]);
        var buttonA = new Move(int.Parse(pairMatch.Groups[1].Value), int.Parse(pairMatch.Groups[2].Value));

        pairMatch = ButtonPattern.Match(lines[1]);
        var buttonB = new Move(int.Parse(pairMatch.Groups[1].Value), int.Parse(pairMatch.Groups[2].Value));

        pairMatch = PrizePattern.Match(lines[2]);
        var prize = new Pos(int.Parse(pairMatch.Groups[1].Value), int.Parse(pairMatch.Groups[2].Value));

        return new ClawMachine(buttonA, buttonB, prize);
    }

    private static readonly Regex ButtonPattern = new(@"Button \w: X\+(\d+), Y\+(\d+)");
    private static readonly Regex PrizePattern = new(@"Prize: X=(\d+), Y=(\d+)");
}