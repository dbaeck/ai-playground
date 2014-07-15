using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem;

namespace AIPlayground.Search.Algorithm.TreeSearch
{
    public class DepthFirstSearch:TreeSearch
    {
        public DepthFirstSearch(SearchProblem problem) : base(problem)
        {
        }

        public override IEnumerable<SearchNode> Search()
        {
            SearchNode current = null;
            while (Fringe.Any())
            {
                current = Fringe.Pop();
                if (Problem.GoalCheck(current.CurrentState)) 
					yield return GoalReached(current);
                
				Fringe.Push(CreateSearchNode(Problem.Expand(current.CurrentState), current));
            }
			SearchFinished();
        }

        
    }
}
