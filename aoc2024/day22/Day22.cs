namespace Advent_of_Code_2024.day22;

public static partial class Day22
{
    public static string Part1(InputSelector inputSelector)
    {
        IEnumerable<long> initialSecretsOfBuyers = Input.GetInput(inputSelector)
            .Split(Environment.NewLine)
            .Select(long.Parse);

        return initialSecretsOfBuyers
            .Select(PseudoRandomGenerator.Create)
            .Select(Compute2000thValue)
            .Sum()
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static long Compute2000thValue(PseudoRandomGenerator generator)
    {
        for (int i = 0; i < 2000; i++)
        {
            generator.GenerateNextValue();
        }

        return generator.CurrentValue;
    }
}