package aoc2017.day16

import kotlin.math.max
import kotlin.math.min

sealed class Command {

    abstract fun process(input: String): String

    data class Spin(
            val num: Int
    ) : Command() {
        override fun process(input: String): String {
            return input.takeLast(num) + input.dropLast(num)
        }
    }

    data class Exchange(
            val pos1: Int,
            val pos2: Int
    ) : Command() {
        override fun process(input: String): String {
            if (pos1 == pos2) return input

            val p1 = min(pos1, pos2)
            val p2 = max(pos1, pos2)

            return input[(0 until p1)] +
                    input[p2] +
                    input[(p1+1 until p2)] +
                    input[p1] +
                    input[(p2+1 until input.length)]
        }
    }

    data class Partner(
            val prog1: Char,
            val prog2: Char
    ) : Command() {
        override fun process(input: String): String {
            val i1 = input.indexOf(prog1)
            val i2 = input.indexOf(prog2)
            return Exchange(i1, i2).process(input)
        }
    }
}


operator fun String.get(r: IntRange): String = this.substring(r)
