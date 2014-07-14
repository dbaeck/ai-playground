using System;
using AIPlayground.Search.Problem;

namespace AIPlayground
{
	public class Grid:SearchProblem
	{
		public char [,] Map {get; set;}
		public Size Size { get; set; }
		public Point Start { get; set; }
		public Point Goal { get; set; }

		public Grid (string filename)
		{
			this.Size = new Size ();
			this.Start = new Point ();
			this.Goal = new Point ();

			string[] lines = System.IO.File.ReadAllLines (filename);
			this.Size.Width = Int32.Parse (lines [0]);
			this.Size.Height = Int32.Parse (lines [1]);

			string[] strStart = lines [this.Size.Height + 2].Split (new Char[]{ ',' });
			string[] strGoal = lines [this.Size.Height + 3].Split (new Char[]{ ',' });

			this.Start.X = Int32.Parse (strStart [0]);
			this.Start.Y = Int32.Parse (strStart [1]);
			this.Goal.X = Int32.Parse (strGoal [0]);
			this.Goal.Y = Int32.Parse (strGoal [1]);

			this.Map = new char[this.Size.Height, this.Size.Width];

			for (var i = 2; i < this.Size.Height + 2; i++)
				for (var j = 0; j < this.Size.Width; j++)
					this.Map [i - 2, j] = lines [i] [j];

			Console.WriteLine (this.ToString ());

			this.InitialState = new GridState (this.Start.X, this.Start.Y, 0);
		}

		public override string ToString()
		{
			string output = "\n";
			for (var i = 0; i < this.Size.Height; i++) {
				for (var j = 0; j < this.Size.Width; j++)
					output += this.Map [i, j] + " ";
				output += "\n";
			}

			return string.Format("[Grid: Map={0}, size={1}, start={2}, goal={3}]", output, Size, Start, Goal);
		}

		public override bool GoalCheck(AIPlayground.Search.Problem.State.IState current)
		{
			var currentPoint = (current as GridState).Coordinates;
			return this.Goal.Equals (currentPoint);
		}

		protected override System.Collections.Generic.IEnumerable<AIPlayground.Search.Problem.State.IState> InternalExpand(AIPlayground.Search.Problem.State.IState current)
		{
			var currentState = (current as GridState);
			var offsets = new int[]{ -1, 0, +1 };

			foreach (var i in offsets)
				foreach (var j in offsets) {
					var newX = currentState.Coordinates.X + i;
					var newY = currentState.Coordinates.Y + j;

					if ((i != 0 || j != 0)  && newX >= 0 && newX < this.Size.Width && newY >= 0 && newY < this.Size.Height)
						yield return new GridState (newX, newY, currentState.Cost + Int32.Parse (""+this.Map [newX, newY]));
				}
		
		}
	}
}

