using System.Globalization;

namespace Advent_of_Code_2024.day11;

public static partial class Day11
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        return ParseStones(rawInput)
            .LookAtThemAndBlink(25)
            .Length.ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        return ParseStones(rawInput)
            .LookAtThemAndBlink(75)
            .Length.ToString();
    }

    private static Stone[] ParseStones(string rawInput)
    {
        return rawInput
            .Split(' ')
            .Select(Stone.Create)
            .ToArray();
    }

    private static Stone[] LookAtThemAndBlink(this Stone[] stones, int blinkCount)
    {
        for (int i = 0; i < blinkCount; i++)
        {
            Console.Write($" [{i}: {stones.Length}] ");
            stones = stones
                .SelectMany(stone => stone.Blink())
                .ToArray();
        }
        Console.WriteLine();

        return stones;
    }
}

public class Stone
{
    private readonly string _textNumber;

    public Stone(string number)
    {
        int firstMeaningfulDigitIndex = 0;
        while (firstMeaningfulDigitIndex < number.Length && number[firstMeaningfulDigitIndex] == '0')
        {
            firstMeaningfulDigitIndex++;
        }

        // remove leading zeroes
        if (firstMeaningfulDigitIndex >= number.Length)
        {
            _textNumber = "0";
        }
        else if (firstMeaningfulDigitIndex > 0)
        {
            _textNumber = number[firstMeaningfulDigitIndex..];
        }
        else
        {
            _textNumber = number;
        }
    }

    public IEnumerable<Stone> Blink()
    {
        if (_textNumber == "0") yield return new("1");
        else if (_textNumber.Length % 2 == 0)
        {
            string next1 = _textNumber.Substring(0, _textNumber.Length / 2);
            string next2 = _textNumber.Substring(_textNumber.Length / 2);
            yield return new(next1);
            yield return new(next2);
        }
        else
        {
            decimal newNumber = 2024 * decimal.Parse(_textNumber);
            yield return new(newNumber.ToString(CultureInfo.InvariantCulture));
        }
    }

    public override string ToString() => _textNumber;

    public static Stone Create(string number) => new Stone(number);
}