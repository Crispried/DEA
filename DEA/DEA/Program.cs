using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CenterSpace.NMath.Core;
using CenterSpace.NMath.Analysis;

namespace DEA
{
    class Program
    {
        static void Main(string[] args)
        {



        /*    DoubleVector obj = new DoubleVector(9, 4, 16, 0, 0);

            LinearProgrammingProblem lp = new LinearProgrammingProblem(obj);

            lp.AddLowerBoundConstraint(new DoubleVector(-9, -4, -16, 5, 14), 0);
            lp.AddLowerBoundConstraint(new DoubleVector(-5, -7, -10, 8, 15), 0);
            lp.AddLowerBoundConstraint(new DoubleVector(-4, -9, -13, 7, 12), 0);
            lp.AddEqualityConstraint(new DoubleVector(0, 0, 0, 5, 14), 1);
            for (int i = 0; i < obj.Length; i++)
            {
                lp.AddLowerBound(i, 0.0001);
            }
            for (int i = 0; i < obj.Length; i++)
            {
                lp.AddLowerBound(i, 0.0);
            }*/
            //DoubleVector obj = new DoubleVector(9, 4, 16, 0, 0);

             DoubleVector obj = new DoubleVector(5.0, 7.0, 10.0, 0.0, 0.0);

             LinearProgrammingProblem lp = new LinearProgrammingProblem(obj);

             lp.AddLowerBoundConstraint(new DoubleVector(-9.0, -4.0, -16.0, 5.0, 14.0), 0.0);
             lp.AddLowerBoundConstraint(new DoubleVector(-5.0, -7.0, -10.0, 8.0, 15.0), 0.0);
             lp.AddLowerBoundConstraint(new DoubleVector(-4.0, -9.0, -13.0, 7.0, 12.0), 0.0);
             lp.AddEqualityConstraint(new DoubleVector(0.0, 0.0, 0.0, 8.0, 15.0), 1.0);
             for (int i = 0; i < obj.Length; i++)
             {
                 lp.AddLowerBound(i, 0.0001);
             }

             for (int i = 0; i < obj.Length; i++)
             {
                 lp.AddLowerBound(i, 0.0);
             }

            var solver = new PrimalSimplexSolver();

            solver.Solve(lp);

            var vectorResult = solver.OptimalX;

            


                Console.WriteLine("solution: " + vectorResult);
                Console.WriteLine();
                Console.WriteLine("optimal value: " + solver.OptimalObjectiveFunctionValue);
                Console.WriteLine();
                Console.WriteLine("result: " + solver.Result);







            //Console.WriteLine(res);


        }
    }

}
