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
	public class BreadthFirstSearch:BiDirectionalSearch
	{
		public BreadthFirstSearch (SearchProblem problem, IState goalState):base(problem,goalState)
		{

		}

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

