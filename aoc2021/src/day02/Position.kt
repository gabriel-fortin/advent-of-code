package day02

/** A position in 2d space */
data class Position(val x: Int = 0, val depth: Int = 0, val aim: Int = 0) {
    /** (par 1) Returns a new position resulting from applying the provided movement's vector to this position */
    fun naivelyAdd(m: Movement): Position = m.naiveChangeFrom(this)

    /** (part 2) Returns a new position resulting from applying the provided movement's vector to this position */
    fun advancedAdd(m: Movement): Position = m.advancedChangeFrom(this)
}
