using System;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MOSU1.Blocks;


namespace MOSU1
{
    public partial class Mixer : Form
    {
        private double V = 5.0;      // Об'єм змішувача (м^3)
        private double rho = 10.0;   // Густина рідини (кг/м^3)
        private double G_in1, G_in2, C_in1, C_in2;
        private double concentration;
        private double time = 0;
        private double dt = 0.1;       // Крок часу (сек)
        private System.Windows.Forms.Timer simulationTimer;

        // Використовуємо оновлений PID-регулятор (PIDBlock)
        private PIDBlock pid;
        // Бажане значення концентрації
        private double setpoint; // Add this field to the Mixer class
        //private double measured = 50; // Add this field to the Mixer class

        private bool autoMode = false;  // false – режим ручного керування, true – автоматичний режим

        public Mixer()
        {
            InitializeComponent();

            // Ініціалізація PID-регулятора: передаємо крок dt
            pid = new PIDBlock(0.5, 0.01, 0.01, dt);
           
            pid.UpLimit = 1000.0;
            pid.DownLimit = 0.0;

            // Встановлюємо бажане значення концентрації
            setpoint = 10;

            // Ініціалізація таймера
            simulationTimer = new System.Windows.Forms.Timer();
            simulationTimer.Interval = 1000; // 1 секунда
            simulationTimer.Tick += SimulationStep;

            InitializeSimulation();
        }

        private void InitializeSimulation()
        {
            // Початкові значення потоків та концентрацій
            G_in1 = 1.0;
            G_in2 = 1.0;
            C_in1 = 100;
            C_in2 = 1;
            concentration = (G_in1 * C_in1 + G_in2 * C_in2) / (G_in1 + G_in2);

            chartConcentration.ChartAreas[0].AxisX.Title = "Час (с)";
            chartConcentration.ChartAreas[0].AxisY.Title = "Концентрація (кг/кг)";
            chartConcentration.Series[0].ChartType = SeriesChartType.Line;

            // Відображення початкових значень
            G1textBox.Text = G_in1.ToString("F2");
            G2textBox.Text = G_in2.ToString("F2");
            C1textBox.Text = C_in1.ToString("F2");
            C2textBox.Text = C_in2.ToString("F2");
            SetPointBox.Text = setpoint.ToString("F2");
        }

        private void SimulationStep(object sender, EventArgs e)
        {
            // Обчислення поточної помилки
            double error = setpoint - concentration;

            // Якщо автоматичний режим, PID-регулятор коригує G_in1
            if (autoMode)
            {
                double u_pid = pid.Calc(error);
                G_in1 = u_pid;
                G1textBox.Text = G_in1.ToString("F2");
            }

            // Обчислення зміни концентрації за диференційним рівнянням
            double dC_dt = (G_in1 * C_in1 + G_in2 * C_in2 - (G_in1 + G_in2) * concentration) / (rho * V);
            concentration += dC_dt * dt;
            C_Out_Box.Text = concentration.ToString("F2");

            time += dt;
            chartConcentration.Series[0].Points.AddXY(time, concentration);
        }

        // Перемикання між автоматичним та ручним режимами
        private void ModeSwitchButton_Click(object sender, EventArgs e)
        {
            autoMode = !autoMode;

            if (autoMode)
            {
                // Обчислюємо поточну помилку
                double error = setpoint - concentration;
                // Скидання інтегральної частини для безударного переходу
                pid.ResetIntegrator(G_in1, error);
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
            setpoint += 0.1; // Use the local setpoint field
            SetPointBox.Text = setpoint.ToString("F2");
        }
        private void CpMinesButton_Click(object sender, EventArgs e)
        {
            setpoint -= 0.1; // Use the local setpoint field
            SetPointBox.Text = setpoint.ToString("F2");
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
                setpoint = newValue; // Update the local setpoint field
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


        private void OptimizeButton_Click(object sender, EventArgs e)
        {
            double error = setpoint - concentration;
            pid.OptimizePIDParameters(setpoint, concentration);
            pid.ShowOptimizedParameters();

        }

    }
}
