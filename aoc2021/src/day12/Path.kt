package day12

data class Path<TNode>(val nodes: List<TNode>) {
    constructor(node: TNode) : this(listOf(node))
    operator fun plus(newNode: TNode): Path<TNode> = this.copy(nodes = nodes + newNode)
}