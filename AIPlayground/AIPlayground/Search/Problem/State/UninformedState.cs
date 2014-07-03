using System;

namespace AIPlayground
{
	public abstract class UninformedState:IState
	{
		public abstract int CompareTo(object obj);
	}
}

