namespace Advent_of_Code_2024.day04;

public class Matrix
{
    private readonly char[][] _data;

    public int MaxRow { get; }

    public int MaxColumn { get; }

    public Matrix(string[] textLines)
    {
        _data = textLines
            .Select(x => x.ToCharArray())
            .ToArray();
        MaxRow = _data.Length;
        MaxColumn = _data[0].Length;
    }

    /// <summary>
    /// Returns the character at the given position.
    /// If either of the arguments is out of range, null is returned.
    /// </summary>
    public char? Get(Pos position)
    {
        (int row, int column) = position;
            
        if (row < 0 || row >= _data.Length || column < 0 || column >= _data[row].Length)
        {
            return null;
        }

        return _data[row][column];
    }

    public void Set(Pos position, char value)
    {
        (int row, int column) = position;
        _data[row][column] = value;
    }

    /// <summary>
    /// Returns all positions existing in the matrix
    /// together with the letters present at each of those positions.
    /// </summary>
    public IEnumerable<(Pos position, char letter)> AllPositions()
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