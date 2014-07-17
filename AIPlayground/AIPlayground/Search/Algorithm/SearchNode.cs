using System;
using AIPlayground.Search.Problem.State;
using System.Collections.Generic;

namespace AIPlayground.Search.Algorithm
{
	/// <summary>
	/// Search node.
	/// Wrapper for Generated States.
	/// Includes additional information like parent state, node ID, ...
	/// </summary>
	public class SearchNode
	{
		public IState CurrentState {get;set;}
		public SearchNode ParentNode {get;set;}
		public int Generated { get; private set; }
		public int Expanded { get; set; }
		public bool onPathToGoal { get; set; }
		public bool isGoal { get; set; }
		public List<SearchNode> Edges { get; set; }
		public bool ControlNode { get; set; }

	    public int Depth
	    {
	        get
	        {
	            return (ParentNode == null) ? 0 : ParentNode.Depth+1;
	        }
	    }

	    public SearchNode(){}

		/// <summary>
		/// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.SearchNode"/> class.
		/// </summary>
		/// <param name="current">Current.</param>
		/// <param name="parent">Parent.</param>
		/// <param name="generated">Generated.</param>
		public SearchNode(IState current,SearchNode parent, int generated = 0){
			CurrentState = current;
			ParentNode = parent;
			Generated = generated;
			this.Edges = new List<SearchNode> ();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="AIPlayground.Search.Algorithm.SearchNode"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="AIPlayground.Search.Algorithm.SearchNode"/>.</returns>
	    public override string ToString()
	    {
	        return string.Format("Depth: {0} {1}{2}", Depth, Environment.NewLine, CurrentState);
	    }

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="AIPlayground.Search.Algorithm.SearchNode"/>.
		/// Uses the States of the Search Nodes for comparison.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="AIPlayground.Search.Algorithm.SearchNode"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="AIPlayground.Search.Algorithm.SearchNode"/>; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			// If parameter cannot be cast return false.
			SearchNode node = obj as SearchNode;
			if ((System.Object)node == null)
			{
				return false;
			}

			return CurrentState.Equals(node.CurrentState);
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="AIPlayground.Search.Algorithm.SearchNode"/> object.
		/// Uses the HashCode of the Current State
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode()
		{
			return CurrentState.GetHashCode ();
		}

		/// <summary>
		/// ID for a SearchNode. Currently the number (in the order of generation) of this SearchNode.
		/// </summary>
		public int ID()
		{
			return Generated;
		}
	}
}

