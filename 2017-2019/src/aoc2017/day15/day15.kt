package aoc2017.day15

val seedA = 679
val seedB = 771
val factorA = 16807
val factorB = 48271

fun main(args: Array<String>) {
//    val seedA = 65
//    val seedB = 8921

    val genA = { generator(seedA, factorA) }
    val genB = { generator(seedB, factorB) }

    // part 1
    judge(40_000_000, genA(), genB())
            .apply(::println)

    // part 2
    judge(5_000_000,
            genA().filter { it % 4 == 0 },
            genB().filter { it % 8 == 0 })
            .apply(::println)
}

fun generator(seed: Int, factor: Int) =
        generateSequence(seed) { x ->
            ((x.toLong() * factor) % 2147483647).toInt()
        }

fun judge(sampleSize: Int, genA: Sequence<Int>, genB: Sequence<Int>): Int {
    fun bitmask(n: Int): Int = n and ((1 shl 16) - 1)
    fun bitmask(p: Pair<Int, Int>) = Pair(bitmask(p.first), bitmask(p.second))

    return genA.zip(genB)
            .map(::bitmask)
            .take(sampleSize)
            .count { (a, b) -> a==b }
}
