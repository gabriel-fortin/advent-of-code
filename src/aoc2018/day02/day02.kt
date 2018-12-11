package aoc2018.day02

fun main(arg: Array<String>){
    val input = preprocess(rawInput)

    val part1: Int = input
            .map(::analyzeSingleId)
            .reduce(::pairReducer)
            .let(::checksum)

    val part2: String = input
            .let(::findPairWhichHasOneLetterOfDifference)
            .let { (w1, w2) -> w1.zip(w2) } // transform pair of strings in list of character pairs
            .filter { (c1, c2) -> c1 == c2} // cut out differing letters
            .map { it.first }  // take just one letter from the pair
            .joinToString("") // transform list of characters into a string

    println()
    println("Result - part 1: $part1")
    println("Result - part 2: $part2")

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

fun numberOfDifferingLetters(word1: String, word2: String): Int {
    if (word1.length != word2.length) throw Exception("words have different length")

    return word1.zip(word2)
            .count { (a, b) -> a != b }
}

fun findPairWhichHasOneLetterOfDifference(allWords: List<String>): Pair<String, String>{
    for (i in 0 until allWords.size-1) {
        for (j in i+1 until allWords.size) {
            val w1 = allWords[i]
            val w2 = allWords[j]
            if (numberOfDifferingLetters(w1, w2) == 1) return Pair(w1, w2)
        }
    }
    throw Exception("No pair was found")
}
