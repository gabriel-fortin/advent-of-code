namespace Advent_of_Code_2024.day15;

public static partial class Day15
{
    private static (WarehouseObject[] warehouse, IEnumerable<Move> moves) ParseInput(string rawInput)
    {
        string[] rawWarehouseAndMovesData = rawInput.Split(Environment.NewLine + Environment.NewLine);
        WarehouseObject[] warehouseObjects = ParseWarehouse(rawWarehouseAndMovesData[0]).ToArray();
        BuildAndPopulateMatrix(warehouseObjects);

        return (
            warehouse: warehouseObjects,
            moves: ParseMoves(rawWarehouseAndMovesData[1])
        );
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

    private static IEnumerable<WarehouseObject> ParseWarehouse(string warehouseLines)
    {
        int x = 0;
        int y = 0;
        foreach (char character in warehouseLines)
        {
            if (character is '\r' or '\n')
            {
                // if it's a second such character in a row we just ignore it
                if (x == 0) continue;

                x = 0;
                y++;
                continue;
            }

            // we're not interested in empty space
            if (character is not '.')
            {
                yield return new WarehouseObject(
                    type: TileType.Parse(character),
                    positions: [new Pos(x, y)]);
            }

            x++;
        }
    }

    private static IEnumerable<Move> ParseMoves(string input)
    {
        foreach (char character in input)
        {
            // skip new line characters
            if (Move.TryParse(character, out var move))
            {
                yield return move;
            }
        }
    }
}