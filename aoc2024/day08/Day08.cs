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
        return "NOT IMPLEMENTED";
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
}