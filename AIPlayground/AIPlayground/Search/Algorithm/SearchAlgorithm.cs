using System;
using System.Collections.ObjectModel;

namespace AIPlayground.Search.Algorithm
{
	public abstract class SearchAlgorithm
	{
		public ObservableCollection<SearchNode> Fringe {get;set;}

		public abstract SearchNode Search();
	}
}

