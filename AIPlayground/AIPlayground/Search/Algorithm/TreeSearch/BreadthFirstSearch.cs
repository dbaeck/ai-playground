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

	public class BreadthFirstSearch : TreeSearch
    {

        public BreadthFirstSearch(SearchProblem problem) : base(problem)
        {

        }

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
