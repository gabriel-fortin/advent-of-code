package day05

import kotlin.math.min
import kotlin.math.max

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
    val maxX = input.map { max(it.x1, it.x2) }.reduce(::max)
    val maxY = input.map { max(it.y1, it.y2) }.reduce(::max)
    return maxX to maxY
}

fun generateLinePoints(line: Line): List<Pair<Int, Int>> {
    val x1 = min(line.x1, line.x2)
    val x2 = max(line.x1, line.x2)
    val y1 = min(line.y1, line.y2)
    val y2 = max(line.y1, line.y2)

    val xStep = if (x1==x2) 0 else 1
    val yStep = if (y1==y2) 0 else 1

    val pointCount = max(x2 - x1, y2 - y1) + 1
    return List(pointCount) { i -> Pair(x1 + i * xStep, y1 + i * yStep) }
}

fun List<MutableList<Int>>.updateWith(line: Line) {
    generateLinePoints(line)
        .forEach { (x, y) -> this[y][x]++ }
//    if (line.x1 == line.x2) {
//        val x = line.x1
//        // y1 could be either greater or smaller than y2, so we try both ways
//        (line.y1..line.y2).forEach { y -> this[y][x]++ }
//        (line.y2..line.y1).forEach { y -> this[y][x]++ }
//    }
//    if (line.y1 == line.y2) {
//        val y = line.y1
//        // x1 could be either greater or smaller than x2, so we try both ways
//        (line.x1..line.x2).forEach { x -> this[y][x]++ }
//        (line.x2..line.x1).forEach { x -> this[y][x]++ }
//    }

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
