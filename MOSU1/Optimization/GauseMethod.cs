/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOSU1.Optimization
{
    internal class GauseMethod
    {
        static double ComputeFunction(double[] u)
        {
            return 8 * u[0] * u[0] + 4 * u[0] * u[1] + 5 * u[1] * u[1];
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            double[] u = { 2.0, 1.0 };
            int maxIterations = 1000;
            double tolerance = 1e-6;

            GaussZeidelMethod(u, maxIterations, tolerance);

            Console.WriteLine($"Оптимальна точка: u1 = {u[0]:F2}, u2 = {u[1]:F2}");
            Console.WriteLine($"Значення функції: {ComputeFunction(u):F2}");
        }
        static void GaussZeidelMethod(double[] u, int maxIterations, double tolerance)
        {
            for (int iter = 0; iter < maxIterations; iter++)
            {
                double[] prevU = (double[])u.Clone();

                for (int i = 0; i < u.Length; i++)
                {
                    double uNew = LineSearch(u, i);
                    u[i] = Math.Max(uNew, -50);
                }

                if (IsConverged(u, prevU, tolerance))
                {
                    Console.WriteLine($"Збіжність досягнута за {iter} ітераціями.");
                    return;
                }

                Console.WriteLine($"Ітерація {iter + 1}: u1 = {u[0]:F2}, u2 = {u[1]:F2}, Функція: {ComputeFunction(u):F2}");
            }
            Console.WriteLine($"Максимальна кількість ітерацій досягнута.");
        }

        static bool IsConverged(double[] u, double[] prevU, double tolerance)
        {
            for (int i = 0; i < u.Length; i++)
            {
                if (Math.Abs(u[i] - prevU[i]) >= tolerance)
                    return false;
            }
            return true;
        }



        static double LineSearch(double[] u, int variableIndex)
        {
            double step = 0.1;
            double bestValue = ComputeFunction(u);
            double bestPoint = u[variableIndex];

            double[] candidate = (double[])u.Clone();
            candidate[variableIndex] = u[variableIndex] - step;
            double newValue = ComputeFunction(candidate);
            if (newValue < bestValue)
            {
                bestValue = newValue;
                bestPoint = candidate[variableIndex];
            }

            candidate = (double[])u.Clone();
            candidate[variableIndex] = u[variableIndex] + step;
            newValue = ComputeFunction(candidate);
            if (newValue < bestValue)
            {
                bestValue = newValue;
                bestPoint = candidate[variableIndex];
            }

            return bestPoint;
        }
    }
}
*/