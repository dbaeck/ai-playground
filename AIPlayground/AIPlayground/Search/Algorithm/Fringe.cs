using System;
using System.Collections.Generic;
using System.Linq;
using AIPlayground.Search.Algorithm;

namespace AIPlayground
{
	public class Fringe : List<SearchNode>
	{
	
		public delegate int SortDelegate(SearchNode n1, SearchNode n2);

		public Fringe ()
		{

		}

		public int bla(SearchNode s1, SearchNode s2){
			return 0;
		}

		public void SortedInsert(IEnumerable<SearchNode> nodes, SortDelegate del){
			foreach (var searchNode in nodes)
				this.Add (searchNode);

			this.Sort (del);
		}

		public void Enqueue(IEnumerable<SearchNode> nodes)
		{
			foreach (var searchNode in nodes)
			{
				//fringe.Add(searchNode);
				this.Insert((this.Count==0)?0:this.Count-1,searchNode);
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

