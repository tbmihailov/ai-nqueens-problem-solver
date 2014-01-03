using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.NQueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 16;
            Solver solver = new Solver(n);
            solver.Solve();

            //var board = new Board(n);
            //board.InitFigurePositions();
            //Console.WriteLine(board);
            //Console.WriteLine(string.Format("Collisions:{0}", board.CollisionsCnt));
        }
    }
}
