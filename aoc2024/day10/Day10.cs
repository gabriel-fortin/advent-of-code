using System.Text;
using Advent_of_Code_2024.day04;

namespace Advent_of_Code_2024.day10;

public static partial class Day10
{
    private static readonly Move[] NeighbourMoves =
    [
        new Move(-1, 0),
        new Move(1, 0),
        new Move(0, -1),
        new Move(0, 1),
    ];

    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        Matrix<DataPoint> matrix = ParseTopographicMap(rawInput);

        var dataPointsByHeight = ProcessData(matrix);

        // return sum of scores of '0' positions
        return dataPointsByHeight[0]
            .Sum(x => x.element.GetScore())
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        return "NOT IMPLEMENTED";
    }

    private static IGrouping<int, (Pos position, DataPoint element)>[] ProcessData(Matrix<DataPoint> matrix)
    {
        // We'll use dynamic programming.
        // To compute data for a position of a certain height
        // we'll use data from neighbours having the next height (previous computations)

        // order all positions/data points by height, from '0' to '9'
        IGrouping<int, (Pos position, DataPoint element)>[] byHeight = matrix
            .AllPositions()
            .GroupBy(x => x.element.Height)
            .OrderBy(x => x.Key)
            .ToArray();

        // recursion base: set destination for highest positions - each is set to itself
        foreach ((Pos ownPosition, DataPoint element) in byHeight[9])
        {
            element.Destinations.Add(ownPosition);
        }
        // Visualise(matrix, 9);

        // for each lower position's destination use destinations of neighbouring next level positions
        for (int currentHeight = 8; currentHeight >= 0; currentHeight--)
        {
            foreach (var (position, element) in byHeight[currentHeight])
            {
                IEnumerable<Pos> destinationsOfNextHeightNeighbours = NeighbourMoves
                    // compute neighbouring positions
                    .Select(move => position.MoveBy(move))
                    // for each position, get the data for that position
                    .Select(pos => matrix.Get(pos))
                    // only consider neighbours withing bounds and of the next height
                    .Where(data => data != null && data.Height == currentHeight + 1)
                    // get all destinations from those neighbours
                    // (we know data is not null because we excluded nulls in the line above)
                    .SelectMany(data => data!.Destinations);
                foreach (Pos destination in destinationsOfNextHeightNeighbours)
                {
                    element.Destinations.Add(destination);
                }
            }
            // Visualise(matrix, i);
        }

        return byHeight;
    }

    private static Matrix<DataPoint> ParseTopographicMap(string rawInput)
    {
        DataPoint[][] data = rawInput
            .Split("\r\n")
            .Select(ParseLine)
            .ToArray();

        return new Matrix<DataPoint>(data);

        DataPoint[] ParseLine(string line) =>
            line
                .Select(DataPoint.Parse)
                .ToArray();
    }

    private static void Visualise(Matrix<DataPoint> matrix, int height)
    {
        foreach (IGrouping<int, (Pos position, DataPoint element)> line in matrix
                     .AllPositions()
                     .GroupBy(x => x.position.X))
        {
            StringBuilder stringBuilder = line
                .OrderBy(x => x.position.Y)
                .Aggregate(new StringBuilder(),
                    (builder, x) =>
                    {
                        if (x.element.Height == height + 1)
                        {
                            builder.Append($"[{x.element.Height}  . ]");
                        }
                        else if (x.element.Height == height)
                        {
                            builder.Append($"[{x.element.Height} {x.element.GetScore(),2} ]");
                        }
                        else
                        {
                            builder.Append("[     ]");
                        }

                        return builder;
                    });
            Console.WriteLine(stringBuilder);
        }

        Console.WriteLine();
    }
}