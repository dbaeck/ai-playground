using System;
using AIPlayground.Search.Problem.State;

namespace AIPlayground
{
	public class Point
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point (int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public Point() 
		{
		
		}

		public override string ToString()
		{
			return string.Format("[Point: X={0}, Y={1}]", X, Y);
		}

		public override bool Equals(object obj)
		{
			Point other = obj as Point;

			if (other == null)
				return false;

			return (other.X == this.X && other.Y == this.Y);
		}

		public override int GetHashCode()
		{
			return this.ToString ().GetHashCode ();
		}
	}

	public class Size
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public Size()
		{

		}

		public override string ToString()
		{
			return string.Format("[Size: Width={0}, Height={1}]", Width, Height);
		}
	}


	public class GridState:UninformedState
	{
		public Point Coordinates { get; set; }

		public GridState (int x, int y, double costs)
		{
			this.Coordinates = new Point (x,y);
			this.Cost = costs;
		}

		protected override int getStateHashCode()
		{
			return this.Coordinates.GetHashCode ();
		}

		protected override bool stateEquals(Object state)
		{
			var other = state as GridState;
			return other != null && this.Coordinates.Equals (other.Coordinates);
		}

		public override string ToString()
		{
			return string.Format("[GridState: Coordinates={0}, Cost={1}]", Coordinates, Cost);
		}
	}
}

