namespace Advent_of_Code_2024.day15;

public class Tile
{
    // we use the flyweight design pattern in this class

    public char Character { get; set; }
    
    private Tile(char character)
    {
        Character = character;
    }

    public bool IsOneOf(params Tile[] tiles)
    {
        return tiles.Any(tile => tile == this);
    }

    public static Tile Parse(char character)
    {
        return character switch
        {
            '#' => Wall,
            'O' => Box,
            '.' => Empty,
            '@' => Robot,
            _ => throw new ArgumentException($"Unknown character: {character}")
        };
    }

    public static readonly Tile Wall = new('#');
    public static readonly Tile Box = new('O');
    public static readonly Tile Empty = new('.');
    public static readonly Tile Robot = new('@');
}