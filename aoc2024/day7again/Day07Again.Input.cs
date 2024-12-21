﻿namespace Advent_of_Code_2024.day7again;

public static partial class Day07Again
{
    public static class Input
    {
        public static string GetInput(bool useExampleData)
        {
            return useExampleData ? GetExampleInput() : GetMyPuzzleInput();
        }

        private static string GetExampleInput() =>
            """
            190: 10 19
            3267: 81 40 27
            83: 17 5
            156: 15 6
            7290: 6 8 6 15
            161011: 16 10 13
            192: 17 8 14
            21037: 9 7 18 13
            292: 11 6 16 20
            """;

        private static string GetMyPuzzleInput() =>
            """
            4068635: 3 3 43 703 22 632
            5560244397: 722 77 4 7 37 4 1 3 97
            109005084: 519 6 43 1 35
            173488656: 61 57 7 81 3 11 8
            13887984962: 6 61 4 1 677 7 98 49 6 2
            5448: 44 2 31 789 6
            47355640: 20 1 76 62 50 30 1 5 4
            29455065878420: 91 952 54 67 34 419
            641790996325: 161 18 35 473 84 3 2 5
            425625017: 8 6 454 3 611 1 55 43 6
            639710141: 9 1 7 2 710 138
            708953: 20 29 128 901 51
            1544031762: 654 33 5 917 78
            1438664959: 911 84 47 34 4 5 8
            353595: 3 357 981 426 9
            687057312: 6 870 566 10 702
            1051: 36 70 9 7 8 75
            6757654: 383 980 9 767 2
            128227: 30 4 105 9 5 420 2 1 7 1
            31037: 59 48 290 2 5
            82304: 32 1 78 76 32
            135447236: 64 224 8 469 36
            61632: 8 61 109 5 3 7 592 5 9
            10233: 9 2 96 92 389
            3583669: 8 6 8 1 3 5 6 6 353 2 8 5
            17778594: 6 20 50 8 6 436 324 8 3
            483295815: 1 93 5 999 5 1 3 489 5 9
            629898734: 66 30 449 64 95
            2024014: 69 1 61 48 766
            213411: 7 7 92 6 7 622 9 2 8 2 2 1
            27284400: 1 222 943 15 195 8
            10329265596: 39 8 27 396 6 3 178 78
            335727701100: 78 96 74 6 23 748 5 9 3
            28074123: 4 456 21 9 7 1
            545375: 96 9 53 98 5
            48760: 8 1 27 8 2 1
            23836829900: 993 24 2 46 29 897
            872: 393 2 83
            90535068: 57 15 59 74 4 8 9 6 1 6 6
            57081492: 8 9 7 7 6 80 46 78 1 69
            1596210: 8 62 75 65 4 5 637 55 6
            16776: 684 3 45 2 4
            221492102566: 3 389 32 6 50 459 4 41
            7271: 6 283 46 32 624 285
            1259640: 2 7 3 5 34 7 3 7 2 6 2 6
            681972047: 93 199 9 36 7 813 1 3
            437926526960: 481 856 62 235 73
            2596513920: 30 552 6 44 965 1 104
            5281086: 68 5 8 9 3 46 8 51 9 7 6 6
            1931750: 2 535 762 63 18
            71393: 5 53 27 838 163
            1025311: 8 72 178 2 8
            3753: 3 63 33 21 9
            4012038: 79 1 890 50 2 2 6 653 6
            1315440: 37 50 6 60 42
            2166: 21 129 3 6 659
            1735440562: 7 4 924 60 563
            3531024007: 8 496 225 791 5 7
            68504: 6 4 73 4 9 647 4 886 9 8
            198445: 5 92 5 389 5 1 37 1 6 3 7
            33355: 304 1 292 2 4
            3404858473: 31 9 54 505 211
            35785148: 5 9 24 7 929 856 68
            4316750484: 2 3 703 14 4 46 22 62
            8102541: 930 8 5 29 7 8 3
            314200490: 5 231 8 34 7 7 6 6 8 8 3 2
            361979: 26 6 3 2 6 6 7 1 3 9 7 199
            510955764: 70 112 3 732 89
            27682: 956 7 473 19 398
            305532: 677 75 6 7 873 2
            61469371: 6 31 405 17 6 3 1 8 67
            110285804: 5 58 38 8 1 4 710 94
            3490217: 90 6 8 71 2 32 425
            27348146: 707 967 40 717 669
            823: 670 2 78 67 6
            3352030: 2 5 973 5 682
            7908670871: 811 447 6 606 6
            153013: 88 15 210 10 1
            357479: 1 294 62 3 97 84
            2649: 876 2 3 3 6
            205425: 8 7 7 3 8 8 91 5 3 1 75 3
            884981: 46 6 30 7 81 461
            254610048: 575 300 82 3 8 1 6
            4218796: 7 1 637 2 932 1 5 2 428
            48680090401: 517 78 9 1 33 94 7 7 6 4
            342: 9 98 5 3 6
            104041: 52 4 500 9 32
            4122: 80 8 941 4 6
            36964822: 80 302 45 34 5 17
            554756995: 67 6 4 1 28 73 1 3 929 5
            1939399: 19 353 40 99
            11100345303: 6 18 9 79 25 3 3 38 66 1
            963229413: 469 86 8 205 1 4 9
            25275976: 8 12 70 8 47 877 10 6
            3606365: 4 491 367 385 8 92 5 1
            2697: 6 397 36 47 167 6 59
            37226107: 1 92 2 8 6 526 4
            16185: 48 330 74 75 196
            543096: 4 4 1 910 586 18 4 438
            1840: 720 2 400
            203134: 20 31 37
            5412586614: 8 2 1 6 6 6 8 711 6 5 9 7
            1023946: 138 60 64 558 82 7
            1470564294: 194 96 840 66 75 94
            186522: 5 486 34
            32410: 2 5 5 2 895 1 6 8 35
            583: 2 14 2 6 20
            12804: 5 9 3 6 4 750 992 3 5 9
            9338: 9 75 7 8 854 4
            17372785: 80 841 56 86 3 97
            112087: 9 20 4 1 957 118
            98008309: 54 2 58 2 689 581
            3964820: 75 9 472 2 1
            524834323: 32 42 4 7 7 661 3 21 4
            68857737007: 7 1 3 9 7 27 8 2 5 820 7 2
            634456000: 74 44 1 3 8 71 400
            40890: 8 9 39 2 6 1 4 2 3 3 99 5
            2067984: 327 4 93 17 36
            31310: 15 2 2 2 310 6 9 5 431 4
            38787869: 8 472 444 182 29
            1512: 2 395 9 9 3 267
            799089: 739 9 7 3 5 7 8 52 4 4 13
            1060: 73 14 1 38 1
            22058791: 9 6 8 3 8 5 544 3 41 6 2 4
            34029072787: 104 8 5 3 378 8 785
            3957739: 39 577 28 5 7
            282584532: 4 42 806 997 291 833
            2289841544174: 84 29 47 1 8 61 767 5 5
            502463128: 36 9 42 968 78 4 39 7 4
            1203352: 3 69 3 12 488 3 6 4 3 3
            1521193: 980 774 469 684 661
            2908341755: 871 1 359 2 93
            37: 15 9 13
            413019456: 55 98 897 41 25 32 94
            179422: 202 2 90 61 8 3
            406719936: 20 2 6 719 912 7 19
            872508: 9 753 8 3 3 8 3 4 8 21 52
            193157895: 41 673 985 7
            35159: 3 118 36 41 96 65 904
            384531509: 2 7 7 5 54 7 6 8 349 6 5 6
            431354: 8 7 1 1 640 6 96 76 6 4 7
            6568: 6 2 6 337 993 857
            10749004: 6 19 943 17 6 229 92 7
            4393620: 813 6 6 99 5 951
            29431707458: 8 1 3 231 8 3 29 8 3 508
            4206: 7 6 9 4 3 7 1 70 4 8 6
            62016000: 7 59 6 106 60 400
            182754: 98 5 97 9 4 858
            43790985: 2 8 604 4 31 645 7
            14546449904: 5 3 2 957 49 903
            8641608: 878 188 5 57 163 47
            82583: 2 2 481 5 1 2 12 7 7 8 38
            185333240: 38 8 3 5 8 3 459 8 9 7 8
            213884544: 9 7 6 69 8 397
            61793822789: 7 2 2 6 6 6 927 22 2 3 86
            156668: 5 521 6 36 7
            9565278: 99 9 1 1 8 8 955
            6012109859: 22 38 9 543 799
            304941602: 6 1 1 5 2 187 1 2 820 5
            176614: 35 63 5 16 185 29
            14176888497: 981 935 6 8 6 644 3 3
            1032490018: 7 443 869 229 8
            31249: 2 92 3 1 7 8 567 3 6 6 1
            198259040: 227 72 5 1 8 9 8 4 916 2
            514904592: 663 799 9 2 6 1 3 6 1 6 6
            634712: 63 4 7 1 1
            99: 6 5 9
            6664: 94 4 29 9 49
            7347448213: 2 254 41 35 459 7
            4248192: 1 4 570 2 672 92 37
            5306863: 70 5 8 7 176 2 628 58
            3376221: 84 3 763 293 1 4
            102837504: 77 71 564 2 616
            8432175948082: 6 971 9 4 8 35 21 10 8
            6872637: 686 8 4 6 11 1 29
            1292549: 1 6 6 2 489 8 9 16 1 2 1 5
            2224138176: 2 5 611 934 39 16 684
            18234: 26 7 65 894 6
            72364106: 3 9 4 77 5 3 5 17 3 2 8 8
            2161: 6 3 35 3 81 5 1 3 4
            3890: 5 4 3 4 36
            507394: 4 95 6 87 4 214
            34679100: 3 4 67 910 2
            6253533: 3 765 1 2 8 5 60 6 339
            442512952177: 7 262 6 3 6 4 88 402
            2295555: 37 66 94 2 76
            13291810: 7 7 3 2 8 998 9 1 1 3 317
            317513: 2 792 2 20 6 4 7 4 54 7 7
            28567: 68 1 60 7 7
            5785808977: 5 9 84 752 60 29 7 3 6 9
            1224096558: 7 6 190 5 5 2 3 21 79 7 3
            67297152: 49 97 5 34 416
            112003856321: 93 1 95 52 93 6 67 6 4
            3698: 6 8 4 182 324 98
            327888000: 7 1 2 2 3 8 29 8 720 5 46
            37548: 3 51 77 14 9
            47761897: 2 234 57 904 897
            174437037: 6 5 36 2 6 352 1 621
            87300: 4 2 242 3 60
            45986: 45 8 88 9 89
            1545201: 43 6 9 4 1 2 332 1 72
            22253316: 211 11 516 16 36 80
            103290753: 1 7 3 2 144 9 9 550 7 5 1
            139374153: 783 2 89 1 53
            891: 6 2 822 6 55
            237107758764: 8 378 366 283 4 7 49 4
            19733051520: 619 4 5 144 936 47
            79305585726: 785 6 74 5 585 7 29
            198293: 2 5 79 251 3
            6607695: 189 9 3 927 1 2 6 6 3
            32937: 1 35 52 5 9 2 4 83
            1760688: 1 29 64 66 8 9
            2061025: 68 32 824 1 41 25
            84231568873: 329 32 7 4 20 6 8 872
            1777: 87 722 968
            4490: 92 40 5 802
            2016950020: 759 9 12 53 7 50 17
            1673031: 845 98 2 887 149
            393487282429: 4 5 3 8 419 6 31 6 8 4 32
            5011357802: 1 707 7 900 7 7 8 7 91 8
            838628861: 6 9 8 85 7 1 3 9 8 9 4 31
            344039: 84 7 2 8 4 4 817 9 8 8 5 9
            3428964: 34 8 7 27 318 403 99 4
            3680225795: 61 7 90 3 323 86 17
            1385795320: 2 388 213 8 52 9 9 5 4 7
            8046065: 1 49 540 66 2
            4045025: 40 4 495 6 71
            1177805: 60 43 1 5 58 2 683 61 5
            2475: 58 7 98 15 30
            369462: 1 6 79 668 58
            17121: 19 9 20
            944: 4 5 46
            13849860: 471 1 175 42 615 4
            11634264: 2 9 262 611 68 824
            1322490: 934 9 712 1 47 8 17 9
            106361374: 9 36 78 7 3 7 601
            1841487: 93 9 22 85
            12593522892: 50 6 34 26 4 2 5 915
            90252509: 47 400 8 9 2 2 232 5 5 3
            1500: 94 2 982 216 114
            11392365: 7 9 7 1 92 3 41 3 5 2 6 8
            1676056: 7 6 75 8 3 3 6 91 6 62 4 6
            237104305: 9 5 9 1 10 584 3 6 9 5 7 4
            1817: 81 6 409 1 891 30
            3020489: 67 166 68 3 7 488
            59739110747: 739 345 23 20 808 1
            5876: 7 5 1 27 39 1 5 15 26
            155952259: 207 9 722 25 9
            6047040509: 925 5 398 6 9 626 758
            80332824: 3 11 356 13 526
            576879605: 214 6 8 449 41 7 3 230
            1767268002: 184 8 7 22 6 6 4 9 2 3 2 6
            1075073051: 3 1 5 9 2 32 296 8 9 9 7 2
            173255760: 801 500 555 54 8
            2314: 3 5 7 41 3 16
            374601806: 9 9 666 868 8 782
            330954: 543 8 7 98 473 2 6
            790539271956: 7 905 38 7 1 56 1 9 56
            46332386103: 4 5 231 260 217 395
            94556532: 2 93 48 96 6 8 3 4 3 12
            47236386: 9 1 2 1 599 5 264 9 6 6
            4545435: 4 35 4 99 8 4 3 435 2 1
            18768: 4 31 8 420 626 82
            1230037411197: 3 627 1 815 700 416 1
            567272: 9 122 6 45 1 92
            836196: 335 82 5 3 2 2 55 4 939
            1090768: 940 2 6 58 6 8 7
            178: 4 6 65 2
            1310471: 1 689 72 1 19
            911191680: 6 9 9 7 93 15 192
            94437511856: 5 7 4 6 1 4 622 669 4 9 4
            343728: 981 5 481 70 63
            344744397: 3 1 2 388 524 8 6 3 9 93
            44340702: 7 3 5 89 2 624 1 3 2 4 4 2
            41305922: 5 451 8 8 6 1 9 41 2 809
            463: 49 346 25 7 6 30
            15926: 4 9 17 13 7 2
            520842: 79 8 824 2 75
            28984: 358 77 840 554 24
            122766: 44 75 9 5 3 8 2 478 3 7
            2903433550: 9 82 6 4 7 39 502 7 41
            17477600: 773 6 471 202 8
            337518: 4 6 73 69 263 41 9 34
            31988443: 4 9 130 174 13 19 79
            387096: 27 7 9 36 9 5 488 8 4 8 8
            88028: 6 6 5 75 7
            731250807: 93 94 5 5 78 6 4 8 9 76
            10415101: 45 61 275 660 5 100
            1441456: 1 8 2 1 34 1 6 4 4 80 22 8
            30719301: 2 902 63 3 24 6 7 1 4 1 1
            122976: 8 240 1 493 5 21 33 18
            13939: 368 6 3 6 8 663 2
            2687445: 50 2 853 466 49 8 57 5
            143055: 3 19 2 8 707 6 7 896 85
            788687: 7 885 94 5 89
            147163698: 1 1 14 2 791 2 3 585 62
            2780: 82 375 5 3 9 483
            308752565: 74 3 11 102 145 837 5
            1433218: 79 386 47
            77189: 4 2 7 4 5 257 3 47 29 3 7
            5355: 8 9 21 5 3
            17389951: 86 34 651 3 5 829 929
            32307161: 3 175 55 71 63
            56663087: 5 5 9 4 6 992 2 35 47 1
            38233893178: 91 20 6 57 21 96 179
            2553479460: 1 9 701 34 3 8 496 36
            93496: 9 21 862 7 2 52
            5278: 59 6 45 7 13
            7538688: 4 2 4 9 98 4 2 1 8 6 409
            30812605: 32 60 4 5 23 5 728 5
            208352250: 7 230 6 1 2 22 37 8 1 90
            620446: 99 6 26 446
            37852120084: 87 50 8 184 87 5
            200524728705: 8 354 8 9 576 3 70 6
            769510: 57 75 3 6 9
            338386733: 530 1 118 3 3 3 2 5 7 6 9
            74026: 1 53 33 1 2 3 409 807 8
            31117: 62 498 68 88 85
            170830944: 5 108 2 3 6 1 8 9 12 9 2 9
            19399: 8 8 32 93 5 89
            34520152: 70 733 3 61 5 9 8 873
            20213958205: 19 588 37 95 3 48 8 9
            237639240: 140 41 690 48 4 2 4 5 3
            406756: 399 5 72 58
            51056: 6 37 486 72 80
            2299760: 8 445 646
            124149: 2 3 8 27 87
            9280546: 48 2 228 424 34
            3640090: 98 11 5 50 64 3 4 221
            1550: 1 6 35 3 6 40 1 6 5 1 9
            441951: 44 505 805 5 1
            432914: 111 6 247 16 466
            804577539: 4 723 368 9 84
            373362: 62 6 1 8 4 62
            15848096: 5 420 731 4 7 12
            1019: 3 8 37 3 1 77 746 13
            956858: 83 12 1 5 86 1 1
            74019: 7 28 5 7 1 9
            4567: 190 88 634 5 2 5
            1299049746940: 7 9 527 346 4 47 786
            42887048419: 592 69 134 54 19
            73686590: 8 8 7 85 1 439
            78408746: 9 80 8 8 746
            432202709: 49 2 86 7 6 3 974 80 5 9
            212583063: 722 64 5 71 46
            5058944: 4 454 476 8 83 4 32
            668362: 4 7 434 1 4 35 2
            9923350: 8 28 7 452 7 508 3 9 3 2
            1502: 1 6 82 74 550 7 91
            3936716143: 39 36 71 6 143
            684330375: 5 3 91 792 2 6 8 1 1 3 7 5
            48007326: 8 598 932 85 6
            8536: 9 88 11 8
            13100624715: 795 2 713 123 47 984
            1843: 62 4 3 2 12 21 100
            49972: 792 7 1 9 74
            64676182625: 95 5 6 9 1 56 2 752
            2440171657: 4 3 630 8 6 8 82 184 9 1
            52321991: 58 7 8 1 1 9 2 29 9 93
            5661: 40 54 10 462 1
            3505994436482: 83 2 66 23 261 4 40 8
            3219255871811: 85 2 37 25 587 1 8 14
            67167: 3 6 8 4 1 221 37 570 5 9
            1611807567: 7 10 39 3 5 97 764 4 6 1
            14013920: 5 35 100 74 80
            39244535497: 707 1 555 48 54 95
            364039451: 5 87 160 4 62
            10311: 170 2 2 6 88
            24569: 6 9 2 289 80 8 6 8 66 1 1
            13111862: 80 86 56 330 24 9 34
            304167: 7 422 86 1 67
            2520514: 2 1 5 12 2 51 6
            97944: 6 24 485 5 19
            5099529984: 81 830 3 98 258 3 21
            64776618: 9 2 1 6 2 742 3 742 5 3 6
            51189854: 3 853 2 98 55
            588298: 7 15 6 331 7 16 330 1
            38968341: 38 9 62 6 344
            687942: 69 833 34 210 5 6 1 6
            9670052207735: 327 5 759 3 943 8 369
            20175168: 4 59 6 52 274
            13491: 6 1 71 6 5 612 99
            60786119: 90 6 629 33 12 71 6 42
            8298388: 7 6 16 88 8 98 18 6 641
            58190683104: 898 90 3 917 15 72
            9222408900: 7 4 59 98 9 207 580 9
            5918: 9 5 22 283 5
            163107: 64 363 2 67 7 1
            7305: 975 1 36 32 7 4
            340704: 92 6 28 1 986 3 975 7 4
            13920397: 5 213 7 3 5 202 32 399
            4597763: 581 1 8 79 58 5 8 9 1 35
            45457: 4 3 7 172 835 3 14 5 1 7
            38609408960: 4 9 2 92 3 251 3 968 56
            452: 9 5 2 396 9
            1874443742: 39 89 191 9 54 69 45
            1382511964: 1 5 69 4 9 612 3 1 2 9 6 4
            120073367232: 1 8 717 6 6 92 548 7 78
            267512: 4 77 7 56
            237665610: 7 569 170 39 9
            13049395281: 751 543 60 320 83
            5092644121484: 42 438 694 7 12 14 8 7
            27999746: 8 7 5 918 5 1 3 9 2 690 5
            646797: 385 6 70 4
            386973820: 5 68 9 632 7 3 6 382 1
            506: 63 2 380
            29309707401: 713 2 7 32 3 82 373 9
            494: 8 7 286 67 82
            1690038: 938 926 503 102 7
            1183: 7 7 3 996 40
            498190: 232 429 1 5 549
            184738: 176 8 739
            1102735865: 220 5 4 697 9 3 3 5 401
            75348: 86 6 7 13 9
            28928: 6 1 5 957 218
            2784378: 123 2 32 4 380
            153912319: 7 69 7 8 3 7 6 7 3 164 41
            60867: 8 4 4 6 583 1 78 2 8 8 3
            16530060: 967 259 66 31 66 65
            94400253678: 8 2 6 90 15 65 9 6 458
            147860314: 1 1 3 31 762 98 5 1 5 27
            4134965363: 3 72 6 1 65 57 5 5 85 3
            3418100: 334 227 139 9 1 7 5
            5724509816: 700 4 334 924 7 551 8
            3407: 33 78 29 1 1
            322155288: 94 38 47 703 22 1 9 84
            2827527698: 4 897 233 788 96
            2055: 26 8 9 778 971
            2149779027: 37 581 7 90 24
            10281: 71 6 7 445 3
            51584431: 5 9 5 5 7 12 3 2 690 3 8 4
            69464: 2 7 31 4 5 3 8
            1117: 5 5 9 4 6 4 807 1 6 33 39
            88908757: 514 76 451 225 4
            10673: 4 222 5 5 799 2 64 81
            332798224: 5 5 5 15 316 9 3 1 3 9 4 7
            127: 8 7 85 19 5
            1342148: 2 1 737 59 3 9 1 1 3 3 5 2
            2247912540663: 6 9 375 5 3 4 2 54 5 663
            595647: 65 71 8 547 511
            335703: 373 9 6 865 2 83
            35519904: 8 3 680 1 70 28 168
            9222: 2 53 35 193 2 56 115 1
            4601520: 28 15 33 83 4
            30503831: 79 13 9 48 33 350
            36225119709: 69 8 1 881 3 3 6 5 9 6 7 8
            12627360036: 9 67 7 7 1 9 6 395 1 1 2 5
            81215505: 756 4 8 96 6 9 6 2 1 279
            716623: 67 3 6 8 837 75 2 1
            577119: 902 59 86 6 5
            38418941: 97 4 7 4 68 4 59 6 29
            8948480: 7 5 5 8 2 42 3 6 566 4 5
            11488805: 6 28 177 776 68
            9446: 780 2 6 2 3 79 2
            23811484: 68 72 9 77 5 4
            440075937: 5 634 77 781 400
            19212022: 3 20 2 60 22
            1133799048376: 24 740 96 975 665
            23773221504: 6 66 22 6 21 507
            1671: 1 5 4 8 2 5 3 2 795 8 17 9
            14005: 4 21 56 5
            997027919: 7 80 8 4 345 7 47 1
            14040338215: 31 647 2 4 253 7 7 6 9
            25791: 282 2 11 2 782 4
            14326: 1 5 351 21 38
            18483694: 7 9 9 72 71 4 4 878 9 4 2
            7418796: 597 3 552 99 49 62
            4064312: 30 99 9 35 9 6 4 1 25 8 7
            71971711: 8 578 239 5 33 7 8 8 9 7
            242178446: 651 834 67 446 1
            49494374955: 3 6 72 57 20 670 95 5
            288: 4 3 2 5 4 6 3 1 33 14 1
            4976165403: 845 473 7 15 2 415 3
            4170: 81 420 3 91 7 5
            3787: 9 67 6 6 1 4 3 7 8 2 131 8
            164018: 861 38 81 5 23
            273025: 546 5 1 7 8
            1209: 6 49 907 5 3
            77: 71 5 1
            206939699: 4 5 6 30 3 7 53 9 6 99
            631555321: 6 315 55 315 6
            233222558101: 3 74 7 8 5 77 8 19 8 6 50
            2374: 2 5 88 9 7 8 988 3 4 622
            11277161483: 76 1 8 10 3 6 9 269 6 83
            407924: 3 83 9 6 9 41 1 47 4 30
            426761130: 52 1 819 62 112 5 6 6 4
            2034000: 54 9 1 9 1 2 6 44 339 3 4
            79380: 39 6 9 2 3
            495646675: 4 830 3 6 5 31 9 4 33 1 7
            1155: 5 71 481 3 2 34
            89367: 6 3 662 8 26 7 6 179 3
            16547544: 9 685 76 251 42 312
            8938: 7 4 25 5 218
            11056: 4 92 5 3 6
            620357862: 620 354 3 133 729
            248173345: 7 6 2 5 8 85 2 7 9 8 166 5
            9628298: 756 2 239 504 53
            1031077670944: 1 807 7 812 1 2 7 5 9 4 1
            47692170: 5 8 6 614 8 3 7 1 73 1 28
            9879506: 98 793 67 1 68 70
            1284442543: 394 40 2 9 962 9 9 4 8 9
            9189: 513 627 7 8 13
            1441: 4 1 12 24 3
            1777083: 7 79 1 4 7 67 17 5
            7726092: 13 8 56 260 9 5
            8509997761: 87 1 926 976 2
            79147: 983 774 45 48 34
            1017: 934 5 34 43 1
            5663: 2 3 886 4 1 343
            2121642536: 8 77 6 2 252 4 2 2 411 6
            205390: 547 60 97 69 9 92 235
            167176596: 81 209 7 849 97 6
            58368: 12 4 55 8 1 82 310 8 6
            1530: 8 9 90
            3800973405: 360 6 871 849 402
            147122946: 4 687 9 41 577 61 2
            77953682: 6 3 27 67 63 76 155 99
            1174: 590 418 72 3 91
            594691440: 67 86 38 2 8 8 3 122 35
            28557432132: 739 14 895 7 276
            9993168: 787 3 32 58 3 8 3
            30960: 8 4 30 3 688
            6576: 22 247 4 20 6
            5337122: 5 3 9 29 4 4 6 357 89 7
            15143942: 702 5 7 612 5
            17127: 3 9 5 484 43 7 5 1 2 559
            2954052401902: 476 46 62 335 66 902
            47387767: 29 38 696 7 7 4 73
            524615: 715 733 92 97 331
            1332433696: 588 5 213 959 5 11
            30113: 3 19 7 571 31 43
            472725: 1 2 23 90 5 292 67 8 5
            1186291128: 72 263 7 9 6 7 994 834
            2369493: 87 184 24 87 49 3
            12378072: 7 8 179 2 2 8 3 8 6 20 6
            5603140: 7 39 8 997 20
            3070559: 3 4 29 7 6 5 9 58 9 6 5 9
            86520: 5 3 5 637 880
            1095595753: 6 83 61 301 73
            371852218: 9 3 6 459 3 9 444 5
            8098588836497: 956 7 87 97 932 9 497
            15338257536004: 263 1 4 5 271 613 8 58
            243186204: 5 589 4 9 2 6 4 646 762
            53170734: 8 8 6 6 123 948 1 5 8
            360566001385: 680 31 32 1 53 4 5 42
            3860823: 3 5 2 4 5 6 6 8 9 70 3 180
            15713744: 7 486 96 8 658 6 670 8
            1713601: 711 482 5 91 3
            266414191: 3 33 929 72 9 7 9 8 7
            19214: 68 2 7 44 6 26
            174658079389533: 296 724 39 188 9 815
            105176651: 936 3 8 5 6 86 2 3 374
            157078: 7 33 85 8 1
            87020640: 308 2 70 23 4 88 504
            701438474: 4 3 38 8 494 7 38 3 8 9 4
            49247363: 7 44 8 5 112 7 6 77 9 7 4
            1696203: 3 2 3 9 94 29 106 7 733
            33867077: 870 469 7 83 7
            4410781575: 724 266 203 4 1 49 4 3
            30132: 394 23 975 7 3
            1987473: 190 8 560 187 1
            29360: 1 15 5 654 40
            135835: 51 12 431 14 5
            33419: 3 7 1 139 3
            910287: 5 2 22 836 2 87
            6572860245: 384 351 43 543 383
            214365: 29 1 3 8 812
            160783202: 8 7 349 6 8 5 489 5 1 4 2
            3121274: 3 450 289 8 74
            35709465: 1 3 832 7 678 4 9 524 1
            3607232500: 7 7 520 587 9 6 4 9 2 4
            253899364262: 902 9 4 9 6 39 3 1 4 26 2
            2497428: 34 7 605 169 28
            1229: 7 75 3 7 976
            954970: 946 2 9 857 4 2 68
            18283746: 808 973 58 59 3
            3306408: 3 6 638 70 8 5 9 9 31 3 6
            547: 5 1 6 504 7
            1113: 299 4 68 3
            595504: 174 7 414 415 89
            140043850: 1 7 954 2 780 356 735
            81237744: 743 69 328 8 485 1 4 3
            125554: 8 1 164 1 85 9
            69253654952: 678 96 28 60 4 38
            59591698: 11 3 7 8 9 82 945 84
            754513: 387 40 19 93 4
            18810: 28 3 7 679 1 4 5 5 856 9
            869714010: 29 7 4 759 346 8 21 9 1
            26469952: 1 5 359 64 8 6 2 4 1 8
            24528876: 7 6 584 809 69
            4471: 8 6 9 7 55 827 9 1 4 283
            1456733: 2 728 65 1 80
            5117760: 605 964 1 206 5 5 8 9 8
            3831831368: 8 7 98 63 431 32 1 3 8
            7457856118: 56 6 4 4 5 180 496 58 2
            463: 2 5 28 12 7
            964: 88 6 36 8 392
            27168: 68 45 9 42 55 12 6 6 1 4
            390154431744: 969 81 39 849 38 7 22
            1689434: 563 3 403 27 7
            4176741281472: 7 63 7 81 6 47 9 617 64
            625879: 2 507 6 55 9 61 2 5 2 2 3
            26389755: 68 8 21 22 3 105
            40293792: 8 3 553 92 33
            607530: 678 16 8 6 7
            413350002: 4 3 4 5 1 3 3 9 7 50 5 751
            6177691: 4 7 68 51 86 31 40 3 8
            18614: 5 32 15 391 85 18 56
            24009551: 74 1 30 9 9 6 2 5 2 11 5
            16967: 4 1 3 12 893
            3818033: 49 75 7 115 4 8 783 9 8
            1019070: 83 2 6 357 642 72 3
            2790844: 96 646 5 9 124
            137940397056: 40 98 47 7 126 616 64
            23701973245327: 901 9 36 565 73 327
            40436355826: 55 77 682 40 1 7 913 2
            1838: 7 3 7 806 9 1 4 970 6 8 6
            14679546: 3 243 4 942 4 5 5 2 682
            65017567: 774 84 771 793 3
            4298: 6 888 4 91 167 6 4 454
            3210: 1 54 77 9 533 1 395 3
            571: 1 447 124
            27231910: 525 910 2 57 46
            678182: 90 2 600 869 362
            360081: 9 38 6 69 98 7 63 21
            3230: 6 502 7 131 5
            3004958643: 9 3 9 1 8 396 6 2 2 4 1
            9129703: 30 27 16 3 702
            218303783536: 317 294 8 86 93 8 9 1 3
            3483: 39 35 55 3 9
            4379014349: 53 82 32 952 62 350
            49182339: 973 1 83 609 47 2 56
            52141320: 631 81 8 6 19 7 90 6
            13546505: 5 8 463 2 13 453 49
            502: 6 2 12 2 454
            70330615: 5 95 70 591 95 17
            24164113: 4 9 30 763 133 29 4
            39576620443: 8 3 7 6 5 6 15 9 7 3 7 40
            7035: 3 6 78 5 6 8
            175318: 4 6 3 43 4 59 6 6 9 10 1 9
            15340390142: 385 3 9 4 4 5 5 985 1 8 8
            1413407490: 22 433 92 89 90 5 62
            22644373: 524 9 8 1 63 48 1 660
            6628993: 526 5 4 2 90 19 7
            847722: 899 3 2 1 1 5 6 8 26 6 3
            100962: 6 94 964
            655920: 1 220 93 32 413 787
            1731: 21 21 20 884 6 1
            248107860: 2 6 622 227 85 5 561
            3034: 33 373 1 8 1 7 24 98
            234: 35 4 6 1
            429347771369: 536 68 4 7 14 8 7 3 95
            984020529: 29 4 869 999 5 50 29
            853: 3 1 5 2 500
            166658472: 1 3 176 821 2 4 7 7 9 81
            164224: 948 78 5 2 32
            8885095: 8 1 7 598 23 247 4 4 1 6
            17448: 73 9 12 180 527 1
            4797444604: 9 9 1 3 6 4 73 152 8 9 5 6
            572243952: 682 15 85 4 82 367 3
            209250: 631 1 330 65 625
            1107: 82 1 9 9 3 31 1 71
            20837370: 1 8 8 192 5 17 8 9 1 43
            543229500: 8 920 90 75 820
            19829233270: 4 2 4 6 6 292 3 32 6 2 6 2
            9036229: 3 6 5 947 8 75 2 582 97
            350601133: 9 73 1 8 9 360 2 3 720 6
            475: 7 5 5 384 9
            12276: 8 2 5 245 26
            110642415: 930 15 9 1 8 2 6 88 9 3 5
            963: 6 37 95 1 4 3
            278637660: 2 3 3 76 8 363 9 9 7 927
            412268: 46 29 5 4 7 46 7 20 4
            935616: 11 28 41 173 4 7 3 64
            14103180: 435 60 17 3 36 5
            46035: 5 11 286 5 27
            1052096768: 712 4 8 757 61
            304538: 1 956 6 4 53
            1557: 667 92 3 795
            374723: 3 5 3 74 3 377 13 7 61
            246084806: 1 230 42 403 2
            2162846: 54 8 4 1 8 82 9 5 87 346
            70764540: 2 6 29 21 78 3 578 7
            251008126: 1 6 2 3 4 34 93 32 4 129
            75169467: 8 8 858 6 81 7 32 3 729
            107645454: 52 226 57 2 6 217 7
            24140763150: 2 3 773 58 26 1 274 75
            2895363: 3 3 354 7 96 7 6 216 99
            612: 4 1 2 94 6
            456279344117: 4 114 2 1 6 9 1 2 441 1 8
            556777: 35 3 60 99 87 64
            18251: 8 86 11 904 6 27 3 8
            71415161: 759 35 64 201 42
            71878843312: 953 2 482 301 43 31 3
            791136806: 345 7 76 6 626 22 7 2
            245037: 6 77 806 967 39
            102412828: 157 5 56 63 25
            770563: 199 20 45 998 71
            342145080: 747 2 835 800 4 5 27 2
            68248154583: 655 753 708 21 765 7
            54937: 808 4 4 798 4 33
            745200: 3 8 4 478 5 3 81 6 9 9 3 6
            4160740434: 9 77 2 8 6 74 460 7 5 3 7
            1886101: 99 8 33 534 1 6 8 525 7
            3233354: 62 2 5 371 7 87
            1667: 15 5 80 5 62
            24963: 39 632 37 277 1
            7630488: 25 7 7 4 7 6 22 115 6 1
            11434824799: 7 726 4 78 493 5 2 3 9 9
            231749: 101 996 30 197 7
            4482: 6 666 13 12 464
            747192: 87 8 62 6 978
            44018481: 976 4 914 3 3 913 3 7 2
            6371: 94 7 63 5 3
            23571994: 9 264 2 4 1 6 33 5 5 6 94
            208: 5 8 56 26 1 28 84
            1810086: 8 5 1 56 132 30 364
            1080752: 36 4 27 747 2
            1166716: 4 13 170 7 6 6 21 14
            427335: 2 892 3 270 76 65
            94539774: 972 2 840 6 5 1 895 32
            908688: 615 5 4 61 7 1 59 99 3 6
            3343457: 309 44 2 5 37 47 6 9
            107975389: 70 879 147 2 387 9 58
            2653075079: 4 7 447 3 64 40 63 193
            38546921: 385 45 99 93 2 2 1
            39328633: 863 4 83 1 86 6 703 9 1
            124289724621: 2 5 91 309 92 56 9 773
            408352: 34 4 3 1 355
            2682572: 2 68 2 571 1
            480732: 5 8 7 55 9 709 62 2 1 2
            99444997: 7 7 710 4 499 7 2
            53067197: 6 859 39 5 8 8 11 9 3 2
            59455115303: 8 93 9 7 1 70 98 1 905
            4873: 4 266 7 521 79
            6606600: 230 9 1 5 4 143
            18977220016: 9 457 5 2 339 15 2 2 1 6
            3782835099: 7 497 3 780 3 25 5 2 99
            2322402: 4 82 45 75 42 8 66
            26216124: 6 5 41 2 796 21 1 8 122
            207992: 3 8 8 89 983 9
            236304642: 4 928 1 553 458
            1669: 668 45 3 929 24
            445610: 2 468 947 84 427 9
            409113934: 1 8 9 40 8 1 3 1 51 17 9 3
            3132195432: 4 3 708 79 4 8 9 13 9 3
            11291: 6 5 357 29 6 557 56
            69647139: 7 595 929 18 9
            6240: 6 608 95 71 8
            11324015008: 9 17 7 72 2 77 765
            156638: 1 6 1 282 542
            497520074: 691 96 75 74 1
            4641: 23 57 12 2 2 3 6 2 1 188
            430327: 2 610 352 35 1 851
            295783528: 209 39 9 84 48 39 1
            1095048: 7 899 58 3 5 40 1 6 9 4
            1844295: 12 65 578 555 740
            2264724: 18 40 73 5 37 1 1 903 3
            5149: 9 6 7 49 4
            142552: 507 279 8 6 989 80 16
            1683: 81 83 1 7 5 9 523 6 968
            17356056: 1 3 3 27 6 6 124 1 4 6
            24564: 3 16 3 77
            29372575: 812 3 78 7 11 42 1
            45183: 3 32 465 87 989 694 1
            115057: 7 7 36 9 18 68 1
            5741491: 8 6 35 2 7 4 3 29 4 4 9 96
            1295532: 8 81 282 36 1 97
            69311788: 2 3 23 67 49 4 6 7 26
            516: 2 442 61 7 4
            8923049478: 918 54 497 1 18
            7029230698: 83 5 8 4 60 672 6 1 454
            25720378257: 8 7 48 4 2 2 7 7 3 289 9 6
            831: 3 21 9 7 752
            2747627989: 22 4 61 987 129 279
            15836955591: 6 2 8 1 51 8 59 7 8 227 7
            10655: 2 7 72 93 662
            35060364: 3 40 28 44 81
            10993968: 87 98 413 2 86 612
            4908438: 1 8 2 5 24 71 6 9 6 861 3
            2323011534249: 4 2 79 5 8 790 606 7 5 3
            234304945351: 807 2 3 69 776 7 5 21 1
            33216: 408 7 77 771 481 9
            59538994: 3 7 72 91 62 8 32 2 5 74
            15536271: 135 3 5 7 4 36 82 879
            763587: 12 7 265 6
            2974159968: 110 1 54 3 2 9 84 86
            93344925312638: 7 7 6 3 4 8 6 72 696 641
            1774: 1 95 2 63 7
            21875: 414 5 52 60 28
            5307120: 8 5 2 44 9 6 7 1 4 243 1
            466750362990: 888 6 9 5 9 2 58 2 9 8 9 4
            32464: 12 12 225 58 6
            14712732030: 888 45 2 828 28
            781434053: 18 5 2 4 4 1 1 4 87 3 54 1
            675956948806: 404 9 35 3 5 8 668 70 8
            39184: 6 71 18 20 5 744
            7598216340: 83 7 57 522 9 5 507
            201398: 645 9 404 80 32 150
            716511403: 890 6 816 335 44 5 6
            121642: 3 4 3 109 31
            147660164: 82 9 2 5 4 257 784 4
            20315941677: 3 677 594 15 1 80
            3379889746: 198 817 17 743 3
            258005515: 9 85 5 81 9 5 337
            115130: 731 563 3 13 6 69 29
            1444130843: 2 5 4 5 8 95 39 91 846
            297: 26 6 48 92 1
            6138: 2 56 54 1 90
            188818326011: 3 4 803 7 22 74 45 13
            109854440: 9 2 5 8 2 835 758 776 5
            33239219: 97 6 87 24 32 54
            7966513: 623 9 6 1 38 8 49 41 8
            504870240000: 50 10 94 736 21 695
            713274: 7 11 520 819 935
            10054859064: 93 6 60 312 15 8 2 7 9
            33857619: 90 79 90 3 4 5 957 464
            1650710889: 38 6 169 2 7 306 8
            81509148: 15 9 962 51 7 7 7 9 23
            361793955: 919 70 152 55 37
            141033289: 285 178 1 4 278
            4528: 19 8 74 4 2
            1687128127: 3 8 8 94 288 41 218 5
            159813: 82 19 40 1 2
            108038776529: 2 5 520 885 727 939 1
            2104697032: 885 91 97 391 9 9 82 3
            15798: 9 583 8 3 4 26 1
            77889637: 77 8 887 77 860
            1442532: 3 88 92 844 3
            414871565: 194 330 3 6 3 7 5 72 5 1
            22: 5 4 4 6 3
            178813217220: 951 47 6 3 8 2 5 7 21 9
            1988436: 475 41 1 7 38 9 4 3 6 2 7
            1929: 657 1 584 2 580 74 31
            877273395: 5 7 5 68 6 870 9 3 46 4
            21401685366: 26 8 5 7 653 4 2 9 8 3 5 3
            1169: 42 7 1 7 819
            48069787223: 9 5 8 8 5 8 298 4 6 7 1
            1567955016: 94 95 417 4 6 7 18 612
            24012315622: 6 1 86 5 3 7 7 9 5 5 6 24
            234993438: 8 3 860 1 5 6 2 6 2 1 69 6
            3999296358: 2 75 5 6 300 9 484
            5361: 59 78 515 7 705 92
            4697255368: 230 4 409 80 9 63 9
            20: 4 5 11
            7225: 3 719 1 3
            28957500: 6 5 3 715 450
            103304: 269 4 96 8
            69944664: 9 993 5 23 759 84 68
            1550: 61 366 73 8 3 26
            """;
    }
}