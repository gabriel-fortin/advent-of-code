namespace Advent_of_Code_2024.day19;

public class PatternCounter(string targetPattern, string[] availableTowels)
{
    private readonly Dictionary<ReadOnlyMemory<char>, long> _cache = new ();

    public long Count()
    {
        return Count(targetPattern.AsMemory());
    }

    private long Count(ReadOnlyMemory<char> pattern)
    {
        if (pattern.IsEmpty) return 1L;

        if (_cache.TryGetValue(pattern, out long cachedCount))
        {
            return cachedCount;
        }

        return _cache[pattern] = availableTowels.Sum(towel =>
            TowelFitsIntoPattern(towel, pattern)
                ? Count(pattern.Slice(towel.Length))
                : 0);
    }

    private static bool TowelFitsIntoPattern(string towel, ReadOnlyMemory<char> pattern)
    {
        if (towel.Length > pattern.Length) return false;

        for (int i = 0; i < towel.Length; i++)
        {
            if (pattern.Span[i] != towel[i])
            {
                return false;
            }
        }

        return true;
    }
}