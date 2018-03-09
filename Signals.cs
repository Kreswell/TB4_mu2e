using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_mu2e;

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
        protected static TekScope myDMM;

        public VoltageSignal(TekScope dmm)
        {
            myDMM = dmm;
        }

        public TcpClient myClient;
        public bool isBad = false;
        public int signalID = 0;

        public int myHDMIChannel = 0;
        public UInt16 myFPGA = 0;
        public int myAFE = 0; //Bias
        public UInt16 signalIndex = 0; //0-3 for trims, 1,2 for AFE (Bias), 0-16 for LEDs 
        public SignalType signalType = SignalType.Trim;

        protected Mu2e_Register _register = new Mu2e_Register();
        public Mu2e_Register register
        {
            get { return _register; }
            set { SetRegister(register); }
        }
        public virtual void SetRegister(Mu2e_Register reg) { }

        public double _voltageSetting;
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
        public virtual void GetVoltageSetting() { }
        public virtual void SetVoltageSetting(double vSet) { }
        public SignalMeasurement myMeasurements = new SignalMeasurement(myDMM);
        public Calibration calibration = new Calibration();
    }

    public class TrimSignal : VoltageSignal
    {
        public TrimSignal(TekScope dmm) : base(dmm)
        {
            signalType = SignalType.Trim;
        }

        public override void SetRegister(Mu2e_Register reg)
        {
            base.SetRegister(reg);
            reg.fpga_index = myFPGA;
            if (signalIndex < 0 || signalIndex > 15)
            {
                throw new IndexOutOfRangeException($"FPGA value of {signalIndex} is out of range for Trim signal.");
            }
            reg.addr = (ushort)(0x30 + signalIndex);
            register = reg;
        }

        public override void GetVoltageSetting()
        {
            base.GetVoltageSetting();
            Mu2e_Register.ReadReg(ref _register, ref myClient);
            UInt32 regval = _register.val;
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
                Mu2e_Register.WriteReg(regval, ref _register, ref myClient);
                _voltageSetting = vSet;
            }
        }

        public double muxCurrent { get; set; }
    }

    public class BiasSignal : VoltageSignal
    {
        public BiasSignal(TekScope dmm) : base(dmm)
        {
            signalType = SignalType.Bias;
        }

        public override void SetRegister(Mu2e_Register reg)
        {
            base.SetRegister(reg);
            reg.fpga_index = myFPGA;
            if (signalIndex < 0 || signalIndex > 1)
            {
                throw new IndexOutOfRangeException($"FPGA value of {signalIndex} is out of range for Bias signal.");
            }
            reg.addr = (ushort)(0x44 + signalIndex);
            register = reg;
        }

        public override void GetVoltageSetting()
        {
            base.GetVoltageSetting();
            Mu2e_Register.ReadReg(ref _register, ref myClient);
            UInt32 regval = _register.val;
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
                Mu2e_Register.WriteReg(regval, ref _register, ref myClient);
                _voltageSetting = vSet;
            }
        }

        public HDMIchan[] HDMI = new HDMIchan[2];

    }

    public class LEDsignal : VoltageSignal
    {
        public LEDsignal(TekScope dmm) : base(dmm)
        {
        }

        public override void SetRegister(Mu2e_Register reg)
        {
            base.SetRegister(reg);
            if (signalIndex < 0 || signalIndex > 4)
            {
                throw new IndexOutOfRangeException($"FPGA value of {signalIndex} is out of range for LED signal.");
            }
            reg.fpga_index = myFPGA;
            reg.addr = (ushort)(0x40 + signalIndex);
            register = reg;
        }

        public override void GetVoltageSetting()
        {
            base.GetVoltageSetting();
            Mu2e_Register.ReadReg(ref _register, ref myClient);
            UInt32 regval = _register.val;
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
                Mu2e_Register.WriteReg(regval, ref _register, ref myClient);
                _voltageSetting = vSet;
            }
        }
    }

    public class Calibration
    {
        public SignalMeasurement Vhi { get; set; }
        public SignalMeasurement Vmed { get; set; }
        public SignalMeasurement Vlow { get; set; }
        public double gain = 1;
        public double offset = 0;
        public bool isTested = false;
        public bool isCalibrated = false;
    }

    public enum SignalType
    {
        Trim,
        Bias,
        LED,
    }

}
