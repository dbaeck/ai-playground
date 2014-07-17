using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem;

namespace AIPlayground.Search.Algorithm.TreeSearch
{
	/// <summary>
	/// Depth first search.
	/// </summary>
    public class DepthFirstSearch:TreeSearch
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.TreeSearch.DepthFirstSearch"/> class.
		/// </summary>
		/// <param name="problem">Problem.</param>
        public DepthFirstSearch(SearchProblem problem) : base(problem)
        {
        }

		/// <summary>
		/// Run this Search Algorithm Instance on the given Problem
		/// </summary>
		/// <code>
		/// 	while fringe not empty:
		/// 		if problem.GoalTest(current = fringe.Pop()) return current
		/// 		fringe.Push(current.expand())
		/// </code>
        public override IEnumerable<SearchNode> Search()
        {
            SearchNode current = null;
            while (Fringe.Any())
            {
                current = Fringe.Pop();
                if (Problem.GoalCheck(current.CurrentState)) 
					yield return GoalReached(current);
                
				Fringe.Push(CreateSearchNode(Problem.Expand(current), current));
            }
			SearchFinished();
        }

        
    }
}
