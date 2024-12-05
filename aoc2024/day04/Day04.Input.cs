﻿namespace Advent_of_Code_2024.day04;


public static partial class Day04
{
    public static class Input
    {
        public static string GetInput(bool useExampleData)
        {
            return useExampleData ? GetExampleInput() : GetActualInput();
        }

        private static string GetExampleInput() =>
            """
            MMMSXXMASM
            MSAMXMSMSA
            AMXSXMAAMM
            MSAMASMSMX
            XMASAMXAMM
            XXAMMXXAMA
            SMSMSASXSS
            SAXAMASAAA
            MAMMMXMMMM
            MXMXAXMASX
            """;

        private static string GetActualInput() =>
            """
            AAMXMSMMMSMMSSMMXMASMAMXXMAMAMXXMASMXMXXMMMXMMXMAMXMXSMMMXMXSAMXSASXMAMXAMAMXSXSSSMXXMASAMMMMASXMAMXAMXAXMASXMASAMXSSMMSAMXAXXAMMXXXXSMAAMAM
            SMSSMMMAAMAAAAAXMAXAMAMXASXSSMMSMMAXAXXASAXAAXSMMSAMMAAASXSASASAMXMMSAMXMMAMMMAMMAMAXMXXMMSAMMSASASASASAXMMXXMASXMASAAAMAMXXMAMXMMMXXAMXXMAA
            MAAAAXSMSSMMSXMMXMSSSMMXMAXAXSAXASMXMMSMMASMSMXAASAMAMMMXAMASMMAMXMASASAASAMAMAMSAMSXSSMSXXAXAXAMASAMAAXMMAMXSAXMXMSMMMSSMAASMSMAXAASAMMSSMS
            MMMSMMMAMAXAMXMSAMAMAMMSXMXMMMXMMMMAAMMXMMMXAMMSMSMMXSAMMAMAMASXMAMXSMMMMSAXXSSXXASXMXSMXASXMSMSMXMAMSMSMXAMMMAXMAAXAMAAAMSMAAAMAMSMMAAAMAMX
            SXXXXXMAMSASAXMAXMASMMAMAXMXASMSMAMSMSMAXSASMMAAAMMMASAXSAMMSAMAXMXAXXMAMMAMXMMMSSMAMAMMMMMXAAAAMAMAMAAXMXASAMXASMSXAMMMSMAMMSMMXXXASMMXSAMX
            XAMMMSSSSXAMMMSAMMXMMMAMMMAMSAAAMSXXAAXAMXMMXMSSSMAMXMMMSASAMASMMSMMSMSASMAMXAMMMAAAMAXSASAMXMSMSASASMSMMSASMSSMXAXXXMXXMXMMAMXMMASAMMAMSMSS
            XXSAAXAMXMMMAASAMSXSASMSSXSXXMSMSMAMSMMXSSMXXXAMAMXXMAMXSAMXSAMMAXAMXAMAMMAMMXMAMXMMMXMSASXSXXXASMSXSAMXXAMMAAAXMMMXXSSXMASMMSAMAXAAXMAMXAAM
            XASMSXXMSXMSMMSXMAXSAMXAMAXMSMMXMMAMXAXXXMASXMXSAMXSSMMMMAMAMXSMSSSMXMMSMMXSMMSSSMSSXXMMASASXAMXMAMAMAMXMASMXMXMAMXXMMMXSAMAASAMSSXMMSXSMMMS
            SMXAXMAMSAMXMASMXSMMAMMAMXMASAMXMSAMSAMSAMXMAAXMASMXAMXXSMMMMMMXAAAAXXAMASAAAAAAAAAXSAXMXMAXMMXAMXMAMAMASXMXMMASASXXMAAMSAMMMMMMMAASAMXXAXAA
            MXMXMSSXXAMXMASAAXMXSMSSXMMAMAMAXMAXMAMXAMSSMMMXMMXSXMMXSMMASAAMMSXMXMMSAMSSXMMSMMMSMXSAXMSMMMSMSAMXXAXXSMMAMSASASAMSMSXSAMMSXMAMSMMASMSMMMS
            SSMMXAXAMSMSSSMMMSAXMMMXAAMSSXMXSMMMMSMXAMXSAMSASMXMMMSAMXSASXSXAMMMMMAMXXMXMAMXAMSMMASMAMAAAXAAAMSMSSSMSASAXMAMMMMMAXMXMAMSMXXAXXASAMMAXXXX
            XAAXMMSMXXAMXMXAAMAMMASMMMXXAASXSXAAXMAXMAMXMMMAMXXMAXMAMMMMSMXMMSAAAMASMSASMSMSSMAAMAMSAMSSMSMSMXAAAAAASAMMSMXMXASMMSSMSMMAAMSSMMXMAXSAMMSM
            SSMMSAAXAMAMMMXMAMXAXAMAAMXMSMSAMXSSSMAXXAXMSSMAMSMSSSXSSMAAXAMAASMSMSMXAMAMAAAAASXSMMMSXMAAAXXAXMMMMMMMMAMXAMMSMMSAMMXAAXMMXMAAAXSSSMSAMXXA
            MMSAMMSMMSAMAMXMAMXSSMXSMMAAAXMMMAMAMMAMSMMAAXSXMXAAAXAAAMMMSXSMMSXMASAMSMSMSMMMMXMAMXAMMMXSMSSMMMXMXXMXMAXXASASAMXAMXMXMSXSXMSSMMMAXAMXXMAS
            SAMXSAXAMAXSSMSAMXAAAAAXASXSAXMASAMAMMAMAMMMSXMMMMMMSMSMMAMASMXAAMAMXMAMMAMXMASMSMSSSMASMSXXAXAXASXSMXSASASXXMASMMSMMMXSAXAMXMMMMXMAMMMMAMAA
            MAMSAMXAMXXAXASAMMMSMMMSAMMXMMSASASMSSXSAXXAXAMASAMXAAXXXXMAMMSMMSXMXSMMMAMAMSMMAAAAAMAAAAXMXMMSMSAAAASAMASXXMMSAAAAAAMAXMAMSXMASMMMXAXSSMMS
            SSMSAMSAMXMAMMSSMAAAXMXMAMXXAAMAMAMXAAMSXMXXSSMMSASXMSMSXMMMSAAXMAAMASAASMSSXMASMSMSMMMSMMXMAAXMAMMMMMMAMAMXXMASMXSSMXAMXMXMSAMAXXAMMMMXMAMX
            MMAMAMSSMMAAAXSAXMXMMXAMAMSSMMSSMMAMMSMSAMXMXAMMMMMAMMAXAXAAMMMSMMSMASXMSXAMASMMXXMXMAXAAXXSMSMMSMMXMAXAMAMXMMMSMAMMMMSXXASXSXMAMSXSAMXXXAMX
            AMAMMMMXMASXSSXMMSSMSSMSASXAAAAAAMAXAXMXAMAAXMSSMSSSMMMMSXMASAXXAXXMXSXMMMXMASASAMXMSMXSXMMMAXMMMAMXMMSMSAMASAXMMMSAAXMXMASAMMMXXMASMMAMXSSM
            MMASAAXMXMMAMMMSAAAAAAXSMMXSMMSSMMXMASMMXSMSMXAAXMAMMAMAMXMMMMXMAMXMAXAXMASMXSAMXSAAXMAXAXSMAMAAXMMAAMAAMXMMXASXXXMMMMXXMASXSAMMAMXMAMXSAAAA
            XSASMSMMMAXMSAAMMSMMMMMMSMXXXAXAXXMASMMAAXAAAMSMMMMMSAMSXSAAAXXASMSMXSMMMSAMXMAMXMASMMASAMSMMSSMSSSXMAMMMSXMSAAMASXAXAMXMMSXSASMSXMSXMAMAXAS
            XMASAXASXMMXAMMSAMMXAMAMMSSMMSMSMSSXMASMMMSMSMMXXAXXMXSMASXMXSMXXAAXXAASXMMSMSAMXMMMXMASMXMAXXAAXMASAMXSAAAMAMXMAMSMSSMASMXAMAMXMAXXAMASMSMX
            XMAMXMAMMAMXMXAMAMXSXMASXAXMAXAAAMXMMAXXSXXSXAAAXSXSXMXMMMMSAAMAMMMMSSXSAMAAAAAMAXAMXMASMSSSMAMMMMMMSXAMXSXMMSSMAMAMXAMASMMXMAMASMMSXMAXAAMX
            XSASXMAMSAMAMMMSAMXXASASMAMMAMMMMMAXMMXXSAXAXMMMMMAMMSSXMAAMMXMASAAXAAMMAMMMMMMXMXMXAMXMMAAMXSMSXSAAAMMMAAXSXMASXSMMSSMXXMAAMAXXXXXMASAMXAMS
            MSASXSXMXASAXAASASAMXMASMMMSXSXXASMSMAMSMMMMXSAMSMAMAAXAMMSXXMAXSAMMASXXAMXSSMSXXSAASAMXMMSMXMAXAXMSSXAXSMAXASAMMAAAAAXMMMMXSAMSSMASAMAMXAMX
            MMMMMMAMMMMMXMXSXXXAXMXMXSMSAMASMMMXMAXSASAXMSASMSMMMMSAMAXXXMXXMAMSXMASXMAMAAXAAMAMXASXMMAMAMXMSMAAMMXXASMSMMMSSXMMXSMAXSAMMXMAAMAMXMAMSSSM
            MAMAXXAMASXMASMMMSASXMXMAMMMAMAXMSSSSXMXXMASAMXMXAXSAAXMSASMMMMMSAMXAXMASMASMMMMMSMMXAMMAXSSXSXAMXMAXAXSAMMAMAAMAMSSMXASAMASAAMSSMSAXMXXAMAA
            SASMXMASASASXSAAAAMMASXMSSMSSMMSSMAAAMMSSMMXAXMSSSMSMASMMAXXAAAASMSSMMMAMXXMASXMAAAXMMMSSMAMAMMMMSMSMSAMXMSSSMSMAMAAAMSXMSAMMMMMXXMASXXMXSMX
            SXSAASMMAMXMASXMSSXXAMAAAXMAXAAXAMMMMSAAAAMSSMAXAMAMXMXXMAMSMSSMMMXXXAMASXMASMSASMSMSAXAMMMMAMAMMMSMAMXAAXAAXMAMMSSMMMXAXMXSMMSSSXSXSAMSAAXS
            MASMXXAMXMSMXSAMXXXMXSMMMSMMXSAXMMSAXMMXSMMAASMMSMMMSMASMSXMMAXAASMSSXXAMAXXMAXMMAAAXMMMSMXSMXAXASAMAMASMMSSMMAAXXAAMXMAMXAXAAMAMAMAMMAMASMA
            MAMMMXSXSXAASMAMXMASXAAMMXMXAXMXSASMSMSAMAMSXMXAAAAAAMAMAXMAMMMMMMAMXMMSSMMXMAMXMXMSAMAAXMAMASMSMSASXSAXXAAMAMMSASXMMMSAMAMSMMSAMAMXMAXMMMXX
            MASAMMMAMMMXAAAMXAASXXMMMAMMASXXMASASAMASAMXMXXSSSMMXMAMMMSMMXSAXMAMMXAXAXMXAAMXMXXMMSXSXMXSAXAAASAMXMXSMSAMSXXXMXAXXASXSXXXMASASXSXSXXSAMXS
            MAXASAMAMAXXMSMSXMASAXSASAXXAMAMMXMMMAMASASAMSMMMMMSSMXSXAAAMAAMSXMSAMMXMAMSSMSXSAXMASMMMMMMXSSMMMAMAAMXXMAMXXAMXXMMMMSASASAMAMXMMXAXXMSASAM
            MSMMMMXAMMSXMAAXXMAMAMMASMSMXSAMXSAXSXMASASASAAAAXXAXMAMMSXMMASXSAMXXAMASAMAAAAAXMMXMXXSAAXXMAXAXXAMSXXSASAMAMSXSASXMXSAMAMXMMSMXAMAMMXMXMAS
            XMASAMSSSSMMSMMMXSXMSMMXMMAMXSASXSAMAXMASXMXMMXMSSMSXMASMMSMMAXAMXMAMXXASASMSMMMMSMSMSASXMSMAMSXMSSXMMASXMMXXAAASAAXAAMMMSMMMSAMXSAXSAMXMSXM
            XSMMAXAASMAAXMSSXMAMAMXSASASASAMXMAMXSMXSASXSSSXAAAMSMXSAAASXAMXASMMSMMASAMAMMASXSMAAAXMASMXSXSAMAMAXMXMASMSSMMXMMMMMMSAAAAAXXASAASAMXMAXMMM
            AMXSXMMXMMMMMAAMASMMSXXMASASXMASXSSMXXMAMXMAAAXMMMSMAXSXMXMXMXXMAXAAAASXMMMXMSAMMSMMSMMSXMAAXXSAMAMAMMMSAXAAMXXAAAXXMMXMMSMMSXSMMSMMSASXXAAS
            SXASMMSMXMASMMASAMXMMAMMMMAMAMASMAASXAMAMXMMMMMAXXAMMMMASXXXSAMSSSMMSMMAAXXXMMXXAXAMXAXXXMMSSMSMMASASAAMMMMMMSSSMMSMASXMMXAMAXXAMXAXXAMSMSAS
            AMMSAAMAXXAXXSASASAMSAAXSSMSMSMXMSMMSMSAMMSSXMXSSSXXSAMAMAMMXAXAAXXAMASMMMMMXASXSSXMASMMXMAMAAMASMSAMMMMAAAAXMAMMAAMAMAMASAMAMMAMSMSMSMAMXAX
            MXSXMMSMMMMMXMASASAXSSXMAMAAAMXSMMAXAMXAMAAMASAMXMMAMAMMXXMSASMMSMMXSAMAMSASMXSAAAXSXASMAMASMMMMXAMAMSASMSSSMMAMMXMMMSSMAMXMAAMAMAAXAXMMMMSM
            XMMMSASAMXAAMMAMMMMMXMSAMMSMSMASAMXMASXMMMASXMXMASXSSSMSSMXMAMXXXAMAMXSXMMAMMMMMMMXMMSASMSAXMMXXMXMAMMAMXAXMASMMMAXAAMXMASMSMSSSSMMMMMXXXAMX
            MAAXMASMMSMSSSSXSAXXXMAMXXAXXMMMAMXMASXXASMSMMMSMMSXAMAASAAMSMSXSXMAXMMMSMSMAAXAAXAXMXASMMMSAMSAMMSASXSSMXMSASAASASMXXAMAAXAAMAAAXXASMMMMSSS
            MXSSMAMAAAXAAAMASMXXXSASXSSSMSMSAMSMXSMSXSASXSASAMXMAMSMXSASAAMMMMSMXMAAXAMXSSMSXSMXAMMMAAXSAMAAXXAXMAMAMXXMASXMSMMAMSMXSASMSMMMSXXAXSASAMMM
            SAMXMASMXSSMMMMXMMSMMMASAAXAAAASXMAMAMAMASAMXMMSAMXMAXMAMMMSMSMAAMXXAXMSMSMAXAAXASMSMXASMMMXMASMMAAMMSMMMMXMAMAXMASAMAAXMAMMAMSXMAMSMSXMASAS
            MMSASMSAAXMMMXMXXAAAAMAMMMMMSMMMSXMSSSMMXMAMXMASXMAXMAMXMAAXXMMSMSAMXSAAAXMAMMMMAMAAMSMSMMMAMAMAXMMAXAXXAXSMXSXMAASASXSAMAMSSXXAMXMAASMSXMAS
            XXMXMMMMXXAAMASMMSSSMMASXAXXAXXAMMXAAAMSSSSMSMASAMXMSASASMMSMSAMXMASAAXXMXMXXXAMAMMMMAXXAASAMAXMMXASMMXSMMAXAXMXMMSXMAMMMAXAMXSMSSSMXSAMXMAM
            MSSMSXXMMSSMSAXAMMMXMSASXSSMMSMXSAMMMMMAAMAAMMMXAMAXMASAMSAAAMAXXXMMMSMMXMASMSMMXXASMSXSSMMXSSSMSXMMASMAMMMMMXAMXXXMASXSSSSSMMMAAASXASXSAMXX
            AMAAXMXSAAMXMMSSMSAMXMASAXXAAXMAAMXXASMMSMMAMMMMMMXMMAMMMMMSSMSMSXMASAXXAAXAAAAXSXMSAAAXAMSAMAAASAXMAMXAMASMSMMSXMXMAMAAAAAAMXMAMSMMASAXASXX
            SSMMMSAMMSMAAMAMXMASXMXMXMMMMXMSSMXMXMASAAXMAMMAXSMMMXSMSSXXXAAAMMXXSXXXXSAMXMMMSAMMMMMMAASAMMMMMXXMAMSMSMSAAAMSAMXMASMXMMSXMAMMXXAMAMAMSAXA
            XAAMAMASAMXMMMASXSAMXSXSASMXSAMMAMMSMSSMXAMMXASXXXAAMMMAAXSAMSMSMSMAMMMSAMXSXAAAXAMXMSSMMMSAMMXSAAXSAMAAAXMXMXMSAMXMASXMXMAASAMMAMAMSMMMXAMM
            SSMMXXMXXMASXMASXAXXMMAXAAAASAXMAMAAXXXAXSMMXMXMASXMSAMMMSMXMAAAAAMAMAXAASAMXSMSXMMXASXAXXSXMSAAMSXMASMXMSXAXSMXXMXMXXMAAMXXSXSMMMXMAAAAMMMM
            MAAXSSSXASASAMASMMMSXMAMXMMMSAMSSMSSSMMMMMAMMXMMXMAASMSMXMAASMSMMXSXXSSSXMASAMXMAMXMSMSXMASMMMMSAXMSMMXSXSAMXAMAMSXMMSASMXSAMASASASXMSMSXMAS
            SSMMSAMXMMXSAMASAXAXXMASMSMXMXMXMAXMXAAAAMAMSMSMSMMMMAAXSMXMMAXXXMMXAAXXXMSMMSAMAMXXMXAMXASMAAXMAMMXAASAAXXXXMASAMASASAAAAXAMMSAMMASXXAAMSMS
            XAMXMMMSXAASXMAXXMSSXSAXAMXMASXMMSMSXSSXSSMMSAAAAXAAMXMXMAAMSMAXXAAMMSSSSXAAAMASMMMMMMMMMMSXSXSXSXSSSMMMSMMSSXMMSSXMAXXMMMSAMXMXMMAMMXMAMAAM
            SXMXMXAXMMXSSMMSSMMXASASXSAMASAMMAMXAXAXMAMAMSMSMXSMSAMXMAMXAMMMMMMMXMXAMMMMMSAAAAAAAAAAAXMAMSAAMAMAAXMXAAXAMASAMXXMMMMAXMXMMMMMXMAMSAMXSMSM
            XMMAMMXSMXXMASAAAAMMMSAMASMSASAMXSAMSMAMSAMMMAMAXMAAAXSAMXXXXSASAMXSXMMMMSMAXMASXSSMSSSSSMMAMXMXMAMAMMMSSSMMSAMMSAXSAAMAMXXSASASASXMXAMAMMAM
            MSSMSAASMSMMAMMSXMMAXMAMXMASXSXMAMXSAMXMAXMAXASASMMMMSAMXSXMASASXMMAAMMMAAMMXAMXAAAAMAAMAASMMXMASXSASXXMXAMXMAXSXMMSXSXAXMASASASASMSSSMMMXAM
            AXAXMMXSAMXMASAMAXSSMSAMXMMMMMMXAMMMMXAMXXXXSXMASAXXXXXXAXSAAMMMXMSSSMXMSSSXMSAMMMMMMAMMMMMASAXMAMMMAMXSMMMASXMAAXAMAMXMSMMSMMMMAMAXAAXAAXSX
            SSMMXMXMMMXSXSASXMMXAMMMMMAAAASMMSASAASMMMMMAAXXMXMMMMMMMSMMMSMAAXXAAMSAAAXAAMASMAMAMSMMXXSXMAXAMMSSSMMSAXMXSAASXMMSAXAMXAAXAAXMAMMMXMMMSXMA
            MAMXSASXXMXMMMMMAAAMXMAAXXSXSMSAMSASMXMAAAAXMSMXMXAAAAAASAXAAAMMSSMMMMSXMSMMMSAMXAMAXXMXSXAAMMSSMXAAASAMMMXMXMMMMMASMSMSSSMSSMSSSSSMSMSXMAMX
            XAMXMAMMAMXMASASXMMSSSSSSXMAXXSAMMMMMASXMSXXAAAASXMSSXSXSASMMMSAMMASMASAMMASAMASMSSMMASXMASXXAAAMMMMMMMSXSAMMXAAXXMXAXAAAAMXAAAAAAXAAAXMMSMX
            SMMAMAMXAXASXSASXASAMAAAXMMAMASXMMXXSAMAMAASMMSMSAMAXMXAMMMXAAMASMSAMASXMMAMXXAMAMAXSXMASXMMMMSSMAXSMSXAXSASXMMMMMMMSSMMSMMSMMMMMXMSMSMXXAXS
            AAXXSXMSMMASAMXMXXMASMMMMMMASAMXSXAMXMSSMMMAAXXXSXMAXXMXMXAMXXSAMXMMMXSXSMMMSMMMAMXMAMSAMAMXAAMAXXSAAXAXASAMMSMXMAMAAAXAMXXXMXXMXSAXAAMXXMMA
            MSSMMAXAMMSMXMXMAMSMMXMAASMMSAMASMMMAMAXAXXSSMAMMAMMMSXMMMSSMXMMMAMXSAMAMASAAAXXMSSSMMMXSAMXMSXMMSAMXMASMMAMAAAASAMMSSMXSMMMSMMSASMMSMSMAXAA
            XAAASAMXSXMASXMSAXAXSXXMXSAASXMAMAASAMASXMMXAXMAMMMSAMXSAAAAXMAXSASAMASXSAMMSMSAAAAXXXMMSASMXMASXSMXXMASXSXSSMSMSASXMAAXMASAAASMASAMXXSMSMSX
            MMSXMAAAMAMSMXAMMSXSMMSSXXXMMXMXXSASXSXXAASMMMSSMMAMAXAXMXXXMSAMXXMAXXMXMASMAAXMMMSMMMSXSAMXAMSMAXXMXMMSAAAAXXXASMMMSAMXSXSSMSMMXMMXXAMXMXXS
            SXMASXMXMAMXMMSMMMMMMAAMAMSMSXMXMMASXSMSSMMAXMAXAMXXAMXSXSAMXMASMMSSMASAMXSMMSMMAXXASAMXMAXSMSMMMMXMAXMMXMXMXSMMMAAXXAXAXXXAXMMSASXSMAXXXAMX
            AASAMMMXSASXMAXMASAMMSSMAMAAXAAMXSXSASAMXAXXMMASMMSXXSAAAXMAXSAMAXAAMAMASXSAMAASASXSMASMMMMAMXXAAXMSXSAMXMMMAMAMMSMXSSMMSSMSMMASXSAASAMSMSMX
            MMMMXAAAMAMMMSXSAMXXAAAXSSMSMMSMMSAMXMAMMSXSSMAXAAAXAMMSMXMAMMMMXMMSMSXMMXSAMSMMAMXXMMMMASAASXMMMXMAMXMAMSAMASAMMMSAMXAXXMAMXMAMMMMMAXMSAAAM
            XSASMMMXXAMAMMAMXSXMMXXMXMAMXAXAAMSMASMMAAXSXMSSMMSMXMAXXMMXSAMASXMMAMAMXMSAMXAMSMMMMSAMMMAMMMSSSXMXSAMXAMASXXAXAAMXXSAAMMAMAMAMAAXMXMXMMMSA
            SMASXMASXMSASMAMSAXSSSSSSMSMMMSMMSMXAMAMMSSMAMXSXAXMASMSSXMAMAMXAAAMASAMXAXXMXXMXAMAAMAMXSAMXXAAXXAAMAXMMSXMAXSSMMMXAMMMSSXSXSASMSSSXMASAMAX
            XMAMXMASAASASMMMXMMAAAAXMAMAAAAAXMXMASAMXXAMXMAXMAMMMXMAMAMASXMMMMXMXMAMSSMXXSSMSXMASXXMAMMAXMMSMMMASXMMMAMXMMAAXSSXSXAAMMMMMMMMAAXMASASASAS
            XSAMXXAMMMMXMXMMMXSMMMMMSASXMMSMMXMAXSASXSMMXMMSMSSMAAMASMMMSAAAXXXXMSAMAASXSMAAXMSMMASXMMSSXXAAXMMMAMAMAMMSXXSXMXAAMMMMSAAXAAMMMXMSAMMSAMAS
            MSAMSMSXMXSMMXXAMMASAMXAMXSASAMXSASXMMAMXAMXMMAAAAAASXMASAAASXMMMAMMMSAMMXAMAXMMMAAAXAMASAMAAXSASXAXXASAMSAXMXMMSMMMMASASXMSSXSASMMMMSAMAMAX
            AMAMMAAXSAAASMSMSAMXXSMMSAMAMXSMSASXMSAMXSAAAMMSSSSMMAMASMMXSMMASAMAMMMSSMMSSMSSXSSSMMSXMASMXMMAXMSMMMXAXMASXAXSAAAXSAMAMXXXXASASAAAAMASMMMM
            SSSMMSMSMSSMMAAAAMXMXMAXMASXMMMAMAMXMAMXAMMSXSAMXMAXSXMASAMMXMSAXASMSAAAAMXMXAAAMXMXMMAXXXMXASMSMAMAMXSAMXSXMMXSASMMMAMAMSMSMMMAMMMMSMMMAASA
            MAMXAAXXAXMASMMSMSAAAXXMMMMAAXMAMAMMMAMMXMXMAAXSXSMMMAMXSAMSAMMSSXMAMMXSXMAMMMMSAMXMASASXSMSXSAAXMSSMXMSMXXAMMAXXMXXMAMAXSAMXASXMASAMASMSMMS
            MAMMSSSMSMMASAAMASMSSSMAAASXMMMASXMASAMMAASMAMXMASAMMSMAMXMSASAAMAMMMSAMXSSSMSAMXSAAASAMXAAMMMXMMMAMXAAXXXMAMXXXMMXXXAMMMMSMMASMMXMASAMMAAAX
            SMMMAXXAAAMAXMMMAMMAAAXMMMMAAXSXXXSMSXSMSXSASXSMAMAMAXMMXMMMAMMXXAMXAMASMSAAMSXMASASXMAMSMMMAMAMXMMSSMMMMMSAMXMSMSAMXSMSAAASMASASMMMMMMSSMMS
            AMAMMSXSSSMSSSSSMMMMXMMSSXSMMXMSMASAXAAAMAMXMAXMAMSMASASAMMMSMSASXSMMSMXMMSMMMMMMSXXMSXMMXMSSSSMMSAMASAXAAXAMMMAMMXSAAASMSMXMASMMAMSAAXXMASA
            MSXSAXMAXAMMXMAAASXSAAAAAAAXMXAAMAMMMMMMMAMSMXMMSAAMXMASASXMAAMAXXAXMAMMSXMSAAASXMXXASAMMAXMASXAAMASAMXSSXSXMAXAMXMAMMMMMXMMMASMMAMSSMSMSMMM
            XXAMMSMSXMMSXSXSMMASXXMSMMMSAMXMSMSXXSAMXXSAMXXAMXAASMXSAMASMXMMMXSMSASAXAASMXXXAXAXMSAMSSSMMMSMMSAMASAXAMXXSMSMSMMAMXAAXAMXAMXASXMXAXXAAXAX
            MMMMASXXASXSAMMXAMXMSMAXMAXXAMXMAAMAASMSMXMAXXMXSXMAAXXMASMMAXSASXMASMMXSMMMAMSSMMAMXSMMXMAMXMASAMXSAMMMMSAMXMAAAAMASXSSMMSAMXMMMMXSAMMSMSMS
            MAAMXXASAMAMXMAMAMXAXMAMSXSXAXMSSSSMMXSAXXSSMSXMXMSMMXMMASAMXMXASAMMSXMAXAAMAMXAAXAAMMXXAMSMXSASMSMSMMMAXMXSAXSSSXSMMMXMAAAXSASXXSAAAMMAAXAX
            SSSSSSXMMMAMAMMSSMMMMMXXXAMXXMMXMAXXXXMMMMAXMASMMMASXAAMASAMMSMXMXMAXAMMSMMSXSXXMSMXSASXSMASXMAMMAAXSAXSMMASAMXAMXSMMSAMSMMMMXSAAMASAMXMSMAM
            XAAAXXAAXSSSXSAAAMMSAMMAMXMXMASAMAMXMXMAXMAMXMXXASMXSMSMMXAMAMMSMAMMXXMAAAXSAMXSXXMAMMSAASMMMSSXSMSMMMXMAMAMMMMAMAXAASAXMAAAXMMMMMXMMMMXMASM
            XSMSMMMMMMAAAMMSXMASAMSAMASAMASXSAAMASMSXSASXSMAXMXXSXMASMSMXMAAAAAXMSMSSSMMXMAXXAMXSXMMMMXAXXAASAMAXMAMAMXSSMSMMMSMMSMMSSMXXAXSXSAMXAAXXXMA
            AXXAAMMSASMMMXAMAMXSAMXASASASXSXMAMAXAAAASMXAAMSSMMMSASAMXAMMMSSSXSAAAAMAMAXMMASXSMSSXMMSXSMSMMMMASXMMSSSMMXAAXSMMMAAXAAXMSSMXSAMXAMXSSSMMSM
            SSMSSMASASXSXMASAMAMMMSXMMSAMASXSMSXSMXMASAMSMMAAMXASXMMSMMSAMMAAAXMSMSMSMSAAXAMXXMMSAXASMMASAMXSAMXSAMXAXXSMXMAXXXMXMMMSAAXAMXMSSMMMXAMXAAX
            XAAAMMMMXMMMMSAMAMASMMMMAMMXMAMMSASAAXXXXMXMAAMMXMMMSASASMASASMMMAMAMAMAXAAMSMMSMMAAXMMMSAMAMMSAMASXMMSXMMMMAMSMMMMMSMAMSXSMSAXAXXAAXMAMMXSS
            AMMMSMMMSASAAMASASXSMAASAMXMMXXAMAMSMMMMMMAXXMMMSAXXSAMAMSMXXMXMAXMMMAMAMAMAAXMAMXMMSSSXXXMXSAMAXAMXMASAXAMMAMAAASMAASXMMAMAMMMSMSXSXMXXSAXM
            MXMXAAAAXASMSSXMASXSXSMSXSXXXASMMXMXMMMAAXMMXSAAMXMAMXMXMSXSSMMSXXXXMXMMMSXSMXSAXSAMAAMMSMSAMXSSMSSSMASMMXXSSMMSXXMAMAMAMSMAMXAAASAMMSAAMMSS
            MASXSSMSMMMAMMMSAMASAMMXMMMMXXMAAMXMMAMMSMSAAMMMSMMASAMAAMAXAAAAMSMSMXXAAAXAMXMAMSAMMSMAAAMASMXXAXAAMAMMAMXMMAMMMMXSAASMMXSSXMXMXMAMAMMSMSAM
            MAXXAXXAMAAAAAAMASMMAMAAAAASXSMSSMAMSASXAAMMSMSXAASASASXSMSMSMMSSMAAAMSMMSSSXSAMXSAMXMMSXSXAMXMMSMSMMSXMASAASXMSAMXASXMAMXAXSMASAMAMMMAMMMMS
            MSSMMMSMSSSSSMXXAMAMXMSXMSMSAAMAAMAMXAMMMMMXMASXMMMASASAXAMAMXXXAMSMSMAAXAMXMMMAXSAMXSAMMXMASXMAAXMASAASAMMMMMMSSSMMMMSSMMAMMXASASXMXXXXMAXX
            AXAMMASXAXXAAMMXXXAMMXMSXMMMXMMSSMSSSSMSXASAMXMAMSMAMAMMMAMSSSSSMMMXXXSXMMSAMASMXMASMXAMAXAXAXMAMXXMMMMMAMSAXAMMMXMAXXAMXMMMSMMSAMXASMMMSMSM
            XMAMMMMMXSXMASAAMXSMXAAMXMAXMXXMAXXMAAAXMASASASAMAMASXMMSSMMXAAXXXMASMMXSSXXXAMMASMMMSSMXSSMMXMAXMSMAXMMXMSAMSSSSSMSAMXSXMSAMAAMAMSMSAAXAAAX
            SSSMAXSAMXMASMMMSAXSSMSMASAXSAMXMAXMMMMMMAXMMXSXSMSAMAMMAMAXMMMMMAMASAMASAMSMMSAMXMAMAXAMXAXXSMXMAASXXMMSXMSMAAAAAAXASMSAMMAMMMSSMXXXMSSMSMM
            XAAMXMAMXAMXXAAXMXMAXAAMXMAAXAXSSSXMXSAXMMSSSXMASMMXSSMMASXMXAMMMSMMMAMXMMAXAASASMMMMASMSSMMXMAASMMMMMAAMXAAMMMMMMMMASASXMSSMSAMAAXMSMXXXMMS
            MSMMMXSSSXSASMMSMMMMMSMSXMXMMMMMAXAMAXASMAMMAAMAMASAMXAMMMAASMSAAMASXSSSSXMMMMSAMAASMMXMXAAMAMAMAAAAMSAMXMAMXSAAXSMMAMMMAMAMASAMXSMXSAAMMMAA
            AAXXMAMAMAMASMAAAAMXAAMMASAXMSSMMMAMMXSAMASXSMMAXXMASXSMASXMASXMMSAMAAAXMAXXXXSXMXMSASMASXMSSSMXSXMAXSASXSMSMSSMXAXMASASMMASXSSMSAMXMMMSAMXS
            SAMSAMSAMMSMMMSSMMSMSMXSAXXMSAAXXSASXXMASXXAAAXMSSMXMAASAMMMXXMAXMAMMMMMSSMSMAMXSXAXAMMMSAMAAAMAMXMXXMAMAXXAAMASMMMXMSASXSAMMMXSAMMXXAAMASAM
            MAAMAMXAXXAAXAXAXSMXMSAMASMMMMMSAMXSAMSXMMMSMMXMAXMMMMMMMSMSASMMMSXMXAAAAXAAMXMAMMSMMMAXMAMMSMMASXMXSMMMAMSSSMAMMMXSAMXMASXMASMMMXMSMMMSAMMA
            MAMMMMXSSSSSMXSAMXMASMMMSAXXAXAMASAMAAMMMXAMAMXMAMSMSMXAAAXMASMSAXASXMMMSSSSSSMXSAMXMXXSXXMAMXMASAXAMASMSXMAAMXSXAASAMMMMMMSXMAMXMSMXAAMXMAS
            MAMAMMXAAAAMMAMAMASMSAXMMAMSMMMSXMASMSMAMMXSAMSXSAXAAXSMSSSMSMAMXSAMXMAMAMAMAAMSMMMASMAMXAMXMAMASMMMSAMAMAMSMMXMMMMSAMXMMAMXAXSASMAMMMSXMAMX
            XAXASMMMSMMMMAMASXXXXAMXMAMAAXXAAXAXMAMXXAAMASXAMMMSMMAMAMAXXMXMASAMMSXSSMAMSMMMAMSASXASAMXMSAMXSXAMXXMASAMAAMMSMXMXAMAMXMSMXMMASMMSAMXAMSMS
            SXSASXXMMMSXSSSXSMSSMASASMSMMSSSSMMSSSMSMMSMXMMMMXAMMSSMASXMSMSMASAMXAASASXXAMXMAMSXMMXXAMXAXXSSXXXSAMSASASMSMASXMMSMMASAAXMSMMMMAXSASMMMAAM
            AAMAMMMMMAXAAAXXXAAAXASMSXAXMAAXMASAXAAXMAXMMMXMAMXXAXXSASAAAAXMASXSMMSMAMSAMAXMAXXAMSSMXSXMXSMXAXXMAMMMSXMAMMASAMXAXSAXMSMXAXAMMXMSMMAASMSM
            MMMAMAAAMMMMMMMMMMSSMAXMSXMMMMSMSSMAMMMMMAMAASASXMSMMSXMXSMSMMMXXMASMXAMAMSSMMSMSXSMMAASAMAXXMASXMXMMXSAMAMAMMXSAMSMMMMSAMASMSSSMXMXMSSMSAXX
            SXMXXXSXSAAAAMXXAAXXMMSSMASXXXXMXAMMMSSXMASMMSMSAAAAASXSAXMAXAXXAMXMXXXSXMMAMSXAXAMAMSSMXSAMXMAMXAXSMAXAXXMAXXAMXMAXAAAMAMMSAAAAMAMXMAMAMMMS
            AAXSMMMASXMMXSASMSXXAAMASAMASXMMSSMAAXAXMXAAMSXSMMMMMSAMMSMMSAMSSMMMMSAMMSSMMMMMMXMAXMAXXAMXSXAXXMAMMMSMSSSSSMSSSSMSMSMSAMXMMMMMMMXMSMMMMAAA
            MSMSASMAMAMXMMMAAMMSMXSMMMSAMAAAAXSMSSMSMMSSMMAXXXXXSMMMAAAXMAXAAAMAAMAMAAXXAASASMSMSAMSMSMASXSMMSSMAXXMAAAXAAAXAAXXXXASAXMMMSASASAAAXSASMSS
            SXAXAAMSMXMAAAXMXMASAASXMAMASMMMSMMMAAXAAMMXAMXMSASMSAMXSSSXSMMSSMMMSSSMMMSSSXSASAMXMAXMAXMXMAMXAAMMMSXMMSMMMMMMSAMXAMMMMXAAAMAMAXMSMSXAXAAX
            XMMMMMMXMASXSMXXMMAMMMXAMMSAMAXXXMAMSSSSSMAXMMSASAMASXMXMAMXAAAMAXSMMXMASMAMMMMXMMMAMAMMMMMSMMMMMXSAMXMXMAXXXSXAXAMXSXXAMMSMSMSMAMXAMXMXMMMM
            MXAAAXSAMXMAAAMSMMXXAMXMMXMASMSSMSSXXMAXXMSMSASMMAMAMAMAMXMSSSMSAMXAXXMASMSMSASMMSSSSXSAMAAXAAAMAASXSXAASASXAAXMXMXAMMMMSAXAAAXMSMMAAAAAMASX
            AXSSXSASAMSSMMMSAAMSMSAMXXSAMXAAMAMSMMMMXMXXMAMAMXMMSAMAMAMXXAAMMMSMMSMMXAMAMAXXAAAXAASASXSSSMSMMXSASASXSXMMMMMMSXMMXXAAMMSXMSMAMASMMMSMSAMA
            SMAAXXMASAAXAAAXMMMAAXAXSAMXXMSMMASAXAAMSAMSMSMSMSMAXXXAXAMXXMSMSMXMAXAAMMMAMXMMMSSMMMMAMMAAXSAMXXMXMAXAMXXAAXAMXAXAASMSSXAXMXMSMAMMAMAXMAMX
            MAMAMXXAASMSSMSXSASMSMAXSXSASMMXSXSMSSXSAMXAAXAAAAMMMSSMXSSMMXAAAAXMASMMSASXSSMXAAAASAMXMSMXMMMXSAMXMXMXMASMSSSMXMMSMSAMMMSSMAXMASASAMSMSAXM
            SSSMASMMMMXAAAAASASAMMMMXMAXMAAASXMXAAXSAMXMXMSMSMXSAMAMAXAAAAMSMSMMMSAASMSMMAXMSSSMMXMAMAMSXSAAAAXASAMXMAXXXAMXXXAXMMXMAAAAXAMMXAAMXXAMXXXX
            XAAAXMASAXMSMMMMMAMXMASXSSMAMMMMSAMMMSMSASAXXMMMXXAMASAMXSAMSMXXAAMAMSMMMAMMSAMMAAXAXMAMXAXAAMMSSMMMSXSAMXSMMMMXMAMMMMASMMXSMMSXMMSSSMMSMMMX
            MSMMSSXMAXXXXXMAMXMSSMSAAAXMASMXSAMXMXAMAXXXMXAXMMXSAMXAXAXMMXAMXMSMXXXMASMAMMXMASMSMSASMSSMSMMAAAXXMASASXXAASASXSAAASASMSAAAAAAXXAAAAXAAAXX
            MXMAXMMMMSSMMMXXSMMXAASMSMMXAAAASAMXSMMMSMMXMAXSAMAMASXMMMXXAMXAAXXMASMMAMMXSMXSAXAMASMXAXXXXAMSSMMASXMASXSSMSAMAMXXMMXSAMSSMMSMMXMSMMSSSMSM
            XAMMXMAXAAAAAMSMXASXMMMXXASXMASXSXMXMASAMAXASAXXAMASAMASAXMMXMMXMSAMXMAMMSASXMASAMAMAMAMAMSMMXMAMASAMAMMMAAAXMAMSMMSSMSMMMXXMXMXSSMXAXAAAAAA
            SSMSASXMMSSMMAAAMAMAXMXASAMXMAXAMASXSMMASXSMMSMSMMXMMSAMXMSAMXSMXAAMASAMXSXMAXXXMXMMXSMAAAXSMXSASXMASXSAMXMAMXMMXAAAAXMASXSASAMAMAASXMMXMMMX
            SAASASXAXXXMMSSSXASMMSAMMMMSMXSAMAMMAAMAMAMMAMMASXAAMMMSMMMAXAXAMMMXXMAXAXAMSMMMMSXMASXSXSAMXAMXXXSMMXMXSAMASXMASMMXMMMAMASAMMMASMMMMASMSSSS
            MMAMMMMSMSMSAAAAMXMXASXXAAMASMSMMXMSSMMAMAMMASMMMXMXMAXXAASXMASMSXSXMSMMSMSMAAXAAAAMAXAASMXAMSSSMXMASAMAMAMAXAMXSSSMMAXAMXMSMASAMXXAXMAAAAAX
            SMMMXAXAAXAMMMMXSMMMXMASXMXAMXMMMAMXMXSAMAMMAXAXSXSASXMSSMSXMMAAAASMMAXXXAAXMXMMSMSMMMSMMSXXXXAAAAXAMAMSXSMSXMMSMAMASXSSSSMMXXMMSMSXSXMMMMMM
            XAMMSSSMSMMMSAXXMAXSAMMMMSMSSXMSSSSXSASMSSSMSSSXMASASAMXAAXXXAMXMAMASXXMMSMMMXMMXXXAXXXAAAXSMMSMMXMSSSMMAXAXMAMASMSXMAAMMAAXXMAXAAXAXMSXMSSM
            SSMAMXAAXAAAXMSMSSMSXSAMXXAAAAAAAMAMMAXAAAMAXSXAMAMXMAMXMMMMSMXAMXSXMMXSAMMSAASAMXMXMAXMMMXAAMMMXMXMAMXMAMAMSXSASXSMMSMASMMMXMASMSMXMASAAAAM
            SMMASXMMMXMSXXAAAMXMXSMMMMMMXMMMSMXMMSMMMSMSXMSXMSMSSSMXMXAAAXAMXXSAAAXMASAMSSMASMMSAMXSMSSSSMMXMAAMSMMMAMSMAMMMMXMXAMAMSAMXSXAXAXXXAXMMMSSM
            SASASXSXSAXAMSMSMSSMAMXASXMASXAXXXXMAMAMAXXMAXXMAMAMAXXAMXSSMXSAMASXMMXSAMMMXXMMXAAAXXMXAAMAAMXAXSAXAAMMMSAMXMAMSSMMMSSXSAMASAMSSSMMSSXMXMAM
            XMMAMXSASMSXAXAMXAXMASXMSAMXAMXXMSXMASAMASASXMMMAMAMXMMMSAMAMMMAMMMAMXXMXMXAMXAAMXAMXSASMXXSXMMSXMMSSSMMSXMAMMAMAMAXAAAAMXMAMMMAAAXAAMAXMMXA
            MSMSMAMAMXSASMSMMSSMASAASAMXSMSMXMASASASASAMMMAMXSXMAMXAMXMAMAXXXAXAMXAASMSASXMAXSAXAXMMMSMMASAMAAAAAMAXMAXXSASMMSMMMSMMSMMMSMMXSMMMSSSMMSSM
            MAAXMXMAMXXAMAMAMXXMAMMMMMMMMAAASXMMMSAMAMAMASXSXMXXASMASMSMSMSMSMSAXAMXMASASXMAMSXMXXXSAAASAXASMMMSSSMMSXMASAMXXAAXXXXAAAAXAAXAMXXAAMMAMAAX
            SMSMXAMAXXMMMMMSSMXMMMSXXAXAMSMSAMSAMMAMAXAXXXAXMAMXMSAMAXXAAAAXAMSAMSMSMAMAMXMSMMMSSXAMSSMMMXMMAXAMXAAAXAAMMXXXSXSMMXMXSMMMSSMSAAMMMMXAMSSM
            XMAASASAMSMSXXMAAAMSSXMASMSMXMMAAASXMSXMMSMSMMMSMAMASMMMMMMSMSMMXMMXMMAAMAMMMXMXAAAAMMXMAXMASAMXAMSSSSMMSXMXMXMASAXMASXAMXSAAMMMMMXMXMXMMAMX
            MSMMXMXAXSAMXSAMXSAAMMSAMXAXAXXSMMXAXSAMXAMAXAMXMSSMAAAMASXMAAXAMMMMMMXMSMSMSMMSSMMSSSSMAXXASASXSSMAMAXXXAMXSAAAMAMASAMXSAMXXXAAASXSASASMMSS
            AAMMAMSXMMAMAMAXSMMMSXSASAMSXSAMASMMMSAMSXSASMSAMXAXMSMSASAMXMSSMMAAAAAXXMXMAAMAAXMMMMAMAMMMSAMXMAMMMSMMMSMASMSAMMMMMMMAMAMMMSSSMSASASMSASAM
            SXSSXMAAXSAMXSAMXASXSAMXMAXAMAAMAMAAASMMMXMASXMASMSMAXAMASAMXXSAASMSSSSSXXASXSMSSMSAASAMAXSAXAMXSAMXAXAXAAMXSMMXAAAAAAMASAMAMAAXMXAMAMMSXMAS
            XAXMASXSMXXXXAMXSAMXMXMASXMAMSAMXSSMMXSXMASMSMSMMXMASMXMXMXAMXSSMMMXAAXXXSMSAXAMMASXMSXSAXMASMAASXMMASXMSSSMXMASXSSSSMSASMSMSMSMMMAMXMXMASAM
            """;
    }
}