namespace Advent_of_Code_2024.day04;

public class WordFinder(Matrix matrix)
{
    private static readonly Move[] MovementDirections =
        new[]
            {
                (-1, -1), (-1, 0), (-1, 1),
                (0, -1), /* pos */ (0, 1),
                (1, -1), (1, 0), (1, 1),
            }
            .Select(pair => new Move(pair))
            .ToArray();

    public long FindAndCount(string word) => FindAndCount(word.ToCharArray());

    public long FindAndCount(char[] word)
    {
        long sum = 0;
        for (int row = 0; row < matrix.MaxRow; row++)
        {
            for (int column = 0; column < matrix.MaxColumn; column++)
            {
                sum += FindAndCountAt(new Pos(row, column), word);
            }
        }

        return sum;
    }

    // TODO: use more LINQ?
    private long FindAndCountAt(Pos pos, char[] word)
    {
        int count = 0;
        foreach (var move in MovementDirections)
        {
            var currPos = pos;
            foreach (char letter in word)
            {
                if (matrix.Get(currPos) != letter)
                {
                    goto wordNotFound;
                }

                currPos = currPos.MoveBy(move);
            }

            count++;
            wordNotFound: ;
        }

        return count;
    }
}