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
        Matrix<Data> matrix = ParseTopographicMap(rawInput);

        // We'll use dynamic programming.
        // To compute data for a position of a certain height
        // we'll use data from positions of a greater height (previous computations)

        // order all positions by height, from '0' to '9'
        IGrouping<int, (Pos position, Data element)>[] byHeight = matrix
            .AllPositions()
            .GroupBy(x => x.element.Height)
            .OrderBy(x => x.Key)
            .ToArray();

        // set destination for highest positions - each is set to itself
        foreach ((Pos ownPosition, Data element) in byHeight[9])
        {
            element.Destinations.Add(ownPosition);
        }

        // Visualise(matrix, 9);

        // for each lower position, use destinations of neighbouring higher positions as its destinations
        for (int i = 8; i >= 0; i--)
        {
            foreach (var (position, element) in byHeight[i])
            {
                IEnumerable<Pos> destinationsOfNextHeightNeighbours = NeighbourMoves
                    // compute neighbouring positions
                    .Select(move => position.MoveBy(move))
                    // for each position, get the data for that position
                    .Select(pos => matrix.Get(pos))
                    // only consider neighbours withing bounds and of the next height
                    .Where(data => data != null && data.Height == i + 1)
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

        // return sum of scores of '0' positions
        return byHeight[0]
            .Sum(x => x.element.GetScore())
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        return "NOT IMPLEMENTED";
    }

    private static Matrix<Data> ParseTopographicMap(string rawInput)
    {
        Data[][] data = rawInput
            .Split("\r\n")
            .Select(ParseLine)
            .ToArray();

        return new Matrix<Data>(data);

        Data[] ParseLine(string line) =>
            line
                .Select(Data.Parse)
                .ToArray();
    }

    private static void Visualise(Matrix<Data> matrix, int height)
    {
        foreach (IGrouping<int, (Pos position, Data element)> line in matrix
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

public class Data(int height = 0)
{
    public int Height { get; } = height;

    // using a set which has elements of a record type allows to avoid duplicates
    public HashSet<Pos> Destinations { get; } = new();
    
    public int GetScore()
    {
        return Destinations.Count;
    }

    public static Data Parse(char input) => new(height: input - '0');
}