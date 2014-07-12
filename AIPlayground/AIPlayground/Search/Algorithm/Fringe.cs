using System;
using System.Collections.Generic;
using System.Linq;
using AIPlayground.Search.Algorithm;

namespace AIPlayground
{
	public class Fringe : List<SearchNode>
	{
		public Fringe ()
		{

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
			if (this.Count != 0)
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

