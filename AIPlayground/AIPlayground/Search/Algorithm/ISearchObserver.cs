using System;

namespace AIPlayground.Search.Algorithm
{
	/// <summary>
	/// Interface for SearchObservers
	/// Such are classes, that react on each event the search algorithm provides
	/// </summary>
	public interface ISearchObserver
	{
		void OnGenerateNode(object sender, SearchEventArgs e);
		void OnGoalReached(object sender, SearchEventArgs e);
		void OnSearchFinished(object sender, SearchEventArgs e);
		void OnSearchSpaceExhausted(object sender, SearchEventArgs e);
		void OnExpandNode(object sender, SearchEventArgs e);
	}
}

