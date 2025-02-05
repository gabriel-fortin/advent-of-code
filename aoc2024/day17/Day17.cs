namespace Advent_of_Code_2024.day17;

public static partial class Day17
{
    public static string Part1(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }
}

public delegate void WriteOutput(int dataToWrite);

public delegate (int opcode, int operand) ProgramCodeAt(int position);

public class HaltException : Exception
{
}