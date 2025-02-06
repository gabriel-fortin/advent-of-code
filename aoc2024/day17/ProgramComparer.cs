using System.Diagnostics;

namespace Advent_of_Code_2024.day17;

public class ProgramComparer(Program originalProgram)
{
    private int _position = 0;
    private bool _isPartialMatch = true;

    // for debugging
    private int _bestPosition = 0;
    private Stopwatch _stopwatch = Stopwatch.StartNew();

    public int PartialMatchLength => _position;

    public void Feed(long number)
    {
        if (!originalProgram.TryReadAt(_position, out var originalNumber))
        {
            // original program is shorter than what we are fed
            _isPartialMatch = false;
        }

        if (originalNumber != number)
        {
            // original program differs at current position
            _isPartialMatch = false;
        }

        _position++;
    }

    public bool IsPartialMatch() => _isPartialMatch;

    public bool IsFullMatch() =>
        _position == originalProgram.ProgramInstructionsAndOperands.Length;

    public void Reset()
    {
        _position = 0;
        _isPartialMatch = true;
    }

    public void Debug(long regA)
    {
        if (_position > _bestPosition)
        {
            _bestPosition = _position;
            string bestProg = string.Join(',',
                originalProgram.ProgramInstructionsAndOperands
                    .Take(_position));

            double seconds = _stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"[{seconds:N0}s] reg A = {Convert.ToString(regA, 8)} || prog: {bestProg}");
        }
    }
}