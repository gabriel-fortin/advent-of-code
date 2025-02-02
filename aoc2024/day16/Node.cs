namespace Advent_of_Code_2024.day16;

public class Node(Direction direction, Tile parentTile)
{
    public Direction Direction => direction;

    public Tile Tile { get; } = parentTile;

    public long Score { get; set; } = long.MaxValue;

    public Dictionary<Node, long> Edges { get; } = new();

    /// <exception cref="ArgumentException"> if connection already exists and is different </exception>
    public void ConnectTo(Node otherNode, long cost)
    {
        // sanity check: if nodes are already connected, make sure we're not trying to set the same cost
        if (Edges.TryGetValue(otherNode, out long existingCost) && existingCost == cost)
        {
            return;
        }
        // however, if the cost is different, the call to .Add will fail

        Edges.Add(otherNode, cost);
    }

    public override string ToString()
    {
        return $"Node {Tile.Position} {Direction.Name} - {Edges.Count} edges - score: {Score}";
    }

    public class ScoreComparer : IComparer<Node>
    {
        public int Compare(Node? x, Node? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (y is null) return 1;
            if (x is null) return -1;
            
            int scoreCmp = x.Score.CompareTo(y.Score);
            if (scoreCmp != 0) return scoreCmp;
            int positionCmp = x.Tile.Position.CompareTo(y.Tile.Position);
            if (positionCmp != 0) return positionCmp;
            return string.Compare(x.Direction.Name, y.Direction.Name, StringComparison.Ordinal);
        }
    }
}