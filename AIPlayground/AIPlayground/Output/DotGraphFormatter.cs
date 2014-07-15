using System;
using AIPlayground.Search.Algorithm;
using AIPlayground.Search;
using System.Collections.Generic;

namespace AIPlayground.Output
{
	public class DotGraphFormatter
	{
		public Dictionary<int, SearchNode> Nodes { get; set;}

		public event EventHandler<EventArgs> OnChange;

		public DotGraphFormatter (SearchAlgorithm algorithm)
		{
			this.Nodes = new Dictionary<int, SearchNode> ();
			algorithm.OnCreateNode += NodeCreated;
		}

		public void NodeCreated(object sender, SearchEventArgs e)
		{
			Nodes.Add(e.Node.ID(), e.Node);
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

		private string nodeRepresentation(SearchNode node)
		{
			var output = String.Format ("{0}[label=\"{1}\\n{2}\"];\n", node.ID(), node.ID(), node.CurrentState);
			if(node.ParentNode != null)
				output += String.Format ("{0}->{1};\n",node.ParentNode.ID(), node.ID());
			return output;
		}
	}
}

