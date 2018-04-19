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

        public Mu2e_FEB_client FEBclient { get; set; }

        public HDMIchan[] HDMIs = new HDMIchan[16];
        public List<FPGA> FPGAs = new List<FPGA>();
        public List<AFE> AFEs = new List<AFE>();
        public List<BiasChannel> Biases = new List<BiasChannel>();
        public List<TrimSignal> Trims = new List<TrimSignal>();
        public List<LEDsignal> LEDs = new List<LEDsignal>();
        public VoltageSignal[] Voltages = new VoltageSignal[6 * 16]; //All voltage signals.

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
            AllLED
        }

        public FEB()
        {
            //BuildHDMIsignalDB();
            TekScope.OpenScope();
        }

        public void GetVoltages(GetVoltageTypes types, int numberOfMeasurements = 1)
        {
            switch (types)
            {
                case GetVoltageTypes.AllVoltages:
                    foreach (VoltageSignal vs in Voltages)
                    {
                        vs.myMeasurements.GetMeasurement(numberOfMeasurements);
                    }
                    break;
                case GetVoltageTypes.AllTrim:
                    foreach (VoltageSignal vs in Trims)
                    {
                        vs.myMeasurements.GetMeasurement(numberOfMeasurements);
                    }
                    break;
                case GetVoltageTypes.AllBias:
                    foreach (BiasChannel bc in Biases)
                    {
                        foreach (VoltageSignal vs in bc.Biases)
                            vs.myMeasurements.GetMeasurement(numberOfMeasurements);
                    }
                    break;
                case GetVoltageTypes.AllLED:
                    foreach (VoltageSignal vs in LEDs)
                    {
                        vs.myMeasurements.GetMeasurement(numberOfMeasurements);
                    }
                    break;
                default:
                    break;
            }
        }

        public void SetVoltages(GetVoltageTypes types, double newVoltage)
        {
            switch (types)
            {
                case GetVoltageTypes.AllVoltages:
                    foreach (VoltageSignal vs in Voltages)
                    {
                        vs.voltageSetting = newVoltage;
                    }
                    break;
                case GetVoltageTypes.AllTrim:
                    foreach (VoltageSignal vs in Trims)
                    {
                        vs.voltageSetting = newVoltage;
                    }
                    break;
                case GetVoltageTypes.AllBias:
                    foreach (BiasChannel bc in Biases)
                    {
                        foreach (VoltageSignal vs in bc.Biases)
                            vs.voltageSetting = newVoltage;
                    }
                    break;
                case GetVoltageTypes.AllLED:
                    foreach (VoltageSignal vs in LEDs)
                    {
                        vs.voltageSetting = newVoltage;
                    }
                    break;
                default:
                    break;
            }
        }

        public void BuildHDMIsignalDB()
        {
            TrimSignal newTrim;
            BiasSignal newBias;
            LEDsignal newLED;
            int connector = 11;
            int myHDMI = 0;
            int myAFE = 0;
            ushort myFPGA = 0;
            int vcount = 0;

            TcpClient client = FEBclient.client;
            List<Mu2e_Register> arrReg = FEBclient.arrReg;

            //Main for loop builds the arrays for HDMIs, Trims, Biases, LEDs, and Voltages
            for (int chan = 0; chan < 16; chan++)
            {
                // load this channel's references
                myHDMI = chan;
                myAFE = chan / 2;
                myFPGA = (ushort)(chan / 4);

                HDMIs[chan] = new HDMIchan();
                HDMIs[chan].J = connector++;

                // load the trims
                for (int idx = 0; idx < 4; idx++)
                {
                    newTrim = new TrimSignal();
                    // DMMchan.get auto increments to the correct DMM channel signal 
                    newTrim.myMeasurements.myDmm.myDMMchannel = TekScope.DMMchan;
                    newTrim.voltageSignal_ID = chan + idx;
                    newTrim.signalType = SignalType.Trim;
                    newTrim.myHDMI_ID = myHDMI;
                    newTrim.myAFE_ID = myAFE;
                    newTrim.myFPGA_ID = myFPGA;
                    newTrim.signalIndex = (ushort)((chan*4 + idx) % 16);
                    newTrim.myClient = client;
                    newTrim.regList = arrReg;
                    newTrim.SetRegister();
                    newTrim.name = "Trim" + newTrim.myFPGA_ID.ToString() + newTrim.signalIndex.ToString("00");

                    HDMIs[chan].Trims[idx] = newTrim; //build the HDMIs entry
                    Trims.Add(HDMIs[chan].Trims[idx]); //Add it to the trims while its here
                    Voltages[vcount++] = HDMIs[chan].Trims[idx]; //Add it to the voltages while its here
                }
                //load the Bias
                newBias = new BiasSignal();
                newBias.myMeasurements.myDmm.myDMMchannel = TekScope.DMMchan;
                newBias.voltageSignal_ID = chan + 5;
                newBias.signalType = SignalType.Bias;
                newBias.myHDMI_ID = myHDMI;
                newBias.myHDMI = HDMIs[myHDMI];
                newBias.myAFE_ID = myAFE;
                newBias.myFPGA_ID = myFPGA;
                newBias.signalIndex = (ushort)((chan % 4) / 2);
                newBias.myClient = client;
                newBias.regList = arrReg;
                newBias.SetRegister();
                newBias.name = "Bias[" + (chan % 2).ToString() + "]" + newBias.myFPGA_ID.ToString() + newBias.signalIndex.ToString("00");


                //Cant add it to the Biases because this is generating BiasSignals and Biases is for BiasChannel i.e each BiasChannel Biases has 2 BiasSignals 
                HDMIs[chan].Bias = newBias;             // build the HDMIs entry
                Voltages[vcount++] = HDMIs[chan].Bias;  //Add it to the voltages while its here

                //load the LED
                newLED = new LEDsignal();
                newLED.myMeasurements.myDmm.myDMMchannel = TekScope.DMMchan;
                newLED.voltageSignal_ID = chan + 6;
                newLED.signalType = SignalType.Bias;
                newLED.myHDMI_ID = myHDMI;
                newLED.myHDMI = HDMIs[myHDMI];
                newLED.myAFE_ID = myAFE;
                newLED.myFPGA_ID = myFPGA;
                newLED.signalIndex = (ushort)(chan % 4);
                newLED.myClient = client;
                newLED.regList = arrReg;
                newLED.SetRegister();
                newLED.name = "LED" + newLED.myFPGA_ID.ToString() + newLED.signalIndex.ToString("00");

                HDMIs[chan].LED = newLED;               // build the HDMIs entry
                LEDs.Add(HDMIs[chan].LED);              //Add it to the LEDs while its here
                Voltages[vcount++] = HDMIs[chan].LED;   //Add it to the voltages while its here
            }

            //build the biasChannels and the AFEs
            BiasChannel newBiasChan;
            AFE newAFE;
            for (int chan = 0; chan < 16; chan++)
            {
                // load the Biases. 8 biases per FEB
                newBiasChan = new BiasChannel();
                newAFE = new AFE();

                newBiasChan.myAFE_ID = (int)(chan / 2);
                newBiasChan.Biases[0] = HDMIs[chan].Bias;
                //  newAFE.HDMIs[0] = HDMIs[chan++]; // load the HDMIs into the AFEs

                newBiasChan.Biases[1] = HDMIs[chan].Bias;
                //  newAFE.HDMIs[1] = HDMIs[chan];

                Biases.Add(newBiasChan);

                newAFE.Bias = newBiasChan;

                AFEs.Add(newAFE);
            }

            // load the trims into the AFEs
            for (int afe = 0; afe < 8; afe++)
            {
                AFEs[afe].AFE_ID = afe; //set the ID number for this AFE
                AFEs[afe].Bias = Biases[afe]; //match the ADE to its bias

                //load the Trim signals
                for (int t = 0; t < 8; t++)
                {
                    AFEs[afe].Trims[t] = Trims[afe * t];
                }
                // load the HDMIs and LED signals
                AFEs[afe].HDMIs[0] = HDMIs[afe * 2];
                AFEs[afe].LEDs[0] = LEDs[afe * 2];
                AFEs[afe].HDMIs[1] = HDMIs[1 + (afe * 2)];
                AFEs[afe].LEDs[1] = LEDs[1 + (afe * 2)];
            }

            // load the FPGAs
            for (int fpga = 0; fpga < 4; fpga++)
            {
                FPGA newFPGA = new FPGA();
                newFPGA.FPGA_ID = fpga;

                //load the 2 AFEs
                newFPGA.AFEs[0] = AFEs[0 + fpga * 2];
                newFPGA.AFEs[1] = AFEs[1 + (fpga * 2)];

                //load the 2 Biases
                newFPGA.Biases[0] = Biases[0 + fpga * 2];
                newFPGA.Biases[1] = Biases[1 + (fpga * 2)]; //TODO: FIX BIAS BUG

                //load the 4 LEDs
                newFPGA.LEDs[0] = LEDs[0 + fpga * 4];
                newFPGA.LEDs[1] = LEDs[1 + (fpga * 4)];
                newFPGA.LEDs[2] = LEDs[2 + (fpga * 4)];
                newFPGA.LEDs[3] = LEDs[3 + (fpga * 4)];

                //load the 4 HDMIs
                newFPGA.HDMIs[0] = HDMIs[0 + fpga * 4];
                newFPGA.HDMIs[1] = HDMIs[1 + (fpga * 4)];
                newFPGA.HDMIs[2] = HDMIs[2 + (fpga * 4)];
                newFPGA.HDMIs[3] = HDMIs[3 + (fpga * 4)];

                //load the 16 Trims
                for (int t = 0; t < 16; t++)
                {
                    newFPGA.Trims[t] = Trims[fpga * t];
                }

                // add it to the list
                FPGAs.Add(newFPGA);
            }
            // now that all lists are built, link the FPGA, AFE, and BiasChannel objects
            foreach (AFE afe in AFEs)
            {
                afe.myFPGA = FPGAs[afe.myFPGA_ID];
            }

            foreach (BiasChannel bc in Biases)
            {
                bc.myAFE = AFEs[bc.myAFE_ID];
            }

            foreach (VoltageSignal v in Voltages)
            {
                v.myAFE = AFEs[v.myAFE_ID];
            }

        }
    }


    public class SignalMeasurement
    {

        public DMM myDmm = new DMM();
        public bool isValid = false;
        public double maxValue;
        public double minValue;
        public double averageValue { get { return (measurements.Count > 0) ? sum / measurements.Count : 0d; } }
        public List<double> measurements;
        public double sum;

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

        private Thread waitThread;
        public void Invalidate(int wait_ms)
        {
            isValid = false;

       //     SignalMeasurement wait = new SignalMeasurement();
       //     waitThread = new Thread(wait.waitToValidate);
       //     waitThread.Start(wait_ms);

            WaitObject wait = new WaitObject(wait_ms, this);
            waitThread = new Thread(wait.waitToValidate);
            waitThread.Start();
        }

   /*     public void waitToValidate(object waitObject)
        {
            WaitObject w = (WaitObject)waitObject;
            Console.WriteLine("+++ entering wait thread for voltage to stabilize");
            Thread.Sleep((int)wait_ms);
            isValid = true;
            Console.WriteLine("--- Exiting wait thread for voltage to stabilize");

            //  GetMeasurement();
        }*/

        public struct WaitObject
        {
            int wait_ms; 
             SignalMeasurement isValidRef;

            public WaitObject(int wait, SignalMeasurement isvalidref)
            {
                wait_ms = wait;
                isValidRef = isvalidref;
            }

            public void waitToValidate()
            {
                Thread.Sleep(wait_ms);
                isValidRef.isValid = true;
            }
        }

    }

}