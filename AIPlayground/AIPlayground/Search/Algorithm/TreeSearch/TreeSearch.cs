using System;
using System.Collections.ObjectModel;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using System.Collections.Generic;

namespace AIPlayground.Search.Algorithm.TreeSearch
{
	public abstract class TreeSearch:SearchAlgorithm
	{
		protected TreeSearch(SearchProblem problem) : base(problem)
	    {
	    }
	}
}

