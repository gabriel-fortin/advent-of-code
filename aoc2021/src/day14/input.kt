package day14

import java.io.File

fun getInput() =
//    getTestInput()
    getRealInput()


fun getRealInput(): List<String> {
    return File("input.txt")
        .readLines()
}

@Suppress("unused")
fun getTestInput() = listOf(
    "NNCB",
    "",
    "CH -> B",
    "HH -> N",
    "CB -> H",
    "NH -> C",
    "HB -> C",
    "HC -> B",
    "HN -> C",
    "NN -> C",
    "BH -> H",
    "NC -> B",
    "NB -> B",
    "BN -> B",
    "BB -> N",
    "BC -> B",
    "CC -> N",
    "CN -> C",
)
