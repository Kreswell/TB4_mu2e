using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_mu2e;
using MathNet.Numerics;

namespace mu2e.FEB_Test_Jig
{
    public class FPGAgroup
    {
        public BiasSignal[] Biases = new BiasSignal[2];
        public TrimSignal[] Trims = new TrimSignal[16];
        public LEDsignal[] LEDs = new LEDsignal[4];

    }

    public class AFEgroup
    {
        public BiasSignal[] Biases = new BiasSignal[1];
        public TrimSignal[] Trims = new TrimSignal[8];
        public LEDsignal[] LEDs = new LEDsignal[2];

    }

    public partial class VoltageSignal
    {

        public VoltageSignal()
        {
        }

        public TcpClient _myClient;
        public TcpClient myClient { get { return _myClient; } set { _myClient = value; } }
        public List<Mu2e_Register> _regList;
        public List<Mu2e_Register> regList { get { return _regList; } set { _regList = value; } }
        public bool isBad = false;
        public int signalID = 0;

        public int myHDMIChannel { get; set; }
        public UInt16 myFPGA { get; set; }
        public int myAFE { get; set; } //Bias
        public UInt16 signalIndex { get; set; } //0-3 for trims, 1,2 for AFE (Bias), 0-16 for LEDs 
        public SignalType signalType = SignalType.Trim;

        public Mu2e_Register register = new Mu2e_Register();
        public virtual void SetRegister() { }

        protected double _voltageSetting;
        public double voltageSetting
        {
            get
            {
                GetVoltageSetting();
                return _voltageSetting;
            }
            set
            {
                SetVoltageSetting(value);
            }
        }
        protected virtual void GetVoltageSetting() { }
        public virtual void SetVoltageSetting(double vSet) { }
        public SignalMeasurement myMeasurements = new SignalMeasurement();
        public Calibration calibration = new Calibration();

        public Calibration.Measurements SaveMeasurements()
        {
            Calibration.Measurements measurement;
            measurement.setting = _voltageSetting;
            measurement.min = myMeasurements.minValue;
            measurement.max = myMeasurements.maxValue;
            measurement.average = myMeasurements.averageValue;
            measurement.measurementList = myMeasurements.measurements;
            return measurement;
        }

        public partial class Calibration
        {
            public struct Measurements
            {
                public double setting;
                public double min;
                public double max;
                public double average;
                public List<double> measurementList;
            }

            public Measurements Vhi { get; set; }
            public Measurements Vmed { get; set; }
            public Measurements Vlow { get; set; }
            public double gain = 1;
            public double offset = 0;
            public bool isTested = false;
            public bool isCalibrated = false;

            protected void doFit(Measurements hi, Measurements med, Measurements low)
            {
                double[] voltageX = { Vhi.setting, Vmed.setting, Vlow.setting };
                double[] voltageY = { Vhi.average, Vmed.average, Vlow.average };
                Tuple<double, double> fitParams = Fit.Line(voltageX, voltageY);
                gain = fitParams.Item2;
                offset = fitParams.Item1;
                Int16 slopeInt = (Int16)(gain * 32768);
                Int16 interceptInt = (Int16)(offset * 32768);
                string slope = slopeInt.ToString("X");
                string intercept = interceptInt.ToString("X");
                isTested = true;
            }

            protected void Calibrate()
            {
                isCalibrated = true;
            }
        }

    }

    public class TrimSignal : VoltageSignal
    {
        public TrimSignal() : base()
        {
            signalType = SignalType.Trim;
        }

        public override void SetRegister()
        {
            base.SetRegister();
            if (signalIndex < 0 || signalIndex > 15)
            {
                throw new IndexOutOfRangeException($"FPGA value of {signalIndex} is out of range for Trim signal.");
            }
            Mu2e_Register reg;
            Mu2e_Register.FindName("BIAS_DAC_CH" + signalIndex.ToString(), ref _regList, out reg);
            reg.fpga_index = myFPGA;
            register = reg;
        }

        protected override void GetVoltageSetting()
        {
            base.GetVoltageSetting();
            Mu2e_Register.ReadReg(ref register, ref _myClient);
            UInt32 regval = register.val;
            _voltageSetting = ((double)regval - 2048) / 500;
        }
        public override void SetVoltageSetting(double vSet)
        {
            base.SetVoltageSetting(vSet);
            if (vSet < -4.096 || vSet > 4.096)
            {
                throw new ArgumentOutOfRangeException($"Voltage setting {vSet} not between -4.096 and 4.096 Volts.");
            }
            if (vSet != _voltageSetting)
            {
                myMeasurements.Invalidate((int)(Math.Abs(vSet - _voltageSetting)) * 50);
                UInt32 regval = (UInt32)(vSet * 500 + 2048);
                Mu2e_Register.WriteReg(regval, ref register, ref _myClient);
                _voltageSetting = vSet;
            }
        }
        public double muxCurrent { get; set; }
    }

    public class BiasChannel
    {
        public int myAFE = 0;
        public BiasSignal[] Biases = new BiasSignal[2];

        public BiasChannel()
        {
            Biases[0] = new BiasSignal();
            Biases[1] = new BiasSignal();
        }

        public void myMeasurements() { }
    }

    public class BiasSignal : VoltageSignal
    {
        public BiasSignal() : base()
        {
            signalType = SignalType.Bias;
        }

        public override void SetRegister()
        {
            base.SetRegister();
            if (signalIndex < 0 || signalIndex > 1)
            {
                throw new IndexOutOfRangeException($"FPGA value of {signalIndex} is out of range for Bias signal.");
            }
            Mu2e_Register reg;
            Mu2e_Register.FindName("BIAS_BUS_DAC" + signalIndex.ToString(), ref _regList, out reg);
            reg.fpga_index = myFPGA;
            register = reg;
        }

        protected override void GetVoltageSetting()
        {
            base.GetVoltageSetting();
            Mu2e_Register.ReadReg(ref register, ref _myClient);
            UInt32 regval = register.val;
            _voltageSetting = (double)regval / 50;
        }
        public override void SetVoltageSetting(double vSet)
        {
            base.SetVoltageSetting(vSet);
            if (vSet < 0 || vSet > 81.92)
            {
                throw new ArgumentOutOfRangeException($"Voltage setting {vSet} not between 0 and 81.92 Volts.");
            }
            if (vSet != _voltageSetting)
            {
                myMeasurements.Invalidate((int)(Math.Abs(vSet - _voltageSetting)) * 50);
                UInt32 regval = (UInt32)(vSet * 50);
                Mu2e_Register.WriteReg(regval, ref register, ref _myClient);
                _voltageSetting = vSet;
            }
        }
        public HDMIchan[] HDMI = new HDMIchan[2];
    }

    public class LEDsignal : VoltageSignal
    {
        public LEDsignal() : base()
        {
        }

        public override void SetRegister()
        {
            base.SetRegister();
            if (signalIndex < 0 || signalIndex > 3)
            {
                throw new IndexOutOfRangeException($"FPGA value of {signalIndex} is out of range for LED signal.");
            }
            Mu2e_Register reg;
            Mu2e_Register.FindName("LED_INTENSITY_DAC_CH" + signalIndex.ToString(), ref _regList, out reg);
            reg.fpga_index = myFPGA;
            register = reg;
        }

        protected override void GetVoltageSetting()
        {
            base.GetVoltageSetting();
            Mu2e_Register.ReadReg(ref register, ref _myClient);
            UInt32 regval = register.val;
            _voltageSetting = (double)regval / 300;
        }
        public override void SetVoltageSetting(double vSet)
        {
            base.SetVoltageSetting(vSet);
            if (vSet < 0 || vSet > 13.65)
            {
                throw new ArgumentOutOfRangeException($"Voltage setting {vSet} not between 0 and 13.65 Volts.");
            }
            if (vSet != _voltageSetting)
            {
                myMeasurements.Invalidate((int)(Math.Abs(vSet - _voltageSetting)) * 50);
                UInt32 regval = (UInt32)(vSet * 300);
                Mu2e_Register.WriteReg(regval, ref register, ref _myClient);
                _voltageSetting = vSet;
            }
        }
    }


    public enum SignalType
    {
        Trim,
        Bias,
        LED,
    }

}
