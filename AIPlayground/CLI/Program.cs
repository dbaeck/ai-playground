﻿using System;
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
using AIPlayground.Output;
using Common;
using AIPlayground;

namespace CLI
{
    class Program
    {
		static void WriteToFile(object sender, EventArgs e)
		{
			var w = new System.IO.StreamWriter ("graph.dot");
			w.Write (sender);
			w.Close ();
		}

        static void Main(string[] args)
        {

            //TODO: Insert Problem here!

            SearchNode res = null;
            using (new OperationMonitor("sender", "sleep",time))
            {
              
				Grid problem = new Grid ("../../Examples/2DGrid/ex1.map");

				foreach(var state in problem.Expand (problem.InitialState))
					Console.WriteLine (state);

				SearchAlgorithm sa = new IterativeDeepeningSearch (problem);
				DotGraphFormatter graph = new DotGraphFormatter (sa);
				graph.OnChange += WriteToFile;

				res = sa.Search ();
//                MagicSquare problem = new MagicSquare(3);
//                SearchAlgorithm sa = new DepthFirstSearch(problem);
//                res = sa.Search();
//                Console.WriteLine("c: " + problem.c);

            }
			Console.WriteLine ("Blaaaaaaaa");
            Console.WriteLine(res);
			if(res!=null) printPath (res);
            Console.In.Read();

            

        }

        private static void time(string result)
        {
            Console.Out.WriteLine(result);
        }

		private static void printPath(SearchNode n){
			Console.WriteLine ("Path: {0}", n.getPath());
		}
    }
}
