using System;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Examples
{
	public class MapState:IState
	{
		public string Name { get; set; }

		public MapState (string name)
		{
			Name = name;
		}

		protected override bool stateEquals(object obj)
		{
			return ((obj) as MapState).Name == this.Name;
		}

		protected override int getStateHashCode()
		{
			return this.Name.GetHashCode ();
		}

		public override string ToString()
		{
			return Name;
		}

	}
}

