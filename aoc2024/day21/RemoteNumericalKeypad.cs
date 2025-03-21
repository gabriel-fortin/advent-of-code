namespace Advent_of_Code_2024.day21;

/// <summary>
/// Helper to compute controller keypresses for a robot entering a key sequence
/// on a remote keypad of the numerical type
/// </summary>
public class RemoteNumericalKeypad : RemoteKeypad
{
    // The remote keypad looks as follows:
    //    +---+---+---+
    //    | 7 | 8 | 9 |
    //    +---+---+---+
    //    | 4 | 5 | 6 |
    //    +---+---+---+
    //    | 1 | 2 | 3 |
    //    +---+---+---+
    //        | 0 | A |
    //        +---+---+

    public override IEnumerable<char> MoveBetweenKeys(char start, char end)
    {
        return start switch
        {
            'A' => end switch
            {
                'A' => "A",
                '0' => "<A",
                '1' => "^<<A",
                '2' => "^<A",
                '3' => "^A",
                '4' => "^^<<A",
                '5' => "^^<A",
                '6' => "^^A",
                '7' => "^^^<<A",
                '8' => "^^^<A",
                '9' => "^^^A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '0' => end switch
            {
                'A' => ">A",
                '0' => "A",
                '1' => "^<A",
                '2' => "^A",
                '3' => "^>A",
                '4' => "^^<A",
                '5' => "^^A",
                '6' => "^^>A",
                '7' => "^^^<A",
                '8' => "^^^A",
                '9' => "^^^>A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '1' => end switch
            {
                'A' => ">>vA",
                '0' => ">vA",
                '1' => "A",
                '2' => ">A",
                '3' => ">>A",
                '4' => "^A",
                '5' => "^>A",
                '6' => "^>>A",
                '7' => "^^A",
                '8' => "^^>A",
                '9' => "^^>>A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '2' => end switch
            {
                'A' => ">vA",
                '0' => "vA",
                '1' => "<A",
                '2' => "A",
                '3' => ">A",
                '4' => "<^A",
                '5' => "^A",
                '6' => "^>A",
                '7' => "^^<A",
                '8' => "^^A",
                '9' => "^^>A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '3' => end switch
            {
                'A' => "vA",
                '0' => "<vA",
                '1' => "<<A",
                '2' => "<A",
                '3' => "A",
                '4' => "<<^A",
                '5' => "<^A",
                '6' => "^A",
                '7' => "<<^^A",
                '8' => "<^^A",
                '9' => "^^A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '4' => end switch
            {
                'A' => ">>vvA",
                '0' => ">vvA",
                '1' => "vA",
                '2' => "v>A",
                '3' => "v>>A",
                '4' => "A",
                '5' => ">A",
                '6' => ">>A",
                '7' => "^A",
                '8' => "^>A",
                '9' => "^>>A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '5' => end switch
            {
                'A' => "vv>A",
                '0' => "vvA",
                '1' => "v<A",
                '2' => "vA",
                '3' => "v>A",
                '4' => "<A",
                '5' => "A",
                '6' => ">A",
                '7' => "^<A",
                '8' => "^A",
                '9' => "^>A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '6' => end switch
            {
                'A' => "vvA",
                '0' => "<vvA",
                '1' => "<<vA",
                '2' => "<vA",
                '3' => "vA",
                '4' => "<<A",
                '5' => "<A",
                '6' => "A",
                '7' => "<<^A",
                '8' => "<^A",
                '9' => "^A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '7' => end switch
            {
                'A' => ">>vvvA",
                '0' => ">vvvA",
                '1' => "vvA",
                '2' => "vv>A",
                '3' => "vv>>A",
                '4' => "vA",
                '5' => "v>A",
                '6' => "v>>A",
                '7' => "A",
                '8' => ">A",
                '9' => ">>A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '8' => end switch
            {
                'A' => ">vvvA",
                '0' => "vvvA",
                '1' => "vv<A",
                '2' => "vvA",
                '3' => "vv>A",
                '4' => "v<A",
                '5' => "vA",
                '6' => "v>A",
                '7' => "<A",
                '8' => "A",
                '9' => ">A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            '9' => end switch
            {
                'A' => "vvvA",
                '0' => "<vvvA",
                '1' => "<<vvA",
                '2' => "<vvA",
                '3' => "vvA",
                '4' => "<<vA",
                '5' => "<vA",
                '6' => "vA",
                '7' => "<<A",
                '8' => "<A",
                '9' => "A",
                _ => throw new ArgumentOutOfRangeException(nameof(end), end, null)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(start), start, null)
        };
    }
}