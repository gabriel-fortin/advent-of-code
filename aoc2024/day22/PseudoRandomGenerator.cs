namespace Advent_of_Code_2024.day22;

public class PseudoRandomGenerator(long seed)
{
    private long _currentValue = seed;

    public long CurrentValue => _currentValue;

    public long GenerateNextValue()
    {
        return _currentValue = Mul2048MixPrune(Div32MixPrune(Mul64MixPrune(_currentValue)));

        // we could see the operation order more clearly if we used '.Aggregate'
        _currentValue = new[]
            {
                Mul64MixPrune,
                Div32MixPrune,
                Mul2048MixPrune,
            }
            .Aggregate(_currentValue, (val, evolutionStep) => evolutionStep(val));
    }

    private static long Mul64MixPrune(long number)
    {
        // multiply by 64 (2^6 = 64)
        long x = number << 6;
        // mix & prune
        return (number ^ x) % 16777216;
    }

    private static long Div32MixPrune(long number)
    {
        // divide by 32 (2^5 = 32) with rounding down
        long x = number >> 5;
        // mix & prune
        return (number ^ x) % 16777216;
    }

    private static long Mul2048MixPrune(long number)
    {
        // multiply by 2048 (2^11 = 2048)
        long x = number << 11;
        // mix & prune
        return (number ^ x) % 16777216;
    }
    
    public static PseudoRandomGenerator Create(long seed) => new(seed);
}