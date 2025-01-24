namespace Advent_of_Code_2024.day15;

public static partial class Day15
{
    private static (Matrix<Tile> warehouse, IEnumerable<Move> moves) ParseInput(string rawInput)
    {
        string[] rawWarehouseAndMovesData = rawInput.Split(Environment.NewLine + Environment.NewLine);
        return (
            warehouse: ParseWarehouse(rawWarehouseAndMovesData[0]),
            moves: ParseMoves(rawWarehouseAndMovesData[1])
        );
    }

    private static Matrix<Tile> ParseWarehouse(string warehouseLines)
    {
        return new Matrix<Tile>(
            warehouseLines
                .Split(Environment.NewLine)
                .Select(ParseLineOfTiles)
                .ToArray());

        Tile[] ParseLineOfTiles(string characters)
        {
            return characters.Select(Tile.Parse).ToArray();
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