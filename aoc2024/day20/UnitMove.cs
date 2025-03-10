using System.Diagnostics;
using Advent_of_Code_2024.day15;

namespace Advent_of_Code_2024.day20;

[DebuggerDisplay($"{nameof(UnitMove)}: ({{X}}, {{Y}})")]
public class UnitMove : Move
{
    private UnitMove(int x, int y) : base(x, y)
    {
    }

    public static UnitMove operator *(int scalar, UnitMove unitMove) =>
        new UnitMove(scalar * unitMove.X, scalar * unitMove.Y);

    public static readonly UnitMove[] All =
    [
        new UnitMove(1, 0),
        new UnitMove(0, 1),
        new UnitMove(-1, 0),
        new UnitMove(0, -1)
    ];
}