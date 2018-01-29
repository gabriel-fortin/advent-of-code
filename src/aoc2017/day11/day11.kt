package aoc2017.day11

import kotlin.math.abs
import kotlin.math.max

fun main(args: Array<String>) {

    val loc = Location()

//    "ne,ne,sw"  // 1
//    "n,se,s,sw,nw,n,se"  // 0
//    "n,se,s,sw,nw,n,ne,s"  // 0
    rawInput
            .toUpperCase()
            .split(',')
            .map(Dir::valueOf)
            .apply(::println)
            .forEach(loc::move)

    println(loc.distanceFromBeginning())
    println(loc.furthest)

}


data class Vec(
        val x: Int,
        val y: Int,
        val z: Int
) {
    operator fun times(scalar: Int): Vec = Vec(x*scalar, y*scalar, z*scalar)
    operator fun plus(v: Vec): Vec = Vec(v.x+x, v.y+y, v.z+z)
}


enum class Dir(val vec: Vec) {
    N(Vec(0, -1, 1)),
    NE(Vec(1, -1, 0)),
    SE(Vec(1, 0, -1)),
    S(Vec(0, 1, -1)),
    SW(Vec(-1, 1, 0)),
    NW(Vec(-1, 0, 1)),
}


class Location {
    val start = Vec(1000, 1000, 1000)

    var current = start
        private set

    var furthest = 0
        private set

    fun move(dir: Dir) {
        current += dir.vec
        furthest = max(furthest, distanceFromBeginning())
    }

    fun distanceFromBeginning(): Int = dist(start, current)

    fun dist(v1: Vec, v2: Vec): Int = listOf(
            v2.x - v1.x,
            v2.y - v1.y,
            v2.z - v1.z
    )
            .map(::abs)
            .max()!!
}

