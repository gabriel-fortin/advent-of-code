package day02

/** A movement */
sealed class Movement(val distance: Int) {
    /** (part 1) Returns a new position resulting from applying this movement's vector to the provided position */
    abstract fun naiveChangeFrom(p: Position): Position

    class Forward(distance: Int) : Movement(distance) {
        override fun naiveChangeFrom(p: Position): Position = p.copy(x = p.x + distance)
    }

    class Down(distance: Int) : Movement(distance) {
        override fun naiveChangeFrom(p: Position): Position = p.copy(depth = p.depth + distance)
    }

    class Up(distance: Int) : Movement(distance) {
        override fun naiveChangeFrom(p: Position): Position = p.copy(depth = p.depth - distance)
    }
}
