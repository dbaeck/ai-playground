using System;
using AIPlayground.Search.Algorithm;
using System.Linq;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Algorithm.GraphSearch;
using System.Collections.Generic;

namespace AIPlayground.Search.Algorithm.GraphSearch
{
	/// <summary>
	/// Iterative deepening search.
	/// Depth First Search until a depth limit that is increased with each iteration.
	/// First searches only 1 level, then 2, then 3, ...
	/// Nodes always have to be reexpanded for each iteration
	/// </summary>
	public class IterativeDeepeningSearch:GraphSearch	//TODO: check if that makes even sense for graph search
	{
		private int depthLimit;
		private SearchNode startNode;

		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.GraphSearch.IterativeDeepeningSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
		public IterativeDeepeningSearch (SearchProblem problem):base(problem)
		{
			depthLimit = 0;	//TODO: Parameterize - SearchParams
			startNode = Fringe.First();
		}

		/// <summary>
		/// Run this Search Algorithm Instance on the given Problem
		/// </summary>
		/// 
		public override IEnumerable<SearchNode> Search()
		{

			SearchNode current = null;
			while (true) {
				nextIteration ();
				bool cutoffHappened = false;
				while(Fringe.Any())
				{
					current = Fringe.Pop();
					if (current.Depth <= depthLimit) {
						if (Problem.GoalCheck (current.CurrentState))
							yield return GoalReached(current);
						if (!ClosedList.Contains (current)) {
							Fringe.Push (CreateSearchNode (Problem.Expand (current.CurrentState), current));
							ClosedList.Add (current);
						}
					} else
						cutoffHappened = true;
				}
				//break execusion when Fringe was empty before depth limit reached
				if (!cutoffHappened) {
					SearchFinished ();
					break;
				}
			}
		}

		private void nextIteration()
		{
			Fringe.Clear ();
			Fringe.Add (this.startNode);
			ClosedList.Clear ();
			depthLimit++;
		}
	}
}

