using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day6Tests
{

    [TestClass]
    public class Day06Tests
    {
        readonly static string testInput = "Time:      7  15   30\r\nDistance:  9  40  200";
        readonly static string[] arrayedTestInput = [
            "Time:      7  15   30",
            "Distance:  9  40  200"
        ];

        readonly static int part1Result = 288;
        readonly static int part2Result = 71503;

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Day06.Part1(arrayedTestInput), part1Result);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            Assert.AreEqual(Day06.Part2(arrayedTestInput), part2Result);
        }
    }
}