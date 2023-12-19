using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day4Tests
{

    [TestClass]
    public class Day04Tests
    {
        readonly static string testInput = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\r\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\r\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\r\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\r\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\r\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";

        readonly static string[] arrayedTestInput = [
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        ];

        readonly static int[] allParts = [467, 114, 35, 633, 617, 58, 592, 755, 664, 598];
        readonly static int[] validParts = [467, 35, 633, 617, 592, 755, 664, 598];
        readonly static int part1Result = 13;
        readonly static int part2Result = 30;

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Day04.Part1(arrayedTestInput), part1Result);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            Assert.AreEqual(Day04.Part2(arrayedTestInput), part2Result);
        }
    }
}