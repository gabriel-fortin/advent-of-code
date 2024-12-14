using System.Collections.Immutable;

namespace Advent_of_Code_2024.day07;

public static partial class Day07
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        Equation[] equations = ParseEquations(rawInput);
        
        foreach (Equation equation in equations)
        {
            equation.AttemptComputingExpectedValue(Operation.Add, Operation.Multiply);
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
            equation.AttemptComputingExpectedValue(Operation.Add, Operation.Multiply, Operation.Concatenate);
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

public record Equation
{
    public long ExpectedValue { get; }

    public int[] Numbers { get; }

    public bool IsDoable { get; private set; }

    public Equation(long ExpectedValue, int[] Numbers)
    {
        this.ExpectedValue = ExpectedValue;
        this.Numbers = Numbers;
        // AttemptComputingExpectedValue();
    }

    public void AttemptComputingExpectedValue(params Operation[] operations)
    {
        if (operations.Length == 0) throw new ArgumentException();

        IEnumerable<IList<Operation>> permutations = GetAllOperationPermutations(Numbers.Length - 1, operations);
        foreach (var operationSequence in permutations)
        {
            if (ComputeValue(operationSequence) == ExpectedValue)
            {
                IsDoable = true;
                return;
            }
        }

        IsDoable = false;
    }

    private void AttemptComputingExpectedValueUsingLinq(params Operation[] operations)
    {
        IsDoable = GetAllOperationPermutations(Numbers.Length - 1, operations)
            .Any(operationSequence => ComputeValue(operationSequence) == ExpectedValue);
    }

    private long ComputeValue(IList<Operation> operations)
    {
        long value = Numbers[0];
        for (int i = 1; i < Numbers.Length; i++)
        {
            value = operations[i - 1].Apply(value, Numbers[i]);
        }

        return value;
    }

    private long ComputeValueUsingLinq(IList<Operation> operations)
    {
        return Numbers.Skip(1)
            .Zip(operations, (n, op) => (n, op))
            .Aggregate(Numbers[0],
                (long acc, (int n, Operation op) tuple) => tuple.op.Apply(acc, tuple.n));
    }

    public static IEnumerable<ImmutableList<Operation>> GetAllOperationPermutations(int size,
        params Operation[] operations)
    {
        if (size == 0)
        {
            yield return ImmutableList<Operation>.Empty;
            yield break;
        }

        foreach (var shorterSequence in GetAllOperationPermutations(size - 1, operations))
        {
            foreach (var op in operations)
            {
                // shorterSequence is immutable, calling .Add creates a new list
                yield return shorterSequence.Add(op);
            }
        }
    }
}

public class Operation
{
    public Func<long, int, long> Apply { get; }

    private Operation(Func<long, int, long> apply)
    {
        Apply = apply;
    }

    public static readonly Operation Add = new Operation((x, y) => x + y);
    public static readonly Operation Multiply = new Operation((x, y) => x * y);
    public static readonly Operation Concatenate =
        new Operation((x, y) => long.Parse(string.Concat(x,y)));
}