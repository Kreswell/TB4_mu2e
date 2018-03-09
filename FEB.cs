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

        private List<VoltageSignal> HDMISignals = new List<VoltageSignal>();

        //public TcpClient myClient = new TcpClient();
        //public List<Mu2e_Register> arrReg = new List<Mu2e_Register>();

        public HDMIchan[] HDMIs = new HDMIchan[16];
        public FPGAgroup[] FPGAs = new FPGAgroup[4];
        public AFEgroup[] AFEs = new AFEgroup[8];
        public List<BiasSignal> Biases = new List<BiasSignal>(); 
        public List<TrimSignal> Trims = new List<TrimSignal>();
        public List<LEDsignal> LEDs = new List<LEDsignal>();
        public VoltageSignal[] Voltages = new VoltageSignal[88]; //All voltage signals.

        public static VoltageSignal getVoltageSignalByHDMI(int hdmi, SignalType sigtyp)
        {
            //  if (hdmi < 0 || hdmi > 15) throw new IndexOutOfRangeException($"HDMI value of {HDMIs} is out of 0-15 range");
            return null; // HDMIs[hdmi].GetSignalFromType(sigtyp);
        }

        public static VoltageSignal getVoltageSignalByFPGA(int FPGA, SignalType sigtyp)
        {
            //  if (FPGA < 0 || FPGA > 4) throw new IndexOutOfRangeException($"FPGA value of {FPGA} is out of 0-4 range");
            return null;// HDMIs[FPGA / 4].GetSignalFromType(sigtyp);
        }

        public static VoltageSignal getVoltageSignalByBias(int FPGA, SignalType sigtyp)
        {
            if (FPGA < 0 || FPGA > 4) throw new IndexOutOfRangeException($"FPGA value of {FPGA} is out of 0-4 range");
            return null; //HDMIs[FPGA / 4].GetSignalFromType(sigtyp);
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

            TrimSignal newTrim;
            BiasSignal newBias;
            LEDsignal newLED;
            int connector = 11;
            int myHDMI = 0;
            int myAFE = 0;
            ushort myFPGA = 0;

            for (int chan = 0; chan < 16; chan++)
            {
                // load this channel's references
                // DMMchan.get auto increments to the correct DMM channel signal 
                myHDMI = chan;
                myAFE = chan / 2;
                myFPGA = (ushort)(chan /4);

                HDMIs[chan] = new HDMIchan();
                HDMIs[chan].J = connector++;
                // load the trims
                for (int idx = 0; idx < 4; idx++)
                {
                    newTrim = new TrimSignal();
                    newTrim.myMeasurements.myDmm.myDMMchannel = TekScope.DMMchan;
                    newTrim.signalID = chan + idx;
                    newTrim.signalType = SignalType.Trim;
                    newTrim.myHDMIChannel = myHDMI;
                    newTrim.myAFE = myAFE;
                    newTrim.myFPGA = myFPGA;

                    HDMIs[chan].Trims[idx] = newTrim;
                    Trims.Add(HDMIs[chan].Trims[idx]);
                }
                //load the Bias
                newBias = new BiasSignal();
                newBias.myMeasurements.myDmm.myDMMchannel = TekScope.DMMchan;
                newBias.signalID = chan + 5;
                newBias.signalType = SignalType.Bias;
                newBias.myHDMIChannel = myHDMI;
                newBias.myAFE = myAFE;
                newBias.myFPGA = myFPGA;

                HDMIs[chan].Bias = newBias;
                Biases.Add(HDMIs[chan].Bias);

                //load the LED
                newLED = new LEDsignal();
                newLED.myMeasurements.myDmm.myDMMchannel = TekScope.DMMchan;
                newLED.signalID = chan + 6;
                newLED.signalType = SignalType.Bias;
                newLED.myHDMIChannel = myHDMI;
                newLED.myAFE = myAFE;
                newLED.myFPGA = myFPGA;

                HDMIs[chan].LED = newLED;
                LEDs.Add(HDMIs[chan].LED);
            }

            //Do tests
            int hT = HDMIs[0].Trims[0].myMeasurements.myDmm.myDmmVoltRange;
            HDMIs[0].Trims[0].myMeasurements.myDmm.myDmmVoltRange = 9999;
            int TT = Trims[0].myMeasurements.myDmm.myDmmVoltRange;
            Trims[0].myMeasurements.myDmm.myDmmVoltRange = hT;

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

    public class SignalMeasurement
    {
       
        public DMM myDmm = new DMM();
        public bool isValid = false;
        public double maxValue;
        public double minValue;
        public double averageValue { get { return (measurements.Count > 0) ? sum / measurements.Count : 0d; } }
        public List<double> measurements;
        private double sum;

        public SignalMeasurement()
        {
            clear();
        }

        public void GetMeasurement(int numberOfMeasurements = 1)
        {
            double retval;
            for (int i = 0; i < numberOfMeasurements; i++)
            {
                if ((retval = TekScope.GetVoltage(myDmm)) != double.NaN)
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