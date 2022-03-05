package aoc2016.day1.final

import kotlin.math.abs

const val input = "L3, R2, L5, R1, L1, L2, L2, R1, R5, R1, L1, L2, R2, R4, L4, L3, L3, R5, L1, R3, L5, L2, R4, L5, R4, R2, L2, L1, R1, L3, L3, R2, R1, L4, L1, L1, R4, R5, R1, L2, L1, R188, R4, L3, R54, L4, R4, R74, R2, L4, R185, R1, R3, R5, L2, L3, R1, L1, L3, R3, R2, L3, L4, R1, L3, L5, L2, R2, L1, R2, R1, L4, R5, R4, L5, L5, L4, R5, R4, L5, L3, R4, R1, L5, L4, L3, R5, L5, L2, L4, R4, R4, R2, L1, L3, L2, R5, R4, L5, R1, R2, R5, L2, R4, R5, L2, L3, R3, L4, R3, L2, R1, R4, L5, R1, L5, L3, R4, L2, L2, L5, L5, R5, R2, L5, R1, L3, L2, L2, R3, L3, L4, R2, R3, L1, R2, L5, L3, R4, L4, R4, R3, L3, R1, L3, R5, L5, R1, R5, R3, L1"

fun main(args: Array<String>)
{
    // PART 1:
    val w = Wanderer()
    for (cmd in prepare(input)) {
        w.move(cmd)
    }
    println(distanceFromZero(w.position))


    // PART 2:
    with (LoggingWanderer()) {
        for (cmd in prepare(input)) {
            move(cmd)
        }
        println(firstCrossing?.let { distanceFromZero(it) } ?: "no crossing")
    }

}


/** classes */

enum class Turn { L, R }

data class Command(val turn: Turn, val dist: Int)

open class Wanderer {
    var position = Pair(0, 0)
        private set
    var direction = Pair(1, 0)
        private set

    fun move(cmd: Command) {
        updateDirWith(cmd)
        updatePosWith(cmd)
    }

    private fun updateDirWith(cmd: Command) {
        direction = when (cmd.turn) {
            Turn.R -> Pair(-direction.second, direction.first)
            Turn.L -> Pair(direction.second, -direction.first)
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

class LoggingWanderer : Wanderer() {
    val visits = hashSetOf(position)
    var firstCrossing: Pair<Int, Int>? = null
        private set

    override fun postStep() {
        if (visits.contains(position) && firstCrossing==null) {
            firstCrossing = position
        }
        visits.add(position)
    }

}

/** helpers */

// Manhattan distance
fun distanceFromZero(p: Pair<Int, Int>) =  abs(p.first) + abs(p.second)


/** operator overloads */

operator infix fun Pair<Int, Int>.plus(x: Pair<Int, Int>): Pair<Int, Int>
        = Pair(first+x.first, second+x.second)


/** input pre-processing */

fun prepare(input: String): List<Command> {
    return input
            .split(", ")
            .map { Command(extractDir(it), extractInt(it)) }
}

fun extractDir(s: String) = Turn.valueOf(s[0].toString())
fun extractInt(s: String) = Integer.parseInt(s.substring(1))

