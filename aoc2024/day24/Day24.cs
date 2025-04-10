using Advent_of_Code_2024.day24.circuit;
using Advent_of_Code_2024.day24.gate;
using InterpolatedParsing;
using static Advent_of_Code_2024.day24.gate.GateType;

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

    public static void Part2(InputSelector inputSelector)
    {
        // just run the code in debug to find the problematic places and fix them on the go
        
        string[] inputLines = Input.GetInput(inputSelector)
            .Split(Environment.NewLine);
        IEnumerable<string> wireDefinitionLines = inputLines
            .TakeWhile(line => !string.IsNullOrWhiteSpace(line));
        IEnumerable<string> gateDefinitionLines = inputLines
            .SkipWhile(line => !string.IsNullOrWhiteSpace(line))
            .Skip(1);

        int bitCount = int.Parse(wireDefinitionLines.Max(x => x.Substring(1, 2))!);
        GateFinder finder = new GateFinder(gateDefinitionLines);
        // List<(string?, string?)> potentiallySwapped = new();
        // List<string> definitelySwapped = new();
        List<string> swapInfo = new();

        string? xWire, yWire, zWire, foundZWire;
        string? carryOverA, carryOverB;
        string? bitFromCurrentDigits, bitFromCarryOver;

        // input bits at position 0
        (xWire, yWire) = ("x00", "y00");
        foundZWire = finder.FindGate(Xor, xWire, yWire);
        // TODO: Expect foundZWire to be "z00"
        carryOverA = finder.FindGate(And, xWire, yWire);

        // input bits at position 1
        (xWire, yWire) = ("x01", "y01");
        bitFromCurrentDigits = finder.FindGate(Xor, xWire, yWire);
        foundZWire = finder.FindGate(Xor, carryOverA, bitFromCurrentDigits);
        // TODO: Expect foundZWire to be "z01"
        carryOverA = finder.FindGate(And, carryOverA, bitFromCurrentDigits);
        carryOverB = finder.FindGate(And, xWire, yWire);

        // input bits at positions 2 until last
        for (int i = 2; i <= bitCount; i++)
        {
            (xWire, yWire, zWire) = ($"x{i:D2}", $"y{i:D2}", $"z{i:D2}");
            // cannot be null
            bitFromCurrentDigits = finder.FindGate(Xor, xWire, yWire);
            // if null, carryOverA or carryOverB was swapped
            bitFromCarryOver = finder.FindGate(Or, carryOverA, carryOverB);
            if (bitFromCarryOver == null)
            {
                // SwappedOneOf(carryOverA, carryOverB);
                Swapped(oneOf: [carryOverA, carryOverB]);
            }
            // if null, bitFromCurrentDigit or bitFromCarryOver was swapped
            foundZWire = finder.FindGate(Xor, bitFromCurrentDigits, bitFromCarryOver);
            if (foundZWire == null)
            {
                if (bitFromCarryOver == null)
                {
                    // IMPORTANT
                    // in this situation we're unable to tell if there was a swap on bitFromCurrentDigits
                    
                    // var (wire1, wire2, _, _) = finder.FindGate(zWire);
                    // Swapped([bitFromCurrentDigits], shouldBeOneOf: [wire1, wire2]);
                }
                else
                {
                    Swapped(oneOf: [bitFromCurrentDigits, bitFromCarryOver]);
                }
            }
            if (foundZWire != zWire)
            {
                // TODO: add (foundZWire -> zWire) to a collection of known replacements
                // TODO: report that foundZWire and zWire are swapped
                // TODO: do the above in all the places in this loop
                Swapped(oneOf: [foundZWire], shouldBeOneOf: [zWire]);
            }
            // if null, bitFromCarryOver or bitFromCurrentDigits was swapped
            carryOverA = finder.FindGate(And, bitFromCarryOver, bitFromCurrentDigits);
            if (carryOverA == null)
            {
                Swapped(oneOf: [bitFromCarryOver, bitFromCurrentDigits]);
            }
            // cannot be null
            carryOverB = finder.FindGate(And, xWire, yWire);
        }

        // output bit at position one-past-last
        // if null, carryOverA or carryOverB was swapped
        foundZWire = finder.FindGate(Or, carryOverA, carryOverB);
        if (foundZWire == null)
        {
            Swapped(oneOf: [carryOverA, carryOverB]);
        }

        // void SwappedOneOf(string? wire1, string? wire2)
        // {
        //     potentiallySwapped.Add((carryOverA, carryOverB));
        // }

        void Swapped(string?[] oneOf, string[]? shouldBeOneOf = null)
        {
            if (shouldBeOneOf == null)
            {
                swapInfo.Add($"  SWAPPED SOME OF: {string.Join(',', oneOf)}");
            }
            else
            {
                swapInfo.Add($"  SWAPPED SOME OF: {string.Join(',', oneOf)}" +
                    $"   SHOULD BE: {string.Join(',', shouldBeOneOf)}");
            }
        }
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