using System;

namespace AIPlayground.Search.Algorithm
{

	public class SearchNode
	{
		public IState CurrentState {get;set;}
		public IState ParentState {get;set;}

		public SearchNode(){}

		public SearchNode(IState current,IState parent){
			CurrentState = current;
			ParentState = parent;
		}
	}
}

