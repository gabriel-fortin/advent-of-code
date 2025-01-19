using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.day13;

public record class ClawMachine(Vector ButtonA, Vector ButtonB, Pos Prize)
{
    public long? RequiredPressesOfA { get; private set; }

    public long? RequiredPressesOfB { get; private set; }

    private long _executionLimit;

    private bool _isLogOn = false;
    private int _iterationCount; // for console output only

    private long GetMultiplier()
    {
        long multiplier = 1;
        while ((ButtonA.X + ButtonB.X) * multiplier * 100 < Prize.X &&
               (ButtonA.Y + ButtonB.Y) * multiplier * 100 < Prize.Y)
        {
            multiplier *= 10L;
        }

        return multiplier;
    }

    /// function to decide when to stop searching when multiplier > 1
    private bool IsCloseEnough(Pos currentPos, Pos prize, Vector btnA, Vector btnB)
    {
        if (_executionLimit-- <= 0)
        {
            throw new SolutionDoesNotExistException(
                $"Reached execution limit in {nameof(IsCloseEnough)} ({_iterationCount} iterations)");
        }

        // the closeness limit can be constructed in many ways (possibly simpler than the below)
        long yLimit = 10 * Math.Max(btnA.Y, btnB.Y * (1 + btnA.X / btnB.X));
        long yDistance = Math.Abs(prize.Y - currentPos.Y);

        return yDistance < yLimit;
    }

    /// function to decide when to stop searching when multiplier == 1
    private bool IsBangOnThePrize(Pos pos, Pos prize, Vector btnA, Vector btnB)
    {
        if (_executionLimit-- <= 0)
        {
            throw new SolutionDoesNotExistException(
                $"Reached execution limit in {nameof(IsBangOnThePrize)} ({_iterationCount} iterations)");
        }

        long yDistance = Math.Abs(prize.Y - pos.Y);
        // the too-far-away limit is quite conservative (but multiplying by less than 1000 was not enough)
        long tooFarAwayY = 1000 * Math.Max(btnA.Y, btnB.Y);
        if (yDistance > tooFarAwayY)
        {
            throw new SolutionDoesNotExistException(
                $"Looks like we've diverged after {_iterationCount} iterations \n" +
                $"        prize.Y: {prize.Y} pos.Y: {pos.Y}  a={RequiredPressesOfA} b={RequiredPressesOfB}");
        }

        return pos == Prize;
    }

    public void ComputeRequiredNumberOfPresses()
    {
        if (_isLogOn) Console.WriteLine($"\n/ {ButtonA} {ButtonB} \n/ prize @ {Prize}");

        _executionLimit = 15_000L;

        _iterationCount = 0;

        try
        {
            long aCount = 1 + Prize.X / ButtonA.X;
            long bCount = 0L;

            for (long multiplier = GetMultiplier(); multiplier >= 1; multiplier /= 10)
            {
                // use elongated versions of button vectors to get close to the prize quicker
                // while close, shrink vectors gradually back to normal in order to improve the approximation
                // when multiplier == 1, aim for an exact hit (while checking if our guesses diverge)
                (long virtualACount, long virtualBCount) = IterativelyComputeRequiredNumberOfPresses(
                    buttonA: ButtonA * multiplier,
                    buttonB: ButtonB * multiplier,
                    prize: Prize,
                    shouldStopSearching: multiplier == 1 ? IsBangOnThePrize : IsCloseEnough,
                    startingACount: 1 + aCount / multiplier,
                    startingBCount: bCount / multiplier,
                    startingPos: Pos.Zero);
                aCount = virtualACount * multiplier;
                bCount = virtualBCount * multiplier;

                if (_isLogOn) Console.WriteLine($"     == multiplier {multiplier,9} -- {_iterationCount,3} iterations");
                _iterationCount = 0;

                if (Pos.Zero.Plus(ButtonA * aCount).Plus(ButtonB * bCount) == Prize)
                {
                    RequiredPressesOfA = aCount;
                    RequiredPressesOfB = bCount;
                    if (_isLogOn) Console.WriteLine($"   >{ComputeCost()}");
                    return;
                }
            }

            throw new SolutionDoesNotExistException("This one should never happen, I guess");
        }
        catch (SolutionDoesNotExistException e)
        {
            if (_isLogOn) Console.WriteLine($"   >NOPE!  --  {e.Message}");
            RequiredPressesOfA = -1;
            RequiredPressesOfB = -1;
        }
    }

    private (long a, long b) IterativelyComputeRequiredNumberOfPresses(Vector buttonA, Vector buttonB, Pos prize,
        Func<Pos, Pos, Vector, Vector, bool> shouldStopSearching, long startingACount, long startingBCount,
        Pos startingPos)
    {
        // strategy: with a changing combination of buttons A and B
        // try for their combined X to be close to the X of the prize

        long aCount = startingACount;
        long bCount = startingBCount;
        // make sure we start with a current target placed to the right of the prize
        while (aCount * buttonA.X + bCount * buttonB.X < prize.X) aCount++;
        var currentTarget = startingPos.Plus(buttonA * aCount).Plus(buttonB * bCount);

        while (!shouldStopSearching(currentTarget, prize, buttonA, buttonB))
        {
            if (currentTarget.X > prize.X)
            {
                aCount--;
            }
            else
            {
                bCount++;
            }

            _iterationCount++;
            currentTarget = startingPos.Plus(buttonA * aCount).Plus(buttonB * bCount);

            if (aCount < 0)
            {
                throw new SolutionDoesNotExistException("aCount fell below 0");
            }
        }

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