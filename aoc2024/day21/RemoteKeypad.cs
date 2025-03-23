namespace Advent_of_Code_2024.day21;

/// <summary>
/// Helper to compute controller keypresses for a robot entering a key sequence on a remote keypad
/// </summary>
public abstract class RemoteKeypad
{
    /// <summary>
    /// Computes directional keys to press to type the given sequence on the remote keypad
    /// </summary>
    public IEnumerable<char> KeysToRemotelyType(IEnumerable<char> remoteKeys)
    {
        char previousKey = 'A';
        foreach (char nextKey in remoteKeys)
        {
            foreach (char move in MoveBetweenKeys(previousKey, nextKey))
            {
                yield return move;
            }

            previousKey = nextKey;
        }
    }

    /// <summary>
    /// Computes controller keys to press to move between two keys of the remote keypad
    /// </summary>
    public abstract IEnumerable<char> MoveBetweenKeys(char start, char end);

    public IEnumerable<RemoteKeypad> AsEnumerable()
    {
        return [this];
    }
}