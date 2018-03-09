/*
  * class TecScope
  * namespace mu2e.FEB_Test_Jig

private TekScope DMM = new TekScope(); constructor opens a window allowing the user to select the VISA resource for a scope. You will need to make two TekScope instances. I suggest: DMM and ScopeBias. 

For each scope, subscribe to the 

OnConnectedStateChanged (Object sender, ConnectedStateEventArgs) event. When 
ConnectedStateEventArgs.isConnected = true; You can begin calling 
TecScope.Voltage(int channel) where channel is the scope probe 1-4.

This call to Voltage will start an async thread to write, read, and calculate the requested voltage (i.e. trim voltages and Bias). The async thread will raise an event when a measurement is available. You will need to listen for 

TecScope.OnVoltageChanged(Object Sender, VoltageChangedEventArgs)  where

VoltageChangedEventsArgs.isValid = true indicates the response from the scope is usable. Then VoltageChangedEventArgs.voltage will be the value of the measurement as a double (I think, it might be a float).

If ConnectedStateEventArgs.isConnected becomes false you will need to stop measuring and wait for it to become true or timeout yourself.
*/

using System;
using System.Collections.Generic;
using System.Threading;
using TB_mu2e;
using System.Net.Sockets;


namespace mu2e.FEB_Test_Jig
{
    public class FEB
    {
        private string _FEBserialNum;
        public string FEBserialNum { get { return _FEBserialNum; } set { _FEBserialNum = value; } }

        private TekScope myDMM = new TekScope();
        private List<VoltageSignal> HDMISignals;

        //public TcpClient myClient = new TcpClient();
        //public List<Mu2e_Register> arrReg = new List<Mu2e_Register>();

        public HDMIchan[] HDMIs = new HDMIchan[16];
        public FPGAgroup[] FPGAs = new FPGAgroup[4];
        public AFEgroup[] AFEs = new AFEgroup[8];
        public BiasSignal[] Biases = new BiasSignal[8]; //TODO: Biases are only 4 per board not on signal
        public TrimSignal[] Trims = new TrimSignal[64];
        public LEDsignal[] LEDs = new LEDsignal[16];
        public VoltageSignal[] Voltages = new VoltageSignal[88]; //All voltage signals.

        public static VoltageSignal getVoltageSignalByHDMI(int hdmi, SignalType sigtyp)
        {
            if (hdmi < 0 || hdmi > 15) throw new IndexOutOfRangeException($"HDMI value of {HDMIs} is out of 0-15 range");
            return HDMIs[hdmi].GetSignalFromType(sigtyp);
        }

        public static VoltageSignal getVoltageSignalByFPGA(int FPGA, SignalType sigtyp)
        {
            if (FPGA < 0 || FPGA > 4) throw new IndexOutOfRangeException($"FPGA value of {FPGA} is out of 0-4 range");
            return HDMIs[FPGA / 4].GetSignalFromType(sigtyp);
        }

        public static VoltageSignal getVoltageSignalByBias(int FPGA, SignalType sigtyp)
        {
            if (FPGA < 0 || FPGA > 4) throw new IndexOutOfRangeException($"FPGA value of {FPGA} is out of 0-4 range");
            return HDMIs[FPGA / 4].GetSignalFromType(sigtyp);
        }

        public enum GetVoltageTypes
        {
            AllVoltages,
            AllTrim,
            AllBias,
            AllLED,
        }

        public FEB()
        {
            BuildHDMIsignalDB();
        }

        public void GetVoltages(GetVoltageTypes types) { }

        public void SetVoltages(GetVoltageTypes types, double setting, bool GetMeasurements = true) { }

        private void BuildHDMIsignalDB()
        {
            VoltageSignal newSignal;
            for (int sigNum = 0; sigNum < (6 * 16); sigNum++)
            {
                // make all the signals on the FEB and assign the DMM channel number
                newSignal = new VoltageSignal(myDMM);
                newSignal.myMeasurements.myDmm.myDMMchannel = myDMM.DMMchan;
                newSignal.signalID = sigNum;
                HDMISignals.Add(newSignal);

                // add this signal to the HDMIChan view
          
                trim = (TrimSignal)HDMISignals[i];

            }
            
        }
    }

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
        int _J = 0; // channel number i.e. J connector RefDes AKA HDMI socket;
        public int J
        {
            get { return _J; }
            set
            {
                _J = value;
                Trim0.myHDMIChannel = value;
                Trim1.myHDMIChannel = value;
                Trim2.myHDMIChannel = value;
                Trim3.myHDMIChannel = value;
                LED.myHDMIChannel = value;
                Bias.myHDMIChannel = value;
            }
        }
        /// <summary>
        /// Trim0 is the first signal for this FEB channel. LED is the last.
        /// </summary>
        public VoltageSignal Trim0 = new VoltageSignal();
        public VoltageSignal Trim1 = new VoltageSignal();
        public VoltageSignal Trim2 = new VoltageSignal();
        public VoltageSignal Trim3 = new VoltageSignal();
        public VoltageSignal Bias = new VoltageSignal();
        /// <summary>
        /// LED is the last signal for this FEB channel. Trim0 is the first.
        /// </summary>
        public VoltageSignal LED = new VoltageSignal();

        public HDMIchan()
        {
            //Trim0.signalType = SignalType.Trim0;
            //Trim1.signalType = SignalType.Trim1;
            //Trim2.signalType = SignalType.Trim2;
            //Trim3.signalType = SignalType.Trim3;
            //LED.signalType = SignalType.LED;
            //Bias.signalType = SignalType.Bias;
        }

        public VoltageSignal GetSignalFromType(SignalType sigtyp)
        {
            VoltageSignal retval = new VoltageSignal();
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
            return retval;
        }

        public static explicit operator HDMIchan(VoltageSignal v)
        {
            return new HDMIchan();
        }
    }

    public class SignalMeasurement
    {
        private TekScope DMM;
        public DMM myDmm = new DMM();
        public bool isValid = false;
        public double maxValue;
        public double minValue;
        public double averageValue { get { return (measurements.Count > 0) ? sum / measurements.Count : 0d; } }
        public List<double> measurements;
        private double sum;

        public SignalMeasurement(TekScope dmm)
        {
            clear();
            DMM = dmm;
        }

        public void GetMeasurement(int numberOfMeasurements = 1)
        {
            double retval;
            for (int i = 0; i < numberOfMeasurements; i++)
            {
                if ((retval = DMM.GetVoltage(myDmm)) != double.NaN)
                    Add(retval);
            }
        }

        public void clear()
        {
            maxValue = 0d;
            minValue = 0d;
            sum = 0;
            if (measurements == null) measurements = new List<double>(); else measurements.Clear();
        }

        public void Add(double value)
        {
            if (measurements.Count == 0)
            {
                maxValue = value;
                minValue = value;
            }
            else
            {
                if (value > maxValue) maxValue = value;
                if (value < minValue) minValue = value;
            }
            measurements.Add(value);
            sum += value;
        }

        internal void Invalidate(int wait)
        {
            isValid = false;
            // ThreadPool.QueueUserWorkItem(new WaitCallback(waitToValidate), ti);

            Thread.Sleep(wait);
            isValid = true;
        }

        /*  private WaitCallback waitToValidate()
           {

           } */
    }
}