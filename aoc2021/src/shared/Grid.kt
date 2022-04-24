package shared

/** Grid of custom cells. Can handle addressing out-of-range coordinates */
class Grid<TCellData>(data: List<List<TCellData>>) {
    private val totalRows = data.size
    private val totalCols = data.first().size
    private val data: List<List<Cell<TCellData>>> = data.mapIndexed { row, rowList ->
        if (rowList.size != totalCols) {
            throw IllegalArgumentException("Uneven grid; row $row has size ${rowList.size} (expected $totalCols)")
        }
        rowList.mapIndexed { col, cellData -> Cell(row, col, cellData) }
    }

    /** Returns null if [row] or [col] is out of range */
    operator fun get(row: Int, col: Int): Cell<TCellData>? {
        if (row !in 0 until totalRows ||
            col !in 0 until totalCols
        ) return null
        return data[row][col]
    }

    override fun toString(): String {
        return data.joinToString("") { rowList ->
            rowList.joinToString("") { cell ->
                cell.data.toString()
            } + "\n"
        }
    }

    data class Cell<TData>(
        val row: Int,
        val col: Int,
        var data: TData,
    )
}
