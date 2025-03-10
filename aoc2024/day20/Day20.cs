using Advent_of_Code_2024.day15;
using static Advent_of_Code_2024.day20.TileType;

namespace Advent_of_Code_2024.day20;

public static partial class Day20
{
    public static string Part1(InputSelector inputSelector)
    {
        int qualityThreshold = inputSelector switch
        {
            InputSelector.MyInput => 100,
            InputSelector.Example1 => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(inputSelector), inputSelector, null)
        };
        string rawInput = Input.GetInput(inputSelector);
        Matrix<Tile> raceTrackMap = Parsing
            .ParseRaceTrackMap(rawInput)
            .ForEach((pos, tile) => tile.Pos = pos);

        Tile startTile = FindStartTile(raceTrackMap);
        LinkTrackTiles(raceTrackMap, startTile);
        ComputeDistancesOnTrack(startTile);
        IEnumerable<Shortcut> shortcuts = FindAllShortcutSavings(raceTrackMap, startTile);

        return shortcuts
            .Order(new Shortcut.HavingHighestSaving())
            .TakeWhile(s => s.Saving >= qualityThreshold)
            .Count()
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static Tile FindStartTile(Matrix<Tile> raceTrackMap)
    {
        Pos startPos = raceTrackMap.FindPositionOfFirst(x => x.Type == Start)
            ?? throw new Exception("Start position not found");

        return raceTrackMap.Get(startPos)!;
    }

    private static void LinkTrackTiles(Matrix<Tile> raceTrackMap, Tile startTile)
    {
        for (Tile currentTile = startTile; currentTile.Type != End;)
        {
            // find the single neighbour tile that is the next tile on the track
            Tile nextTile = UnitMove.All
                .Select(unitMove => currentTile.Pos.After(unitMove))
                .Select(raceTrackMap.Get)
                .Single(tile => tile is { Type: Track or End, NextOnTrack: null })!;

            currentTile.NextOnTrack = nextTile;

            currentTile = nextTile;
        }
    }

    private static void ComputeDistancesOnTrack(Tile startTile)
    {
        startTile.DistanceFromStart = 0;

        for (Tile currentTile = startTile; currentTile.Type != End;)
        {
            Tile? nextTile = currentTile.NextOnTrack;
            if (nextTile == null) break;

            nextTile.DistanceFromStart = currentTile.DistanceFromStart + 1;

            currentTile = nextTile;
        }
    }

    private static IEnumerable<Shortcut> FindAllShortcutSavings(Matrix<Tile> raceTrackMap, Tile startTile)
    {
        for (Tile? currentTile = startTile; currentTile is not null; currentTile = currentTile.NextOnTrack)
        {
            foreach (UnitMove unitMove in UnitMove.All)
            {
                Tile? neighbour = raceTrackMap.Get(currentTile.Pos.After(unitMove));
                Tile? neighbour2 = raceTrackMap.Get(currentTile.Pos.After(2 * unitMove));

                if (neighbour?.Type is not Wall) continue;
                if (neighbour2?.Type is not (Track or End)) continue;

                var saving = neighbour2.DistanceFromStart - currentTile.DistanceFromStart - 2;
                if (saving > 0)
                {
                    yield return new Shortcut(saving, currentTile, neighbour2);
                }
            }
        }
    }
}