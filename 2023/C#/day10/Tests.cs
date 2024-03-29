using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day10Tests
{
    [TestClass]
    public class Tests
    {
        readonly static string testInput = "..F7.\r\n.FJ|.\r\nSJ.L7\r\n|F--J\r\nLJ...";
        readonly public static string[] arrayedTestInput = ["..F7.", ".FJ|.", "SJ.L7", "|F--J", "LJ..."];

        readonly static string[][] part2TestInputs = [
            [
                "...........",
                ".S-------7.",
                ".|F-----7|.",
                ".||.....||.",
                ".||.....||.",
                ".|L-7.F-J|.",
                ".|..|.|..|.",
                ".L--J.L--J.",
                "..........."
            ],
            [
                "..........",
                ".S------7.",
                ".|F----7|.",
                ".||....||.",
                ".||....||.",
                ".|L-7F-J|.",
                ".|..||..|.",
                ".L--JL--J.",
                ".........."
            ],
            [
                ".F----7F7F7F7F-7....",
                ".|F--7||||||||FJ....",
                ".||.FJ||||||||L7....",
                "FJL7L7LJLJ||LJ.L-7..",
                "L--J.L7...LJS7F-7L7.",
                "....F-J..F7FJ|L7L7L7",
                "....L7.F7||L7|.L7L7|",
                ".....|FJLJ|FJ|F7|.LJ",
                "....FJL-7.||.||||...",
                "....L---J.LJ.LJLJ..."
            ],
            [
                "FF7FSF7F7F7F7F7F---7",
                "L|LJ||||||||||||F--J",
                "FL-7LJLJ||||||LJL-77",
                "F--JF--7||LJLJ7F7FJ-",
                "L---JF-JLJ.||-FJLJJ7",
                "|F|F-JF---7F7-L7L|7|",
                "|FFJF7L7F-JF7|JL---7",
                "7-L-JL7||F7|L7F-7F7|",
                "L.L7LFJ|||||FJL7||LJ",
                "L7JLJL-JLJLJL--JLJ.L"
             ]
        ];


        readonly static int part1Result = 8;
        readonly static int[] part2Results = [4, 4, 8, 10];

        [TestMethod]
        public void GetsCorrectPart1()
        {
            Assert.AreEqual(Day10.Part1(arrayedTestInput), part1Result);
        }

        [TestMethod]
        public void GetsCorrectPart2()
        {
            for (int i = 0; i < part2TestInputs.Length; i++)
            {
                Assert.AreEqual(Day10.Part2(part2TestInputs[i]), part2Results[i]);
            }

        }
    }
}