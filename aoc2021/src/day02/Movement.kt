package day02

/** A movement along a single axis */
sealed class Movement(val distance: Int) {
    /** Returns a new position resulting from applying this movement's vector to the provided position */
    abstract fun from(p: Position): Position

    class Forward(distance: Int) : Movement(distance) {
        override fun from(p: Position): Position = p.copy(x = p.x + distance)
    }

    class Down(distance: Int) : Movement(distance) {
        override fun from(p: Position): Position = p.copy(z = p.z - distance)
    }

    class Up(distance: Int) : Movement(distance) {
        override fun from(p: Position): Position = p.copy(z = p.z + distance)
    }
}
