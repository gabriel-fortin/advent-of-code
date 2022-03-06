package day02

/** A movement */
sealed class Movement(val value: Int) {
    /** (part 1) Returns a new position resulting from applying this movement's vector to the provided position */
    abstract fun naiveChangeFrom(p: Position): Position

    /** (part 2) Returns a new position resulting from applying this movement to the provided position */
    abstract fun advancedChangeFrom(p: Position): Position

    class Forward(distance: Int) : Movement(distance) {
        override fun naiveChangeFrom(p: Position): Position = p.copy(x = p.x + value)
        override fun advancedChangeFrom(p: Position): Position =
            p.copy(x = p.x + value, depth = p.depth + p.aim * value )
    }

    class Down(distance: Int) : Movement(distance) {
        override fun naiveChangeFrom(p: Position): Position = p.copy(depth = p.depth + value)
        override fun advancedChangeFrom(p: Position): Position = p.copy(aim = p.aim + value)
    }

    class Up(distance: Int) : Movement(distance) {
        override fun naiveChangeFrom(p: Position): Position = p.copy(depth = p.depth - value)
        override fun advancedChangeFrom(p: Position): Position = p.copy(aim = p.aim - value)
    }
}
