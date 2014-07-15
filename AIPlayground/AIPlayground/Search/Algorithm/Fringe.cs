using System;
using System.Collections.Generic;
using System.Linq;
using AIPlayground.Search.Algorithm;
using System.Collections;

namespace AIPlayground
{
	public delegate int SortDelegate(SearchNode n1, SearchNode n2);

	public class Fringe : List<SearchNode>
	{
	
		public Fringe ()
		{

		}

		public void SortedInsert(IEnumerable<SearchNode> nodes, IComparer<SearchNode> del){
			foreach (var searchNode in nodes)
				this.Add (searchNode);

			this.Sort (del);
		}

		public void Enqueue(IEnumerable<SearchNode> nodes)
		{
			foreach (var searchNode in nodes)
			{
				this.Add(searchNode);
				//this.Insert((this.Count==0)?0:this.Count,searchNode);
			}
		}

		public SearchNode Dequeue()
		{
			return this.GetAndRemoveFirst();
		}

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

		public SearchNode Pop()
		{
			return GetAndRemoveFirst();
		}

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

