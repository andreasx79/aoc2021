using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Day04
{
    class Program
    {
        
        private static List<List<string>> digits = new List<List<string>>();
        
        static void parseInput(string filename) {
            digits = System.IO.File.ReadLines(filename)
                .Select(line => line.Split("|").Last().Split(" ").ToList()).ToList();   
        }

        static int Run1()
        {
            return digits.Sum(ds => ds.Count(d => d.Length == 2 || d.Length == 3 || d.Length == 4 || d.Length == 7));
        }

        static int Run2()
        {
            return 0;
        }
        
        static void Main(string[] args)
        {
            parseInput("input.txt");
            if (Environment.GetEnvironmentVariable("Part") == "Part1")
                Console.WriteLine(Run1());
            else 
                Console.WriteLine(Run2());
        }
    } 
}
