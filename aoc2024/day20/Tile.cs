using System.Diagnostics;
using Advent_of_Code_2024.day15;

namespace Advent_of_Code_2024.day20;

[DebuggerDisplay("{Type} {Pos}")]
public class Tile(TileType type)
{
    private int _distanceFromStart = int.MaxValue;
    private bool _isDistanceSet;

    public int DistanceFromStart
    {
        get => _isDistanceSet ? _distanceFromStart : throw new InvalidOperationException("Distance not set");
        set
        {
            _distanceFromStart = value;
            _isDistanceSet = true;
        }
    }

    public TileType Type => type;

    public Pos Pos { get; set; }

    /// <summary> Next tile on the track </summary>
    public Tile? NextOnTrack { get; set; }

    public static Tile Create(TileType type) => new(type);
}