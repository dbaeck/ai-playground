using System;
using System.Collections.ObjectModel;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using System.Collections.Generic;
using System.Linq;

namespace AIPlayground.Search.Algorithm.BiDirectionalSearch{

	public abstract class BiDirectionalSearch:SearchAlgorithm
	{
		protected BiDirectionalSearch(SearchProblem problem, IState goalState) : base(problem)
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

		public override IEnumerable<SearchNode> GetGoalPath(IEnumerable<SearchNode> goal)
		{
			SearchNode forwardNode = goal.ElementAt (0);
			SearchNode backwardNode = goal.ElementAt (1);

			foreach (var node in GetGoalPath(forwardNode)) {
				yield return node;
			}
			foreach (var node in GetGoalPath(backwardNode.ParentNode).Reverse()) {
				yield return node;
			}
		}
	}
}

