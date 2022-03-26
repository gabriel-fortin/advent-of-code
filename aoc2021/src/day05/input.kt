package day05

import java.io.File
import java.util.regex.Matcher
import java.util.regex.Pattern

fun getInput(): List<Line> {
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

