namespace Advent_of_Code_2024.day05;

public static partial class Day05
{
    public static class Parsing
    {
        public static (PageOrderingRule[] orderingRules, PageSet[] updates) ParseInput(string rawInput)
        {
            string[] inputLines = rawInput.Split('\n');

            PageOrderingRule[] orderingRules = inputLines
                .TakeWhile(x => !string.IsNullOrWhiteSpace(x))
                .Select(ParsePageOrderingRule)
                .ToArray();

            PageSet[] updates = inputLines
                .SkipWhile(x => !string.IsNullOrWhiteSpace(x))
                .Skip(1)
                .Select(ParseSafetyManualUpdate)
                .ToArray();

            return (orderingRules, updates);
        }

        private static PageOrderingRule ParsePageOrderingRule(string inputLine)
        {
            Page[] pages = inputLine
                .Split('|')
                .Select(int.Parse)
                .Select(x => new Page(x))
                .ToArray();
            return new PageOrderingRule(pages[0], pages[1]);
        }

        private static PageSet ParseSafetyManualUpdate(string inputLine)
        {
            Page[] pages = inputLine
                .Split(',')
                .Select(x => new Page(int.Parse(x)))
                .ToArray();
            return new PageSet(pages);
        }
    }
}