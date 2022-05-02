package day11

import shared.Grid
import java.io.File

fun getInput() = getTestInput()
//fun getInput() = getRealInput()

@Suppress("unused")
fun getTestInput() =
    listOf(
        "5483143223",
        "2745854711",
        "5264556173",
        "6141336146",
        "6357385478",
        "4167524645",
        "2176841721",
        "6882881134",
        "4846848554",
        "5283751526",
    )
        .map(splitStringIntoIntegers)
        .map { it.map(Octopus::fromEnergyLevel) }
        .let(::Grid)

val splitStringIntoIntegers = fun(s: String): List<Int> {
    return s.toList().map { it - '0' }
}

fun getRealInput(): Grid<Octopus> {
    return File("input.txt")
        .readLines()
        .map(splitStringIntoIntegers)
        .map { it.map(Octopus::fromEnergyLevel) }
        .let(::Grid)
}
