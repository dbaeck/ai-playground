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
        public int[,] CurrentSquare { get; private set;}

        public MagicSquareState(int[,] state)
        {
            CurrentSquare = state;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
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
    }
}
