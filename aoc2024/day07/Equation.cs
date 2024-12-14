using System.Collections.Immutable;

namespace Advent_of_Code_2024.day07;

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

    public void AttemptComputingExpectedValue(params Operator[] operations)
    {
        if (operations.Length == 0) throw new ArgumentException();

        IEnumerable<IList<Operator>> permutations = GetAllOperatorPermutations(Numbers.Length - 1, operations);
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

    private void AttemptComputingExpectedValueUsingLinq(params Operator[] operations)
    {
        IsDoable = GetAllOperatorPermutations(Numbers.Length - 1, operations)
            .Any(operationSequence => ComputeValue(operationSequence) == ExpectedValue);
    }

    private long ComputeValue(IList<Operator> operations)
    {
        long value = Numbers[0];
        for (int i = 1; i < Numbers.Length; i++)
        {
            value = operations[i - 1].Apply(value, Numbers[i]);
        }

        return value;
    }

    private long ComputeValueUsingLinq(IList<Operator> operations)
    {
        return Numbers.Skip(1)
            .Zip(operations, (n, op) => (n, op))
            .Aggregate(Numbers[0],
                (long acc, (int n, Operator op) tuple) => tuple.op.Apply(acc, tuple.n));
    }

    public static IEnumerable<ImmutableList<Operator>> GetAllOperatorPermutations(int size,
        params Operator[] operations)
    {
        if (size == 0)
        {
            yield return ImmutableList<Operator>.Empty;
            yield break;
        }

        foreach (var shorterSequence in GetAllOperatorPermutations(size - 1, operations))
        {
            foreach (var op in operations)
            {
                // shorterSequence is immutable, calling .Add creates a new list
                yield return shorterSequence.Add(op);
            }
        }
    }
}