using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MOSU1
{
    public partial class Mixer : Form
    {
        private double V = 3.0; // Об'єм змішувача (м^3)
        private double rho = 1000.0; // Густина рідини (кг/м^3)
        private double G_in1, G_in2, C_in1, C_in2;
        private double concentration;
        private double time = 0;
        private double dt = 1; // Крок часу (сек)
        private System.Windows.Forms.Timer simulationTimer;

        public Mixer()
        {
            InitializeComponent();

            // Ініціалізація таймера
            simulationTimer = new System.Windows.Forms.Timer();
            simulationTimer.Interval = 1000; // Оновлення кожні 100 мс
            simulationTimer.Tick += SimulationStep; // Прив'язка обробника подій

            InitializeSimulation();
        }

        private void InitializeSimulation()
        {
            G_in1 = 2.0;
            G_in2 = 2.0;
            C_in1 = 0.5;
            C_in2 = 0.6;
            concentration = (G_in1 * C_in1 + G_in2 * C_in2) / (G_in1 + G_in2);

            chartConcentration.ChartAreas[0].AxisX.Title = "Час (с)";
            chartConcentration.ChartAreas[0].AxisY.Title = "Концентрація (кг/кг)";
            chartConcentration.Series[0].ChartType = SeriesChartType.Line;
            G1textBox.Text = G_in1.ToString("F2");
            G2textBox.Text = G_in2.ToString("F2");
            C1textBox.Text = C_in1.ToString("F2");
            C2textBox.Text = C_in2.ToString("F2");
        }

        private void SimulationStep(object sender, EventArgs e)
        {
            // Обчислення зміни концентрації за диференційним рівнянням
            double dC_dt = (G_in1 * C_in1 + G_in2 * C_in2 - (G_in1 + G_in2) * concentration) / (rho * V);
            concentration += dC_dt * dt;
            time += dt;

            // Додавання точки на графік
            chartConcentration.Series[0].Points.AddXY(time, concentration);
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
