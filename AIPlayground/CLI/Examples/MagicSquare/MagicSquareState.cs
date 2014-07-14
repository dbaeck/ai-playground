using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Examples
{
    
    public class MagicSquareState:UninformedState
    {	
		public string FieldRepresentation { get; private set;}
        public int[,] CurrentSquare { get; private set;}


        public MagicSquareState(int[,] state)
        {
            CurrentSquare = state;
			FieldRepresentation = getFieldRepresentation();
        }

        public int GetCurrentNumber()
        {
           return CurrentSquare.Cast<int>().Max();
        }

        public override string ToString()
        {
            var res="";
            for (int i = 0; i < CurrentSquare.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentSquare.GetLength(1); j++)
                    res += CurrentSquare[i, j] + " ";
                res += Environment.NewLine;
            }
            return res;
        }

		public override bool Equals(object obj)
		{
			return stateEquals(obj);
		}

		private String getFieldRepresentation(){
			StringBuilder rep = new StringBuilder();
			foreach (var f in CurrentSquare) {
				rep.Append(f);
			}
			return rep.ToString();
		}

		protected override int getStateHashCode(){
			//proposed on stack overflow
			unchecked // Overflow is fine, just wrap
			{
				int hash = 17;
				// Suitable nullity checks etc, of course :)
				hash = hash * 23 + FieldRepresentation.GetHashCode();
				return hash;
			}
		}

		protected override bool stateEquals(System.Object obj)
		{
			if (obj == null)
			{
				return false;
			}
			// If parameter cannot be cast to Point return false.
			MagicSquareState s = obj as MagicSquareState;
			if ((System.Object)s == null)
			{
				return false;
			}

			if(FieldRepresentation.Equals(s.FieldRepresentation))
				return true;

			return false;
		}
    }
}
