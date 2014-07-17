﻿using System;

namespace AIPlayground.Search.Problem.State
{
	/// <summary>
	/// Basic Interface for States
	/// </summary>
	public abstract class IState
	{
		public double Cost {get;set;}

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

