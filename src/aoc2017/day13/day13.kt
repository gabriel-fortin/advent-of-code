package aoc2017.day13

fun main(args: Array<String>) {
    val test_input = listOf(
            "0: 3",
            "1: 2",
            "4: 4",
            "6: 4"
    )

    val scanners = input
            // prepare input
            .map {
                val g = Regex("(\\d+): (\\d+)").find(it)?.groupValues ?: throw Exception("regex fail")
                Scanner(g[1].toInt(), g[2].toInt())
            }

    // part 1
    scanners
            .let { computeSeverity(it, 0) }
            .apply(::println)

    // part 2
    var i = 0;
    while (true) {
        if (computeSeverity(scanners, i).first == false){
            println(i)
            break
        }
        i++
    }
}

data class Scanner(val depth: Int, val range: Int)

fun computeSeverity(scanners: List<Scanner>, startDelay: Int): Pair<Boolean, Int> {
    return scanners.fold(Pair(false, 0)) { (overallBreach, totalSeverity), (depth, range) ->
        val didBreach = (depth + startDelay) % ((range-1)*2) == 0
        val severity = if (didBreach) depth * range else 0
        Pair(overallBreach || didBreach, totalSeverity + severity)
    }
}
