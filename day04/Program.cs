using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Day04
{
    class Program
    {
        static (List<BingoBoard> boards, List<int> bingonumbers) parseInput(string filename) {
            var input = System.IO.File.ReadLines(filename)
                .ToArray();
            
            var bingoNumbers = Array.ConvertAll(input[0].Split(","), int.Parse);
            List<BingoBoard> boards = new List<BingoBoard>();
            
            for(var i = 1; i < input.Length; i+=5)
            {
                if(input[i].Length == 0) i++;
                var buffer = new string[5];
                Array.Copy(input, i, buffer, 0, 5);
                boards.Add(new BingoBoard(buffer));
            }

            return (boards, bingoNumbers.ToList());
            
        }

        public static int Part1(List<BingoBoard> boards, int[] bingonumbers) 
        {
            (int sum, int winindex) bestResult = (0,bingonumbers.Length);
            
            Parallel.ForEach(boards, board =>
            {   
                var boardResult = board.PlayNumbers(bingonumbers);
                if(bestResult.winindex>=boardResult.winIndex) bestResult = boardResult;
                
            });

            return bestResult.sum * bingonumbers[bestResult.winindex];
        }
        public static int Part2(List<BingoBoard> boards, int[] bingonumbers) 
        {
            (int sum, int winindex) bestResult = (0,0);
            
            Parallel.ForEach(boards, board =>
            {   
                var boardResult = board.PlayNumbers(bingonumbers);
                if(bestResult.winindex<boardResult.winIndex) bestResult = boardResult;
                
            });

            return bestResult.sum * bingonumbers[bestResult.winindex];
        }

        static void Main(string[] args)
        {
            var input = parseInput("input.txt");
            List<BingoBoard> boards = input.boards;
            List<int> bingonumbers = input.bingonumbers;


            var part = Environment.GetEnvironmentVariable("part");
            if(part == "Part1") Console.WriteLine(Part1(boards, bingonumbers.ToArray())); else Console.WriteLine(Part2(boards, bingonumbers.ToArray()));
        }
    } 
}
