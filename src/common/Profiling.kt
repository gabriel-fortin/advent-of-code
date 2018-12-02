package common


fun <T> measure(block: () -> T): T {
    val nanoTimeBefore = System.nanoTime()
    val result = block()
    val nanoTimeAfter = System.nanoTime()
    val nanoDiff = nanoTimeAfter - nanoTimeBefore
    println("   >> MEASURED TIME: ${nanoDiff / 1000_000_000.0}s")
    return result
}
