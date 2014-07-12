using System;

namespace AIPlayground.Search.Problem.State
{
	public abstract class UninformedState:IState
	{

		public override bool Equals(object obj)
		{
			return stateEquals(obj);
		}

		public override int GetHashCode()
		{
			return getStateHashCode();
		}

		protected abstract int getStateHashCode();
		protected abstract bool stateEquals(Object obj);
	}
}

