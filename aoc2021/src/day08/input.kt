package day08
import java.io.File

//fun getInput() = getTestInput()
fun getInput() = getRealInput()

@Suppress("unused")
fun getTestInput(): List<Entry> {
    return TEST_INPUT.map(::parseInputLine)
}

fun getRealInput(): List<Entry> {
    return File("input.txt")
        .readLines()
        .map(::parseInputLine)
}

fun parseInputLine(inputLine: String): Entry {
    val (leftPart, rightPart) = inputLine.split(" | ")
    val testDigits = leftPart
        .split(" ")
        .map { SignalPattern(it.toSet()) }
    val valueDigits = rightPart
        .split(" ")
        .map { SignalPattern(it.toSet()) }
    return Entry(testDigits, valueDigits)
}


val TEST_INPUT = listOf(
    "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
    "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
    "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
    "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
    "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
    "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
    "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
    "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
    "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
    "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
)