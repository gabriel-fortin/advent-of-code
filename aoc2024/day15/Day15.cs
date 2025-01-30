using static Advent_of_Code_2024.day15.TileType;

namespace Advent_of_Code_2024.day15;

public static partial class Day15
{
    public static string Part1(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);
        (WarehouseObject[] warehouse, IEnumerable<Move> moves) = ParseInput(rawInput);

        BuildAndPopulateMatrix(warehouse);
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

    public static string Part2(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);
        (WarehouseObject[] warehouse, IEnumerable<Move> moves) = ParseInput(rawInput);

        // part 2 makes the warehouse twice as large
        warehouse = warehouse.Select(DoubleTheWidth).ToArray();

        BuildAndPopulateMatrix(warehouse);
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

    private static WarehouseObject DoubleTheWidth(WarehouseObject obj)
    {
        if (obj.Positions.Count == 1 && (obj.Type == Wall || obj.Type == Box))
        {
            (int x, int y) = obj.Positions[0];
            return new WarehouseObject(obj.Type, [
                new Pos(2 * x, y), new Pos(2 * x + 1, y)
            ]);
        }

        if (obj.Positions.Count == 1 && obj.Type == Robot)
        {
            (int x, int y) = obj.Positions[0];
            return new WarehouseObject(Robot, [new Pos(2 * x, y)]);
        }
        
        throw new ArgumentOutOfRangeException($"Unknown object: {obj.Type} ({obj.Positions.Count})");
    }

    private static void BuildAndPopulateMatrix(WarehouseObject[] warehouseObjects)
    {
        int ySize = 1 + warehouseObjects.Max(obj => obj.Positions.Max(pos => pos.Y));
        int xSize = 1 + warehouseObjects.Max(obj => obj.Positions.Max(pos => pos.X));

        WarehouseObject?[][] warehouseArrays = new WarehouseObject[ySize][];
        for (int row = 0; row < ySize; row++)
        {
            warehouseArrays[row] = new WarehouseObject[xSize];
        }

        var warehouseMatrix = new Matrix<WarehouseObject?>(warehouseArrays);

        foreach (WarehouseObject obj in warehouseObjects)
        {
            obj.WarehouseMatrix = warehouseMatrix;
            foreach (Pos objPosition in obj.Positions)
            {
                warehouseMatrix.Set(objPosition, obj);
            }
        }
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