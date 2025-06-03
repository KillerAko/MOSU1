using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSU1.Blocks;


namespace MOSU1
{
    public class ControlSystem
    {
        private PIDBlock _pid;
        private double _dt;
        private bool _isAutoMode = true;
        private double _manualOutput = 0;
        private double _processVariable = 0;

        public double SetPoint { get; set; }
        public double Kp { get => _pid.Kp; set => _pid.Kp = value; }
        public double Ki { get => _pid.Ki; set => _pid.Ki = value; }
        public double Kd { get => _pid.Kd; set => _pid.Kd = value; }
        public double E { get; set; }
        public bool IsAutoMode => _isAutoMode;
        public double Output { get; private set; }
        public double ProcessVariable => _processVariable;

    
        public ControlSystem(double dt)
        {
            _dt = dt;
            //_pid = new PIDBlock(1.0, 0.1, 0.01, dt);
            //_pid = new PIDBlock(5.7, 0.00001, 1.6, dt);
        }

        public void SwitchToAutoMode()
        {
            if (!_isAutoMode)
            {
                E = SetPoint - _processVariable;
                _pid.SetManualOutput(_manualOutput, E);
                _isAutoMode = true;
            }
        }

        public void SwitchToManualMode(double manualOutput)
        {
            if (_isAutoMode)
            {
                _isAutoMode = false;
            }
            _manualOutput = manualOutput;
        }

        public double ComputeControlOutput(double processVariable)
        {
            _processVariable = processVariable;

            if (_isAutoMode)
            {
                E = SetPoint - processVariable;
                Output = _pid.Calc(E);
            }
            else
            {
                Output = _manualOutput;
            }

            return Output;
        }
    }
}
