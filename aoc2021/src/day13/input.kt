package day13

import java.io.File

fun getInput() =
//    getTestInput()
    getRealInput()


fun getRealInput(): List<String> {
    return File("input.txt")
        .readLines()
}

@Suppress("unused")
fun getTestInput() = listOf("hello")
