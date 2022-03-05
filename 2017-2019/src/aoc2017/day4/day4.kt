package aoc2017.day4


fun main(args: Array<String>) {
    println("hello")
    println(INPUT.take(200))

    // PART 1  (took 25 minutes)
    prepare(INPUT)
            .map { isCorrectPassphrase(it) }
            .sumBy { if (it) 1 else 0 }
            .apply(::println)

    // PART 2  (took 5 minutes)
    prepare(INPUT)
            .map(::isCorrectPassphrase2)
            .sumBy { if (it) 1 else 0 }
            .apply(::println)
}


fun isCorrectPassphrase(passphrase: List<String>): Boolean {
    val words = hashSetOf<String>()

    for (word in passphrase) {
        val alreadyOccurred = ! words.add(word)
        if (alreadyOccurred) return false
    }

    return true
}


fun isCorrectPassphrase2(passphrase: List<String>): Boolean {
    val words = hashSetOf<CharSequence>()

    for (rawWord in passphrase) {
        val word = String(rawWord.toSortedSet().toCharArray())
        val alreadyOccurred = ! words.add(word)
        if (alreadyOccurred) return false
    }

    return true
}




fun prepare(input: String): List<List<String>> = input
        .lines()
        .filter { it.isNotBlank() }
        .map { it.split(' ') }
