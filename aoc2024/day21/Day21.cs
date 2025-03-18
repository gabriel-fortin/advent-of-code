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
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        var multiRemoteKeypad = new ComposedRemoteKeypad(
            Enumerable.Repeat<IRemoteKeypad>(new RemoteDirectionalKeypad(), 15)
                .Prepend(new RemoteNumericalKeypad())
        );

        return doorCodes
            .Select(code => ComputeComplexity(code, multiRemoteKeypad.KeysToRemotelyType(code)))
            .Sum()
            .ToString();
    }

    private static long ComputeComplexity(string code, IEnumerable<char> remoteSequence)
    {
        return remoteSequence.Count() * long.Parse(code.AsSpan(0, 3));
    }
}