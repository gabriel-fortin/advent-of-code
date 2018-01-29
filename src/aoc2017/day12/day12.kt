package aoc2017.day12

fun main(args: Array<String>) {

//    rawInput.lines().take(4).forEach { println("> $it") }

//    val graph: MutableMap<Int, MutableList<Int>> = mutableMapOf()
//    val visited: MutableSet<Int> = mutableSetOf()

    val graph: Graph<Wrapper> = Graph { Wrapper(false) }

//    """
//        0 <-> 2
//        1 <-> 1, 19
//        2 <-> 0, 3, 4
//        3 <-> 2, 4
//        4 <-> 2, 3, 6
//        5 <-> 6
//        6 <-> 4, 5
//        19 <-> 1
//    """
    rawInput
            .lines()
            .filterNot(String::isBlank)
            .map { line ->
                val g = Regex("(\\d+) <-> (\\d+[,\\s*\\d+]*)")
                        .find(line)
                        ?.groupValues
                        ?: throw Exception("regex match failure, text: \"$line\"")
                val node: Int = g[1].toInt()
                val children: List<Int> = g[2]
                        .split(',')
                        .map(String::trim)
                        .map(String::toInt)

                println("  $node -> $children")

                graph.addNode(node, children)

            }

    graph.print()

    // part 1
    var groupSize = 0
    graph.dfs(0, { n -> groupSize++ ; n.extra.visited = true})
    println(groupSize)

    // part 2
    val allNodes = graph.getAllNodes()
    val iterator = allNodes.iterator()
    var groupCount = 1
    while (iterator.hasNext()) {
        val (nodeNumber, nodeExtra) = iterator.next()
        if (nodeExtra.visited) continue
        groupCount++
        graph.dfs(nodeNumber, { n -> n.extra.visited = true})
    }
    println(groupCount)

}

class Wrapper(var visited: Boolean = false)


/**
 * T - type of extra data carried by each node
 */
class Graph<T>(val nodeExtraCreator: () -> T) {
    private val allNodes: MutableMap<Int, Node<T>> = mutableMapOf()

    fun getAllNodes(): Map<Int, T> {
        return allNodes.mapValues { (k, v) -> v.extra }
    }

    fun addNode(id: Int, neighbours: List<Int>) {
        val n: Node<T> = allNodes.getOrPut(id) { Node(id, nodeExtraCreator()) }

        val nodeNeighbours = neighbours
                .map { allNodes.getOrPut(it) { Node(it, nodeExtraCreator()) } }

        n.addNeighbours(nodeNeighbours)

        nodeNeighbours.forEach { it.addNeighbour(n) }
    }

    fun dfs(startNode: Int, visit: (Node<T>) -> Unit) {
        val node = allNodes[startNode] ?: throw Exception("node $startNode not found")
        internalDfs(node, visit)
    }

    private fun internalDfs(node: Node<T>, visit: (Node<T>) -> Unit) {
        if (node.wasVisited) return

        node.wasVisited = true
        visit(node)
        for (n in node.getNeighbours()) {
            internalDfs(n, visit)
        }
    }

    fun print() {
        allNodes.forEach { (k, v) ->
            print("   ${v.id} -> ${v.getNeighbours().map { it.id } }")
            println()
        }
    }


    class Node<T>(val id: Int, var extra: T) {
        private val neighbours: MutableSet<Node<T>> = mutableSetOf()

        // to be used by the Graph class during dfs/bfs
        var wasVisited: Boolean = false

        fun addNeighbour(node: Node<T>) {
            neighbours.add(node)
        }

        fun addNeighbours(nodes: List<Node<T>>) {
            neighbours.addAll(nodes)
        }

        fun getNeighbours(): List<Node<T>> {
            return neighbours.toList()
        }
    }
}


