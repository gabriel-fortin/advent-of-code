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

        PriorityQueue<Tile, int> queue = new();
        queue.Enqueue(endTile, endTile.DistanceFromExit);

        while (queue.Count > 0)
        {
            Tile currentTile = queue.Dequeue();

            IEnumerable<Tile> neighbours = Direction.All
                .Select(move => currentTile.Pos.After(move))
                .Select(memory.Get)
                .Where(tile => tile != null)!;
            
            int potentialNewDistance = currentTile.DistanceFromExit + 1;
            
            foreach (var neighbour in neighbours)
            {
                if (neighbour.IsCorrupted) continue;
                if (potentialNewDistance < neighbour.DistanceFromExit)
                {
                    neighbour.DistanceFromExit = potentialNewDistance;
                    queue.Remove(neighbour, out _, out _);
                    queue.Enqueue(neighbour, neighbour.DistanceFromExit);
                }
            }
        }
    }
}