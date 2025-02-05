namespace Advent_of_Code_2024.day17;

public class Program(string programText)
{
    private readonly int[] _programInstructionsAndOperands = programText
        .Split(',')
        .Select(int.Parse)
        .ToArray();

    public (int opcode, int operand) At(int position) =>
        position >= _programInstructionsAndOperands.Length
            ? throw new HaltException()
            : (_programInstructionsAndOperands[position], _programInstructionsAndOperands[position + 1]);
}