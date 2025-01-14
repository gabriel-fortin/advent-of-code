namespace Advent_of_Code_2024.day12;

public class Region(
    char plantType
)
{
    public int Area { get; private set; }

    public int Perimeter { get; private set; }

    public int Sides { get; set; }

    public bool WillAccept(GardenPlot plot)
    {
        return plot.PlantType == plantType;
    }

    public void Add(GardenPlot plot)
    {
        if (plot.PlantType != plantType)
        {
            throw new ArgumentException(
                $"Region has plan type '{plantType}' and won't accept a plot having plant type '{plot.PlantType}'");
        }

        Area++;
        Perimeter += 4; // one for each side of the added plot

        // remove 2 sides from Perimeter for each pair of adjacent plots that are already in the Region
        int neighboursAlreadyInRegion = plot.Neighbours
            .Count(neighbour => neighbour.Region == this);
        Perimeter -= 2 * neighboursAlreadyInRegion;
    }

    public long RegularFencePrice()
    {
        return (long)Area * Perimeter;
    }

    public long BulkDiscountFencePrice()
    {
        return (long)Area * Sides;
    }
}