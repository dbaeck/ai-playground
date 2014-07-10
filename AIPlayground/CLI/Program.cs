using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AIPlayground.Examples;
using AIPlayground.Search.Algorithm;
using AIPlayground.Search.Algorithm.GraphSearch;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using Common;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
             
            

            //TODO: Insert Problem here!

            SearchNode res = null;
            using (new OperationMonitor("sender", "sleep",time))
            {
              

                SearchProblem problem = new MagicSquare(3);
                SearchAlgorithm sa = new BreadthFirstSearch(problem);
                res = sa.Search();

            }
            Console.WriteLine(res);
            Console.In.Read();

            

        }

        private static void time(string result)
        {
            Console.Out.WriteLine(result);
        }
    }
}
