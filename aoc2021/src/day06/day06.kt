package day06

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part1: $part1")

//    val part2 = part2(input)
//    println("part2: $part2")
}

const val SIMULATION_LENGTH = 80
fun part1(input: List<Int>): Int {
    val currentFish = input.toMutableList()
    repeat(SIMULATION_LENGTH) {
        currentFish.indices.forEach { i -> currentFish.updateFish(i) }
    }
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
