using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day02Tests
{

    [TestClass]
    public class Day02Tests
    {
        readonly static string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        readonly static string[] arrayedInput = [
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            ];

        readonly static bool[] validityResults = [true, true, false, false, true];

        readonly static int[] powerResults = [48, 12, 1560, 630, 36];

        [TestMethod]
        public void GetsCorrectAnswer()
        {
            int count = 0;
            for (int i = 0; i < arrayedInput.Length; i++)
            {
                Game game = Day02.ParseGame(arrayedInput[i]);
                bool isValid = Day02.IsValidGame(game);

                if (isValid)
                {
                    count += game.Id;
                }
            }
            Assert.AreEqual(count, 8);
        }

        [TestMethod]
        public void ParsesValidGamesCorrectly()
        {
            for (int i = 0; i < arrayedInput.Length; i++)
            {
                Game game = Day02.ParseGame(arrayedInput[i]);
                bool isValid = Day02.IsValidGame(game);
                Assert.AreEqual(isValid, validityResults[i]);
            }
        }

        [TestMethod]
        public void CalculatesPowerCorrectly()
        {
            int count = 0;
            for (int i = 0; i < arrayedInput.Length; i++)
            {
                Game game = Day02.ParseGame(arrayedInput[i]);
                count += Day02.CalcPower(game);
            }
            Assert.AreEqual(count, 2286);
        }
    }
}