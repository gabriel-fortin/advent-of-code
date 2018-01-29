package aoc2017.day14

import common.KnotHash
import common.FindUnion
import common.FindUnionImpl

//const val ONE = '1'
//const val ZERO = '0'
const val ONE = '#'
const val ZERO = '.'

val input = "amgozmfv"

fun main(args: Array<String>) {
//    val input = "flqrgnkx"

    (0..127)
            // create inputs for each row: "amgozmfv-0", "amgozmfv-1", …
            .map<Int, String> { i -> "$input-$i" }
            // compute each row as a knot hash
            .map<String, String> { KnotHash().compute(it) }
            // translate hexadecimal representation to binary representation
            .map<String, String> {
                it
                        .map(::hexadecimalToBinary)
                        .joinToString("")
            }

            .also(::debugPrint)  // doesn't alter the content of the stream

            .also(::part1)

            .also(::part2)


}

fun part1(listOfRows: List<String>) {
    val occupiedCells: Int = listOfRows
            // count the number of occupied cells in each row
            .map<String, Int> { row ->
                row.count { cell -> cell == ONE }
            }
            // sum the number of occupied cells in all each rows
            .sum()

    println("part 1: $occupiedCells")
}

const val USED = -1
fun part2(listOfRows: List<String>) {
    val fu: FindUnion = FindUnionImpl()
    fun addRegion(): Int = fu.addSet()
    fun joinRegions(a: Int, b: Int): Int = fu.joinSets(a, b)

    val emptyRow = List<Int?>(128) { null }
    listOfRows
            .map<String, List<Int?>> { row ->
                row.map<Int?> { if (it == ONE) USED else null }
            }
            .fold<List<Int?>, List<Int?>>(emptyRow) { prevRow, row ->
                val processedRow = MutableList<Int?>(0, {/*whatever:*/-14})
                prevRow.zip(row)
                        .fold<Pair<Int?, Int?>, Int?>(null) foldStep@ { leftCellState, (aboveCellState, currentCellState) ->
                            if (currentCellState == null) {
                                processedRow.add(null)
                                return@foldStep null
                            } else {
                                val regionForCell = when {
                                    leftCellState == null -> aboveCellState ?: addRegion()
                                    aboveCellState == null -> leftCellState ?: addRegion()
                                    else -> joinRegions(leftCellState, aboveCellState)
                                }
                                processedRow.add(regionForCell)
                                return@foldStep regionForCell
                            }
                        }  // ignore result
                processedRow  // as reference when computing the next row
            }

    val result = fu.setCount
    println("part 2: $result")
}

fun hexadecimalToBinary(c: Char): String {
    val asInt = Integer.parseInt(c.toString(), 16)
    val result = Array<Char>(4, {'?'})
    result[0] = if ((asInt and (1 shl 3)) > 0) ONE else ZERO
    result[1] = if ((asInt and (1 shl 2)) > 0) ONE else ZERO
    result[2] = if ((asInt and (1 shl 1)) > 0) ONE else ZERO
    result[3] = if ((asInt and (1 shl 0)) > 0) ONE else ZERO
    return result.joinToString("")
}


fun debugPrint(listOfRows: List<String>) {
    listOfRows
            .take(8)  // first 8 rows
            .map { it.take(8) }  // first 8 chars from each row
            .map(::println)
}
