package day08

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part1: $part1")

    val part2 = part2(input)
    println("part2: $part2")
}

fun part1(entries: List<Entry>): Int =
    entries.map(::count1478).sum()

/** Counts how many times digits 1, 4, 7, 8 occur in the value digits of the entry */
fun count1478(entry: Entry): Int {
    val unambiguousPatternLengths = listOf(2, 3, 4, 7)
    return entry.valueDigits
        .count { it.litSegmentsCount in unambiguousPatternLengths }
}

fun part2(entries: List<Entry>): Int =
    entries
        .onEach(::deduceDigitMapping)
        .sumOf(::mapValueDigits)

fun deduceDigitMapping(entry: Entry) {
    val spFor1 = entry.testDigits.single { it.litSegmentsCount == 2 }
    entry.mapping[spFor1] = 1

    val spFor7 = entry.testDigits.single { it.litSegmentsCount == 3 }
    entry.mapping[spFor7] = 7

    val spFor4 = entry.testDigits.single { it.litSegmentsCount == 4 }
    entry.mapping[spFor4] = 4

    val spFor8 = entry.testDigits.single { it.litSegmentsCount == 7 }
    entry.mapping[spFor8] = 8

    val spFor3 = entry.testDigits.single { it.litSegmentsCount == 5 && it.subsumes(spFor7)}
    entry.mapping[spFor3] = 3

    val spFor9 = entry.testDigits.single { it.litSegmentsCount == 6 && it.subsumes(spFor4) }
    entry.mapping[spFor9] = 9

    // SPs remaining to be mapped: 0256
    val spFor0 = entry.testDigits.single { it.subsumes(spFor7) && entry.mapping.containsKey(it).not() }
    entry.mapping[spFor0] = 0

    // the only unmapped SP having 6 segments is the SP for 6
    val spFor6 = entry.testDigits.single { it.litSegmentsCount == 6 && entry.mapping.containsKey(it).not() }
    entry.mapping[spFor6] = 6

    val spFor5 = entry.testDigits.single { it.litSegmentsCount == 5 && spFor6.subsumes(it) }
    entry.mapping[spFor5] = 5

    // SP remaining to be mapped: 2
    val spFor2 = entry.testDigits.single { entry.mapping.containsKey(it).not() }
    entry.mapping[spFor2] = 2
}

// length: signal patterns using this many segments
// 2: 1
// 3: 7
// 4: 4
// 5: 235
// 6: 069
// 7: 8

fun mapValueDigits(entry: Entry): Int =
    entry.valueDigits
        .fold(0) { value, signalPattern ->
            val digit: Int = entry.digitFor(signalPattern)
            10 * value + digit
        }
