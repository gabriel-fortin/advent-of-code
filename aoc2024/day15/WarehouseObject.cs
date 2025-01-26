using System.Collections.Immutable;

namespace Advent_of_Code_2024.day15;

public struct WarehouseObject : IComparable<WarehouseObject>, IEquatable<WarehouseObject>
{
    public WarehouseObject(TileType type, Pos[] positions)
    {
        if (type == TileType.Empty)
        {
            throw new ArgumentException("We don't want to build objects for empty space");
        }

        Type = type;
        Positions = positions.ToImmutableSortedSet();
    }

    public TileType Type { get; }
    public ImmutableSortedSet<Pos> Positions { get; private set; }

    public bool OccupiesAnyOf(IEnumerable<Pos> positions)
    {
        foreach (Pos otherPosition in positions)
        {
            if (Positions.Contains(otherPosition)) return true;
        }
        return false;
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