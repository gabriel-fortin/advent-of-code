package day12


fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

//    val part2 = part2(input)
//    println("part 2: $part2")
}

fun part1(pairs: List<Pair<String, String>>): Int {
    val pathFindingGraph = PathsVisitingSmallCavesAtMostOnce(pairs)
    val paths = pathFindingGraph.findPaths()
    return paths.count()
}


/**
 * assumption: input doesn't contain duplicated edges
 */
open class Graph(edgesList: List<Pair<String, String>>) {
    val nodes = mutableMapOf<String, Node>()
    init {
        for ((name1, name2) in edgesList) {
            // find node by name or create new
            val node1 = nodes.getOrPut(name1) { Node(name1, name1 == name1.lowercase()) }
            val node2 = nodes.getOrPut(name2) { Node(name2, name2 == name2.lowercase()) }

            // we assume input doesn't have duplicated edges
            node1.neighbours.add(node2)
            node2.neighbours.add(node1)
        }
    }

    open class Node(val name: String, val isSmallCave: Boolean) {
        val neighbours = mutableSetOf<Node>()
    }
}

class PathsVisitingSmallCavesAtMostOnce(edgesList: List<Pair<String, String>>) : Graph(edgesList) {
    private val validPaths = mutableListOf<Path>()

    fun findPaths(): List<Path> {
        if (validPaths.isNotEmpty()) throw IllegalStateException("This method is not meant to be run multiple times")

        val startNode = nodes["start"] ?: throw NoSuchElementException("Cannot find start node")
        findRecursively(Path(startNode))

        return validPaths
    }

    // DFS on the graph
    private fun findRecursively(pathSoFar: Path) {
        val lastNodeOnPath = pathSoFar.nodes.last()
        lastNodeOnPath.neighbours.forEach tryNode@{ newNode ->
            val extendedPath = pathSoFar + newNode
            if (newNode.name == "end") {
                validPaths += extendedPath
                return@tryNode
            }
            if (newNode.isSmallCave && pathSoFar.nodes.contains(newNode)) {
                // small caves are allowed to be visited only once
                return@tryNode
            }
            findRecursively(extendedPath)
        }
    }
}

data class Path(val nodes: List<Graph.Node>) {
    constructor(node: Graph.Node) : this(listOf(node))
    operator fun plus(newNode: Graph.Node): Path = this.copy(nodes = nodes + newNode)
}
