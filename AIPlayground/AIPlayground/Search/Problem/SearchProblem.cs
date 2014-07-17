using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AIPlayground.Search.Algorithm;
using AIPlayground.Search.Problem.State;
using AIPlayground.Search.Problem.Heuristic;

namespace AIPlayground.Search.Problem
{
	/// <summary>
	/// Search problem.
	/// Super class for all search problems.
	/// </summary>
	public abstract class SearchProblem 
	{
		/// <summary>
		/// Each Problem needs an inital state for the search to start.
		/// </summary>
		/// <value>The initial state.</value>
		public IState InitialState{ get; set;}

		public event EventHandler<SearchEventArgs> OnExpand;

		/// <summary>
		/// Informed Search problems can have heuristics that determine the next steps.
		/// </summary>
		/// <value>The heuristic.</value>
		public IHeuristic<IState> Heuristic{ get; set;}	//TODO: not all problems have heuristics - class hierarchy

		//TODO: decide how to implement blocking hooks for UI (idea: method calls protected expand every time event is received from UI) - hooks should be in the algorithm
		public IEnumerable<IState> Expand(SearchNode current)
	    {
			current.isExpanded = true;
			if (OnExpand != null)
				OnExpand (this, new SearchEventArgs(current));
			return InternalExpand(current.CurrentState);
	    }

		/// <summary>
		/// Every problem needs a way to check if a state is the goal we want to reach.
		/// </summary>
		/// <returns><c>true</c>, if goal reached, <c>false</c> otherwise.</returns>
		/// <param name="current">Current.</param>
		public  abstract bool GoalCheck(IState current);

		/// <summary>
		/// Expand a given State
		/// Based on one state we want to quickly change the expand function, so it is specific to the problem (e.g. different search problems that are all based on 2D grid states)
		/// </summary>
		/// <returns>The expand.</returns>
		/// <param name="current">Current.</param>
	    protected abstract IEnumerable<IState> InternalExpand(IState current);
	}
}

