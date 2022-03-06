package day02

/** A position in 2d space */
data class Position(val x: Int = 0, val z: Int = 0) {
    /** Returns a new position resulting from applying the provided movement's vector to this position */
    fun plus(m: Movement): Position = m.from(this)
}
