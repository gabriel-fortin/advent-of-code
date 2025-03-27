namespace Advent_of_Code_2024.day23;

public static partial class Day23
{
    public static string Part1(InputSelector inputSelector)
    {
        IEnumerable<(string, string)> connections = Input.GetInput(inputSelector)
            .Split(Environment.NewLine)
            .Select(s => (name1: s[..2], name2: s[3..]));

        List<Computer> network = ParseNetwork(connections);

        return FindCliquesOfSize3(network)
            .Where(SomeNameStartsWith('t'))
            .Distinct(comparer: new ArrayHasSameElementsInSameOrder())
            .Count()
            .ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        throw new NotImplementedException();
    }

    private static Func<Computer[], bool> SomeNameStartsWith(char letter)
    {
        return computers => computers.Any(c => c.Name[0] == 't');
    }

    private static List<Computer> ParseNetwork(IEnumerable<(string, string)> connections)
    {
        Dictionary<string, Computer> network = new();

        foreach (var (name1, name2) in connections)
        {
            if (!network.TryGetValue(name1, out Computer? computer1))
            {
                network.Add(name1, computer1 = new Computer(name1));
            }

            if (!network.TryGetValue(name2, out Computer? computer2))
            {
                network.Add(name2, computer2 = new Computer(name2));
            }

            computer1.AddConnection(computer2);
            computer2.AddConnection(computer1);
        }

        return network.Values.OrderBy(x => x.Name).ToList();
    }

    private static IEnumerable<Computer[]> FindCliquesOfSize3(List<Computer> lanParty)
    {
        return InternalFindCliques().SelectMany(x => x);

        IEnumerable<IEnumerable<Computer[]>> InternalFindCliques()
        {
            foreach (Computer c1 in lanParty)
            {
                foreach (Computer c2 in c1.Connections)
                {
                    yield return c1.Connections
                        .Intersect(c2.Connections)
                        .Select(c3 =>
                        {
                            List<Computer> result = [c1, c2, c3];
                            result.Sort();
                            return result.ToArray();
                        });
                }
            }
        }
    }
}