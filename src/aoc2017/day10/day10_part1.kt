package aoc2017.day10

const val input = "192,69,168,160,78,1,166,28,0,83,198,2,254,255,41,12"

fun main(args: Array<String>) {
    prepare(input)
            .fold(Kekeke(256)) { kh, i ->
                //            .fold(KnotHash()) { kh, i ->
//    prepare("3,4,1,5")
//            .fold(Kekeke(5)) { kh, i ->
                kh.doTheThingJulie(i)
//                kh.twist(i)
//                kh
            }
            .arr
            .also { println("RESULT: ${it[0]} * ${it[1]}  => ${it[0]*it[1]}") }
}


class Kekeke(val size: Int = 256) {
    var arr: List<Int> = (0 until size).toList()
        private set
    private var skip = 0
    private var pos = 0

    fun doTheThingJulie(len: Int): Kekeke {
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


class KnotHash(val size: Int = 256) {
//    class Item(val value: Int) {
//        val neighbours: MutableList<Item> = mutableListOf()
//        var flipControl: Int = 1
//        fun next(): Item =
//    }

    private var arr: List<Int> = (0 until size).toList()
    private var shifted = 0
    private var skip = 0

    fun twist(howMany: Int) {
        println("howMany=$howMany  shift=$shifted  skip=$skip")
        var arr = this.arr + this.arr
        val beginning = arr.slice(0 until howMany)
        val intRange2 = howMany until (howMany + skip)
        val middle = arr.slice(intRange2)
        val intRange3 = ((howMany + skip)) until size
        val ending = arr.slice(intRange3)

        this.arr = ending + beginning.asReversed() + middle
        shifted = (shifted + howMany + skip) % size
        skip++

        debugPrint()
    }

    private fun debugPrint() {
        (0 until size)
                .forEach { print("${get(it)}  ") }
        println()
    }

    operator fun get(index: Int): Int {
        if (index < 0 || index >= size) {
            throw ArrayIndexOutOfBoundsException()
        }
        val i2 = ((size - shifted) + index) % size
        return arr[i2]
    }

}


fun prepare(input: String): List<Int> {
    return input.split(",")
            .map(Integer::parseInt)
}

