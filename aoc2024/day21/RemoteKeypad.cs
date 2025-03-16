namespace Advent_of_Code_2024.day21;

/// <summary>
/// Helper to compute controller keypresses for a robot entering a key sequence on a remote keypad
/// </summary>
public abstract class RemoteKeypad(bool debugPrintKeys = false)
{
    /// <summary>
    /// Computes directional keys to press to type the given sequence on the remote keypad
    /// </summary>
    public IEnumerable<char> KeysToRemotelyType(IEnumerable<char> remoteKeys)
    {
        List<IEnumerable<char>> result = new List<IEnumerable<char>>();

        char previousKey = 'A';
        foreach (char nextKey in remoteKeys)
        {
            result.Add(MoveBetweenKeys(previousKey, nextKey));
            previousKey = nextKey;
        }

        IEnumerable<char> keysSequence = result.SelectMany(x => x);
        if (debugPrintKeys)
        {
            keysSequence = keysSequence.ToArray();
            Console.WriteLine(new string((char[])keysSequence));
        }

        return keysSequence;
    }

    /// <summary>
    /// Computes controller keys to press to move between two keys of the remote keypad
    /// </summary>
    protected abstract IEnumerable<char> MoveBetweenKeys(char start, char end);
}