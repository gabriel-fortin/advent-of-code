using Advent_of_Code_2024.day04;

namespace Advent_of_Code_2024.day06;

public class AvoidingTheGuard
{
    private const char Obstacle = '#';
    private const char StartingMarker = '^';
    
    // a set doesn't contain duplicates, that will allow to count visited positions properly
    // 'Pos' being a record ensures two different Pos objects are seen as the same if the data they hold match
    private readonly Dictionary<Pos, List<Move>> _visitedPositions = new();

    public bool HasGuardBeenLooped { get; private set; }

    public IEnumerable<Pos> VisitedPositions => _visitedPositions.Keys;
    
    public AvoidingTheGuard(Matrix labMap)
    {
        try
        {
            Pos? pos = labMap.AllPositions()
                .First(x => x.letter == StartingMarker)
                .position;
            var directions = new Directions();

            // when the guard leaves the lab, we'll get a null position
            while (labMap.Get(pos) != null)
            {
                SaveVisitedPosition(pos, directions.CurrentDirection);
                Pos? nextPos = pos.MoveBy(directions.CurrentDirection);
                while (labMap.Get(nextPos) == Obstacle)
                {
                    directions.RotateRight();
                    nextPos = pos.MoveBy(directions.CurrentDirection);
                }

                pos = nextPos;
            }
        }
        catch(LoopedGuardException)
        {
            HasGuardBeenLooped = true;
        }
    }

    private void SaveVisitedPosition(Pos pos, Move direction)
    {
        _visitedPositions.TryAdd(pos, new List<Move>(4));
        if (_visitedPositions[pos].Contains(direction))
        {
            throw new LoopedGuardException();
        }
        _visitedPositions[pos].Add(direction);
    }

    private class LoopedGuardException : Exception
    {
    }
}