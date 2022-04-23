package day10

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

    val part2 = part2(input)
    println("part 2: $part2")
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

fun part2(lines: List<String>): Long {
    val scoresForUnfinishedLines = lines
        .asSequence() // to (allegedly) improve performance of a call chain on a collection
        .map { ChunkMachine(it).analyse() }
        .filterIsInstance<ChunkMachine.AnalysisResult.ChunkIsIncomplete>()
        .map(::scoreForCompletingTheLine)
        .sorted()
        .toList()

    // the middle element is the answer; we're promised that this list will be odd-sized
    return scoresForUnfinishedLines[scoresForUnfinishedLines.size / 2]
}

fun scoreForCompletingTheLine(chunkIncompleteResult: ChunkMachine.AnalysisResult.ChunkIsIncomplete): Long =
    chunkIncompleteResult
        // the stack of unclosed chunks contains the needed closing characters
        .unclosedChunks
        // in reverse order (hence folding from right)
        .foldRight(0L) { character, acc ->
            acc * 5 + pointsForChunkClosing(character)
        }

fun pointsForChunkClosing(character: Char): Int = when (character) {
    '(' -> 1
    '[' -> 2
    '{' -> 3
    '<' -> 4
    else -> throw Exception("Illegal character '$character' cannot be valued")
}

fun pointsForIllegalCharacter(c: Char): Int = when (c) {
    ')' -> 3
    ']' -> 57
    '}' -> 1197
    '>' -> 25137
    else -> throw Exception("Illegal character '$c' cannot be scored")
}