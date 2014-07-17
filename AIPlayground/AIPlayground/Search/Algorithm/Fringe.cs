using System;
using System.Collections.Generic;
using System.Linq;
using AIPlayground.Search.Algorithm;
using System.Collections;

namespace AIPlayground
{

	/// <summary>
	/// The Fringe is a List with some extensions to fit the needs of various algorithms.
	/// Such a collection is sometimes called open list or frontier.
	/// Our collection includes possibilities to be used as a stack, queue or sorted list.
	/// </summary>
	public class Fringe : List<SearchNode>
	{
	
		public Fringe ()
		{

		}

		/// <summary>
		/// Insert an element at the position determined by a given IComparer.
		/// </summary>
		/// <param name="nodes">Nodes.</param>
		/// <param name="del">Del.</param>
		public void SortedInsert(IEnumerable<SearchNode> nodes, IComparer<SearchNode> del){
			foreach (var searchNode in nodes)
				this.Add (searchNode);

			this.Sort (del);
		}

		/// <summary>
		/// Enqueue the specified nodes.
		/// </summary>
		/// <param name="nodes">Nodes.</param>
		public void Enqueue(IEnumerable<SearchNode> nodes)
		{
			foreach (var searchNode in nodes)
			{
				this.Add(searchNode);
				//this.Insert((this.Count==0)?0:this.Count,searchNode);
			}
		}

		/// <summary>
		/// Dequeue the first element of the queue.
		/// </summary>
		public SearchNode Dequeue()
		{
			return this.GetAndRemoveFirst();
		}

		/// <summary>
		/// Gets and removes first element of our list (stack behavior).
		/// </summary>
		/// <returns>The and remove first.</returns>
		public SearchNode GetAndRemoveFirst()
		{
			if (this.Any())
			{
				var temp = this.First();
				this.RemoveAt(0);
				return temp;
			}
			return null;
		}

		/// <summary>
		/// Pop the first element of the list (stack behavior).
		/// </summary>
		public SearchNode Pop()
		{
			return GetAndRemoveFirst();
		}

		/// <summary>
		/// Look at the first element of our list without removing it (stack behaviour).
		/// </summary>
		public SearchNode Peek()
		{
			return this.First ();
		}

		/// <summary>
		/// Push the specified nodes on the list (stack behavior).
		/// </summary>
		/// <param name="nodes">Nodes.</param>
		public void Push(IEnumerable<SearchNode> nodes)
		{
			var a = nodes.Reverse();
			foreach (var node in a)
			{
				Insert(0,node);
			}
		}


	}
}

