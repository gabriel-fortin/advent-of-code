using System.Collections.Immutable;

namespace Advent_of_Code_2024.day15;

public class WarehouseObject : IComparable<WarehouseObject>, IEquatable<WarehouseObject>
{
    public TileType Type { get; }

    public ImmutableSortedSet<Pos> Positions { get; private set; }

    public Matrix<WarehouseObject?> WarehouseMatrix
    {
        get => _warehouse ?? throw new InvalidOperationException("Warehouse property is null");
        set => _warehouse = value;
    }

    private bool _wasVisited;
    private Matrix<WarehouseObject?>? _warehouse;

    public WarehouseObject(TileType type, Pos[] positions)
    {
        if (type == TileType.Empty)
        {
            throw new ArgumentException("We don't want to build objects for empty space");
        }

        Type = type;
        Positions = positions.ToImmutableSortedSet();
    }

    public void TryPush(Move move)
    {
        var objectsMovingTogether = new List<WarehouseObject>();
        CollectObjectsMovingTogether(move, objectsMovingTogether);
        try
        {
            if (objectsMovingTogether.Any(x => !x.CanBeMoved())) return;

            // remove all from warehouse
            foreach (Pos pos in objectsMovingTogether.SelectMany(x => x.Positions))
            {
                WarehouseMatrix.Set(pos, null);
            }

            // move
            foreach (WarehouseObject obj in objectsMovingTogether)
            {
                obj.MoveBy(move);
            }
            
            // re-add to warehouse
            foreach (WarehouseObject obj in objectsMovingTogether)
            {
                foreach (Pos pos in obj.Positions)
                {
                    WarehouseMatrix.Set(pos, obj);
                }
            }
        }
        finally
        {
            // clear flag set by CollectObjectsMovingTogether
            foreach (WarehouseObject obj in objectsMovingTogether)
            {
                obj._wasVisited = false;
            }
        }
    }

    private void CollectObjectsMovingTogether(Move move, List<WarehouseObject> result)
    {
        if (_wasVisited) return;
        _wasVisited = true;

        result.Add(this);

        IEnumerable<WarehouseObject> objectsToVisit = Positions
            .Select(x => x.After(move))
            .Select(x => WarehouseMatrix.Get(x))
            .Where(x => x != null)!;
        // we're not worried about visiting duplicates because of _wasVisited flag
        foreach (WarehouseObject obj in objectsToVisit)
        {
            obj.CollectObjectsMovingTogether(move, result);
        }
    }

    public bool CanBeMoved() => Type.CanBeMoved();

    public void MoveBy(Move move)
    {
        if (!CanBeMoved())
        {
            throw new InvalidOperationException($"Cannot move {ToString()}");
        }

        Positions = Positions
            .Select(x => x.After(move))
            .ToImmutableSortedSet();
    }

    // GPS = Goods Positioning System
    public int CalculateGpsCoordinate()
    {
        var minX = Positions.Min(p => p.X);
        var minY = Positions.Min(p => p.Y);
        return minY * 100 + minX;
    }

    public override string ToString()
    {
        var stringifiedPositions = string.Join(", ", Positions.Select(x => x.ToString()));
        return $"{Type} @ [{stringifiedPositions}]";
    }

    public int CompareTo(WarehouseObject other)
    {
        var byY = Positions.First().Y.CompareTo(other.Positions.First().Y);
        if (byY != 0) return byY;
        return Positions.First().X.CompareTo(other.Positions.First().X);
    }

    public bool Equals(WarehouseObject other)
    {
        return Type.Equals(other.Type) && Positions.Equals(other.Positions);
    }

    public override bool Equals(object? obj)
    {
        return obj is WarehouseObject other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Type, Positions);
    }
}