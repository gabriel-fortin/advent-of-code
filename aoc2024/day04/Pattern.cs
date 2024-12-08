namespace Advent_of_Code_2024.day04;

/// <summary>
/// List of letters and relative positions of where each letter is placed
/// </summary>
public record Pattern(List<(char letter, Move relativePosition)> LettersAndTheirRelativePositions)
{
    public bool IsMatchAtPosition(int row, int col, Matrix matrix) =>
        IsMatchAtPosition(new(row, col), matrix);

    public bool IsMatchAtPosition(Pos position, Matrix matrix)
    {
        return LettersAndTheirRelativePositions.All(x =>
        {
            var absolutePositionOfLetter = position.MoveBy(x.relativePosition);
            return matrix.Get(absolutePositionOfLetter) == x.letter;
        });
    }

    public static Pattern FromEnumerableOfLettersAndPositions(
        IEnumerable<(char letter, (int, int) relativePosition)> lettersAndTheirRelativePositions
    )
    {
        return new Pattern(
            lettersAndTheirRelativePositions
                .Select(pair => (pair.letter, new Move(pair.relativePosition)))
                .ToList()
        );
    }
}