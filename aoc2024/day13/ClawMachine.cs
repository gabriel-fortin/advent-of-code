using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.day13;

public record class ClawMachine(Vector ButtonA, Vector ButtonB, Pos Prize)
{
    public long? RequiredPressesOfA { get; private set; }

    public long? RequiredPressesOfB { get; private set; }

    public void ComputeRequiredNumberOfPresses()
    {
        // overall strategy: with any combination of buttons A and B
        // try to target a point having X close to the X of the prize

        Console.WriteLine($"/ {ButtonA} {ButtonB}");

        var startingACount = 1 + Prize.X / ButtonA.X;
        // var startingClockwiseness = Ccw()

        long multiplier = 1;
        while ((ButtonA.X + ButtonB.X) * multiplier < Prize.X)
        {
            multiplier *= 10L;
        }

        long executionLimit = 200L + startingACount;

        // ReSharper disable RedundantAssignment
        Vector virtualButtonA = ButtonA * multiplier;
        Vector virtualButtonB = ButtonB * multiplier;
        // ReSharper restore RedundantAssignment

        long aCount = startingACount;
        long bCount = 0L;

        bool IsCloseEnough(Pos pos)
        {
            if (executionLimit-- <= 0) return true;

            // ReSharper disable AccessToModifiedClosure
            long xLimit = Math.Max(virtualButtonA.X, virtualButtonB.X);
            // long yLimit = Math.Max(virtualButtonA.Y, virtualButtonB.Y);
            // long yLimit = virtualButtonB.Y * 10;
            // long yLimit = virtualButtonA.Y;
            long yLimit = virtualButtonB.Y * (1 + virtualButtonA.X / virtualButtonB.X);
            
            // ReSharper restore AccessToModifiedClosure
            long xDistance = Math.Abs(Prize.X - pos.X);
            long yDistance = Math.Abs(Prize.Y - pos.Y);

            return pos.X >= Prize.X &&
                   // pos.X < (Prize.X + virtualButtonA.X) &&
                   yDistance < yLimit;

            // return xDistance <= xLimit && yDistance <= yLimit;
        }

        bool IsBangOnThePrize(Pos pos)
        {
            if (executionLimit-- <= 0) return true;
            return pos == Prize;
        }

        _iterationCount = 0;

        try
        {
            // INVARIANT: ButtonA * aCount + ButtonB * bCount falls to the right of Prize
            for (; multiplier >= 1; multiplier /= 10)
            {
                virtualButtonA = ButtonA * multiplier;
                virtualButtonB = ButtonB * multiplier;

                Debug.Assert(Pos.Zero.MoveBy(ButtonA * aCount).MoveBy(ButtonB * bCount).X >= Prize.X, "before call");
                var (virtualACount, virtualBCount) = ComputeRequiredNumberOfPresses(
                    buttonA: virtualButtonA,
                    buttonB: virtualButtonB,
                    prize: Prize,
                    shouldStopSearching: multiplier == 1 ? IsBangOnThePrize : IsCloseEnough,
                    startingACount: 1 + aCount / multiplier,
                    startingBCount: bCount / multiplier);
                aCount = virtualACount * multiplier;
                bCount = virtualBCount * multiplier;
                Debug.Assert(Pos.Zero.MoveBy(ButtonA * aCount).MoveBy(ButtonB * bCount).X >= Prize.X, "after call");

                Console.WriteLine($"      == multiplier {multiplier,9} -- {_iterationCount,3} iterations");
                _iterationCount = 0;

                if (Pos.Zero.MoveBy(ButtonA * aCount).MoveBy(ButtonB * bCount) == Prize)
                {
                    RequiredPressesOfA = aCount;
                    RequiredPressesOfB = bCount;
                    Console.WriteLine($"   >{ComputeCost()}\n");
                    return;
                }

                // make sure we don't get too low with 'A' (because there is no way to rectify that)
                // aCount += multiplier;
                // make sure we don't get too high with 'B' (because there is no way to rectify that)
                // bCount -= multiplier;
                // bCount -= 1 + (ButtonA.Y / ButtonB.Y) * multiplier;
            }

            throw new SolutionDoesNotExistException();
        }
        catch (SolutionDoesNotExistException)
        {
            Console.WriteLine($"   >NOPE!\n");
            RequiredPressesOfA = -1;
            RequiredPressesOfB = -1;
        }
    }

    private int _iterationCount;

    private (long a, long b) ComputeRequiredNumberOfPresses(Vector buttonA, Vector buttonB, Pos prize,
        Func<Pos, bool> shouldStopSearching, long startingACount = 0L, long startingBCount = 0L)
    {
        long aCount = startingACount;
        long bCount = startingBCount;
        Debug.Assert(Pos.Zero.MoveBy(buttonA * aCount).MoveBy(buttonB * bCount).X >= Prize.X, "inside start");
        var currentTarget = Pos.Zero.MoveBy(buttonA * aCount).MoveBy(buttonB * bCount);

        while (!shouldStopSearching(currentTarget))
        {
            _iterationCount++;
            if (currentTarget.X > prize.X)
            {
                aCount--;
            }
            else
            {
                bCount++;
            }

            currentTarget = Pos.Zero.MoveBy(buttonA * aCount).MoveBy(buttonB * bCount);
            if (aCount < 0) throw new SolutionDoesNotExistException();
        }

        Debug.Assert(currentTarget.X >= Prize.X, $"inside end; current: {currentTarget} prize: {prize}");

        return (aCount, bCount);
    }

    public long ComputeCost()
    {
        if (!RequiredPressesOfA.HasValue || !RequiredPressesOfB.HasValue)
        {
            ComputeRequiredNumberOfPresses();
        }

        if (RequiredPressesOfA < 0 || RequiredPressesOfB < 0) return 0;

        long xxx = (long)(RequiredPressesOfA! * 3 + RequiredPressesOfB!);
        return xxx;
    }

    public static long Ccw(Pos a, Pos b, Pos c)
    {
        return (b.X - a.X) * (c.Y - a.Y) - (c.X - a.X) * (b.Y - a.Y);
    }


    public static ClawMachine FromInput(string input)
    {
        string[] lines = input.Split(Environment.NewLine);

        Match pairMatch = ButtonPattern.Match(lines[0]);
        var buttonA = new Vector(int.Parse(pairMatch.Groups[1].Value), int.Parse(pairMatch.Groups[2].Value));

        pairMatch = ButtonPattern.Match(lines[1]);
        var buttonB = new Vector(int.Parse(pairMatch.Groups[1].Value), int.Parse(pairMatch.Groups[2].Value));

        pairMatch = PrizePattern.Match(lines[2]);
        var prize = new Pos(long.Parse(pairMatch.Groups[1].Value), long.Parse(pairMatch.Groups[2].Value));

        return new ClawMachine(buttonA, buttonB, prize);
    }

    private static readonly Regex ButtonPattern = new(@"Button \w: X\+(\d+), Y\+(\d+)");
    private static readonly Regex PrizePattern = new(@"Prize: X=(\d+), Y=(\d+)");
}