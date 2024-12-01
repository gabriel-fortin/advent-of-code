namespace Advent_of_Code_2024.day01;

public partial class Day01
{
    public string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var (list1, list2) = ParseLocationLists(rawInput);

        list1.Sort();
        list2.Sort();

        int distanceSum = 0;
        for (int i = 0; i < list1.Count; i++)
        {
            int distance = Math.Abs(list1[i] - list2[i]);
            distanceSum += distance;
        }

        return distanceSum.ToString();
    }

    private (List<int> list1, List<int> list2) ParseLocationLists(string rawInput)
    {
        List<int> list1 = new();
        List<int> list2 = new();

        string[] rawLines = rawInput.Split('\n');
        foreach (var rawLine in rawLines)
        {
            string[] rawNumbers = rawLine.Split("   ");
            list1.Add(int.Parse(rawNumbers[0]));
            list2.Add(int.Parse(rawNumbers[1]));
        }

        return (list1, list2);
    }

    public string Part1UsingLotsOfLinqAndChaining()
    {
        string rawInput = Input.GetInput(useExampleData: false);
        var (list1, list2) = ParseLocationListsUsingLotsOfLinqAndChaining(rawInput);

        list1.Sort();
        list2.Sort();

        // get corresponding numbers together
        return list1.Zip(list2, (x, y) => (int[]) [x, y]) // IEnumerable<int[]>
            // calculate difference
            .Select(x => x[0] - x[1]) // IEnumerable<int>
            // calculate absolute value of the difference
            .Select(Math.Abs) // IEnumerable<int>
            // sum all the differences
            .Sum() // int
            .ToString();
    }

    private (List<int> list1, List<int> list2) ParseLocationListsUsingLotsOfLinqAndChaining(string rawInput)
    {
        int[][] numberPairs = rawInput
            .Split('\n')
            // split each line into an array of numbers
            .Select(line => line
                .Split("   ") // IEnumerable<string>
                .Select(int.Parse) // IEnumerable<int>
                .ToArray()) // int[]
            .ToArray();

        return (
            list1: numberPairs.Select(x => x[0]).ToList(),
            list2: numberPairs.Select(x => x[1]).ToList());
    }

    public string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var (list1, list2) = ParseLocationLists(rawInput);

        return list1
            .Select(x => SimilarityScore(x, list2))
            .Sum()
            .ToString();
    }

    private int SimilarityScore(int number, List<int> list2)
    {
        int occurrencesOnList2 = list2.Count(x => x == number);
        return number * occurrencesOnList2;
    }
}