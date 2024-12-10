namespace Advent_of_Code_2024.day05;

public static partial class Day05
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        (PageOrderingRule[] orderingRules, PageSet[] pageSets) = Parsing.ParseInput(rawInput);

        return pageSets
            .Where(x => IsUpdateRightlyOrdered(orderingRules, x))
            .Select(x => x.MiddlePage.Value)
            .Sum()
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        (PageOrderingRule[] orderingRules, PageSet[] pageSets) = Parsing.ParseInput(rawInput);


        return pageSets
            .Where(pageSet => !IsUpdateRightlyOrdered(orderingRules, pageSet))
            .Select(pageSet => TopologicalSort(pageSet.Pages, orderingRules))
            .Select(x => x.MiddlePage.Value)
            .Sum()
            .ToString();
    }

    private static PageSet TopologicalSort(Page[] pages, PageOrderingRule[] orderingRules)
    {
        List<Page> sortedPages = new List<Page>(pages.Length);

        // rules that are not discarded
        // first we remove rules for pages we don't have
        List<PageOrderingRule> rules = orderingRules
            .Where(rule => rule.IsUsedBy(pages))
            .ToList();
        // later, we'll remove rules for pages which we have already handled

        // pages such that no rule may require them to appear later
        List<Page> almostTherePages = AlmostTherePages(rules);

        while (almostTherePages.Any())
        {
            var page = almostTherePages.First();
            sortedPages.Add(page);

            // remove rules that have page as predecessor, they are not needed anymore
            rules = rules
                .Where(rule => rule.Predecessor != page)
                .ToList();

            almostTherePages = AlmostTherePages(rules);
        }

        if (rules.Any())
        {
            throw new ArgumentException("The graph has cycles.");
        }

        return new PageSet(sortedPages.ToArray());

        List<Page> AlmostTherePages(List<PageOrderingRule> pageOrderingRules)
        {
            return pages
                .Where(page => pageOrderingRules.All(rule => rule.Successor != page))
                .Except(sortedPages)
                .ToList();
        }
    }

    private static bool IsUpdateRightlyOrdered(PageOrderingRule[] orderingRules, PageSet update)
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

    public bool IsUsedBy(Page[] pages)
    {
        return pages.Any(page => page == Predecessor)
            && pages.Any(page => page == Successor);
    }

    public override string ToString()
    {
        return $"{Predecessor} -> {Successor}";
    }
}

public record PageSet(Page[] Pages)
{
    public Page MiddlePage => Pages[Pages.Length / 2];
}

public record Page(int Value)
{
    public override string ToString()
    {
        return $"Page {Value}";
    }
}