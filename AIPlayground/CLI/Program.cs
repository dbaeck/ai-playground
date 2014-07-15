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

		static void Main(string[] args)
		{
			//TODO: Insert Problem here!

			CLIControl ctrl = new CLIControl ();
			ctrl.evaluateArgs (args);
			ctrl.runAlgorithm ();
		}

	}
}
