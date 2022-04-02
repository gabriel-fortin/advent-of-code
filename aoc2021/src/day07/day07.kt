package day07

import java.lang.Integer.min
import kotlin.math.abs

const val DEBUG = true

fun main() {
    val input = getInput()

    val part1 = part1ButClever(input)
    println("part1: $part1")

//    val part2 = part2(input)
//    println("part2: $part2")
}

@Suppress("unused")
fun part1(input: List<Int>): Int {
    val sortedCrabsPositions = input.sorted()
    val crabCount = input.size

    var groupSeparationIndex = 0
    var leftGroupCost = 0
    // right group will contain crabs aligned to the current align position
    var rightGroupCost = sortedCrabsPositions.sumOf { it - sortedCrabsPositions[0] }
    var minCost = Int.MAX_VALUE
    var leftGroupSize = 0
    var rightGroupSize = sortedCrabsPositions.size

    for (alignPosition in sortedCrabsPositions[0]+1..sortedCrabsPositions.last()) {
        val newSeparationIndex = sortedCrabsPositions.indexOfFirst { it >= alignPosition }
        val crabsChangingGroup = newSeparationIndex - groupSeparationIndex
        leftGroupSize += crabsChangingGroup
        rightGroupSize -= crabsChangingGroup
        leftGroupCost += leftGroupSize
        rightGroupCost -= rightGroupSize

        val costAtThisAlignment = leftGroupCost + rightGroupCost
        if (DEBUG) {
            val leftGroup = sortedCrabsPositions.subList(0, groupSeparationIndex)
            val rightGroup = sortedCrabsPositions.subList(groupSeparationIndex, crabCount)
            println("$leftGroup / $rightGroup")
            println("will align to: $alignPosition")
            println("new separator will be at  $newSeparationIndex  ($crabsChangingGroup crabs change group)")
            println("new cost:  $leftGroupCost / $rightGroupCost  ($costAtThisAlignment total)")
            println()
        }

        groupSeparationIndex = newSeparationIndex
        minCost = min(minCost, costAtThisAlignment)
    }
    return minCost
}


fun part1ButClever(input: List<Int>): Int {
    val sortedCrabsPositions = input.sorted()
    val crabCount = input.size

    val alignPos = when {
        crabCount % 2 == 1 -> {
            // the middle element
            sortedCrabsPositions[crabCount / 2]
        }
        else -> {
            // average of the two middle elements, rounded to the closest integer
            val sumOfMiddleCrabPositions = (sortedCrabsPositions[crabCount / 2 - 1] + sortedCrabsPositions[crabCount / 2])
            (sumOfMiddleCrabPositions.toDouble() / 2 + 0.5).toInt()
        }
    }
    return sortedCrabsPositions.sumOf { abs(it - alignPos) }
}
