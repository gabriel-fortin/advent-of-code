namespace Advent_of_Code_2024.day17;

public static partial class Day17
{
    public static string Part1(InputSelector inputSelector)
    {
        (Registers registers, string programText) = Input.GetInput(inputSelector);
        var program = new Program(programText);
        List<long> outputList = new();

        RunProgram(program, registers, outputList.Add);

        return string.Join(',', outputList);
    }

    public static string Part2(InputSelector inputSelector)
    {
        (Registers inputRegisters, string programText) = Input.GetInput(inputSelector);
        var program = new Program(programText);
        var comparer = new ProgramComparer(program);
        
        // observation: the end of the value (in octal) doesn't change once the value is big enough
        // that allows to increment by multiplies of 8 - the actual multiplier is chosen by trial and error

        long searchedRegisterValue = 0;
        long increment = 1;
        int bestPartialMatchLength = 0;
        int sanityCounter = 25; // for debugging

        for (bool isMatchFound = false; !isMatchFound;)
        {
            searchedRegisterValue += increment;
            string valueAsBase8String = Convert.ToString(searchedRegisterValue, 8); // for debugging

            Registers registers = inputRegisters with { A = searchedRegisterValue };

            (isMatchFound, int partialMatchLength) = RunProgram(program, registers, comparer.Feed, comparer);

            if (partialMatchLength > bestPartialMatchLength)
            {
                bestPartialMatchLength = partialMatchLength;

                if (searchedRegisterValue > increment * 8 * 8 * 8)
                {
                    if (sanityCounter-- < 0) throw new Exception("AAAAAA");
                    increment *= 8;
                    Console.WriteLine($"  increment is now {Convert.ToString(increment, 8)}" +
                        $" ( regA = {Convert.ToString(searchedRegisterValue, 8)} )");
                }
            }

            comparer.Debug(searchedRegisterValue);
            comparer.Reset();
        }

        return searchedRegisterValue.ToString();
    }

    private static (bool isMatchFound, int partialMatchLength) RunProgram(Program program, Registers registers,
        Action<long> outputCollector, ProgramComparer? comparer = null)
    {
        comparer ??= new ProgramComparer(program);

        while (true)
        {
            if (!program.TryReadPairAt(registers.InstructionPointer, out int opcode, out int operand))
            {
                // halt - reading past end of program
                // the program halted but did it generate all the numbers we expect?
                return (comparer.IsFullMatch(), comparer.PartialMatchLength);
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

        return (false, comparer.PartialMatchLength);
    }
}

public class HaltException : Exception
{
}