using System;

namespace AIPlayground.Search.Problem.State
{
	public abstract class IState : IComparable
	{

		public double Cost {get;set;}

		public int CompareTo(object obj){
			return 0;
		}
	}
}

