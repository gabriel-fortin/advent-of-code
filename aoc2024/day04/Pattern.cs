namespace Advent_of_Code_2024.day04;

/// <summary>
/// List of letters and relative positions of where each letter is placed
/// </summary>
public record Pattern(List<(char letter, Move relativePosition)> LettersAndTheirRelativePositions)
{
    public bool IsMatchAtPosition(Pos position, Matrix matrix)
    {
        return LettersAndTheirRelativePositions.All(x =>
        {
            var absolutePositionOfLetter = position.MoveBy(x.relativePosition);
            return matrix.Get(absolutePositionOfLetter) == x.letter;
        });
    }
}