package aoc2017.day14

import aoc2017.KnotHash

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

interface FindUnion {
    /** returns the id for the newly created set */
    fun addSet(): Int

    /** "union": returns the id of the merged sets */
    fun joinSets(set1: Int, set2: Int): Int

    /** "find": returns the id of the set containing the given element */
    fun findSet(element: Int): Int

//    /** returns a list of "union-ed" sets */
//    fun allSets(): List<Int>

    /** Number of sets currently in the structure */
    var setCount: Int
}

class FindUnionImpl : FindUnion {
    private val parents: MutableMap<Int, Int?> = HashMap()
    private var lastIndex = -1

    /** Number of sets */
    override var setCount = 0

    override fun addSet(): Int {
        setCount++
        parents[++lastIndex] = null
        return lastIndex
    }

    override fun joinSets(set1: Int, set2: Int): Int {
        if (set1 !in (0..lastIndex) || set2 !in (0..lastIndex)) {
            throw Exception("invalid argument")
        }

        val set1Root = findSet(set1)

        if (findSet(set2) == set1Root) return set1Root

        setCount--

        /* attach set2 and all its ascendants to the new root */
        var el = set2
        while (true) {
            val p = parents[el]
            parents[el] = set1Root
            el = p ?: break
        }

        return set1Root
    }

    override fun findSet(element: Int): Int {
        var el = element
        while (true) {
            el = parents[el] ?: return el
        }
    }

//    override fun allSets(): List<Int> {
//        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
//    }
}


fun debugPrint(listOfRows: List<String>) {
    listOfRows
            .take(8)  // first 8 rows
            .map { it.take(8) }  // first 8 chars from each row
            .map(::println)
}
