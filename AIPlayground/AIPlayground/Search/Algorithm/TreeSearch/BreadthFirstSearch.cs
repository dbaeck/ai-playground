using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Algorithm.TreeSearch
{
	/// <summary>
	/// Breadth first search.
	/// </summary>
	public class BreadthFirstSearch : TreeSearch
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.TreeSearch.BreadthFirstSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
        public BreadthFirstSearch(SearchProblem problem) : base(problem)
        {

        }

		/// <summary>
		/// Run this Search Algorithm Instance on the given Problem
		/// </summary>
		/// <code>
		/// while fringe not empty:
		/// 	if problem.GoalTest(x = fringe.dequeue()) return x;
		/// 	fringe.enqueue(x.expand)
		/// </code>
		public override IEnumerable<SearchNode> Search()
        {
            SearchNode current = null;
            while(Fringe.Any())
            {
                current = Fringe.Dequeue();
                if (Problem.GoalCheck(current.CurrentState)) 
					yield return GoalReached(current);
                
                Fringe.Enqueue(CreateSearchNode(Problem.Expand(current.CurrentState), current));
            }
			SearchFinished();
        }
    }
}
