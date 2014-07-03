using System;

namespace AIPlayground
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
	}
}

