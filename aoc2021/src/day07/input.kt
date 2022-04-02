package day07

import java.io.File

//fun getInput() = getTestInput()
fun getInput() = getRealInput()

@Suppress("unused")
fun getTestInput() = listOf(16,1,2,0,4,2,7,1,2,14)

fun getRealInput(): List<Int> {
    return File("input.txt")
        .readLines()
        .first()
        .split(',')
        .map(Integer::parseInt)
}
