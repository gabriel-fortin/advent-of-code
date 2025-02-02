using Advent_of_Code_2024.day15;
using static Advent_of_Code_2024.day16.Tile.TileType;

namespace Advent_of_Code_2024.day16;

public static partial class Day16
{
    private static class Parsing
    {
        public static (Tile[] tiles, Matrix<Tile?> matrix) Parse(string rawInput)
        {
            Tile[] tiles = ParseNonWallTiles(rawInput).ToArray();
            Matrix<Tile?> matrix = BuildMatrix(tiles);
            return (tiles, matrix);
        }

        private static IEnumerable<Tile> ParseNonWallTiles(string rawInput)
        {
            int x = 0;
            int y = 0;
            foreach (char character in rawInput)
            {
                if (character is '\r' or '\n')
                {
                    // if it's a second such character in a row we just ignore it
                    if (x == 0) continue;

                    x = 0;
                    y++;
                    continue;
                }

                Tile.TileType tileType = ParseTileType(character);
                if (tileType is Empty or Start or End)
                {
                    var tile = new Tile(new Pos(x, y), tileType);
                    tile.CreateInternalNodes();
                    yield return tile;
                }

                x++;
            }
        }

        private static Tile.TileType ParseTileType(char character)
        {
            return character switch
            {
                '#' => Wall,
                '.' => Empty,
                'S' => Start,
                'E' => End,
                _ => throw new ArgumentException($"Unrecognised character: {character}")
            };
        }

        private static Matrix<Tile?> BuildMatrix(Tile[] tiles)
        {
            int ySize = 1 + tiles.Max(tile => tile.Position.Y);
            int xSize = 1 + tiles.Max(tile => tile.Position.X);

            Tile?[][] tileArrays = new Tile[ySize][];
            for (int row = 0; row < ySize; row++)
            {
                tileArrays[row] = new Tile[xSize];
            }

            var matrix = new Matrix<Tile?>(tileArrays);

            foreach (Tile tile in tiles)
            {
                matrix.Set(tile.Position, tile);
            }

            return matrix;
        }
    }
}