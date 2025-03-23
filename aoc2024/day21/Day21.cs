using System.Globalization;

namespace Advent_of_Code_2024.day21;

public static partial class Day21
{
    public static string Part1(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        var numKeypad = new RemoteNumericalKeypad();
        var dirKeypad = new RemoteDirectionalKeypad();

        IEnumerable<string> remoteDoorSequences = doorCodes
            .Select(seq => numKeypad.KeysToRemotelyType(seq))
            .Select(seq => dirKeypad.KeysToRemotelyType(seq))
            .Select(seq => dirKeypad.KeysToRemotelyType(seq))
            .Select(x => new string(x.ToArray()));

        return remoteDoorSequences
            .Zip(doorCodes, (sequence, code) => (sequence, code))
            .Select(x => ComputeComplexity(x.code, x.sequence.Length))
            .Sum()
            .ToString(CultureInfo.InvariantCulture);
    }

    public static string Part2(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        // there will be a caching layer in between every 5 layers of keypads
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
            // insert a caching layer between sets of IEnumerable<RemoteKeypad>
            result = CreatePressCounterFrom(keypads, new CachingCounter(result));
        }

        return result;
    }

    private static decimal ComputeComplexity(string code, decimal remoteSequenceLength)
    {
        return remoteSequenceLength * decimal.Parse(code.AsSpan(0, 3));
    }
}