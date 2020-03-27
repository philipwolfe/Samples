using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using SharedLib1;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            for (long i = 0; i < 10; i++)
            {
                Console.WriteLine("Start: {0}  Count: {1}   Step: {2}   Mean: {3}",
                    i, 1000, 2, numbers.CalculateMean(i, 100000000, 2));
            }

            stopWatch.Stop();

            Console.WriteLine("Elapsed Time [hh:mm:sec:msec]: {0}", stopWatch.Elapsed.ToString());

            Console.ReadKey(false);
        }
    }
}
