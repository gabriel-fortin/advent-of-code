package aoc2017.day8

import kotlin.math.max

const val testInput =
"""
b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10
"""

fun main(args: Array<String>) {
    val input =
//            prepare(testInput)
            prepare(rawInput)

    val cpu1 = Registers()
    input
            .forEach { cpu1.execute(it) }
    println("\nRESULT 1:  ${cpu1.maxRegisterVal()}\n")


    val cpu2 = RegistersWithHistoryAwareness()
    cpu2.execute(input)
    println("\nRESULT 2:  ${cpu2.maxValueEverObserved}\n")

}

data class Condition(
        val reg: String,
        val op: String,
        val value: Int
) {
    fun check(readRegister: (String) -> Int): Boolean = when (op) {
        "<" -> readRegister(reg) < value
        "<=" -> readRegister(reg) <= value
        ">" -> readRegister(reg) > value
        ">=" -> readRegister(reg) >= value
        "==" -> readRegister(reg) == value
        "!=" -> readRegister(reg) != value
        else -> throw Exception("invalid operation: $op")
    }

    override fun toString(): String = "$reg $op $value"
}


data class Instr(
        val register: String,
        val action: Int,
        val condition: Condition
) {
    fun evaluate(readRegister: (String) ->  Int, writeRegister: (String, Int) -> Unit) {
        if (condition.check(readRegister)) {
            val newValue = readRegister(register) + action
            writeRegister(register, newValue)
        }
    }
}


open class Registers {
    private val registers: MutableMap<String, Int> = mutableMapOf()

    protected var readRegister: (String) -> Int =
            { s -> registers.getOrDefault(s, 0) }
    protected var writeRegister: (String, Int) -> Unit =
            registers::set

    fun maxRegisterVal(): Int = registers
            .map { it.value }
            .reduce(::max)

    open fun execute(instr: Instr) {
        instr.evaluate(readRegister, writeRegister)
    }

    fun execute(instrs: List<Instr>) = instrs.forEach { execute(it) }
}

class RegistersWithHistoryAwareness : Registers() {
    var maxValueEverObserved = 0
        private set

    init {
        val writerFromSuper = writeRegister
        writeRegister = { key, value ->
            maxValueEverObserved = max(maxValueEverObserved, value)
            writerFromSuper(key, value)
        }
    }
}


fun prepare(rawInput: String): List<Instr> {
    return rawInput.lines()
            .filterNot { it.isBlank() }
            .map { line ->
                // parse line
                val group = Regex("(\\w+) (\\w+) (-?\\d+) if (\\w+) (\\S{1,2}) (-?\\d+)")
                        .find(line)
                        ?.groupValues
                        ?: throw Exception("could not parse instruction: \"$line\"")

                // extract values
                val reg = group[1]
                val action = when (group[2]) {
                    "inc" -> + Integer.parseInt(group[3])
                    "dec" -> - Integer.parseInt(group[3])
                    else -> throw Exception("action is not 'inc'/'dec' but: \"${group[2]}\"")
                }
                val cmpReg = group[4]
                val cmpOp = group[5]
                val cmpVal = Integer.parseInt(group[6])

                // build result
                Instr(reg, action, Condition(cmpReg, cmpOp, cmpVal))
            }
}
