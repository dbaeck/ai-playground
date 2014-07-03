using System;

namespace AIPlayground.Search.Problem.State
{
	public abstract class UninformedState:IState
	{
		public abstract int CompareTo(object obj);
	}
}

