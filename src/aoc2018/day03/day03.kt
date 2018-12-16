package aoc2018.day03

val rawInput =
        rawInput1 + rawInput2 + rawInput3 + rawInput4
//    test_01__4

fun main(args: Array<String>){
    val input = preprocess(rawInput)

    val part1 = countTotalOverlap(input)

    println("Result - part 1: $part1")

}


fun countTotalOverlap(claims: List<ElfClaim>): Int{
    val maxStrip: Int = claims
            .maxBy { it.top + it.height - 1 }
            ?.let { it.top + it.height }
            ?: throw Exception("wat? no claims?")

    return (1..maxStrip)
            .fold(0) { currentTotal, strip ->
                currentTotal + countOverlapInStrip(strip, claims)
            }
}


fun countOverlapInStrip(strip: Int, allClaims: List<ElfClaim>): Int {
    val claims: List<ElfClaim> = claimsApplicableToStrip(strip, allClaims)

    val claimedInchesInStrip = claims
            .fold(hashMapOf<Int, Int>()) { claimedInches, claim ->
                (claim.left until (claim.left + claim.width))
                        .forEach { claimedInches.merge(it, 1, Int::plus) }

                claimedInches
            }

    return claimedInchesInStrip
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
