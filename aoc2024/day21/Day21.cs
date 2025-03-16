namespace Advent_of_Code_2024.day21;

public static partial class Day21
{
    public static string Part1(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        var triRemoteKeypad = new ComposedRemoteKeypad(
            new RemoteNumericalKeypad(debugPrintKeys: false),
            new RemoteDirectionalKeypad(debugPrintKeys: false),
            new RemoteDirectionalKeypad(debugPrintKeys: false));

        return doorCodes
            .Select(code => ComputeComplexity(code, triRemoteKeypad.KeysToRemotelyType(code)))
            .Sum()
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static int ComputeComplexity(string code, IEnumerable<char> remoteSequence)
    {
        return remoteSequence.Count() * int.Parse(code.AsSpan(0, 3));
    }
}