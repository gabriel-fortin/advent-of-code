package day13

fun main() {
    val input = getInput()

    val part1 = part1(input)
    println("part 1: $part1")

//    val part2 = part2(input)
//    println("part 2: $part2")
}

fun part1(input: Input): Int {
    val dotsAfterFolding = mutableSetOf<Dot>()
    val instruction = input.instructions.first()
    input.dots.forEach { dot ->
        when (instruction.axis) {
            Axis.X -> when {
                dot.x < instruction.location -> dotsAfterFolding.add(dot)
                dot.x == instruction.location -> throw Exception("Dot on the fold; aaa, what to do?")
                else -> dotsAfterFolding.add(Dot(
                    x = instruction.location - (dot.x - instruction.location),
                    y = dot.y,
                ))
            }
            Axis.Y -> when {
                dot.y < instruction.location -> dotsAfterFolding.add(dot)
                dot.y == instruction.location -> throw Exception("Dot on the fold; aaa, what to do?")
                else -> dotsAfterFolding.add(Dot(
                    x = dot.x,
                    y = instruction.location - (dot.y - instruction.location),
                ))
            }
        }
    }

    return dotsAfterFolding.count()
}
