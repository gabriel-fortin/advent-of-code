using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.day03;

public static partial class Day03
{
    private const string DO = "do()";
    private const string DONT = "don't()";
    private static readonly Regex MulStructure = new(@"mul\((\d{1,3}),(\d{1,3})\)");

    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInputForPart1(useExampleData);

        return MulStructure
            .Matches(rawInput)
            .Select(match => new Mul(match))
            .Aggregate(0L, (acc, mul) => acc + mul.ComputedValue)
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInputForPart2(useExampleData);

        bool isMulEnabled = true;
        int inputIndex = 0;
        List<Mul> enabledMuls = new();

        while (inputIndex < rawInput.Length)
        {
            Match mul = MulStructure.Match(rawInput, inputIndex);
            int doIndex = rawInput.IndexOf(DO, inputIndex);
            int dontIndex = rawInput.IndexOf(DONT, inputIndex);
            // "IndexOf" returns -1 if it doesn't find the requested string
            // but handling -1 would make conditions longer and less clear
            // so we replace -1's with an index somewhere after the end of the input
            if (doIndex == -1) doIndex = rawInput.Length;
            if (dontIndex == -1) dontIndex = rawInput.Length;

            // if there are no more "mul" instructions then there's nothing more to add to the list
            if (!mul.Success) break;

            // if mul instructions are disabled, we just find where they are enabled again
            // if they are enabled, we need to find out what comes first: a "don't" or a "mul"
            if (!isMulEnabled)
            {
                inputIndex = doIndex + DO.Length;
                isMulEnabled = true;
            }
            else if (dontIndex < mul.Index)
            {
                inputIndex = dontIndex + DONT.Length;
                isMulEnabled = false;
            }
            else
            {
                inputIndex = mul.Index + mul.Length;
                enabledMuls.Add(new Mul(mul));
            }
        }

        return enabledMuls
            .Sum(x => x.ComputedValue)
            .ToString();
    }

    public record Mul
    {
        public int ComputedValue { get; }

        public Mul(string mulText) : this(MulStructure.Match(mulText))
        {
        }

        public Mul(Match match)
        {
            if (!match.Success) throw new ArgumentException($"Invalid mul text: {match.Value}");

            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            ComputedValue = x * y;
        }
    }
}