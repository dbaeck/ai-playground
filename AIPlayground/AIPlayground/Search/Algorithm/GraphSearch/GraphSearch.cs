using System;
using System.Collections.ObjectModel;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using System.Collections.Generic;

namespace AIPlayground.Search.Algorithm.GraphSearch
{
	/// <summary>
	/// Graph search.
	/// Uses a closed list to ensure no node gets visited twice.
	/// </summary>
	public abstract class GraphSearch:SearchAlgorithm
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.GraphSearch.GraphSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
	    protected GraphSearch(SearchProblem problem) : base(problem)
	    {
			ClosedList = new HashSet<SearchNode>();
	    }

		/// <summary>
		/// Gets or sets the closed list.
		/// </summary>
		/// <value>The closed list.</value>
		public HashSet<SearchNode> ClosedList{ get; set;}	//TODO: Probably private
	}
}

