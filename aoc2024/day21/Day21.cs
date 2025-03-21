using System.Collections.Concurrent;
using System.Globalization;

namespace Advent_of_Code_2024.day21;

public static partial class Day21
{
    public static string Part1(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        IKeyPressCounter pressCounter = CreatePressCounterFrom([
            new RemoteDirectionalKeypad(),
            new RemoteDirectionalKeypad(),
            new RemoteNumericalKeypad(),
        ]);

        return doorCodes
            .Select(code => ComputeComplexity(code, pressCounter.CountPresses(code)))
            .Sum()
            .ToString(CultureInfo.InvariantCulture);
    }

    public static string Part2(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        IKeyPressCounter pressCounter = CreateCachingPressCounterFrom([
            Enumerable.Repeat(new RemoteDirectionalKeypad(), 5),
            Enumerable.Repeat(new RemoteDirectionalKeypad(), 5),
            Enumerable.Repeat(new RemoteDirectionalKeypad(), 5),
            Enumerable.Repeat(new RemoteDirectionalKeypad(), 5),
            Enumerable.Repeat(new RemoteDirectionalKeypad(), 5),
            new RemoteNumericalKeypad().AsEnumerable(),
        ]);
        
        return doorCodes
            .Select(code => ComputeComplexity(code, pressCounter.CountPresses(code)))
            .Sum()
            .ToString(CultureInfo.InvariantCulture);
    }

    private static IKeyPressCounter CreatePressCounterFrom(IEnumerable<RemoteKeypad> remoteKeypads,
        IKeyPressCounter? startingCounter = null)
    {
        IKeyPressCounter result = startingCounter ?? new TerminalKeyPressCounter();
        foreach (var keypad in remoteKeypads)
        {
            result = new RemotingKeyPressCounter(keypad, result);
        }

        return result;
    }

    private static IKeyPressCounter CreateCachingPressCounterFrom(
        IEnumerable<IEnumerable<RemoteKeypad>> remoteKeypadsCollection)
    {
        IKeyPressCounter result = new TerminalKeyPressCounter();
        foreach (var keypads in remoteKeypadsCollection)
        {
            var resultWithCaching = new CachingCounter(result);
            // var resultWithCaching = result;
            result = CreatePressCounterFrom(keypads, startingCounter: resultWithCaching);
        }

        return result;
    }

    private static decimal ComputeComplexity(string code, decimal remoteSequenceLength)
    {
        return remoteSequenceLength * decimal.Parse(code.AsSpan(0, 3));
    }

}