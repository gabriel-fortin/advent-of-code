namespace Advent_of_Code_2024.day11;

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