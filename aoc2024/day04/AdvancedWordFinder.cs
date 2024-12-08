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
    
    // alternative version using LINQ
    public int FindAndCountUsingLinq(Pattern pattern)
    {
        return Enumerable
            .Range(0, matrix.MaxRow)
            .Sum(row => Enumerable
                .Range(0, matrix.MaxColumn)
                .Count(column => pattern.IsMatchAtPosition(row, column, matrix)));
    }
    
    // simple LINQ version which required adding AllPositions method to Matrix
    public int FindAndCountUsingLinqAndAllPositionsFromMatrix(Pattern pattern)
    {
        return matrix.AllPositions()
            .Count(x => pattern.IsMatchAtPosition(x.position, matrix));
    }
}