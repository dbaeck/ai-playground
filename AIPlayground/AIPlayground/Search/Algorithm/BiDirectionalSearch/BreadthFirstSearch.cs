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
			while (BackwardFringe.Any() && Fringe.Any ()) {

				//start->goal direction
				SearchNode current = Fringe.Dequeue();
				if (/*Problem.GoalCheck (current) || */BackwardFringe.Contains (current)) 
				{
					yield return current;
					yield return GoalReached(BackwardFringe.Find (x => x.Equals (current)));
					break;
				}
				if (!ClosedList.Contains(current))
				{
					Fringe.Enqueue(CreateSearchNode(Problem.Expand(current.CurrentState), current));
					ClosedList.Add(current);
				}

				//goal->start direction
				SearchNode currentReverse = BackwardFringe.Dequeue();
				if (/*Problem.InitialState.Equals (currentReverse) ||*/ Fringe.Contains (currentReverse)) 
				{
					yield return Fringe.Find (x => x.Equals (currentReverse));
					yield return GoalReached(currentReverse);
					break;
				}
				if (!BackwardClosedList.Contains(currentReverse))
				{
					BackwardFringe.Enqueue(CreateSearchNode(Problem.Expand(currentReverse.CurrentState), currentReverse));
					BackwardClosedList.Add(currentReverse);
				}
			}

			SearchFinished ();
		}

			
	}
}

