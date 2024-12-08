namespace Advent_of_Code_2024.day04;

public class AdvancedWordFinder(Matrix matrix)
{
    public int FindAndCount(Pattern pattern)
    {
        int sum = 0;
        for (int row = 0; row < matrix.MaxRow; row++)
        {
            for (int column = 0; column < matrix.MaxColumn; column++)
            {
                Pos position = new Pos(row, column);
                if (pattern.IsMatchAtPosition(position, matrix)) sum++;
            }
        }

        return sum;
    }
}