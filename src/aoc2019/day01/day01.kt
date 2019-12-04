package aoc2019.day01

import kotlin.math.max

fun main(args: Array<String>) {
    val input = preprocess(rawInput)

    println("part1: ${part1(input)}")

    println("part2: ${part2(input)}")
}

fun part1(masses: List<Int>): Int {
    return masses
            .map(::calculateFuelRequirementForMass)
            .sum()
}

fun part2(masses: List<Int>): Int {
    return masses
            .map(::calculateReappliedFuelRequirementForMass)
            .sum()
}

fun calculateFuelRequirementForMass(mass: Int): Int {
    return (mass / 3) - 2
}

fun calculateReappliedFuelRequirementForMass(mass: Int): Int {
    var totalFuelRequirement = 0
    var partialFuelReq: Int
    var currentMass = mass

    do {
        partialFuelReq = max(0, calculateFuelRequirementForMass(currentMass))
        totalFuelRequirement += partialFuelReq
        currentMass = partialFuelReq
    } while (partialFuelReq > 0)

    return totalFuelRequirement
}

