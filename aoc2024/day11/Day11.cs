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