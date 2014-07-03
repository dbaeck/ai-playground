using System;

namespace AIPlayground.Search.Problem.Heuristic
{
	public interface Heuristic<T> where T:IState
	{
		double calculate(T current, T goal);
	}
}

