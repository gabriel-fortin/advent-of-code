package aoc2018.day03

val rawInput =
        rawInput1 + rawInput2 + rawInput3 + rawInput4
//    test_01__4

fun main(args: Array<String>){
    val input = preprocess(rawInput)

    val part1 = countTotalOverlap(input)

    println("Result - part 1: $part1")

}


fun countTotalOverlap(claims: List<ElfClaim>): Int {
    // compute how much surface must be analyzed, how many rows to analyze
    val maxStrip: Int = maxStripNumber(claims)

    // for each row count number of inches covered at least twice
    return (1..maxStrip)
            .map { countOverlapInStrip(it, claims) }
            .sum()
}

fun countOverlapInStrip(strip: Int, allClaims: List<ElfClaim>): Int =
        analyzeStrip(strip, allClaims)
                .toList()
                // count only inches claimed by more than one elf
                .filter { it.second.count() > 1 }
                .size

fun analyzeStrip(strip: Int, allClaims: List<ElfClaim>): Map<Int, List<ElfClaim>> {
    // filter out claims not intersecting with the strip (optimization)
    val claims: List<ElfClaim> = claimsApplicableToStrip(strip, allClaims)

    return claims
            // produce all inches for all claims
            .flatMap { claim ->
                val rangeStart = claim.left
                val rangeEnd = claim.left + claim.width
                (rangeStart until rangeEnd)
                        .map { inch -> Pair(inch, claim) }
            }
            // group them by inches, collect claims collecting each inch
            .groupBy({it.first}, {it.second})
}

fun claimsApplicableToStrip(strip: Int, allClaims: List<ElfClaim>): List<ElfClaim> {
    return allClaims
            .filter {
                strip >= it.top
                        &&
                strip < (it.top + it.height)
            }
}

fun maxStripNumber(claims: List<ElfClaim>): Int = claims
        .maxBy { it.top + it.height - 1 }
        ?.let { it.top + it.height }
        ?: throw Exception("wat? no claims?")
