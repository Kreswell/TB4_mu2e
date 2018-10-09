using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.ComponentModel;
using ZedGraph;

namespace TB_mu2e
{
    public class Mu2e_FEB_client : IStenComms
    {
        #region InterfaceStenComms
        public string m_prop { get { return m; } set { m = value; } }
        public string name { get { return _logical_name; } set { _logical_name = value; } }
        public string host_name_prop { get { return _host_name; } set { _host_name = value; } }
        public TcpClient client_prop { get { return client; } }
        public Socket TNETSocket_prop { get { return TNETSocket; } }
        public NetworkStream stream_prop { get { return stream; } }
        public StreamReader SR_prop { get { return SR; } }
        public StreamWriter SW_prop { get { return SW; } }
        public int max_timeout_prop { get { return max_timeout; } set { max_timeout = value; } }
        public int timeout_prop { get { return timeout; } set { timeout_prop = timeout; } }
        bool IStenComms.ClientOpen { get { return _ClientOpen; } set { } }

        public void DoOpen() { Open(); }
        #endregion InterfaceStenComms

        public string m;
        private string _host_name;
        private string _logical_name;
        private bool _ClientOpen = false;
        private bool _ClientBusy = true;
        private string _TNETname;

        public int _TNETsocketNum = 0;
        public TcpClient client;
        public Socket TNETSocket;
        public NetworkStream stream;
        public StreamReader SR;
        public StreamWriter SW;
        public int max_timeout;
        public int timeout;
        public List<Mu2e_Register> arrReg;
        public string _FEBserialNum;

        // events 
        //public delegate void cOpening();
        //public event cOpening ClientOpening;

        public Mu2e_FEB_client() //construct
        {
            AddRegisters.add_FEB_reg(out arrReg);
        }

        public bool ClientOpen { get { return _ClientOpen; } }
        public bool ClientBusy { get { return _ClientBusy; } set { _ClientBusy = value; } }
        public int TNETsocketNum { get { return _TNETsocketNum; } set { _TNETsocketNum = value; } }
        public string FEBserialNum { get { return _FEBserialNum; } set { _FEBserialNum = value; } }


        public void Open()
        {
            _ClientOpen = false;
            try
            {
                client = new TcpClient();
                TNETSocket = client.Client;
                TNETSocket.ReceiveBufferSize = 1500000;
                TNETSocket.SendBufferSize = 32000;
                TNETSocket.ReceiveTimeout = 1;
                TNETSocket.SendTimeout = 1;
                TNETSocket.NoDelay = true;
                TNETSocket.Connect(_host_name, _TNETsocketNum + 5000);

                //Thread.Sleep(100);
                _ClientOpen = true;
                m = "connected " + _logical_name + " to " + _host_name + " on port " + (TNETsocketNum + 5000);
            }
            catch
            {
                _TNETsocketNum++;
                if (_TNETsocketNum < 2)
                {
                    this.Open();
                }
                else
                {
                    _ClientOpen = false;
                    return;
                }
            }

        }


        public void SetV(double V, int fpga = 0)
        {
            UInt32 counts;
            //double t = V / 5.38 * 256;
            double t = V * 50;
            t = System.Math.Round(t);
            try { counts = Convert.ToUInt32(t); }
            catch { counts = 0; }
            //string a= ????
            SendStr("wr " + Convert.ToString(4 * fpga, 16) + "44 " + Convert.ToString(counts, 16));
            Thread.Sleep(5);
            SendStr("wr " + Convert.ToString(4 * fpga, 16) + "45 " + Convert.ToString(counts, 16));
        }

        public double ReadV(int fpga = 0)
        {
            if (fpga > 3) { fpga = 0; }
            UInt32 counts;
            string a;
            int r;
            double V;
            SendStr("rd " + Convert.ToString(4 * fpga, 16) + "44");
            ReadStr(out a, out r);
            if (a.Length > 4)
            { a = a.Substring(0, 4); }

            try { V = (double)Convert.ToInt32(a, 16); }
            catch { V = 0; }
            //double t = V * 5.38 / 256;
            double t = V * 0.02;
            //t = System.Math.Round(t*1000)/1000;

            return t;
        }

        public double ReadA0(int fpga = 0, int ch = 0)
        {
            int dt;
            string t;
            if (ch == 0)
            { SendStr("wr " + Convert.ToString(4 * fpga, 16) + "20 10"); }
            else
            {
                if (ch < 16)
                {
                    string sch = Convert.ToString(ch, 16);
                    SendStr("wr " + Convert.ToString(4 * fpga, 16) + "20 1" + sch);
                }
            }
            Thread.Sleep(20);
            SendStr("gain 8");
            Thread.Sleep(20);
            ReadStr(out t, out dt, 100);
            SendStr("A0 2");
            Thread.Sleep(250);
            ReadStr(out t, out dt, 100);
            char[] sep = new char[3];
            sep[0] = ' ';
            sep[1] = '\r';
            sep[2] = '\n';
            string[] tok = t.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            double adc;
            try { adc = Convert.ToDouble(tok[2]); }
            catch { adc = -1; }
            if (adc > 4.096) { adc = 8.192 - adc; }
            double I = adc / 8 * 250;
            //for (int i = 0; i < tok.Length; i++)
            { SendStr("wr " + Convert.ToString(4 * fpga, 16) + "20 00"); }
            return I;
        }

        public bool GetReady()
        {
            string t = "";
            if (_ClientOpen)
            {
                if (TNETSocket.Available > 0)
                {
                    Thread.Sleep(1);
                    byte[] buf = new byte[TNETSocket.Available];
                    TNETSocket.Receive(buf);
                }
                t = "DREC\r\n";
                SendStr(t);
                t = "TRIG 0\r\n";
                SendStr(t);
                t = "WR 0 3C\r\n";
                SendStr(t);
            }
            return true;
        }

        public bool Arm()
        {
            return true;
        }

        public bool Disarm()
        {
            string t = "TRIG 0\r\n";
            if (_ClientOpen)
            {

                if (TNETSocket.Available > 0)
                {
                    Thread.Sleep(1);
                    byte[] buf = new byte[TNETSocket.Available];
                    TNETSocket.Receive(buf);
                }
                SendStr(t);
            }
            //SW.WriteLine("disarm");
            //timeout = 0;
            //while ((SR.ReadLine() != "disarm") && (timeout < max_timeout)) { System.Threading.Thread.Sleep(1); timeout++; }
            //if (timeout < max_timeout) { return true; } else { return false; }
            return true;
        }

        public bool SoftwareTrig()
        {
            SW.WriteLine("trig");
            timeout = 0;
            while ((SR.ReadLine() != "trig") && (timeout < max_timeout)) { System.Threading.Thread.Sleep(1); timeout++; }
            if (timeout < max_timeout) { return true; } else { return false; }
        }

        //public bool ReadN(int n)
        //{
        //    SW.WriteLine("read " + n.ToString());
        //    timeout = 0;
        //    while ((SR.ReadLine().Contains("read") == false) && (timeout < max_timeout)) { System.Threading.Thread.Sleep(1); timeout++; }
        //    if (timeout < max_timeout) { return true; } else { return false; }

        //}

        //public bool ReadAll(ref mu2e_Event this_e, ref  TcpClient myclient)
        //{
        //    bool event_complete = false;
        //    List<byte> buf = new List<byte>(15000);
        //    List<byte> rlbuf = new List<byte>(1500);
        //    byte[] rbuf = new byte[1500];
        //    int num_av_tot = 0;
        //    int num_av = 0;
        //    timeout = 200;
        //    if (_ClientOpen)
        //    {
        //        if (TNETSocket.Available > 0)
        //        {
        //            Thread.Sleep(1);
        //            rbuf = new byte[TNETSocket.Available];
        //            TNETSocket.Receive(rbuf);
        //        }

        //        //Mu2e_Register read_point_reg;
        //        //Mu2e_Register.FindAddr(5, ref this.arrReg, out read_point_reg);

        //        //Mu2e_Register.WriteReg(0, ref read_point_reg, ref myclient);

        //        TNETSocket.ReceiveBufferSize = 8000000; //eight million!
        //        TNETSocket.ReceiveTimeout = 200;


        //        Thread.Sleep(5);
        //        num_av_tot = 0;

        //        long l = 0;
        //        TCP_reciever.ReadFeb(myclient.Client, out buf, out l);

        //        //List<mu2e_Event> this_spill = new List<mu2e_Event>();
        //        //ParseInput(buf, ref this_spill, ref event_complete);

        //        Console.WriteLine("got " + l.ToString());
        //    }

        //    return true;
        //}

        public bool CheckStatus(out uint spill_state, out uint spill_num, out uint trig_num)
        {
            Mu2e_Register reg_spill_state;
            Mu2e_Register.FindAddr(0x76, ref arrReg, out reg_spill_state);
            Mu2e_Register reg_spill_num;
            Mu2e_Register.FindAddr(0x68, ref arrReg, out reg_spill_num);
            Mu2e_Register reg_trig_count;
            Mu2e_Register.FindAddr(0x67, ref arrReg, out reg_trig_count);

            Mu2e_Register.ReadReg(ref reg_spill_state, ref client);
            Mu2e_Register.ReadReg(ref reg_spill_num, ref client);
            Mu2e_Register.ReadReg(ref reg_trig_count, ref client);

            spill_state = reg_spill_state.val;
            spill_num=reg_spill_num.val;
            trig_num=reg_trig_count.val;
            return true;
        }

        public bool Clear()
        {
            SW.WriteLine("clear");
            timeout = 0;
            while ((SR.ReadLine() != "clear") && (timeout < max_timeout)) { System.Threading.Thread.Sleep(1); timeout++; }
            if (timeout < max_timeout) { return true; } else { return false; }
        }

        public bool ReadCMB_SN(int FPGAnum, int CMB_num, out string CMB_ROM)
        {
            CMB_ROM = "";
            try
            {
                if (_ClientOpen)
                {
                    Mu2e_Register CMB_set; //addr25
                    Mu2e_Register.FindAddr(0x25, ref this.arrReg, out CMB_set);
                    Mu2e_Register CMB_cmnd; //addr24
                    Mu2e_Register.FindAddr(0x24, ref this.arrReg, out CMB_cmnd);
                    Mu2e_Register CMB_read; //addr26
                    Mu2e_Register.FindAddr(0x26, ref this.arrReg, out CMB_read);

                    try
                    {
                        if (FPGAnum < 4)
                        {
                            CMB_set.fpga_index = Convert.ToUInt16(FPGAnum);
                            CMB_cmnd.fpga_index = Convert.ToUInt16(FPGAnum);
                            CMB_read.fpga_index = Convert.ToUInt16(FPGAnum);
                        }
                    }
                    catch { }

                    switch (CMB_num)
                    {
                        case 0:
                            Mu2e_Register.WriteReg(1, ref CMB_set, ref client);
                            break;
                        case 1:
                            Mu2e_Register.WriteReg(2, ref CMB_set, ref client);
                            break;
                        case 2:
                            Mu2e_Register.WriteReg(4, ref CMB_set, ref client);
                            break;
                        case 3:
                            Mu2e_Register.WriteReg(8, ref CMB_set, ref client);
                            break;
                        default:
                            Mu2e_Register.WriteReg(1, ref CMB_set, ref client);
                            break;
                    }
                    Mu2e_Register.WriteReg(0x200, ref CMB_cmnd, ref client);

                    SendStr("rdi 26");
                    string t = "";
                    int rt = 0;
                    ReadStr(out t, out rt);
                    CMB_ROM = t;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        public bool ReadCMB(out string CMB_Disp)
        {
            CMB_Disp = "";
            try
            {
                if (_ClientOpen)
                {
                    SendStr("cmb");
                    string t = "";
                    int rt = 0;
                    ReadStr(out t, out rt);
                    CMB_Disp = t;
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public uint[] ReadHisto(uint sipm, uint afe, uint fpga)
        {
            string writecmd = "";
            string readcmd = "";
            string fpgaPrefix = "";
            uint[] Histo = new uint[512];
            if (_ClientOpen)
            {
                string HistoStr = "";
                string[] delimiters = new string[] { " ", "\r", "\n", ">" };
                if (fpga == 0)
                { fpgaPrefix = "0"; }
                else if (fpga == 1)
                { fpgaPrefix = "4"; }
                else if (fpga == 2)
                { fpgaPrefix = "8"; }
                else if (fpga == 3)
                { fpgaPrefix = "c"; }
                else { }
                writecmd = "wr " + fpgaPrefix + Convert.ToString(13 + afe) + " 0";
                readcmd = "rdm " + fpgaPrefix + Convert.ToString(15 + afe) + " 400";
                SendStr(writecmd);
                SendStr(readcmd);
                System.Threading.Thread.Sleep(100);
                int rt = 0;
                ReadStr(out HistoStr, out rt);
                string[] SplitHistoStr = HistoStr.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                int imax = SplitHistoStr.Length > 1024 ? 512 : SplitHistoStr.Length / 2;
                for (int i = 0; i < imax; i++)
                {
                    if (SplitHistoStr[i].StartsWith(">"))
                    {
                        SplitHistoStr[i].Remove(0, 1);
                    }
                    string UpperStr = "0";
                    string UpperStrShifted = "0";
                    string LowerStr = "0";
                    UpperStr = SplitHistoStr[2 * i];
                    UpperStrShifted = UpperStr + "0000";
                    LowerStr = SplitHistoStr[(2 * i) + 1];
                    uint UpperBits = uint.Parse(UpperStr, System.Globalization.NumberStyles.HexNumber);
                    uint LowerBits = uint.Parse(LowerStr, System.Globalization.NumberStyles.HexNumber);

                    Histo[i] = UpperBits + LowerBits;
                }
            }
            else
            {
                for (int i = 0; i < 512; i++)
                {
                    Histo[i] = 0;
                }
            }
            return Histo;
        }

        //public bool ReadHisto(int channel, out uint[] Histo)
        //{
        //    uint[] HistoVals = new uint[512];
        //    try
        //    {
        //        if (_ClientOpen)
        //        {
        //            if (channel < 8)
        //            {
        //                SendStr("wr 14 0");
        //                SendStr("rdm 16 400");
        //            }
        //            else if (8 <= channel && channel < 16)
        //            {
        //                SendStr("wr 15 0");
        //                SendStr("rdm 17 400");
        //            }
        //            else { }
        //            string HistoStr = "";
        //            int rt = 0;
        //            ReadStr(out HistoStr, out rt);
        //            string[] SplitHistoStr = HistoStr.Split(null);
        //            for (int i = 0; i < 512; i++)
        //            {
        //                string UpperStr = SplitHistoStr[2 * i] + "0000";
        //                uint UpperBits = uint.Parse(UpperStr, System.Globalization.NumberStyles.HexNumber);
        //                uint LowerBits = uint.Parse(SplitHistoStr[(2 * i) + 1], System.Globalization.NumberStyles.HexNumber);
        //                HistoVals[i] = UpperBits + LowerBits;
        //            }
        //            Histo = HistoVals;
        //            return true;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < 512; i++)
        //            {
        //                HistoVals[i] = 0;
        //            }
        //            Histo = HistoVals;
        //            return false;
        //        }
        //    }
        //    catch
        //    {
        //        for (int i = 0; i < 512; i++)
        //        {
        //            HistoVals[i] = 0;
        //        }
        //        Histo = HistoVals;
        //        return false;
        //    }
        //    //return Histo;
        //}

        public string SendRead(string lin)
        {
            string lout;
            if (_ClientOpen)
            {
                SW.WriteLine(lin);
                System.Threading.Thread.Sleep(50);
                if (TNETSocket.Available > 0)
                {
                    byte[] rec_buf = new byte[TNETSocket.Available];
                    Thread.Sleep(10);
                    int ret_len = TNETSocket.Receive(rec_buf);
                    lout = PP.GetString(rec_buf, ret_len);
                    return lout;
                }
                else
                {
                    return ("!error! timeout");
                }
            }
            else { return null; }
        }

        public void SendStr(string t)
        {
            if (_ClientOpen)
            {
                if (TNETSocket.Available > 0)
                {
                    Thread.Sleep(1);
                    byte[] buf = new byte[TNETSocket.Available];
                    TNETSocket.Receive(buf);
                }
                // ? why does this not work? SW.WriteLine(t);
                //byte[] b = PP.GetBytes(t + Convert.ToChar((byte)0x0d));
                byte[] b = PP.GetBytes(t + "\r");
                TNETSocket.Send(b);
            }
        }

        public void ReadStr(out string t, out int ret_time, int tmo = 100)
        {
            t = "";
            bool tmo_reached = false;
            int this_t = 0;
            if (_ClientOpen)
            {
                DateTime s = DateTime.Now;
                while (TNETSocket.Available == 0 && !tmo_reached)
                {
                    Thread.Sleep(5);
                    this_t += 5;
                    if (this_t > tmo) { tmo_reached = true; }
                }
                if (!tmo_reached)
                {
                    byte[] rec_buf = new byte[TNETSocket.Available];
                    Thread.Sleep(10);
                    int ret_len = TNETSocket.Receive(rec_buf);
                    t = PP.GetString(rec_buf, ret_len);
                }
            }
            ret_time = this_t;
        }

        //public  static int GetStatus(out string[] status)
        //{
        //    string[] n = new string[10];
        //    n[0] = "";
        //    n[1] = "";
        //    n[2] = "";
        //    n[3] = "st=";
        //    n[4] = "ARM=";
        //    n[5] = "t in mem=";
        //    n[6] = "err reg=";
        //    n[7] = "last trig=";
        //    n[8] = "Ptemp=";
        //    n[9] = "Stemp=";
        //    int lines = 0;
        //    int num_pade = 0;
        //    string[] tok = new string[1];

        //    SW.WriteLine("status");

        //    string t = SR.ReadLine();
        //    lines++;
        //    if (t.ToUpper().Contains("MASTER") || t.ToUpper().Contains("SLAVE"))
        //    {
        //        string[] delim = new string[1];
        //        delim[0] = " ";
        //        tok = t.Split(delim, StringSplitOptions.RemoveEmptyEntries);
        //        num_pade = Convert.ToInt32(tok[0]);
        //    }


        //    lines = num_pade;
        //    string[] s = new string[lines + 1];
        //    if ((tok.Length < 9 * num_pade) || (num_pade == 0))
        //    {
        //        for (int i = 0; i < s.Length; i++)
        //        {
        //            s[i] = "error";
        //        }
        //        if (num_pade == 0) { s = new string[1]; s[0] = "error, 0 PADE"; }
        //    }
        //    else
        //    {
        //        int j = 0;
        //        int k = 0;
        //        s[k] = "";
        //        for (int i = 0; i < tok.Length; i++)
        //        {

        //            if (j > 0)
        //            {
        //                s[k] += n[j - 9 * k] + tok[j] + " ";
        //            }
        //            j++;
        //            if ((j - 1) >= (9 * (k + 1))) { k++; s[k] = ""; }
        //        }
        //    }
        //    status = s;
        //    return lines;
        //}

        public void checkFEB_connection()
        {
            if (!client.Connected)
            {
                client.Connect(_host_name, _TNETsocketNum);
            }
        }

        public void Close()
        {
            if (stream != null) { stream.Close(); }
            if (client != null) { client.Close(); }
            _ClientOpen = false;
        }

        public static int count_bits(int val)
        {
            int count = 0;
            try
            {
                for (int i = 0; i < 31; i++)
                {
                    if ((Convert.ToInt32(Math.Pow(2, i)) & val) == Convert.ToInt32(Math.Pow(2, i))) { count++; }
                }
                return count;
            }
            catch { return 0; }
        }

        public void MuxTestSetup()
        {
            SendStr("GAIN 8");
            Thread.Sleep(20);
            SendStr("WR 20 0");
            Thread.Sleep(20);
            SendStr("WR 420 0");
            Thread.Sleep(20);
            SendStr("WR 820 0");
            Thread.Sleep(20);
            SendStr("WR C20 0");
            Thread.Sleep(20);
        }

        public double ReadMuxI(int fpga, int ch)
        {
            int readWait = 2000;
            double adc = 0;
            string[] ReadA0ForMux()
            {
                string t;
                int dt;
                Thread.Sleep(20);
                ReadStr(out t, out dt, 100);
                SendStr("A0 10");
                Thread.Sleep(readWait);
                ReadStr(out t, out dt, 100);
                char[] sep = new char[3];
                sep[0] = ' ';
                sep[1] = '\r';
                sep[2] = '\n';
                string[] tok = t.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                return tok;
            }

            SendStr("MUX " + Convert.ToString(fpga));
            Thread.Sleep(20);
            if (fpga != 0)
            {
                int f1ch = (ch / 4) * 4;
                SendStr("WR " + Convert.ToString(4 * fpga, 16) + "20 1" + Convert.ToString(f1ch, 16));
                Thread.Sleep(20);
            }
            SendStr("WR 20 1" + Convert.ToString(ch % 4, 16));
            Thread.Sleep(20);
            string[] measurements = ReadA0ForMux();
            if (Array.IndexOf(measurements, "avg") != -1)
            {
                adc = Convert.ToDouble(measurements[Array.IndexOf(measurements, "avg") - 1]);
            }
            else { throw new Exception($"Failed to read multiplexer current."); }        
            double I = adc / 8 * 250;
            if (fpga != 0)
            {
                SendStr("WR " + Convert.ToString(4 * fpga, 16) + "20 0");
                Thread.Sleep(20);
            }
            SendStr("WR 20 0");
            Thread.Sleep(20);
            return I;
        }

        //static byte[] GetBytes(string str)
        //{
        //    byte[] bytes = new byte[str.Length];
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        bytes[i] = (byte)(str[i]);
        //    }
        //    return bytes;
        //}

        //static string GetString(byte[] bytes, int len)
        //{
        //    char[] chars = new char[len];
        //    for (int i = 0; i < len; i++)
        //    {
        //        chars[i] = (char)bytes[i];
        //    }
        //    return new string(chars);
        //}

    }
}
