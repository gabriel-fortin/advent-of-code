using Advent_of_Code_2024.day15;

namespace Advent_of_Code_2024.day20;

public static partial class Day20
{
    public static class Parsing
    {
        public static Matrix<Tile> ParseRaceTrackMap(string rawInput)
        {
            Tile[][] raceTrackMapData = rawInput
                .Split(Environment.NewLine)
                .Select(ParseLineIntoTiles)
                .ToArray();
            return new Matrix<Tile>(raceTrackMapData);
        }

        private static Tile[] ParseLineIntoTiles(string line)
        {
            return line
                .Select(ParseTileType)
                .Select(Tile.Create)
                .ToArray();
        }

        private static TileType ParseTileType(char c)
        {
            return c switch
            {
                '#' => TileType.Wall,
                '.' => TileType.Track,
                'S' => TileType.Start,
                'E' => TileType.End,
                _ => throw new ArgumentOutOfRangeException(nameof(c), c, "Unknown tile type")
            };
        }
    }
}