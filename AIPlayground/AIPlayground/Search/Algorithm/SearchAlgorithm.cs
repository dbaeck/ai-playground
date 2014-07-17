using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;
using AIPlayground.Search.Algorithm;

namespace AIPlayground.Search.Algorithm
{

	/// <summary>
	/// Search algorithm.
	/// Splits into GraphSearch, TreeSearch, ...
	/// Super Class for all Algorithms
	/// Includes Basic Event Handling and Properties to hold the Problem and the Fringe
	/// </summary>
	public abstract class SearchAlgorithm
	{
		public event EventHandler<SearchEventArgs> OnGenerateNode;
		public event EventHandler<SearchEventArgs> OnGoalReached;
		public event EventHandler<SearchEventArgs> OnSearchFinished;
		public event EventHandler<SearchEventArgs> OnSearchSpaceExhausted;
		public event EventHandler<SearchEventArgs> OnExpandNode;

		public int NodeCount { get; set; }

		public SearchProblem Problem { get; private set; }
		public Fringe Fringe {get;private set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="AIPlayground.Search.Algorithm.SearchAlgorithm"/> class.
		/// Every Search Algorithm needs to run on a specific Search Problem
        /// </summary>
        /// <param name="problem">Problem.</param>
	    protected SearchAlgorithm(SearchProblem problem)
	    {
	        Problem = problem;
			Problem.OnExpand += OnExpandNode;
            Fringe = new Fringe();
			var initNode = new SearchNode(Problem.InitialState, null, NodeCount++);
            Fringe.Add(initNode);
			OnGoalReached += MarkGoalNodes;
	    }

		/// <summary>
		/// Run this Search Algorithm Instance on the given Problem
		/// Needs to be implemented by the specific algorithm
		/// </summary>
		public abstract IEnumerable<SearchNode> Search();


		/// <summary>
		/// Creates a new search node with a given parent.
		/// </summary>
		/// <returns>The search node.</returns>
		/// <param name="current">Current.</param>
		/// <param name="parent">Parent.</param>
        protected SearchNode CreateSearchNode(IState current, SearchNode parent)
	    {
			return OnCreateNodeEvent(new SearchNode (current, parent, NodeCount++));
	    }

		/// <summary>
		/// Creates search nodes for a collection of states with a fixed parent (on expansion)
		/// </summary>
		/// <returns>The search node.</returns>
		/// <param name="current">Current.</param>
		/// <param name="parent">Parent.</param>
        protected IEnumerable<SearchNode> CreateSearchNode(IEnumerable<IState> current, SearchNode parent)
	    {
			return current.Select(state => CreateSearchNode(state,parent));
	    }

		/// <summary>
		/// Creates a new search node for a variable number of states under a fixed parent.
		/// </summary>
		/// <returns>The search node.</returns>
		/// <param name="parent">Parent.</param>
		/// <param name="current">Current.</param>
	    protected IEnumerable<SearchNode> CreateSearchNode(SearchNode parent, params IState[] current)
	    {
			return CreateSearchNode(current, parent);
	    }

		/// <summary>
		/// Returns all found goal Paths
		/// </summary>
		/// <returns>The goal path.</returns>
		/// <param name="goal">Goal.</param>
		public virtual IEnumerable<SearchNode> GetGoalPath(IEnumerable<SearchNode> goal){
			return GetGoalPath(goal.FirstOrDefault());	//TODO: Multiple goal paths/goals
		}

		/// <summary>
		/// Returns the path to a single SearchNode (the goal)
		/// By default, traverses the search tree upwards and yields nodes on the way back down.
		/// Can be overriden to fit specific needs (e.g. bidirectional search)
		/// </summary>
		/// <returns>The goal path.</returns>
		/// <param name="goal">Goal.</param>
		public virtual IEnumerable<SearchNode> GetGoalPath(SearchNode goal){
			if (goal.ParentNode != null)
				foreach (var node in GetGoalPath(goal.ParentNode))
					yield return node;
			yield return goal;
		}


		#region Events

		/// <summary>
		/// Add an observer to this Algorithm
		/// An ISearchObserver must define a method for each possible event
		/// each event gets attached with this methode
		/// </summary>
		/// <param name="observer">Observer.</param>
		public virtual void addObserver(ISearchObserver observer)
		{
			OnGenerateNode += observer.OnGenerateNode;
			OnGoalReached += observer.OnGoalReached;
			OnSearchFinished += observer.OnSearchFinished;
			OnSearchSpaceExhausted += observer.OnSearchSpaceExhausted;
			OnSearchFinished += observer.OnSearchFinished;
		}


		public virtual void addObserver(INotifyOnExpandNode observer)
		{
			OnExpandNode += observer.OnExpandNode;
		}

		public virtual void addObserver(INotifyOnGenerateNode observer)
		{
			OnGenerateNode += observer.OnGenerateNode;
		}

		public virtual void addObserver(INotifyOnGoalReached observer)
		{
			OnGoalReached += observer.OnGoalReached;
		}

		/// <summary>
		/// Raises the generate node event.
		/// </summary>
		/// <param name="node">Node.</param>
		public virtual SearchNode OnCreateNodeEvent(SearchNode node)
		{
			if(OnGenerateNode != null)
				OnGenerateNode (this, new SearchEventArgs(node));
			return node;
		}

		/// <summary>
		/// Raises tht goal reached event.
		/// Also Calls SearchFinished for now.
		/// </summary>
		/// <returns>The reached.</returns>
		/// <param name="node">Node.</param>
		public virtual SearchNode GoalReached(SearchNode node)
		{
			if(OnGoalReached != null)
				OnGoalReached (this, new SearchEventArgs(node));

			SearchFinished (node);	//TODO: Allow resume searching after reaching a goal

			return node;
		}

		/// <summary>
		/// Raises the SearchFinished event
		/// </summary>
		/// <returns>The finished.</returns>
		/// <param name="node">Node.</param>
		public virtual SearchNode SearchFinished(SearchNode node = null)
		{
			if(OnSearchFinished != null)
				OnSearchFinished (this, new SearchEventArgs(node));
			return node;
		}

		/// <summary>
		/// After finding a goal, mark all the nodes on the goal path
		/// Default action for the goal reached event
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void MarkGoalNodes(object sender, SearchEventArgs e)
		{
			var goal = e.Node;
			goal.isGoal = true;
			foreach (var n in GetGoalPath(goal))
				n.onPathToGoal = true;
		}

		#endregion
	}
}

