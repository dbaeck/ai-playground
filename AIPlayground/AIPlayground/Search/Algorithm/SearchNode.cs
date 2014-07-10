﻿using System;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Search.Algorithm
{
	//TODO: Make implement iCompareable
	public class SearchNode
	{
		public IState CurrentState {get;set;}
		public SearchNode ParentNode {get;set;}

	    public int Depht
	    {
	        get
	        {
	            return (ParentNode == null) ? 0 : ParentNode.Depht+1;
	        }
	    }

	    public SearchNode(){}

		public SearchNode(IState current,SearchNode parent){
			CurrentState = current;
			ParentNode = parent;
		}

	    public override string ToString()
	    {
	        return string.Format("Depth: {0} {1}{2}", Depht, Environment.NewLine, CurrentState);
	    }
	}
}

