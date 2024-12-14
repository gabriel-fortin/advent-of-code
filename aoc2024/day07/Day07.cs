namespace Advent_of_Code_2024.day07;

public static partial class Day07
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        Equation[] equations = ParseEquations(rawInput);
        
        foreach (Equation equation in equations)
        {
            equation.AttemptComputingExpectedValue(Operator.Add, Operator.Multiply);
        }

        return equations
            .Where(x => x.IsDoable)
            .Sum(x => x.ExpectedValue)
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        Equation[] equations = ParseEquations(rawInput);
        
        foreach (Equation equation in equations)
        {
            equation.AttemptComputingExpectedValue(Operator.Add, Operator.Multiply, Operator.Concatenate);
        }

        return equations
            .Where(x => x.IsDoable)
            .Sum(x => x.ExpectedValue)
            .ToString();
    }

    private static Equation[] ParseEquations(string rawInput)
    {
        return rawInput
            .Split('\n')
            .Select(line =>
            {
                int colonPosition = line.IndexOf(':');
                long expectedValue = long.Parse(line[..colonPosition]);
                int[] numbers = line[(colonPosition + 2)..].Split(' ')
                    .Select(s => int.Parse(s))
                    .ToArray();
                return new Equation(expectedValue, numbers);
            })
            .ToArray();
    }
}