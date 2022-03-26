package day05

import java.lang.Integer.max

const val DEBUG = false

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part1: $part1")
}

fun part1(input: List<Line>): Int {
    val (maxX, maxY) = getMaxCoordinateValues(input)
    val matrix: List<MutableList<Int>> = List(maxY + 1) { MutableList(maxX + 1) { 0 } }

    input
        // consider only vertical and horizontal lines (as required for part 1)
        .filter { line -> line.x1 == line.x2 || line.y1 == line.y2 }
        .forEach { line -> matrix.updateWith(line) }

    return matrix.flatten().count { it > 1 }
}

fun getMaxCoordinateValues(input: List<Line>): Pair<Int, Int> {
    val maxX = input
        .map { max(it.x1, it.x2) }
        .reduce(::max)
    val maxY = input
        .map { max(it.y1, it.y2) }
        .reduce(::max)
    return maxX to maxY
}

fun List<MutableList<Int>>.updateWith(line: Line) {
    if (line.x1 == line.x2) {
        val x = line.x1
        // y1 could be either greater or smaller than y2, so we try both ways
        (line.y1..line.y2)
            .forEach { y -> this[y][x]++ }
        (line.y2..line.y1)
            .forEach { y -> this[y][x]++ }
    }
    if (line.y1 == line.y2) {
        val y = line.y1
        // x1 could be either greater or smaller than x2, so we try both ways
        (line.x1..line.x2)
            .forEach { x -> this[y][x]++ }
        (line.x2..line.x1)
            .forEach { x -> this[y][x]++ }
    }

    if (DEBUG) {
        println("$line")
        this.forEach { row ->
            row.forEach {
                when (it) {
                    0 -> print("  . ")
                    else -> print(String.format("%1$3d", it) + " ")
                }
            }
            println()
        }
        println()
    }
}
