namespace Advent_of_Code_2024.day21;

public static partial class Day21
{
    public static string Part1(InputSelector inputSelector)
    {
        string[] doorCodes = Input.GetInput(inputSelector).Split(Environment.NewLine);

        return doorCodes
            .Select(code => ComputeComplexity(code, TripleRemote(code)))
            .Sum()
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static IEnumerable<char> TripleRemote(string code)
    {
        var numPad = new RemoteNumericalKeypad(debugPrintKeys: false);
        var dirPad = new RemoteDirectionalKeypad(debugPrintKeys: false);

        return new IRemoteKeypad[]
            {
                numPad, dirPad, dirPad
            }
            .Aggregate(
                seed: code.AsEnumerable(),
                func: (remotedCode, keyPad) => keyPad.KeysToRemotelyType(remotedCode));
    }

    private static int ComputeComplexity(string code, IEnumerable<char> remoteSequence)
    {
        return remoteSequence.Count() * int.Parse(code.AsSpan(0, 3));
    }
}