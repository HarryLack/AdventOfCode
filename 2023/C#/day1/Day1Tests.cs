using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day1Tests
{

    [TestClass]
    public class Day1Tests
    {
        readonly static string[] testInputPart1 = ["1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"];

        readonly static int[] testResultsPart1 = [12, 38, 15, 77];

        readonly static string[] testInputPart2 = [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
            ];

        readonly static int[] testResultsPart2 = [29, 83, 13, 24, 42, 14, 76];

        [TestMethod]
        public void ExtractsCorrectDigits()
        {
            for (int i = 0; i < testInputPart1.Length; i++)
            {
                Assert.AreEqual(Day1.ExtractDigits(testInputPart1[i]), testResultsPart1[i]);
            }
        }

        [TestMethod]
        public void ExtractsCorrectNumbers()
        {
            for (int i = 0; i < testInputPart1.Length; i++)
            {
                Assert.AreEqual(Day1.ExtractNumbers(testInputPart2[i]), testResultsPart2[i]);
            }
        }
    }
}