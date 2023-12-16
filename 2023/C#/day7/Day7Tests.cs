using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day7Tests
{

    [TestClass]
    public class Day7Tests
    {
        readonly static string testInput = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";
        readonly static string[] arrayedTestInput = ["32T3K 765", "T55J5 684", "KK677 28", "KTJJT 220", "QQQJA 483"];
        // credit: https://www.reddit.com/r/adventofcode/comments/18cr4xr/2023_day_7_better_example_input_not_a_spoiler/
        readonly static string[] arrayedRedditTestCase = [
            "2345A 1",
            "Q2KJJ 13",
            "Q2Q2Q 19",
            "T3T3J 17",
            "T3Q33 11",
            "2345J 3",
            "J345A 2",
            "32T3K 5",
            "T55J5 29",
            "KK677 7",
            "KTJJT 34",
            "QQQJA 31",
            "JJJJJ 37",
            "JAAAA 43",
            "AAAAJ 59",
            "AAAAA 61",
            "2AAAA 23",
            "2JJJJ 53",
            "JJJJ2 41"
        ];

        readonly static int part1Result = 6440;
        readonly static int part2Result = 5905;

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Day7.Part1(arrayedTestInput), part1Result);
        }

        [TestMethod]
        public void Part1Reddit()
        {
            Assert.AreEqual(Day7.Part1(arrayedRedditTestCase), 6592);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            Assert.AreEqual(Day7.Part2(arrayedTestInput), part2Result);
        }

        [TestMethod]
        public void Part2Reddit()
        {
            Assert.AreEqual(Day7.Part2(arrayedRedditTestCase), 6839);
        }
    }
}