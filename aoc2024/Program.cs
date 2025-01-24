using Advent_of_Code_2024.day01;
using Advent_of_Code_2024.day02;
using Advent_of_Code_2024.day03;
using Advent_of_Code_2024.day04;
using Advent_of_Code_2024.day05;
using Advent_of_Code_2024.day06;
using Advent_of_Code_2024.day07;
using Advent_of_Code_2024.day08;
using Advent_of_Code_2024.day09;
using Advent_of_Code_2024.day7again;
using Advent_of_Code_2024.day10;
using Advent_of_Code_2024.day11;
using Advent_of_Code_2024.day12;
using Advent_of_Code_2024.day13;
using Advent_of_Code_2024.day14;
using Advent_of_Code_2024.day15;
using static Advent_of_Code_2024.InputSelector;

Console.WriteLine("== Day 01 ==");
Console.WriteLine("Day 01, part 1, example: " + new Day01().Part1(useExampleData: true));
Console.WriteLine("Day 01, part 1, actual: " + new Day01().Part1(useExampleData: false));
Console.WriteLine("Day 01, part 1, actual: " + new Day01().Part1UsingLotsOfLinqAndChaining());
Console.WriteLine("Day 01, part 2, example: " + new Day01().Part2(useExampleData: true));
Console.WriteLine("Day 01, part 2, actual: " + new Day01().Part2(useExampleData: false));

Console.WriteLine("== Day 02 ==");
Console.WriteLine("Day 02, part 1, example: " + new Day02().Part1(useExampleData: true));
Console.WriteLine("Day 02, part 1, actual: " + new Day02().Part1(useExampleData: false));
Console.WriteLine("Day 02, part 2, example: " + new Day02().Part2(useExampleData: true));
Console.WriteLine("Day 02, part 2, actual: " + new Day02().Part2(useExampleData: false));

Console.WriteLine("== Day 03 ==");
Console.WriteLine("Day 03, part 1, example: " + Day03.Part1(useExampleData: true));
Console.WriteLine("Day 03, part 1, actual: " + Day03.Part1(useExampleData: false));
Console.WriteLine("Day 03, part 2, example: " + Day03.Part2(useExampleData: true));
Console.WriteLine("Day 03, part 2, actual: " + Day03.Part2(useExampleData: false));

Console.WriteLine("== Day 04 ==");
Console.WriteLine("Day 04, part 1, example: " + Day04.Part1(useExampleData: true));
Console.WriteLine("Day 04, part 1, actual: " + Day04.Part1(useExampleData: false));
Console.WriteLine("Day 04, part 2, example: " + Day04.Part2(useExampleData: true));
Console.WriteLine("Day 04, part 2, actual: " + Day04.Part2(useExampleData: false));

Console.WriteLine("== Day 05 ==");
Console.WriteLine("Day 05, part 1, example: " + Day05.Part1(useExampleData: true));
Console.WriteLine("Day 05, part 1, actual: " + Day05.Part1(useExampleData: false));
Console.WriteLine("Day 05, part 2, example: " + Day05.Part2(useExampleData: true));
Console.WriteLine("Day 05, part 2, actual: " + Day05.Part2(useExampleData: false));

Console.WriteLine("== Day 06 ==");
Console.WriteLine("Day 06, part 1, example: " + Day06.Part1(useExampleData: true));
Console.WriteLine("Day 06, part 1, actual: " + Day06.Part1(useExampleData: false));
Console.WriteLine("Day 06, part 2, example: " + Day06.Part2(useExampleData: true));
Console.WriteLine("Day 06, part 2, actual: " + Day06.Part2(useExampleData: false));

Console.WriteLine("== Day 07 ==");
Console.WriteLine("Day 07, part 1, example: " + Day07.Part1(useExampleData: true));
Console.WriteLine("Day 07, part 1, actual: " + Day07.Part1(useExampleData: false));
Console.WriteLine("Day 07, part 2, example: " + Day07.Part2(useExampleData: true));
Console.WriteLine("Day 07, part 2, actual: " + Day07.Part2(useExampleData: false));

Console.WriteLine("== Day 08 ==");
Console.WriteLine("Day 08, part 1, example: " + Day08.Part1(useExampleData: true));
Console.WriteLine("Day 08, part 1, actual: " + Day08.Part1(useExampleData: false));
Console.WriteLine("Day 08, part 2, example: " + Day08.Part2(useExampleData: true));
Console.WriteLine("Day 08, part 2, actual: " + Day08.Part2(useExampleData: false));

Console.WriteLine("== Day 09 ==");
Console.WriteLine("Day 09, part 1, example: " + Day09.Part1(useExampleData: true));
Console.WriteLine("Day 09, part 1, actual: " + Day09.Part1(useExampleData: false));
Console.WriteLine("Day 09, part 2, example: " + Day09.Part2(useExampleData: true));
Console.WriteLine("Day 09, part 2, actual: " + Day09.Part2(useExampleData: false));

Console.WriteLine("== Day 07 again ==");
Console.WriteLine("Day 07 again, part 1, example: " + Day07Again.Part1(useExampleData: true));
Console.WriteLine("Day 07 again, part 1, actual: " + Day07Again.Part1(useExampleData: false));
Console.WriteLine("Day 07 again, part 2, example: " + Day07Again.Part2(useExampleData: true));
Console.WriteLine("Day 07 again, part 2, actual: " + Day07Again.Part2(useExampleData: false));

Console.WriteLine("== Day 10 ==");
Console.WriteLine("Day 10, part 1, example: " + Day10.Part1(useExampleData: true));
Console.WriteLine("Day 10, part 1, actual: " + Day10.Part1(useExampleData: false));
Console.WriteLine("Day 10, part 2, example: " + Day10.Part2(useExampleData: true));
Console.WriteLine("Day 10, part 2, actual: " + Day10.Part2(useExampleData: false));

Console.WriteLine("== Day 11 ==");
Console.WriteLine("Day 11, part 1, example: " + Day11.Part1(useExampleData: true));
Console.WriteLine("Day 11, part 1, actual: " + Day11.Part1(useExampleData: false));
Console.WriteLine("Day 11, part 2, example: " + Day11.Part2(useExampleData: true));
Console.WriteLine("Day 11, part 2, actual: " + Day11.Part2(useExampleData: false));

Console.WriteLine("== Day 12 ==");
Console.WriteLine($"Day 12, part 1, example 1: {Day12.Part1(Example1)} (expected 140)");
Console.WriteLine($"Day 12, part 1, example 2: {Day12.Part1(Example2)} (expected 772)");
Console.WriteLine($"Day 12, part 1, example 3: {Day12.Part1(Example3)} (expected 1930)");
Console.WriteLine("Day 12, part 1, my input: " + Day12.Part1(MyInput));
Console.WriteLine($"Day 12, part 2, example 1: {Day12.Part2(Example1)} (expected 80)");
Console.WriteLine($"Day 12, part 2, example 2: {Day12.Part2(Example2)} (expected 436)");
Console.WriteLine($"Day 12, part 2, example 3: {Day12.Part2(Example3)} (expected 1206)");
Console.WriteLine($"Day 12, part 2, example 4: {Day12.Part2(Example4)} (expected 236)");
Console.WriteLine($"Day 12, part 2, example 5: {Day12.Part2(Example5)} (expected 368)");
Console.WriteLine("Day 12, part 2, actual: " + Day12.Part2(MyInput));


Console.WriteLine("== Day 13 ==");
Console.WriteLine($"Day 13, part 1, example 1: {Day13.Part1(Example1)} (expected 480)");
Console.WriteLine($"Day 13, part 1, example 2: {Day13.Part1(Example2)} (expected 119 + 125 + 349 + 237+ 270 + 87 + 161 = 1348)");
Console.WriteLine($"Day 13, part 1, example 3: {Day13.Part1(Example3)} (expected 141)");
Console.WriteLine($"Day 13, part 1, example 4: {Day13.Part1(Example4)} (expected 299)");
Console.WriteLine("Day 13, part 1, my input: " + Day13.Part1(MyInput));
Console.WriteLine("Day 13, part 2, example 1: " + Day13.Part2(Example1));
Console.WriteLine("Day 13, part 2, my input: " + Day13.Part2(MyInput));
Console.WriteLine("== Day 14 ==");
Console.WriteLine($"Day 14, part 1, example 1: {Day14.Part1(Example1)} (expected 12)");
Console.WriteLine($"Day 14, part 1, my input: " + Day14.Part1(MyInput));
Console.WriteLine($"Day 14, part 2, my input: " + Day14.Part2(MyInput));
Console.WriteLine("== Day 15 ==");
Console.WriteLine($"Day 15, part 1, example 1: {Day15.Part1(Example1)} (expected 2028)");
Console.WriteLine($"Day 15, part 1, example 2: {Day15.Part1(Example2)} (expected 10092)");
Console.WriteLine($"Day 15, part 1, my input: {Day15.Part1(MyInput)}");

