using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOSU1.Blocks
{
    public class PIDBlock : BaseBlock
    {
        private GainBlock _proportional;
        private IntegralBlock _integral;
        private DiffBlock _derivative;
        private double _dt;


        public double Kp { get { return _proportional.Gain; } set { _proportional.Gain = value * 1; } }
        public double Ki { get; set; }
        public double Kd { get; set; }

        public double Td { get; set; } = 0;

        // Параметри насичення вихідного сигналу
        public double UpLimit { get; set; } = 1000;
        public double DownLimit { get; set; } = 0;

        // Режим ручного управління
        public bool ManualMode { get; set; } = false;
        
        public double Umanual { get; set; }

        // Поточний вихід блоку
        public double U { get; set; }

        // Дискретний крок інтегрування
        private double dt =0.1;
        // Інтегральна сума (накопичення інтегрального члену)
        private double intSum = 0;
        // Попереднє значення (попередня помилка) для обчислення D-складової
        private double prevError = 0;
        // Допустима похибка для порівнянь
        private const double Tolerance = 1e-6;

        // Конструктор приймає крок dt
        public PIDBlock(double kp, double ki, double kd, double dt)
        {
            _proportional = new GainBlock(kp);
            _integral = new IntegralBlock(dt);
            _derivative = new DiffBlock(dt);

            Kp = kp;
            Ki = ki;
            Kd = kd;
            _dt = dt;
        }
        public void ResetIntegrator(double u, double error)
        {
            if (Math.Abs(Ki) > 1e-6)
            {
                intSum = (u - Kp * error) / Ki;
            }
            prevError = error;
        }

        // Метод Calc приймає на вхід "помилку" (error = setpoint - measured).
        public override double Calc(double error)
        {
            double pTerm = Kp * error;
            double dTerm = Td * (error - prevError) / dt;

            // Режим ручного управління: ініціалізуємо інтегратор так,
            // щоб U = Umanual
            if (ManualMode)
            {
                // Розраховуємо інтегральну суму для заданого Umanual:
                // Umanual = pTerm + Ki * intSum + dTerm   =>   intSum = (Umanual - pTerm - dTerm) / Ki;
                if (Math.Abs(Ki) > Tolerance)
                {
                    intSum = (Umanual - pTerm - dTerm) / Ki;
                }
                else
                {
                    intSum = 0;
                }
            }
            else
            {
                // Оновлення інтегральної суми методом трапеції
                // Використовуємо prevError (попередня помилка) та поточну error
                intSum += (prevError + error) * dt / 2;
            }

            // Розрахунок необмеженого керуючого сигналу
            double uUnclamped = pTerm + Ki * intSum + dTerm;

            // Обмеження сигналу згідно з насиченням
            double uClamped = uUnclamped;
            bool limited = false;
            if (uClamped > UpLimit)
            {
                uClamped = UpLimit;
                limited = true;
            }
            if (uClamped < DownLimit)
            {
                uClamped = DownLimit;
                limited = true;
            }

            // Якщо відбулось насичення, перераховуємо інтегральну суму для корекції анти-windup
            if (Math.Abs(Ki) > Tolerance && limited)
            {
                intSum = (uClamped - pTerm - dTerm) / Ki;
            }

            U = uClamped;
            prevError = error;
            return U;

        }

        
            // Add this method to PIDBlock (outside GauseMethod class)
            public void OptimizePIDParameters(double setpoint, double measured, int maxIterations = 1000, double tolerance = 1e-6)
            {
            // Use 'this' to reference the instance fields K, Ki, and Td  
            double[] u = { this.Kp, this.Ki, this.Td };
            GaussZeidelMethodPID(this, u, setpoint, measured, maxIterations, tolerance);
                this.Kp = u[0];
            
                this.Ki = u[1];
                this.Td = u[2];
            }

            // Add these methods to GauseMethod (make them public static)
            public static void GaussZeidelMethodPID(PIDBlock pid, double[] u, double setpoint, double measured, int maxIterations, double tolerance)
            {
                for (int iter = 0; iter < maxIterations; iter++)
                {
                double[] prevU = (double[])u.Clone();

                    for (int i = 0; i < u.Length; i++)
                    {
                        double uNew = LineSearchPID(pid, u, i, setpoint, measured);
                        u[i] = Math.Max(uNew, 0.000001); // PID params should be positive
                    }

                    if (IsConverged(u, prevU, tolerance))
                        return;
                }
            }

            static double LineSearchPID(PIDBlock pid, double[] u, int variableIndex, double setpoint, double measured)
            {
            double step = 0.1; 
                double bestValue = PIDObjective(pid, u, setpoint, measured);
                double bestPoint = u[variableIndex];

                double[] candidate = (double[])u.Clone();
                candidate[variableIndex] = u[variableIndex] - step;
                double newValue = PIDObjective(pid, candidate, setpoint, measured);
                if (newValue < bestValue)
                {
                    bestValue = newValue;
                    bestPoint = candidate[variableIndex];
                }

                candidate = (double[])u.Clone();
                candidate[variableIndex] = u[variableIndex] + step;
                newValue = PIDObjective(pid, candidate, setpoint, measured);
                if (newValue < bestValue)
                {
                    bestValue = newValue;
                    bestPoint = candidate[variableIndex];
                }

                return bestPoint;
            }

            static double PIDObjective(PIDBlock pid, double[] parameters, double setpoint, double measured)
            {
                // Save old values
                double oldK = pid.Kp, oldKi = pid.Ki, oldTd = pid.Td;
                // Set new parameters
                pid.Kp = parameters[0];
                pid.Ki = parameters[1];
                pid.Td = parameters[2];

                // Simulate a simple step response for N steps
                double errorSum = 0;
                double processValue = measured;
                pid.intSum = 0;
                pid.prevError = 0;
                for (int t = 0; t < 10; t++)
                {
                    double error = setpoint - processValue;
                    double control = pid.Calc(error);
                    // Simple process model: processValue += control * 0.1 (arbitrary)
                    processValue += control * 0.1;
                    errorSum += Math.Abs(error);
                }

                // Restore old values
                pid.Kp = oldK; 
                pid.Ki = oldKi; 
                pid.Td = oldTd;
                return errorSum;
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
       

        public void ShowOptimizedParameters()
        {
            string message = $"Оптимальні параметри ПІД регулятора:\nK = {Kp}\nKi = {Ki}\nTd = {Td}";
            MessageBox.Show(message, "PID Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetManualOutput(double manualOutput, double error)
        {
            // Для безударного переходу з ручного в автоматичний режим
            _integral.Reset();
            _integral.Calc((manualOutput / Kp) - error - (Kd * _derivative.Calc(error)));
        }

    }
}
