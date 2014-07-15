using System;

namespace AIPlayground.Search.Algorithm
{
	public class SearchEventArgs:EventArgs
	{
		public readonly SearchNode Node;

		public SearchEventArgs (SearchNode node)
		{
			Node = node;
		}
	}
}

