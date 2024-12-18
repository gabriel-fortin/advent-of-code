namespace Advent_of_Code_2024.day09;

public static partial class Day09
{
    public static string Part1(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var disk = new Disk(rawInput);

        disk.DecompressFromDenseFormat();
        disk.CompactFilesByMovingSingleBlocks();
        return disk.ComputeChecksum().ToString();
    }

    public static string Part2(bool useExampleData)
    {
        string rawInput = Input.GetInput(useExampleData);
        var disk = new Disk(rawInput);

        disk.DecompressFromDenseFormat();
        disk.CompactFilesByMovingWholeFiles();
        return disk.ComputeChecksum().ToString();
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

    public void CompactFilesByMovingSingleBlocks()
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

    public void CompactFilesByMovingWholeFiles()
    {
        // we know that last block is always occupied by a file block
        int fileId = _data[_dataSize - 1]!.Id;

        for (; fileId >= 0; fileId--)
        {
            // Visualise();
            Range file = FindFile(fileId);
            int emptySpaceLocation = FindLeftmostFreeSpaceFor(file);
            if (emptySpaceLocation > file.Start.Value) continue;

            if (emptySpaceLocation != -1)
            {
                MoveFile(file, emptySpaceLocation);
            }
        }

        return;

        Range FindFile(int id)
        {
            // end indicates the position AFTER the last block of the file
            int end = _dataSize;
            while (_data[end - 1]?.Id != id) end--;

            int start = end;
            while (start > 0 && _data[start - 1]?.Id == id) start--;

            return new Range(start, end);
        }

        int FindLeftmostFreeSpaceFor(Range file)
        {
            int requiredSpace = file.End.Value - file.Start.Value;

            int searchIndex = 0;
            while (searchIndex < file.Start.Value)
            {
                int spaceStart = Array.FindIndex(_data, searchIndex, block => block == null);
                if (spaceStart == -1) return -1;

                int spaceEnd = Array.FindIndex(_data, spaceStart, block => block != null);
                if (spaceEnd == -1) return -1;

                if (spaceEnd - spaceStart >= requiredSpace) return spaceStart;
                searchIndex = spaceEnd;
            }

            return -1;
        }

        void MoveFile(Range file, int emptySpaceLocation)
        {
            for (int j = emptySpaceLocation, i = file.Start.Value; i < file.End.Value; i++, j++)
            {
                _data[j] = _data[i];
                _data[i] = null;
            }
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