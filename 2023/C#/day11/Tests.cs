using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.day11
{
    [TestClass]
    public class Tests
    {
        readonly static string testInput = "...#......\r\n.......#..\r\n#.........\r\n..........\r\n......#...\r\n.#........\r\n.........#\r\n..........\r\n.......#..\r\n#...#.....";
        public readonly static string[] arrayedTestInput = [
            "...#......",
            ".......#..",
            "#.........",
            "..........",
            "......#...",
            ".#........",
            ".........#",
            "..........",
            ".......#..",
            "#...#....."
        ];
        readonly static string[] part1ExpandedInput = [
            "....#........",
            ".........#...",
            "#............",
            ".............",
            ".............",
            "........#....",
            ".#...........",
            "............#",
            ".............",
            ".............",
            ".........#...",
            "#....#......."
        ];

        readonly static int part1Result = 374;
        readonly static (int ratio, int result)[] part2 = [(10, 1030), (100, 8410)];

        [TestMethod]
        public void ExpandsCorrectly()
        {
            var result = Main.ExpandInput(arrayedTestInput);
            CollectionAssert.AreEquivalent(result, part1ExpandedInput);
        }

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Main.Part1(arrayedTestInput), part1Result);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            for (int i = 0; i < part2.Length; i++)
            {
                Assert.AreEqual(Main.Part2(arrayedTestInput, part2[i].ratio), part2[i].result);
            }
        }
    }
}