package day04


fun main() {
    val (drawnNumbers, bingoBoards) = readInput()

    val part1 = part1(drawnNumbers, bingoBoards)
    println("part1: $part1")

    val part2 = part2(drawnNumbers, bingoBoards)
    println("part2: $part2")
}

fun part1(drawnNumbers: List<Int>, bingoBoards: List<BingoBoard>): Int {
    for (drawnNumber in drawnNumbers) {
        callNumber(drawnNumber, bingoBoards)
        val winningBoard = bingoBoards.singleOrNull { it.isBingo }
        if (winningBoard != null) {
            return drawnNumber * winningBoard.sumUnmarkedNumbers()
        }
    }
    throw ArrayIndexOutOfBoundsException("Have drawn all numbers and no bingo was detected")
}

fun callNumber(number: Int, boards: List<BingoBoard>) {
    boards.forEach { it.tryMark(number) }
}

fun part2(drawnNumbers: List<Int>, allBingoBoards: List<BingoBoard>): Int {
    val notFinishedBingoBoards = allBingoBoards.toMutableList()
    for (drawnNumber in drawnNumbers) {
        callNumber(drawnNumber, notFinishedBingoBoards)
        if (notFinishedBingoBoards.size == 1) {
            val lastWinningBoard = notFinishedBingoBoards.single()
            if (lastWinningBoard.isBingo)
                return drawnNumber * lastWinningBoard.sumUnmarkedNumbers()
        }
        notFinishedBingoBoards.removeIf { it.isBingo }
    }
    throw IllegalArgumentException("a board that wins last was not found")
}
