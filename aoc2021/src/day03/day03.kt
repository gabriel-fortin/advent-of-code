package day03

// defined after having visually inspected the input
const val DIGIT_COUNT = 12

fun main() {
    val inputNumbers = readInputNumbers()

    println("part 1:  ${part1(inputNumbers)}")
    println("part 2:  ${part2(inputNumbers)}")
}

fun part1(inputNumbers: List<Int>): Int {
    val mostCommonBitCounter = MutableList<Double>(DIGIT_COUNT) { .0 }
    for (inputNumber in inputNumbers) {
        var number = inputNumber
        for (bitPos in 0 until DIGIT_COUNT) {
            // get last bit
            val bit = number and 1
            // if we represent bits as +/-0.5 then
            // - a positive sum of them all indicates that 1's dominated
            // - a negative sum of them all indicates that 0's dominated
            val cheekyHalfBit = bit - .5
            mostCommonBitCounter[bitPos] += cheekyHalfBit
            number /= 2  // shift right
        }
    }

    val gammaRate = mostCommonBitCounter
        .foldRight(0) { halfBit, gammaRate ->
            val mostCommonBit = if (halfBit > 0) 1 else 0
            2 * gammaRate + mostCommonBit
        }

    val bitMask = ((1 shl DIGIT_COUNT) - 1)
    val epsilonRate = gammaRate xor bitMask

    return gammaRate * epsilonRate
}

fun part2(inputNumbers: List<Int>): Int {
    val oxygenGeneratorRating = reduceIntoRating(inputNumbers, bitCriteriaIsMostCommonBit = true)
    val scrubberRating = reduceIntoRating(inputNumbers, bitCriteriaIsMostCommonBit = false)
    val lifeSUpportRating = oxygenGeneratorRating * scrubberRating
    return lifeSUpportRating
}

fun reduceIntoRating(inputs: List<Int>, bitCriteriaIsMostCommonBit: Boolean): Int {
    var filteredInputs = inputs
    var bitPosition = DIGIT_COUNT - 1
    while (filteredInputs.size > 1) {
        val mostCommonBit = mostCommonBitAtPosition(filteredInputs, bitPosition)
        val wantedBitValue = if (bitCriteriaIsMostCommonBit) mostCommonBit else (1 - mostCommonBit)
        filteredInputs = filteredInputs.filter(hasBitAtPosition(bit = wantedBitValue, position = bitPosition))
        bitPosition--
    }
    return filteredInputs.single()
}

fun mostCommonBitAtPosition(inputs: List<Int>, position: Int): Int {
    val mask = 1 shl position
    // how many inputs have a 1 at the given position
    val countOfOnesAtGivenPosition = inputs.filter { (it and mask) > 0 }.count()
    val proportion: Double = countOfOnesAtGivenPosition.toDouble() / inputs.size
    // using ">=" means a bias towards returning 1 if count of 1's and 0's is equal
    if (proportion >= .5) return 1
    return 0
}


fun hasBitAtPosition(bit: Int, position: Int): (Int) -> Boolean =
    fun(x: Int): Boolean {
        return (x shr position) and 1 == bit
    }
