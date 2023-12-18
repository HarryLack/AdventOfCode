using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day9Tests
{

    [TestClass]
    public class Day9Tests
    {
        readonly static string testInput = "0 3 6 9 12 15\r\n1 3 6 10 15 21\r\n10 13 16 21 30 45";
        readonly static string[] arrayedTestInput = ["0 3 6 9 12 15", "1 3 6 10 15 21", "10 13 16 21 30 45"];

        readonly static int part1Result = 114;
        readonly static int part2Result = 2;

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Day9.Part1(arrayedTestInput), part1Result);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            Assert.AreEqual(Day9.Part2(arrayedTestInput), part2Result);
        }
    }
}