package day04


fun main() {
    val (drawnNumbers, bingoBoards) = readInput()

    val part1 = part1(drawnNumbers, bingoBoards)
    println("part1: $part1")
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

