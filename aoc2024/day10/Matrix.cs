using Advent_of_Code_2024.day04;

namespace Advent_of_Code_2024.day10;

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
    public TElement? Get(Pos position)
    {
        (int row, int column) = position;

        if (row < 0 || row >= _data.Length || column < 0 || column >= _data[row].Length)
        {
            return null;
        }

        return _data[row][column];
    }

    public void Set(Pos position, TElement element)
    {
        (int row, int column) = position;
        _data[row][column] = element;
    }

    /// <summary>
    /// Returns all positions existing in the matrix,
    /// each together with the element present at that position.
    /// </summary>
    public IEnumerable<(Pos position, TElement element)> AllPositions()
    {
        for (var i = 0; i < _data.Length; i++)
        {
            for (var j = 0; j < _data[i].Length; j++)
            {
                yield return (new Pos(i, j), _data[i][j]);
            }
        }
    }
}