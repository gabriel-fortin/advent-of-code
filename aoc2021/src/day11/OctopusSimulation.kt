package day11

import shared.Grid

class OctopusSimulation(private val octopusGrid: Grid<Octopus>) {
    var flashesInStep = 0
        private set
    var totalFlashes = 0
        private set

    init {
        octopusGrid.forEachCell(::setTriggeringOfAdjacentOctopuses)
    }

    fun simulateStep() {
        flashesInStep = 0
        octopusGrid.forEachCellItem { octopus ->
            octopus.increaseEnergyLevel()
        }
        // the above may generate an avalanche of flashes
        // however, it's limited to one flash per octopus
        // that is... until we reset with the code below
        octopusGrid.forEachCellItem { octopus ->
            if (octopus.hasFlashed)
                octopus.resetEnergyLevel()
        }
        totalFlashes += flashesInStep
    }

    private fun setTriggeringOfAdjacentOctopuses(cell: Grid.Cell<Octopus>) {
        val octopus = cell.data
        octopus.onFlash = {
            flashesInStep++
            adjacentOctopuses(cell)
                .forEach(Octopus::increaseEnergyLevel)
        }
    }

    private fun adjacentOctopuses(cell: Grid.Cell<Octopus>): List<Octopus> {
        val (row, col) = cell
        val adjacentCells = listOf(
            (row - 1) to (col - 1),
            (row - 1) to col,
            (row - 1) to (col + 1),
            row to (col - 1),
            row to (col + 1),
            (row + 1) to (col - 1),
            (row + 1) to col,
            (row + 1) to (col + 1),
        )
        return adjacentCells
            // out of range "addresses" are returned as null by 'octopusGrid'; we don't need them
            .mapNotNull { (row, col) -> octopusGrid[row, col]?.data }
    }

}