package day09


fun main() {
    val input = getInput()

    println(input)

    val part1 = part1(input)
    println("part 1: $part1")

//    val part2 = part2(input)
//    println("part 2: $part2")
}

fun part1(heightMap: List<List<Int>>): Int {
    val guardedHeightMap = wrapInputInGuards(heightMap)

    val rowsCount = heightMap.size // because we want to iterate only over original elements
    val colsCount = heightMap.first().size // same reason as above

    var totalRiskLevel = 0
    (1..rowsCount).forEach { row ->
        (1..colsCount).forEach { col ->
            if (isLowPoint(row, col, guardedHeightMap)) {
                totalRiskLevel += 1 + guardedHeightMap[row][col]
            }
        }
    }
    return totalRiskLevel
}

const val MAX_HEIGHT = 9
fun wrapInputInGuards(input: List<List<Int>>): List<List<Int>> {
    val newlineLength = input.first().size + 2
    val lineOfGuards: List<Int> = List(newlineLength, init = { MAX_HEIGHT + 1 })
    val guardedInputRows = input.map { it.withGuards(MAX_HEIGHT + 1) }

    return (sequenceOf(lineOfGuards) +
            guardedInputRows +
            sequenceOf(lineOfGuards))
        .toList()
}

fun <T> List<T>.withGuards(guardValue: T): List<T> {
    return (sequenceOf(guardValue) +
            this +
            sequenceOf(guardValue))
        .toList()
}

fun isLowPoint(row: Int, col: Int, heightMap: List<List<Int>>): Boolean {
    return heightMap[row][col] < heightMap[row][col - 1] &&
            heightMap[row][col] < heightMap[row][col + 1] &&
            heightMap[row][col] < heightMap[row - 1][col] &&
            heightMap[row][col] < heightMap[row + 1][col]
}
