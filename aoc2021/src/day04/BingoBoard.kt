package day04

import kotlin.test.assertEquals

const val BOARD_SIZE = 5

class BingoBoard(boardValues: List<Int>) {
    private val bingoNumbers: List<Int>
    private val marked: MutableList<Boolean>

    var isBingo: Boolean = false
        private set

    init {
        assertEquals(BOARD_SIZE * BOARD_SIZE, boardValues.size, "Size of a board")
        this.bingoNumbers = boardValues
        this.marked = MutableList(BOARD_SIZE * BOARD_SIZE, init = { false })
    }

    fun tryMark(valueToMark: Int) {
        for (pos in bingoNumbers.indices) {
            if (bingoNumbers[pos] != valueToMark) continue

            marked[pos] = true
            if (doesPositionWinBingo(pos)) {
                isBingo = true
            }
            return
        }
    }

    private fun doesPositionWinBingo(position: Int): Boolean {
        val row = position / BOARD_SIZE
        val col = position.rem(BOARD_SIZE)

        val rowWins = (row * BOARD_SIZE until (row + 1) * BOARD_SIZE)
            .fold(true) { doesLookLikeWinner, pos -> doesLookLikeWinner && marked[pos] }
        if (rowWins) return true

        val columnWins = (col until bingoNumbers.size step BOARD_SIZE)
            .fold(true) { doesLookLikeWinner, pos -> doesLookLikeWinner && marked[pos] }
        if (columnWins) return true

        return false
    }

    fun sumUnmarkedNumbers(): Int {
        return bingoNumbers.indices
            .filter { !marked[it] }
            .sumOf { bingoNumbers[it] }
    }

}