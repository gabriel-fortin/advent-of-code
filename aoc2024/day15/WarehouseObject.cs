namespace Advent_of_Code_2024.day15;

public class WarehouseObject
{
    public WarehouseObject(TileType type, Pos[] positions)
    {
        if (type == TileType.Empty)
        {
            throw new ArgumentException("We don't want to build objects for empty space");
        }

        Type = type;
        Positions = positions;
    }

    public TileType Type { get; }
    public Pos[] Positions { get; private set; }

    public bool OccupiesAnyOf(IEnumerable<Pos> positions)
    {
        return Positions.Intersect(positions).Any();
    }

    public bool CanBeMoved() => Type.CanBeMoved();

    /// <summary>
    /// Returns positions that were previously not occupied
    /// but which would be occupied after performing the given <paramref name="move"/>.
    /// </summary>
    public IEnumerable<Pos> NewPositionsAfter(Move move)
    {
        if (Type == TileType.Wall)
        {
            throw new InvalidOperationException("Cannot move walls");
        }

        return Positions
            .Select(p => p.After(move))
            .Except(Positions);
    }

    public void MoveBy(Move move)
    {
        if (!CanBeMoved())
        {
            throw new InvalidOperationException($"Cannot move {ToString()}");
        }

        Positions = Positions
            .Select(x => x.After(move))
            .ToArray();
    }

    public override string ToString()
    {
        var stringifiedPositions = string.Join(", ", Positions.Select(x => x.ToString()));
        return $"{Type} @ [{stringifiedPositions}]";
    }
}