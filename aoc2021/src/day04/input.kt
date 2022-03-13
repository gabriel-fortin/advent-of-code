package day04

import java.io.File

fun readInput(): List<String> {
    return File("input.txt")
        .readLines()
}
