namespace Advent_of_Code_2024.day25;

public static partial class Day25
{
    public static string Part1(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);
        string[] inputChunks = rawInput.Split(Environment.NewLine + Environment.NewLine);

        int[][] keysHeights = inputChunks.Where(IsKeyChunk).Select(ParseKey).ToArray();
        int[][] locksHeights = inputChunks.Where(IsLockChunk).Select(ParseLock).ToArray();

        int result = 0;
        foreach (int[] key in keysHeights)
        {
            foreach (int[] @lock in locksHeights)
            {
                if (key.Zip(@lock).All(pair => pair.First + pair.Second <= 5))
                {
                    result++;
                }
            }
        }

        return result.ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static bool IsKeyChunk(string inputChunk) => inputChunk[0] == '.';

    private static bool IsLockChunk(string inputChunk) => inputChunk[0] == '#';

    private static int[] ParseKey(string inputChunk)
    {
        int[] result = [0, 0, 0, 0, 0];
        IEnumerable<string> keyLines = inputChunk.Split(Environment.NewLine).Skip(1).SkipLast(1);

        foreach ((int lineIndex, string line) in keyLines.Index())
        {
            int height = 5 - lineIndex;
            foreach ((int column, char c) in line.Index())
            {
                if (c == '#' && result[column] == 0)
                {
                    result[column] = height;
                }
            }
        }

        return result;
    }

    private static int[] ParseLock(string inputChunk)
    {
        int[] result = [-1, -1, -1, -1, -1];
        IEnumerable<string> lockLines = inputChunk.Split(Environment.NewLine).Skip(1);
        foreach ((int lineIndex, string line) in lockLines.Index())
        {
            int height = lineIndex;
            foreach ((int column, char c) in line.Index())
            {
                if (c == '.' && result[column] == -1)
                {
                    result[column] = height;
                }
            }
        }

        return result;
    }
}