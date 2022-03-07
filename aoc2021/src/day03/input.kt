package day03

import java.io.File

fun readInputNumbers(): List<Int> {
    return File("input.txt")
        .readLines()
        .map { Integer.parseInt(it, 2) }
}
