package day13

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

    println("part 2:")
    part2(input)
}

fun part1(input: Input): Int {
    val instruction = input.instructions.first()
    val dotsAfterFoldingOnce = foldPaper(input.dots, instruction)
    return dotsAfterFoldingOnce.count()
}

fun part2(input: Input) {
    val result = input.instructions.fold(input.dots, ::foldPaper)
    prettyPrint(result)
}

fun foldPaper(dots: Collection<Dot>, instruction: FoldInstruction): MutableSet<Dot> {
    val dotsAfterFolding = mutableSetOf<Dot>()
    dots.forEach { dot ->
        when (instruction.axis) {
            Axis.X -> when {
                dot.x < instruction.location -> dotsAfterFolding.add(dot)
                dot.x == instruction.location -> throw Exception("Dot on the fold; aaa, what to do?")
                else -> dotsAfterFolding.add(
                    Dot(
                        x = instruction.location - (dot.x - instruction.location),
                        y = dot.y,
                    )
                )
            }
            Axis.Y -> when {
                dot.y < instruction.location -> dotsAfterFolding.add(dot)
                dot.y == instruction.location -> throw Exception("Dot on the fold; aaa, what to do?")
                else -> dotsAfterFolding.add(
                    Dot(
                        x = dot.x,
                        y = instruction.location - (dot.y - instruction.location),
                    )
                )
            }
        }
    }
    return dotsAfterFolding
}

fun prettyPrint(dots: Collection<Dot>) {
    val maxX = dots.maxOf { it.x }
    val maxY = dots.maxOf { it.y }
    (0..maxY).forEach { lineNumber ->
        val dotsForLine = dots.filter { it.y == lineNumber }
        (0..maxX).forEach { column ->
            print(if (dotsForLine.any { d -> d.y == lineNumber && d.x == column }) "#" else ".")
        }
        println()
    }
}
