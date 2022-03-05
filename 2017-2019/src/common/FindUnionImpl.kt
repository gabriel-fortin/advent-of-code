package common

class FindUnionImpl : FindUnion {
    private val parents: MutableMap<Int, Int?> = HashMap()
    private var lastIndex = -1

    /** Number of sets */
    override var setCount = 0

    override fun addSet(): Int {
        setCount++
        parents[++lastIndex] = null
        return lastIndex
    }

    override fun joinSets(set1: Int, set2: Int): Int {
        if (set1 !in (0..lastIndex) || set2 !in (0..lastIndex)) {
            throw Exception("invalid argument")
        }

        val set1Root = findSet(set1)

        if (findSet(set2) == set1Root) return set1Root

        setCount--

        /* attach set2 and all its ascendants to the new root */
        var el = set2
        while (true) {
            val p = parents[el]
            parents[el] = set1Root
            el = p ?: break
        }

        return set1Root
    }

    override fun findSet(element: Int): Int {
        var el = element
        while (true) {
            el = parents[el] ?: return el
        }
    }
}