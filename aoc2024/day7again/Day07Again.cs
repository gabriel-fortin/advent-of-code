using System.Collections.Immutable;

namespace Advent_of_Code_2024.day7again;

public static partial class Day07Again
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var equations = ParseEquation(rawInput);

        foreach (Equation equation in equations)
        {
            equation.TryToComputeIt(Operator.Add, Operator.Multiply);
        }

        return equations
            .Where(x => x.IsDoable)
            .Sum(x => x.ExpectedValue)
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var equations = ParseEquation(rawInput);

        foreach (Equation equation in equations)
        {
            equation.TryToComputeIt(Operator.Add, Operator.Multiply, Operator.Concat);
        }

        return equations
            .Where(x => x.IsDoable)
            .Sum(x => x.ExpectedValue)
            .ToString();
    }

    private static Equation[] ParseEquation(string rawInput)
    {
        return rawInput
            .Split("\r\n")
            .Select(line =>
            {
                int colonPosition = line.IndexOf(':');
                long expectedValue = long.Parse(line[..colonPosition]);
                int[] numbers = line[(colonPosition + 2)..].Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                return new Equation(expectedValue, numbers);
            })
            .ToArray();
    }
}

public record Equation(long ExpectedValue, int[] Numbers)
{
    public bool IsDoable { get; private set; }

    public void TryToComputeIt(params Operator[] operators)
    {
        IEnumerable<IList<Operator>> allCombinations
            = GetAllOperatorCombinations(Numbers.Length - 1, operators.ToList());
        foreach (IList<Operator> combination in allCombinations)
        {
            IsDoable = CanComputeValue(combination);
            if (IsDoable) { return; }
        }
    }

    private bool CanComputeValue(IList<Operator> operators)
    {
        long value = Numbers[0];
        for (int i = 1; i < Numbers.Length; i++)
        {
            // value = value * Numbers[i];
            value = operators[i - 1].Apply(value, Numbers[i]);
            if (value > ExpectedValue) return false;
        }

        return value == ExpectedValue;
    }

    private long ComputeValueUsingLinq(IList<Operator> operators)
    {
        return Numbers.Skip(1)
            .Zip(operators, (n, op) => (n, op))
            .Aggregate(Numbers[0],
                (long resultSoFar, (int n, Operator op) tuple) =>
                    tuple.op.Apply(resultSoFar, tuple.n));
    }

    private IEnumerable<ImmutableList<Operator>> GetAllOperatorCombinations(int size,
        List<Operator>operators)
    {
        if (size == 0)
        {
            yield return ImmutableList<Operator>.Empty;
            yield break;
        }
        IEnumerable<ImmutableList<Operator>> allSmallerCombinations
            = GetAllOperatorCombinations(size-1, operators);
        foreach (ImmutableList<Operator> smallerCombination in allSmallerCombinations)
        {
            foreach (Operator op in operators)
            {
                yield return smallerCombination.Add(op);
            }
        }
    }

    // GetAllNumbers().Take(20);
    // 1, 2, 3, 4, ...
    private IEnumerable<int> GetAllNumbers()
    {
        int currentNumber = 1;
        while (true)
        {
            yield return currentNumber;
            currentNumber++;
        }
    }
}

public class Operator
{
    public Func<long, int, long> Apply { get; }

    private Operator(Func<long, int, long> apply)
    {
        Apply = apply;
    }

    public static Operator Add = new Operator((x, y) => x + y);
    public static Operator Multiply = new Operator((x, y) => x * y);

    public static Operator Concat = new Operator(
        // (x, y) => long.Parse($"{x}{y}"));
        (x, y) => long.Parse(string.Concat(x,y)));
}