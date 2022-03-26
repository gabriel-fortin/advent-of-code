package day05

data class Line(
    val x1: Int,
    val y1: Int,
    val x2: Int,
    val y2: Int
) {
    override fun toString(): String {
        return "Line: $x1,$y1 -> $x2,$y2"
    }
}