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
            int maxSteps = 200;
            int maxResets = 100;

            bool isSolutionFound = false;
            int resetsCount = 0;
            while ((!isSolutionFound) && (resetsCount < maxResets))
            {
                Solver solver = new Solver(n);
                isSolutionFound = solver.Solve(n, maxSteps);
                resetsCount++;
            }

            if (isSolutionFound)
            {
                Console.WriteLine("Success in {0} resets!", resetsCount);
            }
            else
            {
                Console.WriteLine("Failed to find solution in {0} resets!", resetsCount);
            }
        }
    }
}
