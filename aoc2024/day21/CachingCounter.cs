namespace Advent_of_Code_2024.day21;

public class CachingCounter(IKeyPressCounter nextLayer) : IKeyPressCounter
{
    private readonly Dictionary<(char, char), decimal> _cache = new();

    public decimal CountPresses(IEnumerable<char> sequence, char? startingKey = null)
    {
        decimal result = 0M;
        char previousKey = startingKey ?? 'A';
        foreach (char currentKey in sequence)
        {
            if (!_cache.TryGetValue((previousKey, currentKey), out var count))
            {
                count = nextLayer.CountPresses([currentKey], startingKey: previousKey);
                _cache.Add((previousKey, currentKey), count);
            }

            result += count;
            previousKey = currentKey;
        }

        return result;
    }
}