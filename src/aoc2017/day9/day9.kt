package aoc2017.day9

import kotlin.math.abs

fun main(args: Array<String>) {
//    val input = "<>"   // 0, 0
//    val input = "<random characters>"   // 0, 17
//    val input = "<<<<>"   // 0, 3
//    val input = "<{!>}>"   // 0, 2
//    val input = "<!!>"   // 0, 0
//    val input = "<!!!>>"   // 0, 0
//    val input = "<{o\"i!a,<{i<a>"   // 0, 10
//    val input = ""   //
    input.fold(GarbageCountingAnalyzer(), { analyzer: Analyzer, c -> analyzer.feed(c) })
            .apply { ensureCompleteness() }
            .apply { println(totalScore) }
            .apply { println((this as GarbageCountingAnalyzer).garbageCount) }
}




open class Analyzer {
    protected var isInGarbageMode: Boolean = false
        private set
    protected var isInCancelMode: Boolean = false
        private set

    private var nesting = 0
        set(value) {
            if (abs(value - field) != 1) exception("invalid nesting change")
            // increase total score only when opening scope
            if (value > field) totalScore += value
            field = value
        }

    var totalScore: Int = 0
        private set

    fun ensureCompleteness() {
        if (isInGarbageMode || isInCancelMode || nesting != 0) exception("you're a looser")
    }

    open fun feed(c: Char): Analyzer {
        if (isInGarbageMode) {
            handleGarbage(c)
        } else {
            handleContent(c)
        }
        return this
    }

    open protected fun handleGarbage(c: Char) {
        if (isInCancelMode) {
            isInCancelMode = false
        } else when (c) {
            '!' -> isInCancelMode = true
            '>' -> isInGarbageMode = false
        }
    }

    private fun handleContent(c: Char) {
        when (c) {
            '<' -> isInGarbageMode = true
            '{' -> nesting++
            '}' -> nesting--
            ',' -> {
            }
            else -> exception("character '$c' out of garbage")
        }
    }

    open fun exception(msg: String): Nothing = throw Exception(msg)
}


class GarbageCountingAnalyzer : Analyzer() {
    var garbageCount = 0
        private set

    override fun handleGarbage(c: Char) {
        var skipCounting = isInCancelMode
        super.handleGarbage(c)
        skipCounting = isInCancelMode || skipCounting

        if (! skipCounting && isInGarbageMode) {
            garbageCount++
        }
    }
}


class DebugAnalyzer : Analyzer() {
    var inputCount = 0

    override fun feed(c: Char): Analyzer {
        inputCount++
        return super.feed(c)
    }

    override fun exception(msg: String): Nothing {
        println("STATE:" +
                "  ${if(isInGarbageMode) "in garbage" else "-"}" +
                "  ${if(isInCancelMode) "in cancel" else "-"}")
        super.exception("(on ${inputCount}) $msg")
    }
}


