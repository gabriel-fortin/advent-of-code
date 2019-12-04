package aoc2019.day01

fun main(args: Array<String>) {
    val input = preprocess(rawInput)

    val part1: Int = input
            .map { x -> (x / 3) - 2 }
            .sum()
    println("part1: $part1")
}

