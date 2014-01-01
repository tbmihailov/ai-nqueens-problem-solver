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
            int n = 8;
            Solver solver = new Solver(n);
            solver.Solve();
        }
    }
}
