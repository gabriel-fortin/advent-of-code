
namespace Advent_of_Code_2024.day05;

public static partial class Day05
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        (PageOrderingRule[] orderingRules, SafetyManualUpdate[] updates) = Parsing.ParseInput(rawInput);

        return updates
            .Where(x => IsUpdateRightlyOrdered(orderingRules, x))
            .Select(x => x.MiddlePage.Value)
            .Sum()
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        return "NOT IMPLEMENTED";
    }

    private static bool IsUpdateRightlyOrdered(PageOrderingRule[] orderingRules, SafetyManualUpdate update)
    {
        for (var i = 0; i < update.Pages.Length; i++)
        {
            for (var j = i + 1; j < update.Pages.Length; j++)
            {
                if (orderingRules.Any(rule => rule.IsBrokenBy(update.Pages[i], update.Pages[j])))
                {
                    return false;
                }
            }
        }

        return true;
    }
}

public record PageOrderingRule(Page Predecessor, Page Successor)
{
    public bool IsBrokenBy(Page predecessor, Page successor)
    {
        return predecessor == Successor && successor == Predecessor;
    }
}

public record SafetyManualUpdate(Page[] Pages)
{
    public Page MiddlePage => Pages[Pages.Length / 2];
}

public record Page(int Value);