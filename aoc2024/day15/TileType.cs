namespace Advent_of_Code_2024.day15;

public record TileType
{
    // we use the flyweight design pattern in this class

    public char Character { get; set; }

    private readonly string _name;
    
    private TileType(char character, string name)
    {
        Character = character;
        _name = name;
    }

    public bool CanBeMoved() => this != Wall && this != Empty;

    public static TileType Parse(char character)
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

    public override string ToString() => $"|{_name}|";

    public static readonly TileType Wall = new('#', "Wall");

    public static readonly TileType Box = new('O', "Box");

    public static readonly TileType Empty = new('.', "Empty");

    public static readonly TileType Robot = new('@', "Robot");
}