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
using System.Windows.Forms;
using System.Threading;
using Ivi.Visa;
using NationalInstruments.Visa;
using System.Collections.Generic;
using TB_mu2e;

namespace mu2e.FEB_Test_Jig
{

    public static class TekScope
    {
        /// <summary>
        /// likely not needed. This is asserted when the write command is completed. This is exposed publicly only for testing.
        /// </summary>
        public static event EventHandler WriteComplete;
        /// <summary>
        /// likely not needed. This is asserted when the read command is completed. This is exposed publicly only for testing.
        /// </summary>
        public static event EventHandler<readArgs> ReadComplete;
        /// <summary>
        /// is asserted when the scope connection changes
        /// </summary>
        public static event EventHandler<ConnectedStateEventArgs> OnConnectedStateChanged;
        /// <summary>
        /// returns the voltage measurement after a call to GetVoltage(channelNumber)
        /// </summary>
        public static event EventHandler<VoltageChangedEventsArgs> OnVoltageChanged;
        /// <summary>
        /// Is returned as a VoltageChangedEventArg.voltage when GetVoltage(channelNumber) is called when no scope is attached
        /// <para>This can be used for testing with out scopes attached</para>
        /// </summary>
        public static double voltageDefaultValue = -5d;
        /// <summary>
        /// set inTestMode = true if no scopes are connected. Open scope will succeed, and GetVoltage(ChannelNumber) will retrun voltageDefaultValue.
        /// </summary>
        public static bool inTestMode = false;
        //public static bool inTestMode = true;


        private static SelectResource sr;
        private static ISerialSession serial;
        private static MessageBasedSession mbSession;
        private static IVisaAsyncResult asyncHandle = null;
        private static ResourceManager rmSession = null;

        // +++ properties 
        private static string _scopeName = "Agilent 37970A DMM";
        public static string scopeName
        {
            get { return _scopeName; }
            set { _scopeName = value.Trim(); }
        }

        private static bool _isConnected = false;

        /// <summary>
        /// true indicates the scope is connected and can be used
        /// false indicates the scope has not been set up or cannot be opened.
        /// Get a true value by calling OpenScope or using the new constructor.
        /// </summary>
        public static bool isConnected
        {
            get
            {
                if (inTestMode)
                {
                    _isConnected = true;
                    return true;
                }
                else
                    return _isConnected;
            }
            private set
            {
                if (value != _isConnected)
                {
                    _isConnected = value;
                    // raise the state changed event with the new value
                    OnConnectedStateChanged?.Invoke(null, new ConnectedStateEventArgs(value));
                }
            }
        }

        //++++ Helper property to assign DMM channels only no other use.
        private static int _DMMchan = 100; // channel 101 is the first. but each get increments by one.
        /// <summary>
        /// Only used to assign DMM channel references at start up. no other use.
        /// </summary>
        public static int DMMchan
        {
            get
            {
                if (_DMMchan == 140) { _DMMchan = 201; } // jump to the second module
                else if (_DMMchan == 240) { _DMMchan = 301; } // jump to the third module
                else _DMMchan++; //increment by one
                return _DMMchan;
            }
        }
        //---- Helper DMM property
        // --- properties

        // +++ Constructors
        /// <summary>
        /// Starts a new scope instance but does not attempt to open the scope for use.
        /// <para>Call OpenScope to start communications.</para>
        /// </summary>
        //     public static TekScope()
        //    {

        //  assignDMMchannels();
        //         OpenScope(scopeName);
        //     }

        /// <summary>
        /// Starts a new scope instance and attempts to open the scope for use.
        /// <para>If connection is a success then OnConnectedStateChanged will assert with arg isConnected = true;</para>
        /// <para>Otherwise, isConnected may be tested for connection state.</para>
        /// </summary>
        /// <param name="scopeName">A nickname for this scope instance</param>
        /// <param name="lastResourceString">Optional. If blank, a dialog will allow the user to select a scope from the available scope resources. 
        /// <para>if used, this is a tektronix scope resource string identifying a specific scope that is known to be connected.</para>
        /// </param>
        /*    public TekScope(string scopeName, string lastResourceString = null)
            {
                //  assignDMMchannels();
                OpenScope(scopeName, lastResourceString);
            }*/
        // --- Constructors

        public static void Dispose()
        {
            if (mbSession != null)
            {
                mbSession.Dispose();
            }
        }

        //  public static  bool OpenScope(string name, string lastResourceString = "ASRL1::INSTR")
        public static bool OpenScope()
        {
            bool open = false;
            string lastResourceString = "ASRL1::INSTR";

            //scopeName = name;

            if (inTestMode) return true;

            using (sr = new SelectResource(scopeName, lastResourceString))
            {
                /*  if (lastResourceString != null)
                  {
                      sr.ResourceName = lastResourceString;
                  }*/
                DialogResult result = sr.DialogResult;
                if (result != DialogResult.OK)
                    result = sr.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (sr != null) sr.Close();
                    lastResourceString = sr.ResourceName;
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        using (rmSession = new ResourceManager())
                        {
                            mbSession = (MessageBasedSession)rmSession.Open(lastResourceString);

                            serial = mbSession as ISerialSession;

                            serial.BaudRate = 115200;

                            serial.DataBits = 8;

                            serial.Parity = SerialParity.None;

                            serial.FlowControl = SerialFlowControlModes.RtsCts;

                            // Use SynchronizeCallbacks to specify that the object marshals callbacks across threads appropriately.
                            mbSession.SynchronizeCallbacks = true;

                            // ++++++ Reset the DMM to clear errors
                            write("*RST;*CLS\n");
                            // not supported... mbSession.WaitOnEvent(EventType.Clear);
                            Thread.Sleep(500);
                            write("*CLS\n"); //some times it takes two clears to reset a DMM error
                            Thread.Sleep(500);
                            // ------ end of reset

                            //   mbSession.ServiceRequest += MbSession_ServiceRequest;

                            //CONFigure[:VOLTage][:DC][{< range >| AUTO | MIN | MAX | DEF} [,{<resolution>|MIN|MAX|DEF}] ]
                            write("CONFigure:VOLTage:DC AUTO, (@101:316)\n");

                            // write("SENSe:VOLTage:DC:NPLC1,(@101:316)");
                            _isConnected = true;
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                        _isConnected = false;
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            // for testing   
            //GetVoltages(signalList_AllSignals, 10, 888);
            return open;
        }

        /*
        void mbSession_ServiceRequest(object sender, VisaEventArgs e)
        {
            throw new NotImplementedException("arrived at service request");
        }
        */

        /// <summary>
        /// Close this scope instance. 
        /// <para>OnConnectedStateChanged will assert with isConnected = false</para>
        /// </summary>
        public static void closeScope()
        {
            if (!inTestMode)
            {
                _isConnected = false;
                mbSession.Dispose();
            }
        }


        internal static void write(string command)
        {
            try
            {

                string textToWrite = ReplaceCommonEscapeSequences(command);
                asyncHandle = mbSession.RawIO.BeginWrite(
                    textToWrite,
                    new VisaAsyncCallback(OnWriteComplete),
                    (object)textToWrite.Length);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }


        private static void OnWriteComplete(IVisaAsyncResult result)
        {
            try
            {

                mbSession.RawIO.EndWrite(result);

                if (WriteComplete != null)
                {
                    WriteComplete(null, default(EventArgs));
                }
            }

            catch (Exception exp)
            {
                //  throw new Exception(scopeName + ": OnWriteComplete failed. " + exp.Message);
            }
        }


        internal static void read()
        {
            try
            {
                asyncHandle = mbSession.RawIO.BeginRead(
                    1024,
                    new VisaAsyncCallback(OnReadComplete),
                    null);
            }
            catch (Exception exp)
            {
                throw new Exception(scopeName + ": Read failed. " + exp.Message);
            }
        }

        private static void OnReadComplete(IVisaAsyncResult result)
        {
            try
            {
                string responseString = mbSession.RawIO.EndReadString(result);
                if (ReadComplete != null)
                {
                    readArgs e = new readArgs();
                    e.text = InsertCommonEscapeSequences(responseString);
                    ReadComplete(null, e);
                }

            }
            catch (Exception exp)
            {
                if (ReadComplete != null)
                {
                    readArgs e = new readArgs();
                    e.text = InsertCommonEscapeSequences(scopeName + ": OnReadComplete failed. " + exp.Message);
                    ReadComplete(null, e);
                }
                else
                {
                    //throw new Exception(scopeName + ": OnReadComplete failed. " + exp.Message);
                }
            }
        }

        /*
                internal bool AbortCommand()
                {
                    bool success = false;
                    try
                    {
                        mbSession.RawIO.AbortAsyncOperation(asyncHandle);
                        success = true;
                    }
                    catch (Exception exp)
                    {
                        throw new Exception(scopeName + ": Abort command failed. " + exp.Message);
                    }
                    return success;
                }
                */


        /// <summary>
        /// FEBchan[16] is a helper array, mapping FEB channels to the DMM channels that are measuring the voltage
        /// Choosing the FEB channel (0-16) then choosing the signal in this channel 
        /// provides the integer value of the DMM channel to read for the siganl in this channel.
        /// </summary>
        /*   
           public List<int> signalList_AllSignals = new List<int>();
           public List<int> signalList_AllBiass = new List<int>();
           public List<int> signalList_AllTrims = new List<int>();
           public List<int> signalList_AllLEDs = new List<int>();
           public List<int> signalList_Trim0s = new List<int>();
           public List<int> signalList_Trim1s = new List<int>();
           public List<int> signalList_Trim2s = new List<int>();
           public List<int> signalList_Trim3s = new List<int>();
           public Dictionary<int, VoltageSignal> DMMsignalLookup = new Dictionary<int, VoltageSignal>();
           */

        /*
        private void assignDMMchannels()
        {
            //populate the references to the DMM channels
            FEB.FPGAs[0] = new FPGAgroup();
            FEB.FPGAs[1] = new FPGAgroup();
            FEB.FPGAs[2] = new FPGAgroup();
            FEB.FPGAs[3] = new FPGAgroup();

            int connector = 11;
            int id = 0;
            for (int chan = 0; chan < 16; chan++)
            {
                // load this channel's references
                // DMMchan.get auto increments to the correct DMM channel signal 
                FEB.HDMIs[chan] = new HDMIchan();
                FEB.HDMIs[chan].J = connector++;

                FEB.HDMIs[chan].Trim0.myDmmId = DMMchan;
                DMMsignalLookup.Add(FEB.HDMIs[chan].Trim0.myDmmId, FEB.HDMIs[chan].Trim0);

                FEB.HDMIs[chan].Trim1.myDmmId = DMMchan;
                DMMsignalLookup.Add(FEB.HDMIs[chan].Trim1.myDmmId, FEB.HDMIs[chan].Trim1);

                FEB.HDMIs[chan].Trim2.myDmmId = DMMchan;
                DMMsignalLookup.Add(FEB.HDMIs[chan].Trim2.myDmmId, FEB.HDMIs[chan].Trim2);

                FEB.HDMIs[chan].Trim3.myDmmId = DMMchan;
                DMMsignalLookup.Add(FEB.HDMIs[chan].Trim3.myDmmId, FEB.HDMIs[chan].Trim3);

                FEB.HDMIs[chan].Bias.myDmmId = DMMchan;
                DMMsignalLookup.Add(FEB.HDMIs[chan].Bias.myDmmId, FEB.HDMIs[chan].Bias);

                FEB.HDMIs[chan].LED.myDmmId = DMMchan;
                DMMsignalLookup.Add(FEB.HDMIs[chan].LED.myDmmId, FEB.HDMIs[chan].LED);

                // load all Bias
                signalList_AllBiass.Add(FEB.HDMIs[chan].Bias.myDmmId);

                // load all LEDs
                signalList_AllLEDs.Add(FEB.HDMIs[chan].LED.myDmmId);

                // load individual trims
                signalList_Trim0s.Add(FEB.HDMIs[chan].Trim0.myDmmId);
                signalList_Trim1s.Add(FEB.HDMIs[chan].Trim1.myDmmId);
                signalList_Trim2s.Add(FEB.HDMIs[chan].Trim2.myDmmId);
                signalList_Trim3s.Add(FEB.HDMIs[chan].Trim3.myDmmId);

                // load all trims
                signalList_AllTrims.Add(FEB.HDMIs[chan].Trim0.myDmmId);
                signalList_AllTrims.Add(FEB.HDMIs[chan].Trim1.myDmmId);
                signalList_AllTrims.Add(FEB.HDMIs[chan].Trim2.myDmmId);
                signalList_AllTrims.Add(FEB.HDMIs[chan].Trim3.myDmmId);

                // load all signals
                signalList_AllSignals.Add(FEB.HDMIs[chan].Trim0.myDmmId);
                signalList_AllSignals.Add(FEB.HDMIs[chan].Trim1.myDmmId);
                signalList_AllSignals.Add(FEB.HDMIs[chan].Trim2.myDmmId);
                signalList_AllSignals.Add(FEB.HDMIs[chan].Trim3.myDmmId);
                signalList_AllSignals.Add(FEB.HDMIs[chan].Bias.myDmmId);
                signalList_AllSignals.Add(FEB.HDMIs[chan].LED.myDmmId);



                // load the FPGA references
                id = chan / 4;
//TODO: finish FPGA and BIAS
     /*           FEB.FPGAs[id].Add(FEB.HDMIs[chan].Trim0);
                FEB.FPGAs[id].Add(FEB.HDMIs[chan].Trim1);
                FEB.FPGAs[id].Add(FEB.HDMIs[chan].Trim2);
                FEB.FPGAs[id].Add(FEB.HDMIs[chan].Trim3);
                FEB.FPGAs[id].Add(FEB.HDMIs[chan].Bias);
                FEB.FPGAs[id].Add(FEB.HDMIs[chan].LED); */
        /*
                        FEB.HDMIs[chan].Trim1.myFPGA = id;
                        FEB.HDMIs[chan].Trim2.myFPGA = id;
                        FEB.HDMIs[chan].Trim3.myFPGA = id;
                        FEB.HDMIs[chan].Bias.myFPGA = id;
                        FEB.HDMIs[chan].LED.myFPGA = id;
                        FEB.HDMIs[chan].Trim0.myFPGA = id;
                    } */


        /// <summary>
        /// Get voltage readings from the DMM for the list of signals requested.
        /// </summary>
        /// <param name="list">The TekScope.signalList to measure</param>
        /// <param name="NumberOfMeasurements">Number of measurements to take</param>
        /// <param name="registerSettingRef">Reference to the FPGA register for this measurement. Marks the measurement with the register setting</param>
        /// <param name="CycleTimeMin">The minimum time the measurements should be taken</param>
        /// <returns>a list of VoltageSignals containing the channel, FPGA, signal type, registerSettingRef and measurement data for each signal requested</returns>
        /*      public List<VoltageSignal> GetVoltages(List<int> list, int NumberOfMeasurements, MeasureType mType = MeasureType.ZeroAndNew, float CycleTimeMin = 0f)
              {
                  List<VoltageSignal> newVoltages = new List<VoltageSignal>();// the copy of new voltages returned
                  VoltageSignal next = new VoltageSignal();

                  foreach (int c in list)
                  {
                      for (int n = 0; n < NumberOfMeasurements; n++) // get the number of measurements in a round-robbin
                      {
                          next = DMMsignalLookup[c];
                          next = GetVoltage(next, 1, mType, CycleTimeMin);

                      }
                      newVoltages.Add(next);
                  }

                  return newVoltages;
              }
              */

        /// <summary>
        /// Get voltage readings from the DMM for signal requested.
        /// </summary>
        /// <param name="sig">the identification of the signal to measure</param>
        /// <param name="NumberOfMeasurements">Number of measurements to take</param>
        /// <param name="registerSettingRef">Reference to the FPGA register for this measurement. Marks the measurement with the register setting</param>
        /// <param name="CycleTimeMin">The minimum time the measurements should be taken</param>
        /// <returns>a list of VoltageSignals containing the channel, FPGA, signal type, registerSettingRef and measurement data for each signal requested</returns>
        //    public double GetVoltage(SignalMeasurement sig, int NumberOfMeasurements, MeasureType mType = MeasureType.ZeroAndNew, float CycleTimeMin = 0f)
        public static double GetVoltage(DMM sig)
        {
            double newVolts = 0;

            // if (mType == MeasureType.ZeroAndNew)
            //     sig.clear();
            string DMMcommand = "MEASure:VOLTage:DC? " + sig.myDmmVoltRange + ", " + ((double)(0.000001 * sig.myDmmVoltRange)).ToString() + ", (@" + sig.myDMMchannel + ")\n";
            //  for (int n = 0; n < NumberOfMeasurements; n++)
            //  {
            if (singleReadWrite(DMMcommand, out newVolts)) return newVolts;
            else return double.NaN;
            //  sig.Add(newVolts);
            //  }

            //    VoltageChangedEventsArgs onNewVolts = new VoltageChangedEventsArgs(true, sig.myDmm.myHDMIChannel, sig.myDmm.myFPGA, SignalType.Trim, sig.myMeasurements.measurements.ToArray());
            //    OnVoltageChanged?.Invoke(this, onNewVolts);

            return newVolts;
        }

        private static bool singleReadWrite(string command, out double newVoltage)
        {
            newVoltage = 0;
            try
            {
                string textToWrite = ReplaceCommonEscapeSequences(command);
                mbSession.RawIO.Write(textToWrite);

                string DMMresponse = "";
                int timeout = 0;

                while (DMMresponse == "" && timeout < 100)
                {
                    Application.DoEvents();
                    DMMresponse = mbSession.RawIO.ReadString();

                    timeout++;
                }

                Console.WriteLine($"simpleReadWrite timeout = {timeout}. DMM response is <{DMMresponse}>");
                DMMresponse = DMMresponse.TrimEnd('\r', '\n');

                if (DMMresponse != "")
                {
                    // readArgs e = new readArgs();
                    // e.text = InsertCommonEscapeSequences(DMMresponse);
                    double.TryParse(DMMresponse, out newVoltage);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return false;
            }
        }


        internal static void GetSignalList_test(List<int> list)
        {
            string range = "";
            foreach (int i in list)
                range += i + ",";
            range = range.TrimEnd(',');
            //CONFigure[:VOLTage][:DC][{< range >| AUTO | MIN | MAX | DEF} [,{<resolution>|MIN|MAX|DEF}] ]
            //MEAS: VOLT: DC ? 10,0.003,(@301)
            //"CONFigure:VOLTage:DC AUTO,0.0000022,(@" + range + ")\n"  "ABORt"
            write("ABORt\n");
            Thread.Sleep(500);
            //   write("*OPC ?\n");
            Thread.Sleep(500);
            write("CONFigure:VOLTage:DC MAX, DEF, (@" + range + ")\n");
            //write("CONF:VOLT:DC (@" + range + ")\n");
            Thread.Sleep(500);
            write("TRIG:COUNT 1\n");
            Thread.Sleep(500);
            //     write("*ESE 1\n");
            Thread.Sleep(500);
            //     write("*SRE 32\n");
            Thread.Sleep(500);
            write("INIT\n");
            //  Thread.Sleep(500);
            //     write("*OPC\n");
            Thread.Sleep(10000);
            //  string DMMresponse = "";

            /*   while (DMMresponse == "")
               {
                   DMMresponse = mbSession.RawIO.ReadString();
                   if (DMMresponse != "")
                       Console.Write($"got response <{DMMresponse}>");
               }*/
            write("FETCh?\n");
            WriteComplete += readVoltage;
            //  Thread.Sleep(20000);
            //  simpleReadWrite("FETCh?");
        }

        /*
                /// <summary>
                /// Requests all 6 voltage measurements for the specified FEB HDMI channel.
                /// <para>The voltage measurement is returned on onVoltageChanged event</para>
                /// <para>onVoltageChanged returns double[6] showing all 6 HDMI values in the order Trim0-Trim3, Bias, LED</para>
                /// <para>If inTestMode=true then onVoltageChanged is asserted with VoltageChangedEventArgs.Voltage = voltageDefaultValue</para>
                /// </summary>
                /// <param name="channelNumber">the integer number 0-15, of the FEB HDMI channel to read</param>
                internal void GetVoltage(int HDMIchannelNumber = 0)
                {
                    if (inTestMode)
                    {
                        VoltageChangedEventsArgs VoltArgs = new VoltageChangedEventsArgs();
                        if (OnVoltageChanged != null)
                            VoltArgs.HDMIchannel = HDMIchannelNumber;
                        OnVoltageChanged(this, VoltArgs);
                        return;
                    }

                    if (HDMIchannelNumber < 0 || HDMIchannelNumber > 15)
                        throw new Exception(scopeName + ": GetVoltage. channel number " + HDMIchannelNumber + " is out of bounds. Must be 0-15");

                    // For assistance with DMM VISA See: 
                    //https://www.keysight.com/upload/cmc_upload/All/iols_15_5_visa_users_guide.pdf
                    //https://literature.cdn.keysight.com/litweb/pdf/34972-90001.pdf?id=1837993
                    //https://www.keysight.com/upload/cmc_upload/All/34970-90003_users.pdf * best for programming
                    //http://instructor.physics.lsa.umich.edu/adv-labs/Tools_Resources/HP%2034970A%20quick%20reference%20guide.pdf
                    //http://literature.cdn.keysight.com/litweb/pdf/5989-6338EN.pdf
                    string range = FEB.HDMIs[HDMIchannelNumber].Trim0.myDmmId + ":" + FEB.HDMIs[HDMIchannelNumber].LED.myDmmId;

                    /*           bool useAsync = false;
                               if (useAsync == true) //use asyncornous read and write. This worked for the Tek scope but fails now that the DMM is reading ranges.
                               {
                                   write("MEASure:VOLTage:DC? (@" + range + ")\n"); // AUTO ,MAX, (@101)"); //,316)");
                                   WriteComplete += readVoltage;
                               }
                               else //use Sync read and write Added Jan 2017 Stephen to avoid errors with ivi.VISA
                               { */
        /*
simpleReadWrite("MEASure:VOLTage:DC? (@" + range + ")\n");
//   }
}
*/

        private static void simpleReadWrite(string command)
        {
            try
            {
                string textToWrite = ReplaceCommonEscapeSequences(command);
                mbSession.RawIO.Write(textToWrite);

                string DMMresponse = "";
                int timeout = 0;

                while (DMMresponse == "" && timeout < 100)
                {
                    Application.DoEvents();
                    DMMresponse = InsertCommonEscapeSequences(mbSession.RawIO.ReadString());
                    timeout++;
                }
                Console.WriteLine($"simpleReadWrite timeout = {timeout}. DMM response is <{DMMresponse}>");
                if (DMMresponse != "")
                {
                    readArgs e = new readArgs();
                    e.text = InsertCommonEscapeSequences(DMMresponse);
                    parseVoltage(null, e);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private static void readVoltage(object sender, EventArgs e)
        {
            WriteComplete -= readVoltage;
            ReadComplete += parseVoltage;
            read();
        }


        private static void parseVoltage(object sender, readArgs e)
        {
            VoltageChangedEventsArgs VoltArgs = new VoltageChangedEventsArgs();
            try
            {
                ReadComplete -= parseVoltage;
                //expected result = :MEASUREMENT:MEAS1:VALUE 3.5414E0\n
                string rawResponse = RemoveCommonEscapeSequences(e.text);
                string[] response = rawResponse.Split(',');
                VoltArgs.Voltage = new double[response.Length];
                for (int i = 0; i < response.Length; i++)
                {
                    VoltArgs.Voltage[i] = double.Parse(response[i]);
                }
                VoltArgs.isValid = (response.Length > 0); // 9.9E37 is the scope return value for invalid measurement.
            }
            catch (Exception arg)
            {
                VoltArgs.isValid = false;
            }
            OnVoltageChanged?.Invoke(null, VoltArgs);
        }

        private static string RemoveCommonEscapeSequences(string s)
        {
            return (s != null) ? s.Replace("\\n", "").Replace("\n", "").Replace("\\r", "").Replace("\r", "") : s;
        }

        private static string ReplaceCommonEscapeSequences(string s)
        {
            return (s != null) ? s.Replace("\\n", "\n").Replace("\\r", "\r") : s;
        }

        private static string InsertCommonEscapeSequences(string s)
        {
            return (s != null) ? s.Replace("\n", "\\n").Replace("\r", "\\r") : s;
        }

        public enum MeasureType
        {
            ZeroAndNew,
            AddToExisting
        }
    }



    public class DMM
    {
        public int myDMMchannel = 0;
        public int myDmmVoltRange = 1;
    }

    public class readArgs : EventArgs
    {
        public string text = "";
    }

    public class ConnectedStateEventArgs : EventArgs
    {
        public bool isConnected = false;

        public ConnectedStateEventArgs(bool NewConnectionState)
        {
            isConnected = NewConnectionState;
        }
    }

    public class VoltageChangedEventsArgs : EventArgs
    {
        /// <summary>
        /// If the read was successful. parsing errors or closed scope can cause failure
        /// </summary>
        public bool isValid = false;
        /// <summary>
        /// The channel generating the event
        /// </summary>
        public int HDMIchannel = 0; // the channel read

        /// <summary>
        /// The id number of the FPGA for this measurement
        /// </summary>
        public int FPGAid = 0;

        /// <summary>
        /// The type of signal this measurement represents.
        /// </summary>
        public SignalType signalType;

        /// <summary>
        /// The voltage measurement
        /// </summary>
        public double[] Voltage = { TekScope.voltageDefaultValue }; //voltage value
        public VoltageChangedEventsArgs()
        {

        }

        public VoltageChangedEventsArgs(bool valid, int HDMIChan, int fpgaId, SignalType sigTyp, double[] voltage)
        {
            isValid = valid;
            HDMIchannel = HDMIChan;
            FPGAid = fpgaId;
            signalType = sigTyp;
            Voltage = voltage;
        }
    }

}
