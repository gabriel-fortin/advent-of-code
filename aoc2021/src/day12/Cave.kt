package day12

import shared.Graph

class Cave(val name: String): Graph.Node<Cave>() {
    val isSmallCave = name == name.lowercase()
}