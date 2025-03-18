namespace Advent_of_Code_2024.day21;

public class ComposedRemoteKeypad(IEnumerable<IRemoteKeypad> remoteKeypads) : IRemoteKeypad
{
    public ComposedRemoteKeypad(params IRemoteKeypad[] remoteKeypads):this(remoteKeypads.AsEnumerable())
    {
    }

    public IEnumerable<char> KeysToRemotelyType(IEnumerable<char> remoteKeys)
    {
        return remoteKeypads
            .Aggregate(remoteKeys, (currentKeys, keypad) => keypad.KeysToRemotelyType(currentKeys));
    }
}