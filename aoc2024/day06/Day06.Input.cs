﻿namespace Advent_of_Code_2024.day06;

public static partial class Day06
{
    public static class Input
    {
        public static string GetInput(bool useExampleData)
        {
            return useExampleData ? GetExampleInput() : GetMyPuzzleInput();
        }

        private static string GetExampleInput() =>
            """
            ....#.....
            .........#
            ..........
            ..#.......
            .......#..
            ..........
            .#..^.....
            ........#.
            #.........
            ......#...
            """;

        private static string GetMyPuzzleInput() =>
            """
            .................#.#............................................#................#........................................#.......
            .....#.............................................................#.......#...#........................#...........#.......##....
            ..........................................................#..#........#..........#...............#.#..................#...........
            ..#...#..........#....#.....#......................................#......#..#............................#..#....................
            .........................#....#.............#....................................#............................................#...
            .....................#.......#.............#...#..........#.................#.......#...............#............#......#.........
            ........#.........#.....................................#............#.....................##...#..#..........#...................
            ....#...................#.....##......#............#...#........................#...................................#.............
            ...............................................................................#.......#.....#...#................#.#......##.....
            ..........................................#............................#.#.................................#.........#............
            ........#...............#...............#...................##......#..................#...............#..........................
            .........................#....................................#..........#.........................................##.............
            .......#.................#..................................#......#....................#...............#..........#......#.......
            .............#.#...#.............#.............................................#...............................##.....#...#.......
            .....................................................#............................................#.........................#.....
            .#...#..........................................................##.................................#............#...............#.
            ...........#..#........#.....#.............#.......#............................................#..............#.................#
            ......#.#.##...............#.......#......#......................................................................#...............#
            ...#........#.#.....................##...#...........................#..............................#...................#.........
            ..............#..#....................#...................#.................##..............#.#........................#..........
            ...........................................................#.........#.......................#......................#.........#...
            ................................................#............................................#....................................
            ..#.....................................................#..............#...#.........#.....#........................#.............
            .#..............................#......#..............#........................................................#..................
            #......#.....#..#..#........#....................#...........##..............................#..#.....#.....#.....................
            .................#.....#.....................#.........#..............................#..............##......................#....
            ...........................................................#...##..............#..........................#....#..................
            ........#..#............................#.#........................#.....#................#...#...................................
            ..........................#........#.......................................................................##...................#.
            ............#....#.............................................#.......#....#.....#........................................#......
            ..........#............#....#.......................#.#............#..............................................................
            ......#...#......................................................#..#.............................................................
            .#...#.....#.....#......................................................................................#..........#.....#........
            ...#..#.............................................................................#.............................................
            ............#...................#...........................................#..............#.....#.....................#.##.......
            .................................................#................................................................................
            .........................#.......................................#..................#..............................#..............
            ................................................................................................................................#.
            ...#...........................................#........#.................................................#......#................
            ..#...........................................#.......#.....#.................................#....#.............#...............#
            ........#..............#...................................................................................#......................
            ...........#......#............#............#..................................#.........#..............#.........#..........#....
            .........................#.........#.....#.................................#..................#...............##..#...............
            .....#........#.........................................................#....................................#......#....#........
            ...#..#.......#......#.#..................#..........................^#...........................................................
            ....................#.#..........................................................................#...#............................
            ...........................#..........................................................#...........................................
            ................#..............................................................................#..................................
            ...............................#............................................................#...................................#.
            ..............#..........................................#..............#..................#..........#...........................
            ................#...#..........................#.##..........#.......#..............................#........#..............#.....
            ...................#.............#....................#...........................................................................
            ....#....................................#....#................................................#..#...........#...................
            ....#.#..............#..........#...................#...................................#....................#........#......#....
            ...........................#...........#..#......#.......................................#.......................#......#.........
            .....................................................................................................#.................#..........
            ...................................................#.............#..........#..............................#......................
            ................................#...........##....................................................................#....#..........
            ...........#.......#.......................................................................#............#.....................#...
            .#........#.......#........................................#.#...............................#...#...........................#....
            ..#...............#................#....#............#................................................................#...........
            ........#..........#.........#....................................................................................#...............
            ............................................................................#.............................#...............#......#
            ......................#................................#.............#...#............#...........................................
            ................................#.............#.................................................................#..............#..
            .........#.#..#...............................#....................................................#.#.......#..#........#........
            .............................#.......#.....#......................................................#..#............................
            ..................#.............................................................................#..........#......................
            .....................................#....##.................#......................................#....#........................
            #.......................................................................................................................#.........
            ......#....#..#...........................#..#.....#........................................#..................................#..
            .......#.....#...............#....#......#....#..........#.....................#....#..........#.....#..#......................##.
            ..................#..........#.....#........................................................#............##...................#...
            ........................#....#............#..................................#....#..#.......#...................................#
            .....#............................#...............................#..#...................#.....#..#........#....#.#...............
            ......#...#..#......#..........................#........#....................#.......#...........#..........................#..#..
            .....#.............................................................................................#......#......................#
            ...........................................#......................................................................................
            .....#...........................#.#.#............................#..................#............................#.......#.......
            ........#.......................................................#...................#.......#.....................................
            ...............#..................................................#.................................................#.............
            ..##............................................................#..............................................................#..
            .......#..................................#......................#.................................#...................#..........
            ......#.........#..............#....##........#....#................................#.....................................#......#
            ................#.....................................................................................#.............#.............
            #..#..#......#.#.....#..#.................................................................................................#..#....
            .....................#.....#................................................#.......#........#.................#........#.#...#...
            ..................................................................#....#..#...................#................................#..
            ........................#...........#.......................................................#..#..................................
            .#.......#...................................................#..............#.......#...#.........................................
            .......##...............#.............................#...........................#...............................................
            ....#............#....#...#........................#...........................#.#.....#..........................................
            ...........................#............................#..#..................#...........................#...#...................
            ...........#.#.............#..........#...........................................................................................
            .............#..........#...............#...##.........................#..............#...#.............#..#......................
            ..................#.....#............#..#.........#...............................................................................
            ...........................................................#.....#..................#.......................#..#..................
            ....................................#....#.......##............#.............................#...............#...........#........
            ......#....................#..................#..........................................#...............................#.#......
            ......................#...........................................#.....#.................................................#....#..
            .....................................#...............#....................................#.....#.............#......##...........
            ......................#...............................................................##.#..........#....#..................#.....
            ...........#.............#......................#....................#..................................#......#...........##.....
            .....#.#...#......................................................................................................................
            .........#.....................................#................#.............#....#......................#..........#............
            ......##.#.................#...............#..##.......................#...............#.......................................#..
            ....................#.........#.......#....#..................................#..........................#..............#.........
            ......................#....#..#..#................................#.......#.......................................................
            .........................................##............................##..#..................#..................#...........#....
            ...................#..................................#................................................................#..........
            .#.............#....................................................................................#.............................
            ......................................#.....#.............#..#............................................#...#............#......
            .....................................#..................................#...#.......................##...................#........
            ...........................................................#...................................................#...........#......
            .............................#.......#.......................................#.........................#.....................#...#
            .....................#............................................................................................................
            #....#.......................................#.........#........#...................................#.....#.........#........#....
            .......................................................#......#................................##.#........#.........#..........#.
            .........#........................##.....#.............................................................#.................#..#.....
            ....##....................................................................................................#...#...#...............
            .......#.....#.......#.............#........#...............##.#......#...............#.................#..#.........#...#....#...
            ....................#.................................#........................................................................#..
            #...............#....................................#.........#...............................#..#..........##...#...#......#....
            ............#........................#.....#...#.........#.........#..#......................................#....................
            ..........#.......#.#.....................#...........#...................#.##....................#..#...#........#..............#
            .......................................#.......#........#.....#...........................................#.......#......#........
            ...............................#.........#..............#......................#..........................................#.#.....
            ............#........#.............................................#.....................................................##......#
            ......#.#............................................................................#......#.....#......#................#.......
            .........#.............#................#.................#..###..........#.........................#.#....#......................
            """;
    }
}