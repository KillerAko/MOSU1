using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOSU1.Optimization
{
    

    public class Criteria
    {
        public static double[] u = { 2.0, 1.0 };
        public static int maxIterations = 1000;
        public static double tolerance = 1e-6;

        public static double ControlSystem(double[] vars)
        {
            double sum = 0;

            return sum;
        }
        public void GaussZeidelMethod(double[] u, int maxIterations, double tolerance)
        {
            // Implementation of the Gauss-Zeidel method goes here.
        }
    }
}
