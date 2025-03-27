namespace Advent_of_Code_2024.day23;

public class Computer(string name) : IComparer<Computer>, IComparable<Computer>
{
    private readonly List<Computer> _connections = new();

    public string Name { get; } = name;

    public IReadOnlyList<Computer> Connections => _connections;

    public void AddConnection(Computer computer)
    {
        _connections.Add(computer);
    }

    public int Compare(Computer? x, Computer? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return 1;
        if (x is null) return -1;
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }

    public int CompareTo(Computer? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}