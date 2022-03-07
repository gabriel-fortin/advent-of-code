package day01

fun main() {
    val input = readInput()

    part1Procedural(input)
    part1Functional(input)

    part2Procedural(input)
    part2ProceduralClever(input)
    part2Functional(input)
}

fun part1Procedural(input: List<Int>) {
    val result = sumIncrements(input)
    println(result)
}

fun part1Functional(input: List<Int>) {
    input
        .zipWithNext(::oneIfValueIncrements)
        .sum()
        .also(::println)
}

fun part2Procedural(input: List<Int>) {
    val trioSequence = createTrioSums(input)
    val result = sumIncrements(trioSequence)
    println(result)
}

fun part2ProceduralClever(input: List<Int>) {
    var trioSum = input[0] + input[1] + input[2]
    var result = 0
    for (i in 0 until input.size - 3) {
        val newTrioSum = trioSum - input[i] + input[i + 3]
        if (newTrioSum > trioSum) result++
        trioSum = newTrioSum
    }
    println(result)
}

fun part2Functional(input: List<Int>) {
    input
        .zipWithNext()
        .zipWithNext { a, b -> a.first + a.second + b.second }
        .zipWithNext(::oneIfValueIncrements)
        .sum()
        .also(::println)
}

fun oneIfValueIncrements(prevValue: Int, nextValue: Int): Int = when {
    (nextValue > prevValue) -> 1
    else -> 0
}

private fun createTrioSums(input: List<Int>): MutableList<Int> {
    val trioSequence = mutableListOf<Int>()
    for (i in 2 until input.size) {
        val trioSum = input[i - 2] + input[i - 1] + input[i]
        trioSequence.add(trioSum)
    }
    return trioSequence
}

fun sumIncrements(input: List<Int>): Int {
    var result = 0
    for (i in 1 until input.size) {
        if (input[i] > input[i - 1]) result++
    }
    return result
}
