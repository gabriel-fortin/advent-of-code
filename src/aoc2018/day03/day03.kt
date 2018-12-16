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
    val maxStrip: Int = claims
            .maxBy { it.top + it.height - 1 }
            ?.let { it.top + it.height }
            ?: throw Exception("wat? no claims?")

    // for each row countOverlapInStrip
    return (1..maxStrip)
            .fold(0) { currentTotal, strip ->
                currentTotal + countOverlapInStrip(strip, claims)
            }
}


fun countOverlapInStrip(strip: Int, allClaims: List<ElfClaim>): Int {
    // filter out claims not intersecting with the strip (optimization)
    val claims: List<ElfClaim> = claimsApplicableToStrip(strip, allClaims)

    // create a hashmap which counts how many claims there are for each inch in the strip
    // (i.e. for each cell in the row)
    val claimedInchesInStrip = claims
            .fold(hashMapOf<Int, Int>()) { claimedInches, claim ->
                // add intersection of claim and strip to the result
                (claim.left until (claim.left + claim.width))
                        .forEach { claimedInches.merge(it, 1, Int::plus) }

                claimedInches
            }

    return claimedInchesInStrip
            // count only inches claimed by more than one elf
            .filter { it.value > 1 }
            .size
}

fun claimsApplicableToStrip(strip: Int, allClaims: List<ElfClaim>): List<ElfClaim> {
    return allClaims
            .filter {
                strip >= it.top
                        &&
                strip < (it.top + it.height)
            }
}
