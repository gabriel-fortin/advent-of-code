package aoc2017.day6

val rawInput = """11	11	13	7	0	15	5	5	4	4	1	1	7	1	15	11"""
val input = rawInput
        .split("\t", " ")
        .map { try { Integer.parseInt(it) } catch (ex: NumberFormatException) { null } }
        .filterNotNull()
