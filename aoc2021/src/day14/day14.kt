package day14

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

//    val part2 = part2(input)
//    println("part 2: $part2")
}

fun part1(input: List<String>): Int {
    val polymerTemplate = input.first()
    val pairInsertionRules = input.drop(2).map(::parseInsertionRule)
    val model = Polymerisation(pairInsertionRules, polymerTemplate)
    repeat(10) {
        model.polymerise()
    }

    return model.mostCommonElementCount() - model.leastCommonElementCount()
}
