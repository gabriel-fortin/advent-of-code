using static Advent_of_Code_2024.day15.TileType;

namespace Advent_of_Code_2024.day15;

public static partial class Day15
{
    public static string Part1(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);
        (WarehouseObject[] warehouse, IEnumerable<Move> moves) = ParseInput(rawInput);
        WarehouseObject robot = warehouse.Single(x => x.Type == Robot);

        foreach (Move move in moves)
        {
            robot.TryPush(move);

            // Console.WriteLine($"\n  == Move: {move.X}, {move.Y}");
            // DebugPrint(warehouse);
        }

        return warehouse
            .Where(x => x.Type == Box)
            .Select(x => x.CalculateGpsCoordinate())
            .Sum()
            .ToString();
    }

    private static void DebugPrint(WarehouseObject[] warehouse)
    {
        int xSize = 1 + warehouse.Max(x => x.Positions.Max(y => y.X));
        int ySize = 1 + warehouse.Max(x => x.Positions.Max(y => y.Y));

        char[][] warehouseMap = new char[ySize][];
        for (int i = 0; i < ySize; i++)
        {
            warehouseMap[i] = new char[xSize];
            Array.Fill(warehouseMap[i], '.');
        }

        foreach (WarehouseObject obj in warehouse)
        {
            foreach (var (x, y) in obj.Positions)
            {
                warehouseMap[y][x] = obj.Type.Character;
            }
        }

        foreach (char[] line in warehouseMap)
        {
            Console.WriteLine(line);
        }
    }
}