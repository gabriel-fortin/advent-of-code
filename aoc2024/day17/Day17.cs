namespace Advent_of_Code_2024.day17;

public static partial class Day17
{
    public static string Part1(InputSelector inputSelector)
    {
        (Registers registers, string programText) = Input.GetInput(inputSelector);
        var program = new Program(programText);
        List<int> outputList = new();
        
        try
        {
            while (true)
            {
                (int opcode, int operand) = program.At(registers.InstructionPointer);
                IInstruction instruction = Instruction.FromOpcode(opcode);
                instruction.Execute(operand, registers, outputList.Add);
            }
        }
        catch(HaltException haltException)
        {
            // the halt exception is the signal to stop the execution
        }

        return string.Join(',', outputList);
    }
}

public class HaltException : Exception
{
}