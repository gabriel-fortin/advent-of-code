package day08

data class SignalPattern(
    val segments: Set<Char>,
) {
    override fun toString(): String {
        val s = segments.sorted().joinToString("")
        return "SP($s)"
    }
}