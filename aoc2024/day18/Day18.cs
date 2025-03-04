using Advent_of_Code_2024.day15;
using Advent_of_Code_2024.day16;

namespace Advent_of_Code_2024.day18;

public static partial class Day18
{
    public static string Part1(InputSelector inputSelector)
    {
        (int memorySize, int bytesToTake, string rawInput) = Input.GetInput(inputSelector);
        Pos[] fallingBytes = rawInput
            .Split(Environment.NewLine)
            .Select(Pos.Parse)
            .ToArray();

        var memory = CreateMemory(memorySize);
        foreach (Pos bytePos in fallingBytes.Take(bytesToTake))
        {
            memory.Get(bytePos).IsCorrupted = true;
        }

        ComputeShortestDistances(memory);

        return memory.Get(0, 0)!.DistanceFromExit.ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static Matrix<Tile> CreateMemory(int memorySize)
    {
        Tile[][] data = new Tile[memorySize][];
        for (int y = 0; y < memorySize; y++)
        {
            data[y] = new Tile[memorySize];
            for (int x = 0; x < memorySize; x++)
            {
                data[y][x] = new Tile() {Pos = new Pos(x, y)};
            }
        }

        return new Matrix<Tile>(data);
    }

    private static void ComputeShortestDistances(Matrix<Tile> memory)
    {
        var endPos = new Pos(memory.ColumnCount - 1, memory.RowCount - 1);
        Tile endTile = memory.Get(endPos)!;
        endTile.DistanceFromExit = 0;

        SortedSet<Tile> queue = new(new Tile.DistanceComparer());
        queue.Add(endTile);

        while (queue.Count > 0)
        {
            Tile currentTile = queue.Min!;
            queue.Remove(currentTile);

            IEnumerable<Tile> neighbours = Direction.All
                .Select(move => currentTile.Pos.After(move))
                .Select(memory.Get)
                .Where(tile => tile != null)!
                .ToArray()!;
            
            int potentialNewDistance = currentTile.DistanceFromExit + 1;
            
            foreach (var neighbour in neighbours)
            {
                if (neighbour.IsCorrupted) continue;
                if (potentialNewDistance < neighbour.DistanceFromExit)
                {
                    neighbour.DistanceFromExit = potentialNewDistance;
                    if (queue.Contains(neighbour)) queue.Remove(neighbour);
                    queue.Add(neighbour);
                }
            }
        }
    }
}

public class Tile
{
    public bool IsCorrupted { get; set; }

    public int DistanceFromExit { get; set; } = int.MaxValue;

    public Pos Pos { get; set; }

    public override string ToString()
    {
        return $"{Pos} {(IsCorrupted ? "CORRUPTED" : "")}  dist {DistanceFromExit}";
    }

    public class DistanceComparer : IComparer<Tile>
    {
        public int Compare(Tile? x, Tile? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (y is null) return 1;
            if (x is null) return -1;
            var distanceCmp = x.DistanceFromExit.CompareTo(y.DistanceFromExit);
            
            // never return 0 to not overwrite elements in a SortedSet
            if (distanceCmp == 0)
            {
                return x.Pos.CompareTo(y.Pos);
            }
            
            return distanceCmp;
        }
    }
}