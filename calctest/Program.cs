using System;
using GrammarOfArithmetic;

namespace calctest
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser p = new Parser();
            while (true)
            {
                Console.WriteLine(p.SolveEngineer(Console.ReadLine()));
                //Console.WriteLine(p.SolveEngineer(""));
            }
        }
    }
}
