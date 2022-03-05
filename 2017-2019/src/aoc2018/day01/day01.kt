package aoc2018.day01

fun main(args: Array<String>) {
    val input = preprocess(rawInput)

    println("Input size: ${input.size}")

//    val result = finalFrequency(input)
    val result = firstRepeatedFrequency(input)

    println("Result: $result")
}

// part 1
fun finalFrequency(input: List<Int>) = input.fold(0, Int::plus)

// part 2
fun firstRepeatedFrequency(input: List<Int>) : Int {
    // this will be filled while we compute new frequencies; it's important it's a set
    val observedFreqs = mutableSetOf(0)

    // this repeats values from 'input' infinitely
    val freqChanges: Sequence<Int> = generateSequence { input }.flatten()

    freqChanges.fold(0, {currentFreq, freqChange ->
        val newFreq = currentFreq + freqChange

        // we use the fact that a set returns false when trying to add a duplicate
        val freqWasSeenPreviously = !observedFreqs.add(newFreq)

        if (freqWasSeenPreviously) return@firstRepeatedFrequency newFreq

        newFreq
    })

    throw Exception("This line is needed to compile but never gets executed")
}
