using System;
using AIPlayground.Search.Algorithm;
using System.Linq;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Algorithm.GraphSearch;
using System.Collections.Generic;


namespace AIPlayground
{
	public class UniformCostSearch:GraphSearch
	{
		public delegate int compareDelegate(SearchNode n1, SearchNode n2);

		public UniformCostSearch (SearchProblem problem):base(problem)
		{
		}

		public override SearchNode Search()
		{
			SearchNode current = null;
			while(Fringe.Any())
			{
				current = Fringe.Dequeue();
				if (Problem.GoalCheck(current.CurrentState)) return current;
				if (!ClosedList.Contains(current))
				{
					Fringe.SortedInsert(CreateSearchNode(Problem.Expand(current.CurrentState), current), new CostComparer());
					//Fringe.Enqueue(CreateSearchNode(Problem.Expand(current.CurrentState), current));
					ClosedList.Add(current);
				}
			}
			return null;
		}
	}

	public class CostComparer : Comparer<SearchNode>  {

		public override int Compare(SearchNode s1, SearchNode s2)
		{
			return s1.CurrentState.Cost.CompareTo (s2.CurrentState.Cost);
		}
	}
}

