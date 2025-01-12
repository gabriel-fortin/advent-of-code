using Advent_of_Code_2024.day04;
using Advent_of_Code_2024.day10;

namespace Advent_of_Code_2024.day12;

public static partial class Day12
{
    private static readonly Move[] FourDirections =
    [
        new Move(-1, 0),
        new Move(1, 0),
        new Move(0, -1),
        new Move(0, 1)
    ];

    public static string Part1(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);

        // parse input
        GardenPlot[][] gardenPlots = rawInput
            .Split("\r\n")
            .Select(line =>
            {
                return line
                    .Select(c => new GardenPlot(c))
                    .ToArray();
            })
            .ToArray();
        var matrix = new Matrix<GardenPlot>(gardenPlots);
        
        // further prepare data - set up connections between neighbouring garden plots
        foreach ((Pos currentPosition, GardenPlot currentPlot) in matrix.AllPositions())
        {
            currentPlot.Neighbours = FourDirections
                // positions of all potential neighbours
                .Select(dir => currentPosition.MoveBy(dir))
                // get neighbours at those positions (some might be a miss)
                .Select(neighbourPosition => matrix.Get(neighbourPosition))
                // ignore results that were a miss
                .Where(neighbourPlot => neighbourPlot != null)!
                .ToArray<GardenPlot>();
        }
        
        // build regions - starting from one plot, joining neighbouring plots having the same plant type
        foreach ((Pos currentPosition, GardenPlot currentPlot) in matrix.AllPositions())
        {
            currentPlot.BuildRegion();
        }

        return matrix.AllPositions()
            .Select(x => x.element.Region)
            .Distinct()
            .Select(x => x.FencePrice())
            .Sum()
            .ToString();
    }

    public static string Part2(bool useExampleData)
    {
        return "NOT IMPLEMENTED";
    }
}

public class GardenPlot(char plantType)
{
    public char PlantType { get; init; } = plantType;

    public bool HasBeenProcessed => Region != null;

    public Region? Region { get; set; }

    public GardenPlot[]? Neighbours { get; set; }

    public void BuildRegion()
    {
        // the region will be built using a DFS graph-exploration strategy
        AttemptAttachToRegionAndRequestNeighboursDoingLikewise(new Region(PlantType));
    }

    private void AttemptAttachToRegionAndRequestNeighboursDoingLikewise(Region regionToGrow)
    {
        // if we've been processed as part of a Region already, we politely decline
        if (Region != null) return;
        // same if the plot cannot be part of that Region
        if (!regionToGrow.WillAccept(this)) return;
        
        Region = regionToGrow;
        regionToGrow.Add(this);
        
        foreach (GardenPlot neighbour in Neighbours)
        {
            neighbour.AttemptAttachToRegionAndRequestNeighboursDoingLikewise(regionToGrow);
        }
    }

    public override string ToString()
    {
        return $"{PlantType} -> [{string.Join(", ", Neighbours.Select(x => x.PlantType))}]";
    }
}

public class Region(
    char PlantType
)
{
    public int Area { get; private set; }

    public int Perimeter { get; private set; }

    public bool WillAccept(GardenPlot plot)
    {
        return plot.PlantType == PlantType;
    }

    public void Add(GardenPlot plot)
    {
        if (plot.PlantType != PlantType)
        {
            throw new ArgumentException($"Region has plan type '{PlantType}' and won't accept a plot with plant type '{plot.PlantType}'");
        }

        Area++;
        Perimeter += 4; // one for each side of the added plot

        // remove 2 sides from Perimeter for each pair of adjacent plots that are already in the Region
        int neighboursAlreadyInRegion = plot.Neighbours
            .Count(neighbour => neighbour.Region == this);
        Perimeter -= 2 * neighboursAlreadyInRegion;
    }

    public long FencePrice()
    {
        return Area * Perimeter;
    }
}