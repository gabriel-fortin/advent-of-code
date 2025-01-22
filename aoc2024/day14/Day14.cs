using System.Text.RegularExpressions;
using Advent_of_Code_2024.day13;

namespace Advent_of_Code_2024.day14;

public partial class Day14
{
    private static readonly Regex InputLine = new(@"p=(\d+),(\d+) v=(-?\d+),(-?\d+)");

    public static string Part1(InputSelector inputSelector)
    {
        var (width, height, rawInput) = Input.GetInput(inputSelector);
        var bathroom = new Bathroom(width, height);
        Robot[] robots = rawInput
            .Split(Environment.NewLine)
            .Select(ParseRobot(bathroom))
            .ToArray();

        foreach (var robot in robots)
        {
            robot.Move(iterations: 100);
        }

        int verticalCenterLine = bathroom.Width / 2;
        int horizontalCenterLine = bathroom.Height / 2;

        return robots
            // ignore robots positioned on the dividers
            .Where(x => x.Position.X != verticalCenterLine && x.Position.Y != horizontalCenterLine)
            .ToArray()
            // group them into quadrants
            .GroupBy(x => (x.Position.X < verticalCenterLine, x.Position.Y < horizontalCenterLine))
            .ToArray()
            // multiply the counts of robots in each quadrant
            .Aggregate(1, (acc, grouping) => acc * grouping.Count())
            .ToString();
    }

    private static Func<string, Robot> ParseRobot(Bathroom bathroom)
    {
        return line =>
        {
            Match match = InputLine.Match(line);
            Pos position = new(
                long.Parse(match.Groups[1].Value),
                long.Parse(match.Groups[2].Value));
            Vector velocity = new(
                long.Parse(match.Groups[3].Value),
                long.Parse(match.Groups[4].Value));
            return new Robot(position, velocity, bathroom);
        };
    }
}

public record Bathroom(int Width, int Height) : Vector(Width, Height);

public class Robot(Pos position, Vector velocity, Bathroom bathroom)
{
    public Pos Position { get; private set; } = position;
    public Vector Velocity { get; } = velocity;

    public void Move(int iterations)
    {
        // to avoid moving into the negative, we add the height and width of the room
        Vector positiveVelocity = Velocity.Plus(bathroom);
        // add then we can just do a modulo operation
        Pos newPos = Position.Plus(positiveVelocity * iterations);
        Position = new Pos(newPos.X % bathroom.Width, newPos.Y % bathroom.Height);
    }
}