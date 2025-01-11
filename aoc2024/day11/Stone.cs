using System.Globalization;

namespace Advent_of_Code_2024.day11;

public class Stone
{
    public readonly string Number;

    public Stone(string number)
    {
        // find how many leading zeroes we have
        int firstMeaningfulDigitIndex = 0;
        while (firstMeaningfulDigitIndex < number.Length && number[firstMeaningfulDigitIndex] == '0')
        {
            firstMeaningfulDigitIndex++;
        }

        // remove leading zeroes
        if (firstMeaningfulDigitIndex >= number.Length)
        {
            Number = "0";
        }
        else if (firstMeaningfulDigitIndex > 0)
        {
            Number = number[firstMeaningfulDigitIndex..];
        }
        else
        {
            Number = number;
        }
    }

    public IEnumerable<Stone> Blink()
    {
        if (Number == "0") yield return new("1");
        else if (Number.Length % 2 == 0)
        {
            string next1 = Number.Substring(0, Number.Length / 2);
            string next2 = Number.Substring(Number.Length / 2);
            yield return new(next1);
            yield return new(next2);
        }
        else
        {
            decimal newNumber = 2024 * decimal.Parse(Number);
            yield return new(newNumber.ToString(CultureInfo.InvariantCulture));
        }
    }

    public override string ToString() => Number;

    public static Stone Create(string number) => new Stone(number);
}