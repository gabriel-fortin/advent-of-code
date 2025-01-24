using System.Text;
using static Advent_of_Code_2024.day15.Tile;

namespace Advent_of_Code_2024.day15;

public static partial class Day15
{
    public static string Part1(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);
        (Matrix<Tile> warehouse, IEnumerable<Move> moves) = ParseInput(rawInput);

        Pos robotPos = warehouse.FindPositionOfFirst(tile => tile == Robot)
            ?? throw new Exception("Robot not found");
        
        foreach (Move move in moves)
        {
            // walk from the robot in the move's direction until Wall or Empty space is found
            Pos p = robotPos;
            while (warehouse.Get(p)!.IsOneOf(Robot, Box))
            {
                p = p.After(move);
            }
            
            // if Empty space was found, shuffle all boxes in that direction
            if (warehouse.Get(p)! == Empty)
            {
                // the found Empty tile becomes a Box tile
                warehouse.Set(p, Box);
                // the Robot tile becomes an Empty tile
                warehouse.Set(robotPos, Empty);
                // the tile next to the robot becomes the Robot
                robotPos = robotPos.After(move);
                warehouse.Set(robotPos, Robot);
            }
            
            // Console.WriteLine($"\n  == Move: {move.X}, {move.Y}");
            // DebugPrint(warehouse);
        }
        
        // Console.WriteLine("\n  RESULT:");
        // DebugPrint(warehouse);

        return warehouse.AllPositions()
            .Where(x => x.element == Box)
            .Select(x => CalculateGpsCoordinate(x.position))
            .Sum()
            .ToString();
    }
    
    // GPS = Goods Positioning System
    private static int CalculateGpsCoordinate(Pos pos)
    {
        return pos.Y * 100 + pos.X;
    }

    private static void DebugPrint(Matrix<Tile> warehouse)
    {
        StringBuilder sb = new();
        Pos? lastPos = null;
        foreach (var (position, element) in warehouse.AllPositions())
        {
            if (position.X < lastPos?.X)
            {
                sb.Append(Environment.NewLine);
            }

            sb.Append(element.Character);
            
            lastPos = position;
        }
        Console.WriteLine(sb.ToString());
    }
}