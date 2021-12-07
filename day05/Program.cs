using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Day04
{
    class Program
    {
         
        private record Line((int,int) start, (int,int) end);
        private static int[,] board = new int[5,5];

        private static void printBoard()
        {
            for(int y = 0; y<board.GetLength(1); y++)
            {
                for(int x = 0; x<board.GetLength(0); x++)
                {
                    Console.Write(board[x,y]);
                }   
                Console.WriteLine();
            }
        }
        static List<Line> parseInput(string filename) {
            List<Line> input = System.IO.File.ReadLines(filename)
                .Select(line => new Line(
                    (int.Parse(line.Split(" -> ")[0].Split(",")[0]),int.Parse(line.Split(" -> ")[0].Split(",")[1])), 
                    (int.Parse(line.Split(" -> ")[1].Split(",")[0]),int.Parse(line.Split(" -> ")[1].Split(",")[1]))
                    )).ToList();
            
            board = new int [input.Max(x=>Math.Max(x.start.Item1, x.end.Item1) + 1), input.Max(x=>Math.Max(x.start.Item2, x.end.Item2) + 1)];

            return input;
        }

        static string Part1(List<Line> lines, bool ignoreDiagonals = true)
        {
            int overlapping = 0;
            foreach(var line in lines) 
            {
                (int,int) slope = (line.end.Item1 - line.start.Item1, line.end.Item2 - line.start.Item2);
                (int,int) point = line.start;
                if(ignoreDiagonals && slope.Item1 != 0 && slope.Item2 != 0) continue; 

                while (point != line.end) 
                {
                    board[point.Item1,point.Item2] += 1;
                    if(board[point.Item1,point.Item2] == 2) 
                    {
                        overlapping++;
                    }

                    if(slope.Item1 > 0) point.Item1 += 1;
                    else if (slope.Item1 < 0) point.Item1 -= 1;
                    
                    if (slope.Item2 > 0) point.Item2 += 1;
                    else if (slope.Item2 < 0) point.Item2 -= 1;
                }
                board[line.end.Item1,line.end.Item2] += 1;
                if(board[point.Item1,point.Item2] == 2) 
                    {
                        overlapping++;
                    }
            }

            return overlapping.ToString();
        }
        static string Part2(List<Line> lines)
        {
            return "";
        }
        
        static void Main(string[] args)
        {
            var input = parseInput("input.txt");

            if(Environment.GetEnvironmentVariable("part") == "Part1") 
            Console.WriteLine(Part1(input));
            else Console.WriteLine(Part1(input, false));
        }
    } 
}
