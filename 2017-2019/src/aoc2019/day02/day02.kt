package aoc2019.day02

fun main(args: Array<String>) {
    val input = preprocess(rawInput)

    println("part1: ${part1(input)}")
}

fun part1(input: List<Int>): Int {
    val mem = input.toMutableList()
    restoreGravityAssistProgram(mem)
    return Computer(mem).run()
}

fun restoreGravityAssistProgram(mem: MutableList<Int>) {
    mem[1] = 12
    mem[2] = 2
}


/**
 * @param mem memory
 * @param ip instruction pointer
 */
class Computer(val mem: MutableList<Int>, var ip: Int = 0) {

    fun run(): Int {
        try {
            while (true) executeInstruction()
        } catch (ex: Operation.Halt.ExecutionAttemptException) {
            // program execution ended
        }
        return mem[0]
    }

    /**
     * Executes the instruction where the current instruction pointer is
     * and advances the pointer
     */
    fun executeInstruction() {
        val operation = Operation.fromOpCode(mem[ip])

        val arg1Position = mem[ip + 1]
        val arg2Position = mem[ip + 2]
        val resultPosition = mem[ip + 3]

        val arg1 = mem[arg1Position]
        val arg2 = mem[arg2Position]

        mem[resultPosition] = operation.execute(arg1, arg2)  // throws on Halt

        ip += 4
    }
}


/**
 * Sealing a class makes it behave similarly to an enum - inheriting classes are
 * limited to those listed inside
 */
sealed class Operation {
    abstract fun execute(arg1: Int, arg2: Int): Int

    class Addition : Operation() {
        override fun execute(arg1: Int, arg2: Int): Int = arg1 + arg2
    }

    class Multiplication : Operation() {
        override fun execute(arg1: Int, arg2: Int): Int = arg1 * arg2
    }

    object Halt : Operation() {
        override fun execute(arg1: Int, arg2: Int): Int =
                throw ExecutionAttemptException()

        class ExecutionAttemptException : Exception("The execution of the Halt operation was attempted")
    }

    /**
     * Effectively, this is a factory of Operation objects
     */
    companion object {
        fun fromOpCode(opCode: Int): Operation {
            when (opCode) {
                1 -> return Addition()
                2 -> return Multiplication()
                99 -> return Halt
                else -> throw Exception("OpCode not recognised: $opCode")
            }
        }
    }
}


