using System;
using AIPlayground.Search.Problem;
using System.Collections.Generic;
using Newtonsoft.Json;
using AIPlayground.Search.Problem.State;
using System.Linq;

namespace AIPlayground.Examples
{

	public class MapJSON
	{
		public string[] Nodes { get; set; }
		public string[,] Edges {get; set; }
	}

	public class Edge
	{
		public MapState From { get; set; }
		public MapState To { get; set; }
		public double Costs { get; set; }

		public Edge (MapState frms, MapState tos, double costs)
		{
			From = frms;
			To = tos;
			Costs = costs;
		}
	}


	/// <summary>
	/// Romanian road map problem.
	/// Map from Russel/Norvig - p68, Figure 3.2
	/// </summary>
	public class RoadMapProblem:SearchProblem
	{
		public MapState GoalState { get; set; }
		public Dictionary<string, MapState> Nodes {get; set; }
		public List<Edge> Edges { get; set; }

		public RoadMapProblem (string filename, string start = "Arad", string goal = "Bucharest")
		{
			string json = System.IO.File.ReadAllText (filename);
			var jsonobj = JsonConvert.DeserializeObject<MapJSON>(json);

			Nodes = new Dictionary<string, MapState> ();
			Edges = new List<Edge> ();

			foreach (var n in jsonobj.Nodes)
				Nodes.Add (n, new MapState (n));

			for(int i = 0; i< jsonobj.Edges.GetLength(0); i++)
			{
				var frm = Nodes [jsonobj.Edges [i,0]];
				var to = Nodes [jsonobj.Edges [i,1]];
				var costs = Double.Parse (jsonobj.Edges [i,2]);
				Edges.Add(new Edge(frm, to, costs));
				Edges.Add(new Edge(to, frm, costs));
			}

			InitialState = Nodes [start];
			GoalState = Nodes [goal];
		}

		public override bool GoalCheck(AIPlayground.Search.Problem.State.IState current)
		{
			return current.Equals (GoalState);
		}

		protected override IEnumerable<IState> InternalExpand(IState current)
		{
			var state = current as MapState;
			foreach (var child in Edges.Where (n => n.From.Equals (state)).OrderBy(n=>n.To.Name))
				yield return child.To;
		}
	}
}

