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
        public BiasProperties Bias0;
        public LedProperties Led0;
        public TrimProperties Trim0;
        public TrimProperties Trim1;
        public TrimProperties Trim2;
        public TrimProperties Trim3;

        private bool _isTested = false;

        public System.Windows.Forms.Button button { get { return _button; } set { _button = value; } }
        public uint channel { get { return _channel; } set { _channel = value; } }

        public bool isTested { get { return _isTested; } set { _isTested = value; } }

        public HdmiChannel() { }

    }

    abstract class DacProperties
    {
        private Mu2e_Register _register;
        private double _voltage;
        public double[] voltageDataFEB = new double[3];
        public double[] voltageDataScope = new double[3];
        private double _slope;
        private double _intercept;

        public Mu2e_Register register { get { return _register; } set { _register = value; } }
        public double voltage { get { return _voltage; } set { _voltage = value; } }
        public double slope { get { return _slope; } set { _slope = value; } }
        public double intercept { get { return _intercept; } set { _intercept = value; } }

        public abstract UInt32 convertVoltage(double vIn);

        public void FitData()
        {
            Tuple<double, double> fitParams = MathNet.Numerics.Fit.Line(voltageDataFEB, voltageDataScope);
            _slope = fitParams.Item1;
            _intercept = fitParams.Item2;
        }
    }

    class BiasProperties : DacProperties
    {
        public override UInt32 convertVoltage(double vIn)
        {
            UInt32 vOut;
            vOut = (UInt32)vIn * 50;
            return vOut;
        }
    }

    class LedProperties : DacProperties
    {
        public override UInt32 convertVoltage(double vIn)
        {
            UInt32 vOut;
            vOut = (UInt32)vIn * 300;
            return vOut;
        }
    }

    class TrimProperties : DacProperties
    {
        public override UInt32 convertVoltage(double vIn)
        {
            UInt32 vOut;
            vOut = (UInt32)vIn * 500 + 2048;
            return vOut;
        }
    }
}
