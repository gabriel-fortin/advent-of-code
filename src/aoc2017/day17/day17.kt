package aoc2017.day17

const val stepsPerTraversal = 335  // input

fun main(args: Array<String>) {
    var current = Item(0)

    for (i in 1..2017) {
        for (x in 1..stepsPerTraversal) current = current.next
        // insert new item
        val new = Item(i, current.next)
        current.next = new
        // move current position to point to it
        current = new
    }
    println(">>>  ${current.next.number}")
}

data class Item(val number: Int) {
    constructor(number: Int, next: Item) : this(number) {
        this.next = next
    }
    var next: Item = this
}