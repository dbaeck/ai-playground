using System;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Problem.Heuristic
{
	/// <summary>
	/// Interface for heuristics.
	/// </summary>
	public interface IHeuristic<T> where T:IState
	{
		double Calculate(T current, T goal);
	}
}

