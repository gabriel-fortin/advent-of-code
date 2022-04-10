package day08

data class Entry(
    // each test digit is different
    val testDigits: List<SignalPattern>,
    val valueDigits: List<SignalPattern>,
) {
    val mapping: MutableMap<SignalPattern, Int> = HashMap()

    fun digitFor(signalPattern: SignalPattern): Int {
        return mapping[signalPattern]
            ?: throw Exception("No mapped digit for $signalPattern")
    }
}
