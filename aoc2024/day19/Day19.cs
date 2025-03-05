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
        for (int patternPos = 0; patternPos < pattern.Length;)
        {
            string? matchingTowel = null;
            foreach (var towel in availableTowels)
            {
                if (patternPos + towel.Length > pattern.Length) continue;

                for (int towelPos = 0; towelPos < towel.Length; towelPos++)
                {
                    if (pattern[patternPos + towelPos] != towel[towelPos])
                    {
                        goto not_this_towel;
                    }
                }

                matchingTowel = towel;

                not_this_towel: ;
            }

            if (matchingTowel == null)
            {
                return false;
            }

            patternPos += matchingTowel.Length;

            if (patternPos == pattern.Length)
            {
                return true;
            }
        }

        return false;
    }
}