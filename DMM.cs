/*  class: DMM                                                                *
 *  namespace: mu2e.FEB_Test_Jig                                              *
 *                                                                            *
 *  A module for handling communication with the Keysight multi-channel DMM.  *
 *                                                                            *
 *  This module is modeled off of the TekScope module.                        *
 *                                                                            *
 *  Kreswell Neely, 2017-11-30                                                */

using System;
using NationalInstruments.Visa;
using System.Windows.Forms;

namespace mu2e.FEB_Test_Jig
{
    public class DMM
    {
        /// <summary>
        /// is asserted when the DMM connection changes
        /// </summary>
        public event EventHandler<ConnectedStateEventArgs> OnConnectedStateChanged;
        /// <summary>
        /// returns the voltage measurement after a call to GetVoltage(channelNumber)
        /// </summary>
        public event EventHandler<VoltageChangedEventsArgs> OnVoltageChanged;
        public delegate void VoltageChangedDeligate(object o, VoltageChangedEventsArgs args);
        /// <summary>
        /// Is returned as a VoltageChangedEventArg.voltage when GetVoltage(channelNumber) is called when no DMM is attached
        /// <para>This can be used for testing with out DMMs attached</para>
        /// </summary>
        public static double voltageDefaultValue = -5d;
        /// <summary>
        /// set inTestMode = true if no DMMs are connected. Open DMM will succeed, and GetVoltage(ChannelNumber) will retrun voltageDefaultValue.
        /// </summary>
        public bool inTestMode = false;

        private MessageBasedSession mbSession;

        private string _dmmName = "Default DMM name";
        public string dmmName
        {
            get { return _dmmName; }
            set { _dmmName = value.Trim(); }
        }

        private string _ResourceString = "";
        public string ResourceString
        {
            get
            {
                return _ResourceString;
            }
        }

        private bool _isConnected = false;

        /// <summary>
        /// true indicates the DMM is connected and can be used
        /// false indicates the DMM has not been set up or cannot be opened.
        /// Get a true value by calling OpenDMM or using the new constructor.
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

        private int _autoGetVoltageChannel = 1;
        private int currentChannelNumber = 1;
        private bool busy;

        private int autoVoltageChannel
        {
            get { return _autoGetVoltageChannel; }
            set
            {
                if (value > 4 || value < 1)
                    _autoGetVoltageChannel = 1;
                else
                    _autoGetVoltageChannel = value;
            }
        }

        // --- properties

        // +++ Constructors
        /// <summary>
        /// Starts a new DMM instance but does not attempt to open the DMM for use.
        /// <para>Call OpenDMM to start communications.</para>
        /// </summary>
        public DMM()
        {
            _isConnected = false;
        }

        /// <summary>
        /// Starts a new DMM instance and attempts to open the DMM for use.
        /// <para>If connection is a success then OnConnectedStateChanged will assert with arg isConnected = true;</para>
        /// <para>Otherwise, isConnected may be tested for connection state.</para>
        /// </summary>
        /// <param name="dmmName">A nickname for this DMM instance</param>
        /// <param name="ResourceString">VISA ID for the DMM resource. Optional. If blank, a dialog will allow the user to select a scope from the available scope resources. 
        /// <para>if used, this is a tektronix DMM resource string identifying a specific DMM that is known to be connected.</para>
        /// </param>
        public DMM(string dmmName, string ResourceString = null)
        {
            _isConnected = false;
            bool retval = OpenDMM(dmmName, ResourceString);
        }

        // --- Constructors

        public void Dispose()
        {
            if (mbSession != null)
            {
                mbSession.Dispose();
            }
        }

        public bool OpenDMM(string name, string lastResourceString = null)
        {
            bool open = false;

            dmmName = name;

            if (inTestMode) return true;

            using (SelectResource sr = new SelectResource(dmmName))
            {
                if (String.IsNullOrWhiteSpace(lastResourceString) || !(open = tryOpenVISA(lastResourceString)))
                {
                    DialogResult result = sr.ShowDialog();
                    _ResourceString = "";
                    if (result == DialogResult.OK)
                    {
                        if (!(open = tryOpenVISA(sr.ResourceName)))
                        {
                            MessageBox.Show(dmmName + " could not be opened when resource string " + lastResourceString + " or " + sr.ResourceName);
                        }
                    }
                }
            }
            return open;
        }

        private bool tryOpenVISA(string resourceString)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool result = false;
            try
            {
                using (var rmSession = new ResourceManager())
                {
                    mbSession = (MessageBasedSession)rmSession.Open(resourceString);
                    // Use SynchronizeCallbacks to specify that the object marshals callbacks across threads appropriately.
                    if (mbSession != null)
                    {
                        mbSession.SynchronizeCallbacks = true;
                        _isConnected = true;
                        _ResourceString = resourceString;
                        result = true;
                    }
                    else
                    {
                        _isConnected = false;
                    }
                }
            }
            catch (Exception exp)
            {
                _ResourceString = "";
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return result;
        }

        /// <summary>
        /// Close this DMM instance. 
        /// <para>OnConnectedStateChanged will assert with isConnected = false</para>
        /// </summary>
        public void closeDMM()
        {
            if (!inTestMode && mbSession != null)
            {
                _isConnected = false;
                mbSession.Dispose();
            }
        }

        /// <summary>
        /// Requests a voltage measurement from the next channel. mulitple calls will loop through all channels
        /// <para>The voltage measurement is returned on onVoltageChanged event</para>
        /// <para>If inTestMode=true then onVoltageChanged is asserted with VoltageChangedEventArgs.Voltage = voltageDefaultValue</para>
        /// </summary>
        /// <returns>VoltageChangedEventsArgs containing voltage value, isValid, and channel number</returns>
        internal VoltageChangedEventsArgs GetVoltage()
        {
            return GetVoltage(autoVoltageChannel++);
        }

        /*  THIS IS A SECTION THAT WILL NEED TO BE UPDATED!!
         *  THE mbSession.RawIO FUNCTIONS NEED TO COMMUNICATE WITH THE NEW DMM.
         *  THE CODE WILL ALSO NEED TO BE UPDATED TO EXPECT THE CORRECT CHANNEL NUMBERS.
         *  */
        /// <summary>
        /// Requests a voltage measurement from the specified channel.
        /// <para>The voltage measurement is returned on onVoltageChanged event</para>
        /// <para>If inTestMode=true then onVoltageChanged is asserted with VoltageChangedEventArgs.Voltage = voltageDefaultValue</para>
        /// </summary>
        /// <param name="channelNumber">the integer number 1-4, of the DMM channel to read</param> 
        /// <returns>VoltageChangedEventsArgs containing voltage value, isValid, and channel number</returns>
        internal VoltageChangedEventsArgs GetVoltage(int channelNumber)
        {
            //make sure we are thread safe crudely
            int t = 0;
            while (busy)
            {
                if (t++ > 9999)
                {
                    throw new Exception(dmmName + ": GetVoltage. channel number " + channelNumber + " timed out while waiting for access to the DMM");
                }
            }
            busy = true;

            //set the default return value
            currentChannelNumber = channelNumber;
            VoltageChangedEventsArgs VoltArgs = new VoltageChangedEventsArgs();
            VoltArgs.channel = channelNumber;

            // verify channel number is valid
            if (channelNumber < 1 || channelNumber > 4)
                throw new Exception(dmmName + ": GetVoltage. channel number " + channelNumber + " is out of bounds. Must be 1-4");

            //check for test mode
            if (inTestMode)
            {
                OnVoltageChanged?.Invoke(this, VoltArgs);
                return VoltArgs; // skip out of the rest.
            }

            //Request the voltage from the DMM
            string dmmMsg = "";
            try
            {
                mbSession.RawIO.Write(ReplaceCommonEscapeSequences("MEASUrement:MEAS" + channelNumber + ":VALue?"));

                t = 0;
                while ((dmmMsg = mbSession.RawIO.ReadString()) == "")
                {
                    if (t++ > 9999)
                        throw new Exception(dmmName + ": GetVoltage. channel number " + channelNumber + " read request timed out");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(dmmName + ".GetVoltage exception: " + exp.Message + " " + exp.InnerException);
            }

            // parse the DMM message
            try
            {
                if (double.TryParse(dmmMsg, out VoltArgs.Voltage))
                { //tekScope version 3.41 only returns the voltage value
                    VoltArgs.channel = currentChannelNumber;
                    VoltArgs.isValid = VoltArgs.Voltage != 9.9E37d;
                }
                else
                { //tekScope version 3.27 returns a voltage string including the channel read
                    string[] response = dmmMsg.Split(':');
                    string channel = response[2].Replace("MEAS", "").Trim();
                    VoltArgs.channel = int.Parse(channel);
                    string[] value = response[3].Split(' ');
                    string voltage = value[1].Trim();
                    VoltArgs.Voltage = double.Parse(voltage);
                    VoltArgs.isValid = !(voltage == "9.9E37"); // 9.9E37 is the DMM return value for invalid measurement.
                }
            }
            catch (Exception arg)
            {
                VoltArgs.isValid = false;
            }
            OnVoltageChanged?.Invoke(this, VoltArgs);

            busy = false;
            return VoltArgs;
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
        public int channel = 0; // the channel read
        /// <summary>
        /// The voltage measurement
        /// </summary>
        public double Voltage = DMM.voltageDefaultValue; //voltage value
    }
}
