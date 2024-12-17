using Advent_of_Code_2024.day04;

namespace Advent_of_Code_2024.day08;

public static partial class Day08
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var city = new Matrix(rawInput.Split("\r\n"));

        return city.AllPositions()
            .Where(x => char.IsDigit(x.letter) || char.IsLetter(x.letter))
            // group by frequency
            .GroupBy(x => x.letter)
            // for each frequency: all antennas of this frequency
            .Select(x => x.Select(y => y.position).ToList())
            // for each frequency: all pairs of antennas; flatten the result
            .SelectMany(ComputeAllPermutations)
            // for each pair of antennas: all antinodes; flatten the result
            .SelectMany(ComputeAntiNodes)
            // remove duplicate antinodes
            .Distinct()
            // count antinodes within the city
            .Count(antiNode => city.Get(antiNode) != null)
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var city = new Matrix(rawInput.Split("\r\n"));

        return city.AllPositions()
            .Where(x => char.IsDigit(x.letter) || char.IsLetter(x.letter))
            .GroupBy(x => x.letter)
            .Select(x => x.Select(y => y.position).ToList())
            .SelectMany(ComputeAllPermutations)
            // generate all nodes lying on a line created by each pair of antennas
            .SelectMany(antennaePair =>
            {
                (Pos pos1, Pos pos2) = antennaePair;
                
                // infinite sequence of antinodes in one direction
                IEnumerable<Pos> antiNodes1 = ComputeAntiNodesDirectionally(pos1, pos2)
                    // but take them for only as long as they are within city's borders
                    .TakeWhile(pos => city.Get(pos) != null);
                
                // infinite sequence of antennas in the other direction
                IEnumerable<Pos> antiNodes2 = ComputeAntiNodesDirectionally(pos2, pos1)
                    // again, stop taking them when they get outside the city
                    .TakeWhile(pos => city.Get(pos) != null);
                
                return antiNodes1.Concat(antiNodes2);
            })
            .Distinct()
            .Count(antiNode => city.Get(antiNode) != null)
            .ToString();
    }

    private static IEnumerable<(Pos, Pos)> ComputeAllPermutations(List<Pos> positions)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            for (int j = i + 1; j < positions.Count; j++)
            {
                (Pos, Pos) nextPair = (positions[i], positions[j]);
                yield return nextPair;
            }
        }
    }

    private static IEnumerable<Pos> ComputeAntiNodes((Pos, Pos) positionPair)
    {
        var (pos1, pos2) = positionPair;
        yield return pos2.MoveBy(new Move(pos2.X - pos1.X, pos2.Y - pos1.Y));
        yield return pos1.MoveBy(new Move(pos1.X - pos2.X, pos1.Y - pos2.Y));
    }

    /// Computes an infinite sequence of antinodes in a certain direction
    private static IEnumerable<Pos> ComputeAntiNodesDirectionally(Pos pos1, Pos pos2)
    {
        var vector = new Move(pos2.X - pos1.X, pos2.Y - pos1.Y);

        Pos pos = pos2;
        while (true)
        {
            yield return pos;
            pos = pos.MoveBy(vector);
        }
        // ReSharper disable once IteratorNeverReturns
    }
}