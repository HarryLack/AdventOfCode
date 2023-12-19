using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day8Tests
{

    [TestClass]
    public class Day08Tests
    {
        readonly static string testInput1 = "RL\r\n\r\nAAA = (BBB, CCC)\r\nBBB = (DDD, EEE)\r\nCCC = (ZZZ, GGG)\r\nDDD = (DDD, DDD)\r\nEEE = (EEE, EEE)\r\nGGG = (GGG, GGG)\r\nZZZ = (ZZZ, ZZZ)";
        readonly static string[] arrayedTestInput1 = [
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)"
        ];

        readonly static string testInput2 = "LLR\r\n\r\nAAA = (BBB, BBB)\r\nBBB = (AAA, ZZZ)\r\nZZZ = (ZZZ, ZZZ)";
        readonly static string[] arrayedTestInput2 = [
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)"
        ];

        readonly static string[] arrayedTestInputPart2 = [
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)"
        ];

        readonly static int part1Result1 = 2;
        readonly static int part1Result2 = 6;
        readonly static int part2Result = 6;

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Day08.Part1(arrayedTestInput1), part1Result1);
            Assert.AreEqual(Day08.Part1(arrayedTestInput2), part1Result2);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            Assert.AreEqual(Day08.Part2(arrayedTestInputPart2), (ulong)part2Result);
        }
    }
}