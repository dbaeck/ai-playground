using System;
using System.Collections.ObjectModel;

namespace AIPlayground.Search.Problem
{
	public abstract class SearchProblem
	{
		public IState InitialState{ get; set;}
		public Heuristic<IState> Heuristic{ get; set;}

		//TODO: check if Inumerable maybe better
		//TODO: decide how to implement blocking hooks for UI (idea: method calls protected expand every time event is received from UI)
		public  abstract ObservableCollection<IState> Expand(IState current);
		public  abstract bool GoalCheck(IState current);

	}
}

