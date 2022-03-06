package day02

fun main() {
    val input = readInput()

    val endPosition = input.fold(Position()) { p, m -> p.naivelyAdd(m) }
    val part1 = endPosition.x * endPosition.depth
    println("part 1:  $part1")

    val endPosition2 = input.fold(Position()) { p, m -> p.advancedAdd(m) }
    val part2 = endPosition2.x * endPosition2.depth
    println("part 2:  $part2")

}