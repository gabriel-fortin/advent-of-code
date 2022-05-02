package day11

import shared.Grid

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

    val part2 = part2(input)
    println("part 2: $part2")
}

fun part1(input: List<List<Int>>): Int {
    val simulation = OctopusSimulation(octopusGridFromInput(input))
    repeat(100) { simulation.simulateStep() }
    return simulation.totalFlashes
}

fun part2(input: List<List<Int>>): Int {
    val simulation = OctopusSimulation(octopusGridFromInput(input))

    return generateSequence { }
        .onEach { simulation.simulateStep() }
        .takeWhile { simulation.flashesInStep != 100 }
        .onEach { println(simulation.flashesInStep) }
        .count() + 1
}

private fun octopusGridFromInput(input: List<List<Int>>): Grid<Octopus> {
    val inputMappedToOctopuses = input.map { it.map(Octopus::fromEnergyLevel) }
    return Grid(inputMappedToOctopuses)
}


