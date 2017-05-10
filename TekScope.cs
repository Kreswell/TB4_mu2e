﻿    /*
     * class TecScope
     * namespace mu2e.FEB_Test_Jig

private TekScope ScopeTrim = new TekScope(); constructor opens a window allowing the user to select the VISA resource for a scope. You will need to make two TekScope instances. I suggest: ScopeTrim and ScopeBias. 

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
        public bool inTestMode = true;
        
        private MessageBasedSession mbSession;
        private IVisaAsyncResult asyncHandle = null;

        // +++ properties 
        private string _scopeName = "Default scope name";
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
        // --- properties

        // +++ Constructors
        /// <summary>
        /// Starts a new scope instance but does not attempt to open the scope for use.
        /// <para>Call OpenScope to start communications.</para>
        /// </summary>
        public TekScope()
        {
            _isConnected = false;
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
            _isConnected = false;
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

        public bool OpenScope(string name, string lastResourceString = null)
        {
            bool open = false;

            scopeName = name;

            if (inTestMode) return true;

            using (SelectResource sr = new SelectResource( scopeName ))
            {
                if (lastResourceString != null)
                {
                    sr.ResourceName = lastResourceString;
                }
                DialogResult result = sr.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lastResourceString = sr.ResourceName;
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        using (var rmSession = new ResourceManager())
                        {
                            mbSession = (MessageBasedSession)rmSession.Open(sr.ResourceName);
                            // Use SynchronizeCallbacks to specify that the object marshals callbacks across threads appropriately.
                            mbSession.SynchronizeCallbacks = true;
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
        /// Requests a voltage measurement from the channel.
        /// <para>The voltage measurement is returned on onVoltageChanged event</para>
        /// <para>If inTestMode=true then onVoltageChanged is asserted with VoltageChangedEventArgs.Voltage = voltageDefaultValue</para>
        /// </summary>
        /// <param name="channelNumber">the integer number 1-4, of the scope channel to read</param>
        internal void GetVoltage(int channelNumber = 1)
        {
            if (inTestMode)
            {
                VoltageChangedEventsArgs VoltArgs = new VoltageChangedEventsArgs();
                if (OnVoltageChanged != null)
                    VoltArgs.channel = channelNumber;
                    OnVoltageChanged(this, VoltArgs);
                return;
            }

            if (channelNumber < 1 || channelNumber > 4 )
                throw new Exception(scopeName + ": GetVoltage. channel number " + channelNumber + " is out of bounds. Must be 1-4" );

            write("MEASUrement:MEAS" + channelNumber + ":VALue?");
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
                string[] response = rawResponse.Split(':');
                string channel = response[2].Replace("MEAS","").Trim();
                VoltArgs.channel = int.Parse(channel);
                string[] value = response[3].Split(' ');
                string voltage = value[1].Trim();
                VoltArgs.Voltage = double.Parse(voltage);
                VoltArgs.isValid = !(voltage == "9.9E37"); // 9.9E37 is the scope return value for invalid measurement.
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
        public double Voltage = TekScope.voltageDefaultValue; //voltage value
    }
}
