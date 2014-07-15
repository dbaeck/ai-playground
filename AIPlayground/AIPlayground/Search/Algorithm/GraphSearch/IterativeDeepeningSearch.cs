using System;
using AIPlayground.Search.Algorithm;
using System.Linq;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Algorithm.GraphSearch;
using System.Collections.Generic;

namespace AIPlayground.Search.Algorithm.GraphSearch
{
	public class IterativeDeepeningSearch:GraphSearch
	{
		private int depthLimit;
		private SearchNode startNode;

		public IterativeDeepeningSearch (SearchProblem problem):base(problem)
		{
			depthLimit = 0;
			startNode = Fringe.First();
		}

		public override SearchNode Search()
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
							return GoalReached(current);
						if (!ClosedList.Contains (current)) {
							Fringe.Push (CreateSearchNode (Problem.Expand (current.CurrentState), current));
							ClosedList.Add (current);
						}
					} else
						cutoffHappened = true;
				}
				//break execusion when Fringe was empty before depth limit reached
				if(!cutoffHappened) return null;
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

