using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using AIPlayground.Search.Algorithm;

namespace AIPlayground.Search.Algorithm
{


	public abstract class SearchAlgorithm
	{
		public SearchEvent onCreateNode;

        public SearchProblem Problem { get; private set; }
	    protected SearchAlgorithm(SearchProblem problem)
	    {
	        Problem = problem;
            Fringe = new Fringe();
	        var initNode = new SearchNode(Problem.InitialState, null);
            Fringe.Add(initNode);
	    }
		public Fringe Fringe {get;private set;}

		public abstract SearchNode Search();

        protected SearchNode CreateSearchNode(IState current, SearchNode parent)
	    {
			//onCreateNode (new Event (), new EventArgs ());
			return new SearchNode(current,parent);
	    }

        protected IEnumerable<SearchNode> CreateSearchNode(IEnumerable<IState> current, SearchNode parent)
	    {
            return current.Select(state => CreateSearchNode(state,parent));
	    }

	    protected IEnumerable<SearchNode> CreateSearchNode(SearchNode parent, params IState[] current)
	    {
	        return CreateSearchNode(current, parent);
	    }

	}
}

