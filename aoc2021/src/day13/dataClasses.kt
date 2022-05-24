package day13

data class Input(
    val dots: List<Dot>,
    val instructions: List<FoldInstruction>,
)

data class Dot(
    val x: Int,
    val y: Int,
)

data class FoldInstruction(
    val axis: Axis,
    val location: Int,
)

enum class Axis { X, Y }
