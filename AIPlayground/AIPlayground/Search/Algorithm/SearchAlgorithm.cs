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
		public event EventHandler<SearchEventArgs> OnCreateNode;
		public int NodeCount { get; set; }

        public SearchProblem Problem { get; private set; }
	    protected SearchAlgorithm(SearchProblem problem)
	    {
	        Problem = problem;
            Fringe = new Fringe();
			var initNode = new SearchNode(Problem.InitialState, null, NodeCount++);
            Fringe.Add(initNode);
	    }
		public Fringe Fringe {get;private set;}

		public abstract SearchNode Search();

		public virtual SearchNode OnCreateNodeEvent(SearchNode node)
		{
			if(OnCreateNode != null)
				OnCreateNode (this, new SearchEventArgs(node));
			return node;
		}

        protected SearchNode CreateSearchNode(IState current, SearchNode parent)
	    {
			return OnCreateNodeEvent(new SearchNode (current, parent, NodeCount++));
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

