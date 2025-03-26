namespace Advent_of_Code_2024.day22;

// we'll be keeping 4 numbers in one integer for a slight performance increase
using EncodedPriceChangeSequence = int;

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
        IEnumerable<long> initialSecretsOfBuyers = Input.GetInput(inputSelector)
            .Split(Environment.NewLine)
            .Select(long.Parse);

        PseudoRandomGenerator[] buyers = initialSecretsOfBuyers
            .Select(PseudoRandomGenerator.Create)
            .ToArray();

        Dictionary<EncodedPriceChangeSequence, int> sumsPerSequence = new();

        foreach (PseudoRandomGenerator buyer in buyers)
        {
            int[] prices = new int[2001];
            int[] priceChanges = new int[2000];
            HashSet<EncodedPriceChangeSequence> usedSequences = new();

            prices[0] = (int)(buyer.CurrentValue % 10);
            for (int i = 0; i < 2000; i++)
            {
                prices[i + 1] = (int)(buyer.GenerateNextValue() % 10);
                priceChanges[i] = prices[i + 1] - prices[i];

                // we need at least four price changes
                if (i < 4) continue;

                EncodedPriceChangeSequence sequence = EncodeSequence(
                    priceChanges[i - 3],
                    priceChanges[i - 2],
                    priceChanges[i - 1],
                    priceChanges[i]);

                // if this sequence appeared before, it can't be used again
                if (usedSequences.Contains(sequence)) continue;

                usedSequences.Add(sequence);
                int currentSum = sumsPerSequence.GetValueOrDefault(sequence);
                sumsPerSequence[sequence] = currentSum + prices[i + 1];
            }
        }

        return sumsPerSequence
            .Max(x => x.Value)
            .ToString();
    }

    private static long Compute2000thValue(PseudoRandomGenerator generator)
    {
        for (int i = 0; i < 2000; i++)
        {
            generator.GenerateNextValue();
        }

        return generator.CurrentValue;
    }

    private static EncodedPriceChangeSequence EncodeSequence(int c1, int c2, int c3, int c4)
    {
        // each number is between -9 and 9
        // we add 10 to each it's always non-negative
        // each needs 5 bits to be stored
        return ((c1 + 10) << 15) +
            ((c2 + 10) << 10) +
            ((c3 + 10) << 5) +
            (c4 + 10);
    }

    private static (int, int, int, int) DecodeSequence(EncodedPriceChangeSequence sequence)
    {
        int c4 = (sequence & 0x1f) - 10;
        sequence >>= 5;
        int c3 = (sequence & 0x1f) - 10;
        sequence >>= 5;
        int c2 = (sequence & 0x1f) - 10;
        sequence >>= 5;
        int c1 = (sequence & 0x1f) - 10;
        return (c1, c2, c3, c4);
    }
}