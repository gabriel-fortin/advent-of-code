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
        Matrix<GardenPlot> matrix = ParsePlots(rawInput);
        // further prepare data - set up connections between neighbouring garden plots
        ConnectNeighbours(matrix);

        // build regions - starting from one plot, joining neighbouring plots that have the same plant type
        IEnumerable<Region> allRegions = BuildRegions(matrix);

        return allRegions
            .Select(x => x.RegularFencePrice())
            .Sum()
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);
        Matrix<GardenPlot> matrix = ParsePlots(rawInput);
        ConnectNeighbours(matrix);
        
        // build regions - starting from one plot, joining neighbouring plots that have the same plant type
        Region[] allRegions = BuildRegions(matrix).ToArray();

        // compute sides - sweep each region from top to bottom
        ComputeSides(allRegions, matrix);

        return allRegions
            .Select(x => x.BulkDiscountFencePrice())
            .Sum()
            .ToString();
    }

    private static IEnumerable<Region> BuildRegions(Matrix<GardenPlot> matrix)
    {
        foreach ((Pos currentPosition, GardenPlot currentPlot) in matrix.AllPositions())
        {
            yield return currentPlot.BuildRegion();
        }
    }

    private static void ComputeSides(Region[] allRegions, Matrix<GardenPlot> matrix)
    {
        foreach (Region region in allRegions)
        {
            // iterate over every row, counting:
            //  - number of top sides it adds, and
            //  - number of bottom sides the previous row adds, and
            //  - number of left or right sides it starts
            int sidesCount = Enumerable.Range(0, matrix.RowCount)
                .Select(rowIndex => CountSidesAddedByRow(matrix, rowIndex, region))
                .Sum();
            
            // add bottoms of the last row
            sidesCount += DetermineFragments(matrix, matrix.RowCount-1, region).Count();

            region.Sides = sidesCount;
        }
    }

    private static int CountSidesAddedByRow(Matrix<GardenPlot> matrix, int rowIndex, Region region)
    {
        int sidesCount = 0;
        
        // before we process the lot in the first column, the plots "to its left" are treated as not in the region
        bool isLeftAbovePlotInRegion = false;
        bool isLeftPlotInRegion = false;
        
        for (int columnIndex = 0; columnIndex < matrix.ColumnCount; columnIndex++)
        {
            // note: the plot above might be in "row of index -1" in which case we'll get a null
            bool isAbovePlotInRegion = matrix.Get(rowIndex - 1, columnIndex)?.Region == region;
            bool isCurrentPlotInRegion = matrix.Get(rowIndex, columnIndex)!.Region == region;

            /*
             * All the possible situations starting a horizontal or vertical side
             * In the depictions below:
             *     " R " indicates that the plot is in the region,
             *     "   " indicates that the plot is not in the region
             *     "|||" indicates that it doesn't matter if the plot is in the region
             *
             *      (A)          (A)          (B)          (B)          (C)          (C)          (D)          (D)
             *   ________     ________     ________     ________     ________     ________     ________     ________
             *  |||||   |    | R |||||    |   |||||    | R | R |    |||||   |    | R |   |    |   | R |    ||||| R |
             *  |   | R |    |   | R |    | R |   |    | R |   |    |   | R |    ||||| R |    |   |   |    | R |   |
             */

            // (A) does the current plot start a left side?
            if ((isCurrentPlotInRegion && !isAbovePlotInRegion && !isLeftPlotInRegion) ||
                (isCurrentPlotInRegion && isLeftAbovePlotInRegion && !isLeftPlotInRegion))
            {
                sidesCount++;
            }

            // (B) does the left plot start a right side?
            if ((!isCurrentPlotInRegion && isLeftPlotInRegion && !isLeftAbovePlotInRegion) ||
                (!isCurrentPlotInRegion && isAbovePlotInRegion && isLeftPlotInRegion && isLeftAbovePlotInRegion))
            {
                sidesCount++;
            }

            // (C) does the current plot start a top side?
            if ((isCurrentPlotInRegion && !isAbovePlotInRegion && !isLeftPlotInRegion) ||
                (isCurrentPlotInRegion && !isAbovePlotInRegion && isLeftAbovePlotInRegion))
            {
                sidesCount++;
            }

            // (D) does the above plot start a bottom side?
            if ((!isCurrentPlotInRegion && isAbovePlotInRegion && !isLeftPlotInRegion && !isLeftAbovePlotInRegion) ||
                (!isCurrentPlotInRegion && isAbovePlotInRegion && isLeftPlotInRegion))
            {
                sidesCount++;
            }

            isLeftAbovePlotInRegion = isAbovePlotInRegion;
            isLeftPlotInRegion = isCurrentPlotInRegion;
        }

        // does the last plot in the row start a right side?
        GardenPlot? lastPlotInRowAbove = matrix.Get(rowIndex - 1, matrix.ColumnCount - 1);
        GardenPlot? lastPlotInCurrentRow = matrix.Get(rowIndex, matrix.ColumnCount - 1);
        if (lastPlotInRowAbove?.Region != region && lastPlotInCurrentRow!.Region == region)
        {
            sidesCount++;
        }

        return sidesCount;
    }

    private static IEnumerable<RegionFragment> DetermineFragments(Matrix<GardenPlot> matrix,
        int rowIndex, Region region)
    {
        int? fragmentStart = null; // null means we're not within a fragment

        for (int columnIndex = 0; columnIndex < matrix.ColumnCount; columnIndex++)
        {
            Region plotAtIndex = matrix.Get(rowIndex, columnIndex)!.Region!;

            // new fragment of the region is found; we're now inside a fragment
            if (fragmentStart == null && plotAtIndex == region)
            {
                fragmentStart = columnIndex;
            }
            // end of fragment is found; create and return fragment object
            else if (fragmentStart != null && plotAtIndex != region)
            {
                yield return new RegionFragment((int)fragmentStart, columnIndex - 1);
                fragmentStart = null;
            }
        }

        // after reaching the end, handle the potential unclosed an unreported fragment
        if (fragmentStart != null)
        {
            yield return new RegionFragment((int)fragmentStart, matrix.ColumnCount - 1);
        }
    }

    private record RegionFragment(int First, int Last);

    private static Matrix<GardenPlot> ParsePlots(string rawInput)
    {
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
        return matrix;
    }

    private static void ConnectNeighbours(Matrix<GardenPlot> matrix)
    {
        foreach ((Pos currentPosition, GardenPlot currentPlot) in matrix.AllPositions())
        {
            currentPlot.Neighbours = FourDirections
                // positions of all potential neighbours
                .Select(dir => currentPosition.MoveBy(dir))
                // get neighbours at those positions (some might be a miss)
                .Select(matrix.Get)
                // ignore results that were a miss
                .Where(neighbourPlot => neighbourPlot != null)!
                .ToArray<GardenPlot>();
        }
    }
}