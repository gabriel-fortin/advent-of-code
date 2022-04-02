package day06

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part1: $part1")

    val part2 = part2(input)
    println("part2: $part2")
}

fun part1(input: List<Int>): Int = simulateGrowthOfSchoolOfFish(input, 80)

fun part2(input: List<Int>): Long {
    // prepare structure and populate it with input
    val fishGroups = MutableList(7) { i -> FishGroup(fishTimer = i, count = 0) }
    input.forEach { timer ->
        fishGroups
            .single { it.fishTimer == timer }
            .addFish()
    }

    // simulate fish school growth
    repeat(256) {
        var newSpawns = 0L
        fishGroups.forEach { group ->
            group.advanceTimer { newSpawnsCount -> newSpawns += newSpawnsCount }
        }
        fishGroups.add(FishGroup(fishTimer = 8, count = newSpawns))

        // merge groups having same fish timer, if more optimisation required
    }

    return fishGroups.sumOf { it.count }
}


@Suppress("SameParameterValue")
private fun simulateGrowthOfSchoolOfFish(input: List<Int>, simulationLength: Int): Int {
    val currentFish = input.toMutableList()
    repeat(simulationLength) {
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
