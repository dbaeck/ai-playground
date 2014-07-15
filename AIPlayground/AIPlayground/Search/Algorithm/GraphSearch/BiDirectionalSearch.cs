using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Algorithm.GraphSearch
{
	public class BiDirectionalSearch:GraphSearch
	{
		private Fringe goalFringe;
		private HashSet<SearchNode> goalClosedList;
		private SearchNode goalState;

		public BiDirectionalSearch (SearchProblem problem, IState goalState):base(problem)
		{
			goalFringe = new Fringe ();
			goalClosedList = new HashSet<SearchNode> ();
			this.goalState = new SearchNode (goalState, null);
			goalFringe.Add(this.goalState);
		}

		public override SearchNode Search()
		{
			while (goalFringe.Any() && Fringe.Any ()) {

				//start->goal direction
				SearchNode current = Fringe.Dequeue();
				if (/*Problem.GoalCheck (current) || */goalFringe.Contains (current)) 
				{
					//TODO: update parent relationship
					goalFringe.Find (x => x.Equals(current)).ParentNode = current.ParentNode;
					return goalState;
				}
				if (!ClosedList.Contains(current))
				{
					Fringe.Enqueue(CreateSearchNode(Problem.Expand(current.CurrentState), current));
					ClosedList.Add(current);
				}

				//goal->start direction
				SearchNode currentReverse = goalFringe.Dequeue();
				if (/*Problem.InitialState.Equals (currentReverse) ||*/ Fringe.Contains (currentReverse)) 
				{
					currentReverse.ParentNode = Fringe.Find (x => x.Equals(currentReverse)).ParentNode;
					return goalState;
				}
				if (!goalClosedList.Contains(currentReverse))
				{
					goalFringe.Enqueue(CreateSearchNode(Problem.Expand(currentReverse.CurrentState), currentReverse));
					goalClosedList.Add(currentReverse);
				}
			}

			return null;
		}

		private SearchNode constructSolution(SearchNode startHit, SearchNode goalHit){
			
		}
			
	}
}

