package day14

class Polymerisation(
    private val rules: List<InsertionRule>,
    initialPolymer: String
) {
    var currentPolymer: String = initialPolymer
        private set

    var stats: Map<Char, Int>? = null

    fun polymerise() {
        // invalidate stats
        stats = null

        val newPolymer = mutableListOf(currentPolymer.substring(0, 1))
        currentPolymer
            // all pairs where letters are adjacent
            .windowed(2)
            .mapTo(newPolymer) { "${polymerisePair(it)}${it[1]}" }

        currentPolymer = newPolymer.joinToString("")
    }

    private fun polymerisePair(pair: String): String {
        return rules
            .single { it.pattern == pair }
            .replacement
    }

    fun mostCommonElementCount(): Int {
        ensureStats()
        return stats!!.maxOf { it.value }
    }

    fun leastCommonElementCount(): Int {
        ensureStats()
        return stats!!.minOf { it.value }
    }

    private fun ensureStats() {
        if (stats != null) return
        stats = HashMap()
        currentPolymer.forEach { letter ->
            val letterCount = stats!!.getOrDefault(letter, 0)
            (stats as HashMap)[letter] = letterCount + 1
        }
    }
}
