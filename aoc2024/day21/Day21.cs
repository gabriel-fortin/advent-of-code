using System.Collections.Concurrent;
using System.Globalization;

namespace Advent_of_Code_2024.day21;

public static partial class Day21
{
    public static string Part1(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        var triRemoteKeypad = new ComposedRemoteKeypad(
            new RemoteNumericalKeypad(),
            new RemoteDirectionalKeypad(),
            new RemoteDirectionalKeypad());

        return doorCodes
            .Select(code => ComputeComplexity(code, triRemoteKeypad.KeysToRemotelyType(code)))
            .Sum()
            .ToString(CultureInfo.InvariantCulture);
    }

    public static string Part2(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        var multiRemoteKeypad = new ComposedRemoteKeypad(
            Enumerable.Repeat<IRemoteKeypad>(new RemoteDirectionalKeypad(), 25)
                .Prepend(new RemoteNumericalKeypad())
        );

        ConcurrentQueue<decimal> complexities = new ConcurrentQueue<decimal>();
        await Parallel.ForEachAsync(doorCodes, (doorCode, _) =>
        {
            IEnumerable<char> remoteSequence = multiRemoteKeypad.KeysToRemotelyType(doorCode);
            complexities.Enqueue(ComputeComplexity(doorCode, remoteSequence));
            return ValueTask.CompletedTask;
        });

        return complexities
            .Sum()
            .ToString(CultureInfo.InvariantCulture);
    }

    private static decimal ComputeComplexity(string code, IEnumerable<char> remoteSequence)
    {
        return remoteSequence.LongCount() * decimal.Parse(code.AsSpan(0, 3));
    }
}