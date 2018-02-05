package aoc2017.day16

val programs: String = ('a'..'p').joinToString("")

fun main(args: Array<String>) {
    // simpler inputs for debugging
//    val programs: String = ('a'..'e').joinToString("")
//    val rawInput = "s1,x3/4,pe/b"


    val part1 = preprocess(rawInput)
            .fold(programs) { acc, cmd ->
                print(cmd)
                val after = cmd.process(acc)
                println("   -> $after")
                after
            }

    println(part1)




}


