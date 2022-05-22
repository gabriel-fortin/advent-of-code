package day12

import shared.Graph

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