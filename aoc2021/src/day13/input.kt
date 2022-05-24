package day13

import java.io.File

val DOT_REGEX = Regex("""(\d+),(\d+)""")
val INSTRUCTION_REGEX = Regex("""fold along (\w)=(\d+)""")


fun getInput(): Input {
    val lines =
        getTestInput()
//        getRealInput()

    val dots = lines.takeWhile { it.isNotEmpty() }.map(::parseDot)
    val instructions = lines.drop(dots.size + 1).map(::parseInstruction)
    return Input(dots, instructions)
}

fun getRealInput(): List<String> = File("input.txt").readLines()

@Suppress("unused")
fun getTestInput() = listOf(
    "6,10",
    "0,14",
    "9,10",
    "0,3",
    "10,4",
    "4,11",
    "6,0",
    "6,12",
    "4,1",
    "0,13",
    "10,12",
    "3,4",
    "3,0",
    "8,4",
    "1,10",
    "2,14",
    "8,10",
    "9,0",
    "",
    "fold along y=7",
    "fold along x=5",
)


fun parseDot(s: String): Dot {
    val values = DOT_REGEX.matchEntire(s)!!.groupValues
    return Dot(
        x = Integer.parseInt(values[1]),
        y = Integer.parseInt(values[2]),
    )
}

fun parseInstruction(s: String): FoldInstruction {
    val values = INSTRUCTION_REGEX.matchEntire(s)!!.groupValues
    return FoldInstruction(
        axis = when (values[1]) {
            "x" -> Axis.X
            "y" -> Axis.Y
            else -> throw Exception("Unrecognised axis")
        },
        location = Integer.parseInt(values[2]),
    )
}
