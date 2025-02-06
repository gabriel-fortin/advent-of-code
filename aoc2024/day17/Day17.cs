namespace Advent_of_Code_2024.day17;

public static partial class Day17
{
    public static string Part1(InputSelector inputSelector)
    {
        (Registers registers, string programText) = Input.GetInput(inputSelector);
        var program = new Program(programText);
        List<int> outputList = new();

        RunProgram(program, registers, outputList.Add);

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

            isMatchFound = RunProgram(program, registers, comparer.Feed, comparer);

            comparer.Debug(searchedRegisterValue);
            comparer.Reset();
        }

        return searchedRegisterValue.ToString();
    }

    private static bool RunProgram(Program program, Registers registers, Action<int> outputCollector,
        ProgramComparer? comparer = null)
    {
        comparer ??= new ProgramComparer(program);
        
        while (true)
        {
            if (!program.TryReadPairAt(registers.InstructionPointer, out int opcode, out int operand))
            {
                // halt - reading past end of program
                // the program halted but did it generate all the numbers we expect?
                return comparer.IsFullMatch();
            }

            // (int opcode, int operand) = program.At(registers.InstructionPointer);
            IInstruction instruction = Instruction.FromOpcode(opcode);
            instruction.Execute(operand, registers, outputCollector);

            if (!comparer.IsPartialMatch())
            {
                // the output program differs from the original
                break;
            }
        }

        return false;
    }
}

public class HaltException : Exception
{
}