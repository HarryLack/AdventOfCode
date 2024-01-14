 using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.dayN
{

    [TestClass]
    public class Tests
    {
        readonly static string testInput = "";
        public readonly static string[] arrayedTestInput = [];

        readonly static int part1Result = 0;
        readonly static int part2Result = 0;

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Main.Part1(arrayedTestInput), part1Result);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            Assert.AreEqual(Main.Part2(arrayedTestInput), part2Result);
        }
    }
}