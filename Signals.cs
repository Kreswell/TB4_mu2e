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
    /// <summary>
    /// FEBchan is a helper struct, mapping FEB channels to the DMM channels that are measuring the voltage
    /// Choosing the signal in this channel provides the integer value of the DMM channel to read for this siganl.
    /// </summary>
    public class HDMIchan
    {
        /// <summary>
        /// J refers to the actual HDMI refernce designator value on the FEB PCB. Valid values: J11-J26
        /// </summary>
        /// 
        public int J;
        public TrimSignal[] Trims = new TrimSignal[4];
        public BiasSignal Bias = new BiasSignal();
        public LEDsignal LED = new LEDsignal();

        public HDMIchan()
        {
        }

        /*   public VoltageSignal GetSignalFromType(SignalType sigtyp)
           {
               //VoltageSignal retval = new VoltageSignal();
               //switch (sigtyp)
               //{
               //    case SignalType.Trim0:
               //        retval = Trim0;
               //        break;
               //    case SignalType.Trim1:
               //        retval = Trim1;
               //        break;
               //    case SignalType.Trim2:
               //        retval = Trim2;
               //        break;
               //    case SignalType.Trim3:
               //        retval = Trim3;
               //        break;
               //    case SignalType.Bias:
               //        retval = Bias;
               //        break;
               //    case SignalType.LED:
               //        retval = LED;
               //        break;
               //    default:
               //        break;
               //}
               return null; //retval;
           } */
    }
    public class FPGA
    {
        public int FPGA_ID;
        public AFE[] AFEs = new AFE[2];
        public BiasChannel[] Biases = new BiasChannel[2];
        public TrimSignal[] Trims = new TrimSignal[16];
        public LEDsignal[] LEDs = new LEDsignal[4];
        public HDMIchan[] HDMIs = new HDMIchan[4];

        public FPGA()
        {
            //AFEs
        }
    }

    public class AFE
    {
        public int AFE_ID;
        public FPGA myFPGA;
        public int myFPGA_ID = 0;
        public HDMIchan[] HDMIs = new HDMIchan[2];
        public BiasChannel Bias = new BiasChannel();
        public TrimSignal[] Trims = new TrimSignal[8];
        public LEDsignal[] LEDs = new LEDsignal[2];
    }

    public class BiasChannel
    {
        public int BiasChannel_ID = 0;
        public AFE myAFE;
        public int myAFE_ID = 0;
        public BiasSignal[] Biases = new BiasSignal[2];
        public Calibration calibration = new Calibration();

        public BiasChannel()
        {
            Biases[0] = new BiasSignal();
            Biases[1] = new BiasSignal();
        }

        public int myFPGA_ID { get { return Biases[0].myFPGA_ID; } }
        public int signalIndex { get { return Biases[0].signalIndex; } }

        public double voltageSetting
        {
            get
            {
                if (Biases[0].voltageSetting != Biases[1].voltageSetting)
                {
                    throw new Exception($"Voltage settings for {Biases[0]} and {Biases[1]} do not match!");
                }
                else
                {
                    return Biases[0].voltageSetting;
                }
            }
            set
            {
                Biases[0].voltageSetting = value;
                Biases[1].voltageSetting = value;
            }
        }

        public bool isValid { get { return Biases[0].myMeasurements.isValid && Biases[1].myMeasurements.isValid; } }
        public double maxValue { get { return Math.Max(Biases[0].myMeasurements.maxValue, Biases[1].myMeasurements.maxValue); } }
        public double minValue { get { return Math.Min(Biases[0].myMeasurements.minValue, Biases[1].myMeasurements.minValue); } }
        public double averageValue { get { return (Biases[0].myMeasurements.averageValue + Biases[1].myMeasurements.averageValue) / 2; } }
        public List<double> measurements
        {
            get
            {
                List<double> measurements0 = Biases[0].myMeasurements.measurements;
                List<double> measurements1 = Biases[1].myMeasurements.measurements;
                measurements0.AddRange(measurements1);
                return measurements0;
            }
        }
        private double sum { get { return Biases[0].myMeasurements.sum + Biases[1].myMeasurements.sum; } }

        public void GetMeasurement(int numberOfMeasurements = 1)
        {
            Biases[0].myMeasurements.GetMeasurement(numberOfMeasurements);
            Biases[1].myMeasurements.GetMeasurement(numberOfMeasurements);
        }

        public struct Measurements
        {
            public double setting;
            public double min;
            public double max;
            public double average;
            public List<double> measurementList;
        }

        public Measurements SaveMeasurements()
        {
            Measurements measurement;
            measurement.setting = voltageSetting;
            measurement.min = minValue;
            measurement.max = maxValue;
            measurement.average = averageValue;
            measurement.measurementList = measurements;
            return measurement;
        }

        public class Calibration
        {

            public Measurements Vhi { get; set; }
            public Measurements Vmed { get; set; }
            public Measurements Vlow { get; set; }
            public double gain = 1;
            public double offset = 0;
            public UInt16 gainInt = 32768;
            public UInt16 offsetInt = 0;
            public bool isTested = false;
            public bool isCalibrated = false;
            public bool calibrationsLoaded = false;

            public void DoCalibrationFit()
            {
                doFit(Vhi, Vmed, Vlow);
                isTested = true;
            }

            protected void doFit(Measurements hi, Measurements med, Measurements low)
            {
                double[] voltageX = { Vhi.setting, Vmed.setting, Vlow.setting };
                double[] voltageY = { Vhi.average, Vmed.average, Vlow.average };
                Tuple<double, double> fitParams = Fit.Line(voltageX, voltageY);
                gain = fitParams.Item2;
                offset = fitParams.Item1;
                gainInt = (UInt16)(fitParams.Item2 * 32768);
                // offsetInt is a 12-bit 2's compliment integer.
                // The sign needs to be reversed for it to be applied correctly.
                if (offset >= 0)
                {
                    offsetInt = (UInt16)(fitParams.Item1 * 50);
                }
                else
                {
                    offsetInt = (UInt16)(4096 - fitParams.Item1 * 50);
                }
                string slope = gainInt.ToString("X");
                string intercept = offsetInt.ToString("X");
            }

            public void Calibrate()
            {
                //TODO: Copy code for writing the calibration constants to their registers here.
                if (isTested || calibrationsLoaded)
                {
                    isCalibrated = true;
                }
            }
        }
    }

    public class BiasMeasurement
    {

    }

    public partial class VoltageSignal
    {
        public int voltageSignal_ID = 0;
        public AFE myAFE;

        public TcpClient myClient { get; set; }
        public List<Mu2e_Register> regList { get; set; }

        public bool isBad = false;

        //Boolean to know whether an initial measurement has been taken when first connected.
        public bool initVmeas = false;

        public int myHDMI_ID { get; set; }
        public HDMIchan myHDMI;
        public UInt16 myFPGA_ID { get; set; }
        public int myAFE_ID { get; set; } //Bias
        public UInt16 signalIndex { get; set; } //0-3 for trims, 1,2 for AFE (Bias), 0-16 for LEDs 
        public SignalType signalType = SignalType.Trim;
        public string name { get; set; }

        public Mu2e_Register register = new Mu2e_Register();
        public virtual void SetRegister() { }

        public VoltageSignal()
        {
        }

        protected double _voltageSetting;
        public virtual double voltageSetting
        {
            get
            {
                return _voltageSetting;
            }
            set { }
        }

        public SignalMeasurement myMeasurements = new SignalMeasurement();
        public Calibration calibration = new Calibration();

        public Measurements SaveMeasurements()
        {
            Measurements measurement;
            measurement.setting = voltageSetting;
            measurement.min = myMeasurements.minValue;
            measurement.max = myMeasurements.maxValue;
            measurement.average = myMeasurements.averageValue;
            measurement.measurementList = myMeasurements.measurements;
            return measurement;
        }

        public struct Measurements
        {
            public double setting;
            public double min;
            public double max;
            public double average;
            public List<double> measurementList;
        }

        public class Calibration
        {

            public Measurements Vhi { get; set; }
            public Measurements Vmed { get; set; }
            public Measurements Vlow { get; set; }
            public double gain = 1;
            public double offset = 0;
            UInt16 gainInt = 32768;
            UInt16 offsetInt = 0;
            public bool isTested = false;
            public bool isCalibrated = false;
            public bool calibrationsLoaded = false;

            public void DoCalibrationFit()
            {
                doFit(Vhi, Vmed, Vlow);
                isTested = true;
            }

            protected void doFit(Measurements hi, Measurements med, Measurements low)
            {
                // Voltages need to be shifted for calibration constants to be correct.
                double[] voltageX = { Vhi.setting + 4.096, Vmed.setting + 4.096, Vlow.setting + 4.096 };
                double[] voltageY = { Vhi.average + 4.096, Vmed.average + 4.096, Vlow.average + 4.096 };
                Tuple<double, double> fitParams = Fit.Line(voltageX, voltageY);
                gain = fitParams.Item2;
                offset = fitParams.Item1;
                gainInt = (UInt16)(fitParams.Item2 * 32768);
                // offsetInt is a 12-bit 2's compliment integer. 
                // The sign needs to be reversed for it to be applied correctly.
                if ( offset < 0 )
                {
                    offsetInt = (UInt16)(-fitParams.Item1 * 500);
                }
                else
                {
                    offsetInt = (UInt16)(4096 - fitParams.Item1 * 500);
                }
                string slope = gainInt.ToString("X");
                string intercept = offsetInt.ToString("X");
            }

            public void Calibrate()
            {
                //TODO: Copy code for writing the calibration constants to their registers here.
                if (isTested || calibrationsLoaded)
                {
                    isCalibrated = true;
                }
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
            Mu2e_Register reg = regList.Find(r => r.name == "BIAS_DAC_CH" + signalIndex.ToString());
            //Mu2e_Register.FindName("BIAS_DAC_CH" + signalIndex.ToString(), ref _regList, out reg);
            reg.fpga_index = myFPGA_ID;
            register = reg;
        }

        //protected override void GetVoltageSetting()
        //{
        //    base.GetVoltageSetting();
        //    Mu2e_Register.ReadReg(ref register, myClient, "drd");
        //    UInt32 regval = register.val;
        //    _voltageSetting = ((double)regval - 2048) / 500;
        //}

        //public override void SetVoltageSetting(double vSet)
        //{
        //    base.SetVoltageSetting(vSet);

        //    if (vSet < -4.096 || vSet > 4.096)
        //    {
        //        throw new ArgumentOutOfRangeException($"Voltage setting {vSet} not between -4.096 and 4.096 Volts.");
        //    }

        //    Mu2e_Register.ReadReg(ref register, myClient, "drd");
        //    double vReg = ((double)register.val - 2048) / 500;

        //    if (Math.Abs(vSet - vReg) > 0.01 || !initVmeas)
        //    { //To save time, a measurement is only take if the setting is changed or if none has been taken yet.
        //        initVmeas = true;
        //        if (!TekScope.inTestMode)
        //        {
        //            myMeasurements.Invalidate((int)(Math.Abs(vSet - vReg)) * 50);
        //        }
        //        UInt32 regval = (UInt32)(vSet * 500 + 2048);
        //        Mu2e_Register.WriteReg(regval, ref register, myClient, "dwr");
        //        voltageSetting = vSet;
        //    }
        //}

        public override double voltageSetting
        {
            get
            {
                //Mu2e_Register.ReadReg(ref register, myClient, "drd");
                //UInt32 regval = register.val;
                //double vSet = ((double)regval - 2048) / 500;
                //return vSet;
                return _voltageSetting;
            }
            set
            {
                double vInit = _voltageSetting;
                double vSet = value;
                //Impose ceiling/floor on setting values.
                vSet = (vSet > -4.096) ? vSet : -4.096;
                vSet = (vSet < 4.095) ? vSet : 4.095;

                if (Math.Abs(vSet - vInit) > 0.001 || !initVmeas)
                { //To save time, a measurement is only take if the setting is changed or if none has been taken yet.
                    initVmeas = true;
                    if (!TekScope.inTestMode)
                    {
                        myMeasurements.Invalidate((int)(Math.Abs(vSet - vInit)) * 50);
                    }
                    UInt32 regval = (UInt32)(vSet * 500 + 2048);
                    Mu2e_Register.WriteReg(regval, ref register, myClient, "dwr");
                    voltageSetting = vSet;
                }
            }
        }

        public double muxCurrent { get; set; }
        public double muxCalibCurrent { get; set; }
        public bool muxIsTested = false;
        public bool muxIsCalibrated = false;
        public bool muxIsBad = false;
        public void muxCalibrate()
        {  // TODO: confirm that this is the correct way to calibrate the current.
            if (muxIsTested && !muxIsCalibrated)
            {
                muxCurrent = muxCurrent * 0.0000035 / muxCalibCurrent;
                muxIsCalibrated = true;
            }
        }
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
            Mu2e_Register reg = regList.Find(r => r.name == "BIAS_BUS_DAC" + signalIndex.ToString());
            //Mu2e_Register.FindName("BIAS_BUS_DAC" + signalIndex.ToString(), ref _regList, out reg);
            reg.fpga_index = myFPGA_ID;
            register = reg;
        }

        //protected override void GetVoltageSetting()
        //{
        //    base.GetVoltageSetting();
        //    Mu2e_Register.ReadReg(ref register, myClient, "drd");
        //    UInt32 regval = register.val;
        //    _voltageSetting = (double)regval / 50;
        //}
        //public override void SetVoltageSetting(double vSet)
        //{
        //    base.SetVoltageSetting(vSet);
        //    if (vSet < 0 || vSet > 81.92)
        //    {
        //        throw new ArgumentOutOfRangeException($"Voltage setting {vSet} not between 0 and 81.92 Volts.");
        //    }

        //    Mu2e_Register.ReadReg(ref register, myClient, "drd");            
        //    double vReg = (double)register.val / 50;

        //    if (Math.Abs(vSet - vReg) > 0.01 || !initVmeas)
        //    { //To save time, a measurement is only take if the setting is changed or if none has been taken yet.
        //        initVmeas = true;
        //        if (!TekScope.inTestMode)
        //        {
        //            myMeasurements.Invalidate((int)(Math.Abs(vSet - vReg)) * 50);
        //        }
        //        UInt32 regval = (UInt32)(vSet * 50);
        //        Mu2e_Register.WriteReg(regval, ref register, myClient, "dwr");
        //        _voltageSetting = vSet;
        //    }
        //}

        public override double voltageSetting
        {
            get
            {
                //Mu2e_Register.ReadReg(ref register, myClient, "drd");
                //UInt32 regval = register.val;
                //double vSet = (double)regval / 50;
                //return vSet;
                return _voltageSetting;
            }
            set
            {
                double vInit = _voltageSetting;
                double vSet = value;
                //Impose ceiling/floor on setting values.
                vSet = (vSet > 0) ? vSet : 0;
                vSet = (vSet < 81.91) ? vSet : 81.91;

                if (Math.Abs(vSet - vInit) > 0.001 || !initVmeas)
                { //To save time, a measurement is only take if the setting is changed or if none has been taken yet.
                    initVmeas = true;
                    if (!TekScope.inTestMode)
                    {
                        myMeasurements.Invalidate((int)(Math.Abs(vSet - vInit)) * 50);
                    }
                    UInt32 regval = (UInt32)(vSet * 50);
                    Mu2e_Register.WriteReg(regval, ref register, myClient, "dwr");
                    voltageSetting = vSet;
                }
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
            Mu2e_Register reg = regList.Find(r => r.name == "LED_INTENSITY_DAC_CH" + signalIndex.ToString());
            //Mu2e_Register.FindName("LED_INTENSITY_DAC_CH" + signalIndex.ToString(), ref _regList, out reg);
            reg.fpga_index = myFPGA_ID;
            register = reg;
        }

        //protected override void GetVoltageSetting()
        //{
        //    base.GetVoltageSetting();
        //    Mu2e_Register.ReadReg(ref register, myClient, "drd");
        //    UInt32 regval = register.val;
        //    _voltageSetting = (double)regval / 300;
        //}
        //public override void SetVoltageSetting(double vSet)
        //{
        //    base.SetVoltageSetting(vSet);

        //    if (vSet < 0 || vSet > 13.65)
        //    {
        //        throw new ArgumentOutOfRangeException($"Voltage setting {vSet} not between 0 and 13.65 Volts.");
        //    }

        //    Mu2e_Register.ReadReg(ref register, myClient, "drd");
        //    double vReg = (double)register.val / 300;

        //    if (Math.Abs(vSet - vReg) > 0.001 || !initVmeas)
        //    { //To save time, a measurement is only take if the setting is changed or if none has been taken yet.
        //        initVmeas = true;
        //        if (!TekScope.inTestMode)
        //        {
        //            myMeasurements.Invalidate((int)(Math.Abs(vSet - vReg)) * 50);
        //        }
        //        UInt32 regval = (UInt32)(vSet * 300);
        //        Mu2e_Register.WriteReg(regval, ref register, myClient, "dwr");
        //        _voltageSetting = vSet;
        //    }
        //}

        public override double voltageSetting
        {
            get
            {
                //Mu2e_Register.ReadReg(ref register, myClient, "drd");
                //UInt32 regval = register.val;
                //double vSet = (double)regval * 17/4700;
                //return vSet;
                return _voltageSetting;
            }
            set
            {
                double vInit = voltageSetting;
                double vSet = value;
                //Impose ceiling/floor on setting values.
                vSet = (vSet < 14.81) ? vSet : 14.81;
                vSet = (vSet > 0) ? vSet : 0;

                if (Math.Abs(vSet - vInit) > 0.001 || !initVmeas)
                { //To save time, a measurement is only take if the setting is changed or if none has been taken yet.
                    initVmeas = true;
                    if (!TekScope.inTestMode)
                    {
                        myMeasurements.Invalidate((int)(Math.Abs(vSet - vInit)) * 50);
                    }
                    UInt32 regval = (UInt32)(vSet * 4700/17);
                    Mu2e_Register.WriteReg(regval, ref register, myClient, "dwr");
                    voltageSetting = vSet;
                }
            }
        }
    }


    public enum SignalType
    {
        Trim,
        Bias,
        LED
    }

}
