using System.Collections.Immutable;

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
        IEnumerable<(string, string)> connections = Input.GetInput(inputSelector)
            .Split(Environment.NewLine)
            .Select(s => (name1: s[..2], name2: s[3..]));

        List<Computer> network = ParseNetwork(connections);

        Computer[] largestClique = FindLargestClique(network);
        IEnumerable<string> computersInLanParty = largestClique.Select(x => x.Name);
        return string.Join(',', computersInLanParty);
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
        
        foreach (Computer computer in network.Values)
        {
            computer.SortConnections();
        }

        return network.Values.OrderBy(x => x.Name).ToList();
    }

    private static IEnumerable<Computer[]> FindCliquesOfSize3(List<Computer> network)
    {
        foreach (Computer c1 in network)
        {
            foreach (Computer c2 in c1.Connections)
            {
                IEnumerable<List<Computer>> cliquesOfSize3 =
                    c1.Connections
                        .Intersect(c2.Connections)
                        .Select(c3 => (List<Computer>) [c1, c2, c3]);

                foreach (var clique in cliquesOfSize3)
                {
                    // canonical order: computers are sorted by name
                    clique.Sort();
                    yield return clique.ToArray();
                }
            }
        }
    }

    private static Computer[] FindLargestClique(ICollection<Computer> network)
    {
        Computer[] largestClique = [];
        FindCliques(
            startingClique: ImmutableList<Computer>.Empty,
            availableNodes: network.ToArray(),
            onCliqueFound: KeepLargerClique);
        return largestClique;

        void KeepLargerClique(ImmutableList<Computer> clique)
        {
            if (clique.Count > largestClique.Length)
            {
                largestClique = clique.ToArray();
            }
        }

        void FindCliques(ImmutableList<Computer> startingClique, Span<Computer> availableNodes,
            Action<ImmutableList<Computer>> onCliqueFound)
        {
            onCliqueFound(startingClique);
            
            if (availableNodes.Length == 0) return;

            for (int i = 0; i < availableNodes.Length; i++)
            {
                Computer c = availableNodes[i];
                if (IsElementPartOfClique(c, startingClique))
                {
                    FindCliques(startingClique.Add(c), availableNodes.Slice(i + 1), onCliqueFound);
                }
            }
        }

        bool IsElementPartOfClique(Computer element, IList<Computer> clique)
        {
            for (int i = 0, j = 0; i < clique.Count; i++)
            {
                Computer c = clique[i];
                while (j < element.Connections.Count && element.Connections[j].CompareTo(c) < 0)
                {
                    j++;
                }

                if (j >= element.Connections.Count || element.Connections[j].Name != c.Name)
                {
                    return false;
                }
            }

            return true;
        }
    }
}