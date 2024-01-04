 using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day10Tests
{
    [TestClass]
    public class Tests
    {
        readonly static string testInput = "..F7.\r\n.FJ|.\r\nSJ.L7\r\n|F--J\r\nLJ...";
        readonly public static string[] arrayedTestInput = ["..F7.",".FJ|.","SJ.L7","|F--J","LJ..."];

        readonly static int part1Result = 8;
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