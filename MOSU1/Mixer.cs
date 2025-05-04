using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MOSU1
{
    public partial class Mixer : Form
    {
        private double V = 5.0; // Об'єм змішувача (м^3)
        private double rho = 10.0; // Густина рідини (кг/м^3)
        private double G_in1, G_in2, C_in1, C_in2;
        private double concentration;
        private double time = 0;
        private double dt = 1; // Крок часу (сек)
        private System.Windows.Forms.Timer simulationTimer;

        // Параметри ПІД-регулятора та бажана концентрація (setpoint)
        private PIDController pid;

        private bool autoMode = false;  // false – режим ручного керування, true – автоматичний режим

        public Mixer()
        {
            InitializeComponent();

            // Ініціалізація ПІД-регулятора:
            // Наприклад, керуємо G_in1 в межах від 0 до 10 (одиниці, наприклад, кг/с)
            pid = new PIDController(kp: 2.0, ki: 0.5, kd: 0.1, outMin: 0.0, outMax: 1000.0);



            // Ініціалізація таймера
            simulationTimer = new System.Windows.Forms.Timer();
            simulationTimer.Interval = 1000; // Оновлення кожні 100 мс
            simulationTimer.Tick += SimulationStep; // Прив'язка обробника подій

            InitializeSimulation();
        }

        private void InitializeSimulation()
        {
            // Початкові значення потоків та концентрацій
            G_in1 = 2.0;
            G_in2 = 2.0;
            C_in1 = 1;
            C_in2 = 1;
            concentration = (G_in1 * C_in1 + G_in2 * C_in2) / (G_in1 + G_in2);

            chartConcentration.ChartAreas[0].AxisX.Title = "Час (с)";
            chartConcentration.ChartAreas[0].AxisY.Title = "Концентрація (кг/кг)";
            chartConcentration.Series[0].ChartType = SeriesChartType.Line;


            // Задання початкового значення setpoint у ПІД-регуляторі
            pid.setpoint = 0.70;


            G1textBox.Text = G_in1.ToString("F2");
            G2textBox.Text = G_in2.ToString("F2");
            C1textBox.Text = C_in1.ToString("F2");
            C2textBox.Text = C_in2.ToString("F2");
            SetPointBox.Text = pid.setpoint.ToString("F2");


        }

        private void SimulationStep(object sender, EventArgs e)
        {

            // Якщо обрано автоматичний режим, ПІД-регулятор коригує G_in1
            if (autoMode)
            {
                double u_pid = pid.Compute(concentration, dt);
                G_in1 = u_pid; // Керуюча дія оновлює G_in1
                G1textBox.Text = G_in1.ToString("F2");
            }


            // Обчислення зміни концентрації за диференційним рівнянням
            double dC_dt = (G_in1 * C_in1 + G_in2 * C_in2 - (G_in1 + G_in2) * concentration) / (rho * V);
            concentration += dC_dt * dt;
            C_Out_Box.Text = concentration.ToString("F2");

            time += dt;

            // Додавання точки на графік
            chartConcentration.Series[0].Points.AddXY(time, concentration);
        }



        // Перемикання між автоматичним та ручним режимами
        private void ModeSwitchButton_Click(object sender, EventArgs e)
        {
            autoMode = !autoMode;

            if (autoMode)
            {
                // При переході з ручного в автоматичний режим забезпечуємо безударне переключення:
                // ініціалізуємо інтегратор, щоб вихід ПІД-регулятора відповідав поточному значенню G_in1.
                double currentError = pid.setpoint - concentration;
                if (pid.Ki != 0)
                {
                    pid.integrator = (G_in1 - pid.Kp * currentError) / pid.Ki;
                }
                pid.previousError = currentError;
                ModeSwitchButton.Text = "Автоматичний режим";
            }
            else
            {
                ModeSwitchButton.Text = "Ручний режим";
            }
        }













        private void StartButton_Click(object sender, EventArgs e)
        {
            simulationTimer.Start();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            simulationTimer.Stop();
        }
        private void G1PlusButton_Click(object sender, EventArgs e)
        {
            G_in1 += 0.1;
            G1textBox.Text = G_in1.ToString("F2");
        }
        private void G1MinesButton_Click(object sender, EventArgs e)
        {
            G_in1 -= 0.1;
            G1textBox.Text = G_in1.ToString("F2");
        }
        private void C1PlusButton_Click(object sender, EventArgs e)
        {
            C_in1 += 0.1;
            C1textBox.Text = C_in1.ToString("F2");
        }
        private void C1MinesButton_Click(object sender, EventArgs e)
        {
            C_in1 -= 0.1;
            C1textBox.Text = C_in1.ToString("F2");
        }
        private void G2PlusButton_Click(object sender, EventArgs e)
        {
            G_in2 += 0.1;
            G2textBox.Text = G_in2.ToString("F2");
        }
        private void G2MinesButton_Click(object sender, EventArgs e)
        {
            G_in2 -= 0.1;
            G2textBox.Text = G_in2.ToString("F2");
        }
        private void C2PlusButton_Click(object sender, EventArgs e)
        {
            C_in2 += 0.1;
            C2textBox.Text = C_in2.ToString("F2");
        }
        private void C2MinesButton_Click(object sender, EventArgs e)
        {
            C_in2 -= 0.1;
            C2textBox.Text = C_in2.ToString("F2");
        }
        private void CpPlucButton_Click(object sender, EventArgs e)
        {
            pid.setpoint += 0.1;
            SetPointBox.Text = pid.setpoint.ToString("F2");
        }
        private void CpMinesButton_Click(object sender, EventArgs e)
        {
            pid.setpoint -= 0.1;
            SetPointBox.Text = pid.setpoint.ToString("F2");
        }


        private void G1textBox_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(G1textBox.Text, out double newValue))
            {
                G_in1 = newValue;
            }
        }
        private void G2textBox_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(G2textBox.Text, out double newValue))
            {
                G_in2 = newValue;
            }
        }
        private void C1textBox_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(C1textBox.Text, out double newValue))
            {
                C_in1 = newValue;
            }
        }
        private void C2textBox_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(C2textBox.Text, out double newValue))
            {
                C_in2 = newValue;
            }
        }
        private void SetPointBox_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(SetPointBox.Text, out double newValue))
            {
                pid.setpoint = newValue;
            }
        }


        private void SpeedX1_Click_1(object sender, EventArgs e)
        {
            simulationTimer.Interval = 1000; // 1 секунда
        }
        private void SpeedX4_Click_1(object sender, EventArgs e)
        {
            simulationTimer.Interval = 250; // 4 рази швидше (0.25 сек)
        }
        private void SpeedX10_Click_1(object sender, EventArgs e)
        {
            simulationTimer.Interval = 100; // 10 разів швидше (0.1 сек)
        }
        private void SpeedX50_Click(object sender, EventArgs e)
        {
            simulationTimer.Interval = 20; // 50 разів швидше (0.02 сек)
        }
        private void SpeedX100_Click(object sender, EventArgs e)
        {
            simulationTimer.Interval = 1; // 100 разів швидше (0.01 сек)
        }





        

    }
}
