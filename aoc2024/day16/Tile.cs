using Advent_of_Code_2024.day15;

namespace Advent_of_Code_2024.day16;

public class Tile(Pos position, Tile.TileType type)
{
    private IDictionary<Direction, Node>? _nodes;
    
    public readonly TileType Type = type;

    public long Score => Nodes.Values.Min(x => x.Score);

    public Pos Position { get; } = position;

    public IDictionary<Direction, Node> Nodes
    {
        get => _nodes ?? throw new InvalidOperationException(
            $"Tile has no nodes - missing call to {nameof(CreateInternalNodes)}?");
        private set => _nodes = value;
    }

    /// <exception cref="ArgumentException"> if connection already exists </exception>
    public void ConnectTo(Tile neighbour, Direction direction)
    {
        Node node = Nodes[direction];
        Node otherNode = neighbour.Nodes[direction];

        node.ConnectTo(otherNode, cost: 1);
        // the reverse connection is set up when the other tile is processed
    }

    public void CreateInternalNodes()
    {
        Node eastNode = new Node(Direction.East, parentTile: this);
        Node southNode = new Node(Direction.South, parentTile: this);
        Node westNode = new Node(Direction.West, parentTile: this);
        Node northNode = new Node(Direction.North, parentTile: this);

        // set the clockwise connections between the nodes of this tile
        eastNode.ConnectTo(southNode, cost: 1000);
        southNode.ConnectTo(westNode, cost: 1000);
        westNode.ConnectTo(northNode, cost: 1000);
        northNode.ConnectTo(eastNode, cost: 1000);
        
        // set the anti-clockwise connections between the nodes of this tile
        eastNode.ConnectTo(northNode, cost: 1000);
        northNode.ConnectTo(westNode, cost: 1000);
        westNode.ConnectTo(southNode, cost: 1000);
        southNode.ConnectTo(eastNode, cost: 1000);

        Nodes = new Dictionary<Direction, Node>
        {
            { Direction.East, eastNode },
            { Direction.South, southNode },
            { Direction.West, westNode },
            { Direction.North, northNode },
        };
    }

    public override string ToString()
    {
        return $"Tile [{Type}] {Position} - {Nodes.Values.Sum(x => x.Edges.Count)} edges in total - score: {Score}";
    }

    public enum TileType
    {
        Wall,
        Empty,
        Start,
        End,
    }
}