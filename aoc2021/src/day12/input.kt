package day12

import java.io.File

fun getInput(): List<Pair<String, String>> =
//    getTestInput1()
//    getTestInput2()
    getRealInput()

fun getRealInput(): List<Pair<String, String>> {
    val lineRegex = Regex("""(\w+)-(\w+)""")
    return File("input.txt")
        .readLines()
        .map { lineRegex.matchEntire(it)!!.groupValues }
        .map { it[1] to it[2] }
}

@Suppress("unused")
fun getTestInput1(): List<Pair<String, String>> =
    listOf(
        "start" to "A",
        "start" to "b",
        "A" to "c",
        "A" to "b",
        "b" to "d",
        "A" to "end",
        "b" to "end",
    )

@Suppress("unused")
fun getTestInput2(): List<Pair<String, String>> =
    listOf(
        "dc" to "end",
        "HN" to "start",
        "start" to "kj",
        "dc" to "start",
        "dc" to "HN",
        "LN" to "dc",
        "HN" to "end",
        "kj" to "sa",
        "kj" to "HN",
        "kj" to "dc",
    )

@Suppress("unused")
fun getTestInput3(): List<Pair<String, String>> =
    listOf(
        "fs" to "end",
        "he" to "DX",
        "fs" to "he",
        "start" to "DX",
        "pj" to "DX",
        "end" to "zg",
        "zg" to "sl",
        "zg" to "pj",
        "pj" to "he",
        "RW" to "he",
        "fs" to "DX",
        "pj" to "RW",
        "zg" to "RW",
        "start" to "pj",
        "he" to "WI",
        "zg" to "he",
        "pj" to "fs",
        "start" to "RW",
    )
