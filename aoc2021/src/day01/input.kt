package day01

import java.io.File

fun readInput(): List<Int> =
    File("input.txt")
        .readLines()
        .map(Integer::parseInt)
