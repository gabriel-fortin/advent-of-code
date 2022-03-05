package aoc2017.day10

val lengthsSuffix: List<Int> = listOf(17, 31, 73, 47, 23)

fun main(args: Array<String>) {
//    prepare(input)
//            .fold(Kekeke(256)) { kh, i ->
//                kh.doTheThingJulie(i)
//            }
//            .arr
//            .also { println("RESULT: ${it[0]} * ${it[1]}  => ${it[0]*it[1]}") }

    val input =
            prepare2(input)
            .also { println(it) }
    val kkk = Kekeke(256)

    (1..64).forEach {
        input.forEach { kkk.doTheThingJulie(it) }
    }

    kkk.arr
            .windowed(16, 16)
            .map { it.reduce { a, b -> a xor b} }
            .also { it.forEach { print(" " + it) } ; println() }
            .map { String.format("%02x", it) }
            .also { it.forEach { print("" + it) } ; println() }
            .reduce { a, b -> a + b }
}


class Kekeke2(val size: Int = 256) {
    var arr: List<Int> = (0 until size).toList()
        private set
    private var skip = 0
    private var pos = 0

    fun doTheThingJulie(len: Int): Kekeke2 {
        val ararar = arr + arr + arr

        val tmp = ararar.subList(0, pos) +
                ararar.subList(pos, pos + len).asReversed() +
                ararar.subList(pos + len, 2*size)

        arr = tmp.subList(size, size+pos) + tmp.subList(pos, size)
        if (arr.size != size) throw Exception("ERROR!!!111one")

        pos = (pos + len + skip) % size
        skip++

        return this
    }
}


fun prepare2(input: String): List<Int> {
    return input.map { it.toInt() } + lengthsSuffix
}

