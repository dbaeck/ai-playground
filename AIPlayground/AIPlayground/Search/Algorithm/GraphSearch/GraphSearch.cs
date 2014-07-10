using System;
using System.Collections.ObjectModel;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Algorithm.GraphSearch
{
	public abstract class GraphSearch:SearchAlgorithm
	{
	    protected GraphSearch(SearchProblem problem) : base(problem)
	    {
            ClosedList = new ObservableCollection<SearchNode>();
	    }

	    public ObservableCollection<SearchNode> ClosedList{ get; set;}
	}
}

