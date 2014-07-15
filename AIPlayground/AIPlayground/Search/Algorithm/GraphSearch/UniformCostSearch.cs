using System;
using AIPlayground.Search.Algorithm;
using System.Linq;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Algorithm.GraphSearch;



namespace AIPlayground.Search.Algorithm.GraphSearch
{
	public class UniformCostSearch:GraphSearch
	{
		public UniformCostSearch (SearchProblem problem):base(problem)
		{
		}

		public override SearchNode Search()
		{
			SearchNode current = null;
			while(Fringe.Any())
			{
				current = Fringe.Dequeue();
				if (Problem.GoalCheck(current.CurrentState)) 
					return GoalReached(current);
				if (!ClosedList.Contains(current))
				{
					Fringe.SortedInsert(CreateSearchNode(Problem.Expand(current.CurrentState), current), new CostComparer());
					ClosedList.Add(current);
				}
			}
			return null;
		}
	}
}

