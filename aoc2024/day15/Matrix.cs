namespace Advent_of_Code_2024.day15;

public class Matrix<TElement> where TElement : class
{
    private readonly TElement[][] _data;

    public int RowCount { get; }

    public int ColumnCount { get; }

    public Matrix(TElement[][] inputData)
    {
        _data = inputData;
        RowCount = _data.Length;
        ColumnCount = _data[0].Length;
    }

    /// <summary>
    /// Returns the element at the given position.
    /// If either of the arguments is out of range, null is returned.
    /// </summary>
    public TElement? Get(int row, int column)
    {
        if (row < 0 || row >= RowCount || column < 0 || column >= ColumnCount)
        {
            return null;
        }

        return _data[row][column];
    }

    /// <inheritdoc cref="Get(int,int)"/>
    public TElement? Get(Pos position)
    {
        (int x, int y) = position;
        return Get(row: y, column: x);
    }

    public void Set(Pos position, TElement element)
    {
        (int x, int y) = position;
        var (row, column) = (y, x);
        _data[row][column] = element;
    }

    /// <summary>
    /// Returns all positions existing in the matrix,
    /// each together with the element present at that position.
    /// </summary>
    public IEnumerable<(Pos position, TElement element)> AllPositions()
    {
        for (var row = 0; row < RowCount; row++)
        {
            for (var column = 0; column < ColumnCount; column++)
            {
                var (x, y) = (column, row);
                yield return (new Pos(x, y), _data[row][column]);
            }
        }
    }

    public Pos? FindPositionOfFirst(Func<TElement, bool> predicate)
    {
        for (var row = 0; row < RowCount; row++)
        {
            for (var column = 0; column < ColumnCount; column++)
            {
                if (predicate(_data[row][column]))
                {
                    var (x, y) = (column, row);
                    return new Pos(x, y);
                }
            }
        }

        return null;
    }
}