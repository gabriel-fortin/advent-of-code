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
        catch (HaltException)
        {
            // the halt exception is the signal to stop the execution
        }

        return string.Join(',', outputList);
    }

    public static string Part2(InputSelector inputSelector)
    {
        (Registers inputRegisters, string programText) = Input.GetInput(inputSelector);
        var program = new Program(programText);
        var comparer = new ProgramComparer(program);

        int searchedRegisterValue = 0;

        for (bool isMatchFound = false; !isMatchFound;)
        {
            searchedRegisterValue++;
            Registers registers = inputRegisters with { A = searchedRegisterValue };

            while (true)
            {
                if (!program.TryReadPairAt(registers.InstructionPointer, out int opcode, out int operand))
                {
                    // halt - reading past end of program
                    // the program halted but did it generate all the numbers we expect?
                    isMatchFound = comparer.IsFullMatch();
                    break;
                }

                // (int opcode, int operand) = program.At(registers.InstructionPointer);
                IInstruction instruction = Instruction.FromOpcode(opcode);
                instruction.Execute(operand, registers, comparer.Feed);

                if (!comparer.IsPartialMatch())
                {
                    // the output program differs from the original
                    break;
                }
            }

            comparer.Debug(searchedRegisterValue);
            comparer.Reset();
        }

        return searchedRegisterValue.ToString();
    }
}

public class HaltException : Exception
{
}