package aoc2017.day3

import kotlin.math.abs

const val INPUT = 361527

fun main(args: Array<String>) {
    println(distanceFromCenter(1))      // 0
    println(distanceFromCenter(12))     // 3
    println(distanceFromCenter(23))     // 2
    println(distanceFromCenter(1024))   // 31

    // PART 1   (took 40 minutes to complete)
    // complexity: O(p)  where p is the size of the result;  nb: O(p) < O(n)
    println(distanceFromCenter(INPUT))

    println()

    // PART 2   (took below 2 hours but Wanderer class was re-used)
    println(stressTest(INPUT))

}


fun distanceFromCenter(cell: Int): Int {
    val layer = findLayerFor(cell)
    // compute Manhattan distance
    return layer + distanceFromMiddle(layer, cell)
}


fun distanceFromMiddle(layer: Int, cell: Int): Int {
    // layer zero is kind of special, it has no sides
    if (cell == 1) return 0

    val positionWithinLayer = (cell - layerLastElement(layer-1))
    // transform to the case where the cell is on the first side of the layer
    val positionInSide = positionWithinLayer % (layerWidth(layer) - 1)
    val sideMiddle = layerWidth(layer) / 2  // layer width is always odd but that doesn't matter
    return abs(sideMiddle - positionInSide)
}


fun findLayerFor(cell: Int): Int {
    var result = 0
    while (layerLastElement(result) < cell) {
        result++
    }
    return result
}


val DIRECTION_RIGHT = Pair(0, 1)
val GO_AHEAD = Command(Turn.N, 1)
val TURN_LEFT = Command(Turn.L, 0)
fun stressTest(input: Int): Int {
    // find a safe upper bound on the layer the result lies in
    val layerLimit = findLayerFor(input) + 1
    val mem = generateMemorySlice(layerLimit)
    // create Wanderer in the middle of mem, facing right
    val w: Wanderer =
            with(layerWidth(layerLimit) / 2){
                val midPoint = Pair(this, this)
                Wanderer(midPoint, DIRECTION_RIGHT)
            }

    // init
    mem[w.position] = 1
    var cell = 1
    var layer = 0

    // first step: go from layer 0 to 1
    w.move(GO_AHEAD)
    w.move(TURN_LEFT)
    cell++
    layer++


    while (true) {
        val positionWithinLayer = (cell - layerLastElement(layer - 1) - 1)
        val positionInSide = positionWithinLayer % (layerWidth(layer) - 1)

        // compute cell value
        val neighbourSum = neighbouringPositions(w.position)
                .sumBy { pos -> mem[pos] ?: 0 }
        mem[w.position] = neighbourSum

        // return result?
        if (neighbourSum > input) {
            return neighbourSum
        }

        // move to the next cell
        when {
            cell == layerLastElement(layer) -> {
                // move to next layer
                w.move(GO_AHEAD)
                w.move(TURN_LEFT)
                layer++
            }
            positionInSide >= layerWidth(layer) - 2 -> {
                // turn to continue on layer
                w.move(TURN_LEFT)
                w.move(GO_AHEAD)
            }
            else -> {
                // continue on layer
                w.move(GO_AHEAD)
            }
        }
        cell++
    }
}




/*****************
 *    HELPERS    *
 *****************/

/** layer 0 contains just 1; layer 1 contains 2-9 */
fun layerWidth(layer: Int): Int = 1 + 2 * layer

/** Number of elements in a layer including all smaller layers */
fun layerLastElement(layer: Int) = layerWidth(layer) * layerWidth(layer)


/** Read mem positions using "Pair"s */
operator fun Array<Array<Int?>>.get(p: Pair<Int, Int>): Int? {
    return this[p.first][p.second]
}

/** Write mem positions using "Pair"s */
operator fun Array<Array<Int?>>.set(p: Pair<Int, Int>, value: Int?): Unit {
    this[p.first][p.second] = value
}


fun neighbouringPositions(pos: Pair<Int, Int>): List<Pair<Int, Int>> =
        listOf(
                pos + Pair(1, 0),
                pos + Pair(1, 1),
                pos + Pair(0, 1),
                pos + Pair(-1, 1),
                pos + Pair(-1, 0),
                pos + Pair(-1, -1),
                pos + Pair(0, -1),
                pos + Pair(1, -1)
        )


fun generateMemorySlice(layers: Int): Array<Array<Int?>> {
    val size = layerWidth(layers)
    val newCellCreator: (Int) -> Int? = { _ -> null }
    val newRowCreator: (Int) -> Array<Int?> = { _ ->
        Array<Int?>(size, newCellCreator)
    }
    return Array<Array<Int?>>(size, newRowCreator)
}
