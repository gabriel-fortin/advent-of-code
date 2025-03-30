using Advent_of_Code_2024.day24.gate;

namespace Advent_of_Code_2024.day24.circuit;

public partial class Circuit
{
    private readonly Dictionary<string, Wire> _wires = new();

    public void AddInputWire(string name, int value)
    {
        GetOrCreateWire(name).SetValue(value);
    }

    public void AddGate(GateType type, string input1, string input2, string output)
    {
        var gate = new Gate(GateLogic.For(type))
            .ConnectInput1To(GetOrCreateWire(input1))
            .ConnectInput2To(GetOrCreateWire(input2));
        GetOrCreateWire(output)
            .ConnectInputTo(gate);
    }

    /// <summary>
    /// Returns wires in [..., z03, z02, z01] order
    /// </summary>
    public IEnumerable<int> ReadOutputWires()
    {
        return _wires
            .Where(x => x.Key.StartsWith('z'))
            .OrderByDescending(x => x.Key)
            .Select(x => x.Value.OutputValue
                ?? throw new InvalidOperationException($"Output value for wire '{x.Key}' is not set"))
            .ToArray();
    }

    private Wire GetOrCreateWire(string name)
    {
        if (_wires.TryGetValue(name, out var wire))
        {
            return wire;
        }

        return _wires[name] = new Wire();
    }
}