package aoc2017.day7

val testInput = """
pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)
"""

fun main(args: Array<String>) {
    prepare(rawInput)
//    prepare(testInput)
            .let { buildTreeWith(it) }
            .also { println("\nRESULT:\n ${it.name}\n") }
            .apply { computeTotalWeights() }
            .run { part2() }
            .also { println("\nRESULT: $it") }
}


fun buildTreeWith(progs: List<Program>): Program {
    val set: MutableSet<Program> = progs.toHashSet()
    progs.toList().forEach { prog ->
        prog.childrenRefs.map { childName ->
            val child = set.first { it.name == childName }
            set.remove(child)
            prog.addChild(child)
        }
    }
    return set.first() // first and only one
}



class Program(
        val name: String,
        val weight: Int,
        val childrenRefs: List<String> = emptyList()
) {
    private val childrenMutable: MutableList<Program> = mutableListOf()
    val children: List<Program>
        get() = childrenMutable.toList()

    var totalWeight: Int = 0
        private set

    fun addChild(program: Program): Unit {
        childrenMutable.add(program)
    }

    fun computeTotalWeights(): Unit {
        children.forEach { it.computeTotalWeights() }
        totalWeight = weight + children.map { it.totalWeight }.sum()
    }

    fun part2(): Int? {
        children.forEach { child ->
            child.part2()
                    ?.let { return it }

        }
        children.firstOrNull()
                ?.totalWeight.let { w ->
                    if (children.all { it.totalWeight == w }) return null
                    return findProperWeight(children)
                }
    }

    private fun findProperWeight(children: List<Program>): Int {
        val heavier: Program = children.maxBy { it.totalWeight }!!
        val lighter: Program = children.minBy { it.totalWeight }!!
        val diff = heavier.totalWeight - lighter.totalWeight

        val lightChildrenCount = children
                .filter { it.totalWeight == lighter.totalWeight }
                .count()
        if (lightChildrenCount == 1) {
            //this is also the case when there are only 2 children
            return lighter.weight + diff
        } else {
            return heavier.weight - diff
        }
    }

    override fun toString(): String = "$name ($weight) -> $childrenRefs"
}


fun prepare(rawInput: String): List<Program> = rawInput
        .lines()
        .mapNotNull { line ->
            Regex("(\\w+) \\((\\d+)\\)( -> (.*))?")
                    .find(line)
                    ?.let {
                        val parent = it.groupValues[1]
                        val weight = it.groupValues[2].toInt()
                        val children = it.groupValues[4]
                                .split(", ")
                                .filter { !it.isBlank() }

                        Program(parent, weight, children)
                    }
        }

