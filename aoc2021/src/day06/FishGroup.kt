package day06

data class FishGroup(var fishTimer: Int, var count: Long) {
    fun advanceTimer(onNewFishIsSpawning: (newSpawnsCount: Long) -> Unit) {
        when (fishTimer) {
            0 -> {
                fishTimer = 6
                onNewFishIsSpawning(count)
            }
            else -> fishTimer--
        }
    }

    fun addFish() = count++
}