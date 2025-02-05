namespace Advent_of_Code_2024.day17;

public partial class Instruction
{
    private static readonly IInstruction Adv = new Instruction((operand, registers, writeOutput) =>
    {
        var numerator = registers.A;
        var denominator = 1 << ComboOperand(operand, registers);
        registers.A = numerator / denominator;
        registers.InstructionPointer += 2;
    });

    private static readonly IInstruction Bdv = new Instruction((operand, registers, writeOutput) =>
    {
        var numerator = registers.A;
        var denominator = 1 << ComboOperand(operand, registers);
        registers.B = numerator / denominator;
        registers.InstructionPointer += 2;
    });

    private static readonly IInstruction Cdv = new Instruction((operand, registers, writeOutput) =>
    {
        var numerator = registers.A;
        var denominator = 1 << ComboOperand(operand, registers);
        registers.C = numerator / denominator;
        registers.InstructionPointer += 2;
    });

    private static readonly IInstruction Bxl = new Instruction((operand, registers, writeOutput) =>
    {
        registers.B ^= operand;
        registers.InstructionPointer += 2;
    });

    private static readonly IInstruction Bst = new Instruction((operand, registers, writeOutput) =>
    {
        registers.B = Modulo8(ComboOperand(operand, registers));
        registers.InstructionPointer += 2;
    });

    private static readonly IInstruction Jnz = new Instruction((operand, registers, writeOutput) =>
    {
        if (registers.A == 0)
        {
            registers.InstructionPointer += 2;
            return;
        }

        registers.InstructionPointer = operand;
    });

    private static readonly IInstruction Bxc = new Instruction((operand, registers, writeOutput) =>
    {
        registers.B ^= registers.C;
        registers.InstructionPointer += 2;
    });

    private static readonly IInstruction Out = new Instruction((operand, registers, writeOutput) =>
    {
        writeOutput(Modulo8(ComboOperand(operand, registers)));
        registers.InstructionPointer += 2;
    });
}