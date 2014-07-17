using System;

namespace AIPlayground.Search.Problem.State
{
	/// <summary>
	/// Informed state.
	/// Knows its costs and heuristic distance to the goal.
	/// </summary>
	public abstract class InformedState:IState
	{
		/// <summary>
		/// Gets or sets the H (= heuristic) value.
		/// </summary>
		/// <value>The H value.</value>
		public double HValue {get;set;}

		/// <summary>
		/// Gets the F (= heuristic + costs upto now) value.
		/// </summary>
		/// <value>The F value.</value>
		public double FValue {
			get
			{ 
				return Cost + HValue;
			}
		}
	}
}

