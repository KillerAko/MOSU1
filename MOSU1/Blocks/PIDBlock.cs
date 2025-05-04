using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Blocks
{
    public class PIDBlock : BaseBlock
    {
        // Параметри алгоритму:
        // K – пропорційний коефіцієнт
        // ki – використовуємо безпосередньо інтегральну константу, 
        //     при бажанні можна працювати через часову константу Ti (Ti = 1/ki)
        // Td – диференціальний коефіцієнт (час затримки)
        public double K { get; set; } = 1;
        private double ki = 0.000001;
        public double Ki
        {
            get { return ki; }
            set { ki = value; }
        }
        public double Td { get; set; } = 0;

        // Параметри насичення вихідного сигналу
        public double UpLimit { get; set; } = 100;
        public double DownLimit { get; set; } = 0;

        // Режим ручного управління
        public bool ManualMode { get; set; } = false;
        // Значення виходу, яке задається вручну
        public double Umanual { get; set; }

        // Поточний вихід блоку
        public double U { get; set; }

        // Дискретний крок інтегрування
        private double dt;
        // Інтегральна сума (накопичення інтегрального члену)
        private double intSum = 0;
        // Попереднє значення (попередня помилка) для обчислення D-складової
        private double prevError = 0;
        // Допустима похибка для порівнянь
        private const double Tolerance = 1e-6;

        // Конструктор приймає крок dt
        public PIDBlock(double dt)
        {
            this.dt = dt;
        }
        public void ResetIntegrator(double u, double error)
        {
            if (Math.Abs(Ki) > 1e-6)
            {
                intSum = (u - K * error) / Ki;
            }
            prevError = error;
        }

        // Метод Calc приймає на вхід "помилку" (error = setpoint - measured).
        // Якщо потрібно – можна розширити клас та додати властивість setpoint.
        public override double Calc(double error)
        {
            double pTerm = K * error;
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
    }
}
