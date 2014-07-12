using System;

namespace AIPlayground.Search.Problem.State
{
	public abstract class InformedState:IState
	{
		public double Cost {get;set;}
		public double HValue {get;set;}
		public double FValue {
			get
			{ 
				return Cost + HValue;
			}
		}

		public abstract int CompareTo(object obj);

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

