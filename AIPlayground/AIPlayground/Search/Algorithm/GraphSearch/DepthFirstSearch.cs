using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem;

namespace AIPlayground.Search.Algorithm.GraphSearch
{
    public class DepthFirstSearch:GraphSearch
    {
        public DepthFirstSearch(SearchProblem problem) : base(problem)
        {
        }

        public override SearchNode Search()
        {
            SearchNode current = null;
            while (Fringe.Any())
            {

                current = Fringe.Pop();
                if (Problem.GoalCheck(current.CurrentState)) return current;
                if (!ClosedList.Contains(current))
                {
                    Fringe.Push(CreateSearchNode(Problem.Expand(current.CurrentState), current));
					ClosedList.Add(current);
                }
            }
            return null;
        }

        
    }
}
