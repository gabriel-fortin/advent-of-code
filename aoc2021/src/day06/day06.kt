package day06

const val DEBUG = true

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part1: $part1")

    val part2 = part2(input)
    println("part2: $part2")
}

fun part1(input: List<Int>): Int = simulateGrowthOfSchoolOfFish(input, 80)

fun part2(input: List<Int>): Int = simulateGrowthOfSchoolOfFish(input, 256)

private fun simulateGrowthOfSchoolOfFish(input: List<Int>, simulationLength: Int): Int {
    val currentFish = input.toMutableList()
    repeat(simulationLength) {
        if (DEBUG && it % 10 == 0) print(".")
        currentFish.indices.forEach { i -> currentFish.updateFish(i) }
    }
    if (DEBUG) println()
    return currentFish.count()
}

private fun MutableList<Int>.updateFish(i: Int) {
    when (this[i]) {
        0 -> {
            this[i] = 6
            this.add(8)
        }
        else -> this[i]--
    }
}
