using System.Text.RegularExpressions;
using Advent_of_Code_2024.day24.gate;

namespace Advent_of_Code_2024.day24;

public partial class GateFinder
{
    private readonly List<Gate> _gates = new();

    private static readonly Regex GateDefinitionRegex = CreateGateDefinitionRegex();

    public GateFinder(IEnumerable<string> inputLines)
    {
        foreach (string line in inputLines)
        {
            GroupCollection gc = GateDefinitionRegex.Match(line).Groups;
            _gates.Add(new Gate(
                Input1: gc["n1"].Value,
                Input2: gc["n2"].Value,
                Output: gc["out"].Value,
                GateType: MapGateType(gc["op"].Value)));
        }
    }

    public string? FindGate(GateType gateType, string? name1, string? name2)
    {
        if (name1 == null || name2 == null) return null;
        return
        (
            _gates.Find(gate1 => gate1.GateType == gateType && gate1.Input2 == name2 && gate1.Input1 == name1)
            ?? _gates.Find(gate2 => gate2.GateType == gateType && gate2.Input2 == name1 && gate2.Input1 == name2)
        )?.Output;
    }

    public Gate? FindGate(string output)
    {
        return _gates.Find(x => x.Output == output);
    }

    [GeneratedRegex(@"(?<n1>\w+) (?<op>\w+) (?<n2>\w+) -> (?<out>\w+)")]
    private static partial Regex CreateGateDefinitionRegex();

    private static GateType MapGateType(string type) =>
        type switch
        {
            "AND" => GateType.And,
            "OR" => GateType.Or,
            "XOR" => GateType.Xor,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

    public record Gate(string Input1, string Input2, string Output, GateType GateType);
}