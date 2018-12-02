package aoc2018.day01

fun main(args: Array<String>) {
    val input = preprocess(rawInput)

    val finalFrequency = input.fold(0, Int::plus)

    println("Result: $finalFrequency")
}
