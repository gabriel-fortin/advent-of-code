using System.Globalization;

namespace Advent_of_Code_2024.day11;

public static partial class Day11
{
    // a shared cache of known computations
    private static StoneCounter _stoneCounter = new StoneCounter();
    
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        return ParseStones(rawInput)
            .LookAtThemAndBlink(blinkCount: 25)
            .Length.ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        
        return ParseStones(rawInput)
            // we're not really interested in the actual values on stones
            // so instead of blinking, we care only about the counts, and we cache them where possible
            .Select(stone => _stoneCounter.StoneCount(stone.Number, 75))
            .Sum().ToString();
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
            stones = stones
                .SelectMany(stone => stone.Blink())
                .ToArray();
        }

        return stones;
    }
}

public class Stone
{
    public readonly string Number;

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

public class StoneCounter
{
    private readonly Dictionary<string, long> _stoneCountCache = new();

    /// <summary>
    /// Returns the number of stones the given stone will transform into after the given number of blinks
    /// </summary>
    public long StoneCount(string stoneValue, int blinkCount)
    {
        if (blinkCount == 0)
        {
            AddCacheCount(stoneValue, blinkCount, 1);
            return 1;
        }

        if (TryGetCachedCount(stoneValue, blinkCount, out var cachedStoneCount))
        {
            return cachedStoneCount;
        }

        IEnumerable<Stone> stonesAfterBlink = new Stone(stoneValue).Blink();
        // recursive call
        var stoneCount =  stonesAfterBlink.Sum(stone => StoneCount(stone.Number, blinkCount - 1));
        AddCacheCount(stoneValue, blinkCount, stoneCount);
        return stoneCount;
    }

    private bool TryGetCachedCount(string stoneValue, int blinkCount, out long cachedStoneCount)
    {
        return _stoneCountCache.TryGetValue($"{stoneValue}_{blinkCount}", out cachedStoneCount);
    }

    private void AddCacheCount(string stoneValue, int blinkCount, long stoneCount)
    {
        _stoneCountCache[$"{stoneValue}_{blinkCount}"] = stoneCount;
    }
}
