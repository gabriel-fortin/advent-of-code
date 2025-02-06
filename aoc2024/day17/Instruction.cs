namespace Advent_of_Code_2024.day17;

public interface IInstruction
{
    void Execute(int operand, Registers registers, Action<long> writeOutput);
}

public partial class Instruction : IInstruction
{
    private delegate void InstructionImplementation(int operand, Registers registers, Action<long> writeOutput);

    private readonly InstructionImplementation _instructionImplementation;

    private Instruction(InstructionImplementation instructionImplementation)
    {
        _instructionImplementation = instructionImplementation;
    }

    public void Execute(int operand, Registers registers, Action<long> writeOutput) =>
        _instructionImplementation(operand, registers, writeOutput);

    public static IInstruction FromOpcode(int opcode)
    {
        // flyweight pattern - every instruction is created only once
        return opcode switch
        {
            0 => Adv,
            1 => Bxl,
            2 => Bst,
            3 => Jnz,
            4 => Bxc,
            5 => Out,
            6 => Bdv,
            7 => Cdv,
        };
    }

    private static long ComboOperand(int operand, Registers registers)
    {
        return operand switch
        {
            >= 0 and <= 3 => operand,
            4 => registers.A,
            5 => registers.B,
            6 => registers.C,
            7 => throw new InvalidOperationException("Combo operand 7 is reserved and should never appear"),
        };
    }

    private static long Modulo8(long value)
    {
        return value & 0b111;
    }
}