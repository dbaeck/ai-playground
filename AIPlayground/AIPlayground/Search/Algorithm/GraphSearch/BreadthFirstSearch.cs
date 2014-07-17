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
	/// <summary>
	/// Breadth first search.
	/// </summary>
    public class BreadthFirstSearch : GraphSearch
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.GraphSearch.BreadthFirstSearch"/> class.
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
		/// 	if !x in explored: fringe.enqueue(x.expand), explored.add(x)
		/// </code>
		public override IEnumerable<SearchNode> Search()	//TODO: source? does not correspond to Russel/Norvig
        {
            SearchNode current = null;
            while(Fringe.Any())
            {
                current = Fringe.Dequeue();
                if (Problem.GoalCheck(current.CurrentState)) 
					yield return GoalReached(current);
                if (!ClosedList.Contains(current))
                {
                    Fringe.Enqueue(CreateSearchNode(Problem.Expand(current.CurrentState), current));
                    ClosedList.Add(current);
                }
            }
			SearchFinished();
        }
    }
}
