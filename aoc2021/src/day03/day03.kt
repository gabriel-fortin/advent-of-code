package day03

// defined after having visually inspected the input
const val NUMBER_LENGTH = 12

fun main() {
    val inputNumbers = readInputNumbers()

    println("part 1:  ${part1(inputNumbers)}")
}

private fun part1(inputNumbers: List<Int>): Int {
    val mostCommonBitCounter = MutableList<Double>(NUMBER_LENGTH) { .0 }
    for (inputNumber in inputNumbers) {
        var number = inputNumber
        for (bitPos in 0 until NUMBER_LENGTH) {
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

    val bitMask = ((1 shl NUMBER_LENGTH) - 1)
    val epsilonRate = gammaRate xor bitMask

    return gammaRate * epsilonRate
}
