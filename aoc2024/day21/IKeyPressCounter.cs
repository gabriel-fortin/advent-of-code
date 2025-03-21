namespace Advent_of_Code_2024.day21;

public interface IKeyPressCounter
{
    /// <summary>
    /// Counts the number of presses needed to achieve the desired key sequence
    /// </summary>
    /// <param name="sequence">sequence of characters the remote presses should obtain</param>
    /// <returns>number of presses needed to achieve the required sequence</returns>
    decimal CountPresses(IEnumerable<char> sequence, char? startingKey = null);
}