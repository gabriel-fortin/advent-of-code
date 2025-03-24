namespace Advent_of_Code_2024.day22;

public static partial class Day22
{
    public static string Part1(InputSelector inputSelector)
    {
        IEnumerable<long> initialSecretsOfBuyers = Input.GetInput(inputSelector)
            .Split(Environment.NewLine)
            .Select(long.Parse);

        return initialSecretsOfBuyers
            .Select(initialSecret => new PseudoRandomGenerator(initialSecret))
            .Select(generator => generator.GenerateNextValue(repetitions: 2000))
            .Sum()
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }
}