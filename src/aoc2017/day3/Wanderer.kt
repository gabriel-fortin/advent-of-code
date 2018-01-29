package aoc2017.day3


enum class Turn { L, R, N }

data class Command(val turn: Turn, val dist: Int)

operator infix fun Pair<Int, Int>.plus(x: Pair<Int, Int>): Pair<Int, Int>
        = Pair(first+x.first, second+x.second)


open class Wanderer {
    var position: Pair<Int, Int> //= Pair(0, 0)
        private set
    var direction: Pair<Int, Int> //= Pair(1, 0)
        private set

    constructor(pos: Pair<Int, Int> = Pair(0, 0), dir: Pair<Int, Int> = Pair(1, 0)) {
        position = pos
        direction = dir
    }

    fun copy(): Wanderer = Wanderer(position, direction)

    fun move(cmd: Command) {
        updateDirWith(cmd)
        updatePosWith(cmd)
    }

    private fun updateDirWith(cmd: Command) {
        direction = when (cmd.turn) {
            Turn.R -> Pair(-direction.second, direction.first)
            Turn.L -> Pair(direction.second, -direction.first)
            Turn.N -> direction
        }
    }

    private fun updatePosWith(cmd: Command) {
        for (i in 0 until cmd.dist) {
            position += direction
            postStep()
        }
    }

    protected open fun postStep() {}
}
