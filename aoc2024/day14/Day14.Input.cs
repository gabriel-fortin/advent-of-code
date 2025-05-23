namespace Advent_of_Code_2024.day14;

public partial class Day14
{
    public static class Input
    {
        public static (int width, int height, string data) GetInput(InputSelector inputSelector)
        {
            return inputSelector switch
            {
                InputSelector.Example1 => GetExample1Input(),
                InputSelector.MyInput => GetMyPuzzleInput(),
                _ => throw new ArgumentOutOfRangeException(nameof(inputSelector), inputSelector, null)
            };
        }

        private static (int width, int height, string data) GetExample1Input() =>
            (11, 7,
                """
                p=0,4 v=3,-3
                p=6,3 v=-1,-3
                p=10,3 v=-1,2
                p=2,0 v=2,-1
                p=0,0 v=1,3
                p=3,0 v=-2,-2
                p=7,6 v=-1,-3
                p=3,0 v=-1,-2
                p=9,3 v=2,3
                p=7,3 v=-1,2
                p=2,4 v=2,-3
                p=9,5 v=-3,-3
                """);

        private static (int width, int height, string data) GetMyPuzzleInput() =>
            (101, 103,
                """
                p=32,46 v=96,-70
                p=7,74 v=-14,-96
                p=34,94 v=17,-18
                p=41,3 v=67,78
                p=6,31 v=37,11
                p=66,47 v=-79,46
                p=22,12 v=-57,-18
                p=91,38 v=-46,46
                p=77,99 v=50,-76
                p=39,71 v=52,-75
                p=80,66 v=-3,-55
                p=58,66 v=-60,62
                p=3,24 v=96,45
                p=87,80 v=-20,-96
                p=57,70 v=-26,-83
                p=67,45 v=82,47
                p=27,82 v=96,-62
                p=96,73 v=88,83
                p=52,3 v=-13,-37
                p=100,18 v=-44,-21
                p=74,70 v=15,78
                p=81,78 v=78,46
                p=32,67 v=64,68
                p=86,25 v=55,92
                p=100,83 v=-70,56
                p=94,9 v=-76,-18
                p=43,71 v=-33,-56
                p=29,27 v=-17,-57
                p=59,27 v=66,52
                p=3,52 v=78,90
                p=21,101 v=10,9
                p=50,10 v=-51,-18
                p=25,86 v=16,47
                p=88,39 v=-88,-16
                p=64,58 v=-36,88
                p=3,73 v=-46,82
                p=77,61 v=-37,-35
                p=89,8 v=55,72
                p=10,81 v=-81,-61
                p=91,61 v=55,48
                p=11,9 v=-22,-39
                p=25,16 v=87,-84
                p=18,22 v=-6,79
                p=11,27 v=35,-38
                p=35,77 v=92,68
                p=63,100 v=91,-26
                p=8,13 v=-39,-4
                p=32,96 v=26,-60
                p=0,1 v=-98,71
                p=26,44 v=68,-16
                p=80,72 v=-96,87
                p=38,74 v=93,21
                p=99,69 v=-76,30
                p=15,96 v=-23,-87
                p=60,18 v=-43,-38
                p=77,97 v=-79,36
                p=98,41 v=37,-71
                p=18,7 v=78,-74
                p=98,48 v=5,80
                p=18,100 v=-66,-81
                p=23,87 v=-49,-94
                p=57,78 v=-44,-83
                p=97,8 v=-92,43
                p=96,70 v=64,72
                p=7,28 v=-65,-52
                p=55,80 v=-10,-89
                p=66,76 v=-27,-61
                p=72,97 v=72,-73
                p=94,97 v=87,-12
                p=45,83 v=-9,-20
                p=6,99 v=-39,-88
                p=74,14 v=73,-45
                p=3,102 v=-39,-60
                p=1,102 v=37,43
                p=7,72 v=-37,29
                p=34,17 v=-85,86
                p=61,66 v=-4,25
                p=1,78 v=-22,56
                p=10,14 v=-15,30
                p=79,57 v=-28,81
                p=7,87 v=-22,-74
                p=88,101 v=46,-57
                p=6,80 v=11,28
                p=47,97 v=44,-21
                p=71,74 v=47,-57
                p=48,77 v=45,82
                p=42,37 v=42,-85
                p=83,28 v=-71,-85
                p=84,60 v=71,81
                p=14,83 v=-85,-79
                p=52,27 v=-8,38
                p=90,45 v=-28,67
                p=79,0 v=15,-47
                p=92,41 v=-54,-78
                p=63,29 v=74,-99
                p=24,97 v=-99,22
                p=41,52 v=34,-63
                p=38,29 v=50,3
                p=50,32 v=-33,-56
                p=11,26 v=95,25
                p=88,49 v=90,-56
                p=72,18 v=-54,-78
                p=16,43 v=-57,12
                p=33,53 v=56,26
                p=13,91 v=-14,42
                p=97,37 v=71,39
                p=43,55 v=78,7
                p=5,20 v=-56,-58
                p=43,48 v=-68,-98
                p=50,80 v=-9,-40
                p=88,49 v=-4,-77
                p=91,62 v=79,-86
                p=18,1 v=-92,68
                p=78,20 v=-37,58
                p=89,3 v=30,98
                p=30,46 v=77,39
                p=43,41 v=-59,39
                p=13,55 v=-48,12
                p=98,47 v=98,-92
                p=92,9 v=-9,97
                p=6,55 v=-15,63
                p=56,1 v=-94,57
                p=54,44 v=75,-98
                p=26,61 v=95,91
                p=82,101 v=-3,49
                p=56,74 v=7,-14
                p=76,91 v=89,23
                p=59,27 v=58,-10
                p=43,49 v=75,82
                p=43,19 v=-37,70
                p=55,51 v=-84,-28
                p=55,54 v=-19,-66
                p=47,60 v=-76,-8
                p=2,52 v=29,74
                p=48,29 v=-68,38
                p=45,44 v=-25,39
                p=16,0 v=-5,-45
                p=35,43 v=34,87
                p=53,9 v=34,3
                p=73,62 v=66,54
                p=31,17 v=26,-45
                p=6,94 v=27,50
                p=30,63 v=-18,84
                p=41,33 v=17,46
                p=38,6 v=-14,94
                p=95,51 v=13,67
                p=14,13 v=61,-44
                p=39,21 v=42,58
                p=90,16 v=97,-10
                p=24,86 v=-19,-95
                p=18,68 v=-74,75
                p=98,41 v=54,39
                p=77,52 v=-53,-62
                p=46,40 v=-52,-1
                p=46,42 v=8,-70
                p=57,0 v=66,-73
                p=76,27 v=91,45
                p=26,102 v=93,33
                p=82,21 v=3,88
                p=87,32 v=48,17
                p=7,10 v=11,-62
                p=1,48 v=-5,-77
                p=48,97 v=76,-40
                p=98,9 v=88,-39
                p=88,21 v=90,25
                p=43,89 v=-21,18
                p=3,79 v=70,-96
                p=96,5 v=35,-84
                p=73,13 v=40,-44
                p=27,88 v=22,50
                p=29,44 v=-17,19
                p=18,4 v=2,37
                p=22,9 v=93,30
                p=62,84 v=-78,35
                p=17,100 v=-15,9
                p=67,5 v=43,-16
                p=100,38 v=75,68
                p=88,16 v=59,-19
                p=100,83 v=-79,4
                p=53,88 v=8,-68
                p=90,71 v=-97,89
                p=11,2 v=70,37
                p=77,6 v=-2,69
                p=58,19 v=-86,-5
                p=79,95 v=-68,90
                p=7,15 v=11,-93
                p=51,49 v=-50,-23
                p=4,32 v=-41,5
                p=80,57 v=-44,-36
                p=97,13 v=11,-53
                p=80,68 v=5,69
                p=40,41 v=-34,45
                p=61,33 v=64,-53
                p=65,16 v=-34,-95
                p=51,43 v=-93,46
                p=22,38 v=-90,27
                p=91,54 v=65,28
                p=86,39 v=-47,-84
                p=66,35 v=59,-16
                p=41,85 v=34,63
                p=46,15 v=-51,72
                p=87,0 v=-79,-55
                p=32,22 v=-93,-10
                p=71,6 v=56,-80
                p=12,40 v=-64,21
                p=39,16 v=-8,65
                p=66,69 v=99,82
                p=87,29 v=-62,-91
                p=27,41 v=-91,-91
                p=99,100 v=38,29
                p=57,10 v=16,92
                p=55,88 v=-17,-39
                p=37,18 v=-50,-17
                p=72,73 v=-11,35
                p=95,64 v=-63,83
                p=34,56 v=25,-81
                p=48,35 v=18,57
                p=10,99 v=-10,-52
                p=17,75 v=78,48
                p=68,90 v=58,15
                p=45,100 v=-12,1
                p=94,9 v=-4,85
                p=1,52 v=13,-62
                p=63,82 v=79,94
                p=98,56 v=-5,-15
                p=39,67 v=16,18
                p=85,0 v=81,71
                p=45,22 v=84,24
                p=100,58 v=-65,-48
                p=6,67 v=-74,6
                p=77,10 v=-77,37
                p=80,74 v=-37,-48
                p=47,86 v=-69,-46
                p=21,61 v=-15,34
                p=22,73 v=-57,69
                p=54,52 v=58,40
                p=90,52 v=-57,-12
                p=96,98 v=18,-61
                p=25,16 v=-49,-10
                p=78,23 v=-3,72
                p=42,65 v=-42,-89
                p=88,92 v=-88,-13
                p=39,95 v=-94,-40
                p=30,1 v=12,32
                p=88,82 v=-64,42
                p=80,19 v=-14,62
                p=49,56 v=-21,87
                p=71,17 v=32,67
                p=75,88 v=-45,-68
                p=14,48 v=53,-57
                p=29,78 v=77,-83
                p=79,0 v=22,-37
                p=42,96 v=20,-47
                p=76,55 v=38,-2
                p=99,40 v=96,18
                p=39,60 v=2,77
                p=20,30 v=35,-51
                p=50,27 v=58,18
                p=15,82 v=19,49
                p=67,5 v=10,-56
                p=75,59 v=32,-89
                p=66,69 v=39,46
                p=24,75 v=25,-67
                p=26,22 v=-75,-64
                p=21,90 v=36,90
                p=47,61 v=17,47
                p=54,95 v=-98,69
                p=57,81 v=75,83
                p=66,59 v=15,82
                p=66,90 v=27,62
                p=79,85 v=-86,-89
                p=33,93 v=-34,30
                p=99,97 v=80,-59
                p=75,42 v=97,-70
                p=27,60 v=35,6
                p=70,23 v=48,-44
                p=64,40 v=92,66
                p=60,56 v=73,60
                p=26,23 v=43,-3
                p=30,3 v=60,24
                p=70,87 v=-62,-75
                p=30,28 v=1,31
                p=15,94 v=-23,-5
                p=8,83 v=-17,55
                p=88,50 v=55,-2
                p=68,10 v=-11,71
                p=49,93 v=68,56
                p=98,64 v=53,-41
                p=12,10 v=-24,-53
                p=58,11 v=41,85
                p=49,43 v=-86,95
                p=47,75 v=-48,-38
                p=37,14 v=-63,-70
                p=64,60 v=-52,-56
                p=98,91 v=87,-80
                p=78,88 v=-2,-48
                p=80,27 v=72,45
                p=53,12 v=-67,31
                p=20,3 v=-8,-9
                p=67,12 v=16,-93
                p=49,85 v=-22,18
                p=2,98 v=-18,-52
                p=47,101 v=-13,17
                p=46,72 v=-59,-41
                p=21,22 v=-33,-73
                p=21,37 v=-13,-56
                p=55,48 v=-60,-85
                p=74,8 v=-45,-11
                p=0,25 v=12,72
                p=75,19 v=34,48
                p=55,1 v=-18,91
                p=69,79 v=-94,-19
                p=24,84 v=52,-96
                p=68,9 v=82,-4
                p=89,56 v=-12,6
                p=99,49 v=89,-30
                p=88,9 v=47,-25
                p=62,24 v=-16,35
                p=22,73 v=93,89
                p=1,86 v=-13,28
                p=99,97 v=-89,-33
                p=95,68 v=-13,55
                p=33,24 v=93,45
                p=70,55 v=48,-8
                p=42,9 v=-24,16
                p=9,90 v=52,-40
                p=7,71 v=26,56
                p=52,12 v=24,23
                p=0,66 v=-35,93
                p=49,72 v=-42,-7
                p=65,32 v=52,-92
                p=74,28 v=7,-58
                p=64,12 v=-59,90
                p=100,28 v=88,45
                p=83,57 v=-50,18
                p=81,25 v=-79,66
                p=29,93 v=-65,43
                p=83,63 v=-79,34
                p=88,18 v=5,-31
                p=62,11 v=-36,37
                p=33,63 v=51,75
                p=28,51 v=27,80
                p=35,59 v=69,-51
                p=22,76 v=-82,-41
                p=35,46 v=85,46
                p=6,22 v=62,-73
                p=5,95 v=-81,-48
                p=52,61 v=26,69
                p=16,4 v=-66,79
                p=13,47 v=-73,94
                p=10,96 v=-65,-95
                p=72,86 v=-36,-26
                p=68,45 v=-60,-7
                p=65,14 v=-46,-29
                p=1,22 v=19,-31
                p=80,80 v=57,84
                p=20,69 v=-31,-35
                p=97,24 v=80,37
                p=38,41 v=-59,-64
                p=8,27 v=-60,-94
                p=46,81 v=90,60
                p=5,85 v=86,-55
                p=54,31 v=94,95
                p=29,82 v=-67,-69
                p=8,21 v=-89,87
                p=8,59 v=-56,-97
                p=33,20 v=79,-1
                p=62,80 v=72,-47
                p=7,7 v=69,-52
                p=0,80 v=71,-34
                p=88,0 v=99,-77
                p=53,19 v=16,-45
                p=90,85 v=29,-75
                p=5,31 v=3,-85
                p=38,20 v=7,-32
                p=85,2 v=-12,-87
                p=87,64 v=-49,-49
                p=34,33 v=84,43
                p=42,80 v=77,56
                p=68,44 v=60,90
                p=67,94 v=-80,77
                p=75,44 v=14,73
                p=25,74 v=69,-75
                p=54,67 v=-9,96
                p=34,100 v=1,9
                p=83,73 v=98,-86
                p=58,56 v=-31,-40
                p=16,21 v=-82,93
                p=75,58 v=73,-22
                p=61,9 v=32,-67
                p=15,7 v=27,9
                p=14,77 v=-48,49
                p=48,20 v=84,-24
                p=93,55 v=-12,11
                p=95,78 v=-54,-83
                p=72,33 v=6,-23
                p=50,88 v=97,-73
                p=97,67 v=79,-23
                p=27,76 v=94,-18
                p=99,67 v=-54,-56
                p=79,3 v=39,24
                p=32,22 v=9,59
                p=89,1 v=-63,36
                p=52,82 v=-51,-36
                p=39,70 v=93,1
                p=6,91 v=56,6
                p=6,53 v=-85,-37
                p=24,80 v=-66,56
                p=30,91 v=-21,-11
                p=99,18 v=-4,99
                p=58,53 v=-18,33
                p=36,51 v=-8,-29
                p=0,87 v=46,-6
                p=44,7 v=7,86
                p=13,34 v=-65,-9
                p=28,6 v=60,-59
                p=97,62 v=85,-76
                p=47,11 v=-43,44
                p=11,56 v=53,-29
                p=25,91 v=95,23
                p=91,49 v=52,-57
                p=84,22 v=-20,-38
                p=31,8 v=-50,-10
                p=1,70 v=-30,1
                p=65,78 v=23,7
                p=57,6 v=-10,-80
                p=86,93 v=48,-55
                p=1,98 v=55,90
                p=39,59 v=52,48
                p=13,21 v=80,-96
                p=30,28 v=-36,37
                p=94,92 v=29,-19
                p=44,25 v=92,-65
                p=61,56 v=-49,-70
                p=54,3 v=16,37
                p=53,58 v=-43,96
                p=98,36 v=97,-24
                p=57,25 v=43,30
                p=15,73 v=16,4
                p=72,80 v=48,-41
                p=79,50 v=97,25
                p=79,74 v=-66,86
                p=69,78 v=47,48
                p=73,13 v=-61,92
                p=5,85 v=36,-27
                p=29,98 v=43,-13
                p=1,96 v=46,83
                p=26,53 v=69,95
                p=87,91 v=38,-26
                p=8,90 v=-91,8
                p=30,4 v=3,19
                p=53,75 v=-19,-13
                p=91,80 v=51,74
                p=7,84 v=17,87
                p=61,52 v=35,32
                p=45,22 v=49,-86
                p=23,86 v=87,-67
                p=20,11 v=-57,-18
                p=29,37 v=26,60
                p=56,38 v=-94,-16
                p=6,20 v=2,83
                p=32,63 v=-24,6
                p=29,67 v=43,-83
                p=30,33 v=68,15
                p=20,36 v=-76,-4
                p=40,51 v=-34,-84
                p=98,94 v=-88,-27
                p=66,34 v=-36,81
                p=64,1 v=-61,50
                p=39,92 v=-59,-34
                p=16,24 v=43,4
                p=3,44 v=56,-28
                p=18,10 v=-22,-3
                p=87,47 v=-53,67
                p=28,66 v=9,-42
                p=61,71 v=-94,-55
                p=45,39 v=55,19
                p=15,50 v=16,-45
                p=42,89 v=15,-69
                p=4,42 v=20,-77
                p=4,12 v=25,84
                p=58,42 v=-52,6
                p=43,71 v=93,-19
                p=11,83 v=-81,83
                p=19,96 v=37,62
                p=10,5 v=-56,-25
                p=98,75 v=79,89
                p=55,6 v=40,-26
                p=27,26 v=85,-24
                p=76,55 v=73,60
                p=13,12 v=-6,-32
                p=15,76 v=-15,13
                p=53,10 v=-67,-52
                p=18,53 v=69,-49
                p=65,39 v=-52,73
                p=39,80 v=-67,-41
                p=43,5 v=-12,-58
                p=24,42 v=-7,-85
                p=12,48 v=-57,46
                p=55,98 v=-18,36
                """);
    }
}