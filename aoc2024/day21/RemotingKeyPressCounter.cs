namespace Advent_of_Code_2024.day21;

/// when uses a remote to call to the next layer robot
public class RemotingKeyPressCounter(RemoteKeypad remoteKeypad, IKeyPressCounter nextLayer) : IKeyPressCounter
{
    public decimal CountPresses(IEnumerable<char> sequence, char? startingKey = null)
    {
        decimal result = 0M;
        char previousKey = startingKey ?? 'A';
        foreach (char currentKey in sequence)
        {
            IEnumerable<char> remoteKeys = remoteKeypad.MoveBetweenKeys(previousKey, currentKey);
            result += nextLayer.CountPresses(remoteKeys);
            previousKey = currentKey;
        }

        return result;
    }
}