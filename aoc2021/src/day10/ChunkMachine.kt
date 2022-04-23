package day10

import java.util.*

val OPENING_CHARACTERS: List<Char> = "([{<".toList()
val CLOSING_CHARACTERS: List<Char> = ")]}>".toList()

class ChunkMachine(private val inputCharacters: String) {
    private val chunksStack = Stack<Char>()

    fun analyse(): AnalysisResult {
        inputCharacters.forEach { c ->
            // edge case but can can be triggered by as simple input as "]"
            if (c in CLOSING_CHARACTERS && chunksStack.isEmpty()) {
                return AnalysisResult.UnexpectedClosingChunk(chunksStack, c)
            }
            when (c) {
                in OPENING_CHARACTERS -> chunksStack.push(c)
                closingCharForLastOpenedChunk -> chunksStack.pop()
                in CLOSING_CHARACTERS -> return AnalysisResult.UnexpectedClosingChunk(chunksStack, c)
                else -> throw IllegalArgumentException("Something unexpected happened; character: '$c'," +
                        " stack: ${chunksStack.joinToString("")}")
            }
        }
        if (!chunksStack.isEmpty()) {
            return AnalysisResult.ChunkIsIncomplete(chunksStack)
        }
        return AnalysisResult.ChunkIsCorrect
    }

    private val closingCharForLastOpenedChunk: Char
        get() {
            if (chunksStack.isEmpty()) throw Exception("Never happens as long as caller checks the stack for emptiness")
            return when (chunksStack.peek()) {
                '(' -> ')'
                '[' -> ']'
                '{' -> '}'
                '<' -> '>'
                else -> throw Exception("Never happens; unless some other character get added to the stack")
            }
        }

    sealed class AnalysisResult {
        object ChunkIsCorrect : AnalysisResult()

        data class UnexpectedClosingChunk(
            val unclosedChunks: Stack<Char>,
            val incorrectClosingCharacter: Char,
        ) : AnalysisResult()

        data class ChunkIsIncomplete(
            val unclosedChunks: Stack<Char>,
        ) : AnalysisResult()
    }
}
