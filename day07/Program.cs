using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Day04
{
    class Program
    {
        
        private static Dictionary<int,int> crabPositions = new Dictionary<int, int>();
        private static Dictionary<int,int> fuelcount = new Dictionary<int, int>();
        static void parseInput(string filename) {
            int i = 0;
            Dictionary<int, int> input = System.IO.File.ReadLines(filename)
                .Select(line => line.Split(",")).First().ToDictionary(s => i++, s=> int.Parse(s));
            
            crabPositions = input.OrderBy(s => s.Value).Select(s => s).ToDictionary(s => s.Key, s=> s.Value); 
        }

        private static int countFuel(int pos)
        {
            if(fuelcount.ContainsKey(pos)) return fuelcount[pos];
            int value = 0;
            foreach(var crab in crabPositions)
            {
                if(Environment.GetEnvironmentVariable("part") == "Part1")
                    value += Math.Abs(pos-crab.Value);  
                else 
                {
                    value += Math.Abs(pos-crab.Value);
                    for(int i = 0; i<Math.Abs(pos-crab.Value); i++)
                    {
                        value += i;  
                    }
                }
            }
            fuelcount.Add(pos, value);
            return value;
        }


        static int Run()
        {
            int middleposition = -1;

            int fuelConsumptionMiddle = -1;
            bool keepcounting = true;
            int newMiddle = middleposition;
            int startPosition = crabPositions.Min(c => c.Value);
            int endPosition = crabPositions.Max(c => c.Value);

            while(keepcounting)
            {
                middleposition = (int)((endPosition + startPosition) / 2);
                fuelConsumptionMiddle = countFuel(middleposition);

                if(fuelConsumptionMiddle <= countFuel(middleposition+1) && fuelConsumptionMiddle <= countFuel(middleposition-1)) return middleposition;

                if(countFuel(middleposition+1) > countFuel(middleposition-1)) 
                {
                    endPosition = middleposition;
                }
                else 
                {
                    startPosition = middleposition;
                }
                
            }
            
            return middleposition;
        }
        
        static void Main(string[] args)
        {
            parseInput("input.txt");
            Console.WriteLine(fuelcount[Run()]);
        }
    } 
}
