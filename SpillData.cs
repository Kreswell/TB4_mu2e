using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TB_mu2e
{
    public class SpillData
    {
        public DateTime RecTime { get; set; }
        public String Source { get; set; }
        public UInt32 SpillWordCount { get; set; }
        public UInt32 SpillTrigCount { get; set; }
        public UInt16 SpillCounter { get; set; }
        public UInt16 Mask { get; set; }
        public UInt16 ExpectNumCh { get; set; }
        public UInt16 BoardID { get; set; }
        public UInt16 SpillStatus { get; set; }
        public bool SpillParsed { get; set; }
        public bool NoError { get; set; }
        public bool IsDisplayed { get; set; }
        public LinkedList<mu2e_Event> SpillEvents;

        public SpillData()
        {
            SpillParsed = false;
            NoError = false;
            SpillEvents = new LinkedList<mu2e_Event>();
        }
        public bool ParseInput(List<byte> pack, int err = 0)
        {
            {
                int i = 0;
                //for (int ii = 0; ii < 480; ii++)
                //{
                //    Console.Write(Convert.ToString((i ) + (32 * ii), 16) + "(" + (ii ).ToString() + ") => ");
                //    for (int jj = 0; jj < 16; jj++)
                //    {
                //        int this_index = (i) + (32 * ii) + jj * 2;
                //        Console.Write(Convert.ToString(pack[this_index] * 256 + pack[this_index + 1], 16) + " ");
                //    }
                //    Console.WriteLine();
                //}
            }
            try
            {
                //i is the byte offset counter
                this.RecTime = DateTime.Now;
                #region SpillHeader
                //spill word count 0123
                int i = 0;
                UInt32 t32 = 0;
                t32 = (UInt32)(pack[i] * 256 * 256 * 256 + pack[i + 1] * 256 * 256 + pack[i + 2] * 256 + pack[i + 3]);
                this.SpillWordCount = t32;

                //spill trig count 4567
                i = 4; t32 = 0;
                t32 = (UInt32)(pack[i] * 256 * 256 * 256 + pack[i + 1] * 256 * 256 + pack[i + 2] * 256 + pack[i + 3]);
                this.SpillTrigCount = t32;

                //spill counter 89
                i = 8;
                UInt16 t16 = 0;
                t16 = (UInt16)(pack[i] * 256 + pack[i + 1]);
                this.SpillCounter = t16;

                //mask 10,11
                i = 10; t16 = 0;
                t16 = (UInt16)(pack[i] * 256 + pack[i + 1]);
                this.Mask = t16;
                //from this, we can figure out the num of ch
                this.ExpectNumCh = 0;
                for (int p = 0; p < 16; p++)
                {
                    if ((Convert.ToUInt16(Math.Pow(2, 1)) & this.Mask) == Convert.ToUInt16(Math.Pow(2, 1))) { this.ExpectNumCh++; }
                }

                //board id 12,13
                i = 12; t16 = 0;
                t16 = (UInt16)(pack[i] * 256 + pack[i + 1]);
                this.BoardID = t16;

                //spill status 14,15
                i = 14; t16 = 0;
                t16 = (UInt16)(pack[i] * 256 + pack[i + 1]);
                this.SpillStatus = t16;

                #endregion SpillHeader

                UInt32 event_num_left = this.SpillTrigCount;
                bool first_event_of_spill = true;
                UInt16 ExpectedEventWordCount = 0;
                UInt32 StartPointer = 0x10;
                UInt32 myTriggerCount = 0;
                i = 16;
                int ch_num = 0;
                DateTime start_parsing = DateTime.Now;



                while (event_num_left > 0)
                {
                    mu2e_Event this_event = new mu2e_Event();
                    #region EventHeader
                    //event word count
                    //i is 16 at this point for the first event
                    t16 = 0;


                    t16 = (UInt16)(pack[i] * 256 + pack[i + 1]);
                    this_event.EventWordCount = t16;
                    if (first_event_of_spill) { first_event_of_spill = false; ExpectedEventWordCount = t16; }
                    else
                    {


                        UInt32 myPointer = StartPointer+ (UInt32)(2 * ExpectedEventWordCount) * myTriggerCount;
                        int ioff = -20;
                        Console.WriteLine("My pointer is =0x{0}", Convert.ToString(myPointer, 16));
                        i = (int)(myPointer + 0x10);
                        //------------------------------------------------------
                        for (int ii = 0; ii < 8; ii++)
                        {
                            Console.Write(Convert.ToString((i - 64) + (32 * ii), 16) + "(" + (ii - 2).ToString() + ") => ");
                            for (int jj = 0; jj < 16; jj++)
                            {
                                int this_index = (i - 64) + (32 * ii) + jj * 2;
                                Console.Write(Convert.ToString(pack[this_index] * 256 + pack[this_index + 1], 16) + " ");
                            }
                            Console.WriteLine();
                        }
                        //------------------------------------------------------
                        while (ioff < 64)
                        {
                            t16 = (UInt16)(pack[i + ioff] * 256 + pack[i + ioff + 1]);
                            //   Console.WriteLine("ioff={0}, t16={1}", ioff, Convert.ToString( t16,16));
                            if (t16 == ExpectedEventWordCount)
                            {

                                Console.WriteLine("Found correct offset at {0} for trig {1}", ioff, this_event.TrigCounter);
                                //for (int ii = 0; ii < 15; ii++)
                                //{
                                //    Console.Write((i - 32 - (128 * 16) + (ii * 16).ToString()) + "(" + (ii - 1).ToString() + ") => ");
                                //    for (int jj = 0; jj < 16; jj++)
                                //    {
                                //        int this_index = (i - 32) + (32 * ii) + jj * 2;
                                //        Console.Write(Convert.ToString(pack[this_index], 16) + Convert.ToString(pack[this_index + 1], 16) + " ");
                                //    }
                                //    Console.WriteLine();
                                //}
                                i = i + ioff;
                                t16 = (UInt16)(pack[i] * 256 + pack[i + 1]);
                                this_event.EventWordCount = t16;
                                ioff = 100;
                            }
                            ioff++;
                        }
                    }
                    Console.WriteLine("i={0},ThisEventWordCount={1}", Convert.ToString(i, 16), Convert.ToString(this_event.EventWordCount, 16));
                    i = i + 2;
                    //event time stamp
                    t32 = 0;
                    t32 = (UInt32)(pack[i++] * 256 * 256 * 256 + pack[i++] * 256 * 256 + pack[i++] * 256 + pack[i++]);
                    this_event.EventTimeStamp = t32;

                    //trigger counter
                    t32 = 0;
                    t32 = (UInt32)(pack[i++] * 256 * 256 * 256 + pack[i++] * 256 * 256 + pack[i++] * 256 + pack[i++]);
                    this_event.TrigCounter = t32;

                    //event num samples
                    t16 = 0;
                    t16 = (UInt16)(pack[i++] * 256 + pack[i++]);
                    this_event.NumSamples = t16;

                    //event trig type
                    t16 = (UInt16)(pack[i++] * 256 + pack[i++]);
                    this_event.TrigType = t16;

                    //event stsus
                    t16 = (UInt16)(pack[i++] * 256 + pack[i++]);
                    this_event.EventStatus = t16;

                    #endregion EventHeader

                    #region EventData
                    if (this_event.NumSamples == 0) { Console.WriteLine("stop!"); }
                    int num_ch = Convert.ToInt32(this_event.EventWordCount / this_event.NumSamples);

                    for (int k = 0; k < num_ch; k++)
                    {
                        int[] ch_data = new int[this_event.NumSamples];
                        for (int j = 0; j < this_event.NumSamples ; j++)
                        {
                            t16 = (UInt16)(pack[i++] * 256 + pack[i++]);
                            ch_data[j] = t16;
                            if (ch_data[j] > 0x800) { ch_data[j] = ch_data[j] - 0xfff; }
                            if ((j == 0) || (j == 0x7f))
                            {
                                //for (int ii = i; ii < i + 33; ii++)
                                //{ Console.WriteLine(ii + "(" + (ii - i).ToString() + ") => " + Convert.ToString(pack[ii], 16)); }
                            }
                        }
                        mu2e_Ch this_ch = new mu2e_Ch();
                        this_ch.num_ch = k + 1;
                        this_ch.data = ch_data;
                        this_event.ChanData.Add(this_ch);
                    }

                    Console.WriteLine("end of event {0} at time {1}-----------------", this_event.TrigCounter, this_event.EventTimeStamp);


                    //for (int ii = 0; ii < 20; ii++)
                    //{
                    //    Console.Write((i - 32 - (128 * 16) + (ii * 16).ToString()) + "(" + (ii - 1).ToString() + ") => ");
                    //    for (int jj = 0; jj < 16; jj++)
                    //    {
                    //        int this_index = (i - 32) + (32 * ii) + jj * 2;
                    //        Console.Write(Convert.ToString(pack[this_index], 16) + Convert.ToString(pack[this_index + 1], 16) + " ");
                    //    }
                    //    Console.WriteLine();
                    //}
                    //=======================================================================================================
                    if (first_event_of_spill)
                    { i = i + (int)(this_event.TrigCounter * 16); }//i don't know why there are these extra 16 bytes here
                    //=======================================================================================================

                    //for (int ii = 0; ii < 5; ii++)
                    //{
                    //    Console.Write((i - 32 + (ii * 16).ToString()) + "(" + (ii - 1).ToString() + ") => ");
                    //    for (int jj = 0; jj < 16; jj++)
                    //    {
                    //        int this_index = (i - 32) + (32 * ii) + jj * 2;
                    //        Console.Write(Convert.ToString(pack[this_index], 16) + Convert.ToString(pack[this_index + 1], 16) + " ");
                    //    }
                    //    Console.WriteLine();
                    //}

                    #endregion EventData

                    myTriggerCount++;
                    event_num_left--;
                    this.SpillEvents.AddLast(this_event);
                }
                DateTime end_parsing = DateTime.Now;
                TimeSpan time_to_parse = end_parsing.Subtract(start_parsing);
                Console.WriteLine("Time to parse {0} events was {1} ms", this.SpillTrigCount, time_to_parse.TotalMilliseconds);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception " + e.Message + " in spill data");
                return false;
            }
        }
    }

    public class mu2e_Event
    {
        public UInt16 EventWordCount { get; set; }
        public UInt32 EventTimeStamp { get; set; }
        public UInt32 TrigCounter { get; set; }
        public UInt16 NumSamples { get; set; }
        public UInt16 TrigType { get; set; }
        public UInt16 EventStatus { get; set; }

        public List<mu2e_Ch> ChanData;

        public mu2e_Event()
        {
            EventWordCount = 0;
            EventTimeStamp = 0;
            ChanData = new List<mu2e_Ch>(16);
        }
    }

    public class mu2e_Ch
    {
        public int num_ch;
        public int[] data;
    }


}
