
namespace MOSU1
{
    partial class Mixer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mixer));
            chartConcentration = new System.Windows.Forms.DataVisualization.Charting.Chart();
            StartButton = new Button();
            StopButton = new Button();
            pictureBox1 = new PictureBox();
            Timer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            G1textBox = new TextBox();
            G1MinesButton = new Button();
            G1PlusButton = new Button();
            C1PlusButton = new Button();
            C1MinesButton = new Button();
            C1textBox = new TextBox();
            label3 = new Label();
            C2PlusButton = new Button();
            C2MinesButton = new Button();
            C2textBox = new TextBox();
            label4 = new Label();
            G2PlusButton = new Button();
            G2MinesButton = new Button();
            G2textBox = new TextBox();
            label5 = new Label();
            SpeedX1 = new Button();
            SpeedX4 = new Button();
            SpeedX10 = new Button();
            SpeedX50 = new Button();
            SpeedX100 = new Button();
            ModeSwitchButton = new Button();
            SetPointBox = new TextBox();
            label6 = new Label();
            CpMinesButton = new Button();
            CpPlucButton = new Button();
            C_Out_Box = new TextBox();
            label7 = new Label();
            OptimizeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)chartConcentration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // chartConcentration
            // 
            chartConcentration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea2.Name = "ChartArea1";
            chartConcentration.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartConcentration.Legends.Add(legend2);
            chartConcentration.Location = new Point(249, 476);
            chartConcentration.Name = "chartConcentration";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "c(t)";
            chartConcentration.Series.Add(series2);
            chartConcentration.Size = new Size(1905, 842);
            chartConcentration.TabIndex = 0;
            chartConcentration.Text = "chart1";
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StartButton.Location = new Point(43, 1047);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(142, 111);
            StartButton.TabIndex = 1;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StopButton.Location = new Point(43, 1164);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(142, 115);
            StopButton.TabIndex = 2;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1019, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(396, 359);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(63, 41);
            label1.Name = "label1";
            label1.Size = new Size(74, 38);
            label1.TabIndex = 4;
            label1.Text = "Gin1";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(2228, 793);
            label2.Name = "label2";
            label2.Size = new Size(94, 38);
            label2.TabIndex = 5;
            label2.Text = "Speed";
            // 
            // G1textBox
            // 
            G1textBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            G1textBox.Location = new Point(43, 82);
            G1textBox.Name = "G1textBox";
            G1textBox.Size = new Size(119, 45);
            G1textBox.TabIndex = 7;
            G1textBox.Text = "0";
            G1textBox.Leave += G1textBox_Leave;
            // 
            // G1MinesButton
            // 
            G1MinesButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            G1MinesButton.Location = new Point(43, 133);
            G1MinesButton.Name = "G1MinesButton";
            G1MinesButton.Size = new Size(60, 52);
            G1MinesButton.TabIndex = 8;
            G1MinesButton.Text = "-";
            G1MinesButton.UseVisualStyleBackColor = true;
            G1MinesButton.Click += G1MinesButton_Click;
            // 
            // G1PlusButton
            // 
            G1PlusButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            G1PlusButton.Location = new Point(102, 133);
            G1PlusButton.Name = "G1PlusButton";
            G1PlusButton.Size = new Size(60, 52);
            G1PlusButton.TabIndex = 9;
            G1PlusButton.Text = "+";
            G1PlusButton.UseVisualStyleBackColor = true;
            G1PlusButton.Click += G1PlusButton_Click;
            // 
            // C1PlusButton
            // 
            C1PlusButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            C1PlusButton.Location = new Point(308, 133);
            C1PlusButton.Name = "C1PlusButton";
            C1PlusButton.Size = new Size(60, 52);
            C1PlusButton.TabIndex = 13;
            C1PlusButton.Text = "+";
            C1PlusButton.UseVisualStyleBackColor = true;
            C1PlusButton.Click += C1PlusButton_Click;
            // 
            // C1MinesButton
            // 
            C1MinesButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            C1MinesButton.Location = new Point(249, 133);
            C1MinesButton.Name = "C1MinesButton";
            C1MinesButton.Size = new Size(60, 52);
            C1MinesButton.TabIndex = 12;
            C1MinesButton.Text = "-";
            C1MinesButton.UseVisualStyleBackColor = true;
            C1MinesButton.Click += C1MinesButton_Click;
            // 
            // C1textBox
            // 
            C1textBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            C1textBox.Location = new Point(249, 82);
            C1textBox.Name = "C1textBox";
            C1textBox.Size = new Size(119, 45);
            C1textBox.TabIndex = 11;
            C1textBox.Text = "0";
            C1textBox.Leave += C1textBox_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(271, 41);
            label3.Name = "label3";
            label3.Size = new Size(72, 38);
            label3.TabIndex = 10;
            label3.Text = "Cin1";
            // 
            // C2PlusButton
            // 
            C2PlusButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            C2PlusButton.Location = new Point(308, 312);
            C2PlusButton.Name = "C2PlusButton";
            C2PlusButton.Size = new Size(60, 52);
            C2PlusButton.TabIndex = 21;
            C2PlusButton.Text = "+";
            C2PlusButton.UseVisualStyleBackColor = true;
            C2PlusButton.Click += C2PlusButton_Click;
            // 
            // C2MinesButton
            // 
            C2MinesButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            C2MinesButton.Location = new Point(249, 312);
            C2MinesButton.Name = "C2MinesButton";
            C2MinesButton.Size = new Size(60, 52);
            C2MinesButton.TabIndex = 20;
            C2MinesButton.Text = "-";
            C2MinesButton.UseVisualStyleBackColor = true;
            C2MinesButton.Click += C2MinesButton_Click;
            // 
            // C2textBox
            // 
            C2textBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            C2textBox.Location = new Point(249, 261);
            C2textBox.Name = "C2textBox";
            C2textBox.Size = new Size(119, 45);
            C2textBox.TabIndex = 19;
            C2textBox.Text = "0";
            C2textBox.Leave += C2textBox_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(271, 220);
            label4.Name = "label4";
            label4.Size = new Size(72, 38);
            label4.TabIndex = 18;
            label4.Text = "Cin2";
            // 
            // G2PlusButton
            // 
            G2PlusButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            G2PlusButton.Location = new Point(102, 312);
            G2PlusButton.Name = "G2PlusButton";
            G2PlusButton.Size = new Size(60, 52);
            G2PlusButton.TabIndex = 17;
            G2PlusButton.Text = "+";
            G2PlusButton.UseVisualStyleBackColor = true;
            G2PlusButton.Click += G2PlusButton_Click;
            // 
            // G2MinesButton
            // 
            G2MinesButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            G2MinesButton.Location = new Point(43, 312);
            G2MinesButton.Name = "G2MinesButton";
            G2MinesButton.Size = new Size(60, 52);
            G2MinesButton.TabIndex = 16;
            G2MinesButton.Text = "-";
            G2MinesButton.UseVisualStyleBackColor = true;
            G2MinesButton.Click += G2MinesButton_Click;
            // 
            // G2textBox
            // 
            G2textBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            G2textBox.Location = new Point(43, 261);
            G2textBox.Name = "G2textBox";
            G2textBox.Size = new Size(119, 45);
            G2textBox.TabIndex = 15;
            G2textBox.Text = "0";
            G2textBox.Leave += G2textBox_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(63, 220);
            label5.Name = "label5";
            label5.Size = new Size(74, 38);
            label5.TabIndex = 14;
            label5.Text = "Gin2";
            // 
            // SpeedX1
            // 
            SpeedX1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SpeedX1.Location = new Point(2200, 843);
            SpeedX1.Name = "SpeedX1";
            SpeedX1.Size = new Size(139, 69);
            SpeedX1.TabIndex = 22;
            SpeedX1.Text = "X1";
            SpeedX1.UseVisualStyleBackColor = true;
            SpeedX1.Click += SpeedX1_Click_1;
            // 
            // SpeedX4
            // 
            SpeedX4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SpeedX4.Location = new Point(2200, 918);
            SpeedX4.Name = "SpeedX4";
            SpeedX4.Size = new Size(139, 69);
            SpeedX4.TabIndex = 23;
            SpeedX4.Text = "X4";
            SpeedX4.UseVisualStyleBackColor = true;
            SpeedX4.Click += SpeedX4_Click_1;
            // 
            // SpeedX10
            // 
            SpeedX10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SpeedX10.Location = new Point(2200, 993);
            SpeedX10.Name = "SpeedX10";
            SpeedX10.Size = new Size(139, 69);
            SpeedX10.TabIndex = 24;
            SpeedX10.Text = "X10";
            SpeedX10.UseVisualStyleBackColor = true;
            SpeedX10.Click += SpeedX10_Click_1;
            // 
            // SpeedX50
            // 
            SpeedX50.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SpeedX50.Location = new Point(2200, 1068);
            SpeedX50.Name = "SpeedX50";
            SpeedX50.Size = new Size(139, 69);
            SpeedX50.TabIndex = 25;
            SpeedX50.Text = "X50";
            SpeedX50.UseVisualStyleBackColor = true;
            SpeedX50.Click += SpeedX50_Click;
            // 
            // SpeedX100
            // 
            SpeedX100.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SpeedX100.Location = new Point(2200, 1143);
            SpeedX100.Name = "SpeedX100";
            SpeedX100.Size = new Size(139, 69);
            SpeedX100.TabIndex = 26;
            SpeedX100.Text = "X100";
            SpeedX100.UseVisualStyleBackColor = true;
            SpeedX100.Click += SpeedX100_Click;
            // 
            // ModeSwitchButton
            // 
            ModeSwitchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ModeSwitchButton.Location = new Point(2000, 68);
            ModeSwitchButton.Name = "ModeSwitchButton";
            ModeSwitchButton.Size = new Size(302, 80);
            ModeSwitchButton.TabIndex = 27;
            ModeSwitchButton.Text = "Ручний режим";
            ModeSwitchButton.UseVisualStyleBackColor = true;
            ModeSwitchButton.Click += ModeSwitchButton_Click;
            // 
            // SetPointBox
            // 
            SetPointBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SetPointBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SetPointBox.Location = new Point(2148, 154);
            SetPointBox.Name = "SetPointBox";
            SetPointBox.Size = new Size(119, 45);
            SetPointBox.TabIndex = 28;
            SetPointBox.Text = "0.965";
            SetPointBox.Leave += SetPointBox_Leave;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(2009, 154);
            label6.Name = "label6";
            label6.Size = new Size(133, 38);
            label6.TabIndex = 29;
            label6.Text = ": SetPoint";
            // 
            // CpMinesButton
            // 
            CpMinesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CpMinesButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CpMinesButton.Location = new Point(2141, 206);
            CpMinesButton.Name = "CpMinesButton";
            CpMinesButton.Size = new Size(60, 52);
            CpMinesButton.TabIndex = 31;
            CpMinesButton.Text = "-";
            CpMinesButton.UseVisualStyleBackColor = true;
            CpMinesButton.Click += CpMinesButton_Click;
            // 
            // CpPlucButton
            // 
            CpPlucButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CpPlucButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CpPlucButton.Location = new Point(2207, 205);
            CpPlucButton.Name = "CpPlucButton";
            CpPlucButton.Size = new Size(60, 52);
            CpPlucButton.TabIndex = 30;
            CpPlucButton.Text = "+";
            CpPlucButton.UseVisualStyleBackColor = true;
            CpPlucButton.Click += CpPlucButton_Click;
            // 
            // C_Out_Box
            // 
            C_Out_Box.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            C_Out_Box.Location = new Point(2148, 279);
            C_Out_Box.Name = "C_Out_Box";
            C_Out_Box.Size = new Size(125, 45);
            C_Out_Box.TabIndex = 32;
            C_Out_Box.Text = "0.95";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(2030, 279);
            label7.Name = "label7";
            label7.Size = new Size(101, 38);
            label7.TabIndex = 33;
            label7.Text = ": C_out";
            // 
            // OptimizeButton
            // 
            OptimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OptimizeButton.Location = new Point(1550, 68);
            OptimizeButton.Name = "OptimizeButton";
            OptimizeButton.Size = new Size(302, 80);
            OptimizeButton.TabIndex = 34;
            OptimizeButton.Text = "OPTIMIZE";
            OptimizeButton.UseVisualStyleBackColor = true;
            OptimizeButton.Click += OptimizeButton_Click;
            // 
            // Mixer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2391, 1330);
            Controls.Add(OptimizeButton);
            Controls.Add(label7);
            Controls.Add(C_Out_Box);
            Controls.Add(CpMinesButton);
            Controls.Add(CpPlucButton);
            Controls.Add(label6);
            Controls.Add(SetPointBox);
            Controls.Add(ModeSwitchButton);
            Controls.Add(SpeedX100);
            Controls.Add(SpeedX50);
            Controls.Add(SpeedX10);
            Controls.Add(SpeedX4);
            Controls.Add(SpeedX1);
            Controls.Add(C2PlusButton);
            Controls.Add(C2MinesButton);
            Controls.Add(C2textBox);
            Controls.Add(label4);
            Controls.Add(G2PlusButton);
            Controls.Add(G2MinesButton);
            Controls.Add(G2textBox);
            Controls.Add(label5);
            Controls.Add(C1PlusButton);
            Controls.Add(C1MinesButton);
            Controls.Add(C1textBox);
            Controls.Add(label3);
            Controls.Add(G1PlusButton);
            Controls.Add(G1MinesButton);
            Controls.Add(G1textBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(StopButton);
            Controls.Add(StartButton);
            Controls.Add(chartConcentration);
            Name = "Mixer";
            RightToLeft = RightToLeft.Yes;
            Text = "Mixer";
            ((System.ComponentModel.ISupportInitialize)chartConcentration).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartConcentration;
        private Button StartButton;
        private Button StopButton;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer Timer;
        private Label label1;
        private Label label2;
        private TextBox G1textBox;
        private Button G1MinesButton;
        private Button G1PlusButton;
        private Button C1PlusButton;
        private Button C1MinesButton;
        private TextBox C1textBox;
        private Label label3;
        private Button C2PlusButton;
        private Button C2MinesButton;
        private TextBox C2textBox;
        private Label label4;
        private Button G2PlusButton;
        private Button G2MinesButton;
        private TextBox G2textBox;
        private Label label5;
        private Button SpeedX1;
        private Button SpeedX4;
        private Button SpeedX10;
        private Button SpeedX50;
        private Button SpeedX100;
        private Button ModeSwitchButton;
        private TextBox SetPointBox;
        private Label label6;
        private Button CpMinesButton;
        private Button CpPlucButton;
        private TextBox C_Out_Box;
        private Label label7;
        private Button OptimizeButton;
    }
}
