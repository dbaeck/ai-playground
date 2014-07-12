using System;
using System.Collections.ObjectModel;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using System.Collections.Generic;

namespace AIPlayground.Search.Algorithm.GraphSearch
{
	public abstract class GraphSearch:SearchAlgorithm
	{
	    protected GraphSearch(SearchProblem problem) : base(problem)
	    {
			ClosedList = new HashSet<SearchNode>();
	    }

		public HashSet<SearchNode> ClosedList{ get; set;}
	}
}

