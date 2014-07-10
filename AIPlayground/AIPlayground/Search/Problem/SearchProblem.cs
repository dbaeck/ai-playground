using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AIPlayground.Search.Algorithm;
using AIPlayground.Search.Problem.State;
using AIPlayground.Search.Problem.Heuristic;

namespace AIPlayground.Search.Problem
{
//    public abstract class SearchProblem
//    {
//        public IEnumerable<IState> Expand(Ista current)
//    }
	public abstract class SearchProblem 
	{


		public IState InitialState{ get; set;}
		public IHeuristic<IState> Heuristic{ get; set;}

		//TODO: check if Inumerable maybe better
		//TODO: decide how to implement blocking hooks for UI (idea: method calls protected expand every time event is received from UI)
	    public IEnumerable<IState> Expand(IState current)
	    {
            //TODO: implement block for UI
	        return InternalExpand(current);
	    }
		public  abstract bool GoalCheck(IState current);
	    protected abstract IEnumerable<IState> InternalExpand(IState current);

        


	}
}

