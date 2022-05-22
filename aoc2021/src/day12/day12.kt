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


