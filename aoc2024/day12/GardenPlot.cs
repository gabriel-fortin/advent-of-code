namespace Advent_of_Code_2024.day12;

public class GardenPlot(char plantType)
{
    public char PlantType { get; init; } = plantType;

    public bool HasBeenProcessed => Region != null;

    public Region? Region { get; set; }

    public GardenPlot[]? Neighbours { get; set; }

    public Region BuildRegion()
    {
        var newRegion = new Region(PlantType);
        // the region will be built using a DFS graph-exploration strategy
        AttemptAttachToRegionAndRequestNeighboursDoingLikewise(newRegion);
        return newRegion;
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