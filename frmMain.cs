using mu2e.FEB_Test_Jig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TB_mu2e
{

    public partial class frmMain : Form
    {
        private int _ActiveFEB = 0;
        private bool flgBreak = false;

        private string msg1Conn = "";
        private string msg2Conn = "";
        private uConsole console_label;

        private static int num_reg = 15;
        private TextBox[] txtREGISTERS = new TextBox[num_reg];
        private static int num_spill_reg = 5;
        private TextBox[] txtSPILL = new TextBox[num_spill_reg];
        CheckBox[] chkChEnable = new CheckBox[64];
        private string[] rnames = new string[50];
        private System.Windows.Forms.Label[] lblREG = new System.Windows.Forms.Label[num_reg + num_spill_reg];
        private bool _IntegralScan = false;

        private SpillData DispSpill;
        private mu2e_Event DispEvent;
        //private bool DebugLogging;

        public Mu2e_FEB_client myFEBclient = new Mu2e_FEB_client();
        FEB myFEB = new FEB();

        List<string> ListSipm = new List<string>();
        List<string> ListSipmHisto = new List<string>();

        public void AddConsoleMessage(string mess)
        {
            console_label.add_messg(mess);
        }

        public frmMain()
        {
            InitializeComponent();

            myFEBclient = PP.FEB1;
            myFEB.FEBclient = myFEBclient;

            btnFEB1.BackColor = SystemColors.Control;
            lblMessage.Text = msg1Conn + "\n" + msg2Conn;

            btnFEB1.Click += new System.EventHandler(this.button1_Click);
            btnFEB1.Tag = PP.FEB1; btnFEB1.Text = PP.FEB1.host_name_prop;
            btnFEB2.Click += new System.EventHandler(this.button1_Click);
            btnFEB2.Tag = PP.FEB2; btnFEB2.Text = PP.FEB2.host_name_prop;

            btnWC.Click += new System.EventHandler(this.button1_Click);
            btnWC.Tag = PP.WC; btnWC.Text = PP.WC.host_name_prop;

            txtFEBAddress.Text = PP.FEB1.host_name_prop;

            console_label = new uConsole();

            #region Registers

            rnames[0] = "CSR";
            rnames[1] = "SDRAM_WritePointer";
            rnames[2] = "SDRAM_ReadPointer";
            rnames[3] = "TEST_PULSE_FREQ";//pipe_del
            rnames[4] = "TEST_PULSE_DURATION";//num_samp
            rnames[5] = "TEST_PULSE_INTERSPILL";//mux_ctrl
            rnames[6] = "CHAN_MASK";//trig_ctrl
            rnames[7] = "MUX_SEL";//afe_fifo
            rnames[8] = "TRIG_CONTROL";//mig_stat
            rnames[9] = "SPILL_TRIG_COUNT";//mig_fifo
            ///
            rnames[10] = "SPILL_NUMBER";
            rnames[11] = "SPILL_STATE";
            rnames[12] = "SPILL_TRIG_COUNT";
            rnames[13] = "SPILL_WORD_COUNT";
            rnames[14] = "UPTIME";

            for (int i = 0; i < num_reg; i++)
            {
                txtREGISTERS[i] = new TextBox();
                txtREGISTERS[i].Location = new System.Drawing.Point(240, 16 + 24 * i);
                txtREGISTERS[i].Size = new System.Drawing.Size(100, 15);
                txtREGISTERS[i].TextAlign = HorizontalAlignment.Right;
                txtREGISTERS[i].Tag = i;

                lblREG[i] = new System.Windows.Forms.Label();
                lblREG[i].Location = new System.Drawing.Point(1, 20 + 24 * i);
                lblREG[i].Size = new System.Drawing.Size(230, 20);
                lblREG[i].TextAlign = ContentAlignment.MiddleRight;
                lblREG[i].Text = rnames[i];

            }

            for (int k = 0; k < 2; k++)
            {
                foreach (Control c in tabControl.TabPages[2 + k].Controls)
                {
                    for (int i = 0; i < num_reg; i++)
                    {
                        if (c.Name.Contains("groupBoxREG"))
                        {
                            c.Controls.Add(txtREGISTERS[i]);
                            c.Controls.Add(lblREG[i]);
                        }
                    }
                }

            }
            for (int i = 0; i < num_spill_reg; i++)
            {
                txtSPILL[i] = new TextBox();
                txtSPILL[i].Location = new System.Drawing.Point(125, 20 * (i + 1));
                txtSPILL[i].Size = new System.Drawing.Size(120, 17);
                txtSPILL[i].TextAlign = HorizontalAlignment.Right;
                txtSPILL[i].Tag = i;
            }

            for (int k = 0; k < 2; k++)
            {
                foreach (Control c in tabControl.TabPages[2 + k].Controls)
                {
                    for (int i = 0; i < num_reg; i++)
                    {
                        if (c.Name == "groupBoxSPILL")
                        { c.Controls.Add(txtSPILL[i]); }
                    }
                }

            }
            #endregion Registers

            #region ch_select

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    chkChEnable[j * 4 + i] = new CheckBox();
                    chkChEnable[j * 4 + i].Location = new System.Drawing.Point(6 + 45 * j, 20 * i);
                    chkChEnable[j * 4 + i].Size = new System.Drawing.Size(45, 20);
                    chkChEnable[j * 4 + i].Text = (j * 4 + i + 1).ToString();
                    chkChEnable[j * 4 + i].Tag = j * 4 + i;

                }
            }
            for (int k = 0; k < 2; k++)
            {
                foreach (Control c in tabControl.TabPages[k].Controls)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (c.Name == "groupBoxEvDisplay")
                        { c.Controls.Add(chkChEnable[i]); }
                    }
                }

            }
            #endregion ch_select

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button mySender = (Button)sender;
            string myName = mySender.Text;
            IStenComms comm = (IStenComms)mySender.Tag;
            if (!comm.ClientOpen) { comm.DoOpen(); }
            if (!comm.ClientOpen)
            {
                //label1.Text = comm.m_prop;
                mySender.BackColor = Color.Red;
                if (comm.name.Contains("FEB1")) { btnFEB1.BackColor = Color.Red; }
                if (comm.name.Contains("FEB2")) { btnFEB2.BackColor = Color.Red; }
                if (comm.name.Contains("WC")) { btnWC.BackColor = Color.Red; }
                if (comm.name.Contains("FECC")) { lblFEB1.BackColor = Color.Red; }
            }
            else
            {
                mySender.BackColor = Color.Green;
                if (comm.name.Contains("FEB1"))
                {
                    lblFEB1.BackColor = Color.Green;
                    btnFEB1.BackColor = Color.LightSeaGreen;
                    btnFEB2.BackColor = Color.Green;
                    _ActiveFEB = 1;
                    lblActive.Text = " FEB1";
                    PP.active_Stream = PP.FEB1.stream;
                    PP.active_Socket = PP.FEB1.TNETSocket;
                    dbgFEB1.BackColor = Color.Green;
                    dbgFEB2.BackColor = Color.Gray;
                    dbgWC.BackColor = Color.Gray;
                    btnBiasREAD_Click(null, null);
                    btnRegREAD_Click(null, null);
                }
                if (comm.name.Contains("FEB2"))
                {
                    lblFEB2.BackColor = Color.Green;
                    btnFEB2.BackColor = Color.LightSeaGreen;
                    btnFEB1.BackColor = Color.Green;
                    _ActiveFEB = 2;
                    lblActive.Text = " FEB2";
                    PP.active_Stream = PP.FEB2.stream;
                    PP.active_Socket = PP.FEB2.TNETSocket;
                    dbgFEB2.BackColor = Color.Green;
                    dbgFEB1.BackColor = Color.Gray;
                    dbgWC.BackColor = Color.Gray;
                    btnBiasREAD_Click(null, null);
                    btnRegREAD_Click(null, null);
                }
                if (comm.name.Contains("WC"))
                {
                    lblWC.BackColor = Color.Green;
                    _ActiveFEB = 0;
                    lblActive.Text = "NONE";
                    PP.active_Stream = PP.WC.stream_prop;
                    PP.active_Socket = PP.WC.TNETSocket_prop;
                    dbgFEB2.BackColor = Color.Gray;
                    dbgFEB1.BackColor = Color.Gray;
                    dbgWC.BackColor = Color.Green;
                }
                if (comm.name.Contains("FECC")) { }
                lblMessage.Text = DateTime.Now + " -> " + comm.m_prop;

                // Initialize the VoltagSignal objects, set all voltages to 0, 
                // acquire an initial set of measurements, and fill the display.
                ZeroAllVoltages();
                myFEB.BuildHDMIsignalDB();
            }
        }

        public void select_module_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control))
            {
                if (e.KeyChar.ToString() == " ")
                {
                    if (dbgFEB2.BackColor == Color.Green)
                    { dbgFEB_Click((object)dbgWC, null); textBox1.Text = ""; return; }
                    if (dbgFEB1.BackColor == Color.Green)
                    { dbgFEB_Click((object)dbgFEB2, null); textBox1.Text = ""; return; }
                    if (dbgWC.BackColor == Color.Green)
                    { dbgFEB_Click((object)dbgFEB1, null); textBox1.Text = ""; return; }
                }
                if (e.KeyChar.ToString() == "1")
                { dbgFEB_Click((object)dbgWC, null); }
                if (e.KeyChar.ToString() == "2")
                { dbgFEB_Click((object)dbgWC, null); }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string l = "";
            bool this_is_a_write = false;
            string tt = "";

            if (textBox1.Text.Contains("\n"))
            {
                try
                {
                    if (textBox1.Text.Contains("$")) //this is a comment
                    { }
                    else
                    {
                        byte[] buf = PP.GetBytes(textBox1.Text);
                        tt = textBox1.Text;
                        //textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 2);
                        if (textBox1.Text.ToLower().Contains("wr")) { this_is_a_write = true; }
                        textBox1.Text = "";
                        while (PP.active_Socket.Available > 0)
                        {
                            byte[] rbuf = new byte[PP.active_Socket.Available];
                            PP.active_Socket.Receive(rbuf);
                        }
                        PP.active_Socket.Send(buf);
                        System.Threading.Thread.Sleep(1);
                        int max_timeout = 50; int timeout = 0;
                        if (this_is_a_write) { max_timeout = 3; }
                        while ((PP.active_Socket.Available == 0) && (timeout < max_timeout))
                        {
                            timeout++; System.Threading.Thread.Sleep(2);
                        }
                        if (timeout < max_timeout)
                        {
                            byte[] rec_buf = new byte[PP.active_Socket.Available];
                            int ret_len = PP.active_Socket.Receive(rec_buf);
                            string t = PP.GetString(rec_buf, ret_len);
                            t = tt.Substring(0, tt.Length - 2) + ": " + t;
                            l = console_label.add_messg(t);
                        }
                        else
                        {
                            if (this_is_a_write)
                            { l = console_label.add_messg(tt); }//there is no response to a write
                            else
                            { l = console_label.add_messg("timeout!"); }
                        }
                        lblConsole_disp.Text = l;
                        Application.DoEvents();
                    }
                }
                catch
                {
                    string m = "Exception caught. Do yu have a module selected?";
                    lblConsole_disp.Text = m;
                    Application.DoEvents();
                }
            }
        }

        private void btnRegREAD_Click(object sender, EventArgs e)
        {
            //Mu2e_FEB_client myFEBclient = null;
            string cmb_reg;
            int i = this.tabControl.SelectedIndex;
            if (tabControl.SelectedTab.Text.Contains("FEB"))
            {
                if (_ActiveFEB == 1)
                { myFEBclient = PP.FEB1; }
                else if (_ActiveFEB == 2)
                { myFEBclient = PP.FEB2; }
                else
                { MessageBox.Show("No FEB active"); return; }

                myFEBclient.checkFEB_connection();

                ushort fpga_num = Convert.ToUInt16(udFPGA.Value);
                for (int j = 0; j < num_reg; j++)
                {
                    Mu2e_Register r1;
                    Mu2e_Register.FindName(rnames[j], ref myFEBclient.arrReg, out r1);
                    r1.fpga_index = fpga_num;
                    Mu2e_Register.ReadReg(ref r1, ref myFEBclient.client);
                    if (!r1.pref_hex)
                    { txtREGISTERS[j].Text = r1.val.ToString(); }
                    else
                    { txtREGISTERS[j].Text = "0x" + Convert.ToString(r1.val, 16); }
                    myFEBclient.ReadCMB(out cmb_reg);
                    //label9.Text = cmb_reg;
                }
            }
        }

        private void btnRegMONITOR_Click(object sender, EventArgs e)
        {

        }

        private void btnRegWRITE_Click(object sender, EventArgs e)
        {
            //Mu2e_FEB_client myFEBclient = null;
            int i = this.tabControl.SelectedIndex;
            if (tabControl.SelectedTab.Text.Contains("FEB"))
            {
                //if (_ActiveFEB == 1)
                //{ myFEBclient = PP.FEB1; }
                //if (_ActiveFEB == 2)
                //{ myFEBclient = PP.FEB2; }

                ushort fpga_num = Convert.ToUInt16(udFPGA.Value);
                for (int j = 0; j < num_reg; j++)
                {
                    Mu2e_Register r1;
                    Mu2e_Register.FindName(rnames[j], ref myFEBclient.arrReg, out r1);
                    r1.fpga_index = fpga_num;
                    if (txtREGISTERS[j].Text.Contains("x"))
                    {
                        try
                        {
                            UInt32 v = Convert.ToUInt32(txtREGISTERS[j].Text, 16);
                            Mu2e_Register.WriteReg(v, ref r1, ref myFEBclient.client);
                        }
                        catch
                        { txtREGISTERS[j].Text = "?"; }
                    }
                    else
                    {
                        try
                        {
                            UInt32 v = Convert.ToUInt32(txtREGISTERS[j].Text);
                            Mu2e_Register.WriteReg(v, ref r1, ref myFEBclient.client);
                        }
                        catch
                        { txtREGISTERS[j].Text = "?"; }
                    }
                }
            }
        }

        private void dbgFEB_Click(object sender, EventArgs e)
        {
            Button mySender = (Button)sender;
            string myName = mySender.Text;
            if (myName.Contains("FEB1"))
            {
                button1_Click((object)btnFEB1, e);
                lblConsole_disp.Text = console_label.add_messg("---- FEB1 ----\r\n");
            }
            if (myName.Contains("FEB2"))
            {
                button1_Click((object)btnFEB2, e);
                lblConsole_disp.Text = console_label.add_messg("---- FEB2 ----\r\n");
            }
            if (myName.Contains("WC"))
            {
                button1_Click((object)btnWC, e);
                lblConsole_disp.Text = console_label.add_messg("----  WC  ----\r\n");
            }
            if (myName.Contains("FECC")) { }
        }

        private void btnSpillREAD_Click(object sender, EventArgs e)
        {
            //Mu2e_FEB_client myFEBclient = null;
            int i = this.tabControl.SelectedIndex;
            if (tabControl.SelectedTab.Text.Contains("FEB"))
            {
                //if (_ActiveFEB == 1)
                //{ myFEBclient = PP.FEB1; }
                //if (_ActiveFEB == 2)
                //{ myFEBclient = PP.FEB2; }


                ushort fpga_num = Convert.ToUInt16(udFPGA.Value);
                for (int j = 0; j < num_spill_reg; j++)
                {
                    Mu2e_Register r1;
                    Mu2e_Register.FindName(rnames[j], ref myFEBclient.arrReg, out r1);
                    r1.fpga_index = fpga_num;
                    Mu2e_Register.ReadReg(ref r1, ref myFEBclient.client);
                    if (!r1.pref_hex)
                    { txtSPILL[j].Text = r1.val.ToString(); }
                    else
                    { txtSPILL[j].Text = "0x" + Convert.ToString(r1.val, 16); }
                }
            }
        }

        private void btnSpillWRITE_Click(object sender, EventArgs e)
        {
            //Mu2e_FEB_client myFEBclient = null;
            int i = this.tabControl.SelectedIndex;
            if (tabControl.SelectedTab.Text.Contains("FEB"))
            {
                //if (_ActiveFEB == 1)
                //{ myFEBclient = PP.FEB1; }
                //if (_ActiveFEB == 2)
                //{ myFEBclient = PP.FEB2; }


                ushort fpga_num = Convert.ToUInt16(udFPGA.Value);
                for (int j = 0; j < num_spill_reg; j++)
                {
                    Mu2e_Register r1;
                    Mu2e_Register.FindName(rnames[j], ref myFEBclient.arrReg, out r1);
                    r1.fpga_index = fpga_num;
                    if (txtSPILL[j].Text.Contains("x"))
                    {
                        try
                        {
                            UInt32 v = Convert.ToUInt32(txtREGISTERS[j].Text, 16);
                            Mu2e_Register.WriteReg(v, ref r1, ref myFEBclient.client);
                        }
                        catch
                        { txtSPILL[j].Text = "?"; }
                    }
                    else
                    {
                        try
                        {
                            UInt32 v = Convert.ToUInt32(txtSPILL[j].Text);
                            Mu2e_Register.WriteReg(v, ref r1, ref myFEBclient.client);
                        }
                        catch
                        { txtSPILL[j].Text = "?"; }
                    }
                }
            }
        }

        private void btnSpillMON_Click(object sender, EventArgs e)
        {

        }

        private void btnBiasREAD_Click(object sender, EventArgs e)
        {
            string name = tabControl.SelectedTab.Text;
            if (name.Contains("FEB"))
            {
                switch (_ActiveFEB)
                {
                    case 1:
                        txtV.Text = PP.FEB1.ReadV((int)udFPGA.Value).ToString("0.000");
                        txtI.Text = PP.FEB1.ReadA0((int)udFPGA.Value, (int)udChan.Value).ToString("0.0000");
                        break;
                    case 2:
                        txtV.Text = PP.FEB2.ReadV((int)udFPGA.Value).ToString("0.000");
                        txtI.Text = PP.FEB2.ReadA0((int)udFPGA.Value, (int)udChan.Value).ToString("0.0000");
                        break;

                    default:
                        break;
                }
            }
        }

        private void btnBiasWRITE_Click(object sender, EventArgs e)
        {
            string name = tabControl.SelectedTab.Text;
            if (name.Contains("FEB"))
            {
                switch (_ActiveFEB)
                {
                    case 1:
                        PP.FEB1.SetV(Convert.ToDouble(txtV.Text), (int)udFPGA.Value);
                        txtI.Text = PP.FEB1.ReadA0((int)udFPGA.Value, (int)udChan.Value).ToString("0.0000");
                        break;
                    case 2:
                        PP.FEB2.SetV(Convert.ToDouble(txtV.Text));
                        txtI.Text = PP.FEB2.ReadA0((int)udFPGA.Value, (int)udChan.Value).ToString("0.0000");
                        break;

                    default:
                        break;
                }
            }
        }

        private void btnBIAS_MON_Click(object sender, EventArgs e)
        {

        }

        void histoScan(object sender)
        {
            Button button = sender as Button;
            List<bool> hdmiChecks = new List<bool>();
            ListBox listBox = new ListBox();
            ZedGraphControl zgControl = new ZedGraphControl();
            int intTime;
            if (button == btnScan)
            {
                hdmiChecks.Add(checkBox1.Checked);
                hdmiChecks.Add(checkBox2.Checked);
                hdmiChecks.Add(checkBox3.Checked);
                hdmiChecks.Add(checkBox4.Checked);
                hdmiChecks.Add(checkBox5.Checked);
                hdmiChecks.Add(checkBox6.Checked);
                hdmiChecks.Add(checkBox7.Checked);
                hdmiChecks.Add(checkBox8.Checked);
                hdmiChecks.Add(checkBox9.Checked);
                hdmiChecks.Add(checkBox10.Checked);
                hdmiChecks.Add(checkBox11.Checked);
                hdmiChecks.Add(checkBox12.Checked);
                hdmiChecks.Add(checkBox13.Checked);
                hdmiChecks.Add(checkBox14.Checked);
                hdmiChecks.Add(checkBox15.Checked);
                hdmiChecks.Add(checkBox16.Checked);

                listBox = listBox1;
                zgControl = zedFEB1;
                intTime = (int)udInterval.Value;
            }
            else if (button == btnHistoScan)
            {
                hdmiChecks.Add(chkBoxJ11.Checked);
                hdmiChecks.Add(chkBoxJ12.Checked);
                hdmiChecks.Add(chkBoxJ13.Checked);
                hdmiChecks.Add(chkBoxJ14.Checked);
                hdmiChecks.Add(chkBoxJ15.Checked);
                hdmiChecks.Add(chkBoxJ16.Checked);
                hdmiChecks.Add(chkBoxJ17.Checked);
                hdmiChecks.Add(chkBoxJ18.Checked);
                hdmiChecks.Add(chkBoxJ19.Checked);
                hdmiChecks.Add(chkBoxJ20.Checked);
                hdmiChecks.Add(chkBoxJ21.Checked);
                hdmiChecks.Add(chkBoxJ22.Checked);
                hdmiChecks.Add(chkBoxJ23.Checked);
                hdmiChecks.Add(chkBoxJ24.Checked);
                hdmiChecks.Add(chkBoxJ25.Checked);
                hdmiChecks.Add(chkBoxJ26.Checked);

                listBox = listBoxHistos;
                zgControl = zedGraphHisto;
                intTime = (int)udHistIntegralTime.Value;
            }
            else { return; }

            PP.FEB1Histo.Clear();
            listBox.DataSource = null;
            ListSipm.Clear();
            zgControl.GraphPane.CurveList.Clear();
            zgControl.Refresh();
            Mu2e_Register r_mux;
            Mu2e_Register.FindAddr(0x20, ref myFEBclient.arrReg, out r_mux);
            Mu2e_Register r_CSR;
            Mu2e_Register.FindName("CSR", ref myFEBclient.arrReg, out r_CSR);
            Mu2e_Register r_ch;
            Mu2e_Register.FindName("HISTO_CTRL_REG", ref myFEBclient.arrReg, out r_ch);
            Mu2e_Register r_interval;
            Mu2e_Register.FindName("HISTO_COUNT_INTERVAL", ref myFEBclient.arrReg, out r_interval);
            Mu2e_Register r_pointer0;
            Mu2e_Register.FindName("HISTO_POINTER_AFE0", ref myFEBclient.arrReg, out r_pointer0);
            Mu2e_Register r_pointer1;
            Mu2e_Register.FindName("HISTO_POINTER_AFE1", ref myFEBclient.arrReg, out r_pointer1);
            Mu2e_Register r_port0;
            Mu2e_Register.FindName("HISTO_PORT_AFE0", ref myFEBclient.arrReg, out r_port0);
            Mu2e_Register r_port1;
            Mu2e_Register.FindName("HISTO_PORT_AFE1", ref myFEBclient.arrReg, out r_port1);
            Mu2e_Register.WriteReg(0, ref r_mux, ref myFEBclient.client);

            for (int i = 0; i < 64; i++)
            {
                if (hdmiChecks.ElementAt(i / 4) == false) continue;

                HISTO_curve myHisto = new HISTO_curve();
                myHisto.list = new PointPairList();
                myHisto.loglist = new PointPairList();
                myHisto.created_time = DateTime.Now;
                myHisto.min_thresh = 0;
                myHisto.max_thresh = 256;
                myHisto.interval = intTime;
                myHisto.chan = Convert.ToInt32(i);
                myHisto.integral = _IntegralScan;
                myHisto.board = _ActiveFEB;
                myHisto.V = Convert.ToDouble(txtV.Text);
                myHisto.I = Convert.ToDouble(txtI.Text);
                int sipm = i % 8;
                int sipm16 = i % 0x10;
                int afe = (i / 8) % 2 + 1;
                UInt16 fpga = (UInt16)(i / 16);
                UInt16 pedaddr = Convert.ToUInt16(128 + sipm16);
                r_CSR.fpga_index = fpga;
                r_ch.fpga_index = fpga;
                r_interval.fpga_index = fpga;
                Mu2e_Register r_ped;
                Mu2e_Register.FindAddr(pedaddr, ref myFEBclient.arrReg, out r_ped);
                r_ped.fpga_index = fpga;
                Mu2e_Register.WriteReg(0xFE0, ref r_ped, ref myFEBclient.client);
                Mu2e_Register.WriteReg(0x60, ref r_CSR, ref myFEBclient.client);
                Mu2e_Register.WriteReg(0x0, ref r_CSR, ref myFEBclient.client);
                //Set histo pointer to 0 before generating histo.
                Mu2e_Register.WriteReg(0x0, ref r_pointer0, ref myFEBclient.client);
                Mu2e_Register.WriteReg(0x0, ref r_pointer1, ref myFEBclient.client);
                Mu2e_Register.WriteReg((uint)(sipm + afe * 32), ref r_ch, ref myFEBclient.client);

                myFEBclient.ReadHisto((uint)i, intTime, out myHisto.list, out myHisto.loglist, out myHisto.max_count);
                PP.FEB1Histo.Add(myHisto);
                ListSipm.Add((i + 1).ToString("00"));
            }
            listBox.DataSource = ListSipm;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            //zedFEB1.GraphPane.CurveList.Clear();
            listBox1.ClearSelected();
            //Mu2e_FEB_client myFEBclient = new Mu2e_FEB_client();
            switch (_ActiveFEB)
            {
                case 1:
                    myFEBclient = PP.FEB1;
                    break;
                case 2:
                    myFEBclient = PP.FEB2;
                    break;
            }

            if (btnScan.Text != "SCAN")
            { flgBreak = true; return; }

            if (ShowSpect.Visible)
            {
                IV_curve myIV = new IV_curve();
                udChan_ValueChanged(null, null);
                myIV.min_v = (double)udStart.Value;
                myIV.max_v = (double)udStop.Value;
                myIV.chan = (Int32)udChan.Value;
                myIV.board = _ActiveFEB;
                decimal v = udStart.Value;
                while ((v < udStop.Value) & !flgBreak)
                {
                    txtV.Text = v.ToString("0.000");
                    btnBiasWRITE_Click(null, null);
                    Application.DoEvents();
                    double I = Convert.ToDouble(txtI.Text);
                    myIV.AddPoint((double)v, (double)I);


                    //plot
                    UpdateDisplay_IV(myIV);
                    double s = 0;

                    btnScan.Text = v.ToString("0.00") + "V";

                    v += udInterval.Value / 1000;

                    System.Threading.Thread.Sleep(10);
                    Application.DoEvents();
                }
                if (_ActiveFEB == 1) { PP.FEB1IVs.Add(myIV); }
                if (_ActiveFEB == 2) { PP.FEB2IVs.Add(myIV); }
                v = udStart.Value;
                txtV.Text = v.ToString("0.000");
                btnBiasWRITE_Click(null, null);
                if (myIV.saved == false) { myIV.Save(); }
                myIV.saved = true;
                myIV.saved_time = DateTime.Now;
            }

            if (ShowIV.Visible)
            {
                #region ShowSpect

                udChan_ValueChanged(null, null);
                System.Threading.Thread.Sleep(100);
                btnBIAS_MON_Click(null, null);
                Application.DoEvents();
                //myHisto.V = Convert.ToDouble(txtV.Text);
                //myHisto.I = Convert.ToDouble(txtI.Text);
                //Fetch registers
                int FPGA_index = (int)udFPGA.Value;
                Mu2e_Register r_CSR;
                Mu2e_Register r_mux;
                Mu2e_Register r_ch;
                Mu2e_Register r_interval;
                Mu2e_Register r_pointer0;
                Mu2e_Register r_pointer1;
                Mu2e_Register r_port0;
                Mu2e_Register r_port1;
                Mu2e_Register r_ped;
                //Mu2e_Register r_th0; //write this last- starts count : bit[12]=1 means still counting
                //Mu2e_Register r_count0;
                //Mu2e_Register r_th1; //write this last- starts count : bit[12]=1 means still counting
                //Mu2e_Register r_count1;

                Mu2e_Register.FindAddr(0x20, ref myFEBclient.arrReg, out r_mux);
                Mu2e_Register.FindName("CSR", ref myFEBclient.arrReg, out r_CSR);
                Mu2e_Register.FindName("HISTO_CTRL_REG", ref myFEBclient.arrReg, out r_ch);
                Mu2e_Register.FindName("HISTO_COUNT_INTERVAL", ref myFEBclient.arrReg, out r_interval);
                Mu2e_Register.FindName("HISTO_POINTER_AFE0", ref myFEBclient.arrReg, out r_pointer0);
                Mu2e_Register.FindName("HISTO_POINTER_AFE1", ref myFEBclient.arrReg, out r_pointer1);
                Mu2e_Register.FindName("HISTO_PORT_AFE0", ref myFEBclient.arrReg, out r_port0);
                Mu2e_Register.FindName("HISTO_PORT_AFE1", ref myFEBclient.arrReg, out r_port1);
                //Mu2e_Register.FindName("HISTO_THRESH_AFE0", ref FEB.arrReg, out r_th0);
                //Mu2e_Register.FindName("HISTO_COUNT0", ref FEB.arrReg, out r_count0);
                //Mu2e_Register.FindName("HISTO_THRESH_AFE1", ref FEB.arrReg, out r_th1);
                //Mu2e_Register.FindName("HISTO_COUNT1", ref FEB.arrReg, out r_count1);

                //r_ch.fpga_index = (ushort)FPGA_index;
                //r_interval.fpga_index = (ushort)FPGA_index;
                //r_th0.fpga_index = (ushort)FPGA_index;
                //r_count0.fpga_index = (ushort)FPGA_index;
                //r_th1.fpga_index = (ushort)FPGA_index;
                //r_count1.fpga_index = (ushort)FPGA_index;

                //set interval & ch & stop
                //UInt32 v = (UInt32)(myHisto.chan);
                //if (v > 7) { v = v - 8; }
                //if (_IntegralScan) { v = v + 8; }
                Mu2e_Register.WriteReg(0, ref r_mux, ref myFEBclient.client);
                //Mu2e_Register.WriteReg(v+96, ref r_ch, ref FEB.client);
                //v = (UInt32)(myHisto.interval);
                //Mu2e_Register.WriteReg(v, ref r_interval, ref FEB.client);

                //myHisto.min_count = 0;

                //loop over th
                //zedFEB1.GraphPane.XAxis.Scale.Max = myHisto.max_thresh;
                //zedFEB1.GraphPane.XAxis.Scale.Min = myHisto.min_thresh;
                zedFEB1.GraphPane.XAxis.Scale.Max = 256;
                zedFEB1.GraphPane.XAxis.Scale.Min = 0;
                zedFEB1.GraphPane.YAxis.Scale.Max = 100;
                zedFEB1.GraphPane.YAxis.Scale.Min = 0;

                listBox1.DataSource = null;
                ListSipm.Clear();
                for (uint i = 0; i < 64; i++)
                {
                    HISTO_curve myHisto = new HISTO_curve();
                    myHisto.list = new PointPairList();
                    myHisto.loglist = new PointPairList();
                    myHisto.created_time = DateTime.Now;
                    //myHisto.min_thresh = (int)udStart.Value;
                    myHisto.min_thresh = 0;
                    //myHisto.max_thresh = (int)udStop.Value;
                    myHisto.max_thresh = 256;
                    myHisto.interval = (int)udInterval.Value;
                    //myHisto.chan = (int)udChan.Value;
                    myHisto.chan = Convert.ToInt32(i);
                    myHisto.integral = _IntegralScan;
                    myHisto.board = _ActiveFEB;
                    myHisto.V = Convert.ToDouble(txtV.Text);
                    myHisto.I = Convert.ToDouble(txtI.Text);

                    bool CmbCheck = false;
                    uint sipm = i % 8;
                    uint sipm16 = i % 0x10;
                    uint afe = 1;
                    UInt16 fpga = 0;
                    switch (i)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            fpga = 0;
                            afe = 1;
                            if (checkBox1.Checked) CmbCheck = true;
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            fpga = 0;
                            afe = 1;
                            if (checkBox2.Checked) CmbCheck = true;
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            fpga = 0;
                            afe = 2;
                            if (checkBox3.Checked) CmbCheck = true;
                            break;
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            fpga = 0;
                            afe = 2;
                            if (checkBox4.Checked) CmbCheck = true;
                            break;
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                            fpga = 1;
                            afe = 1;
                            if (checkBox5.Checked) CmbCheck = true;
                            break;
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                            fpga = 1;
                            afe = 1;
                            if (checkBox6.Checked) CmbCheck = true;
                            break;
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                            fpga = 1;
                            afe = 2;
                            if (checkBox7.Checked) CmbCheck = true;
                            break;
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                            fpga = 1;
                            afe = 2;
                            if (checkBox8.Checked) CmbCheck = true;
                            break;
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                            fpga = 2;
                            afe = 1;
                            if (checkBox9.Checked) CmbCheck = true;
                            break;
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                            fpga = 2;
                            afe = 1;
                            if (checkBox10.Checked) CmbCheck = true;
                            break;
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                            fpga = 2;
                            afe = 2;
                            if (checkBox11.Checked) CmbCheck = true;
                            break;
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                            fpga = 2;
                            afe = 2;
                            if (checkBox12.Checked) CmbCheck = true;
                            break;
                        case 48:
                        case 49:
                        case 50:
                        case 51:
                            fpga = 3;
                            afe = 1;
                            if (checkBox13.Checked) CmbCheck = true;
                            break;
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                            fpga = 3;
                            afe = 1;
                            if (checkBox14.Checked) CmbCheck = true;
                            break;
                        case 56:
                        case 57:
                        case 58:
                        case 59:
                            fpga = 3;
                            afe = 2;
                            if (checkBox15.Checked) CmbCheck = true;
                            break;
                        case 60:
                        case 61:
                        case 62:
                        case 63:
                            fpga = 3;
                            afe = 2;
                            if (checkBox16.Checked) CmbCheck = true;
                            break;
                        default:
                            fpga = 0;
                            afe = 1;
                            break;
                    }
                    r_CSR.fpga_index = fpga;
                    r_ch.fpga_index = fpga;
                    r_interval.fpga_index = fpga;
                    if (CmbCheck == false) continue;

                    UInt16 pedaddr = Convert.ToUInt16(128 + sipm16);

                    Mu2e_Register.FindAddr(pedaddr, ref myFEBclient.arrReg, out r_ped);
                    r_ped.fpga_index = fpga;
                    Mu2e_Register.WriteReg(0xFE0, ref r_ped, ref myFEBclient.client);
                    Mu2e_Register.WriteReg(0x60, ref r_CSR, ref myFEBclient.client);
                    Mu2e_Register.WriteReg(0x0, ref r_CSR, ref myFEBclient.client);
                    //Set histo pointer to 0 before generating histo.
                    Mu2e_Register.WriteReg(0x0, ref r_pointer0, ref myFEBclient.client);
                    Mu2e_Register.WriteReg(0x0, ref r_pointer1, ref myFEBclient.client);
                    Mu2e_Register.WriteReg(sipm + afe * 32, ref r_ch, ref myFEBclient.client);
                    //uint[] histo = new uint[512];
                    myFEBclient.ReadHisto(i, (int)udInterval.Value, out myHisto.list, out myHisto.loglist, out myHisto.max_count);
                    //for (uint j = 0; j < 512; j++)
                    //{
                    //    if (flgBreak) { j = 512; }
                    //    uint count = 0;
                    //    count = histo[j];
                    //    if (count > myHisto.max_count) { myHisto.max_count = count; }
                    //    myHisto.AddPoint((int)j, (int)count);
                    //}
                    PP.FEB1Histo.Add(myHisto);
                    uint SipmNum = i + 1;
                    ListSipm.Add(SipmNum.ToString("00"));
                }
                listBox1.DataSource = ListSipm;

                //myHisto.min_thresh = (int)udStart.Value;
                //myHisto.max_thresh = (int)udStop.Value;
                //if (_ActiveFEB == 1) { PP.FEB1Histo.Add(myHisto[(int)udChan.Value])zedFEB; }
                //if (_ActiveFEB == 2) { PP.FEB2Histo.Add(myHisto[(int)udChan.Value]); }

                Application.DoEvents();
                //UpdateDisplay();
                #endregion ShowSpect
            }
            btnScan.Text = "SCAN";
            flgBreak = false;
            Application.DoEvents();
        }

        private void UpdateDisplay_IV(IV_curve myIV)
        {
            zedFEB1.GraphPane.CurveList.Clear();
            if (chkLogY.Checked)
            {
                if (myIV.min_I < 0)
                { zedFEB1.GraphPane.YAxis.Scale.Min = -2; }
                else if (Math.Round((double)(Math.Log10(myIV.min_I))) < -2)
                { zedFEB1.GraphPane.YAxis.Scale.Min = -2; }
                else
                { zedFEB1.GraphPane.YAxis.Scale.Min = Math.Round((double)(Math.Log10(myIV.min_I))) - .1; }

                zedFEB1.GraphPane.YAxis.Scale.Max = Math.Round((double)(Math.Log10(myIV.max_I * 1000)), 0);

                if (zedFEB1.GraphPane.YAxis.Scale.Max < 0.1) { zedFEB1.GraphPane.YAxis.Scale.Max = 0.1; }

                zedFEB1.GraphPane.AddCurve(myIV.chan.ToString(), myIV.loglist, Color.DarkRed, SymbolType.None);
                zedFEB1.GraphPane.YAxis.Scale.MajorStep = .1 * (double)(Math.Log10(myIV.max_I * 1000));
            }
            else
            {
                zedFEB1.GraphPane.YAxis.Scale.Min = 0.0;
                zedFEB1.GraphPane.YAxis.Scale.Max = Math.Round((double)(myIV.max_I + 0.1 * (myIV.max_I - myIV.min_I)), 0);
                zedFEB1.GraphPane.AddCurve(myIV.chan.ToString(), myIV.list, Color.DarkRed, SymbolType.None);
            }
            double s = Math.Round((double)(myIV.max_v - myIV.min_v) / 10.0, 0);
            if (zedFEB1.GraphPane.XAxis.Scale.MajorStep < s) { zedFEB1.GraphPane.XAxis.Scale.MajorStep = s; }
            zedFEB1.GraphPane.XAxis.Scale.MinorStep = zedFEB1.GraphPane.XAxis.Scale.MajorStep / 4;
            zedFEB1.GraphPane.XAxis.Scale.Min = (double)udStart.Value - .2;
            zedFEB1.GraphPane.XAxis.Scale.Max = (double)udStop.Value + .2;

            s = Math.Round((myIV.max_I - myIV.min_I) / 10.0, 0);
            zedFEB1.GraphPane.YAxis.Scale.MinorStep = zedFEB1.GraphPane.YAxis.Scale.MajorStep / 4;

            zedFEB1.Invalidate(true);
            Application.DoEvents();
        }

        private void UpdateDisplay(object sender)
        {
            Color[] this_color = new Color[12];
            Histo_helper.InitColorList(ref this_color);
            ZedGraphControl zgControl = new ZedGraphControl();
            ListBox listBox = new ListBox();
            CheckBox checkLog = new CheckBox();
            if (sender == listBox1 || sender == chkLogY || sender == chkIntegral)
            {
                zgControl = zedFEB1;
                listBox = listBox1;
                checkLog = chkLogY;
            }
            else if (sender == listBoxHistos || sender == chkLogYHist)
            {
                zgControl = zedGraphHisto;
                listBox = listBoxHistos;
                checkLog = chkLogYHist;
            }
            else
            { return; }

            if (listBox.SelectedItem != null)
            {
                string SipmSel = listBox.SelectedItem.ToString();

                int SipmNum = Int32.Parse(SipmSel) - 1;

                List<HISTO_curve> myHistoList = null;
                zgControl.GraphPane.CurveList.Clear();

                myHistoList = PP.FEB1Histo;
                //if (_ActiveFEB == 2) { myHistoList = PP.FEB2Histo; }

                HISTO_curve h1 = myHistoList.Find(x => x.chan == SipmNum);
                int logMax = (int)Math.Ceiling(Math.Log10(h1.max_count));
                if (checkLog.Checked)
                {
                    zgControl.GraphPane.YAxis.Scale.Max = logMax;
                    zgControl.GraphPane.YAxis.Scale.MajorStep = 1;
                    zgControl.GraphPane.YAxis.Scale.MinorStep = 0.5;
                    zgControl.GraphPane.AddCurve(h1.chan.ToString(), h1.loglist, Color.DarkRed, SymbolType.None);
                    zgControl.GraphPane.YAxis.Title.Text = "Log Counts";
                }
                else
                {
                    int yStep = (int)Math.Pow(10, logMax - 1);
                    zgControl.GraphPane.YAxis.Scale.Max = h1.max_count * 1.1;
                    zgControl.GraphPane.YAxis.Scale.MajorStep = yStep;
                    zgControl.GraphPane.YAxis.Scale.MinorStep = yStep / 5;
                    zgControl.GraphPane.AddCurve(h1.chan.ToString(), h1.list, Color.DarkBlue, SymbolType.None);
                    zgControl.GraphPane.YAxis.Title.Text = "Counts";
                }
                zgControl.GraphPane.XAxis.Scale.Max = 512;
                //zgControl.GraphPane.XAxis.Scale.Min = 0;
                //zgControl.GraphPane.YAxis.Scale.Min = 0;
                zgControl.GraphPane.Title.Text = "Channel " + (SipmNum + 1).ToString();
                zgControl.GraphPane.XAxis.Title.Text = "Amplitude (ADC Counts)";

                double s = 0;
                s = Math.Round((double)(h1.max_thresh - h1.min_thresh) / 10.0, 0);
                if (zgControl.GraphPane.XAxis.Scale.MajorStep < s)
                { zgControl.GraphPane.XAxis.Scale.MajorStep = s; }
                zgControl.GraphPane.XAxis.Scale.MinorStep = zgControl.GraphPane.XAxis.Scale.MajorStep / 4;
                s = Math.Round((h1.max_count - h1.min_count) / 10.0, 0);
                //if (zgControl.GraphPane.YAxis.Scale.MajorStep < s)
                //{ zgControl.GraphPane.YAxis.Scale.MajorStep = s; }
                //zgControl.GraphPane.YAxis.Scale.MinorStep = zgControl.GraphPane.YAxis.Scale.MajorStep / 4;
            }
            zgControl.Refresh();
            //Application.DoEvents();
        }

        private void btnCHANGE_Click(object sender, EventArgs e)
        {
            string[,] s = new string[5, num_reg];
            int max_index = 4;
            int index = Convert.ToInt32(btnCHANGE.Tag);
            if (index + 1 > max_index) { btnCHANGE.Tag = Convert.ToString(0); }
            else { btnCHANGE.Tag = Convert.ToString(index + 1); }

            s[0, 0] = "CSR";
            s[0, 1] = "SDRAM_WritePointer";
            s[0, 2] = "SDRAM_ReadPointer";
            s[0, 3] = "TEST_PULSE_FREQ";
            s[0, 4] = "TEST_PULSE_DURATION";
            s[0, 5] = "EVENT_WORD_COUNT";
            s[0, 6] = "CHAN_MASK";
            s[0, 7] = "MUX_SEL";
            s[0, 8] = "TRIG_CONTROL";
            s[0, 9] = "SPILL_TRIG_COUNT";
            s[0, 10] = "SPILL_NUMBER";
            s[0, 11] = "SPILL_STATE";
            s[0, 12] = "SPILL_ERROR";
            s[0, 13] = "SPILL_WORD_COUNT";
            s[0, 14] = "SPILL_TRIG_COUNT";

            s[1, 0] = "CSR";
            s[1, 1] = "HISTO_CTRL_REG";
            s[1, 2] = "HISTO_COUNT_INTERVAL";
            s[1, 3] = "HISTO_PED_AFE0";
            s[1, 4] = "HISTO_PED_AFE1";
            s[1, 5] = "HISTO_POINTER_AFE0";
            s[1, 6] = "HISTO_POINTER_AFE1";
            s[1, 7] = "MUX_SEL";
            s[1, 8] = "HISTO_PORT_AFE0";
            s[1, 9] = "HISTO_PORT_AFE1";
            s[1, 10] = "CHAN_MASK";
            s[1, 11] = "AFE_VGA0";
            s[1, 12] = "AFE_VGA1";
            s[1, 13] = "FLASH_GATE_CONTROL";
            s[1, 14] = "UPTIME";

            s[2, 0] = "CSR";
            s[2, 1] = "MIG_Status";
            s[2, 2] = "MIG_fifo_count";
            s[2, 3] = "CHAN_MASK";
            s[2, 4] = "NUM_SAMPLE_REG";
            s[2, 5] = "TRIG_CONTROL";
            s[2, 6] = "AFE_INPUT_FIFO_EMPTY_FLAG";
            s[2, 7] = "MUX_SEL";
            s[2, 8] = "BIAS_BUS_DAC0";
            s[2, 9] = "BIAS_BUS_DAC1";
            s[2, 10] = "AFE_VGA0";
            s[2, 11] = "AFE_VGA1";
            s[2, 12] = "SPILL_NUMBER";
            s[2, 13] = "SPILL_WORD_COUNT";
            s[2, 14] = "SPILL_TRIG_COUNT";

            s[3, 0] = "TRIG_CONTROL";
            s[3, 1] = "NUM_SAMPLE_REG";
            s[3, 2] = "HIT_DEL_REG";
            s[3, 3] = "TEST_PULSE_DURATION";
            s[3, 4] = "TEST_PULSE_INTERSPILL";
            s[3, 5] = "TEST_PULSE_DELAY";
            s[3, 6] = "SPILL_NUMBER";
            s[3, 7] = "SPILL_TRIG_COUNT";
            s[3, 8] = "SPILL_WORD_COUNT";
            s[3, 9] = "CHAN_MASK";
            s[3, 10] = "SPILL_STATE";
            s[3, 11] = "CSR";
            s[3, 12] = "SDRAM_ReadPointer";
            s[3, 13] = "SDRAM_WritePointer";
            s[3, 14] = "UPTIME";

            s[4, 0] = "BIAS_DAC_CH0";
            s[4, 1] = "BIAS_DAC_CH1";
            s[4, 2] = "BIAS_DAC_CH2";
            s[4, 3] = "BIAS_DAC_CH3";
            s[4, 4] = "BIAS_DAC_CH4";
            s[4, 5] = "BIAS_DAC_CH5";
            s[4, 6] = "BIAS_DAC_CH6";
            s[4, 7] = "BIAS_DAC_CH7";
            s[4, 8] = "BIAS_DAC_CH8";
            s[4, 9] = "BIAS_DAC_CH9";
            s[4, 10] = "BIAS_DAC_CH10";
            s[4, 11] = "BIAS_DAC_CH11";
            s[4, 12] = "BIAS_DAC_CH12";
            s[4, 13] = "BIAS_DAC_CH13";
            s[4, 14] = "BIAS_DAC_CH14";

            Mu2e_Register r1;
            for (int i = 0; i < num_reg; i++)
            {
                rnames[i] = s[index, i];
                txtREGISTERS[i].Tag = i;

                Mu2e_Register.FindName(rnames[i], ref PP.FEB1.arrReg, out r1);
                lblREG[i].Text = rnames[i] + "(x" + Convert.ToString(r1.addr, 16) + ")";
            }

            btnRegREAD_Click(null, null);
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            zedFEB1.GraphPane.CurveList.Clear();
            zedFEB1.Invalidate(true);
            List<HISTO_curve> myHistoList = null;
            List<HISTO_curve> EraseHistoList = null;
            if (_ActiveFEB == 1) { myHistoList = PP.FEB1Histo; }
            if (_ActiveFEB == 2) { myHistoList = PP.FEB2Histo; }


            //foreach (HISTO_curve h1 in myHistoList)
            //{
            //    if (h1.saved) { myHistoList.Remove(h1); }
            //}
            myHistoList.Clear();
        }

        private void btnTestSpill_Click(object sender, EventArgs e)
        {
            bool in_spill;
            string s_num_trig;
            UInt32 num_trig;
            string s_WC_time;
            //--->            mu2e_Event ev = new mu2e_Event();

            WC_client.check_status(out in_spill, out s_num_trig, out s_WC_time);
            try { num_trig = Convert.ToUInt32("0x0" + s_num_trig, 16); }
            catch { num_trig = 0; }


            Mu2e_Register r2;
            Mu2e_Register.FindName("TRIG_CONTROL", ref PP.FEB1.arrReg, out r2);
            // Mu2e_Register.WriteReg(0x0350, ref r2, ref PP.FEB1.client);
            Mu2e_Register r3;
            Mu2e_Register.FindName("SPILL_STATE", ref PP.FEB1.arrReg, out r3);
            System.Threading.Thread.Sleep(250);
            Mu2e_Register.ReadReg(ref r3, ref PP.FEB1.client);



            //if (_ActiveFEB == 1)
            //{
            //    while (r3.val < 6)
            //    {
            //        System.Threading.Thread.Sleep(250);
            //        Application.DoEvents();
            //        Mu2e_Register.ReadReg(ref r3, ref PP.FEB1.client);
            //        Console.WriteLine("waiting for spill to start");
            //    }

            //    while (r3.val == 6)
            //    {
            //        System.Threading.Thread.Sleep(250);
            //        Mu2e_Register.ReadReg(ref r3, ref PP.FEB1.client);
            //        Console.WriteLine("still in spill");
            //    }
            //    PP.FEB1.ReadAll(ref ev, ref PP.FEB1.client);
            //}
            //else if (_ActiveFEB == 2)
            {

                if (!in_spill) { WC_client.FakeSpill(); in_spill = true; }

                while (in_spill)
                {
                    System.Threading.Thread.Sleep(250);
                    WC_client.check_status(out in_spill, out s_num_trig, out s_WC_time);

                    Console.Write(in_spill.ToString() + " ");
                    Mu2e_Register.ReadReg(ref r3, ref PP.FEB1.client);
                    Console.Write(r3.val.ToString() + " ");
                    Mu2e_Register.ReadReg(ref r3, ref PP.FEB2.client);
                    Console.Write(r3.val.ToString() + " ");
                }
                //PP.FEB2.ReadAll(ref ev, ref PP.FEB2.client);
                //PP.FEB1.ReadAll(ref ev, ref PP.FEB1.client);
                int len = 0;
                WC_client.read_TDC(out len);
                Console.WriteLine(" ");
                Console.WriteLine(len);
                Console.WriteLine("done ");

            }

            //Mu2e_Register r2;
            //Mu2e_Register.FindName("SPILL_TRIG_COUNT", ref PP.FEB2.arrReg, out r2);
            //r2.fpga_index = 0;
            //Mu2e_Register.ReadReg(ref r2, ref PP.FEB2.client);
            //if (r2.val == 0)
            //{
            //    MessageBox.Show("0 trig found in  FEB2.FPGA0  ");
            //}
            ////else if (r2.val != num_trig)
            ////{
            ////    MessageBox.Show("trig count mismatch: WC=" + num_trig + " FEB2.FPGA0=  " + r2.val);
            ////}
            //else
            //{
            //    if (_ActiveFEB == 2)
            //    {
            //        PP.FEB2.ReadAll(ref ev);
            //    }
            //}
        }

        private void chkLogY_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowIV.Visible)
            { UpdateDisplay(sender); }
            if (ShowSpect.Visible)
            {
                if (_ActiveFEB == 1)
                {
                    if (PP.FEB1IVs.Count > 0) { UpdateDisplay_IV(PP.FEB1IVs.Last()); }
                }
                if (_ActiveFEB == 2)
                {
                    if (PP.FEB2IVs.Count > 0) { UpdateDisplay_IV(PP.FEB2IVs.Last()); }
                }
            }
        }

        private void chkIntegral_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIntegral.Checked) { _IntegralScan = true; }
            else { _IntegralScan = false; }
            UpdateDisplay(sender);
        }

        private void btnSaveHistos_Click(object sender, EventArgs e)
        {
            if (ShowIV.Visible)
            {
                List<HISTO_curve> myHistoList = null;
                if (_ActiveFEB == 1) { myHistoList = PP.FEB1Histo; }
                if (_ActiveFEB == 2) { myHistoList = PP.FEB2Histo; }

                string hName = "";
                string dirName = "c://data//";
                string preamble = "";
                string header = "";
                DateTime testDate = DateTime.Now;

                hName += "FEB_histo_";
                hName += txtSN.Text;
                hName += "_" + testDate.ToString("yyyyMMdd_HHmm");
                hName = dirName + hName + ".csv";

                preamble += "-- serial number: " + txtSN.Text + "\n" + "-- tested on: " + testDate.ToString();
                header += "Channel, V, I";
                for (int i = 0; i < 512; i++)
                {
                    header += ", " + i.ToString();
                }
                StreamWriter sw = new StreamWriter(hName);
                sw.WriteLine(preamble);
                sw.WriteLine(header);

                foreach (HISTO_curve h1 in myHistoList)
                {
                    string histoLine = "";
                    histoLine += h1.chan.ToString() + ", " + h1.V.ToString() + ", " + h1.I.ToString();
                    foreach (PointPair p in h1.list)
                    {
                        histoLine += ", " + p.Y.ToString();
                    }
                    sw.WriteLine(histoLine);
                }
                sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PP.FEB1.ClientOpen) { PP.FEB1.Close(); dbgFEB1.BackColor = Color.LightGray; btnFEB1.BackColor = Color.LightGray; }
            if (PP.FEB2.ClientOpen) { PP.FEB2.Close(); dbgFEB2.BackColor = Color.LightGray; btnFEB2.BackColor = Color.LightGray; }
        }

        private void ShowIV_Click(object sender, EventArgs e)
        {
            ShowIV.Visible = false;
            ShowSpect.Visible = true;
            chkIntegral.Visible = false;
            udStart.DecimalPlaces = 1;
            udStart.Minimum = 0;
            udStart.Maximum = 80;
            udStart.Value = 60;
            udStart.Increment = (decimal)0.1;
            udStop.DecimalPlaces = 1;
            udStop.Minimum = 1;
            udStop.Maximum = 80;
            udStop.Value = 70;
            udStop.Increment = (decimal)0.1;
            lblInc.Text = "Step (mv)";
            udInterval.Minimum = (decimal)50;
            udInterval.Maximum = 1000;
            udInterval.Value = (decimal)100;
            udInterval.Increment = (decimal)50;
            Application.DoEvents();
        }

        private void ShowSpect_Click(object sender, EventArgs e)
        {
            ShowIV.Visible = true;
            ShowSpect.Visible = false;
            udStart.DecimalPlaces = 0;
            udStop.DecimalPlaces = 0;
            chkIntegral.Visible = true;
            udStart.Minimum = 0;
            udStart.Maximum = 4000;
            udStart.Value = 2000;
            udStart.Increment = (decimal)100;
            udStop.Minimum = 0;
            udStop.Maximum = 4000;
            udStop.Value = 2200;
            udStop.Increment = (decimal)100;
            lblInc.Text = "Time (ms)";
            udInterval.Minimum = (decimal)1;
            udInterval.Maximum = 255;
            udInterval.Value = (decimal)25;
            udInterval.Increment = (decimal)1;
            Application.DoEvents();
        }

        private void btnConnectAll_Click(object sender, EventArgs e)
        {
            if (chkWC.Checked)
            { button1_Click((object)btnWC, e); }
            Application.DoEvents();
            if (chkFEB1.Checked)
            { button1_Click((object)btnFEB1, e); }
            Application.DoEvents();
            if (chkFEB2.Checked)
            { button1_Click((object)btnFEB2, e); }
            Application.DoEvents();
        }

        private void udChan_ValueChanged(object sender, EventArgs e)
        {
            int FPGA_index = (int)udFPGA.Value;
            uint chan = 0;
            Mu2e_Register mux_reg = new Mu2e_Register();
            //Mu2e_FEB_client myFEBclient = new Mu2e_FEB_client();
            //if (_ActiveFEB == 1) { myFEBclient = PP.FEB1; }
            //if (_ActiveFEB == 2) { myFEBclient = PP.FEB2; }
            chan = (uint)udChan.Value;
            mux_reg.fpga_index = (ushort)FPGA_index;
            if (myFEBclient != null)
            {
                Mu2e_Register.FindAddr(0x020, ref myFEBclient.arrReg, out mux_reg);
                if (chan < 16)
                {
                    uint v = (uint)(0x10 + chan);
                    Mu2e_Register.WriteReg(v, ref mux_reg, ref myFEBclient.client);
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool in_spill;

            if (PP.myRun != null) //HACK: Kres, I found this error where myRun = null and threw lots of errors. you might want to ensure this is what you intend. The line you had is above. Stephen
            {
                //Console.WriteLine("timer");
                try
                {
                    TimeSpan since_last_spill = DateTime.Now.Subtract(PP.myRun.timeLastSpill);
                    lblSpillTime.Text = since_last_spill.TotalSeconds.ToString("0.0");
                    if ((since_last_spill.TotalSeconds > 1) && (PP.myRun.spill_complete))
                    {
                        Mu2e_Register r_spill;
                        Mu2e_Register.FindName("TRIG_CONTROL", ref PP.FEB1.arrReg, out r_spill);
                        if (!PP.myRun.OneSpill)
                        { Mu2e_Register.WriteReg(0x300, ref r_spill, ref PP.FEB1.client); }
                    }
                    if (PP.myRun != null)
                    {
                        lblFEB1_TotTrig.Text = PP.myRun.total_trig[0].ToString();
                        lblFEB2_TotTrig.Text = PP.myRun.total_trig[1].ToString();
                        lblWC_TotTrig.Text = PP.myRun.total_trig[2].ToString();
                        if (PP.myRun.ACTIVE)
                        {
                            lblRunTime.Text = DateTime.Now.Subtract(PP.myRun.created).Seconds.ToString("0.0");
                            if ((since_last_spill.Seconds > 2) & (since_last_spill.Seconds < 1000))
                            {
                                if (PP.myRun.spill_complete == false)
                                {

                                    PP.myRun.RecordSpill();
                                    if (PP.myRun.OneSpill)
                                    {
                                        //display it
                                        PP.myRun.DeactivateRun();
                                    }
                                    else
                                    {


                                    }
                                }
                            }
                        }
                    }
                }
                catch { }// timer1.Enabled = false; }

                if (PP.myRun != null) //update log
                {
                    lblRunName.Text = "Run_" + PP.myRun.num.ToString();
                    lblRunLog.Text = "";
                    string[] all_m = PP.myRun.RunStatus.ToArray<string>();
                    int l = all_m.Length;
                    if (PP.myRun.RunStatus.Count > 13)
                    {
                        for (int i = l - 13; i < l; i++)
                        { lblRunLog.Text += all_m[i] + "\r\n"; }
                    }
                    else
                    {
                        for (int i = 0; i < all_m.Length; i++)
                        { lblRunLog.Text += all_m[i] + "\r\n"; }
                    }


                    if (PP.myRun.fake)
                    {
                        if ((PP.FEB1.ClientOpen) && (chkFEB1.Checked))
                        {

                            uint spill_status = 0;
                            uint spill_num = 0;
                            uint trig_num = 0;
                            PP.FEB1.CheckStatus(out spill_status, out spill_num, out trig_num);
                            if (spill_status > 2) { in_spill = true; } else { in_spill = false; }
                            lblSpillFEB1.Text = spill_status.ToString();
                            lblFEB1TrigNum.Text = trig_num.ToString();
                            if (in_spill)
                            {
                                if (PP.myRun != null)
                                {
                                    PP.myRun.timeLastSpill = DateTime.Now;
                                    PP.myRun.UpdateStatus("Detected spill. Run file is " + PP.myRun.OutFileName);
                                    PP.myRun.spill_complete = false;
                                }
                            }

                        }
                    }

                    else //if (!PP.myRun.fake)
                    {
                        if (PP.FEB1.ClientOpen)
                        {
                            uint spill_status = 0;
                            uint spill_num = 0;
                            uint trig_num = 0;
                            PP.FEB1.CheckStatus(out spill_status, out spill_num, out trig_num);
                            lblSpillFEB1.Text = spill_status.ToString();
                            lblFEB1TrigNum.Text = trig_num.ToString();
                        }

                        if (PP.FEB2.ClientOpen)
                        {
                            uint spill_status = 0;
                            uint spill_num = 0;
                            uint trig_num = 0;
                            PP.FEB2.CheckStatus(out spill_status, out spill_num, out trig_num);
                            lblSpillFEB2.Text = spill_status.ToString();
                            lblFEB2TrigNum.Text = trig_num.ToString();
                        }

                        if (PP.WC.ClientOpen)
                        {

                            string num_trig;
                            string mytime;
                            WC_client.check_status(out in_spill, out num_trig, out mytime);
                            lblSpillWC.Text = in_spill.ToString();

                            if (in_spill)
                            {
                                if (PP.myRun != null)
                                {
                                    PP.myRun.timeLastSpill = DateTime.Now;
                                    PP.myRun.UpdateStatus("Detected spill. Run file is " + PP.myRun.OutFileName);
                                    PP.myRun.spill_complete = false;
                                }
                            }


                            lblWCTrigNum.Text = num_trig;
                        }
                    }
                }
            }
        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {
            if ((!PP.FEB1.ClientOpen && chkFEB1.Checked) || (!PP.FEB2.ClientOpen && chkFEB2.Checked) || (!PP.WC.ClientOpen && chkWC.Checked))
            { MessageBox.Show("Are all clients open?"); }
            //timer1.Enabled = false;
            PP.myRun = new Run();
            if (chkFakeIt.Checked) { PP.myRun.fake = true; }
            else { PP.myRun.fake = false; }

            if (PP.myRun.fake == false)
            #region notfake
            {
                WC_client.DisableTrig();
                PP.myRun.UpdateStatus("waiting for spill to disable WC");
                if (!PP.WC.in_spill) { WC_client.FakeSpill(); }
                int spill_timeout = 0;
                int big_count = 0;
                bool inspill = false;
                string X = "";
                string Y = "";
                lblRunTime.Text = "not running";
                PP.myRun.ACTIVE = false;
                while (!inspill)
                {
                    Console.WriteLine("waiting for spill");
                    System.Threading.Thread.Sleep(200);
                    Application.DoEvents();
                    WC_client.check_status(out inspill, out X, out Y);
                    spill_timeout++;
                    if (spill_timeout > 500) { WC_client.FakeSpill(); spill_timeout = 0; big_count++; }
                    if (big_count > 3) { MessageBox.Show("can't get a spill..."); return; }
                }
                PP.myRun.UpdateStatus("in spill....");
                while (PP.WC.in_spill)
                {
                    Console.WriteLine("waiting for spill to end");
                    System.Threading.Thread.Sleep(200);
                    WC_client.check_status(out inspill, out X, out Y);
                    Application.DoEvents();
                }
                PP.myRun.UpdateStatus("Prepairing FEB1 and FEB2");
                //            PP.FEB1.GetReady();
                //            PP.FEB2.GetReady();
                PP.myRun.UpdateStatus("Arming WC");
                if (!PP.WC.in_spill) { WC_client.EnableTrig(); }
                lblRunName.Text = PP.myRun.run_name;
                timer1.Enabled = true;
            }
            #endregion notfake
            else
            {
                PP.myRun.UpdateStatus("Fake Run- sending spills to FEB1");
                lblRunName.Text = PP.myRun.run_name;
                timer1.Enabled = true;
            }
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            if (PP.myRun != null)
            {
                PP.myRun.ActivateRun(); PP.myRun.UpdateStatus("Run STARTING");
                PP.myRun.OneSpill = false;
            }

        }

        private void btnOneSpill_Click(object sender, EventArgs e)
        {
            Mu2e_Register r_spill;
            Mu2e_Register.FindName("TRIG_CONTROL", ref PP.FEB1.arrReg, out r_spill);
            //Mu2e_Register.WriteReg(0x300, ref r_spill, ref PP.FEB1.client);
            if (PP.myRun != null)
            {
                PP.myRun.ActivateRun(); PP.myRun.UpdateStatus("Run STARTING in ONE SPILL MODE");
                Mu2e_Register.WriteReg(0x300, ref r_spill, ref PP.FEB1.client);
                PP.myRun.OneSpill = true;
            }
        }

        private void btnStopRun_Click(object sender, EventArgs e)
        {
            if (PP.myRun != null)
            {
                PP.myRun.DeactivateRun();
                PP.myRun.UpdateStatus("Run STOPPING");
                timer1.Enabled = false;
            }
        }

        private void chkFakeIt_CheckedChanged(object sender, EventArgs e)
        {
            if (PP.WC.ClientOpen)
            {
                if (chkFakeIt.Checked) { WC_client.ForeverFake(); }
                else { WC_client.DisableFake(); }
            }
            if (chkFakeIt.Checked) { btnOneSpill.Visible = true; } else { btnOneSpill.Visible = false; }

        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            ClientNameChange frmChange = new ClientNameChange();
            frmChange.ShowDialog();
            btnFEB1.Text = PP.FEB1.host_name_prop;
            btnFEB2.Text = PP.FEB2.host_name_prop;
        }

        private void btnDisplaySpill_Click(object sender, EventArgs e)
        {
            if (btnDisplaySpill.Text == "DISPLAY")
            {
                if (PP.myRun != null)
                {
                    if (PP.myRun.Spills != null)
                    {
                        if (PP.myRun.Spills.Count > 0)
                        {
                            PP.myRun.Spills.Last().IsDisplayed = true;

                            DispSpill = PP.myRun.Spills.Last();
                            btnDisplaySpill.Text = "DONE";

                            for (int i = 0; i < DispSpill.ExpectNumCh; i++)
                            {
                                this.chkChEnable[i].Visible = true;
                            }
                            lblEventCount.Text = "Spill " + DispSpill.SpillCounter + "," + DispSpill.SpillEvents.Count + " e";
                            txtEvent.Text = Convert.ToString(1);
                            DispEvent = DispSpill.SpillEvents.First();
                            txtEvent.Text = DispEvent.TrigCounter.ToString();
                            UpdateEventDisplay();
                        }
                    }
                }
            }
            else
            {
                btnDisplaySpill.Text = "DISPLAY";
                foreach (SpillData aSpill in PP.myRun.Spills)
                {
                    if (aSpill.IsDisplayed) { aSpill.IsDisplayed = false; }
                }
                for (int i = 0; i < 64; i++)
                {
                    this.chkChEnable[i].Visible = false;
                }
            }
        }

        private void btnNextDisp_Click(object sender, EventArgs e)
        {
            try
            {
                LinkedListNode<mu2e_Event> node = DispSpill.SpillEvents.Find(DispEvent).Next;
                DispEvent = node.Value;
                txtEvent.Text = DispEvent.TrigCounter.ToString();
                UpdateEventDisplay();
            }
            catch { }
        }

        private void btnPrevDisp_Click(object sender, EventArgs e)
        {
            try
            {
                LinkedListNode<mu2e_Event> node = DispSpill.SpillEvents.Find(DispEvent).Previous;
                DispEvent = node.Value;
                txtEvent.Text = DispEvent.TrigCounter.ToString();
                UpdateEventDisplay();
            }
            catch { }

        }

        private void UpdateEventDisplay()
        {//zg1
            Color[] this_color = new Color[12];
            mu2e_Ch[] cha = DispEvent.ChanData.ToArray();
            zg1.GraphPane.CurveList.Clear();
            double[] x = new double[cha[0].data.Count() - 1];
            double[] y = new double[cha[0].data.Count() - 1];
            zg1.GraphPane.YAxis.Scale.Max = Convert.ToDouble(ud_VertMax.Value);
            zg1.GraphPane.YAxis.Scale.Min = Convert.ToDouble(ud_VertMin.Value);
            zg1.GraphPane.XAxis.Scale.Max = Convert.ToDouble(x.Count());
            zg1.GraphPane.XAxis.Scale.Min = Convert.ToDouble(1);
            zg1.GraphPane.YAxis.Scale.MajorStep = 0.2 * (Convert.ToDouble(ud_VertMax.Value) - Convert.ToDouble(ud_VertMin.Value));
            zg1.GraphPane.XAxis.Scale.MajorStep = 10;
            zg1.GraphPane.YAxis.Scale.MinorStep = 0.2 * zg1.GraphPane.YAxis.Scale.MajorStep;
            zg1.GraphPane.XAxis.Scale.MinorStep = 0.2 * zg1.GraphPane.XAxis.Scale.MajorStep;

            for (int i = 0; i < x.Count(); i++)
            { x[i] = i + 1; }

            for (int i = 0; i < 32; i++)
            {
                if (chkChEnable[i].Checked)
                {
                    try
                    {
                        for (int j = 0; j < x.Count(); j++)
                        {
                            y[j] = cha[i].data[j + 1];
                        }
                        zg1.GraphPane.AddCurve(cha[i].data[0].ToString(), x, y, Color.DarkRed, SymbolType.None);
                    }
                    catch { Console.WriteLine("ch does not exist"); }
                }

            }
            zg1.Invalidate(true);
            Application.DoEvents();
        }

        private void btnDebugLogging_Click(object sender, EventArgs e)
        {
            string hName = "";
            if (btnDebugLogging.Text.Contains("START LOG"))
            {
                btnDebugLogging.Text = "STOP LOG";
                hName = "FEB" + _ActiveFEB + "_commands_";
                hName += "_" + DateTime.Now.Year.ToString("0000");
                hName += DateTime.Now.Month.ToString("00");
                hName += DateTime.Now.Day.ToString("00");
                hName += "_" + DateTime.Now.Hour.ToString("00");
                hName += DateTime.Now.Minute.ToString("00");
                hName += DateTime.Now.Second.ToString("00");
            }
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSnSave_Click(object sender, EventArgs e)
        {
            myFEB.FEBserialNum = txtSN.Text;
            myFEBclient.SendStr("SN 123 " + txtSN.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDisplay(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && 
                checkBox2.Checked && 
                checkBox3.Checked && 
                checkBox4.Checked && 
                checkBox5.Checked && 
                checkBox6.Checked && 
                checkBox7.Checked && 
                checkBox8.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox9.Checked && 
                checkBox10.Checked && 
                checkBox11.Checked && 
                checkBox12.Checked && 
                checkBox13.Checked && 
                checkBox14.Checked && 
                checkBox15.Checked && 
                checkBox16.Checked)
            {
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
            }
            else
            {
                checkBox9.Checked = true;
                checkBox10.Checked = true;
                checkBox11.Checked = true;
                checkBox12.Checked = true;
                checkBox13.Checked = true;
                checkBox14.Checked = true;
                checkBox15.Checked = true;
                checkBox16.Checked = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int fpga = 0; fpga < 4; fpga++)
            {
                PP.FEB1.SetV(Convert.ToDouble(textBox2.Text), fpga);
            }
        }

        private void btnLoadCalib_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\data\\";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    string fileLine = "";
                    while ((fileLine = sr.ReadLine()) != null)
                    {
                        PP.FEB1.SendStr(fileLine);
                        System.Threading.Thread.Sleep(1);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSelLowHist_Click(object sender, EventArgs e)
        {
            if (chkBoxJ11.Checked && 
                chkBoxJ12.Checked && 
                chkBoxJ13.Checked && 
                chkBoxJ14.Checked && 
                chkBoxJ15.Checked && 
                chkBoxJ16.Checked && 
                chkBoxJ17.Checked && 
                chkBoxJ18.Checked)
            {
                chkBoxJ11.Checked = false;
                chkBoxJ12.Checked = false;
                chkBoxJ13.Checked = false;
                chkBoxJ14.Checked = false;
                chkBoxJ15.Checked = false;
                chkBoxJ16.Checked = false;
                chkBoxJ17.Checked = false;
                chkBoxJ18.Checked = false;
            }
            else
            {
                chkBoxJ11.Checked = true;
                chkBoxJ12.Checked = true;
                chkBoxJ13.Checked = true;
                chkBoxJ14.Checked = true;
                chkBoxJ15.Checked = true;
                chkBoxJ16.Checked = true;
                chkBoxJ17.Checked = true;
                chkBoxJ18.Checked = true;
            }
        }

        private void btnSelHiHist_Click(object sender, EventArgs e)
        {
            if (chkBoxJ19.Checked && 
                chkBoxJ20.Checked && 
                chkBoxJ21.Checked && 
                chkBoxJ22.Checked && 
                chkBoxJ23.Checked && 
                chkBoxJ24.Checked && 
                chkBoxJ25.Checked && 
                chkBoxJ26.Checked)
            {
                chkBoxJ19.Checked = false;
                chkBoxJ20.Checked = false;
                chkBoxJ21.Checked = false;
                chkBoxJ22.Checked = false;
                chkBoxJ23.Checked = false;
                chkBoxJ24.Checked = false;
                chkBoxJ25.Checked = false;
                chkBoxJ26.Checked = false;
            }
            else
            {
                chkBoxJ19.Checked = true;
                chkBoxJ20.Checked = true;
                chkBoxJ21.Checked = true;
                chkBoxJ22.Checked = true;
                chkBoxJ23.Checked = true;
                chkBoxJ24.Checked = true;
                chkBoxJ25.Checked = true;
                chkBoxJ26.Checked = true;
            }
        }

        void updateTemp()
        {
            if (myFEBclient.ClientOpen)
            {
                string cmb_reg;
                DateTime updateTime = DateTime.Now;
                int checkCount = 0;
                do { myFEBclient.ReadCMB(out cmb_reg); }
                while (cmb_reg.Length == 0 && checkCount < 0);
                //cmb_reg += Environment.NewLine + Environment.NewLine + updateTime.ToString("HH:mm:ss");
                labelTempHist.Text = cmb_reg; 
            }
        }

        void GetVoltageSetting(TrimSignal trimsig)
        {
            //Must be done in frmMain due to TCP client issues.
            //Gets value from register and sets value in trimsig if different.
            double vsig = trimsig.voltageSetting;
            Mu2e_Register reg = new Mu2e_Register();
            Mu2e_Register.FindAddr((ushort)(48 + trimsig.signalIndex), ref myFEBclient.arrReg, out reg);
            reg.fpga_index = trimsig.myFPGA_ID;
            Mu2e_Register.ReadReg(ref reg, ref myFEBclient.client);
            double vreg = ((double)trimsig.register.val - 2048) / 500;
            if (vreg != vsig)
            {
                trimsig.voltageSetting = vreg;
                trimsig.myMeasurements.isUpToDate = false;
            }
        }

        void GetVoltageSetting(LEDsignal ledsig)
        {
            //Must be done in frmMain due to TCP client issues.
            //Gets value from register and sets value in ledsig if different.
            double vsig = ledsig.voltageSetting;
            Mu2e_Register reg = new Mu2e_Register();
            Mu2e_Register.FindAddr((ushort)(64 + ledsig.signalIndex), ref myFEBclient.arrReg, out reg);
            reg.fpga_index = ledsig.myFPGA_ID;
            Mu2e_Register.ReadReg(ref reg, ref myFEBclient.client);
            double vreg = (double)ledsig.register.val * 17 / 4700;
            if (vreg != vsig)
            {
                ledsig.voltageSetting = vreg;
                ledsig.myMeasurements.isUpToDate = false;
            }
        }

        void GetVoltageSetting(BiasChannel biaschan)
        {
            //Must be done in frmMain due to TCP client issues.
            //Gets value from register and sets value in trimsig if different.
            double vsig = biaschan.voltageSetting;
            Mu2e_Register reg = new Mu2e_Register();
            Mu2e_Register.FindAddr((ushort)(68 + biaschan.signalIndex), ref myFEBclient.arrReg, out reg);
            reg.fpga_index = biaschan.myFPGA_ID;
            Mu2e_Register.ReadReg(ref reg, ref myFEBclient.client);
            double vreg = (double)reg.val / 50;
            if (vreg != vsig)
            {
                biaschan.voltageSetting = vreg;
                biaschan.Biases[0].myMeasurements.isUpToDate = false;
                biaschan.Biases[1].myMeasurements.isUpToDate = false;
            }
        }

        void SetVoltage(TrimSignal trimsig, double vset)
        {
            int regvalnew = (int)(vset * 500 + 2048);
            //Impose ceiling/floor on setting values.
            regvalnew = (regvalnew > 0) ? regvalnew : 0;
            regvalnew = (regvalnew < 4096) ? regvalnew : 4095;
            Mu2e_Register reg = new Mu2e_Register();
            Mu2e_Register.FindAddr((ushort)(48 + trimsig.signalIndex), ref myFEBclient.arrReg, out reg);
            reg.fpga_index = trimsig.myFPGA_ID;
            Mu2e_Register.ReadReg(ref reg, ref myFEBclient.client);
            int regvalold = (int)reg.val;

            if (regvalnew != regvalold)
            {
                Mu2e_Register.WriteReg((uint)regvalnew, ref reg, ref myFEBclient.client);
                //Invalidate for 1ms per 20mV (rounded up) to allow for ramping.
                int invalTime = (int)(Math.Abs(regvalold - regvalnew) / 10 + 1);
                invalTime = invalTime < 4096 ? invalTime : 4095;
                trimsig.myMeasurements.Invalidate(invalTime);
                trimsig.voltageSetting = vset;
                trimsig.myMeasurements.isUpToDate = false;
            }
        }

        void SetVoltage(LEDsignal ledsig, double vset)
        {
            int regvalnew = (int)(vset * 4700 / 17);
            //Impose ceiling/floor on setting values.
            regvalnew = (regvalnew > 0) ? regvalnew : 0;
            regvalnew = (regvalnew < 4096) ? regvalnew : 4095;
            Mu2e_Register reg = new Mu2e_Register();
            Mu2e_Register.FindAddr((ushort)(64 + ledsig.signalIndex), ref myFEBclient.arrReg, out reg);
            reg.fpga_index = ledsig.myFPGA_ID;
            Mu2e_Register.ReadReg(ref reg, ref myFEBclient.client);
            int regvalold = (int)ledsig.register.val;

            if (regvalnew != regvalold)
            {
                Mu2e_Register.WriteReg((uint)regvalnew, ref reg, ref myFEBclient.client);
                //Invalidate for 1ms per 20mV (rounded up) to allow for ramping.
                int invalTime = (int)(Math.Abs(regvalold - regvalnew) * 17 / 94 + 1);
                invalTime = invalTime < 4096 ? invalTime : 4095;
                ledsig.myMeasurements.Invalidate(invalTime);
                ledsig.voltageSetting = vset;
                ledsig.myMeasurements.isUpToDate = false;
            }
        }

        void SetVoltage(BiasSignal biassig, double vset)
        {
            int regvalnew = (int)(vset * 50);
            //Impose ceiling/floor on setting values.
            regvalnew = (regvalnew > 0) ? regvalnew : 0;
            regvalnew = (regvalnew < 4096) ? regvalnew : 4095;
            Mu2e_Register reg = new Mu2e_Register();
            Mu2e_Register.FindAddr((ushort)(68 + biassig.signalIndex), ref myFEBclient.arrReg, out reg);
            reg.fpga_index = biassig.myFPGA_ID;
            Mu2e_Register.ReadReg(ref reg, ref myFEBclient.client);
            int regvalold = (int)biassig.register.val;

            if (regvalnew != regvalold)
            {
                Mu2e_Register.WriteReg((uint)regvalnew, ref reg, ref myFEBclient.client);
                //Invalidate for 1ms per 20mV (rounded up) to allow for ramping.
                int invalTime = (int)(Math.Abs(regvalold - regvalnew) + 1);
                invalTime = invalTime < 4096 ? invalTime : 4095;
                biassig.myMeasurements.Invalidate(invalTime);
                biassig.voltageSetting = vset;
                biassig.myMeasurements.isUpToDate = false;
            }
        }

        void SetVoltage(BiasChannel biaschan, double vset)
        {
            BiasSignal bias0 = biaschan.Biases[0];
            BiasSignal bias1 = biaschan.Biases[1];

            SetVoltage(bias0, vset);
            SetVoltage(bias1, vset);
            //uint regvalnew = (uint)(vset * 50);
            ////Impose ceiling/floor on setting values.
            //regvalnew = (regvalnew > 0) ? regvalnew : 0;
            //regvalnew = (regvalnew < 4096) ? regvalnew : 4095;

            //Mu2e_Register reg = biaschan.register;
            //Mu2e_Register.ReadReg(ref reg, myFEBclient.client);
            //uint regvalold = biaschan.register.val;

            //if (regvalnew != regvalold)
            //{
            //    Mu2e_Register.WriteReg(regvalnew, ref reg, myFEBclient.client);
            //    //Invalidate for 1ms per 20mV (rounded up) to allow for ramping.
            //    int invalTime = (int)(Math.Abs(regvalold - regvalnew) + 1);
            //    biaschan.Biases[0].myMeasurements.Invalidate(invalTime);
            //    biaschan.Biases[1].myMeasurements.Invalidate(invalTime);
            //    biaschan.voltageSetting = vset;
            //    biaschan.Biases[0].myMeasurements.isUpToDate = false;
            //    biaschan.Biases[1].myMeasurements.isUpToDate = false;
            //}
        }

        void GetVoltageMeasurement(TrimSignal trimsig, int numMeas, int timeCount = 410)
        {   //timeCount should be the voltage difference * 50. Initialized at max possible voltage diff.
            int checkCount = 0;
            while (!trimsig.myMeasurements.isValid)
            {   //Wait until either it becomes valid, or max time is reached.
                if (checkCount < timeCount)
                {
                    checkCount++;
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
                else
                {
                    trimsig.myMeasurements.isValid = true;
                    //break;
                }
            }
            trimsig.myMeasurements.clear();
            trimsig.myMeasurements.GetMeasurement(numMeas);
            trimsig.myMeasurements.isUpToDate = true;
            if (Math.Abs(trimsig.myMeasurements.averageValue - trimsig.voltageSetting) > 2)
            {
                trimsig.isBad = true;
            }
            updateListVoltage(trimsig);
        }

        void GetVoltageMeasurement(LEDsignal ledsig, int numMeas, int timeCount = 741)
        {   //timeCount should be the voltage difference * 50. Initialized at max possible voltage diff.
            int checkCount = 0;
            while (!ledsig.myMeasurements.isValid)
            {   //Wait until either it becomes valid, or max time is reached.
                if (checkCount < timeCount)
                {
                    checkCount++;
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
                else
                {
                    ledsig.myMeasurements.isValid = true;
                    //break;
                }
            }
            ledsig.myMeasurements.clear();
            ledsig.myMeasurements.GetMeasurement(numMeas);
            ledsig.myMeasurements.isUpToDate = true;
            updateListVoltage(ledsig);
            if (Math.Abs(ledsig.myMeasurements.averageValue - ledsig.voltageSetting) > 5)
            {
                ledsig.isBad = true;
            }
        }

        void GetVoltageMeasurement(BiasSignal biassig, int numMeas, int timeCount = 3900)
        {   //timeCount should be the voltage difference * 50. Initialized at max possible voltage diff.
            int checkCount = 0;
            while (!biassig.myMeasurements.isValid)
            {   //Wait until either it becomes valid, or max time is reached.
                if (checkCount < timeCount)
                {
                    checkCount++;
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
                else
                {
                    biassig.myMeasurements.isValid = true;
                    //break;
                }
            }
            biassig.myMeasurements.clear();
            biassig.myMeasurements.GetMeasurement(numMeas);
            biassig.myMeasurements.isUpToDate = true;
            updateListVoltage(biassig);
            if (Math.Abs(biassig.myMeasurements.averageValue - biassig.voltageSetting) > 10)
            {
                biassig.isBad = true;
            }
        }

        void GetVoltageMeasurement(BiasChannel biaschan, int numMeas, int timeCount = 3900)
        {
            BiasSignal bias0 = biaschan.Biases[0];
            BiasSignal bias1 = biaschan.Biases[1];
            GetVoltageMeasurement(bias0, numMeas, timeCount);
            GetVoltageMeasurement(bias1, numMeas, 0);
            //timeCount should be the voltage difference * 50. Initialized at max possible voltage diff.
            //int checkCount = 0;
            //while (!biaschan.Biases[0].myMeasurements.isValid || !biaschan.Biases[1].myMeasurements.isValid)
            //{   //Wait until either it becomes valid, or max time is reached.
            //    if (checkCount < timeCount)
            //    {
            //        checkCount++;
            //        System.Threading.Thread.Sleep(1);
            //        Application.DoEvents();
            //    }
            //    else
            //    {
            //        biaschan.Biases[0].myMeasurements.isValid = true;
            //        biaschan.Biases[1].myMeasurements.isValid = true;
            //        //break;
            //    }
            //}
            //biaschan.Biases[0].myMeasurements.measurements.Clear();
            //biaschan.Biases[1].myMeasurements.measurements.Clear();
            //biaschan.GetMeasurement(numMeas);
            //biaschan.Biases[0].myMeasurements.isUpToDate = true;
            //biaschan.Biases[1].myMeasurements.isUpToDate = true;
            //updateListVoltage(biaschan.Biases[0]);
            //updateListVoltage(biaschan.Biases[1]);
        }

        bool VoltagesInitialized = false;
        private void ZeroAllVoltages()
        {
            if (VoltagesInitialized)
            {
                foreach (BiasChannel biaschan in myFEB.Biases)
                {
                    biaschan.Biases[0].myMeasurements.Invalidate((int)Math.Ceiling(biaschan.voltageSetting / 20));
                    biaschan.Biases[1].myMeasurements.Invalidate((int)Math.Ceiling(biaschan.voltageSetting / 20));
                }
                foreach (TrimSignal trimsig in myFEB.Trims)
                {
                    trimsig.myMeasurements.Invalidate((int)Math.Ceiling(Math.Abs(trimsig.voltageSetting) / 20));
                }
                foreach (LEDsignal ledsig in myFEB.LEDs)
                {
                    ledsig.myMeasurements.Invalidate((int)Math.Ceiling(ledsig.voltageSetting / 20));
                }
            }
            for (int fpga = 0; fpga < 4; fpga++)
            {
                PP.FEB1.SetV(0, fpga);
                for (int i = 0; i < 16; i++)
                {
                    myFEBclient.SendStr("wr " + Convert.ToString(4 * fpga, 16) + "3" + Convert.ToString(i, 16) + " 800");
                }
            }
        }

        private void AcquireAllVoltages()
        { 
            foreach (BiasChannel biaschan in myFEB.Biases)
            {
                GetVoltageMeasurement(biaschan, 1);
                Application.DoEvents();
            }

            foreach (TrimSignal trimsig in myFEB.Trims)
            {
                GetVoltageMeasurement(trimsig, 1);
                Application.DoEvents();
            }

            foreach (LEDsignal ledsig in myFEB.LEDs)
            {
                GetVoltageMeasurement(ledsig, 1);
                Application.DoEvents();
            }
        }

        private void btnFullVScan_Click(object sender, EventArgs e)
        {
            if (!VoltagesInitialized)
            {
                DialogResult result = MessageBox.Show("Voltages not initialized. Initialize now and continue scan?", "", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    buildListView();
                }
                else { return; }
            }
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int numSamples = (int)UpDnSamples.Value;
            btnFullVScan.Text = "SCANNING...";
            Application.DoEvents();

            ZeroAllVoltages();

            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllBias, 65);
            //myFEB.GetVoltages(FEB.GetVoltageTypes.AllBias);
            foreach (BiasChannel biassig in myFEB.Biases)
            {
                //biassig.GetMeasurement(numSamples);
                //biassig.calibration.Vhi = biassig.SaveMeasurements();
                SetVoltage(biassig, 65);
                GetVoltageMeasurement(biassig, numSamples, 3250);
                biassig.calibration.Vhi = biassig.SaveMeasurements(); // added by GAHS 2019-04-24
                for (int i = 0; i < 2; i++)
                {
                    updateListVoltage(biassig.Biases[i]);
                }
            }

            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllBias, 35);
            //myFEB.GetVoltages(FEB.GetVoltageTypes.AllBias);
            foreach (BiasChannel biassig in myFEB.Biases)
            {
                //biassig.GetMeasurement(numSamples);
                SetVoltage(biassig, 35);
                GetVoltageMeasurement(biassig, numSamples, 1500);
                biassig.calibration.Vmed = biassig.SaveMeasurements();
                for (int i = 0; i < 2; i++)
                {
                    updateListVoltage(biassig.Biases[i]);
                }
            }
            foreach (TrimSignal trimsig in myFEB.Trims)
            {
                trimsig.muxCalibCurrent = PP.FEB1.ReadA0((int)trimsig.myFPGA_ID, (int)trimsig.signalIndex);
                trimsig.muxCalibrate();
                if (trimsig.muxCalibCurrent > 60)
                {
                    trimsig.muxIsBad = true;
                }
            }

            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllBias, 5);
            //myFEB.GetVoltages(FEB.GetVoltageTypes.AllBias);
            foreach (BiasChannel biassig in myFEB.Biases)
            {
                //biassig.GetMeasurement(numSamples);
                SetVoltage(biassig, 5);
                GetVoltageMeasurement(biassig, numSamples, 1500);
                biassig.calibration.Vlow = biassig.SaveMeasurements();

                biassig.calibration.DoCalibrationFit();
                biassig.SaveBiasCalibrations();
                for (int i = 0; i < 2; i++)
                {
                    updateListVoltage(biassig.Biases[i]);
                }
            }

            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllBias, 0);
            foreach (BiasChannel biassig in myFEB.Biases)
            {
                //biassig.GetMeasurement(numSamples);
                //biassig.calibration.Vhi = biassig.SaveMeasurements();
                SetVoltage(biassig, 0);
                GetVoltageMeasurement(biassig, 1, 250);
                for (int i = 0; i < 2; i++)
                {
                    updateListVoltage(biassig.Biases[i]);
                }
            }

            //ZeroAllVoltages();

            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllTrim, 4);
            //myFEB.GetVoltages(FEB.GetVoltageTypes.AllTrim);
            foreach (TrimSignal trimsig in myFEB.Trims)
            {
                //trimsig.myMeasurements.GetMeasurement(numSamples);
                SetVoltage(trimsig, 4);
                GetVoltageMeasurement(trimsig, numSamples, 200);
                // trimsig.calibration.Vlow = trimsig.SaveMeasurements();
                trimsig.calibration.Vhi = trimsig.SaveMeasurements();  // changed Vlow to Vhi here GAHS 2019-04-20
                updateListVoltage(trimsig);
            }

            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllTrim, -4);
            //myFEB.GetVoltages(FEB.GetVoltageTypes.AllTrim);
            foreach (TrimSignal trimsig in myFEB.Trims)
            {
                //trimsig.myMeasurements.GetMeasurement(numSamples);
                SetVoltage(trimsig, -4);
                GetVoltageMeasurement(trimsig, numSamples, 400);
                trimsig.calibration.Vlow = trimsig.SaveMeasurements();
                updateListVoltage(trimsig);
                trimsig.calibration.DoCalibrationFit();
            }

            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllTrim, 0);
            //myFEB.GetVoltages(FEB.GetVoltageTypes.AllTrim);
            foreach (TrimSignal trimsig in myFEB.Trims)
            {
                //trimsig.myMeasurements.GetMeasurement(numSamples);
                SetVoltage(trimsig, 0);
                GetVoltageMeasurement(trimsig, numSamples, 200);
                trimsig.calibration.Vmed = trimsig.SaveMeasurements();
                updateListVoltage(trimsig);
            }

            //Check that all channels look good.
            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllLED, 2);
            //myFEB.GetVoltages(FEB.GetVoltageTypes.AllLED);
            foreach (LEDsignal ledsig in myFEB.LEDs)
            {
                //vLED.myMeasurements.GetMeasurement(1);
                SetVoltage(ledsig, 12);
                GetVoltageMeasurement(ledsig, 1, 600);
                if (Math.Abs(ledsig.voltageSetting - ledsig.myMeasurements.averageValue) > 1)
                {
                    ledsig.isBad = true;
                }
                updateListVoltage(ledsig);
            }

            foreach (LEDsignal ledsig in myFEB.LEDs)
            {
                //vLED.myMeasurements.GetMeasurement(1);
                SetVoltage(ledsig, 0);
                GetVoltageMeasurement(ledsig, 1, 600);
                updateListVoltage(ledsig);
            }

            //myFEB.SetVoltages(FEB.GetVoltageTypes.AllLED, 0);
            ZeroAllVoltages();

            btnFullVScan.Text = "SCAN";
            btnFullVScan.BackColor = Color.LimeGreen;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:000}",
                (int)(ts.TotalMinutes), ts.Seconds, ts.Milliseconds);
            lblScanTime.Text = "Scan time: " + elapsedTime;

            DateTime testDate = DateTime.Now;
            string measurementsFileName = "";
            measurementsFileName += "HVtestVals_";
            measurementsFileName += txtSN.Text;
            measurementsFileName += "_";
            measurementsFileName += testDate.ToString("yyyyMMdd");
            //measurementsFileName = dirName + measurementsFileName + ".txt";
            saveFileMeasurements.FileName = measurementsFileName;

            if (saveFileMeasurements.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter measurementsStream = new StreamWriter(saveFileMeasurements.FileName))
                {
                    foreach (BiasChannel bias in myFEB.Biases)
                    {
                        measurementsStream.WriteLine(bias.name);
                        measurementsStream.WriteLine("HV = 65V");
                        foreach (double meas in bias.calibration.Vhi.measurementList)
                        {
                            measurementsStream.WriteLine(meas.ToString());
                        }
                        measurementsStream.WriteLine("HV = 35V");
                        foreach (double meas in bias.calibration.Vmed.measurementList)
                        {
                            measurementsStream.WriteLine(meas.ToString());
                        }
                        measurementsStream.WriteLine("HV = 5V");
                        foreach (double meas in bias.calibration.Vlow.measurementList)
                        {
                            measurementsStream.WriteLine(meas.ToString());
                        }
                        measurementsStream.WriteLine(
                            "Gain: " + bias.calibration.gain.ToString() + 
                            ", Offset: " + bias.calibration.offset.ToString());
                    }
                    foreach (TrimSignal trim in myFEB.Trims)
                    {
                        measurementsStream.WriteLine(trim.name);
                        measurementsStream.WriteLine("HV = 4V");
                        foreach (double meas in trim.calibration.Vhi.measurementList)
                        {
                            measurementsStream.WriteLine(meas.ToString());
                        }
                        measurementsStream.WriteLine("HV = 0V");
                        foreach (double meas in trim.calibration.Vmed.measurementList)
                        {
                            measurementsStream.WriteLine(meas.ToString());
                        }
                        measurementsStream.WriteLine("HV = -4V");
                        foreach (double meas in trim.calibration.Vlow.measurementList)
                        {
                            measurementsStream.WriteLine(meas.ToString());
                        }
                        measurementsStream.WriteLine(
                            "Gain: " + trim.calibration.gain.ToString() +
                            ", Offset: " + trim.calibration.offset.ToString());
                    }
                    measurementsStream.WriteLine("");
                    measurementsStream.Close();
                }
            }

            AcquireAllVoltages();
            foreach (VoltageSignal vsig in myFEB.LEDs)
            {
                updateListVoltage(vsig);
            }
        }

        private void btnMuxTest_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            btnMuxTest.Text = "SCANNING...";
            void UpdateMyScanTime()  // GAHS 2019-04-24
            {
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}.{2:000}",
                    (int)(ts.TotalMinutes), ts.Seconds, ts.Milliseconds);
                lblMuxTime.Text = "Scan time: " + elapsedTime;
            }
            UpdateMyScanTime(); // GAHS 2019-04-24
            Application.DoEvents();

            ZeroAllVoltages();

            //Must be a power of 2.
            //int gain = 8;
            int stime = 20;

            bool startingMode = TekScope.inTestMode;
            TekScope.inTestMode = true;

            myFEBclient.MuxTestSetup();

            foreach (TrimSignal trimsig in myFEB.Trims)
            { SetVoltage(trimsig, -2); }
            //Wait 100ms to make sure voltages have ramped.
            System.Threading.Thread.Sleep(100);  // moved to be between loops instead of in next loop by GAHS 2019-04-24
            foreach (TrimSignal trimsig in myFEB.Trims)
            {
                int fpga = trimsig.myFPGA_ID;
                int ch = trimsig.signalIndex;
                btnMuxTest.Text = $"scan {fpga}.{ch}";
                UpdateMyScanTime();  // GAHS 2019-04-24
                Application.DoEvents();  // Added by GAHS 2019-04-24
                trimsig.muxCurrent = myFEBclient.ReadMuxI(fpga, ch);
                trimsig.muxIsTested = true;

                myFEBclient.SendStr("WR 20 0");
                System.Threading.Thread.Sleep(stime);
            }

            ZeroAllVoltages();
            myFEBclient.MuxTestSetup();

            TekScope.inTestMode = startingMode;
            btnMuxTest.BackColor = Color.LimeGreen;
            btnMuxTest.Text = "MUX TEST";
            stopWatch.Stop();
            UpdateMyScanTime(); // GAHS 2019-04-24
        }

        private void buildListView()
        {
            string[] listString = new string[8];
            foreach (TrimSignal trimsig in myFEB.Trims)
            {
                GetVoltageSetting(trimsig);
                GetVoltageMeasurement(trimsig, 1);

                Array.Clear(listString, 0, 8);

                listString[0] = trimsig.name;
                listString[1] = trimsig.myHDMI_ID.ToString();
                listString[2] = trimsig.voltageSetting.ToString("F3");
                listString[3] = trimsig.myMeasurements.averageValue.ToString("F4");
                listString[4] = trimsig.calibration.isCalibrated.ToString();
                listString[5] = trimsig.calibration.gain.ToString();
                listString[6] = trimsig.calibration.offset.ToString();
                listString[7] = trimsig.muxCalibCurrent.ToString();

                ListViewItem listRow = new ListViewItem(listString);
                listRow.Group = listView1.Groups[trimsig.myFPGA_ID];
                listView1.Items.Add(listRow);
                if (trimsig.isBad)
                { listRow.SubItems[3].BackColor = Color.Red; }
            }

            foreach (BiasChannel biassig in myFEB.Biases)
            {
                GetVoltageSetting(biassig);
                GetVoltageMeasurement(biassig, 1);
                for (int i = 0; i < 2; i++)
                {
                    Array.Clear(listString, 0, 8);

                    listString[0] = biassig.Biases[i].name;
                    listString[1] = biassig.Biases[i].myHDMI_ID.ToString();
                    listString[2] = biassig.voltageSetting.ToString("F3");
                    listString[3] = biassig.Biases[i].myMeasurements.averageValue.ToString("F4");
                    listString[4] = biassig.calibration.isCalibrated.ToString();
                    listString[5] = biassig.calibration.gain.ToString();
                    listString[6] = biassig.calibration.offset.ToString();
                    listString[7] = "";

                    ListViewItem listRow = new ListViewItem(listString);
                    listRow.Group = listView1.Groups[biassig.Biases[i].myFPGA_ID];
                    listView1.Items.Add(listRow);
                    if (biassig.Biases[i].isBad)
                    { listRow.SubItems[3].BackColor = Color.Red; }
                }
            }

            foreach (LEDsignal ledsig in myFEB.LEDs)
            {
                GetVoltageSetting(ledsig);
                GetVoltageMeasurement(ledsig, 1);

                Array.Clear(listString, 0, 8);

                listString[0] = ledsig.name;
                listString[1] = ledsig.myHDMI_ID.ToString();
                listString[2] = ledsig.voltageSetting.ToString("F3");
                listString[3] = ledsig.myMeasurements.averageValue.ToString("F4");
                listString[4] = ledsig.calibration.isCalibrated.ToString();
                listString[5] = ledsig.calibration.gain.ToString();
                listString[6] = ledsig.calibration.offset.ToString();
                listString[7] = "";

                ListViewItem listRow = new ListViewItem(listString);
                listRow.Group = listView1.Groups[ledsig.myFPGA_ID];
                listView1.Items.Add(listRow);
                if (ledsig.isBad)
                { listRow.SubItems[3].BackColor = Color.Red; }
            }

            listView1.Sort();
            VoltagesInitialized = true;
        }

        VoltageSignal activeVoltageSignal = new VoltageSignal();
        BiasSignal otherBias = new BiasSignal();

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            for (int i = 0; i < 96; i++)
            {
                if (myFEB.Voltages[i].name == e.Item.Text)
                {
                    activeVoltageSignal = myFEB.Voltages[i];
                    txtVSet.Text = myFEB.Voltages[i].voltageSetting.ToString();
                    lblSelectedChan.Text = activeVoltageSignal.name;
                }
                if (myFEB.Voltages[i].name.Contains("Bias[0]") && i < 90)
                {
                    otherBias = (BiasSignal)myFEB.Voltages[i + 6];
                }
                else if (myFEB.Voltages[i].name.Contains("Bias[1]") && i > 5)
                {
                    otherBias = (BiasSignal)myFEB.Voltages[i - 6];
                }
                else { }
            }
        }

        private void updateListVoltage(VoltageSignal vsig)
        {
            foreach (ListViewItem LVitem in listView1.Items)
            {
                if ((vsig is BiasSignal &&
                        LVitem.Text.Substring(6) == vsig.name.Substring(6)) ||
                        LVitem.Text == vsig.name
                    ) //Gets either "Bias[0]..." or "Bias[1]..." if it's a bias
                {
                    LVitem.SubItems[2].Text = vsig.voltageSetting.ToString("F3");
                    LVitem.SubItems[3].Text = vsig.myMeasurements.averageValue.ToString("F4");
                    LVitem.SubItems[4].Text = vsig.calibration.isCalibrated.ToString();
                    LVitem.SubItems[5].Text = vsig.calibration.gain.ToString();
                    LVitem.SubItems[6].Text = vsig.calibration.offset.ToString();
                    if (vsig is TrimSignal)
                    {
                        TrimSignal trimsig = (TrimSignal)vsig;
                        LVitem.SubItems[7].Text = trimsig.muxCalibCurrent.ToString();
                        if (trimsig.muxIsBad)
                        {
                            LVitem.SubItems[7].BackColor = Color.Red;
                        }
                    }
                    if (vsig.isBad)
                    { LVitem.SubItems[3].BackColor = Color.Red; }
                    Application.DoEvents();
                }
            }
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            if (activeVoltageSignal != null)
            {
                double vset = Convert.ToDouble(txtVSet.Text);
                if (activeVoltageSignal is TrimSignal)
                {
                    SetVoltage((TrimSignal)activeVoltageSignal, vset);
                    GetVoltageMeasurement((TrimSignal)activeVoltageSignal, 1);
                }
                else if (activeVoltageSignal is BiasSignal)
                {
                    SetVoltage((BiasSignal)activeVoltageSignal, vset);
                    GetVoltageMeasurement((BiasSignal)activeVoltageSignal, 1);
                    if (otherBias != null)
                    {
                        SetVoltage(otherBias, vset);
                        GetVoltageMeasurement(otherBias, 1);
                    }
                }
                else if (activeVoltageSignal is LEDsignal)
                {
                    SetVoltage((LEDsignal)activeVoltageSignal, vset);
                    GetVoltageMeasurement((LEDsignal)activeVoltageSignal, 1);
                }
                else { }

                updateListVoltage(activeVoltageSignal);
            }
            else { }
        }

        private void btnZeroVoltages_Click(object sender, EventArgs e)
        {
            ZeroAllVoltages();
        }

        private void btnSaveVScan_Click(object sender, EventArgs e)
        {
            if (myFEB.Trims.Exists(x => !x.calibration.isTested || x.isBad || x.muxIsBad) ||
                myFEB.Biases.Exists(x => !x.calibration.isTested || x.Biases[0].isBad || x.Biases[1].isBad) ||
                myFEB.LEDs.Exists(x => !x.calibration.isTested || x.isBad))
            {
                DialogResult result = MessageBox.Show(
                    "One or more channels is marked as untested or bad. Save anyway?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }
            }
            //foreach (TrimSignal trim in myFEB.Trims)
            //{
            //    if (!trim.calibration.isTested)
            //    {
            //        DialogResult result = MessageBox.Show(trim.name + " appears to be untested. Save anyway?", "", MessageBoxButtons.YesNo);
            //        if (result == DialogResult.No) { return; }
            //    }
            //    if (trim.isBad || trim.muxIsBad)
            //    {
            //        DialogResult result = MessageBox.Show(trim.name + " appears to be bad. Save anyway?", "", MessageBoxButtons.YesNo);
            //        if (result == DialogResult.No) { return; }
            //    }
            //}
            //foreach (BiasChannel bias in myFEB.Biases)
            //{
            //    if (!bias.calibration.isTested)
            //    {
            //        DialogResult result = MessageBox.Show(bias.name + " appears to be untested. Save anyway?", "", MessageBoxButtons.YesNo);
            //        if (result == DialogResult.No) { return; }
            //    }
            //    if (bias.Biases[0].isBad || bias.Biases[1].isBad)
            //    {
            //        DialogResult result = MessageBox.Show(bias.name + " appears to be bad. Save anyway?", "", MessageBoxButtons.YesNo);
            //        if (result == DialogResult.No) { return; }
            //    }
            //}

            DateTime testDate = DateTime.Now;

            string dsfFileName = "";
            dsfFileName += "FEBdsf_";
            dsfFileName += myFEBclient.FEBserialNum;
            dsfFileName += "_";
            dsfFileName += testDate.ToString("yyyyMMdd_HHmm");
            saveFileCalibrations.FileName = dsfFileName;

            //saveFileCalibrations.ShowDialog();
            if (saveFileCalibrations.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter dsfStream = new StreamWriter(saveFileCalibrations.FileName))
                {
                    foreach (BiasChannel biaschan in myFEB.Biases)
                    {
                        string biasAddr = "";
                        if (biaschan.calibration.isTested)
                        {
                            biasAddr += (biaschan.myFPGA_ID * 4).ToString("X");
                            switch (biaschan.signalIndex)
                            {
                                case 0:
                                    biasAddr += "44";
                                    break;
                                case 1:
                                    biasAddr += "45";
                                    break;
                                default:
                                    break;
                            }
                            dsfStream.WriteLine
                                ("dsf "
                                + biasAddr
                                + " "
                                + biaschan.calibration.gainInt.ToString("X")
                                + ", "
                                + biaschan.calibration.offsetInt.ToString("X"));
                        }
                    }
                    foreach (TrimSignal trimsig in myFEB.Trims)
                    {
                        string trimAddr = "";
                        if (trimsig.calibration.isTested)
                        {
                            trimAddr += (trimsig.myFPGA_ID * 4).ToString("X");
                            trimAddr += "3";
                            trimAddr += trimsig.signalIndex.ToString("X");
                            dsfStream.WriteLine
                                ("dsf "
                                + trimAddr
                                + " "
                                + trimsig.calibration.gainInt.ToString("X")
                                + ", "
                                + trimsig.calibration.offsetInt.ToString("X"));
                        }
                    }
                    dsfStream.WriteLine("");
                    dsfStream.Close();
                }
            }
        }

        private void btnBuildListView_Click(object sender, EventArgs e)
        {
            buildListView();
            btnFullVScan.Enabled = true;
        }

        private void btnSaveDB_Click(object sender, EventArgs e)
        {
            if (txtHVTestComments.Text.Length < 1)
            {
                DialogResult result = MessageBox.Show("Please enter a comment before saving", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK) { return; }
            }
            if (myFEB.Trims.Exists(x => !x.calibration.isTested) ||
                myFEB.Biases.Exists(x => !x.calibration.isTested) ||
                myFEB.LEDs.Exists(x => !x.calibration.isTested))
            {
                DialogResult result = MessageBox.Show(
                "One or more HV channels is marked as untested. Save anyway?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return;  }
            }

            DateTime testDate = DateTime.Now;

            string sn = myFEB.FEBserialNum.Replace("\r\n\r", "");
            string dbFileName = 
                "FEB_" + sn + "_" + 
                txtTestLocation.Text.Replace(" ", "") +
                txtTestType.Text.Replace(" ", "") + 
                "_" + testDate.ToString("yyyyMMdd_HHmm");
            saveFileDB.FileName = dbFileName;
            string FEBlocation = "KSU Test Stand";

            //saveFileDB.ShowDialog();
            if (saveFileDB.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter dbStream = new StreamWriter(saveFileDB.FileName))
                {
                    dbStream.WriteLine("# File=" + saveFileDB.FileName);
                    dbStream.WriteLine("# Feb ID, FEB Type, Test Date, FEB Location, Comments");
                    dbStream.Write("feb-" + sn);
                    dbStream.Write(", ");
                    dbStream.Write(txtFEBseries.Text);
                    dbStream.Write(", ");
                    dbStream.Write(testDate.ToShortDateString());
                    dbStream.Write(", ");
                    dbStream.Write(FEBlocation);
                    dbStream.Write(", ");
                    dbStream.Write("Test operator: " + txtUser.Text + ". ");
                    dbStream.Write(txtHVTestComments.Text);
                    dbStream.WriteLine();
                    dbStream.WriteLine("# fpga Channel number, FEB ID, Test Date, Bias 0 Gain, Bias 0 Offset, Bias 1 Gain, Bias 1 Offset, Comments");
                    for (int fpga = 0; fpga < 4; fpga++)
                    {
                        string FpgaErrorComments = "";
                        BiasChannel Bias0 = myFEB.Biases.Find(x => x.myAFE_ID == 2 * fpga);
                        BiasChannel Bias1 = myFEB.Biases.Find(x => x.myAFE_ID == 2 * fpga + 1);
                        //TODO: Make a function or loop to fill the error comments.
                        dbStream.Write("fpga-" + fpga.ToString());
                        dbStream.Write(", ");
                        dbStream.Write(sn);
                        dbStream.Write(", ");
                        dbStream.Write(testDate.ToShortDateString());
                        dbStream.Write(", ");
                        dbStream.Write(Bias0.calibration.gainInt.ToString("X"));
                        dbStream.Write(", ");
                        dbStream.Write(Bias0.calibration.offsetInt.ToString("X"));
                        dbStream.Write(", ");
                        dbStream.Write(Bias1.calibration.gainInt.ToString("X"));
                        dbStream.Write(", ");
                        dbStream.Write(Bias1.calibration.offsetInt.ToString("X"));
                        dbStream.Write(", ");
                        dbStream.Write(FpgaErrorComments);
                        dbStream.WriteLine();
                    }
                    dbStream.WriteLine("# channel number, fpga channel, FEB ID, Test Date, Gain, Offset, histogram, Comments");
                    for (int fpga = 0; fpga < 4; fpga++)
                    {
                        for (int index = 0; index < 16; index++)
                        {
                            int channel = 16 * fpga + index;
                            string TrimErrorComments = "";
                            //TODO: Make a function or loop to fill the error comments.
                            TrimSignal trimsig = myFEB.Trims.Find(x => (x.myFPGA_ID == fpga && x.signalIndex == index));
                            List<HISTO_curve> myHistoList = PP.FEB1Histo;
                            PointPairList histoPoints = new PointPairList();
                            dbStream.Write("channel-" + channel.ToString());
                            dbStream.Write(", ");
                            dbStream.Write(fpga.ToString());
                            dbStream.Write(", ");
                            dbStream.Write(sn);
                            dbStream.Write(", ");
                            dbStream.Write(testDate.ToShortDateString());
                            dbStream.Write(", ");
                            dbStream.Write(trimsig.calibration.gainInt.ToString("X"));
                            dbStream.Write(", ");
                            dbStream.Write(trimsig.calibration.offsetInt.ToString("X"));
                            dbStream.Write(", ");
                            //if (myHistoList.Any(x => x.chan == channel))
                            //{
                            //    HISTO_curve thisHisto = myHistoList.Find(x => x.chan == channel);
                            //    dbStream.Write("\"[");
                            //    dbStream.Write(string.Join("; ", thisHisto.list.ToString()));
                            //    dbStream.Write("]\"");
                            //}
                            //else { dbStream.Write(""); }
                            dbStream.Write(", ");
                            dbStream.Write(TrimErrorComments);
                            dbStream.WriteLine();
                        }
                    }

                    dbStream.Close();
                }
            }
        }

        private void btnHistoScan_Click(object sender, EventArgs e)
        {
            double vSet = Convert.ToDouble(textBox3.Text);
            for (int fpga = 0; fpga < 4; fpga++)
            { myFEBclient.SetV(vSet, fpga); }
            btnHistoScan.Text = "Scanning...";
            Application.UseWaitCursor = true;
            Application.DoEvents();

            histoScan(sender);

            for (int fpga = 0; fpga < 4; fpga++)
            { myFEBclient.SetV(0, fpga); }
            btnHistoScan.Text = "SCAN";
            Application.UseWaitCursor = false;
        }

        private void btnConnectFEB_Click(object sender, EventArgs e)
        {
            PP.FEB1.host_name_prop = txtFEBAddress.Text;
            Application.DoEvents();
            button1_Click((object)btnFEB1, e);
            Application.DoEvents();
            if (myFEBclient.ClientOpen)
            {
                //try
                //{
                //    bool blockState = myFEBclient.TNETSocket.Blocking;
                //    myFEBclient.TNETSocket.Blocking = false;
                //    myFEBclient.TNETSocket.Send(new byte[1], 0, 0);
                //    myFEBclient.TNETSocket.Blocking = blockState;
                //}
                //catch
                //{
                //    txtFEBAddress.BackColor = Color.Red;
                //    return;
                //}
                myFEBclient.SendStr("SN");
                string sn = "";
                int rt;
                myFEBclient.ReadStr(out sn, out rt);
                sn = sn.Replace("SerNumb=", "")
                    .Replace(">", "")
                    .Replace("\r", "")
                    .Replace("\n", "");
                myFEB.FEBserialNum = sn;
                txtSN.Text = sn;
                btnSnSave.Enabled = true;
                btnConnectFEB.BackColor = Color.LightGreen;
                btnConnectFEB.Text = PP.FEB1.host_name_prop;
                //btnConnectFEB.Enabled = false;
                //btnDisconnectFEB.Visible = true;
            }
            else { txtFEBAddress.BackColor = Color.Red; }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //Controls.Clear();
            //InitializeComponent();
            //if (myFEBclient.ClientOpen) { myFEBclient.Close(); }
            ZeroAllVoltages();
            Application.Restart();
        }

        private void btnDisconnectFEB_Click(object sender, EventArgs e)
        {
            ZeroAllVoltages();
            if (myFEBclient.ClientOpen) { myFEBclient.Close(); }
            btnDisconnectFEB.Visible = false;
            btnConnectFEB.Enabled = true;
            btnConnectFEB.BackColor = DefaultBackColor;
        }

        private void timerTempRB_Tick(object sender, EventArgs e)
        {
            updateTemp();
            Application.DoEvents();
        }

        private void tabHist_Enter(object sender, EventArgs e)
        {
            updateTemp();
            timerTempRB.Start();
        }

        private void tabHist_Leave(object sender, EventArgs e)
        {
            timerTempRB.Stop();
        }

        private void listBoxHistos_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDisplay(sender);
        }

        private void chkLogYHist_CheckStateChanged(object sender, EventArgs e)
        {
            UpdateDisplay(sender);
        }

        private void txtFEBAddress_Enter(object sender, EventArgs e)
        {
            if (txtFEBAddress.BackColor != Color.White) { txtFEBAddress.BackColor = Color.White; }
        }

        private void btnSaveHist_Click(object sender, EventArgs e)
        {
            List<HISTO_curve> myHistoList = null;
            myHistoList = PP.FEB1Histo;

            string hName = "";
            string dirName = "c://data//";
            //string preamble = "";
            //string header = "";
            DateTime testDate = DateTime.Now;

            hName += "FEB_histo_";
            hName += txtSN.Text;
            hName += "_" + testDate.ToString("yyyyMMdd_HHmm");
            hName = dirName + hName + ".csv";

            //preamble += "-- serial number: " + txtSN.Text + "\n" + "-- tested on: " + testDate.ToString();
            //header += "Channel, V, I";
            saveFileHist.FileName = hName;
            if (saveFileHist.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileHist.FileName))
                {
                    sw.WriteLine("-- serial number: " + myFEBclient.FEBserialNum + "\n" + "-- tested on: " + testDate.ToString());
                    string xVals = string.Join(", ", Enumerable.Range(0, 512));
                    sw.WriteLine("Channel, V, I, " + xVals);

                    foreach (HISTO_curve h1 in myHistoList)
                    {
                        string histVals = string.Join(", ", h1.list.Select(p => p.Y));
                        sw.WriteLine(h1.chan.ToString() + ", " + h1.V.ToString() + ", " + h1.I.ToString(), ", ", histVals);
                    }
                    sw.Close();
                }
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
    }

    public class ConnectAttemptEventArgs : EventArgs
    {
        public int ConnectAttempt { get; set; }
    }

}
