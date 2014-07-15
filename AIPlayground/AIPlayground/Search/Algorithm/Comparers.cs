using System;
using AIPlayground.Search.Algorithm;
using System.Collections.Generic;

namespace AIPlayground
{
	public class CostComparer : Comparer<SearchNode>  {

		public override int Compare(SearchNode s1, SearchNode s2)
		{
			return s1.CurrentState.Cost.CompareTo (s2.CurrentState.Cost);
		}
	}

	public class HeuristicComparer : Comparer<SearchNode>  {

		public override int Compare(SearchNode s1, SearchNode s2)
		{
			return s1.CurrentState.Cost.CompareTo (s2.CurrentState.Cost);
		}
	}

	public class FValueComparer : Comparer<SearchNode>  {

		public override int Compare(SearchNode s1, SearchNode s2)
		{
			return s1.CurrentState.Cost.CompareTo (s2.CurrentState.Cost);
		}
	}
}

