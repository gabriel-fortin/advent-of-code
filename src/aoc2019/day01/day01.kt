package aoc2019.day01

fun main(args: Array<String>) {
    val input = preprocess(rawInput)

    println("part1: ${part1(input)}")
}

fun part1(masses: List<Int>): Int {
    return masses
            .map(::calculateFuelRequirementForMass)
            .sum()
}

fun calculateFuelRequirementForMass(mass: Int): Int {
    return (mass / 3) - 2
}

