package day10

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

//    val part2 = part2(input)
//    println("part 2: $part2")
}

fun part1(lines: List<String>): Int {
    return lines
        .asSequence() // to (allegedly) improve performance of a call chain on a collection
        .map { ChunkMachine(it).analyse() }
        .filterIsInstance<ChunkMachine.AnalysisResult.UnexpectedClosingChunk>()
        .map { it.incorrectClosingCharacter }
        .map(::pointsForIllegalCharacter)
        .sum()
}

fun pointsForIllegalCharacter(c: Char): Int = when (c) {
    ')' -> 3
    ']' -> 57
    '}' -> 1197
    '>' -> 25137
    else -> throw Exception("Illegal character '$c' cannot be scored")
}