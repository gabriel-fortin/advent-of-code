using Advent_of_Code_2024.day24.circuit;
using Advent_of_Code_2024.day24.gate;
using InterpolatedParsing;

namespace Advent_of_Code_2024.day24;

public static partial class Day24
{
    public static string Part1(InputSelector inputSelector)
    {
        string[] inputLines = Input.GetInput(inputSelector)
            .Split(Environment.NewLine);
        IEnumerable<string> wireDefinitionLines = inputLines
            .TakeWhile(line => !string.IsNullOrWhiteSpace(line));
        IEnumerable<string> gateDefinitionLines = inputLines
            .SkipWhile(line => !string.IsNullOrWhiteSpace(line))
            .Skip(1);

        Circuit circuit = new();

        foreach (string wireDefinitionLine in wireDefinitionLines)
        {
            // WARNING: InterpolatedParser in a 'fun' library
            //          don't use it in production (its github page explains why)
            string wireName = null!;
            int value = -1;
            InterpolatedParser.Parse(wireDefinitionLine, $"{wireName}: {value}");

            circuit.AddInputWire(wireName, value);
        }

        foreach (string gateDefinitionLine in gateDefinitionLines)
        {
            // WARNING: InterpolatedParser in a 'fun' library
            //          don't use it in production (its github page explains why)
            string wire1 = null!;
            string wire2 = null!;
            string operation = null!;
            string outputWire = null!;
            InterpolatedParser.Parse(gateDefinitionLine, $"{wire1} {operation} {wire2} -> {outputWire}");

            circuit.AddGate(MapGateType(operation), wire1, wire2, outputWire);
        }

        return circuit.ReadOutputWires()
            .Aggregate(0L, (partialResult, bit) => (partialResult << 1) + bit)
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static GateType MapGateType(string type) =>
        type switch
        {
            "AND" => GateType.And,
            "OR" => GateType.Or,
            "XOR" => GateType.Xor,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}