using static Advent_of_Code_2024.day15.TileType;

namespace Advent_of_Code_2024.day15;

public static partial class Day15
{
    public static string Part1(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);
        (SortedSet<WarehouseObject> warehouse, IEnumerable<Move> moves) = ParseInput(rawInput);
        WarehouseObject robot = warehouse.Single(x => x.Type == Robot);

        foreach (Move move in moves)
        {
            var objectsToMove = new List<WarehouseObject> { robot };
            for (int i = 0; i < objectsToMove.Count; i++)
            {
                WarehouseObject obj = objectsToMove[i];
                if (!obj.CanBeMoved())
                {
                    // robot cannot push objects
                    objectsToMove.Clear();
                    break;
                }

                Pos[] positionsThatWillBeNeeded = obj.NewPositionsAfter(move).ToArray();
                int minY = positionsThatWillBeNeeded.Min(x => x.Y);
                int maxY = positionsThatWillBeNeeded.Max(x => x.Y);
                IEnumerable<WarehouseObject> objectsThatNeedToMove = warehouse
                    // use the fact that warehouse is sorted by Y
                    .SkipWhile(x => x.Positions.First().Y < minY)
                    .TakeWhile(x => x.Positions.First().Y <= maxY)
                    .Where(x => x.OccupiesAnyOf(positionsThatWillBeNeeded))
                    .ToArray();
                
                // add newly found positions to objectsToMove but making sure we're not adding duplicates
                foreach (WarehouseObject objToMove in objectsThatNeedToMove)
                {
                    if (!objectsToMove.Contains(objToMove))
                    {
                        objectsToMove.Add(objToMove);
                        // update the position of the object in the sorted set
                        warehouse.Remove(objToMove);
                        warehouse.Add(objToMove);
                    }
                }
                // objectsToMove.AddRange(objectsThatNeedToMove);
            }

            foreach (WarehouseObject obj in objectsToMove)
            {
                obj.MoveBy(move);
            }

            // Console.WriteLine($"\n  == Move: {move.X}, {move.Y}");
            // DebugPrint(warehouse);
        }

        return warehouse
            .Where(x => x.Type == Box)
            .Select(x => x.CalculateGpsCoordinate())
            .Sum()
            .ToString();
    }

    private static void DebugPrint(List<WarehouseObject> warehouse)
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