package day02

fun main() {
    val input = readInput()

    val endPosition = input.fold(Position()) { p, m -> p.naivelyAdd(m) }
    val part1 = endPosition.x * endPosition.depth
    println("part 1:  $part1")


}