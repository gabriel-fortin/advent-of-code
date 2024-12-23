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
        Matrix<DataPoint> matrix = ParseTopographicMap(Input.GetInput(useExampleData));

        var dataPointsByHeight = ProcessData(matrix);

        // return sum of scores of '0' positions
        return dataPointsByHeight[0]
            .Sum(x => x.element.GetScore())
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        Matrix<DataPoint> matrix = ParseTopographicMap(Input.GetInput(useExampleData));

        var dataPointsByHeight = ProcessData(matrix);

        return dataPointsByHeight[0]
            .Sum(x => x.element.Rating)
            .ToString();
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
            element.Rating = 1;
        }
        // Visualise(matrix, 9);

        // for each lower position's destination use destinations of neighbouring next level positions
        for (int currentHeight = 8; currentHeight >= 0; currentHeight--)
        {
            foreach (var (position, dataPoint) in byHeight[currentHeight])
            {
                DataPoint[] nextHeightNeighbours = NeighbourMoves
                    // compute neighbouring positions
                    .Select(moveToNeighbour => position.MoveBy(moveToNeighbour))
                    // for each position, get the data for that position
                    .Select(neighbourPos => matrix.Get(neighbourPos))
                    // only consider neighbours withing bounds and of the next height
                    .Where(neighbourData => neighbourData != null && neighbourData.Height == currentHeight + 1)
                    // (we know data is not null because we excluded nulls in the line above)
                    .ToArray()!;
                
                IEnumerable<Pos> nextHeightNeighbourDestinations = nextHeightNeighbours
                    // get all destinations from those neighbours
                    .SelectMany(neighbourData => neighbourData.Destinations);
                
                dataPoint.Rating = nextHeightNeighbours.Sum(neighbourData => neighbourData.Rating);
                foreach (Pos neighbourDestination in nextHeightNeighbourDestinations)
                {
                    // 'Destinations' is a set so we'll not have duplicates
                    dataPoint.Destinations.Add(neighbourDestination);
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