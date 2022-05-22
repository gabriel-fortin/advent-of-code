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
 * assumption: distinct nodes have distinct names
 */
open class Graph<TNode : Graph.Node<TNode>> {
    val nodes = mutableMapOf<String, TNode>()

    fun putNode(key: String, node: TNode) = nodes.put(key, node)
    fun getOrPutNode(key: String, defaultValue: () -> TNode) = nodes.getOrPut(key, defaultValue)

    fun addEdge(node1: TNode, node2: TNode) {
        node1.neighbours.add(node2)
        node2.neighbours.add(node1)
    }

    open class Node<TNode> {
        val neighbours = mutableSetOf<TNode>()
    }
}

class PathsVisitingSmallCavesAtMostOnce(edgesList: List<Pair<String, String>>) : Graph<Cave>() {
    init {
        for ((name1, name2) in edgesList) {
            // find node by name or create new
            val node1 = getOrPutNode(name1) { Cave(name1) }
            val node2 = getOrPutNode(name2) { Cave(name2) }

            // we assume input doesn't have duplicated edges and don't check it
            addEdge(node1, node2)
        }
    }

    private val validPaths = mutableListOf<Path<Cave>>()

    fun findPaths(): List<Path<Cave>> {
        if (validPaths.isNotEmpty()) throw IllegalStateException("This method is not meant to be run multiple times")

        val startNode = nodes["start"] ?: throw NoSuchElementException("Cannot find start node")
        findRecursively(Path(startNode))

        return validPaths
    }

    // DFS on the graph
    private fun findRecursively(pathSoFar: Path<Cave>) {
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

class Cave(val name: String): Graph.Node<Cave>() {
    val isSmallCave = name == name.lowercase()
}

data class Path<TNode>(val nodes: List<TNode>) {
    constructor(node: TNode) : this(listOf(node))
    operator fun plus(newNode: TNode): Path<TNode> = this.copy(nodes = nodes + newNode)
}
