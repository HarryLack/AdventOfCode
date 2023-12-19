using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day3Tests
{

    [TestClass]
    public class Day03Tests
    {
        readonly static string testInput = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..";

        readonly static string[] arrayedTestInput = [
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        ];

        readonly static int[] allParts = [467, 114, 35, 633, 617, 58, 592, 755, 664, 598];
        readonly static int[] validParts = [467, 35, 633, 617, 592, 755, 664, 598];
        readonly static int part1Result = 4361;

        readonly static int part2Result = 467835;

        [TestMethod]
        public void GetsPartsCorrectly()
        {
            foreach (var part in Day03.FindPartNumbers(arrayedTestInput))
            {
                Console.WriteLine(part.PartID);
                Assert.IsTrue(allParts.Contains(part.PartID));
            }
        }

        [TestMethod]
        public void ValidatesPartsCorrectly()
        {
            var parts = Day03.FindPartNumbers(arrayedTestInput);
            var symbols = Day03.FindSymbols(arrayedTestInput);
            foreach (var part in Day03.FindValidParts(parts, symbols))
            {
                Console.WriteLine(part.PartID);
                Assert.IsTrue(validParts.Contains(part.PartID));
            }
        }

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Day03.Part1(arrayedTestInput), part1Result);
        }

        public void GetsCorrectPart2()
        {
            Assert.AreEqual(Day03.Part2(arrayedTestInput), part2Result);
        }
    }
}