namespace Advent_of_Code_2024.day15;

public static partial class Day15
{
    private static (SortedSet<WarehouseObject> warehouse, IEnumerable<Move> moves) ParseInput(string rawInput)
    {
        string[] rawWarehouseAndMovesData = rawInput.Split(Environment.NewLine + Environment.NewLine);
        return (
            warehouse: new SortedSet<WarehouseObject>(ParseWarehouse(rawWarehouseAndMovesData[0])),
            moves: ParseMoves(rawWarehouseAndMovesData[1])
        );
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