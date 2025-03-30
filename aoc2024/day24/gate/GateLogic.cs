namespace Advent_of_Code_2024.day24.gate;

public class GateLogic
{
    private GateLogic(Func<int, int, int> compute)
    {
        Compute = compute;
    }
    
    public Func<int, int, int> Compute { get; }

    private static readonly Dictionary<GateType, GateLogic> Gates = new()
    {
        [GateType.And] = new GateLogic((a, b) => a * b),
        [GateType.Or] = new GateLogic((a,b) =>  a | b),
        [GateType.Xor] = new GateLogic((a,b) => a ^ b),
    };
    
    public static GateLogic For(GateType gateType) => Gates[gateType];
}