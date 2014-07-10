using System;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Problem.Heuristic
{
	public interface IHeuristic<T> where T:IState
	{
		double Calculate(T current, T goal);
	}
}

