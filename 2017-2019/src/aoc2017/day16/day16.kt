package aoc2017.day16


const val LENGTH = 16
val programs: String = ('a'..'p').joinToString("")
const val repetitions = 1000_000_000 - 1

fun main(args: Array<String>) {
    // simpler inputs for debugging
//    val programs: String = ('a'..'e').joinToString("")
//    val rawInput = "s1,x3/4,pe/b"

    var input = preprocess(rawInput)
    println("input size: ${input.size}")
//    input = optimize(input)
    println("input size: ${input.size}")

    val part1 = preprocess(rawInput)
            .fold(programs) { acc, cmd ->
                val after = cmd.process(acc)
                after
            }

    println("part 1: " + part1)

    part2UsingCycleDetection(part1, input)

}


fun optimize(input: List<Command>): List<Command> {
    var shift = 0
    return input
            .map {
                when (it) {
                    is Command.Spin -> {
                        shift += it.num
                        it
                    }
                    is Command.Exchange -> {
                        val p1 = (it.pos1 + shift) % LENGTH
                        val p2 = (it.pos2 + shift) % LENGTH
                        Command.Exchange(p1, p2)
                    }
                    else -> it
                }
            }
            .filterNot { it is Command.Spin }
}

fun part2UsingCycleDetection(startOrder: String, danceMoves: List<Command>) {
    var acc = startOrder
    var cycleSize = repetitions + 1  // dummy value

    for (i in 1..repetitions) {
        acc = danceMoves.fold(acc) { acc, cmd ->
            cmd.process(acc)
        }
        if (acc == startOrder) {
            cycleSize = i
            break
        }
    }

    println("cycle size: $cycleSize")

    for (i in 1..(repetitions%cycleSize)) {
        acc = danceMoves.fold(acc) { acc, cmd ->
            cmd.process(acc)
        }
    }

    println("RESULT - part 2 - cycle detection: $acc")
}


fun part2Intelligent(startPoint: String, danceMoves: List<Command>) {
    val afterOneDance = danceMoves.fold(startPoint) { acc, cmd ->
        cmd.process(acc)
    }

    val singleDanceMapping = startPoint
            .map { c ->  afterOneDance.indexOf(c) }

    val transform: (CharArray) -> CharArray = { input ->
//        val result: Array<Char> = Array(LENGTH, {'x'})
        val result = CharArray(LENGTH)
        for (i in 0 until result.size) {
            result[singleDanceMapping[i]] = input[i]
        }
        result
    }

    var state: CharArray = startPoint.toCharArray()
    var achieved = 8
    for (i in 1..repetitions) {

        if (i==achieved){
            achieved = achieved shl 1
            println("   = $i =")
        }

        state = transform(state)
    }

    val result = state.joinToString("")


    println("   RESULT intelligent:  $result")
}


fun part2BruteForce(startOrder: String, danceMoves: List<Command>) {

    // part 2 - lame brute force
    var achieved = 8
    var acc = startOrder
    for (i in 1..repetitions) {
        if (i==achieved){
            achieved = achieved shl 1
            println("   = $i =")
        }

        acc = danceMoves.fold(acc) { acc, cmd ->
            cmd.process(acc)
        }
        if (acc == startOrder) {
            println("@@@@ repetition spotted after $i repetitions")
        }
    }

    println("   RESULT brute      :  $acc")
}

/*
 Bare:
 >> MEASURED TIME: 12.346357102s
 With optimization:
 >> MEASURED TIME: 10.141489832s
*/
