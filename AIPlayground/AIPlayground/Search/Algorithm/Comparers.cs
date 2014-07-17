using System;
using AIPlayground.Search.Algorithm;
using System.Collections.Generic;

namespace AIPlayground
{
	/// <summary>
	/// Compare SearchNodes based on State costs.
	/// </summary>
	public class CostComparer : Comparer<SearchNode>  {

		public override int Compare(SearchNode s1, SearchNode s2)
		{
			return s1.CurrentState.Cost.CompareTo (s2.CurrentState.Cost);
		}
	}

	/// <summary>
	/// Compare SearchNodes based on heuristic values.
	/// </summary>
	public class HeuristicComparer : Comparer<SearchNode>  {

		public override int Compare(SearchNode s1, SearchNode s2)
		{
			throw new NotImplementedException ();	//TODO: Implement
		}
	}

	/// <summary>
	/// Compare SearchNodes based on Calculated F-Values.
	/// </summary>
	public class FValueComparer : Comparer<SearchNode>  {

		public override int Compare(SearchNode s1, SearchNode s2)
		{
			throw new NotImplementedException ();	//TODO: Implement
		}
	}
}

