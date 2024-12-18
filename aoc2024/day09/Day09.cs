namespace Advent_of_Code_2024.day09;

public static partial class Day09
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var disk = new Disk(rawInput);

        disk.DecompressFromDenseFormat();
        disk.CompactFiles();
        return disk.ComputeChecksum().ToString();
    }

    public static string Part2(bool useExampleData)
    {
        return "NOT IMPLEMENTED";
    }
}

public record FileBlock(int Id);

public class Disk
{
    private readonly string _denseMap;
    private readonly int _dataSize;
    private readonly FileBlock?[] _data;

    public Disk(string diskDenseMap)
    {
        _denseMap = diskDenseMap;
        _dataSize = diskDenseMap.Sum(x => int.Parse(x.ToString()));
        _data = new FileBlock?[_dataSize];
    }

    public void DecompressFromDenseFormat()
    {
        bool isFileBlock = true;
        int dataIndex = 0;
        int fileId = 0;
        foreach (char length in _denseMap)
        {
            int blockCount = length - '0';
            if (isFileBlock)
            {
                while (blockCount > 0)
                {
                    _data[dataIndex] = new FileBlock(fileId);
                    blockCount--;
                    dataIndex++;
                }

                fileId++;
            }
            else
            {
                dataIndex += blockCount;
            }

            isFileBlock = !isFileBlock;
        }
    }

    public void CompactFiles()
    {
        int emptySpaceIndex = 0;
        int lastDataIndex = _dataSize - 1;

        while (true)
        {
            FindNextEmptySpace();
            FindLastOccupiedBlock();
            if (emptySpaceIndex > lastDataIndex) break;
            
            _data[emptySpaceIndex] = _data[lastDataIndex];
            _data[lastDataIndex] = null;
            // Visualise();
        }

        return;

        void FindNextEmptySpace()
        {
            while (_data[emptySpaceIndex] != null) emptySpaceIndex++;
        }

        void FindLastOccupiedBlock()
        {
            while (_data[lastDataIndex] == null) lastDataIndex--;
        }
    }

    public long ComputeChecksum()
    {
        return _data.Zip(Enumerable.Range(0, _dataSize))
            .Aggregate(0L, (acc, nextItem) => acc + (nextItem.First?.Id ?? 0) * nextItem.Second);
    }

    // useful for debugging
    private void Visualise()
    {
        char[] visualisation = new char[_dataSize];
        for (int i = 0; i < _dataSize; i++)
        {
            visualisation[i] = _data[i] == null
                ? '.'
                : _data[i]!.Id.ToString()[0];
        }

        Console.WriteLine(new string(visualisation));
    }
}