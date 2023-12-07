using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day3Tests
{

    [TestClass]
    public class Day3Tests
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
            //Additional inputs
            "..........",
            "..........",
            "..........",
        ];

        readonly static int[] allParts = [467, 114, 35, 633, 617, 58, 592, 755, 664, 598];
        readonly static int[] validParts = [467, 35, 633, 617, 592, 755, 664, 598];
        readonly static int result = 4361;

        [TestMethod]
        public void GetsPartsCorrectly()
        {
            foreach (var part in Day3.FindPartNumbers(arrayedTestInput))
            {
                Console.WriteLine(part.PartID);
                Assert.IsTrue(allParts.Contains(part.PartID));
            }
        }

        [TestMethod]
        public void ValidatesPartsCorrectly()
        {
            var parts = Day3.FindPartNumbers(arrayedTestInput);
            var symbols = Day3.FindSymbols(arrayedTestInput);
            foreach (var part in Day3.FindValidParts(parts, symbols))
            {
                Console.WriteLine(part.PartID);
                Assert.IsTrue(validParts.Contains(part.PartID));
            }
        }

        [TestMethod]
        public void GetsCorrectAnswer()
        {
            Assert.AreEqual(Day3.Part1(arrayedTestInput), result);
        }
    }
}