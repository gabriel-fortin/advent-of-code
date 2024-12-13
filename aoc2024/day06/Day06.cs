using Advent_of_Code_2024.day04;

namespace Advent_of_Code_2024.day06;

public static partial class Day06
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        
        var labMap = new Matrix(rawInput.Split('\n'));
        // starting position
        Pos? pos = labMap.AllPositions().First(x => x.letter == '^').position;
        var directions = new Directions();

        // a set doesn't contain duplicates, that will allow to count visited positions properly
        // 'Pos' being a record ensures two different Pos objects are seen as the same if the data they hold match
        var visitedPositions = new HashSet<Pos>();
        
        // when the guard leaves the lab, we'll get a null position
        while (labMap.Get(pos) != null)
        {
            visitedPositions.Add(pos);
            Pos? nextPos = pos.MoveBy(directions.StepInCurrentDirection);
            while (labMap.Get(nextPos) == '#')
            {
                directions.RotateRight();
                nextPos = pos.MoveBy(directions.StepInCurrentDirection);
            }

            pos = nextPos;
        }
        
        return visitedPositions.Count.ToString();
    }

    public static string Part2(bool useExampleData)
    {
        return "NOT IMPLEMENTED";
    }

    public class Directions
    {
        private Move[] moves = new[]
            {
                (-1, 0),
                (0, 1),
                (1, 0),
                (0, -1),
            }
            .Select(x => new Move(x))
            .ToArray();

        private int index = 0;

        public Move StepInCurrentDirection => moves[index];

        public void RotateRight()
        {
            index = (index + 1) % moves.Length;
        }
    }
}