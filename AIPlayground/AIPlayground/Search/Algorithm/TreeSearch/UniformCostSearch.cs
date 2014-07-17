using System;
using AIPlayground.Search.Algorithm;
using System.Linq;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Algorithm.GraphSearch;
using System.Collections.Generic;



namespace AIPlayground.Search.Algorithm.TreeSearch
{
	/// <summary>
	/// Uniform cost search.
	/// </summary>
	public class UniformCostSearch:TreeSearch
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.TreeSearch.UniformCostSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
		public UniformCostSearch (SearchProblem problem):base(problem)
		{
		}

		/// <summary>
		/// Run this Search Algorithm Instance on the given Problem
		/// </summary>
		/// <code>
		/// while fringe not empty:
		/// 	if problem.GoalTest(x = fringe.dequeue()) return x;
		/// 	fringe.sortedInsert(x.expand)	- insert based on costs
		/// </code>
		public override IEnumerable<SearchNode> Search()
		{
			SearchNode current = null;
			while(Fringe.Any())
			{
				current = Fringe.Dequeue();
				if (Problem.GoalCheck(current.CurrentState)) 
					yield return GoalReached(current);

				Fringe.SortedInsert(CreateSearchNode(Problem.Expand(current), current), new CostComparer());
			}
			SearchFinished();
		}
	}
}

