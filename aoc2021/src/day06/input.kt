package day06

import java.io.File

fun getInput(): String {
    return File("input.txt")
        .readLines()
        .first()
}