using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day1Tests
{

    [TestClass]
    public class Day1Tests
    {
        readonly static string[] testInput = ["1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"];

        readonly static int[] testResults = [12, 38, 15, 77];

        [TestMethod]
        public void ExtractsCorrectDigits()
        {
            for (int i = 0; i < testInput.Length; i++)
            {
                Assert.AreEqual(Day1.ExtractDigits(testInput[i]), testResults[i]);
            }
        }
    }
}