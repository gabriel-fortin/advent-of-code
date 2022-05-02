package day11

import shared.Grid

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

//    val part2 = part2(input)
//    println("part 2: $part2")
}

fun part1(grid: Grid<Octopus>): Int {
    val simulation = OctopusSimulation(grid)
    simulation.simulate(100)
    return simulation.totalFlashes
}


