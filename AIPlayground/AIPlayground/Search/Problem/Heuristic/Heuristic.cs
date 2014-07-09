using System;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Problem.Heuristic
{
	public interface Heuristic<T> where T:IState
	{
		double calculate(T current, T goal);
	}
}

