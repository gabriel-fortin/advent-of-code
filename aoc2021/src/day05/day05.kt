package day05

import kotlin.math.abs
import kotlin.math.max

const val DEBUG = false

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part1: $part1")

    val part2 = part2(input)
    println("part2: $part2")
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

fun part2(inputLines: List<Line>): Int {
    val (maxX, maxY) = getMaxCoordinateValues(inputLines)
    val matrix: List<MutableList<Int>> = List(maxY + 1) { MutableList(maxX + 1) { 0 } }

    inputLines.forEach { matrix.updateWith(it) }

    return matrix.flatten().count { it > 1 }
}

fun getMaxCoordinateValues(input: List<Line>): Pair<Int, Int> {
    val maxX = input.map { max(it.x1, it.x2) }.reduce(::max)
    val maxY = input.map { max(it.y1, it.y2) }.reduce(::max)
    return maxX to maxY
}

fun generateLinePoints(line: Line): List<Pair<Int, Int>> {
    val xStep = when {
        line.x1 > line.x2 -> -1
        line.x1 < line.x2 -> 1
        else -> 0
    }
    val yStep = when {
        line.y1 > line.y2 -> -1
        line.y1 < line.y2 -> 1
        else -> 0
    }
    val pointCount = max(abs(line.x2 - line.x1), abs(line.y2 - line.y1)) + 1
    return List(pointCount) { i -> Pair(line.x1 + i * xStep, line.y1 + i * yStep) }
}

fun List<MutableList<Int>>.updateWith(line: Line) {
    generateLinePoints(line)
        .forEach { (x, y) -> this[y][x]++ }

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
