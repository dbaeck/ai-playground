using System;

namespace AIPlayground.Search.Algorithm
{
	/// <summary>
	/// Search event arguments.
	/// </summary>
	public class SearchEventArgs:EventArgs
	{
		public readonly SearchNode Node;

		public SearchEventArgs (SearchNode node)
		{
			Node = node;
		}
	}
}

