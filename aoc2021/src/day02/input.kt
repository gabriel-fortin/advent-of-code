package day02

import java.io.File

fun readInput(): List<Movement> =
    File("input.txt")
        .readLines()
        .map(::parseLineAsMovement)

val LINE_PATTERN = Regex("(?<movement>\\w+) (?<distance>\\d+)")

fun parseLineAsMovement(line: String): Movement {
    val matchResult = LINE_PATTERN.matchEntire(line)!!
    val distance = matchResult.groups["distance"]!!.value.let(Integer::parseInt)
    return when (val direction = matchResult.groups["movement"]!!.value) {
        "forward" -> Movement.Forward(distance)
        "down" -> Movement.Down(distance)
        "up" -> Movement.Up(distance)
        else -> throw Exception("Unrecognised movement '$direction'")
    }
}
