package day02

fun main() {
    val endPosition = readInput()
        .fold(Position()) { p, m -> p.plus(m) }
    val part1 = endPosition.x * endPosition.z * -1 // because depth is positive for negative z values and vice versa
    println("part 1:  $part1")
}