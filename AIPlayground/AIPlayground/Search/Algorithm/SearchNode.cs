using System;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Algorithm
{
	//TODO: Make implement iCompareable
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

