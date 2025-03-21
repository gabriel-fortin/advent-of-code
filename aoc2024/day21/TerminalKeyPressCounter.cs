namespace Advent_of_Code_2024.day21;

/// when no more layers and remote key presses need to be actually counted
public class TerminalKeyPressCounter : IKeyPressCounter
{
    public decimal CountPresses(IEnumerable<char> sequence, char? startingKey = null)
    {
        return sequence.Count();
    }
}