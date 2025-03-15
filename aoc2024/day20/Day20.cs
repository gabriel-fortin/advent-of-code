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
        // IEnumerable<Shortcut> shortcuts = FindShortcutsOfSize2(raceTrackMap, startTile);
        IEnumerable<Shortcut> shortcuts = FindShortcuts(raceTrackMap, startTile, 2);

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

        // iterate over tiles on the track
        for (Tile? previousTile = startTile, currentTile = startTile.NextOnTrack;
             currentTile is not null;
             previousTile = currentTile, currentTile = currentTile.NextOnTrack)
        {
            currentTile.DistanceFromStart = previousTile.DistanceFromStart + 1;
        }
    }

    private static IEnumerable<Shortcut> FindShortcutsOfSize2(Matrix<Tile> raceTrackMap, Tile startTile)
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

    private static IEnumerable<Shortcut> FindShortcuts(Matrix<Tile> raceTrackMap, Tile startTile,
        int maxShortcutLen)
    {
        // iterate over tiles on the track
        for (Tile? currentTile = startTile; currentTile is not null; currentTile = currentTile.NextOnTrack)
        {
            List<Pos> neighbourPositions = NeighboursOf(currentTile.Pos, withinDistance: maxShortcutLen);
            IEnumerable<Shortcut> shortcuts = neighbourPositions
                .Select(raceTrackMap.Get)
                .Where(tile => tile?.Type is Track or End)
                .Select(neighbourTile =>
                {
                    int saving = neighbourTile!.DistanceFromStart - currentTile.DistanceFromStart
                        - Distance(neighbourTile.Pos, currentTile.Pos);
                    return saving > 0
                        ? new Shortcut(saving, currentTile, neighbourTile)
                        : null;
                })
                .Where(x => x is not null);
            foreach (Shortcut shortcut in shortcuts)
            {
                yield return shortcut;
            }
        }
    }

    /// <summary>
    /// Returns all positions within the given distance from the source
    /// </summary>
    private static List<Pos> NeighboursOf(Pos source, int withinDistance)
    {
        List<Pos> neighbours = new List<Pos>(3 * withinDistance);

        int yMin = source.Y - withinDistance;
        int yMax = source.Y + withinDistance;
        for (int y = yMin; y <= yMax; y++)
        {
            int remainingDistance = withinDistance - Math.Abs(source.Y - y);
            int xMin = source.X - remainingDistance;
            int xMax = source.X + remainingDistance;
            for (int x = xMin; x <= xMax; x++)
            {
                neighbours.Add(new Pos(x, y));
            }
        }

        return neighbours;
    }

    // taxicab distance
    private static int Distance(Pos pos1, Pos pos2)
    {
        return Math.Abs(pos2.X - pos1.X) + Math.Abs(pos2.Y - pos1.Y);
    }
}