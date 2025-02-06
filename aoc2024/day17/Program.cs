namespace Advent_of_Code_2024.day17;

public class Program(string programText)
{
    public readonly int[] ProgramInstructionsAndOperands = programText
        .Split(',')
        .Select(int.Parse)
        .ToArray();

    public bool TryReadAt(int position, out int nextNumber)
    {
        if (position >= ProgramInstructionsAndOperands.Length)
        {
            nextNumber = -1;
            return false;
        }

        nextNumber = ProgramInstructionsAndOperands[position];
        return true;
    }

    public bool TryReadPairAt(int position, out int opcode, out int operand)
    {
        if (TryReadAt(position, out var opcode2) && TryReadAt(position + 1, out var operand2))
        {
            (opcode, operand) = (opcode2, operand2);
            return true;
        }
    
        (opcode, operand) = (-1, -1);
        return false;
    }

    public (int opcode, int operand) At(int position)
    {
        if (TryReadAt(position, out var opcode) && TryReadAt(position + 1, out var operand))
        {
            return (opcode, operand);
        }

        throw new HaltException();
    }
}