namespace Advent_of_Code_2024.day15;

public static partial class Day15
{
    public static class Input
    {
        public static string GetInput(InputSelector inputSelector)
        {
            return inputSelector switch
            {
                InputSelector.Example1 => GetExample1Input(),
                InputSelector.Example2 => GetExample2Input(),
                InputSelector.MyInput => GetMyPuzzleInput(),
                _ => throw new ArgumentOutOfRangeException(nameof(inputSelector), inputSelector, null)
            };
        }


        private static string GetExample1Input() =>
            """
            ########
            #..O.O.#
            ##@.O..#
            #...O..#
            #.#.O..#
            #...O..#
            #......#
            ########

            <^^>>>vv<v>>v<<
            """;

        private static string GetExample2Input() =>
            """
            ##########
            #..O..O.O#
            #......O.#
            #.OO..O.O#
            #..O@..O.#
            #O#..O...#
            #O..O..O.#
            #.OO.O.OO#
            #....O...#
            ##########

            <vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
            vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
            ><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
            <<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
            ^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
            ^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
            >^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
            <><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
            ^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
            v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^
            """;

        private static string GetMyPuzzleInput() =>
            """
            ##################################################
            #.....O..O....O.#.OOO...#....#....OO......OOOO...#
            #O......OOO..#..O...O.#........O.OOOO.OOO........#
            #..#..O.O..O.......O....#..O.O..O.O#...OOO....O..#
            #.......O..O..O.O.#..#......O#..OO...#..##..O.O..#
            #.#...O....O......O...O#.OO.....OO..#.O..O.......#
            #OOO.O....OOOOOOOO.O...O..O.O..O.........O....O.O#
            #.O...#.##.#.....O.O.O...........O....OOO#OO..O..#
            #.OO.O.O.....O.#OO......O.O#.O.O........OO.O.....#
            #...O....#OOO.OOO.O#.........OO#.O....O.O..O.OO..#
            ##O#O#.....O..O..#...O.........O.O....O..#OO#..#O#
            #.OO.O.....#.O.#.O....O...O...O..O....O##O..O#O..#
            #.O..O.O......OO.#..O...O.O..#....#...O.O#.##..#.#
            #......O....#O..O.....O.......O..O....OO..#..O..O#
            #.#.O....O..#O.O...O.#...O..#..........OO...O....#
            #OOO...#O....O..O..OOO..O......#O..O#O.....O..O..#
            #......O......O..#.....O.....OOOO...OO.OOO.O.....#
            #.O.O..O.O..#.....#OO..OO.#O..OO..O.O#O....O..#..#
            #.O.OOO..O..OO.........O...OOO...#..OO.O.O.....#O#
            #.......OO..O...OO......OO.......O.O.O..#..##.O.##
            #O..O.O...#...OO....OO.....O...OOO...#O..O.O.....#
            #..#.O.#O..OO.OO..O..#OO#..OOO.....O....OO.O....O#
            #O...O..O#..###..#OOOO.O.O.O.O.....#OOO....O.OOO.#
            #....O.OO.#..#........OO......O.#..O.O.O.........#
            #.O.O#O....O....O#..O.#.@.....O..OO.......OO..OOO#
            #OOO........#..OO#....#.O.O..#..O#..............O#
            #..O.OO.O.O.O#.OO.OO#OO.O....OOO.#O.O...OOO..O#..#
            #..........O..O.....O..O......O......#OO.OO..O...#
            #....O.O...O...O.O.O.OO.#O.......#O.O...O....O...#
            #......O..OO......##....O#O....#.O.....#..#.O...O#
            #..O...O...O..O.#.....#OO..O.O#..O....O.O.....O..#
            #OO.....O..O.....OO...#........O.O#O..OO..O....O.#
            #.OOO..O...O....#...O#O.O.O.#...O.O.....O..OO...O#
            #.O..O......O..#..O.......#.OO..O.O........#.....#
            #...O.O.O..OO..OO.#.O..O...........OO....O.OOO.###
            #O....#..#..#.....OO..O..OO....O......O..O#......#
            #...O.O........O..#.O.O#.....O.O.O.O..O..#.O.O..O#
            #...OO..O.....O............#.....O.O.O.....OO..O.#
            #OO#O.O.O#..#.#..O.#....##.OOO......O..O.#...O...#
            #..OO....O.......O.....O#...O.......OO#O...O...O.#
            #.#.OO.....#OOO..#.......O.O.O....O..............#
            #O........#.O.OO....OOO..O.......#.OO.O.O....#...#
            ##O........O.O..#.....OO#O.O.OOOO.#...OOO.#O#O#.##
            #..O....O.#OO....OOO.##.#O..O..O..#O.O..OO.......#
            #O...#..#O.O.OO..##.O.O..O......O.O.O...#OO.##O.##
            ##..............OO...O..O........#.....O..OO..O..#
            #.O.#O.OO...OO.O.O.O..OOO....O.O.O...OO.O....#..##
            ##O.....O#....#O#..O##......##.#OOOO.#.OO.O.OOO..#
            ##.O......#........OO#.O..#.#..O.O.OO.#.O..O#.O.##
            ##################################################

            <vv^><<vv>v>v>^^><>><<^vv>^v>^>^>>>^><>^vv^v><v<^><>><v^^^v>^>>>^^^^>>^v^>^v>vvv<<<<>v><^<^<><><><v><><<<^>><><>v<>^>><<<v^vv><^<<^v>>^v^^<<<>>vv^^^^<<^>>^v^><<v<<><>^<vv<<v<^<<>^<vvv>^><>vv^^v>><v>^^^>v^<v^<^<v>v^vv<^<v>><^vv<^><<v^^<<^><vv^v>v<><^<>v<v^<v^>v><<^>^^^<><<><v<vvv^>^vvv^><v<<v<><<^<v><v>^>><^v>><>^v<^^v^^<v<><^>>^^vv>>^^^<^v><<^^^>^^><^>vv<><<v<>>^v^<<^><^v^^v><<v><><><vv<^<v<>v<<<<>vv<>^<<<v>v>>><<<^v>>^^>vv><vv<<v>^vv^v<^><v<<^<<^<>>^v>>^vvv^<>v<^^^<<v>vvv>vv^^<vv<<^>v<<><>>^>v>>vv<<^vv^^^<<v>^^<^^^^^vv><>^vv>^v^^<<>>>^v^v>^^^<<><vv>v><v^^^^<<^>>^<>v^v<^^<v>^^<><><><^^>>v<v>^>^><^><v><<<<vvv^><^^^v>^^<^^v>^>v>>v>>>v^<^>vv<>^v>>>^>vv^>v^<>v><^><<v<v><><<<vvvv>v>^^vv<>>v^^v>v^^<^>>><>>vv>^<vv^><><><<<vv<>v<^v>>v<v<v<^<v><^vv<vv<^>^<vv><v>>v>>^>^v<><<^v>^^>v^v<^^^>^vv>^^<<v>^v>><^>^>^<>^^<^^<v>v<<>^>>^v<v^v>v<>v^^>^<v<v>vvvv><>>^^>>^<v<v^>>^v^<v>^v^^^^<^<vv^><>vvv<v>^<vvvv^>^^^^>^^^^^>v^v>v>>v^><<v<<<^^vv>><<v>^>>^<^>>v^<<v<^vv>vv>v<<^<>v^>>><v><v^v^v<v<v^>^^^v>v>^^v^^>v<
            v>>^v<^><^><<>>><>>v^<<<>^^<<^^><><>vv<^<^^^<<^<v<><<<vvv<v^^v>^v>v<<>v<v>v^^><v>^v^^<v^^^<vvv><<^<v>v^^v>>>^^<v^v><<<>^^>^>v<v^<vv^>^<<^vv>>v^>v^v<<<v^v<v>^>v<<vv<^^<^v><>^<>v^v>>^v<v^v^^v^>^>^>>vv><^<vv>><vvv<v^<vv<>vv^vv^^<>vv>^^<<<<v^>v>^^><><v<vv^v^^<<vv>^^<^<<^<>^<<vvv^^v<<><v><>^>>v^vv^v>><v<v<<<^^^^^<><^<><><^<<<>^v^v><^<^^^^v^<v^>^v^<v^^<<>>>^^v>><>>>><<vvv^<v>^v>>>v<^^<<^^><>^^>>^<^<>>^v><v<<<v>>>v>^^<^>>^><^v>>v><<v<v<^^<v<^^v>^^<><><>vv^^^<v^<v^^vv<vv^^<<v>>^^v>>v><><<v^v>^>><><^>^^^<^^v<>^v^<<>>vvv<<^<v^v><<>^<v<>>v<v^^vv>^>>vv<<^<<v>v^v<v>vvv^<<<>^<vvv<>^^vv<^<^^<v^>>>><<^>>^^^>^v><v<^^<>>>>v^v<<vv>>^vvv<^vv<<v^^<^^<v>>^<<v>^>>^>vv^v<>>^<v>^>>^v<>><^>>>><<<>^v^^v>v<^v^^vvv<<>^><<v<<v^v>v><>^v<<^^^vv<<<<<<vv<v^^>v<<vv^<<v>v^v<<v>vvv^<vvv>v<v<>v<<v<v>>>^>^^v^<><<<>^<><>^>^>^>><>>><v<^<v<v<><<>^>^v<^^<>>^^<^<<><<<<<^^v><<^<v^v^<<^v^<<^>^>><^>^v<v<^v^>vv<>v<>>>v^^^>^v<vvv^^<^<vvv<^<>>><v<v><v<^<vvvv><^<<v<<^<<<^v^>v<>^v<^>>^>^>v>^^<><v>^<><<^<<<<<<>^v>>^><<><^^>>^vvv>^v>v>^<<
            >><^<>><>vv^v<v>^>vvv>^<<<<><>v>v^<v><<>v^>>^^^^<^v><vv<<<><<^<v>>v^<vv^>^<v>^<v<<v>>vv<v^^v>^>v^v<<>>vv^><v<<>>^><><<^v><v^^^<v>vv<<<>^<<v>vvv^v<<^^v^^^><<^<vv<><^>v<^>^<<^v^<vv><v>>v<>^<<vv<^<v>^>v<^<>>^v<^><>><^^^v<<v>>v>^>^>>v<<><^v^>^<^>^<>^>^^>vv><<vv^>>>^<>^vv^v^<v>^>v^>>^><vvv^v<v<>vv^>^><v>^vv>^vv<>^<vv><<v<v^v>vvv><^v<><>^^^^v^^v^<v^<^v<>^v>>^v^v>vv<^<>><><vv<v^^>v<vv^^^^^^v>>><v>vvv^vv>^<^<>v^<^^<^<<<<>><<<v><>vv^>v^<>^^<>>>v<>v<<><v^<<^vv><<v>>>^v<>v^<>v^v>v<v^vv>^^><<^v>vv^v>><v><v<v<vv<<><^^<v^vv^^<<>v<<v<vv>>^^<<^<^><v<<<^<^>^>>^^<>^^v>^>^><^<<<<>v^>>><^v^v<v>^<^^<>>v<^>v^^<vvv<^v>>v<><vv>^^vv>>^<^v^^^v>><^<^^<vv<<vv^^<v><v^v>vv>^v<^^>v>v^vv^v<^<>^<<>v>>><<<<>>>>vv>><<v<vv><v>><>>v^<^v><^^^<>>^>>vv^><^>vv<<v<><^^>^><<vv<<>>v^<^<^<^<vvv^<>^><<<^>>v<>^>v<<><vv<<>^^v^vvv>^>vv^<>v<^>v<^<v<^><<v<>>^v>v^<<v><>^<^<>v^<^^<^>^^>^<>v>v<v^^^>v>>>v^>>vv>>v><v>v>^^^<v>>^v^^^<>><<v>^vv<^vv^^^^^>><<v>^^<<v^v>v<>>vv>v<>^^v>^>^<<^^^^<v>v^v^<<<v<^>^^>^<v<v^<^<v<><<><v^<^v^^^^v^<^<^v<vv>v>
            v<^^<>v^v<><<^^<v^>><<>>v<vv^vvv>v<>^>><>><v^<v>^>v>v^v<><v<<<<<<v^v^<<>vv<v^<^<>^<<^^vv<v<>>^^v<<vv^>v^>^><>^v>^^>^v^<><>v<<^>>v<v^<^<<><<^><<<<^v>>v^v<>v>v>>v>><vvv^v>^^^^<>^<v><>vv^<>^v>^<>>>>^<v<>>><v<^><v<^^<<<<v^>>>^<v<^^>^<^^<><<^>v^v>^^>><<<<v><^^^>>v^>><^^<<vv>>v<>v^^^v<^v><<^v>vv^vv<^>>>^vv^>v<>^<>v><^>^v><<><>v>^><v>^<v><vv^^^>v^^^>v^<vvv^v<v^vvv^v>^^^<v>><v^>>v>^>^v>v<^^^>^>>v^>^v>v^^^^<v^v<v^^v><<<v<v>v^^>v<><v^>>v^^^^>^<v<>>><^v<><v^^^^^>v^^^><>>^<^v<v^<>v>>v<>><vv>><><^<>v<<^v^vv<v<><v>>v^^^<>^>^^>>>v>>^<v>^>^^v>>>>v>><>>>^v^<v<>^^><<^^v^<<^<^<><<v^v<<>^^^<^<>v^^<<>v^<>>><v^>>>>><^>^^vvv<>v<v<>vv>v><^><<<><<vv<^>^v<<><>>>>^^>v>^^<v><>>>v<<>><>v^vv<^^v<vvv><<>^<><vv^<^>vvvvv<<v<v<>^^v>v^vvvv<><<<v>v<^>v>>>>^>^>v>>v^>><^vv>^^<v>vvvv<>v<^^>>^<<><<<^<<vv<<vvv^>>>v<<>><<vv^v><>v<>>^><^<vv^^>v<v><v<>^<^v^<><v^<v<<>><^vv<<v>><<^<v<>>^<^>^^>>v^v><v^v<^^^v>vv>^^<><v^<v>v>v><<^^<v<v<^><>><^><><^>^^v<^^<^<><v>>>v<vvvv^<<>><v^<<<<^v>v><vv<^^<<^^>v>>vv>^^v>^vvv<v^>^v<>>>vv<v<<<>v><<<
            v<^<^<<vv^<^>v^>^^>>^^><<^<>v>^>v<^>^vv<^>v>>><<^v>^^^<<<<v^<vv^^><>v>v^vv>v><<<<><v<<v<^><<v>>>><^v>>vvv<<<^><<v<<<^><^v>^v^v^>^<<v>^^<^>^<>v^><<>vv<^<^<<v<<>^^^>^v^>>>^><<<^v<vv^^>v^^><^^>><<^<^^^vv^v><>>^v^<^v<><>v^><>v>v<>^>><^^>v<<v^>v>vv^<<<^>^<vv^^v<v^<<><vv<<^>^v<>v^v<><><><v>^>>^><^v>>><<v<>^^>^^^v<>^<v>v<><><>>>v<^<<<<v^^^^v<vv^^<<<<v>^^v>><v>>v<<<^vvv<>^<vv^vvvvvvv<>>>>v><^>><^><vv>>><>>>>^v^<^^><>^><>>>><vv^^>v>>>>>v^vv^<v^><>^>><^<^<v><><<>v^<vv>vvv<^<>>v<<^^>>^<>^^vv<v^v<vvv^>>><v<v<v^v>vv><^<><>^<v<<v<^vvv<vv>v>>v>^<<>^<>^^v<>>^v>v^v><><^><v^>vv>>^<<v^v<<<v<^<^v^<^<><^^^>>>v^v>v<^><><<^>^<^v^<><^v<v<>>v<<^^<>^<vv>v<<v^v^vvvvv^v>^><vv>vv<<^^vv>>^vv<<^>>^^^>><>vvv<>^>v><<<>^v^><^>^<<^^v^<<v>v<v>><><<v><^>><<^<^<<>>vv<<^vv>^^<<^<>^^<^v<v^v<^<><>>vvv><<>^>vv><v>>>v<<<>v>vvv<><><vvv<><vv^<v^^><<>^v<v<<<^<<<><>>>^^<^v<v<>v^<<v><<^<>v<>v<>^v<<<>^vv^>>^^v>v<^v<^<v<v^^><^^<<^<v><<v^>>v^>v^<v^^^v>^^>v<^vvv<v<v<<>>v^>v<^^>>^v<<^>vv<vvv><<v<v^^^<vv<v^><<v<^<^v>v<^v^>v<<>>>><>^^v^>>>
            vvvvv>vvv^vv<^>^v>><><>v^^v>^v^<<<^>>>vv>^>^<v>v>v<<^v<<v>><><<^v<^^v<^^^^^>v>^>v^v^^<^v^<v><<<<^>>>v<<<^vv^<^>>>v<^>^v<^<v><<^>vv<>>>^v>v>^>^<>^^><>^^v<v<^>v><v>>^vv^>vv^><v><>^><<^<v<>^^^vv>v^v^v<v^vvv>>>vv^vvvv^>>v^^<^<>v>v<<v<>^<^<^>v<>>^>v>^^<^v><>^<><>v^><>><^vv^>vv>>>^<vv<>>v>v<vv^vv><^vv^<^^<<^v<<>>^>v><vv<<^v<>v<^v><^>^<<v><v>vv<^<<<^<>^>>v>>>>>>v^<<vvv^<<v^<v><<v>>^<^><^>v^<><>>^<^^<^<>vv^>^>v><<<<v><vvv><^>^><>^^v><^^v><v^v>^<<^^^v<<>^>^vv<v^vv^v>><vv>>^<<^v<v<>vvv^<^v>>>^<v^v<vv>^v^><>v>v>>v>vv<^<^v>^<<>v^>>v>v<<<vvv>>v<>><<<<v^<<v>><<>>>^<>><^<v>^^^>^^^v^><<>>><^v<>>^>>^v><<^^<v<v<>v^^<><^^>>>vv^>v>>v^<>>>>vv>><v<^<^<^^^v>>v>v>vv^>>^^^><v^<^^<<>v>^>><>>^^vvv><>v>v^^>v^v<<v^v<<>>><>^>>v^>v^v^v^<<<^<><v<v><v^^<vv><<v<^v^>^^>>vvv>v><>^<v>v>>v<<><v^>><^v<<v>^^>v^^v^>vv<^><>>><v<v<><^<v<<>>^<<v>vv>^<v>vv>v><<vv>^>^v<^>>^v<<v<v><<v<><^^^^><^<^>v<^<^>>v<<^>^<v>v>^^^>^^>^^><v><v^><<^^^<>v<<^<^v^v><<>^^vv>^<<<<><<>>^^^<^vv^v><>v<<^>v^^^vv^^^v>>^^vv>>^^<^^^v>>>vv<^<vv>^<><>>vv>v<<<>
            ^^>^>><<<v<<>>>^^>v^<v<>v<<v<<<v<>>^>><v<>>^^^v>><<>>>><^^vv^>vv<<v^^v<<v<^>v<v^v<^>^^^v>v^v<v>>^v<^^v>v>v>>^<v<<v>v^>^>^^<v^vv>>>v^<^v<^^^>>v<vvv<^<^<^v<^>vvv<>vv<><v>v^<^^v^^vv<>>vv<v<><v><>vv><vv<<^><^<<<><<v<>^v<><^^v>>^>^^^>>^v>^v<>>^>vv<^^^^<><><><<^^^<^><^<v^v^v^^vv>v^^v>>>^<>>><<^^>^<<^<v><>>^^^>v<v<v<>><>><><>>^^v<<^^v>vvvvvv><v<<<^>^<^><<>>v^v^>v<^^<><vv<v<v<<><><vv^v^^v<^^v>^v^^<^>v^>v<v^vvv<^>vv^>>><v>>^v>>>^<v<v^^v<^<^^<<v><vv^>vv<v>v^v><^^>^^<^v<vv<>><vv^<>>^>>>^>>>><>><<^^<vv><v^<><<v<<vv^^v><<^<^<<vv^v<<<<<v^>^<>vv<>^vv^>>^>vvvv<<<vv<^v<v^^^^v>><<v>^v><v<>>v<^v<v^>><^^^v>v^v^vv>>v^><<^v<^v<<>><v>><v<v<>>><vv^<v>v^v<^<>>v<>v^vv^><>><v<vv<<v><>v<<<v^<><^>v<v><>vv^>>vvvv><<><>v>v^><<^<^>^<<vv<v>^^>v<vv>>vv>v<vv^>vv<<^v^vv<>v<vvv><^vv^vv^<<<^<v^vvv>>>>v<v><^>v^>vv<vv<v<<v<<v<v>^v<<v<^<^>^vv>><>>>^v>vv>>^<v<<<<^^><^>v><>><<>^<<<v^<v^<^<^>^^<v<>v>>v<^<v^><v>^>v^^^^><<><^<>>v^vvv<v<^<>^<v>v<<<vvv<v<<^<<<>^<v<^><><^<^><v^>v^v><^<v^<^>><v<>v^>v<v><^vv^<>^vv>v>><v<<>v^vv^<<><^vv^
            ^><^^^^>v<^<>^>v>^^^^v^>v><vv^vv<>v<^v<^<>^><><^^><v<^<v>>^^>^<<<<^<v>>^<^><^<><^^><v>v^>><<>v>^^^><<<^^<>^<^^^>^v><<^^<^><<^^>v>^<^<^^<>^^<^>^><>v<<<<v>^<<^v^><v>v<>^>v<^^vv^><<>^<^vv>vv^^v^<v<^vv>^>^^<>^^vv<<v>^^^<<^<<v<<<vvv<vv<<^<<^^^>^^^^^<vv<^vv<>^<v<<>><^<>>>^^>^v<>v<v>^><>v<^v^<>^v^^<><<v^^<v>^^>>^v<>>^<>^v^><v><^^<v^>>^v^<<^<<v^>>^<^>><^><^^><>>>>vv^><^>>^v<v^>vv>>>>><v^v<<>v><<>>vv^^>^>><<v>>^^v<<v^<v>>^<<^>^><v>^<^>v^v<>^<<v<v^>>>^>v<><<v>>>v^>v<<<^<<v><v><vv>>>>v^<<^v>^<<v<>>>>>>v<<vvvvv<>^v<>^<<<^v<>>>^^^^>v^^^^<v<<^<^><>^v^^<v>><^^^<vv>^<<><><><>vvv>^>v^^>^>><<^<v><>vvv^v^^<>v><^^v<v>>v^><>><^v>^<<<^^<vv^<><vv^><^^<vv>><^vv><^>vv>v^<>^>vv^v^<>^<<v^^v>vv<^<v><<^<><>^v>^>^^<>><<^<v^^^^^><vv^><>v^<>v><<<v^><<<^v^>vv><v><v^^^><>>><>v^^>><>>^>v>>>>>v<<^^v><<v^<v^v>^<vv^><>v><v><vv<>v>>>^^v>v^>v^<^^^v<v<v<v^^^v>vvv>>><v^<^><>><<<>><<v^^<><<^v>>^v><><^>><^^^<v<^^><vv^<v<v<v^v>>v>vv>^v>v<>^<v><<^^vv^^^<^v<v<v<<<>^<>v^^>>^<<^^^^<v><^v>v<v<<^v<<vv^^^<<>v<^>>vv<><<<>v<^<<^^>>v^>v>^^
            v^v<^>v^v^>^^<v>>^v<<v^vv>v<><^v><><v<^<v^v<>v^<^v>>>v>^vv<<^<vv^^<>^>v<^^>v^^<v<v>^<><>^>^^^>^^^>v^<<v<v^v^^<<>v>vv>><^^><>vv^^<v<v>v><<v>vvv>^<><^<v^^>^>>^vvv<vvv>v^^<<>v>vv<^<<<<>>vv^<vv^>^v>vv<v^v<v^^^vv^^vvv^<^^>^<vvv<v<^<^>>vv<><<v>^<v<v^v^<>^<vv<><^^v<>^^^<<v>v<>v<>v<<<<<>><<^<>v^>v>^>^>^^<^><><>^<^v<>^>vv<^<^<>v>vv^<v^<><>v>>><v^v<>v^vv<>v>^><<v<v^>^>><^^vvv<<<<>v><>v>vvv>v^vv<>v^v<<><<vvv^^<<>^>>^^>v>^v^>>>^v<>^<^^><v^<>^<>^>>>^<<<>vv>v<^^vv<v^vv<>><v<>>^>^^v>^<v><>^v>^^>^<<^^^^<><^><<v>^^>v^vv^>^v><>>v>^v^^>^<^^>v<^v^v><><<v^>vv^^^>>^><>^vv<>^<^<<vvv^<<>>vv>^^<<^<>v<^<v<>^^><<<^<^<^v^<^<>v^>>>><^v>v>^v^<>^><^^>><><vv>vvvv^>vvvv^v<<><v^vv^^>><<vv^>^^>><>>^v>>>^>>^^>^>^<<>>><v<^<v<vvv^><<>v<<^v>>vvv^v<^vv^v>v>>^>^>^>>vvv^<><><>^v^<<<^>>>v^<^<^<<><<><<^<v><<v<^<<>>><<v^>>>>^v<v><<v>v>^vv^<<vv<v^<>^v><<<><^v^^>v<v^><vvv><v^v><<^^>v<>^^^v^^>^^v<v<v<<^<^>v>>^^<<>v^^^^v<>>^^vv<<>>vv^^<^<<^>v^^v<v<>>v^>>v<^>>><>v^>v<>>>^<<vv^>v<<><><vv>^v^>>v<>v<^>v><>^<>vvv<>^<v^<<^v^^vv>v>vv^v^<v><
            <>^><>v^<<^^<>v><>^^^<^vvv>v<^v<v>^><>v>vv>v<<<<>v>><><vv^>>v<v<>>^<<><>v<>>>>><^^^^>^v><^<v<v<^v^vv<<>><>^<<>>^><^<v^v^><<<>v^><^v^vv>v><v><v^><><><^<<><<^vv<v^>v^v^v>v>v<vvvv>>>^^v^v<>v^^vv>><<<<<<>><^^^v^<vv>>>v^<><>^v<v<<<^v><v>^>^<<^<^<v<^<v^<v<<v><v^^^<vv>>^^^v^>>>>v>v>>>><^<>>^>><v<>>>v>>vv<<>^^><><><vv^v>>><<vvv<v><^<<^<v<^<<>v^^>v<vv<>v<>^v>^^<<><^vv><^><^<><v>>^>^v<vv<><>><<>^v><>v^<>><<><>v^^>^>v<<><v>v^vvv^<>^^>v<<<<><^<<v><><v^^^<v>v^<^^v<<>v<<vv><^<><v><>v>^<vv<^>><><>^<<<>vv^>^<^>^>^v^>^>v>vvv<v<v>^^>^v><^>>^^v^<<^><^^v<^^^v><v<>v^<><^^<v^><v<<v^><>^v^^vvv<>^<vv^^v><v<><<v^v>vv>v<<<<<>v><vv>>^^>v<vv^<^vvv>>vv<v>v<>v<>>>vvv<>^<v^<<v<^v^v^>><<^<>v>^<><<<<^^>v<^><v><v^<>v>>><^v>><<>v<><>v^^><>>v<>v>><^^v<^>>vv^>v^^>vv><>>>vv>v><v^^<^>^^^<v<>^^v<^v^v><^^v<^>^^><>v^^^^<^v^>^v^><v^<^<>^<vv^<>><<^v>v^<<>>^<^<<<><^><>>v^v><v>v>^>^^v>>^>>^^^^vv<>^^>>v>^vv<<<>>v^vv>>v^^^v<>v<^v^^v^^<^^<<<>^<<>^^^v^><>^^>^<v^><><v><^<>^^<v>^^>^>^^^v>vv>^><vv^v><><^<vv^^^><v<vv>>v>><<v<v<v<>v>>^>>^v
            ><<^<^<^>^^<>>^^>>^v^<><>vv^><<v<^>>^^v^<<^>v^v^<><<>^><v<v^^>><>>^>v<<>>>v><v>^^v>^<v>v^^>>>vvv>^v<>v<<>^<<v^>v^<>^v^^>><><>v>>>vv><v>vv^vvv>^^^<>>><^^^v<>v>^<^v>v^^vvvv^v>^^vv^^<<>><v<<v<^>^^<>^<<<v>v>^>^^v^>v^<^<>>v^<^v<vvv<v><>>^^><^vv<<<<>v^v><>^^><^vv><<<<^vv>vvv<>v^<<^>v^^v>v>^<<^>><^v^v<>v>>v>^vv>>v^><^^^^<<<>^^<v^^v<v<v>vvv>>^^<<^>^^<^v<<vv><>^<v<^v<^>v^^<>v^>>^^^v<>><v<v^^v^<v<v^v^>^>>^>^v<><>^vv><<v^^<>vv>vv<<vv^^^v^v^v<v<^><vv^>^>>><<>^><^>^>^^^<<v^>>>><<>>v^v<^<v^^v^^^<v<v^v^^>v>v><v^><>v>><>^^>><<^vv<<>^v<v>^<v^^v>^<^<^>vvvv^^v^>vv<<<<>^>>>><v^^^<<<>^>v^vvv><vv><>>v<^<^v>^<>>>vvvv>^vv^^^v>>^v>>^v<v>^>vv>v>>><vvvv<>>v>v<<>v^<<^<<^>>vv<^^<>v>^^vv^v^^^^vv><>>vv<>v^^>^vvv^^<^<^^v^^<vv<v<v>vv^^^^v^>><>><<v>^v<^^^>>v>v>v^^^^v><^>>v^<<v>>v<^<vv>vv<v^<>>^^^>^<>><vv>^<>>^^^<><^<^v^>>^v>>^v<^v^>><^><vvv^vv><<<vv>^^<>vv>>v<>>^><v^>v<<<<>v<>^>^<>v<v^><^^v<^><v>>^v^^>^<><>^>^><v>>>>>>vv^>^^><^v<^>>^<<>><<<v<v<^<<<^>>vv^>vvv<><>^>>>^v^^v^vv>v>><<^^>vv<<v><><v^><v>>>^^v<<>^<v<<>vvv><><v
            ^<>>vvv^<<^<v<>^<^<^>v>v>^<<<^^<^vvv^<^>v^^^vv>><>^vv>v^^v^vv><^^^><>>v<v>^><>^v<<v>><v>>^>>^v^>vvv><>v^<>>^<<^<>^>>v^<^<>^^^^<><v^v<v<^^>^>>^v>v>vv^<^<^v^>^v^<>vv<>^^<>^<^<^v^<^vv<^vvv^^^v<>^^vvv<v^^>v>^>v<^<^^^<>^<v>>><v^vvvv<>^>^v>v<><>^v<^^v><^<v<v<<^^^^<v<^>^^<vv><<^<<^>^<^vv>v^>^>><vvv><<^>>>^<>>v<v^<vv<<^<><<^^<^><^<>v^>^>^<^><v^<<^<vv><<<<^<v<<>^^v<>>v^v<<v^<<<><>^v>>>^^<v>>v^<v<v^<^^^v<<<><v<^>><^v^^>>><>>^<v^vv^v<v^<<v^<v><^^>vv<<<vv<<><<v>vv<v<>v^<<<v^v^v^>v<^<>>v^vv>v>v<<><>v<<<^vv^vv^>>>><v<>>^v^<>v>^<<>><<<^^<<>^v>^>>>v><<v>>vvv>>>^>>v><^^>^^^>^>^v^^v^>v^^^^<^v>v>^<v^vv>>><^><^vv^v<>^^><^v<<^<vv><<^^<<^<>>v^><v^><<v^^^^<v<^<>>v^^>^><<vv<<<v<>^>^>^v<<^>^<<^v^vvvv<vvv<<^>>v>v<^v>^>^v^>v^^v<<>><>v^^>^vv>v<>vv^><^>v^vv<><v<^v<>vv^<^>>>v<>v<><v>v><>^^><<>^^<^vvvv^v^v>v>v<<^><<>vv^<v<<v>^<^v^<vvv><^<<>v><<^^vv>^<>^>^^>v^^>v^>>>^v^^<^^>^<<^^<vv^^^v^<^<<^><^>v^>>^>^>v>vvvv^<<<>^<<v^>^v<<<v^vv><>v>>^^<><v<>>^>^>>>>v^<v^^v>v>^^vv^^<^v>v^v>v^^^>>>^^>>^^^v>>vv>^vv^^^^>>>v<^<<><v>^^>^
            ><v>^^vvv>><<^<>v>v><><<v^^>v><vvv^^>v<<>v<><v>^^<<^>><<>vv<<>vvv<v<<^>>><^<<v>^<vvv<<^^^vvvv><<v>^><vv<v^><^v>^v^>v><v^v^>>^><^>><v>^v^^>><<>v^>>v<v<v<v>v^^^v<>>v^<<vv>>>^<>^^>v>^<v>^v<<vvvv>>^v^<v<v><>^^>^v<v<<^^<>v^>^^>vv<<>^^><^^><<vv>>v>^^^<v>>v<^<^vvvvv><<^^^<^<<^<<<^<>>><^>>>>><v^<>v<<>v>^<<<^<<^vv><v^v<^><>><v<^>^vvv><v>v<><>>>vvv^<^v<v<^<<<v^>>^<v>>>^<><<^>v<>^v^<v<v<><v^><^^<^v><vvv^vvvv>^v<^>^<<^>>^v^<<^>>>><>vv<<^v^v^v<v<^>v>><v^<^<v<>^><^^<<^^^>v^v<^^v>><<>^vv><><>>v^<>>>^>v^^<v^^^>^v>>^v<^>v<>>v>v<v^^><>>><v>^vv<^v><v>vv>vv><v^<<<>>>^^>v^><^vv>v<^v<<v^v<<^<>^><^<>v^>v<v^>>^^v^v<^>^><>><^^v<<<vvv<<v^^>^v>><^vv<^v>>vv<^vv>><^><<<^^^<^>vvvv<^v>>^v>>v^>^vv<v<v>v><v<>^v<>^vvvv^v><>^v^^><^>v>v^><v^^^<^v><v^v<><<v>^<>^><v>>vv^<<v^v>^>>v<<^vvv<>>>v^v><><<<<v><v<>^^><<v^v<>^^v<vv>><>vv^<>v<vv<><^<^<<v^>v<>>>>^<^>>v>vv^<^<>^^<<>>vv<v<^>^<^>^^>>v^^>><<v^^^v>vv^^^v<>^v^>v^>>v>^^<^<<<^vvv<^vv^^^^v>>><v^v<^v>><<vvv><^^^<^v>><vv>v><vvvv^^<>>^^vvv>v^vv<^<>vvv>^^^>><^>v^<v<>^><>>v^>>^>>^>
            ^v^<^vv<^v^^^><v<^><^<v<><^^<v<>^>v<vv<vv>v^>vv^<^>^>>v^<<>><>^<<^v<v>^>v^vv^v<^v><^<v^^<v<><v>v<>>>^><vv<<^>^>^<^<>^v>v>>v>v>^^v^<<vv<^<v^>^^<^<<>^v^v^^vv<<<<^v>>vvv>^><v<^>>v<^^vv>^^<^<v<<><v^><^>v<<><v^v>^v^>^>^>v<><v>>>^^v<>>v<^<vv<vv>v^<v<>>v<<<^><^>v<vv<>^>><^v>^^v^>v^>v>>>><<><v^><^<><^<^^^<^^>>^^>^<v^><<v^v>v>>^v<>^^^^^v<v^v><>^^v<<v>>^<^v>^^<<^^<^><vv>>^>>>v^>><><v^<vv^^>vv^^>>v<vvv<^<^<><>^>v^v^<vv>^^<v<><vvv<v<^<v^v>^>><><^<^>^^^vv>><<^><><^v>v^v<^^vv>^^<^>>v<^><<^v^<<v^^^^>v<v<>^v^<^<v^>v<v>^>>vv^v^v^^><^<<>v>^^>v^^^<<^^vv^^^><^<v^<vv>v^<><<^^^^>><v<<<vv^<^vv<^^v^^^<>v^<^v>^v<v<^v<^>>^><>>v^<^v^><^v^v>>>v^^>vvv<<><><v><v^>^v>><v>^>>^v><^<^<<vv>^vvv><<>><^v>><vv^<><<v>v^<>v<<<<v^>^>><<<><>^<<^<vvv<>v^<<<<>><><>>^<v<^<>>^v^^v^v<^v>v^v^^<><>^v><<>^<v^<^vvv^v^^^v>v>v<<^^><<v<v<vvv><<^^<^^<v^<v>><^<v>>>v^^<><v>v^v<v^vvvvv>^v^<v^v>^^<v>>^^^><>v^^<^vv>^<^<>^<><>^>v^^><<<^>>v^>^v>v<>v<vv>><vvv<^^><<>v<<^vvv><>v<^v<<^vv^><<<<v><^v>^>v^vv^vvv><>><v>vv<^v^<<<^>><<^><>^><<>^<^>v><>v><^
            <v>v<v^^><>^<v><vv^<^vv^^^<<<v><^>>>v^<>><<v<>^><>^>vv^>vvv>v><v^^><v<v><^^<^v<vv^><>^v>>v^>>^^^v^<vvv^>>v^^^><<^>>>^^>v^v^v^<<^^<<><><^^<^^^<<<vv<^^^<v^>vv^^<^^v>^><<<>vvv^^<v<vv<^^^^>v>v<vv>vvv^<>>^><<>^vv>>>^v>>v>^^>^><<vvvv<>^>^<v^v<v><^v^<v^vv^><^v<>v<><<>^<<^vv^vv<>>^^v^vv><>^<^>><><<^v<<^v>><v<v><>^><^vv<<^<vvv>^<v>^v^^vv<v>><><^>v>^><v><^<^<^>^<<>^<vv>v><v<<>>>vv>><^>>vvv<^<vvvv^<^<<>^v<v^<><<<>^<>>>v^v^v^><<v^^v^vvv<v<<^<<vvvv<^^>v>><^<>v>^>v<^^v<><v>^^^vv<^v^>>^^v<^<^v^^v<v>^v^^^<vv>^<<>^^vv>^^>v><^>><vv>>vvv<v<>v<>^>^<<><<^><>vv<>>>^vv>>>>v>^<v^v>>v>^<^<<<v<^^v>vvvvv^<v^v<^><>^>v>v^<^^^^^<vv>>v><>^v^<^v^v>^v^^<^<<^^<v>^v^^>^v<^v>^vvv<<vv^>^^v<v>vvvv^<>><<v>v^vv^<<<>vv^>^<v^^>^>v^<^<v<^^v^^^vv<><<<v>v<^<><>v<<>^<^>^><^v^^v>vvv^>^<vv^>vvv><><v>v>vv>>v><>><<<><^>vv^^^v<<^^<<v^><<v<>^>^<v><^^^v<>v<><<><<<v<<>>v^^<^<><vv<^^v<><><<><>>^^v^vv^v>^><^<<>v^<^^<><vv<^<><v^^<><<vvvvv<<v>^^^<v<<>v<>v<v<><>>^v<^<^v<<<>^v<<v><<<<<vv<^<v^<v><vv^^v<vvv<^v>^^^>^<^><^>^<^>>vv^<>v^>>^<^><>v>>v>
            >v<<<^>^<<v>^<^^>>^<>>^>^<^<>^>^^^<><^>v<<vv>v>vvv<^><^v>vv>>^>^v^<^v>>^v^v<^>^<><^>^>><<v<vv>^<<>v>v<>v>v<vv<^<^><>>v^>v<<^<>>v><<<<^<v<^>>vvvvv>vvv>vv<<>>>>vv>vvv^<^v^v>v>v<<<<>^<v^^v>>^<><^^v><<>^^v^^v>v><vvvv^v<^>^v^^v>^<v<vv^<^>v><v<<v^^^v^v<v<>^vv^<^^^><v<^<<>^vv^v<v^^<v^>^>v<vv>>v>>v><<^^<v<v<^>v^^v^v^>>v^>^^^^<v<v<vv>v<v>vvv>>^v^vv<^>>v>><v^>v>vv<^>v^v^^><v<<v^v^v<>>v<<<v<^<<^<<v^>><^<vv<>v<>>><vvvvv^<<vv^<^<^><<v<>^^^>^>^<><<v<>^<<<>>v><>><^vv^><<^<>v>^v<>^^^v^<^<<vv<<<>^^>v><^^^><>>v^v>^>^>>^v^v>>^v<^^>^^>>><<^^>^v><<v><^<v<>>^vv<<<>v>vv^vvvv^^>><<v>>v>v<>>>>v<<vv<^^<^v<^^>v>^<vv><v>vv^^v<v<>v><v^>>^>^<^>>>>^^v<v<^>>>>v>^^>>^^>^>v><^>v^<^v<<v<^v<<vvv^^>^^><v>v^>>^>v><v^v<v>>^^^<^<>^>v^v<^^^^<v<<^<>v>>^<v^<<>v^^<<^<v^<>^>^<v^<v^^<>>v^<<^>v^>vv<^v^vv>^^vv>^v><>><<vv^^<>^v><<><v^v^v>^v<>^<^^^>>^^vv^vv>^v^vvv>v<^<<<>^><>v^v<>v<<><^v<<>>>v><>^>^^v^<^v><<^^^^><^>v<>^<v><>^<^<<^^><v<><><<>^vvv><<^^v>>v^^^v^^>v>^^><>^vv><^^<<<^^><<v>v^>^>^>^<>>><<v^^^><^v<<>^<^<^v><v^>>vv<<>v^>>>v<v>
            v^^<>>>v<v^>^v><vv^<^^^<v^>^<vvvv^^^^vvv<v><^vvv<^^v^<<><>>><<^v^<><^^vv<>^<v^v><vv^<>vv<^<^^>v>>>v^v<>^<>^vv^vvv^>^<><v^v<^<<v<<v^^<^<vvv<vvvvv>^v>vv>^<vv>><v>^<<^^^>>><v^v>><<<>^>>v^^^v^^<v^vvv<><vvv>v><^v<vv><<<>><>>^<v><<^>^>>^><>v<v><>v<>>>>>>^<^<^vv<>v>^>^<<^<^^^^^^v><^v^^<v><<>^>v<v<<<^>^v^<<^<^<>^<>><vv<v^^v<<vv^^<v^^>>><<<<v^v>>v^><>^><^v>>><>^>>v^<^^^^>v^<v<><>>^>>v>^v>>^<v>>v>^^^<<<^^<>>>>^>vv>^v^^<<^<^<<><^>v>v^v<><>>^v^>^^^^^v^<vv><v^v^v<^<<>^^v^<v<vv>^>>v><>^><<>><><<vv^^<^<v<^^>>^^v<vvvvv^v>v^v>^v^v>><v>^>><^^><>>v<<<>><^vv^<<<^^^><>^><^>v>v>v^vv^>^^^vv^^><^^><><<^<<vv^^v>v>v>^><<<<^^v^^^v^>>vv<<<>vv>>>^v>v>><>v<v^<>^^>><<><v<<^^<^>vv<<<<>>^><<<>>^>>>>v<^v^>v><><>v^^^<<^^vv<>^vvvv><>v^v><<><v>^vv<vv<<>>^^>>v>><^<<vv^<>v^<^^>>v>>^^>v^^vv^<v>^<^^<><^><v<v>v<>^>>v<<<vvvv<^>v^vv>^v<vv>>v<vv^v><<v<^<><v><v^v><<^>^<v^>^v>vv><>><<>v>>v>>>><vv<v<>^^<v<^<<>^>^^<vv>>^vvv^vvv>^^<<>>^v^^<>>v>v^>^^^v>>v>^>^v<^>^<><<v>^<v<vv^<vv^v^<v>>^v>^><^v>v>>>v<><vv>v^<^>vv^><v^vv<v><v^v><<<vv^<v
            <^>^<<v^<vv^^^^>v<>v<^>^^^v^><^><<v<v^v<vv><^v<>^<v^>v><>v><^<<><<v<^v^<v<><v^v>^<<>^>^<v<^^<^<>^^<v><>^^v^<v>><>^v><v^^vv<><v>^<v^^<><vv^>><>><<>>>vv<<^^^>^>^<><<^><>^<<>><^<^>vv><<<<^>^<<^<<v><^^v<^<<v>^v^<^<v<>v^v<vvvv^v^^v>v>><v<v>>v^>vvv>>>vvv^v^^<>><vv>>^<><>>v<^v^^v^<>^^v>>^^>><^>><v<><<<^v^>v><v>^v><vv<<<<v^v<<>v<<<><>>^>>^^<v<>v>>v>^>^^<<vv<<<^v>><^><^v><^>v^>^<>^^^vv<>vv>^vvvv<<><<v>>^v<vv^^<>v^>^<v><>v<v<^vv>vv^vv<^^<>v<><v<vvvv>><^>>^v>^<<>^>v>vv^>>^<^^v<^>v<<^^><<^^>>>>>^^^v<v^^<><^<>^v><<>^<<vv<<^^vvv<^<^<<vv^v<v<>^<v^v<<<<^^^vv<<><^<^^v<^vv>^<<v^<><>^vv^>^<<<>>vv^<<<v>^>>>^<<v<<<^v^><>^>^<v<>^^v<><v>>^^<<>v<v^v^v<>^>^><v>v>>><^^^<^v<>>^^^<><^vv^<^v><<<vvv<v><<v^>vvv<v>>^^^>><^^<><<^v^<^^<v<^<<^<>>>>^>>v^<<><<^v^v^v<vv<v<<<<v>^^>><^v>><^>>vv>^<v^<^v^^<><vv>v^v^^<<>>^>>^<^^^<^<^v>^<<^<vv<>v<><^v>v^>>vv^^><<<<vv<<v>v^><^<>vv<v><^<><v<><v>^^v<<^<>^><><>^vv^vv^^vv<^vv<>><^<v<^>>>v>>v<>^^>v^^>v^>^<>><v^^>v^^>vv<^<<^v<vv>>^vvv>><v^<^<<><v>>^v<<^v><<^v<>>>>^<<<<<^<<><<v>>v<^>><<
            >^<<>vv<^<<>^v^^v<^^^<^>>^><vvv^^^v^<v><^><>>>><v<<v^vv^^^^^<^^vvv>v^^<^^><^^^vv>v^v<v<^v^v>^^^<><<^<<^v>>^v^^>v^v<v><<v^>>^^<^vv><v^v^<^<v>v><>^>^>vvv<>>^v>^v>><>^^v>^>^^vvv><<><v^<>vv><>^>><<<^<vv<v^v>>v>v<<>vv>><><v>v<>^<v>v^<><>v>vv>^v>v<vv<^>v<<>>^<^^>v^v><vv<<>>v><>>>>^><<<<v>>^^<<<^>v<v<<<><<<vv>^>^vv^<<^v>>v<v^vvv><vvv<^>^vv>>v^v^^v^^<<v>>^^^^^^>v<>^v<v^v>v<^^^>^<<>>vv<>v>v<<v^<>^<>^vvv>v^vv<>>^^>>>>^vv>^^>^v<^^>^>><^^>>^v><<^vv<v^v<v^vv^v<<><<^vv^^vv>^v>^^>>^v<><><<v^v><<>^<^>>vv<^<v<vv<>>^>>^>^v<v<<>^<v><>^<>^^^<>vv^<<>vv><<v^>^^vv^vv<<<^v^>>>v^v>^v^^v^>v<vv^^<v^^^<<<v^>>><^<v<v<^><^v^<>v><^^><^<>v>>vv<<>^>>^vvv^^>^<^v^<v>v<<>v^>>^<>>v>vv>>v>>>^<vv<vv>v^v>v<v>^v^>v^^^vvv<^<>v^<^>vv<>>vv<^^v>v^>^<^^^<<<v<<<<^^^^v^v^vvv>v^^vv<^>v<v^<^>>>>>v^^v><>v^<><>v^v^<^<>>^^<<<v<^v^>>>^^^<<^>><<<<vv>v^^^^>^>v^>^v<^<^<v<<v<vvv^><v>>>vv>^v<>v>><<v>>^^v>^v^<>v<v^v<<^v><vvv<v^v>>^^v^><^<v^^^^<>^v<v>v^v^^v<^^>v^^^v>v<<vv<^><v>vv<><>>^v^>v^vvv>>v^v^v>^<>^v>v><>^v^^<v<^>>><<>^>v>>^v>>^v<vvvv><<>v
            ><v<>^^>^vv>vv>>>><<^v^<v>^<^<v<^>>^>v^v<<>^^^<v>vv>>^><>>v<>^><<><<>v>^><^^<<^^><>v<vvv^>>^^>><^<^<>v^v^>><vv<<>><^<><<^v^>vv<v<<>vvv<^v><v<<<<>>v<<>v>v^<vv<vvv>v>><^vv>v<<><^vv><>><v>>vv^<vv^<<v>vvv<^^>^><<vv<^>>><^v<v<<^>^v<<><<v^>vvv<v>vvv<v<^^>>^v^><^^>v<>><<^><>v>><>^vv<>><<<v<^<vv>^<^<^<>><v^^v<^^^>>v<v><<v^v<v^vv^^v><v<v><><<>^v><vv^v>^^v<vvv<<<<^>><^vv<^v>><<v<<>v><>^<<>>>><<^<vv^v<v>><<>>>v^<vv<v<<<>v^v>^v^vv<v^v^^^<>>>v<^v^<<<<^v^<vv>>^<<<^^>>>^<v>^>>>>^^v<<><>>^<<<<<<><v<v^<^^vv>^^^v^>>v<v^^><<v<>^>^><v>>>^vv^^<>^^v><<v>^>^>^v<vv<<<>>>^^v<^^<<^<><<^>>^>vv>^>>^>v>>^^>>>>^^<>^<><<<<><>>v>v^<v^^^vv>>>>>v^^^<^^vv^v^>><>^^^^v><^<v<v^v<<v<^v<vv<>v^v<>>v<^v^v<v^<vvv><v>v^>v<<^^<<<v^<>^>>^^<<^>vvv<>vvvvv>v^><<<>>^>>^^>v^>^<^><><v<<^^<<v^<v>^<vv>><><<><>^<><^v>^><^><<v<<<<^^<<>>v^<<>v>^vv<v<^^^vvv<v<v<<<vvv><^>v>vv<<>>v>^<<<>v>v<<vv>v>^>vvvv>^><^^>>v^v<v>^<v>>^^v>^><v^^^v^>vv>^vv<<<v><v^<v^^>^v<<v<v^>^vv><^v^><^<>v^v<<<vv<<^v>>^^^<><<<v^<>>^^><>>vvvv^^<><v<<<>v^>^v<<>vvv^v>^<<^<v<>>
            """;
    }
}