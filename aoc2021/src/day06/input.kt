package day06

import java.io.File

//fun getInput() = getTestInput()
fun getInput() = getRealInput()

@Suppress("unused")
fun getTestInput() = listOf(3,4,3,1,2)

fun getRealInput(): List<Int> {
    return File("input.txt")
        .readLines()
        .first()
        .split(',')
        .map(Integer::parseInt)
}
