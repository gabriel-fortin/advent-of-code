namespace Advent_of_Code_2024.day23;

public class ArrayHasSameElementsInSameOrder : IEqualityComparer<Computer[]>
{
    public bool Equals(Computer[]? x, Computer[]? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.Length != y.Length) return false;
        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] != y[i]) return false;
        }

        return true;
    }

    public int GetHashCode(Computer[] obj)
    {
        // very poor hash code implementation - it doesn't account for the order of elements in the array
        // please don't judge me
        return obj.Select(x => x.GetHashCode()).Sum();
    }
}