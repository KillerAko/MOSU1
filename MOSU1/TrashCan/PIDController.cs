using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOSU1.TrashCan
{
    // Клас ПІД-регулятора, який враховує компенсацію інтегрального насичення
    public class PIDController
    {
        public double Kp, Ki, Kd;
        public double integrator;
        public double previousError;
        public double output;
        public double outputMin, outputMax;
        public double setpoint;

        public PIDController(double kp, double ki, double kd, double outMin, double outMax)
        {
            Kp = kp;
            Ki = ki;
            Kd = kd;
            outputMin = outMin;
            outputMax = outMax;
            integrator = 0;
            previousError = 0;
            output = 0;
            setpoint = 15;
        }

        // Метод Compute() обчислює вихід регулятора за виміряним значенням і часом інтегрування dt
        public double Compute(double measured, double dt)
        {
            double error = setpoint - measured;
            double derivative = (error - previousError) / dt;
            double newIntegrator = integrator + error * dt;

            // Обчислення необмеженого керуючого сигналу
            double outputUnclamped = -(Kp * error + Ki * newIntegrator + Kd * derivative);
            // Застосування насичення
            double outputClamped = Math.Max(outputMin, Math.Min(outputMax, outputUnclamped));

            // Компенсація інтегрального насичення: оновлюємо інтегратор тільки, якщо сигнал не насичено
            if (outputUnclamped == outputClamped)
            {
                integrator = newIntegrator;
            }

            previousError = error;
            output = outputClamped;
            return outputClamped;
        }
    }
}
