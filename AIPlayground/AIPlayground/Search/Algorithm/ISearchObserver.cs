using System;

namespace AIPlayground.Search.Algorithm
{
	public interface INotifyOnGenerateNode
	{
		void OnGenerateNode(object sender, SearchEventArgs e);
	}

	public interface INotifyOnGoalReached
	{
		void OnGoalReached(object sender, SearchEventArgs e);
	}

	public interface INotifyOnSearchFinished
	{
		void OnSearchFinished(object sender, SearchEventArgs e);
	}

	public interface INotifyOnSearchSpaceExhausted
	{
		void OnSearchSpaceExhausted(object sender, SearchEventArgs e);
	}

	public interface INotifyOnExpandNode
	{
		void OnExpandNode(object sender, SearchEventArgs e);
	}

	/// <summary>
	/// Interface for SearchObservers
	/// Such are classes, that react on each event the search algorithm provides
	/// </summary>
	public interface ISearchObserver: INotifyOnExpandNode, INotifyOnGenerateNode, INotifyOnGoalReached, INotifyOnSearchFinished, INotifyOnSearchSpaceExhausted
	{

	}

}

