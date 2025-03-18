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

    protected override IEnumerable<char> MoveBetweenKeys(char start, char end)
    {
        return start switch
        {
            'A' => end switch
            {
                'A' => "A",
                '^' => "<A",
                '<' => "v<<A",
                'v' => "v<A",
                '>' => "vA",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '^' => end switch
            {
                'A' => ">A",
                '^' => "A",
                '<' => "v<A",
                'v' => "vA",
                '>' => "v>A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '<' => end switch
            {
                'A' => ">>^A",
                '^' => ">^A",
                '<' => "A",
                'v' => ">A",
                '>' => ">>A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            'v' => end switch
            {
                'A' => ">^A",
                '^' => "^A",
                '<' => "<A",
                'v' => "A",
                '>' => ">A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '>' => end switch
            {
                'A' => "^A",
                '^' => "^<A",
                '<' => "<<A",
                'v' => "<A",
                '>' => "A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(start), start, null)
        };
    }
}