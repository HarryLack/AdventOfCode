 using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day10Tests
{

    [TestClass]
    public class Day10Tests
    {
        readonly static string testInput = "";
        readonly static string[] arrayedTestInput = [];

        readonly static int part1Result = 0;
        readonly static int part2Result = 0;

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Day10.Part1(arrayedTestInput), part1Result);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            Assert.AreEqual(Day10.Part2(arrayedTestInput), part2Result);
        }
    }
}