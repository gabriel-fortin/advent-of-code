package day11

import shared.Grid

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

//    val part2 = part2(input)
//    println("part 2: $part2")
}

fun part1(grid: Grid<Octopus>): Int {
    // preparation
    var totalFlashes = 0
    fun onOctopusFlashes(row: Int, col: Int) {
        totalFlashes++
        adjacentCoords(grid[row, col]!!).forEach { (r, c) ->
            val adjacentOctopus = grid[r, c]?.data
            adjacentOctopus?.increaseEnergyLevel()
        }
    }
    grid.forEachCell { cell ->
        cell.data.onFlash = { onOctopusFlashes(cell.row, cell.col) }
    }

    repeat(100) { simulateStep(grid) }

    return totalFlashes
}

fun simulateStep(grid: Grid<Octopus>) {
    grid.forEachCellItem { octopus ->
        octopus.increaseEnergyLevel()
    }
    // the above may generate an avalanche of flashes
    // however, it's limited to one flash per octopus
    // that is... until we reset with the code below
    grid.forEachCellItem { octopus ->
        if (octopus.hasFlashed)
            octopus.resetEnergyLevel()
    }
}

fun <T>adjacentCoords(cell: Grid.Cell<T>): List<Pair<Int, Int>> {
    val (row, col) = cell
    return listOf(
        (row - 1) to (col - 1),
        (row - 1) to col,
        (row - 1) to (col + 1),
        row to (col - 1),
        row to (col + 1),
        (row + 1) to (col - 1),
        (row + 1) to col,
        (row + 1) to (col + 1),
    )
}
