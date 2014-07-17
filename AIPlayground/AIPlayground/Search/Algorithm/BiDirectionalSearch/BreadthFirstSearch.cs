using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Algorithm.BiDirectionalSearch
{
	/// <summary>
	/// Breadth first search.
	/// </summary>
	public class BreadthFirstSearch:BiDirectionalSearch
	{
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="AIPlayground.Search.Algorithm.BiDirectionalSearch.BreadthFirstSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
		/// <param name="goalState">Goal state.</param>
		public BreadthFirstSearch (SearchProblem problem, IState goalState):base(problem,goalState)
		{

		}

		/// <summary>
		/// Run this Search Algorithm Instance on the given Problem
		/// Needs to be implemented by the specific algorithm
		/// </summary>
		public override IEnumerable<SearchNode> Search()
		{
			bool found = false;
			SearchNode current = null;
			SearchNode other = null;

			while (BackwardFringe.Any() && Fringe.Any () && !found) 
			{
				//start->goal direction
				current = Fringe.Dequeue();
				if (/*Problem.GoalCheck (current) || */BackwardFringe.Contains (current)) 
				{
					found = true;
					other = BackwardFringe.Find (x => x.Equals (current));
				}
				if (!ClosedList.Contains(current) && !found)
				{
					Fringe.Enqueue(CreateSearchNode(Problem.Expand(current.CurrentState), current));
					ClosedList.Add(current);
				}

				//goal->start direction
				SearchNode currentReverse = BackwardFringe.Dequeue();
				if (/*Problem.InitialState.Equals (currentReverse) ||*/ Fringe.Contains (currentReverse) && !found) 
				{
					found = true;
					current = currentReverse;
					other = Fringe.Find (x => x.Equals (currentReverse));
				}
				if (!BackwardClosedList.Contains(currentReverse) &&!found)
				{
					BackwardFringe.Enqueue(CreateSearchNode(Problem.Expand(currentReverse.CurrentState), currentReverse));
					BackwardClosedList.Add(currentReverse);
				}

				if(found)
				{
					current.Edges.Add (other);
					yield return GoalReached(current);
					yield return GoalReached(other);
					yield break;
				}
						
			}
	
			SearchFinished ();
		}

			
	}
}

