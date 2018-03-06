using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace TB_mu2e
{
    class HdmiChannel
    {
        public System.Windows.Forms.Button button { get; set; }
        public int channel { get; set; }
        public uint fpga_num { get; set; }
        public BiasProperties Bias0 { get; set; }
        public LedProperties Led0 { get; set; }
        public TrimProperties Trim0 { get; set; }
        public TrimProperties Trim1 { get; set; }
        public TrimProperties Trim2 { get; set; }
        public TrimProperties Trim3 { get; set; }

        public bool isTested { get; set; }

        public HdmiChannel() => isTested = false;
    }

    abstract class DacProperties
    {
        public double[] voltageDataFEB = new double[3];
        public double[] voltageDataScope = new double[3];

        public Mu2e_Register register { get; set; }
        public double voltage { get; set; }
        public string slope { get; set; }
        public string intercept { get; set; }
        public double slopeDouble { get; set; }
        public double interceptDouble { get; set; }

        public abstract UInt32 convertVoltage(double vIn);

        public void FitData()
        {
            Tuple<double, double> fitParams = Fit.Line(voltageDataFEB, voltageDataScope);
            slopeDouble = fitParams.Item2;
            interceptDouble = fitParams.Item1;
            Int16 slopeInt = (Int16)(fitParams.Item2*32768);
            Int16 interceptInt = (Int16)(fitParams.Item1*32768);
            slope = slopeInt.ToString("X");
            intercept = interceptInt.ToString("X");
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

        public double muxCurrent { get; set; }
    }
}
