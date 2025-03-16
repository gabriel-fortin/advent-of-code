namespace Advent_of_Code_2024.day21;

/// <summary>
/// Helper to compute controller keypresses for a robot entering a key sequence on a remote keypad
/// </summary>
public interface IRemoteKeypad
{
    /// <summary>
    /// Computes directional keys to press to type the given sequence on the remote keypad
    /// </summary>
    IEnumerable<char> KeysToRemotelyType(IEnumerable<char> remoteKeys);
}