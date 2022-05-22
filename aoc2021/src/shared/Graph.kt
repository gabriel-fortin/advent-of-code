package shared

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
