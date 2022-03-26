package day05

import java.io.File
import java.util.regex.Matcher
import java.util.regex.Pattern

//fun getInput(): List<Line> = getTestInput()
fun getInput(): List<Line> = getRealInput()

@Suppress("unused")
fun getTestInput(): List<Line> {
    return listOf(
        Line(0, 9, 5, 9),
        Line(8, 0, 0, 8),
        Line(9, 4, 3, 4),
        Line(2, 2, 2, 1),
        Line(7, 0, 7, 4),
        Line(6, 4, 2, 0),
        Line(0, 9, 2, 9),
        Line(3, 4, 1, 4),
        Line(0, 0, 8, 8),
        Line(5, 5, 8, 2),
    )
}

fun getRealInput(): List<Line> {
    val pattern = Pattern.compile("""(\d+),(\d+) -> (\d+),(\d+)""")
    return File("input.txt")
        .readLines()
        // create matcher for each line
        .map(pattern::matcher)
        .apply {
            forEachIndexed { index, matcher ->
                require(matcher.matches()) { "Could not parse input in line $index" }
            }
        }
        .map(::createLineFromMatcher)
}

private fun createLineFromMatcher(m: Matcher): Line {
    val (x1, y1, x2, y2) = listOf(
        m.group(1),
        m.group(2),
        m.group(3),
        m.group(4)
    ).map(Integer::parseInt)
    return Line(x1, y1, x2, y2)
}

