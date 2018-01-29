package aoc2017.day6

fun main(args: Array<String>) {
    val testInput = listOf(0, 2, 7, 0)

//    println(BasicReallocator.CREATE().performReallocations(testInput))
    println(BasicReallocator.CREATE().performReallocations(input))

//    println(CuriousReallocator.CREATE().performReallocations(testInput))
    println(CuriousReallocator.CREATE().performReallocations(input))
}

abstract class Reallocator(
        val findVictim: (List<Int>) -> Int,
        val redistribute: (List<Int>, Int) -> List<Int>)
{
    open fun performReallocations(memoryBanks: List<Int>): Int {
        var mem = memoryBanks
        var loopCount = 0
        while (!shouldStopAllocating(mem)) {
            val victim = findVictim(mem)
            mem = redistribute(mem, victim)
            loopCount++
            afterRealloc(mem)
        }
        return loopCount
    }

    abstract fun shouldStopAllocating(mem: List<Int>): Boolean;

    open fun afterRealloc(memState: List<Int>) {}
}

open class BasicReallocator : Reallocator {
    companion object Creator {
        fun CREATE(): BasicReallocator {
            return BasicReallocator(::selectVictim, ::redistribute)
        }

        fun selectVictim(mem: List<Int>): Int {
            val result = mem
                    .foldIndexed(Pair(-14, -15)) { index, acc, item ->
                        if (item > acc.first) Pair(item, index)
                        else acc
                    }.second

//            println("  select $mem  ->  $result")
            return result
        }

        fun redistribute(memBank: List<Int>, pos: Int): List<Int> {
            val value = memBank[pos]
            val mem = memBank.toMutableList()
            mem[pos] = 0
            for (i in 0 until value) {
                mem[(pos + i + 1) % memBank.size]++
            }
//            println("redistribute $memBank  =>  $mem")
            return mem
        }
    }

    constructor(
            findVictim: (List<Int>) -> Int,
            redistribute: (List<Int>, Int) -> List<Int>
    ) : super(findVictim, redistribute)

    private val knownConfigs = hashSetOf<List<Int>>()
    private var repetitionFound = false

    override fun performReallocations(memoryBanks: List<Int>): Int {
        beforeReallocationsBegin(memoryBanks)
        return super.performReallocations(memoryBanks)
    }

    open fun beforeReallocationsBegin(firstConfiguration: List<Int>) {
        knownConfigs.add(firstConfiguration)
    }

    override fun afterRealloc(memState: List<Int>) {
        if (!knownConfigs.add(memState)) repetitionFound = true
    }

    override fun shouldStopAllocating(mem: List<Int>): Boolean {
        return repetitionFound
    }
}

class CuriousReallocator : BasicReallocator {
    companion object {
        fun CREATE(): CuriousReallocator {
            return CuriousReallocator(
                    BasicReallocator.Creator::selectVictim,
                    BasicReallocator.Creator::redistribute)
        }
    }

    constructor(
            findVictim: (List<Int>) -> Int,
            redistribute: (List<Int>, Int) -> List<Int>
    ) : super(findVictim, redistribute)

    val knownConfigs = mutableListOf<List<Int>>()

    override fun performReallocations(memoryBanks: List<Int>): Int {
        val steps = super.performReallocations(memoryBanks)
        val occuredAtPos = knownConfigs.indexOf(knownConfigs.last())
        return steps - occuredAtPos
    }

    override fun beforeReallocationsBegin(firstConfiguration: List<Int>) {
        super.beforeReallocationsBegin(firstConfiguration)
        knownConfigs.add(firstConfiguration)
    }

    override fun afterRealloc(memState: List<Int>) {
        super.afterRealloc(memState)
        knownConfigs.add(memState)
    }

}

