package common


class KnotHash(val size: Int = 256) {
    var arr: List<Int> = (0 until size).toList()
        private set
    private var skip = 0
    private var pos = 0

    fun compute(rawInput: String): String {
        val input = preprocess(rawInput)
        for (i in (1..64)) {
            twist(input)
        }
        val output = postprocess()
        return output
    }

    private fun preprocess(input: String): List<Int> {
        val lengthsSuffix: List<Int> = listOf(17, 31, 73, 47, 23)
        return input.map { it.toInt() } + lengthsSuffix
    }

    private fun twist(lengths: List<Int>): KnotHash {
        for (len in lengths) {
            twist(len)
        }
        return this
    }

    private fun twist(howMuch: Int): KnotHash {
        if (howMuch > size) throw IllegalArgumentException()

        val ararar = arr + arr + arr

        val tmp = ararar.subList(0, pos) +
                ararar.subList(pos, pos + howMuch).asReversed() +
                ararar.subList(pos + howMuch, 2*size)

        // pos chosen as limit because (size + pos) > (pos + howMuch)
        arr = tmp.subList(size, size+pos) + tmp.subList(pos, size)
        if (arr.size != size) throw Exception("ERROR!!!111one")

        pos = (pos + howMuch + skip) % size
        skip++

        return this
    }

    private fun postprocess(): String {
        return arr
                .windowed(16, 16)
                .map { it.reduce { a, b -> a xor b} }
//                .also { it.forEach { print(" " + it) } ; println() }
                .map { String.format("%02x", it) }
//                .also { it.forEach { print("" + it) } ; println() }
                .reduce { a, b -> a + b }
    }

}
