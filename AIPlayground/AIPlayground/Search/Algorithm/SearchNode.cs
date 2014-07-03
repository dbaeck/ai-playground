using System;

namespace AIPlayground
{

	public class SearchNode
	{
		public IState CurrentState {get;set;}
		public IState ParentState {get;set;}
	}
}

