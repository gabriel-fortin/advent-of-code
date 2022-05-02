package day11

/**
 * An Octopus flashes once it reaches a certain energy level.
 * It will flash only once until [resetEnergyLevel] is called.
 */
class Octopus private constructor (startingEnergyLevel: Int) {
    private var energyLevel = startingEnergyLevel

    /**
     * Whether the octopus has reached an energy level causing it to flash.
     * If true, it implies that the [onFlash] callback has been called
     */
    var hasFlashed = false
        private set

    /** Called when the octopus reaches the energy level where it flashes */
    var onFlash: () -> Unit = {}

    /** Might lead to a flash. */
    fun increaseEnergyLevel() {
        energyLevel++
        if (energyLevel >= FLASH_ENERGY && !hasFlashed) {
            hasFlashed = true
            onFlash()
        }
    }

    fun resetEnergyLevel() {
        hasFlashed = false
        energyLevel = 0
    }

    companion object {
        private const val FLASH_ENERGY = 10

        fun fromEnergyLevel(startingEnergyLevel: Int) =
            Octopus(startingEnergyLevel)
    }
}
