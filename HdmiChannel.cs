using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet;

namespace TB_mu2e
{
    class HdmiChannel
    {
        private System.Windows.Forms.Button _button;
        private uint _channel;
        private uint fpga_num;
        public DacProperties Bias0;
        public DacProperties Led0;
        public DacProperties Trim0;
        public DacProperties Trim1;
        public DacProperties Trim2;
        public DacProperties Trim3;

        private bool _isTested = false;

        public System.Windows.Forms.Button button { get { return _button; } set { _button = value; } }
        public uint channel { get { return _channel; } set { _channel = value; } }

        public bool isTested { get { return _isTested; } set { _isTested = value; } }

        public void doTest(DacProperties dac, double vHi, double vMed, double vLo)
        {

        }

        private void FitData(double[] xdata, double[] ydata, out double slope, out double intercept)
        {
            Tuple<double, double> fitParams = MathNet.Numerics.Fit.Line(xdata, ydata);
            slope = fitParams.Item1;
            intercept = fitParams.Item2;
        }

        public HdmiChannel() { }

    }

    class DacProperties
    {
        private Mu2e_Register _register;
        private double _voltage;
        private double[,] voltageData;

        public Mu2e_Register register { get { return _register; } set { _register = value; } }
        public double voltage { get { return _voltage; } set { _voltage = value; } }


    }
}
