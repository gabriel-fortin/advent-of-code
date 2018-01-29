package common

interface FindUnion {
    /** returns the id for the newly created set */
    fun addSet(): Int

    /** "union": returns the id of the merged sets */
    fun joinSets(set1: Int, set2: Int): Int

    /** "find": returns the id of the set containing the given element */
    fun findSet(element: Int): Int

    /** Number of sets currently in the structure */
    var setCount: Int
}