using System;
using System.Collections.ObjectModel;

namespace AIPlayground.Search.Algorithm
{
	public abstract class GraphSearch:SearchAlgorithm
	{	
		public ObservableCollection<SearchNode> ClosedList{ get; set;}
	}
}

