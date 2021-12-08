using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Day04
{
    class Program
    {
         
        private static Dictionary<int, long> school;
        
        static void parseInput(string filename) {
            List<int> input = System.IO.File.ReadLines(filename)
                .Select(line => line.Split(",")).First().Select(s=>int.Parse(s)).ToList();
            school = new Dictionary<int, long>{
                {0, 0}, {1, 0},{2, 0},{3, 0},{5, 0},{4, 0},{6, 0},{7, 0},{8, 0}
            };
            foreach(int i in input) 
            {
                school[i] ++;
            }
        }

        static long Run(int days)
        {
            
            for(int day = 0; day< days; day++)
            {
                Dictionary<int, long> schoolAfterDay = new Dictionary<int, long>{
                    {0, 0}, {1, 0},{2, 0},{3, 0},{4, 0},{5, 0},{6, 0},{7, 0},{8, 0}
                };
                for(int i = 0; i< 9; i++)
                {
                    if(i == 0)
                    {
                        schoolAfterDay[8] += school[i];
                        schoolAfterDay[6] += school[i];
                    }
                    else 
                    {
                        schoolAfterDay[i-1] += school[i];
                    }                    
                }    
                
                school = schoolAfterDay;
            }
            
            return school.Sum(s => s.Value);
        }
        
        static void Main(string[] args)
        {
            parseInput("input.txt");

            if(Environment.GetEnvironmentVariable("part") == "Part1") Console.WriteLine(Run(80));
            else Console.WriteLine(Run(256));
        }
    } 
}
