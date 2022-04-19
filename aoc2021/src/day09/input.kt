package day09

import java.io.File

//fun getInput() = getTestInput()
fun getInput() = getRealInput()

@Suppress("unused")
fun getTestInput() = listOf(
    listOf(2,1,9,9,9,4,3,2,1,0),
    listOf(3,9,8,7,8,9,4,9,2,1),
    listOf(9,8,5,6,7,8,9,8,9,2),
    listOf(8,7,6,7,8,9,6,7,8,9),
    listOf(9,8,9,9,9,6,5,6,7,8),
)

fun getRealInput(): List<List<Int>> =
    File("input.txt")
        .readLines()
        .map { it.toList().map(::charToInt) }

fun charToInt(c: Char): Int {
    if (c < '0') throw IllegalArgumentException("character '$c' is smaller than '0'")
    if (c > '9') throw IllegalArgumentException("character '$c' is bigger than '9'")
    return c - '0'
}
