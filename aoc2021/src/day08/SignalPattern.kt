package day08

data class SignalPattern(
    val segments: Set<Char>,
) {
    val litSegmentsCount = segments.size

    override fun toString(): String {
        val s = segments.sorted().joinToString("")
        return "SP($s)"
    }

    /** True if this SignalPattern contains the same segments as the provided argument (and possibly more) */
    fun subsumes(signalPattern: SignalPattern): Boolean = segments.containsAll(signalPattern.segments)
}
