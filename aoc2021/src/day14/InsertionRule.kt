package day14

data class InsertionRule(
    val pattern: String,
    val replacement: String
)


fun parseInsertionRule(line: String): InsertionRule {
    val insertionRuleRegex = Regex("""(\w\w) -> (\w)""")

    val groups: List<String> =
        insertionRuleRegex
            .matchEntire(line)
            ?.groupValues
            ?: throw Exception("Could not match insertion rule; input: '$line'")

    return InsertionRule(groups[1], groups[2])
}
