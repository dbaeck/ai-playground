using System;
using AIPlayground.Search.Problem;
using AIPlayground.Examples;
using AIPlayground.Search.Algorithm.GraphSearch;
using AIPlayground.Search.Algorithm;
using AIPlayground;
using AIPlayground.Output;
using Common;

namespace CLI
{
	public enum ExampleProblem
	{
		Grid,
		MagicSquare
	}

	public enum SearchParadigm
	{
		GraphSearch,
		TreeSearch,
		BidirectionalSearch
	}

	public enum AvailableAlgorithm
	{
		BreadthFirstSearch,
		DepthFirstSearch,
		IterativeDeepeningSearch,
		UniformCostSearch
	}

	public class CLIControl
	{
		public AvailableAlgorithm currentAlgorithm { get; set; }
		public SearchParadigm currentSearchParadigm { get; set; }
		public ExampleProblem currentProblem { get; set; }
		public string parameters { get; set; }


		static System.IO.StreamWriter fileIncremental = new System.IO.StreamWriter ("graph_incremental.dot");

		static void WriteToFile(object sender, EventArgs e)
		{
			var w = new System.IO.StreamWriter ("graph.dot");
			w.Write (sender);
			w.Close ();
		}

		static void WriteToFileIncremental(object sender, EventArgs e)
		{
			fileIncremental.Write ((sender as DotGraphFormatter).nextString ());
		}

		private static void time(string result)
		{
			Console.Out.WriteLine(result);
		}

		private static void printPath(SearchNode n){
			Console.WriteLine(string.Join("\n", n.getPath()));
		}

		public CLIControl (string parameters = "ex1.map", 
			ExampleProblem problem = ExampleProblem.Grid, 
			AvailableAlgorithm algorithm = AvailableAlgorithm.BreadthFirstSearch, 
			SearchParadigm paradigm = SearchParadigm.GraphSearch)
		{
			currentProblem = problem;
			currentAlgorithm = algorithm;
			currentSearchParadigm = paradigm;
			this.parameters = parameters;
		}

		public void evaluateArgs(string [] args)
		{
//			if (args.Length == 0) {
//				this.ListOptions ();
//				return;
//			}

			foreach (var arg in args) {
				var parameters = arg.Split(new char[]{'='});
				var key = parameters [0].Trim (new char[]{' ', '\t', '-', '+'});
				var value = parameters [1].Trim (new char[]{' ', '\t', '-', '+'});
				switch (key) {
				case "help":
					this.ListOptions ();
					break;
				case "problem":
					this.currentProblem = (ExampleProblem)Enum.Parse (typeof(ExampleProblem), value, true);
					break;
				case "algorithm":
					this.currentAlgorithm = (AvailableAlgorithm)Enum.Parse (typeof(AvailableAlgorithm), value, true);
					break;
				case "paradigm":
					this.currentSearchParadigm = (SearchParadigm)Enum.Parse (typeof(SearchParadigm), value, true);
					break;
				case "params":
					this.parameters = value;
					break;
				default:
					this.ListOptions ();
					return;
				}
			}


		}


		public SearchProblem makeProblem(ExampleProblem p, string parameters = null)
		{
			switch (p) {
			case ExampleProblem.Grid:
			default:
				return new Grid(parameters);
			case ExampleProblem.MagicSquare:
				return new MagicSquare (Int32.Parse(parameters));
			}
		}

		public SearchAlgorithm makeAlgorithm(AvailableAlgorithm a, SearchProblem p)
		{
			switch (a) {
			case AvailableAlgorithm.BreadthFirstSearch:
			default:
				return new BreadthFirstSearch (p);
			case AvailableAlgorithm.DepthFirstSearch:
				return new DepthFirstSearch (p);
			case AvailableAlgorithm.IterativeDeepeningSearch:
				return new IterativeDeepeningSearch (p);
			case AvailableAlgorithm.UniformCostSearch:
				return new UniformCostSearch (p);
			}
		}

		public void ListOptions()
		{
			Console.WriteLine ("Available Options:");
			Console.WriteLine ("\t-problem=Grid \t\t\tThe Search Problem to use");
			Console.WriteLine ("\t-algorithm=BreadthFirstSearch \tSearch Algorithm to use");
			Console.WriteLine ("\t-paradigm=GraphSearch \t\tHow to Search");
			Console.WriteLine ("\t-params=ex1.map \t\tAdditional Parameters for the Search Problem");
			Console.WriteLine ();

			Console.WriteLine ("Available Example Problems:");
			foreach (var value in Enum.GetValues(typeof(ExampleProblem)))
				Console.WriteLine("\t{0,3}:  {1}",
					(int) value, ((ExampleProblem) value));

			Console.WriteLine ("Available Search Paradigms:");
			foreach (var value in Enum.GetValues(typeof(SearchParadigm)))
				Console.WriteLine ("\t{0,3}:  {1}",
					(int)value, ((SearchParadigm)value));

			Console.WriteLine ("Available Search Algorithms:");
			foreach (var value in Enum.GetValues(typeof(AvailableAlgorithm)))
				Console.WriteLine("\t{0,3}:  {1}",
					(int) value, ((AvailableAlgorithm) value));
		}

		public void runAlgorithm()
		{
			SearchNode res = null;
			using (new OperationMonitor("sender", "sleep",time))
			{
				SearchAlgorithm a = makeAlgorithm (this.currentAlgorithm, makeProblem (this.currentProblem, this.parameters));
				DotGraphFormatter graph = new DotGraphFormatter (a);
				graph.OnChange += WriteToFileIncremental;
				res = a.Search ();
				a.Search ();
			}

			fileIncremental.Close ();

			Console.WriteLine ("Search finished");
			Console.WriteLine(res);

			if(res!=null) 
				printPath (res);
		}
	}
}

