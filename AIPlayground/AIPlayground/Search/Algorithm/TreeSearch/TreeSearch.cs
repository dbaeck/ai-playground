using System;
using System.Collections.ObjectModel;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using System.Collections.Generic;

namespace AIPlayground.Search.Algorithm.TreeSearch
{
	/// <summary>
	/// Tree search.
	/// </summary>
	public abstract class TreeSearch:SearchAlgorithm
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.TreeSearch.TreeSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
		protected TreeSearch(SearchProblem problem) : base(problem)
	    {
	    }
	}
}

