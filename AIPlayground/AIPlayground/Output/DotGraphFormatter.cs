﻿using System;
using AIPlayground.Search.Algorithm;
using AIPlayground.Search;
using System.Collections.Generic;

namespace AIPlayground.Output
{
	public class DotGraphFormatter:INotifyOnGenerateNode, INotifyOnGoalReached, INotifyOnExpandNode
	{
		public Dictionary<int, SearchNode> Nodes { get; set;}

		public event EventHandler<EventArgs> OnChange;

		private bool fileSetup = true;
		private bool fileClose = false;
		private SearchNode nextNode = null;
		private SearchAlgorithm algorithm;

		public DotGraphFormatter (SearchAlgorithm algorithm)
		{
			this.Nodes = new Dictionary<int, SearchNode> ();
			this.algorithm = algorithm;
			algorithm.addObserver (this as INotifyOnGenerateNode);
			algorithm.addObserver (this as INotifyOnGoalReached);
			algorithm.addObserver (this as INotifyOnExpandNode);
		}

		public void OnExpandNode(object sender, SearchEventArgs e)
		{
			OnChangeEvent ();
		}

		public void OnGenerateNode(object sender, SearchEventArgs e)
		{
			Nodes.Add(e.Node.ID(), e.Node);
			nextNode = e.Node;
			OnChangeEvent ();
		}

		public void OnGoalReached(object sender, SearchEventArgs e)
		{
			this.fileClose = true;
			OnChangeEvent ();
		}
	
		public void OnChangeEvent()
		{
			if (OnChange != null)
				OnChange (this, new EventArgs());
		}

		public override string ToString()
		{
			string output = "digraph SearchGraph\n{";

			foreach (var n in Nodes)
				output += nodeRepresentation (n.Value);

			output += "\n}";

			return output;
		}

		public string nextString()
		{
			string output = "";
			if(this.fileSetup)
				output += "digraph SearchGraph\n{";

			this.fileSetup = false;

			output += nodeRepresentation (this.nextNode);

			if (this.fileClose) 
			{
				foreach (var n in this.algorithm.GetGoalPath(this.nextNode))
					output += nodeRepresentation (n, false);
				output += "\n}";
			}
			return output;

		}

		private string nodeRepresentation(SearchNode node, bool withEdges = true, bool flip = false)
		{
			var style = node.isExpanded ? ", style=bold" : "style=dotted";
			var color = node.isGoal ? ", style=filled, color=lightblue4" : (node.onPathToGoal ? ", style=filled, color=lightblue":"");
			var nodeStyle = style + color;
			var output = String.Format ("{0}[label=\"{1}\\n{2}\" {3}];\n", node.ID(), node.ID(), node.CurrentState, nodeStyle);
			if (node.ParentNode != null) {
				if (flip)
					output += String.Format ("{1}->{0};\n", node.ParentNode.ID (), node.ID ());
				else
					output += String.Format ("{0}->{1};\n", node.ParentNode.ID (), node.ID ());
			}
			foreach(var n in node.Edges)
				output += String.Format ("{1}->{0};\n", node.ID (), n.ID ());
			return output;
		}
	}
}

