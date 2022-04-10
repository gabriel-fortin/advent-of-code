package day08

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part1: $part1")

//    val part2 = part2(input)
//    println("part2: $part2")
}

fun part1(entries: List<Entry>): Int {
    return entries
        .map(::count1478)
        .sum()
}

/** Counts how many times digits 1, 4, 7, 8 occur in the value digits of the entry */
fun count1478(entry: Entry): Int {
    val unambiguousPatternLengths = listOf(2, 3, 4, 7)
    return entry.valueDigits
        .count { it.segments.size in unambiguousPatternLengths }
}
