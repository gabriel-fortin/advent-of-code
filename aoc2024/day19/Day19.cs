namespace Advent_of_Code_2024.day19;

public static partial class Day19
{
    public static string Part1(InputSelector inputSelector)
    {
        string[] rawLines = Input.GetInput(inputSelector).Split(Environment.NewLine);
        string[] expectedPatterns = rawLines.Skip(2).ToArray();
        string[] availableTowels = rawLines[0].Split(", ").OrderBy(x => x.Length).ToArray();

        return expectedPatterns
            .Select(pattern => IsPatternPossible(pattern, availableTowels))
            .Count(x => x)
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static bool IsPatternPossible(string pattern, string[] availableTowels)
    {
        if (pattern.Length == 0) return true;

        return availableTowels.Any(towel =>
            TowelFitsIntoPattern(towel, pattern) &&
            IsPatternPossible(pattern.Substring(towel.Length), availableTowels));
    }

    private static bool IsPatternPossible__withoutLinq__withSpan(ReadOnlySpan<char> pattern, string[] availableTowels)
    {
        foreach (string towel in availableTowels)
        {
            if (TowelFitsIntoPattern(towel, pattern))
            {
                ReadOnlySpan<char> remainingPattern = pattern.Slice(towel.Length);
                if (IsPatternPossible__withoutLinq__withSpan(remainingPattern, availableTowels))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool TowelFitsIntoPattern(string towel, ReadOnlySpan<char> pattern)
    {
        if (towel.Length > pattern.Length) return false;

        for (int i = 0; i < towel.Length; i++)
        {
            if (pattern[i] != towel[i])
            {
                return false;
            }
        }

        return true;
    }
}