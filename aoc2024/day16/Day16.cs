using Advent_of_Code_2024.day15;
using static Advent_of_Code_2024.day16.Tile.TileType;

namespace Advent_of_Code_2024.day16;

public static partial class Day16
{
    public static string Part1(InputSelector inputSelector)
    {
        // terminology:
        // score - applies to a tile; the meaning as in the puzzle
        // node - a graph node; each tile has four of them, one for each direction
        // cost - applies to edges between nodes; indicates score cost when following the edge (moving between connected nodes)

        // we will transform the input into a graph
        // the graph is directed and has non-negative edge costs
        // so we can run Dijkstra's algorithm for finding the shortest path
        // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm

        // for each non-wall tile we create 4 nodes: one for each direction
        // at first, all nodes get a score of long.MaxValue (except the starting node)
        // edges between the 4 nodes of a tile (representing reindeer turns) get a cost of 1000
        // edges to nodes of neighbouring tiles get a cost of 1
        // (just remember, East node of a tile has to connect to the East node of a neighbouring tile etc.)

        // find lowest-scoring paths

        // return lowest scores among nodes of the end tile

        string rawInput = Input.GetInput(inputSelector);
        Tile[] tiles = Parsing.ParseNonWallTiles(rawInput).ToArray();
        Matrix<Tile?> matrix = Parsing.BuildMatrix(tiles);

        BuildGraphFromTileNodes(tiles, matrix);

        Node startingNode = tiles.Single(x => x.Type == Start).Nodes[Direction.East];
        Dijkstra(tiles, startingNode);

        return tiles
            .Single(x => x.Type == End)
            .Score.ToString();
    }

    public static string Part2(InputSelector inputSelector)
    {
        string rawInput = Input.GetInput(inputSelector);
        Tile[] tiles = Parsing.ParseNonWallTiles(rawInput).ToArray();
        Matrix<Tile?> matrix = Parsing.BuildMatrix(tiles);

        BuildGraphFromTileNodes(tiles, matrix);

        Node startingNode = tiles.Single(x => x.Type == Start).Nodes[Direction.East];
        Dijkstra(tiles, startingNode);

        return CountBestPathTiles(tiles).ToString();
    }

    private static void BuildGraphFromTileNodes(Tile[] tiles, Matrix<Tile?> matrix)
    {
        foreach (Tile tile in tiles)
        {
            foreach (Direction direction in Direction.All)
            {
                Tile? neighbourTile = matrix.Get(tile.Position.After(direction));
                if (neighbourTile == null) continue;

                tile.ConnectTo(neighbourTile, direction);
            }
        }
    }

    /// <summary>
    /// Finds shortest (lowest score) paths between starting node and all other nodes
    /// </summary>
    private static void Dijkstra(Tile[] allTiles, Node startingNode)
    {
        // create a processing queue, sorted by node's score
        SortedSet<Node> processingQueue = new SortedSet<Node>(new Node.ScoreComparer());
        foreach (Tile tile in allTiles)
        {
            foreach (Node node in tile.Nodes.Values)
            {
                node.Score = long.MaxValue;
                processingQueue.Add(node);
            }
        }

        // to begin with, only the starting node has a computed score
        UpdateScore(startingNode, 0);

        while (processingQueue.Count != 0)
        {
            // get an unprocessed node having the lowest score
            Node node = processingQueue.Min!;
            processingQueue.Remove(node);

            foreach (Node neighbourNode in node.Edges.Keys)
            {
                // try to improve neighbour's score
                // and keep track of how to get to the node in a lowest-score manner
                long alternativeScore = node.Score + node.Edges[neighbourNode];
                if (alternativeScore == neighbourNode.Score)
                {
                    neighbourNode.PrevNodesForBestPath.Add(node);
                }
                else if (alternativeScore < neighbourNode.Score)
                {
                    neighbourNode.PrevNodesForBestPath.Clear();
                    neighbourNode.PrevNodesForBestPath.Add(node);
                    UpdateScore(neighbourNode, alternativeScore);
                }
            }
        }

        return;

        void UpdateScore(Node n, long score)
        {
            processingQueue.Remove(n);
            n.Score = score;
            processingQueue.Add(n);
        }
    }

    /// Counts tiles that are part of a best path
    private static int CountBestPathTiles(Tile[] allTiles)
    {
        var bestPathNodes = new HashSet<Node>();
        IEnumerable<Node> endTileNodes = allTiles.Single(x => x.Type == End).Nodes.Values;
        foreach (Node node in endTileNodes.Where(x => x.Score == x.Tile.Score))
        {
            Visit(node);
        }
        return bestPathNodes.Select(x => x.Tile).Distinct().Count();

        void Visit(Node node)
        {
            bool nodeWasAlreadyVisited = !bestPathNodes.Add(node);
            if (nodeWasAlreadyVisited) return;
            
            foreach (Node bestPathNeighbour in node.PrevNodesForBestPath)
            {
                Visit(bestPathNeighbour);
            }
        }
    }
}