using System;

namespace AIPlayground.Search.Algorithm
{
	/// <summary>
	/// Search event arguments.
	/// </summary>
	public class SearchEventArgs:EventArgs
	{
		public readonly SearchNode Node;

		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.SearchEventArgs"/> class.
		/// </summary>
		/// <param name="node">Node.</param>
		public SearchEventArgs (SearchNode node)
		{
			Node = node;
		}
	}
}

