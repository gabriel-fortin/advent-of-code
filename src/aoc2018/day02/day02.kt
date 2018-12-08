package aoc2018.day02

fun main(arg: Array<String>){
    val input = preprocess(rawInput)

    val part1: Int = input
            .map(::analyzeSingleId)
            .reduce(::pairReducer)
            .let(::checksum)

    println()
    println("Result - part 1: $part1")

}

fun analyzeSingleId(id: String): Pair<Int, Int>{
    // sort, so any double/triple letter has its repetitions next to each other
    val idSorted = id.toCharArray().sorted()

    // add guards (characters at beginning and end) so we don't have to handle edge cases separately
    val idWithGuards = idSorted.joinToString("", "_", "_$")

    val doubleLetterPresent = idWithGuards
            // one letter before and one letter after a potential double
            .windowed(4)
            // letters making a double must be same but neighbouring ones must be different
            .any { it[1]==it[2] && it[1]!=it[0] && it[2]!=it[3] }

    val tripleLetterPresent = idWithGuards
            // one letter before and two letters after a potential triple
            .windowed(5)
            // letters making a triple must be same but neighbouring ones must be different
            .any { it[1]==it[2] && it[2]==it[3] && it[1]!=it[0] && it[3]!=it[4] }

    // transform bool to 1 or 0
    return Pair(
        (if (doubleLetterPresent) 1 else 0),
        (if (tripleLetterPresent) 1 else 0))
}

fun pairReducer(p1: Pair<Int, Int>, p2: Pair<Int, Int>): Pair<Int, Int> = Pair(
        p1.first + p2.first,
        p1.second + p2.second)

fun checksum(pair: Pair<Int, Int>) = pair.first * pair.second
