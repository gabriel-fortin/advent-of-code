namespace Advent_of_Code_2024.day21;

/// <summary>
/// Helper to compute controller keypresses for a robot entering a key sequence
/// on a remote keypad of the directional type
/// </summary>
public class RemoteDirectionalKeypad : RemoteKeypad
{
    // The remote keypad looks as follows:
    //        +---+---+
    //        | ^ | A |
    //    +---+---+---+
    //    | < | v | > |
    //    +---+---+---+

    private readonly Dictionary<char, Dictionary<char, string>> _moves = new()
    {
        ['A'] = new()
        {
            ['A'] = "A",
            ['^'] = "<A",
            ['<'] = "v<<A",
            ['v'] = "v<A",
            ['>'] = "vA",
        },
        ['^'] = new()
        {
            ['A'] = ">A",
            ['^'] = "A",
            ['<'] = "v<A",
            ['v'] = "vA",
            ['>'] = "v>A",
        },
        ['<'] = new()
        {
            ['A'] = ">>^A",
            ['^'] = ">^A",
            ['<'] = "A",
            ['v'] = ">A",
            ['>'] = ">>A",
        },
        ['v'] = new()
        {
            ['A'] = ">^A",
            ['^'] = "^A",
            ['<'] = "<A",
            ['v'] = "A",
            ['>'] = ">A",
        },
        ['>'] = new()
        {
            ['A'] = "^A",
            ['^'] = "^<A",
            ['<'] = "<<A",
            ['v'] = "<A",
            ['>'] = "A",
        },
    };

    public override IEnumerable<char> MoveBetweenKeys(char start, char end)
    {
        return _moves[start][end];
    }
}