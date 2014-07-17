using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem;

namespace AIPlayground.Search.Algorithm.GraphSearch
{
	/// <summary>
	/// Depth first search.
	/// </summary>
    public class DepthFirstSearch:GraphSearch
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.GraphSearch.DepthFirstSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
        public DepthFirstSearch(SearchProblem problem) : base(problem)
        {
        }

		/// <summary>
		/// Run this Search Algorithm Instance on the given Problem
		/// </summary>
		/// <code>
		/// while fringe not empty:
		/// 	current = fringe.pop()
		/// 	if problem.GoalTest(current) return current
		/// 	if current not explored: fringe.Push(current.expand()), explored.add(current)
		/// </code>
        public override IEnumerable<SearchNode> Search()
        {
            SearchNode current = null;
            while (Fringe.Any())
            {
                current = Fringe.Pop();
                if (Problem.GoalCheck(current.CurrentState)) 
					yield return GoalReached(current);
                if (!ClosedList.Contains(current))
                {
                    Fringe.Push(CreateSearchNode(Problem.Expand(current), current));
					ClosedList.Add(current);
                }
            }
			SearchFinished();
        }

        
    }
}
