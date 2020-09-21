using System;
using System.Collections.Generic;
using System.IO;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.Run();
        }

        static void PrintToFile()
        {
            var pp = MonteCarlo.CalculateAllProbabilities(100);
            using StreamWriter sw = new StreamWriter("results.csv");
            foreach (var (h, r) in pp)
            {
                sw.WriteLine($"{h[0].ToString()}, {h[1].ToString()}, {r},");
            }
        }
    }
}
