using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace PADE
{
    public class RemoteControl
    {
        static TcpListener listener;
        static IPEndPoint ipend;
        const int LIMIT = 5;
        static int g_commanded_max_trig = 1000;
        public static bool gEnable_Remote_Service = true;

        public void StartRC()
        {
            ipend = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23);
            //ipend = new IPEndPoint(IPAddress.Parse("131.225.56.170"), 23);
            listener = new TcpListener(ipend);
            listener.Start();

            for (int i = 0; i < LIMIT; i++)
            {
                Thread t = new Thread(new ThreadStart(Service));
                t.Start();
            }

        }

        static bool ArmAll()
        {
            List<PADE> Slaves = PADE_explorer.getallPADE(PADE.type_of_PADE.slave);
            List<PADE> Master = PADE_explorer.getallPADE(PADE.type_of_PADE.crate_master); //need to check there is only one!


            foreach (PADE thisPADE in Slaves)
            {
                TB4.activatePADE(thisPADE);
                //PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x240);
                //PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x2c0);
                PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x0240);
                PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x02c0);
                PADE_explorer.registerLookup("SOFTWARE_RESET").RegWrite(1); //???this resets the ping and pong pointers, I guess
                PADE_explorer.registerLookup("TRIG_ARM").RegWrite(1);

                TB4_Exception.logConsoleOnly("slave(s) armed");
            }

            foreach (PADE thisPADE in Master)
            {
                TB4.activatePADE(thisPADE);
                //PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x340);
                //PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x3c0);
                PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x0340);
                PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x03c0);
                PADE_explorer.registerLookup("SOFTWARE_RESET").RegWrite(1); //???this resets the ping and pong pointers, I guess
                Console.WriteLine("master " + Convert.ToString(PADE_explorer.registerLookup("STATUS_REG").RegRead(), 16));
                PADE_explorer.registerLookup("TRIG_ARM").RegWrite(1);
                TB4_Exception.logConsoleOnly("master armed ");
            }
            return true;
        }

        static bool DisArmAll()
        {
            List<PADE> Slaves = PADE_explorer.getallPADE(PADE.type_of_PADE.slave);
            List<PADE> Master = PADE_explorer.getallPADE(PADE.type_of_PADE.crate_master); //need to check there is only one!

            foreach (PADE thisPADE in Master)
            {
                TB4.activatePADE(thisPADE, true);
                PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x0340);
                PADE_explorer.registerLookup("TRIG_ARM").RegWrite(0);

                TB4_Exception.logConsoleOnly("master disarmed");
            }

            foreach (PADE thisPADE in Slaves)
            {
                TB4.activatePADE(thisPADE, true);
                PADE_explorer.registerLookup("TRIG_ARM").RegWrite(0);
                PADE_explorer.registerLookup("CONTROL_REG").RegWrite(0x0240);
                TB4_Exception.logConsoleOnly("slave(s) disarmed ");
            }
            return true;
        }

        static bool Trig()
        {
            List<PADE> Master = PADE_explorer.getallPADE(PADE.type_of_PADE.crate_master); //need to check there is only one!

            foreach (PADE thisPADE in Master)
            {
                TB4.activatePADE(thisPADE);
                PADE_explorer.registerLookup("SOFTWARE_TRIGGER").RegWrite(1);
                TB4_Exception.logConsoleOnly("software trig ");
            }
            return true;
        }

        static bool ClearAll()
        {
            List<PADE> Slaves = PADE_explorer.getallPADE(PADE.type_of_PADE.slave);
            List<PADE> Master = PADE_explorer.getallPADE(PADE.type_of_PADE.crate_master); //need to check there is only one!

            foreach (PADE thisPADE in Master)
            {
                TB4.activatePADE(thisPADE);
                PADE_explorer.registerLookup("MEM_CLEAR").RegWrite(1);
            }

            foreach (PADE thisPADE in Slaves)
            {
                TB4.activatePADE(thisPADE);
                PADE_explorer.registerLookup("MEM_CLEAR").RegWrite(1);
            }

            TB4_Exception.logConsoleOnly("all cleared ");
            return true;
        }

        static bool ReadAll()
        {
            List<PADE> Slaves = PADE_explorer.getallPADE(PADE.type_of_PADE.slave);
            List<PADE> Master = PADE_explorer.getallPADE(PADE.type_of_PADE.crate_master); //need to check there is only one!

            foreach (PADE thisPADE in Master)
            {
                TB4.activatePADE(thisPADE);
                UInt16 max_trig_count = PADE_explorer.registerLookup("MEM_TRIG_COUNT").RegRead();
                for (UInt16 i = 0; i < max_trig_count; i++)
                {
                    PADE_explorer.registerLookup("READ_TRIG_NUM").RegWrite(i);
                    PADE_explorer.registerLookup("READ_ENABLE").RegWrite(1);
                    PADE_explorer.registerLookup("READ_ENABLE").RegWrite(0);
                }
            }

            foreach (PADE thisPADE in Slaves)
            {
                TB4.activatePADE(thisPADE);
                UInt16 max_trig_count = PADE_explorer.registerLookup("MEM_TRIG_COUNT").RegRead();
                for (UInt16 i = 0; i < max_trig_count; i++)
                {
                    PADE_explorer.registerLookup("READ_TRIG_NUM").RegWrite(i);
                    PADE_explorer.registerLookup("READ_ENABLE").RegWrite(1);
                    PADE_explorer.registerLookup("READ_ENABLE").RegWrite(0);
                }
            }
            return true;
        }

        static string ReportStatus()
        {
            List<PADE> Slaves = PADE_explorer.getallPADE(PADE.type_of_PADE.slave);
            List<PADE> Master = PADE_explorer.getallPADE(PADE.type_of_PADE.crate_master); //need to check there is only one!
            UInt16 stat = 0;
            UInt16 arm = 0;
            UInt16 trig_in_mem = 0;
            UInt16 mem_error_count = 0;
            UInt16 current_trig = 0;
            UInt16 pade_temp = 0;
            UInt16 sib_temp = 0;
            UInt16 num_pade = 0;
            string message = "";

            foreach (PADE thisPADE in Master)
            {
                TB4.activatePADE(thisPADE);
                stat = PADE_explorer.registerLookup("STATUS_REG").RegRead();
                arm = PADE_explorer.registerLookup("TRIG_ARM").RegRead();
                trig_in_mem = PADE_explorer.registerLookup("MEM_TRIG_COUNT").RegRead();
                mem_error_count = PADE_explorer.registerLookup("MEM_ERROR_COUNT").RegRead();
                current_trig = PADE_explorer.registerLookup("READ_TRIG_NUM").RegRead();
                pade_temp = PADE_explorer.registerLookup("PADE_TEMP").RegRead();
                sib_temp = PADE_explorer.registerLookup("SIB_TEMP").RegRead();
                num_pade++;
                message += "Master " + thisPADE.PADE_sn + " ";
                message += stat.ToString("X4") + " ";
                message += arm.ToString("X4") + " ";
                message += trig_in_mem.ToString("X4") + " ";
                message += mem_error_count.ToString("X4") + " ";
                message += current_trig.ToString("X4") + " ";
                message += pade_temp.ToString("X4") + " ";
                message += sib_temp.ToString("X4") + " ";
            }

            foreach (PADE thisPADE in Slaves)
            {
                TB4.activatePADE(thisPADE);
                stat = PADE_explorer.registerLookup("STATUS_REG").RegRead();
                arm = PADE_explorer.registerLookup("TRIG_ARM").RegRead();
                trig_in_mem = PADE_explorer.registerLookup("MEM_TRIG_COUNT").RegRead();
                mem_error_count = PADE_explorer.registerLookup("MEM_ERROR_COUNT").RegRead();
                current_trig = PADE_explorer.registerLookup("READ_TRIG_NUM").RegRead();
                pade_temp = PADE_explorer.registerLookup("PADE_TEMP").RegRead();
                sib_temp = PADE_explorer.registerLookup("SIB_TEMP").RegRead();
                num_pade++;
                message += "Slave " + thisPADE.PADE_sn + " ";
                message += stat.ToString("X4") + " ";
                message += arm.ToString("X4") + " ";
                message += trig_in_mem.ToString("X4") + " ";
                message += mem_error_count.ToString("X4") + " ";
                message += current_trig.ToString("X4") + " ";
                message += pade_temp.ToString("X4") + " ";
                message += sib_temp.ToString("X4") + " ";
            }

            TB4_Exception.logConsoleOnly("reported status ");
            TB4_Exception.logConsoleOnly(message);
            message = num_pade.ToString() + " " + message;
            return message;
        }

        public static void Service()
        {
            while (gEnable_Remote_Service)
            {
                Socket soc = listener.AcceptSocket();
                try
                {
                    string[] delimeter = new string[64];
                    string[] tokens = new string[64];

                    delimeter[0] = "<=";
                    delimeter[1] = "//";
                    delimeter[2] = ";";
                    delimeter[3] = "=";
                    delimeter[4] = "set ";
                    delimeter[5] = "dec";
                    delimeter[6] = "0x";
                    delimeter[7] = "(";
                    delimeter[8] = ")";
                    delimeter[9] = " ";
                    Stream s = new NetworkStream(soc);
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true; // enable automatic flushing
                    string RCcmd = "";
                    while (RCcmd != "quit")
                    {
                        RCcmd = sr.ReadLine();
                        RCcmd = RCcmd.Trim().ToLower();
                        
                        //crappy short cuts
                        if (RCcmd == "arm") { ArmAll(); sw.WriteLine(RCcmd); }
                        if (RCcmd == "trig") { Trig(); sw.WriteLine(RCcmd); }
                        if (RCcmd == "disarm") { DisArmAll(); sw.WriteLine(RCcmd); }
                        if (RCcmd == "clear") { ClearAll(); sw.WriteLine(RCcmd); }
                        if (RCcmd == "status") { string m = ReportStatus(); sw.WriteLine(m); }
                        if (RCcmd.Contains("maxtrig"))
                        {
                            int val = 1000;
                            string[] tok = RCcmd.Split(delimeter, StringSplitOptions.None);
                            if (tok.Length > 1)
                            {
                                try
                                {
                                    val = Convert.ToInt32(tok[1]);
                                    if (val < 1) { val = 1; }
                                    if (val > 1000) { val = 1000; }
                                }
                                catch
                                { val = 1000; }
                                g_commanded_max_trig = val;
                            }
                        }

                        if (RCcmd.Contains("read"))
                        {
                            string[] tok = RCcmd.Split(delimeter, StringSplitOptions.None);
                            if (tok.Length > 1)
                            {
                                if (tok[1].Contains("all"))
                                {
                                    ReadAll();
                                    sw.WriteLine(RCcmd);
                                }
                                else
                                {
                                    UInt16 trig_num = 0;
                                    try
                                    { trig_num = Convert.ToUInt16(tok[1]); }
                                    catch (Exception ex)
                                    { TB4_Exception.logError(ex, "illegal trig num in read trig remote control", true); break; }
                                    PADE_explorer.registerLookup("TRIG_ARM").RegWrite(0);
                                    UInt16 max_trig_count = PADE_explorer.registerLookup("MEM_TRIG_COUNT").RegRead();

                                    if ((trig_num < max_trig_count) && (trig_num < g_commanded_max_trig))
                                    {
                                        PADE_explorer.registerLookup("READ_TRIG_NUM").RegWrite(trig_num);
                                        PADE_explorer.registerLookup("READ_ENABLE").RegWrite(1);
                                        PADE_explorer.registerLookup("READ_ENABLE").RegWrite(0);
                                    }
                                    else
                                    {

                                    }

                                }
                            }
                        }
                    }
                    s.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("oops, connection lost");
                }

                soc.Close();
            }
        }
    }
}
