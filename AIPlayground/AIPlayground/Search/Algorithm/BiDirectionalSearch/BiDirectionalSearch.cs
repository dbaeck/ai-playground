using System;
using System.Collections.ObjectModel;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using System.Collections.Generic;
using System.Linq;

namespace AIPlayground.Search.Algorithm.BiDirectionalSearch
{
	/// <summary>
	/// Bi directional search.
	/// Uses two closed lists and two initial states to search from both directions for a way from start to goal
	/// </summary>
	public abstract class BiDirectionalSearch:SearchAlgorithm
	{
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="AIPlayground.Search.Algorithm.BiDirectionalSearch.BiDirectionalSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
		/// <param name="goalState">Goal state.</param>
		protected BiDirectionalSearch(SearchProblem problem, IState goalState) : base(problem)	// TODO: should need a special SearchProblem with 2 inital states
		{
			ClosedList = new HashSet<SearchNode>();
			BackwardClosedList = new HashSet<SearchNode>();
			BackwardFringe = new Fringe ();
			GoalNode = CreateSearchNode (goalState, null);
			BackwardFringe.Add(GoalNode);
		}

		public Fringe BackwardFringe { get; set;}
		public HashSet<SearchNode> ClosedList{ get; set;}
		public HashSet<SearchNode> BackwardClosedList{ get; set;}
		public SearchNode GoalNode{get; set;}

		/// <summary>
		/// Returns all found goal Paths
		/// The nodes returned by bidirectional search are the nodes that need to be linked together to reach a path from initial state to goal.
		/// </summary>
		/// <returns>The goal path.</returns>
		/// <param name="goal">Goal.</param>
		public override IEnumerable<SearchNode> GetGoalPath(IEnumerable<SearchNode> goal)
		{
			List<SearchNode> l = goal.ToList();

			foreach (var node in GetGoalPath(l[0])) {
				yield return node;
			}
			foreach (var node in GetGoalPath(l[1].ParentNode).Reverse()) {
				yield return node;
			}
		}
	}
}

