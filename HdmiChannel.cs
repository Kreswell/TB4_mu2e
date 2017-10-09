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
        private uint _fpga_num;
        private BiasProperties _Bias0;
        private LedProperties _Led0;
        private TrimProperties _Trim0;
        private TrimProperties _Trim1;
        private TrimProperties _Trim2;
        private TrimProperties _Trim3;

        private bool _isTested;

        public System.Windows.Forms.Button button { get { return _button; } set { _button = value; } }
        public uint channel { get { return _channel; } set { _channel = value; } }
        public uint fpga_num { get { return _fpga_num; } set { _fpga_num = value; } }
        public BiasProperties Bias0 { get { return _Bias0; } set { _Bias0 = value; } }
        public LedProperties Led0 { get { return _Led0; } set { _Led0 = value; } }
        public TrimProperties Trim0 { get { return _Trim0; } set { _Trim0 = value; } }
        public TrimProperties Trim1 { get { return _Trim1; } set { _Trim1 = value; } }
        public TrimProperties Trim2 { get { return _Trim2; } set { _Trim2 = value; } }
        public TrimProperties Trim3 { get { return _Trim3; } set { _Trim3 = value; } }

        public bool isTested { get { return _isTested; } set { _isTested = value; } }

        public HdmiChannel()
        {
            bool _isTested = false;
            //BiasProperties _Bias0 = new BiasProperties();
            //LedProperties _Led0 = new LedProperties();
            //TrimProperties _Trim0 = new TrimProperties();
            //TrimProperties _Trim1 = new TrimProperties();
            //TrimProperties _Trim2 = new TrimProperties();
            //TrimProperties _Trim3 = new TrimProperties();
    }

    }

    abstract class DacProperties
    {
        private Mu2e_Register _register;
        private double _voltage;
        public double[] voltageDataFEB = new double[3];
        public double[] voltageDataScope = new double[3];
        private string _slope;
        private string _intercept;
        private double _slopeDouble;
        private double _interceptDouble;

        public Mu2e_Register register { get { return _register; } set { _register = value; } }
        public double voltage { get { return _voltage; } set { _voltage = value; } }
        public string slope { get { return _slope; } set { _slope = value; } }
        public string intercept { get { return _intercept; } set { _intercept = value; } }
        public double slopeDouble { get { return _slopeDouble; } set { _slopeDouble = value; } }
        public double interceptDouble { get { return _interceptDouble; } set { _interceptDouble = value; } }

        public abstract UInt32 convertVoltage(double vIn);

        public void FitData()
        {
            Tuple<double, double> fitParams = MathNet.Numerics.Fit.Line(voltageDataFEB, voltageDataScope);
            _slopeDouble = fitParams.Item2;
            _interceptDouble = fitParams.Item1;
            Int16 slopeInt = (Int16)(fitParams.Item2*32768);
            Int16 interceptInt = (Int16)(fitParams.Item1*32768);
            _slope = slopeInt.ToString("X");
            _intercept = interceptInt.ToString("X");
        }

        //Make lists of test values for diagnostics.
        public List<double> HVHiVals = new List<double>();
        public List<double> HVMedVals = new List<double>();
        public List<double> HVLowVals = new List<double>();
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
