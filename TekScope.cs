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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Ivi.Visa;
using NationalInstruments.Visa;

namespace mu2e.FEB_Test_Jig
{
    class TekScope
    {
        /// <summary>
        /// likely not needed. This is asserted when the write command is completed. This is exposed publicly only for testing.
        /// </summary>
        public event EventHandler WriteComplete;
        /// <summary>
        /// likely not needed. This is asserted when the read command is completed. This is exposed publicly only for testing.
        /// </summary>
        public event EventHandler<readArgs> ReadComplete;
        /// <summary>
        /// is asserted when the scope connection changes
        /// </summary>
        public event EventHandler<ConnectedStateEventArgs> OnConnectedStateChanged;
        /// <summary>
        /// returns the voltage measurement after a call to GetVoltage(channelNumber)
        /// </summary>
        public event EventHandler<VoltageChangedEventsArgs> OnVoltageChanged;
        /// <summary>
        /// Is returned as a VoltageChangedEventArg.voltage when GetVoltage(channelNumber) is called when no scope is attached
        /// <para>This can be used for testing with out scopes attached</para>
        /// </summary>
        public static double voltageDefaultValue = -5d;
        /// <summary>
        /// set inTestMode = true if no scopes are connected. Open scope will succeed, and GetVoltage(ChannelNumber) will retrun voltageDefaultValue.
        /// </summary>
        public bool inTestMode = false;
        
        private MessageBasedSession mbSession;
        private IVisaAsyncResult asyncHandle = null;

        /// <summary>
        /// FEBchan is a helper struct, mapping FEB channels to the DMM channels that are measuring the voltage
        /// Choosing the signal in this channel provides the integer value of the DMM channel to read for this siganl.
        /// </summary>
        public struct FEBchan
        {
            /// <summary>
            /// J refers to the actual HDMI refernce designator value on the FEB PCB. Valid values: J11-J26
            /// </summary>
            public int J;
            /// <summary>
            /// Trim0 is the first signal for this FEB channel. LED is the last.
            /// </summary>
            public int Trim0;
            public int Trim1;
            public int Trim2;
            public int Trim3;
            public int Bias;
            /// <summary>
            /// LED is the last signal for this FEB channel. Trim0 is the first.
            /// </summary>
            public int LED;
        }
        /// <summary>
        /// FEBchan[16] is a helper array, mapping FEB channels to the DMM channels that are measuring the voltage
        /// Choosing the FEB channel (0-16) then choosing the signal in this channel 
        /// provides the integer value of the DMM channel to read for the siganl in this channel.
        /// </summary>
        public FEBchan[] FEBchannel = new FEBchan[16];

        // +++ properties 
        private string _scopeName = "Agilent 37970A DMM";
        public string scopeName { 
            get { return _scopeName; } 
            set { _scopeName = value.Trim(); }
        }

        private bool _isConnected = false;
       
        /// <summary>
        /// true indicates the scope is connected and can be used
        /// false indicates the scope has not been set up or cannot be opened.
        /// Get a true value by calling OpenScope or using the new constructor.
        /// </summary>
        public bool isConnected
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
                    if (OnConnectedStateChanged != null)
                    {
                        // raise the state changed event with the new value
                        OnConnectedStateChanged(this, new ConnectedStateEventArgs(value));
                    }
                }
            }
        }

        //++++ Helper property to assign DMM channels only no other use.
        private int _DMMchan = 100; // channel 101 is the first. but each get increments by one.
        /// <summary>
        /// Only used to assign DMM channel references at start up. no other use.
        /// </summary>
        private int DMMchan { get
            {
                if (_DMMchan == 140) { _DMMchan = 201; } // jump to the second module
                else if (_DMMchan == 240) { _DMMchan = 301; } // jump to the third module
                else _DMMchan++; //increment by one
                return _DMMchan;
            }  }
        //---- Helper DMM property
        // --- properties

        // +++ Constructors
        /// <summary>
        /// Starts a new scope instance but does not attempt to open the scope for use.
        /// <para>Call OpenScope to start communications.</para>
        /// </summary>
        public TekScope()
        {
            assignDMMchannels();
            OpenScope(scopeName);
        }

        private void assignDMMchannels()
        {
            //populate the references to the DMM channels
            int connector = 11;
            for (int chan = 0; chan < 16; chan++)
            {
                FEBchannel[chan].J = connector++;
                FEBchannel[chan].Trim0 = DMMchan;
                FEBchannel[chan].Trim1 = DMMchan;
                FEBchannel[chan].Trim2 = DMMchan;
                FEBchannel[chan].Trim3 = DMMchan;
                FEBchannel[chan].Bias = DMMchan;
                FEBchannel[chan].LED = DMMchan;
            }
        }

        /// <summary>
        /// Starts a new scope instance and attempts to open the scope for use.
        /// <para>If connection is a success then OnConnectedStateChanged will assert with arg isConnected = true;</para>
        /// <para>Otherwise, isConnected may be tested for connection state.</para>
        /// </summary>
        /// <param name="scopeName">A nickname for this scope instance</param>
        /// <param name="lastResourceString">Optional. If blank, a dialog will allow the user to select a scope from the available scope resources. 
        /// <para>if used, this is a tektronix scope resource string identifying a specific scope that is known to be connected.</para>
        /// </param>
        public TekScope(string scopeName, string lastResourceString = null)
        {
            assignDMMchannels();
            OpenScope(scopeName, lastResourceString);
        }
        // --- Constructors

        public void Dispose()
        {
            if (mbSession != null)
            {
                mbSession.Dispose();
            }
        }

        public bool OpenScope(string name, string lastResourceString = "ASRL1::INSTR")
        {
            bool open = false;

            scopeName = name;

            if (inTestMode) return true;

            using (SelectResource sr = new SelectResource( scopeName, lastResourceString))
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
                    if(sr!= null) sr.Close();
                    lastResourceString = sr.ResourceName;
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        using (var rmSession = new ResourceManager())
                        {
                            mbSession = (MessageBasedSession)rmSession.Open(lastResourceString);

                            ISerialSession serial = mbSession as ISerialSession;

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

                            //CONFigure[:VOLTage][:DC][{< range >| AUTO | MIN | MAX | DEF} [,{<resolution>|MIN|MAX|DEF}] ]
                            write("CONFigure:VOLTage:DC AUTO, (@101:316)\n"); 

                           // write("SENSe:VOLTage:DC:NPLC1,(@101:316)");
                            _isConnected = true;
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            return open;
        }

        void mbSession_ServiceRequest(object sender, VisaEventArgs e)
        {
            throw new NotImplementedException("arrived at service request");
        }

        /// <summary>
        /// Close this scope instance. 
        /// <para>OnConnectedStateChanged will assert with isConnected = false</para>
        /// </summary>
        public void closeScope()
        {
            if (!inTestMode)
            {
                _isConnected = false;
                mbSession.Dispose();
            }
        }


        internal void write(string command)
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

        private void OnWriteComplete(IVisaAsyncResult result)
        {
            try
            {

                mbSession.RawIO.EndWrite(result);

                if (WriteComplete != null)
                {
                    WriteComplete(this, default(EventArgs));
                }
            }

            catch (Exception exp)
            {
              //  throw new Exception(scopeName + ": OnWriteComplete failed. " + exp.Message);
            }
        }


        internal void read()
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

        private void OnReadComplete(IVisaAsyncResult result)
        {
            try
            {
                string responseString = mbSession.RawIO.EndReadString(result);
                if (ReadComplete != null)
                {
                    readArgs e = new readArgs();
                    e.text = InsertCommonEscapeSequences(responseString);
                    ReadComplete(this, e);
                }

            }
            catch (Exception exp)
            {
                if (ReadComplete != null)
                {
                    readArgs e = new readArgs();
                    e.text = InsertCommonEscapeSequences(scopeName + ": OnReadComplete failed. " + exp.Message);
                    ReadComplete(this, e);
                }
                else
                {
                    //throw new Exception(scopeName + ": OnReadComplete failed. " + exp.Message);
                }
            }
        }


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
                    VoltArgs.channel = HDMIchannelNumber;
                    OnVoltageChanged(this, VoltArgs);
                return;
            }

            if (HDMIchannelNumber < 0 || HDMIchannelNumber > 15 )
                throw new Exception(scopeName + ": GetVoltage. channel number " + HDMIchannelNumber + " is out of bounds. Must be 0-15" );

            // For assistance with DMM VISA See: 
            //https://www.keysight.com/upload/cmc_upload/All/iols_15_5_visa_users_guide.pdf
            //https://literature.cdn.keysight.com/litweb/pdf/34972-90001.pdf?id=1837993
            //https://www.keysight.com/upload/cmc_upload/All/34970-90003_users.pdf
            //http://instructor.physics.lsa.umich.edu/adv-labs/Tools_Resources/HP%2034970A%20quick%20reference%20guide.pdf
            //http://literature.cdn.keysight.com/litweb/pdf/5989-6338EN.pdf
            string range =  FEBchannel[HDMIchannelNumber].Trim0 + ":" + FEBchannel[HDMIchannelNumber].LED;
            write("MEASure:VOLTage:DC? (@"+ range +")\n"); // AUTO ,MAX, (@101)"); //,316)");
            WriteComplete += readVoltage;

//TODO: enter message queue required to read voltage.
}

private void readVoltage(object sender, EventArgs e)
{
WriteComplete -= readVoltage;
ReadComplete += parseVoltage;
read();
}

private void parseVoltage(object sender, readArgs e)
{
VoltageChangedEventsArgs VoltArgs = new VoltageChangedEventsArgs();
try
{
    ReadComplete -= parseVoltage;
    //expected result = :MEASUREMENT:MEAS1:VALUE 3.5414E0\n
    string rawResponse = RemoveCommonEscapeSequences(e.text);
    string[] response = rawResponse.Split(',');
    VoltArgs.Voltage = new double[response.Length];
                for( int i = 0; i < response.Length; i++)
                {
                    VoltArgs.Voltage[i] = double.Parse(response[i]);
                }
    VoltArgs.isValid = (response.Length > 0); // 9.9E37 is the scope return value for invalid measurement.
}
catch(Exception arg)
{
    VoltArgs.isValid = false;
}
if (OnVoltageChanged != null)
        OnVoltageChanged(this, VoltArgs);
}

private string RemoveCommonEscapeSequences(string s)
{
return (s != null) ? s.Replace("\\n", "").Replace("\n", "").Replace("\\r", "").Replace("\r", "") : s;
}

private string ReplaceCommonEscapeSequences(string s)
{
return (s != null) ? s.Replace("\\n", "\n").Replace("\\r", "\r") : s;
}

private string InsertCommonEscapeSequences(string s)
{
return (s != null) ? s.Replace("\n", "\\n").Replace("\r", "\\r") : s;
} 
}

public class readArgs : EventArgs
{
public string text = "";
}

public class ConnectedStateEventArgs : EventArgs
{
public bool isConnected = false;

public ConnectedStateEventArgs(bool NewConnectionState){
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
public int channel = 0; // the channel read
/// <summary>
/// The voltage measurement
/// </summary>
public double[] Voltage = { TekScope.voltageDefaultValue }; //voltage value
}
}
