using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace TB_mu2e
{
    static class TCP_reciever
    {
        private static StreamWriter sw;
        public static DateTime time_start;
        public static DateTime time_read_done;
        public static DateTime time_save_done;
        public static bool NewSpill;
        public static bool SaveEnabled;
        public static bool ParseEnabled;
        public static bool AllDone;
        public static string source_name;

        private static void Save(List<byte> buf)
        {
            sw = PP.myRun.sw;
            try
            {
                if (sw == null)
                {
                    return;
                }
                int i = 0;
                NewSpill = true;

                sw.WriteLine("--Begin of spill");
                sw.WriteLine("--** SOURCE = " + source_name);
                foreach (byte b in buf)
                {
                    sw.Write(b.ToString());
                    sw.Write(" ");
                    i++;
                    if (i == 16) { sw.WriteLine(); i = 0; }
                }
                time_save_done = DateTime.Now;

                sw.WriteLine("--wrote " + buf.Count.ToString() + " bytes");
                sw.WriteLine("--Read took (in ms):" + time_read_done.Subtract(time_start).TotalMilliseconds.ToString(""));
                sw.WriteLine("--Save took (in ms):" + time_save_done.Subtract(time_read_done).TotalMilliseconds.ToString(""));

                //close after 30 min
            }
            catch { Console.WriteLine("bad break"); }
        }

        public static void ReadFeb(string BoardName, Socket s, out long l) //out List<byte> buf,
        {
            List<byte> buf;
            source_name = BoardName;
            PP.myMain.timer1.Enabled = false;
            byte[] b = new byte[5];
            b = PP.GetBytes("rdb\r\n");
            time_start = DateTime.Now;
            l = 0;

            s.Send(b);
            buf = new List<byte>();
            Thread.Sleep(100);
            //wait to get the first packet
            while (s.Available == 0)
            {
                Thread.Sleep(5);
            }
            Thread.Sleep(50);
            int old_available = 0;
            while (old_available < s.Available)
            {
                Thread.Sleep(20);
                PP.myRun.UpdateStatus("Started recieving " + old_available + " bytes");
                old_available = s.Available;
            }

            byte[] rec_buf = new byte[s.Available];
            int ret_len = s.Receive(rec_buf);
            for (int i = 0; i < ret_len; i++)
            {
                buf.Add(rec_buf[i]);
                l++;
            }

            PP.myRun.UpdateStatus("Ended recieving " + buf.LongCount() + " bytes");
            Thread.Sleep(5);
            //spill word count is the first 4 bytes
            int ind = 0;
            Int64 t = 0;
            t = (Int64)(buf[0] * 256 * 256 * 256 + buf[1] * 256 * 256 + buf[2] * 256 + buf[3]);
            long SpillWordCount = t*2;
            long RecWordCount = buf.LongCount<byte>();
            DateTime start_rec=DateTime.Now;
            TimeSpan MaxTimeSpan=TimeSpan.FromSeconds(2);
            while (RecWordCount < SpillWordCount)
            {
                Thread.Sleep(2);
                if (DateTime.Now>start_rec.Add(MaxTimeSpan))
                {
                    //timeout
                    SpillWordCount=RecWordCount;
                }
                if (s.Available > 0)
                {
                    byte[] rec_buf2 = new byte[s.Available];
                    int ret_len2 = s.Receive(rec_buf);

                    for (int i = 0; i < ret_len; i++)
                    {
                        buf.Add(rec_buf[i]);
                        l++;
                    }
                    RecWordCount = buf.LongCount<byte>();
                    DateTime so_far_time = DateTime.Now;
                    TimeSpan elapsed = so_far_time.Subtract(start_rec);
                    Console.WriteLine("read... " + buf.LongCount<byte>().ToString() + " out of " + SpillWordCount.ToString() + " in " + elapsed.TotalMilliseconds + " ms");
                }
            }
            
            time_read_done = DateTime.Now;

            SpillData new_spill = new SpillData();
            new_spill.ParseInput(buf);
            PP.myRun.Spills.AddLast(new_spill);
            while (PP.myRun.Spills.Count > 3)
            {
                SpillData aSpill;
                aSpill = PP.myRun.Spills.First();
                if (aSpill.IsDisplayed == false) { PP.myRun.Spills.Remove(aSpill); }
                else { return; }
                
            }
            if (PP.myRun != null)
            {
                if (PP.myRun.sw != null)
                {
                    if (SaveEnabled) { Save(buf); }
                }
            }
            AllDone = true;

            PP.myMain.timer1.Enabled = true;

        }
    }
}
