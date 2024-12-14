using System.Collections.Immutable;

namespace Advent_of_Code_2024.day07;

public static partial class Day07
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        Equation[] equations = ParseEquations(rawInput);

        return equations
            .Where(x => x.IsDoable)
            .Sum(x => x.ExpectedValue)
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        return "NOT IMPLEMENTED";
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
        AttemptComputingExpectedValue();
    }

    private void AttemptComputingExpectedValue()
    {
        foreach (IList<Operation> operationSequence in Operation.GetAllOperationSequencesOfSize(Numbers.Length - 1))
        {
            if (ComputeValue(operationSequence) == ExpectedValue)
            {
                IsDoable = true;
                return;
            }
        }

        IsDoable = false;
    }

    private void AttemptSolvingEquationUsingLinq()
    {
        IsDoable = Operation
            .GetAllOperationSequencesOfSize(Numbers.Length - 1)
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
}

public class Operation
{
    public string Name { get; }

    public Func<long, int, long> Apply { get; }

    private Operation(string name, Func<long, int, long> apply)
    {
        Name = name;
        Apply = apply;
    }

    public override string ToString() => Name;

    public static IEnumerable<ImmutableList<Operation>> GetAllOperationSequencesOfSize(int size)
    {
        if (size == 0)
        {
            yield return ImmutableList<Operation>.Empty;
            yield break;
        }

        foreach (var shorterSequence in GetAllOperationSequencesOfSize(size - 1))
        {
            yield return shorterSequence.Add(Add);
            yield return shorterSequence.Add(Multiply);
        }
    }

    public static readonly Operation Add = new Operation("Add", (x, y) => x + y);
    public static readonly Operation Multiply = new Operation("Multiply", (x, y) => x * y);
}