package day04

import java.io.File
import kotlin.test.assertEquals

fun readInput(): InputCollection {
    val inputLines = File("input.txt").readLines()

    val numbersToDraw = inputLines
        .first()
        .split(',')
        .map(Integer::parseInt)

    val boards: List<BingoBoard> = inputLines
        .drop(1)  // drop numbers to draw
        .chunked(size = 6, transform = ::linesIntoBoard)

    return InputCollection(numbersToDraw, boards)
}

fun linesIntoBoard(lines: List<String>): BingoBoard {
    assertEquals(BOARD_SIZE + 1, lines.size,
        "We want to read an empty line before the board's values")
    val valuesForBoard = lines
        .drop(1)  // empty line
        .joinToString(" ")
        .split(Regex("\\s+"))
        .filter(String::isNotEmpty)
        .map(Integer::parseInt)
    return BingoBoard(valuesForBoard)
}

