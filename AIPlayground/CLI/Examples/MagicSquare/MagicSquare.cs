using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Problem;
using AIPlayground.Search.Problem.State;

namespace AIPlayground.Examples
{
    public class MagicSquare:SearchProblem
    {
	
        private int n;
        private int solution;

        public MagicSquare(int n)
        {
            InitialState = new MagicSquareState(new int[n,n]);
            this.n = n;
            solution = (n*(n*n + 1))/2;
        }

        public override bool GoalCheck(IState current)
        {
            var magicCurrent = (MagicSquareState) current;

            if (magicCurrent.GetCurrentNumber() < n * n) return false;
            
            return checkRows(magicCurrent.CurrentSquare);
        }

        private Boolean checkRows(int[,] square)
        {
            
            int sumDiag1 = 0;
            int sumDiag2 = 0;
            for (int i = 0; i < n; i++)
            {
                int sumCols = 0;
                int sumRows = 0;
                for (int j = 0; j < n; j++)
                {
                    sumCols += square[i, j];
                    sumRows += square[j, i];

                    if (i == j) sumDiag1 += square[i, j];
                    if (i + j ==n-1) sumDiag2 += square[i, j];
                }
                if (sumCols != solution || sumRows!= solution) return false;
            }
            if (sumDiag1 != solution || sumDiag2 != solution) return false;
            
            return true;

        }

        protected override IEnumerable<IState> InternalExpand(IState current)
        {
            var magicCurrent = (MagicSquareState)current;

            var currSquare = magicCurrent.CurrentSquare;
            int nextNumber = magicCurrent.GetCurrentNumber() + 1;

           for(int i = 0; i<n;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (currSquare[i,j] == 0)
                    {
                        int[,] newSquare = new int[n, n];
                        Array.Copy(currSquare, newSquare, n * n);
                        newSquare[i, j] = nextNumber;
                        var newState = new MagicSquareState(newSquare);
                        
                        yield return newState;
                    }
                }
                
            }
        }
    }
}