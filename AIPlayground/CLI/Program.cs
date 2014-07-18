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

		static void WaitForInput(object sender, EventArgs e)
		{
			Console.WriteLine ("Press Enter to Continue");
			var line = Console.ReadLine();
		}

		static void Main(string[] args)
		{
			//TODO: Insert Problem here!

			SearchAlgorithm a = new BreadthFirstSearch(new RoadMapProblem("map.json"));
			DotGraphFormatter graph = new DotGraphFormatter (a);
			graph.OnChange += WriteToFile;
			IEnumerable<SearchNode> res = null;
			a.Problem.OnExpand += WaitForInput;
			res = a.Search ();

			Console.WriteLine ("Search finished");

			if(res!=null) 
				Console.WriteLine(string.Join("\n", a.GetGoalPath(res)));
			
			return;

			CLIControl ctrl = new CLIControl (algorithm:AvailableAlgorithm.BreadthFirst);
			ctrl.evaluateArgs (args);
			ctrl.runAlgorithm ();
            //
		}
	}
}
