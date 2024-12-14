namespace Advent_of_Code_2024.day07;

public class Operator
{
    public Func<long, int, long> Apply { get; }

    private Operator(Func<long, int, long> apply)
    {
        Apply = apply;
    }

    public static readonly Operator Add = new Operator((x, y) => x + y);
    public static readonly Operator Multiply = new Operator((x, y) => x * y);
    public static readonly Operator Concatenate =
        new Operator((x, y) => long.Parse(string.Concat(x,y)));
}