﻿using mu2e.FEB_Test_Jig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
//using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TB_mu2e
{

    public partial class frmMain : Form
    {

        private int _ActiveFEB = 0;
        private int reg_set = 0;
        private bool flgBreak = false;
        HdmiChannel ActiveHdmiChannel;
        private HdmiChannel HdmiChannel0;
        private HdmiChannel HdmiChannel1;
        private HdmiChannel HdmiChannel2;
        private HdmiChannel HdmiChannel3;
        private HdmiChannel HdmiChannel4;
        private HdmiChannel HdmiChannel5;
        private HdmiChannel HdmiChannel6;
        private HdmiChannel HdmiChannel7;
        private HdmiChannel HdmiChannel8;
        private HdmiChannel HdmiChannel9;
        private HdmiChannel HdmiChannel10;
        private HdmiChannel HdmiChannel11;
        private HdmiChannel HdmiChannel12;
        private HdmiChannel HdmiChannel13;
        private HdmiChannel HdmiChannel14;
        private HdmiChannel HdmiChannel15;
        private List<HdmiChannel> HdmiChannelList = new List<HdmiChannel>();


        ushort fpga_num = 0;
        Mu2e_Register rBias;
        Mu2e_Register rLed;
        Mu2e_Register rTrim0;
        Mu2e_Register rTrim1;
        Mu2e_Register rTrim2;
        Mu2e_Register rTrim3;

        private string msg1Conn = "";
        private string msg2Conn = "";
        private uConsole console_label;
        private List<Button> sel_list;

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
        private bool DebugLogging;

        public Mu2e_FEB_client myFEBclient = new Mu2e_FEB_client();
        FEB myFEB = new FEB();

        double vScopeBias;
        double vScopeLED;
        double vScopeTrim0;
        double vScopeTrim1;
        double vScopeTrim2;
        double vScopeTrim3;

        List<Button> chan_list = new List<Button>();
        private bool ScopeBiasVoltageUpdated = false;
        private bool ScopeTrimVoltageUpdated = false;

        List<string> ListSipm = new List<string>();
        //List<string> ListSipmIV = new List<string>();
        //List<string> ListSipmHisto = new List<string>();

        public void AddConsoleMessage(string mess)
        {
            console_label.add_messg(mess);
        }

        public frmMain()
        {
            InitializeComponent();

            myFEBclient = PP.FEB1;
            myFEB.FEBclient = myFEBclient;
            //myFEB.BuildHDMIsignalDB();

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

            chan_list.Add(btnJ11);
            chan_list.Add(btnJ12);
            chan_list.Add(btnJ13);
            chan_list.Add(btnJ14);
            chan_list.Add(btnJ15);
            chan_list.Add(btnJ16);
            chan_list.Add(btnJ17);
            chan_list.Add(btnJ18);
            chan_list.Add(btnJ19);
            chan_list.Add(btnJ20);
            chan_list.Add(btnJ21);
            chan_list.Add(btnJ22);
            chan_list.Add(btnJ23);
            chan_list.Add(btnJ24);
            chan_list.Add(btnJ25);
            chan_list.Add(btnJ26);

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

        private void setHdmiChannel(HdmiChannel channel, uint chanNum)
        {
            switch (chanNum)
            {
                case 0:
                    fpga_num = 0;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH0", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH0", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH1", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH2", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH3", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ11;
                    break;
                case 1:
                    fpga_num = 0;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH1", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH4", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH5", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH6", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH7", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ12;
                    break;
                case 2:
                    fpga_num = 0;
                    Mu2e_Register.FindName("BIAS_BUS_DAC1", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH2", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH8", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH9", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH10", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH11", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ13;
                    break;
                case 3:
                    fpga_num = 0;
                    Mu2e_Register.FindName("BIAS_BUS_DAC1", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH3", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH12", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH13", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH14", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH15", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ14;
                    break;
                case 4:
                    fpga_num = 1;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH0", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH0", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH1", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH2", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH3", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ15;
                    break;
                case 5:
                    fpga_num = 1;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH1", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH4", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH5", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH6", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH7", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ16;
                    break;
                case 6:
                    fpga_num = 1;
                    Mu2e_Register.FindName("BIAS_BUS_DAC1", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH2", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH8", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH9", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH10", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH11", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ17;
                    break;
                case 7:
                    fpga_num = 1;
                    Mu2e_Register.FindName("BIAS_BUS_DAC1", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH3", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH12", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH13", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH14", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH15", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ18;
                    break;
                case 8:
                    fpga_num = 2;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH0", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH0", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH1", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH2", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH3", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ19;
                    break;
                case 9:
                    fpga_num = 2;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH1", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH4", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH5", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH6", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH7", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ20;
                    break;
                case 10:
                    fpga_num = 2;
                    Mu2e_Register.FindName("BIAS_BUS_DAC1", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH2", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH8", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH9", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH10", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH11", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ21;
                    break;
                case 11:
                    fpga_num = 2;
                    Mu2e_Register.FindName("BIAS_BUS_DAC1", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH3", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH12", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH13", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH14", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH15", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ22;
                    break;
                case 12:
                    fpga_num = 3;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH0", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH0", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH1", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH2", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH3", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ23;
                    break;
                case 13:
                    fpga_num = 3;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH1", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH4", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH5", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH6", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH7", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ24;
                    break;
                case 14:
                    fpga_num = 3;
                    Mu2e_Register.FindName("BIAS_BUS_DAC1", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH2", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH8", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH9", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH10", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH11", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ25;
                    break;
                case 15:
                    fpga_num = 3;
                    Mu2e_Register.FindName("BIAS_BUS_DAC1", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH3", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH12", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH13", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH14", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH15", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ26;
                    break;
                default:
                    fpga_num = 0;
                    Mu2e_Register.FindName("BIAS_BUS_DAC0", ref myFEBclient.arrReg, out rBias);
                    Mu2e_Register.FindName("LED_INTENSITY_DAC_CH0", ref myFEBclient.arrReg, out rLed);
                    Mu2e_Register.FindName("BIAS_DAC_CH0", ref myFEBclient.arrReg, out rTrim0);
                    Mu2e_Register.FindName("BIAS_DAC_CH1", ref myFEBclient.arrReg, out rTrim1);
                    Mu2e_Register.FindName("BIAS_DAC_CH2", ref myFEBclient.arrReg, out rTrim2);
                    Mu2e_Register.FindName("BIAS_DAC_CH3", ref myFEBclient.arrReg, out rTrim3);
                    channel.button = btnJ11;
                    break;
            }
            rBias.fpga_index = fpga_num;
            rLed.fpga_index = fpga_num;
            rTrim0.fpga_index = fpga_num;
            rTrim1.fpga_index = fpga_num;
            rTrim2.fpga_index = fpga_num;
            rTrim3.fpga_index = fpga_num;
            channel.Bias0.register = rBias;
            channel.Led0.register = rLed;
            channel.Trim0.register = rTrim0;
            channel.Trim1.register = rTrim1;
            channel.Trim2.register = rTrim2;
            channel.Trim3.register = rTrim3;
            ActiveHdmiChannel = channel;
        }

        private void setButtonColor()
        {
            if (ActiveHdmiChannel.isTested == false)
            { ActiveHdmiChannel.button.BackColor = Color.Red; }
            else { ActiveHdmiChannel.button.BackColor = Color.Green; }
            foreach (Button item in chan_list)
            {
                if (item != ActiveHdmiChannel.button)
                {
                    if (item.BackColor == Color.Green || item.BackColor == Color.LightGreen)
                    { item.BackColor = Color.LightGreen; }
                    else { item.BackColor = Color.Silver; }
                }
            }
        }

        private void doTest(DacProperties dac, double vHi, double vMed, double vLow)
        {
            UInt32 vSet;
            Mu2e_Register r = dac.register;
            TextBox ReadbackBox = txtBiasRB0;
            TextBox SlopeBox = null;
            TextBox InterceptBox = null;
            if (dac == ActiveHdmiChannel.Bias0)
            {
                ReadbackBox = txtBiasRB0;
                SlopeBox = txtBiasSlope;
                InterceptBox = txtBiasInt;
            }
            else if (dac == ActiveHdmiChannel.Led0)
            {
                ReadbackBox = txtLEDRB0;
                SlopeBox = null;
                InterceptBox = null;
            }
            else if (dac == ActiveHdmiChannel.Trim0)
            {
                ReadbackBox = txtTrimRB0;
                SlopeBox = txtTrim0Slope;
                InterceptBox = txtTrim0Int;
            }
            else if (dac == ActiveHdmiChannel.Trim1)
            {
                ReadbackBox = txtTrimRB1;
                SlopeBox = txtTrim1Slope;
                InterceptBox = txtTrim1Int;
            }
            else if (dac == ActiveHdmiChannel.Trim2)
            {
                ReadbackBox = txtTrimRB2;
                SlopeBox = txtTrim2Slope;
                InterceptBox = txtTrim2Int;
            }
            else if (dac == ActiveHdmiChannel.Trim3)
            {
                ReadbackBox = txtTrimRB3;
                SlopeBox = txtTrim3Slope;
                InterceptBox = txtTrim3Int;
            }
            else { }

            int n = 5; //number of samples per output voltage data point
            int tSample = 5; //number of 20ms steps between output samples
            double vSamp = 0;

            vSet = dac.convertVoltage(vHi);
            Mu2e_Register.WriteReg(vSet, ref r, ref myFEBclient.client);
            updateVoltage();
            dac.voltageDataFEB[0] = vHi;
            for (int t = 0; t < 3 * vHi; t++)
            {
                System.Threading.Thread.Sleep(20);
                Application.DoEvents();
            }

            if (ReadbackBox.Text != "")
            {
                vSamp = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int t = 0; t < tSample; t++)
                    {
                        System.Threading.Thread.Sleep(20);
                        Application.DoEvents();
                    }
                    dac.HVHiVals.Add(double.Parse(ReadbackBox.Text));
                    vSamp += double.Parse(ReadbackBox.Text);
                }
                dac.voltageDataScope[0] = vSamp / n;
            }


            vSet = dac.convertVoltage(vMed);
            Mu2e_Register.WriteReg(vSet, ref r, ref myFEBclient.client);
            updateVoltage();
            dac.voltageDataFEB[1] = vMed;

            for (int t = 0; t < 3 * (vHi - vMed + 10); t++)
            {
                System.Threading.Thread.Sleep(20);
                Application.DoEvents();
            }
            if (ReadbackBox.Text != "")
            {
                vSamp = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int t = 0; t < tSample; t++)
                    {
                        System.Threading.Thread.Sleep(20);
                        Application.DoEvents();
                    }
                    dac.HVMedVals.Add(double.Parse(ReadbackBox.Text));
                    vSamp += double.Parse(ReadbackBox.Text);
                }
                dac.voltageDataScope[1] = vSamp / n;
            }

            vSet = dac.convertVoltage(vLow);
            Mu2e_Register.WriteReg(vSet, ref r, ref myFEBclient.client);
            updateVoltage();
            dac.voltageDataFEB[2] = vLow;
            for (int t = 0; t < 3 * (vMed - vLow + 10); t++)
            {
                System.Threading.Thread.Sleep(20);
                Application.DoEvents();
            }
            if (ReadbackBox.Text != "")
            {
                vSamp = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int t = 0; t < tSample; t++)
                    {
                        System.Threading.Thread.Sleep(20);
                        Application.DoEvents();
                    }
                    dac.HVLowVals.Add(double.Parse(ReadbackBox.Text));
                    vSamp += double.Parse(ReadbackBox.Text);
                }
                dac.voltageDataScope[2] = vSamp / n;
            }

            dac.FitData();

            if (SlopeBox != null && InterceptBox != null)
            {
                SlopeBox.Text = dac.slopeDouble.ToString("G");
                InterceptBox.Text = dac.interceptDouble.ToString("G");
            }

            vSet = dac.convertVoltage(0);
            Mu2e_Register.WriteReg(vSet, ref r, ref myFEBclient.client);
            updateVoltage();
            Application.DoEvents();
        }

        private void doMuxTest(TrimProperties trim, double v)
        {
            double R = 0.01; //Test resistor in GigaOhm. May neet to be set per channel.
            UInt32 vSet;
            Mu2e_Register biasr = ActiveHdmiChannel.Bias0.register;
            Mu2e_Register trimr = trim.register;
            TextBox BiasBox = txtBiasRB0;
            TextBox ReadbackBox = txtTrimRB0;
            TextBox MuxIBox = txtMuxI0;
            if (trim == ActiveHdmiChannel.Trim0)
            {
                ReadbackBox = txtTrimRB0;
                MuxIBox = txtMuxI0;
            }
            else if (trim == ActiveHdmiChannel.Trim1)
            {
                ReadbackBox = txtTrimRB1;
                MuxIBox = txtMuxI1;
            }
            else if (trim == ActiveHdmiChannel.Trim2)
            {
                ReadbackBox = txtTrimRB2;
                MuxIBox = txtMuxI2;
            }
            else if (trim == ActiveHdmiChannel.Trim3)
            {
                ReadbackBox = txtTrimRB3;
                MuxIBox = txtMuxI3;
            }
            else { }

            int n = 5; //number of samples per output voltage data point
            int tSample = 5; //number of 20ms steps between output samples
            double vDelta = 0;
            double vSamp = 0;

            Mu2e_Register.WriteReg(0, ref biasr, ref myFEBclient.client);
            vSet = trim.convertVoltage(v);
            Mu2e_Register.WriteReg(vSet, ref trimr, ref myFEBclient.client);
            updateVoltage();
            for (int t = 0; t < 3 * v; t++)
            {
                System.Threading.Thread.Sleep(20);
                Application.DoEvents();
            }

            if (ReadbackBox.Text != "" && BiasBox.Text != "")
            {
                for (int i = 0; i < n; i++)
                {
                    for (int t = 0; t < tSample; t++)
                    {
                        System.Threading.Thread.Sleep(20);
                        Application.DoEvents();
                    }
                    vDelta = double.Parse(ReadbackBox.Text) - double.Parse(BiasBox.Text);
                    vSamp += vDelta;
                }
                trim.muxCurrent = vSamp / n / R;

                MuxIBox.Text = trim.muxCurrent.ToString("0.00");
                if (trim.muxCurrent > 60 || trim.muxCurrent < -60)
                {
                    MuxIBox.BackColor = Color.Red;
                }
                else
                {
                    MuxIBox.BackColor = Color.LimeGreen;
                }
            }

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
                    label9.Text = cmb_reg;
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

        private void tabFEB2_Click(object sender, EventArgs e)
        {

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
                //create new histo
                //HISTO_curve[] myHisto = new HISTO_curve[64];
                //for (int i = 0; i < 64; i++)
                //{
                //    myHisto[i] = new HISTO_curve();
                //    myHisto[i].list = new PointPairList();
                //    myHisto[i].loglist = new PointPairList();
                //    myHisto[i].created_time = DateTime.Now;
                //    //myHisto[i].min_thresh = (int)udStart.Value;
                //    myHisto[i].min_thresh = 0;
                //    //myHisto[i].max_thresh = (int)udStop.Value;
                //    myHisto[i].max_thresh = 512;
                //    myHisto[i].interval = (int)udInterval.Value;
                //    //myHisto[i].chan = (int)udChan.Value;
                //    myHisto[i].chan = i;
                //    myHisto[i].integral = _IntegralScan;
                //    myHisto[i].board = _ActiveFEB;
                //    myHisto[i].V = Convert.ToDouble(txtV.Text);
                //    myHisto[i].I = Convert.ToDouble(txtI.Text);
                //}
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
                    uint[] histo = new uint[512];
                    histo = myFEBclient.ReadHisto(sipm, afe, fpga);
                    for (uint j = 0; j < 512; j++)
                    {
                        if (flgBreak) { j = 512; }
                        uint count = 0;
                        count = histo[j];
                        if (count > myHisto.max_count) { myHisto.max_count = count; }
                        myHisto.AddPoint((int)j, (int)count);
                    }
                    PP.FEB1Histo.Add(myHisto);
                    uint SipmNum = i + 1;
                    ListSipm.Add(SipmNum.ToString());
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

        private void UpdateDisplay()
        {
            Color[] this_color = new Color[12];
            Histo_helper.InitColorList(ref this_color);

            if (listBox1.SelectedItem != null)
            {
                string SipmSel = listBox1.SelectedItem.ToString();

                int SipmNum = Int32.Parse(SipmSel) - 1;

                List<HISTO_curve> myHistoList = null;
                zedFEB1.GraphPane.CurveList.Clear();

                myHistoList = PP.FEB1Histo;
                //if (_ActiveFEB == 2) { myHistoList = PP.FEB2Histo; }

                foreach (HISTO_curve h1 in myHistoList)
                {
                    if (h1.chan == SipmNum)
                    {
                        if (chkLogY.Checked)
                        {
                            zedFEB1.GraphPane.YAxis.Scale.Max = Math.Round((double)(Math.Log10(h1.max_count + 0.1 * (h1.max_count - h1.min_count))), 0);
                            zedFEB1.GraphPane.AddCurve(h1.chan.ToString(), h1.loglist, Color.DarkRed, SymbolType.None);
                        }
                        else
                        {
                            zedFEB1.GraphPane.YAxis.Scale.Max = Math.Round((double)(h1.max_count + 0.1 * (h1.max_count - h1.min_count)), 0);
                            //zedFEB1.GraphPane.AddCurve(h1.chan.ToString(), h1.list, this_color[h1.chan % 16], SymbolType.None);
                            zedFEB1.GraphPane.AddCurve(h1.chan.ToString(), h1.list, Color.DarkBlue, SymbolType.None);
                        }
                        double s = 0;
                        s = Math.Round((double)(h1.max_thresh - h1.min_thresh) / 10.0, 0);
                        if (zedFEB1.GraphPane.XAxis.Scale.MajorStep < s) { zedFEB1.GraphPane.XAxis.Scale.MajorStep = s; }
                        zedFEB1.GraphPane.XAxis.Scale.MinorStep = zedFEB1.GraphPane.XAxis.Scale.MajorStep / 4;

                        s = Math.Round((h1.max_count - h1.min_count) / 10.0, 0);
                        if (zedFEB1.GraphPane.YAxis.Scale.MajorStep < s) { zedFEB1.GraphPane.YAxis.Scale.MajorStep = s; }
                        zedFEB1.GraphPane.YAxis.Scale.MinorStep = zedFEB1.GraphPane.YAxis.Scale.MajorStep / 4;
                    }
                }
            }
            zedFEB1.Invalidate(true);
            Application.DoEvents();
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
            { UpdateDisplay(); }
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
            UpdateDisplay();
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
                hName += "_" + testDate.ToString("yyyyMMdd");
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

        private void zg1_Load(object sender, EventArgs e)
        {

        }

        private void udStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void udInterval_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblInc_Click(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {

        }

        private void udFPGA_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxREG1_Enter(object sender, EventArgs e)
        {

        }

        private void txtV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBiasSet1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDacUpdate_Click(object sender, EventArgs e)
        {
            //updateVoltage();
            //Application.DoEvents();
            //for (int i = 1; i < 3; i++)
            //{
            //    ScopeBias.GetVoltage(i);
            //    int t = 0;
            //    while (!ScopeBiasVoltageUpdated && t++ < 99999) {
            //        Application.DoEvents();
            //    }
            //    ScopeBiasVoltageUpdated = false;
            //}
            //for (int i = 1; i < 5; i++)
            //{
            //    ScopeTrim.GetVoltage(i);
            //    int t = 0;
            //    while (!ScopeTrimVoltageUpdated && t++ < 99999) {
            //        Application.DoEvents();
            //    }
            //    if (ScopeTrimVoltageUpdated)
            //    {

            //    }
            //    ScopeTrimVoltageUpdated = false;
            //}
        }

        private void updateVoltage()
        {
            //Mu2e_FEB_client myFEBclient = null;
            double v;
            //if (_ActiveFEB == 1)
            //{ myFEBclient = PP.FEB1; }
            //else if (_ActiveFEB == 2)
            //{ myFEBclient = PP.FEB2; }
            //else
            //{ MessageBox.Show("No FEB active"); return; }

            //DMM.GetVoltage(ActiveHdmiChannel.channel);

            if (ActiveHdmiChannel != null)
            {
                Mu2e_Register.ReadReg(ref rBias, ref myFEBclient.client);
                v = rBias.val * 0.02;
                txtBiasSet0.Text = v.ToString("0.000");
                Mu2e_Register.ReadReg(ref rLed, ref myFEBclient.client);
                v = rLed.val * 0.003333333;
                txtLEDSet0.Text = v.ToString("0.000");
                Mu2e_Register.ReadReg(ref rTrim0, ref myFEBclient.client);
                v = ((double)rTrim0.val - 2048) * 0.002;
                txtTrimSet0.Text = v.ToString("0.000");
                Mu2e_Register.ReadReg(ref rTrim1, ref myFEBclient.client);
                v = ((double)rTrim1.val - 2048) * 0.002;
                txtTrimSet1.Text = v.ToString("0.000");
                Mu2e_Register.ReadReg(ref rTrim2, ref myFEBclient.client);
                v = ((double)rTrim2.val - 2048) * 0.002;
                txtTrimSet2.Text = v.ToString("0.000");
                Mu2e_Register.ReadReg(ref rTrim3, ref myFEBclient.client);
                v = ((double)rTrim3.val - 2048) * 0.002;
                txtTrimSet3.Text = v.ToString("0.000");

                Application.DoEvents();
            }
            else { MessageBox.Show("No HDMI channel selected"); return; }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDacWrite_Click(object sender, EventArgs e)
        {
            //Mu2e_FEB_client myFEBclient = null;

            //if (_ActiveFEB == 1)
            //{ myFEBclient = PP.FEB1; }
            //else if (_ActiveFEB == 2)
            //{ myFEBclient = PP.FEB2; }
            //else
            //{ MessageBox.Show("No FEB active"); return; }

            double v;
            UInt32 vInt;

            v = Convert.ToDouble(txtBiasSet0.Text);
            vInt = (UInt32)v * 50;
            Mu2e_Register.WriteReg(vInt, ref rBias, ref myFEBclient.client);
            v = Convert.ToDouble(txtLEDSet0.Text);
            vInt = (UInt32)v * 300;
            Mu2e_Register.WriteReg(vInt, ref rLed, ref myFEBclient.client);
            v = Convert.ToDouble(txtTrimSet0.Text) * 500 + 2048;
            vInt = (UInt32)v;
            Mu2e_Register.WriteReg(vInt, ref rTrim0, ref myFEBclient.client);
            v = Convert.ToDouble(txtTrimSet1.Text) * 500 + 2048;
            vInt = (UInt32)v;
            Mu2e_Register.WriteReg(vInt, ref rTrim1, ref myFEBclient.client);
            v = Convert.ToDouble(txtTrimSet2.Text) * 500 + 2048;
            vInt = (UInt32)v;
            Mu2e_Register.WriteReg(vInt, ref rTrim2, ref myFEBclient.client);
            v = Convert.ToDouble(txtTrimSet3.Text) * 500 + 2048;
            vInt = (UInt32)v;
            Mu2e_Register.WriteReg(vInt, ref rTrim3, ref myFEBclient.client);
            updateVoltage();
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnDacScan_Click(object sender, EventArgs e)
        {
            //Mu2e_FEB_client myFEBclient = null;
            double v;

            //myFEBclient = PP.FEB1;
            UInt32 vInt;

            v = 65;
            vInt = (UInt32)v * 50;
            Mu2e_Register.WriteReg(vInt, ref rBias, ref myFEBclient.client);
            v = 12;
            vInt = (UInt32)v * 300;
            Mu2e_Register.WriteReg(vInt, ref rLed, ref myFEBclient.client);
            v = 4 * 500 + 2048;
            vInt = (UInt32)v;
            Mu2e_Register.WriteReg(vInt, ref rTrim0, ref myFEBclient.client);
            v = 4 * 500 + 2048;
            vInt = (UInt32)v;
            Mu2e_Register.WriteReg(vInt, ref rTrim1, ref myFEBclient.client);
            v = 4 * 500 + 2048;
            vInt = (UInt32)v;
            Mu2e_Register.WriteReg(vInt, ref rTrim2, ref myFEBclient.client);
            v = 4 * 500 + 2048;
            vInt = (UInt32)v;
            Mu2e_Register.WriteReg(vInt, ref rTrim3, ref myFEBclient.client);
            updateVoltage();
            for (int t = 0; t < 200; t++)
            {
                System.Threading.Thread.Sleep(20);
                Application.DoEvents();
            }

            //Check voltage readbacks. If all six too small, print error message.
            bool doScan = true;
            if (vScopeBias < 50 || vScopeLED < 10 || vScopeTrim0 < 1 || vScopeTrim1 < 1 || vScopeTrim2 < 1 || vScopeTrim3 < 1)
            {
                DialogResult result = MessageBox.Show("Test cable appears to not be connected.\nAre you sure you are connected to the correct channel?\nRun anyway?", "", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    doScan = false;

                    v = 0;
                    vInt = (UInt32)v * 50;
                    Mu2e_Register.WriteReg(vInt, ref rBias, ref myFEBclient.client);
                    vInt = (UInt32)v * 300;
                    Mu2e_Register.WriteReg(vInt, ref rLed, ref myFEBclient.client);
                    v = 2048;
                    vInt = (UInt32)v;
                    Mu2e_Register.WriteReg(vInt, ref rTrim0, ref myFEBclient.client);
                    vInt = (UInt32)v;
                    Mu2e_Register.WriteReg(vInt, ref rTrim1, ref myFEBclient.client);
                    vInt = (UInt32)v;
                    Mu2e_Register.WriteReg(vInt, ref rTrim2, ref myFEBclient.client);
                    vInt = (UInt32)v;
                    Mu2e_Register.WriteReg(vInt, ref rTrim3, ref myFEBclient.client);
                    updateVoltage();
                    Application.DoEvents();
                }
            }

            if (doScan)
            {
                // Plays the sound associated with the Asterisk system event.
                SystemSounds.Asterisk.Play();
                doTest(ActiveHdmiChannel.Bias0, 65, 35, 10);
                doTest(ActiveHdmiChannel.Led0, 12, 6, 0);
                doTest(ActiveHdmiChannel.Trim0, 4, 0, -4);
                doTest(ActiveHdmiChannel.Trim1, 4, 0, -4);
                doTest(ActiveHdmiChannel.Trim2, 4, 0, -4);
                doTest(ActiveHdmiChannel.Trim3, 4, 0, -4);
                //doTest(ActiveHdmiChannel.Bias0, vScopeBias, 75, 35, 10);
                //doTest(ActiveHdmiChannel.Led0, vScopeLED, 14, 7, 0);
                //doTest(ActiveHdmiChannel.Trim0, vScopeTrim0, 4, 0, -4);
                //doTest(ActiveHdmiChannel.Trim1, vScopeTrim1, 4, 0, -4);
                //doTest(ActiveHdmiChannel.Trim2, vScopeTrim2, 4, 0, -4);
                //doTest(ActiveHdmiChannel.Trim3, vScopeTrim3, 4, 0, -4);
                doMuxTest(ActiveHdmiChannel.Trim0, 4);
                doMuxTest(ActiveHdmiChannel.Trim1, 4);
                doMuxTest(ActiveHdmiChannel.Trim2, 4);
                doMuxTest(ActiveHdmiChannel.Trim3, 4);
                ActiveHdmiChannel.isTested = true;
                setButtonColor();
                // Plays the sound associated with the Exclamation system event.
                SystemSounds.Exclamation.Play();
            }
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnSnSave_Click(object sender, EventArgs e)
        {
            myFEB.FEBserialNum = txtSN.Text;
            myFEBclient.SendStr("SN 123 " + txtSN.Text);
        }

        private void btnJ11_Click(object sender, EventArgs e)
        {
            if (HdmiChannel0 == null)
            {
                HdmiChannel0 = new HdmiChannel();
                HdmiChannel0.Bias0 = new BiasProperties();
                HdmiChannel0.Led0 = new LedProperties();
                HdmiChannel0.Trim0 = new TrimProperties();
                HdmiChannel0.Trim1 = new TrimProperties();
                HdmiChannel0.Trim2 = new TrimProperties();
                HdmiChannel0.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel0, 0);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel0))
            { HdmiChannelList.Add(HdmiChannel0); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ12_Click(object sender, EventArgs e)
        {
            if (HdmiChannel1 == null)
            {
                HdmiChannel1 = new HdmiChannel();
                HdmiChannel1.Bias0 = new BiasProperties();
                HdmiChannel1.Led0 = new LedProperties();
                HdmiChannel1.Trim0 = new TrimProperties();
                HdmiChannel1.Trim1 = new TrimProperties();
                HdmiChannel1.Trim2 = new TrimProperties();
                HdmiChannel1.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel1, 1);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel1))
            { HdmiChannelList.Add(HdmiChannel1); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ13_Click(object sender, EventArgs e)
        {
            if (HdmiChannel2 == null)
            {
                HdmiChannel2 = new HdmiChannel();
                HdmiChannel2.Bias0 = new BiasProperties();
                HdmiChannel2.Led0 = new LedProperties();
                HdmiChannel2.Trim0 = new TrimProperties();
                HdmiChannel2.Trim1 = new TrimProperties();
                HdmiChannel2.Trim2 = new TrimProperties();
                HdmiChannel2.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel2, 2);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel2))
            { HdmiChannelList.Add(HdmiChannel2); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ14_Click(object sender, EventArgs e)
        {
            if (HdmiChannel3 == null)
            {
                HdmiChannel3 = new HdmiChannel();
                HdmiChannel3.Bias0 = new BiasProperties();
                HdmiChannel3.Led0 = new LedProperties();
                HdmiChannel3.Trim0 = new TrimProperties();
                HdmiChannel3.Trim1 = new TrimProperties();
                HdmiChannel3.Trim2 = new TrimProperties();
                HdmiChannel3.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel3, 3);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel3))
            { HdmiChannelList.Add(HdmiChannel3); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ15_Click(object sender, EventArgs e)
        {
            if (HdmiChannel4 == null)
            {
                HdmiChannel4 = new HdmiChannel();
                HdmiChannel4.Bias0 = new BiasProperties();
                HdmiChannel4.Led0 = new LedProperties();
                HdmiChannel4.Trim0 = new TrimProperties();
                HdmiChannel4.Trim1 = new TrimProperties();
                HdmiChannel4.Trim2 = new TrimProperties();
                HdmiChannel4.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel4, 4);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel4))
            { HdmiChannelList.Add(HdmiChannel4); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ16_Click(object sender, EventArgs e)
        {
            if (HdmiChannel5 == null)
            {
                HdmiChannel5 = new HdmiChannel();
                HdmiChannel5.Bias0 = new BiasProperties();
                HdmiChannel5.Led0 = new LedProperties();
                HdmiChannel5.Trim0 = new TrimProperties();
                HdmiChannel5.Trim1 = new TrimProperties();
                HdmiChannel5.Trim2 = new TrimProperties();
                HdmiChannel5.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel5, 5);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel5))
            { HdmiChannelList.Add(HdmiChannel5); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ17_Click(object sender, EventArgs e)
        {
            if (HdmiChannel6 == null)
            {
                HdmiChannel6 = new HdmiChannel();
                HdmiChannel6.Bias0 = new BiasProperties();
                HdmiChannel6.Led0 = new LedProperties();
                HdmiChannel6.Trim0 = new TrimProperties();
                HdmiChannel6.Trim1 = new TrimProperties();
                HdmiChannel6.Trim2 = new TrimProperties();
                HdmiChannel6.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel6, 6);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel6))
            { HdmiChannelList.Add(HdmiChannel6); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ18_Click(object sender, EventArgs e)
        {
            if (HdmiChannel7 == null)
            {
                HdmiChannel7 = new HdmiChannel();
                HdmiChannel7.Bias0 = new BiasProperties();
                HdmiChannel7.Led0 = new LedProperties();
                HdmiChannel7.Trim0 = new TrimProperties();
                HdmiChannel7.Trim1 = new TrimProperties();
                HdmiChannel7.Trim2 = new TrimProperties();
                HdmiChannel7.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel7, 7);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel7))
            { HdmiChannelList.Add(HdmiChannel7); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ19_Click(object sender, EventArgs e)
        {
            if (HdmiChannel8 == null)
            {
                HdmiChannel8 = new HdmiChannel();
                HdmiChannel8.Bias0 = new BiasProperties();
                HdmiChannel8.Led0 = new LedProperties();
                HdmiChannel8.Trim0 = new TrimProperties();
                HdmiChannel8.Trim1 = new TrimProperties();
                HdmiChannel8.Trim2 = new TrimProperties();
                HdmiChannel8.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel8, 8);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel8))
            { HdmiChannelList.Add(HdmiChannel8); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ20_Click(object sender, EventArgs e)
        {
            if (HdmiChannel9 == null)
            {
                HdmiChannel9 = new HdmiChannel();
                HdmiChannel9.Bias0 = new BiasProperties();
                HdmiChannel9.Led0 = new LedProperties();
                HdmiChannel9.Trim0 = new TrimProperties();
                HdmiChannel9.Trim1 = new TrimProperties();
                HdmiChannel9.Trim2 = new TrimProperties();
                HdmiChannel9.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel9, 9);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel9))
            { HdmiChannelList.Add(HdmiChannel9); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ21_Click(object sender, EventArgs e)
        {
            if (HdmiChannel10 == null)
            {
                HdmiChannel10 = new HdmiChannel();
                HdmiChannel10.Bias0 = new BiasProperties();
                HdmiChannel10.Led0 = new LedProperties();
                HdmiChannel10.Trim0 = new TrimProperties();
                HdmiChannel10.Trim1 = new TrimProperties();
                HdmiChannel10.Trim2 = new TrimProperties();
                HdmiChannel10.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel10, 10);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel10))
            { HdmiChannelList.Add(HdmiChannel10); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ22_Click(object sender, EventArgs e)
        {
            if (HdmiChannel11 == null)
            {
                HdmiChannel11 = new HdmiChannel();
                HdmiChannel11.Bias0 = new BiasProperties();
                HdmiChannel11.Led0 = new LedProperties();
                HdmiChannel11.Trim0 = new TrimProperties();
                HdmiChannel11.Trim1 = new TrimProperties();
                HdmiChannel11.Trim2 = new TrimProperties();
                HdmiChannel11.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel11, 11);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel11))
            { HdmiChannelList.Add(HdmiChannel11); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ23_Click(object sender, EventArgs e)
        {
            if (HdmiChannel12 == null)
            {
                HdmiChannel12 = new HdmiChannel();
                HdmiChannel12.Bias0 = new BiasProperties();
                HdmiChannel12.Led0 = new LedProperties();
                HdmiChannel12.Trim0 = new TrimProperties();
                HdmiChannel12.Trim1 = new TrimProperties();
                HdmiChannel12.Trim2 = new TrimProperties();
                HdmiChannel12.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel12, 12);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel12))
            { HdmiChannelList.Add(HdmiChannel12); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ24_Click(object sender, EventArgs e)
        {
            if (HdmiChannel13 == null)
            {
                HdmiChannel13 = new HdmiChannel();
                HdmiChannel13.Bias0 = new BiasProperties();
                HdmiChannel13.Led0 = new LedProperties();
                HdmiChannel13.Trim0 = new TrimProperties();
                HdmiChannel13.Trim1 = new TrimProperties();
                HdmiChannel13.Trim2 = new TrimProperties();
                HdmiChannel13.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel13, 13);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel13))
            { HdmiChannelList.Add(HdmiChannel13); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ25_Click(object sender, EventArgs e)
        {
            if (HdmiChannel14 == null)
            {
                HdmiChannel14 = new HdmiChannel();
                HdmiChannel14.Bias0 = new BiasProperties();
                HdmiChannel14.Led0 = new LedProperties();
                HdmiChannel14.Trim0 = new TrimProperties();
                HdmiChannel14.Trim1 = new TrimProperties();
                HdmiChannel14.Trim2 = new TrimProperties();
                HdmiChannel14.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel14, 14);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel14))
            { HdmiChannelList.Add(HdmiChannel14); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnJ26_Click(object sender, EventArgs e)
        {
            if (HdmiChannel15 == null)
            {
                HdmiChannel15 = new HdmiChannel();
                HdmiChannel15.Bias0 = new BiasProperties();
                HdmiChannel15.Led0 = new LedProperties();
                HdmiChannel15.Trim0 = new TrimProperties();
                HdmiChannel15.Trim1 = new TrimProperties();
                HdmiChannel15.Trim2 = new TrimProperties();
                HdmiChannel15.Trim3 = new TrimProperties();
            }
            setHdmiChannel(HdmiChannel15, 15);
            if (!HdmiChannelList.Exists(x => x == HdmiChannel15))
            { HdmiChannelList.Add(HdmiChannel15); }
            setButtonColor();
            updateVoltage();
            Application.DoEvents();
        }

        private void btnDacSave_Click(object sender, EventArgs e)
        {
            bool DoSave = true;

            foreach (var chan in HdmiChannelList)
            {
                if (!chan.isTested)
                {
                    DialogResult result = MessageBox.Show("Channel " + chan.button.Text + " appears to be untested. Save anyway?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) { DoSave = false; }
                }
            }
            if (DoSave)
            {
                string dirName = "c://data//";
                string hName = "";
                DateTime testDate = DateTime.Now;

                hName += "FEBdsf_";
                hName += txtSN.Text;
                hName += "_";
                hName += testDate.ToString("yyyyMMdd");
                hName = dirName + hName + ".dsf";
                StreamWriter sw = new StreamWriter(hName);

                string biasAddr = "044";
                string trim0Addr = "030";
                string trim1Addr = "031";
                string trim2Addr = "032";
                string trim3Addr = "033";

                foreach (var chan in HdmiChannelList)
                {
                    if (chan == HdmiChannel0)
                    {
                        biasAddr = "044";
                        trim0Addr = "030";
                        trim1Addr = "031";
                        trim2Addr = "032";
                        trim3Addr = "033";
                    }
                    else if (chan == HdmiChannel1)
                    {
                        biasAddr = "044";
                        trim0Addr = "034";
                        trim1Addr = "035";
                        trim2Addr = "036";
                        trim3Addr = "037";
                    }
                    else if (chan == HdmiChannel2)
                    {
                        biasAddr = "045";
                        trim0Addr = "038";
                        trim1Addr = "039";
                        trim2Addr = "03A";
                        trim3Addr = "03B";
                    }
                    else if (chan == HdmiChannel3)
                    {
                        biasAddr = "045";
                        trim0Addr = "03C";
                        trim1Addr = "03D";
                        trim2Addr = "03E";
                        trim3Addr = "03F";
                    }
                    else if (chan == HdmiChannel4)
                    {
                        biasAddr = "444";
                        trim0Addr = "430";
                        trim1Addr = "431";
                        trim2Addr = "432";
                        trim3Addr = "433";
                    }
                    else if (chan == HdmiChannel5)
                    {
                        biasAddr = "444";
                        trim0Addr = "434";
                        trim1Addr = "435";
                        trim2Addr = "436";
                        trim3Addr = "437";
                    }
                    else if (chan == HdmiChannel6)
                    {
                        biasAddr = "445";
                        trim0Addr = "438";
                        trim1Addr = "439";
                        trim2Addr = "43A";
                        trim3Addr = "43B";
                    }
                    else if (chan == HdmiChannel7)
                    {
                        biasAddr = "445";
                        trim0Addr = "43C";
                        trim1Addr = "43D";
                        trim2Addr = "43E";
                        trim3Addr = "43F";
                    }
                    else if (chan == HdmiChannel8)
                    {
                        biasAddr = "844";
                        trim0Addr = "830";
                        trim1Addr = "831";
                        trim2Addr = "832";
                        trim3Addr = "833";
                    }
                    else if (chan == HdmiChannel9)
                    {
                        biasAddr = "844";
                        trim0Addr = "834";
                        trim1Addr = "835";
                        trim2Addr = "836";
                        trim3Addr = "837";
                    }
                    else if (chan == HdmiChannel10)
                    {
                        biasAddr = "845";
                        trim0Addr = "838";
                        trim1Addr = "839";
                        trim2Addr = "83A";
                        trim3Addr = "83B";
                    }
                    else if (chan == HdmiChannel11)
                    {
                        biasAddr = "845";
                        trim0Addr = "83C";
                        trim1Addr = "83D";
                        trim2Addr = "83E";
                        trim3Addr = "83F";
                    }
                    else if (chan == HdmiChannel12)
                    {
                        biasAddr = "C44";
                        trim0Addr = "C30";
                        trim1Addr = "C31";
                        trim2Addr = "C32";
                        trim3Addr = "C33";
                    }
                    else if (chan == HdmiChannel13)
                    {
                        biasAddr = "C44";
                        trim0Addr = "C34";
                        trim1Addr = "C35";
                        trim2Addr = "C36";
                        trim3Addr = "C37";
                    }
                    else if (chan == HdmiChannel14)
                    {
                        biasAddr = "C45";
                        trim0Addr = "C38";
                        trim1Addr = "C39";
                        trim2Addr = "C3A";
                        trim3Addr = "C3B";
                    }
                    else if (chan == HdmiChannel15)
                    {
                        biasAddr = "C45";
                        trim0Addr = "C3C";
                        trim1Addr = "C3D";
                        trim2Addr = "C3E";
                        trim3Addr = "C3F";
                    }
                    else { }
                    if (chan.isTested)
                    {
                        sw.WriteLine("dsf " + biasAddr + " " + chan.Bias0.slope + ", " + chan.Bias0.intercept);
                        sw.WriteLine("dsf " + trim0Addr + " " + chan.Trim0.slope + ", " + chan.Trim0.intercept);
                        sw.WriteLine("dsf " + trim1Addr + " " + chan.Trim1.slope + ", " + chan.Trim1.intercept);
                        sw.WriteLine("dsf " + trim2Addr + " " + chan.Trim2.slope + ", " + chan.Trim2.intercept);
                        sw.WriteLine("dsf " + trim3Addr + " " + chan.Trim3.slope + ", " + chan.Trim3.intercept);
                    }
                }
                sw.Close();

                string fName = "";
                fName += "HVtestVals_";
                fName += txtSN.Text;
                fName += "_";
                fName += testDate.ToString("yyyyMMdd");
                fName = dirName + fName + ".txt";
                StreamWriter swf = new StreamWriter(fName);

                string comments = txtCalibComments.Text;
                string hdmi = "";
                swf.WriteLine(comments);
                foreach (var chan in HdmiChannelList)
                {
                    if (chan == HdmiChannel0) { hdmi = "J11"; }
                    else if (chan == HdmiChannel1) { hdmi = "J12"; }
                    else if (chan == HdmiChannel2) { hdmi = "J13"; }
                    else if (chan == HdmiChannel3) { hdmi = "J14"; }
                    else if (chan == HdmiChannel4) { hdmi = "J15"; }
                    else if (chan == HdmiChannel5) { hdmi = "J16"; }
                    else if (chan == HdmiChannel6) { hdmi = "J17"; }
                    else if (chan == HdmiChannel7) { hdmi = "J18"; }
                    else if (chan == HdmiChannel8) { hdmi = "J19"; }
                    else if (chan == HdmiChannel9) { hdmi = "J20"; }
                    else if (chan == HdmiChannel10) { hdmi = "J21"; }
                    else if (chan == HdmiChannel11) { hdmi = "J22"; }
                    else if (chan == HdmiChannel12) { hdmi = "J23"; }
                    else if (chan == HdmiChannel13) { hdmi = "J24"; }
                    else if (chan == HdmiChannel14) { hdmi = "J25"; }
                    else if (chan == HdmiChannel15) { hdmi = "J26"; }
                    else { };

                    swf.WriteLine("HDMI port " + hdmi);

                    swf.Write("Bias high HV test results: ");
                    foreach (var val in chan.Bias0.HVHiVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Bias medium HV test results: ");
                    foreach (var val in chan.Bias0.HVMedVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Bias low HV test results: ");
                    foreach (var val in chan.Bias0.HVLowVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("LED high HV test results: ");
                    foreach (var val in chan.Led0.HVHiVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("LED medium HV test results: ");
                    foreach (var val in chan.Led0.HVMedVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("LED low HV test results: ");
                    foreach (var val in chan.Led0.HVLowVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim0 high HV test results: ");
                    foreach (var val in chan.Trim0.HVHiVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim0 medium HV test results: ");
                    foreach (var val in chan.Trim0.HVMedVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim0 low HV test results: ");
                    foreach (var val in chan.Trim0.HVLowVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");


                    swf.Write("Trim1 high HV test results: ");
                    foreach (var val in chan.Trim1.HVHiVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim1 medium HV test results: ");
                    foreach (var val in chan.Trim1.HVMedVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim1 low HV test results: ");
                    foreach (var val in chan.Trim1.HVLowVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");


                    swf.Write("Trim2 high HV test results: ");
                    foreach (var val in chan.Trim2.HVHiVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim2 medium HV test results: ");
                    foreach (var val in chan.Trim2.HVMedVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim2 low HV test results: ");
                    foreach (var val in chan.Trim2.HVLowVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");


                    swf.Write("Trim3 high HV test results: ");
                    foreach (var val in chan.Trim3.HVHiVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim3 medium HV test results: ");
                    foreach (var val in chan.Trim3.HVMedVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");

                    swf.Write("Trim3 low HV test results: ");
                    foreach (var val in chan.Trim3.HVLowVals)
                    {
                        swf.Write(val + " ");
                    }
                    swf.WriteLine("");
                }
                swf.Close();
            }
        }

        private void ScopeBiasConnectionChanged(object sender, ConnectedStateEventArgs e)
        {

        }

        private void ScopeTrimConnectionChanged(object sender, ConnectedStateEventArgs e)
        {

        }

        private void txtTrimRB0_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConnectScope_Click(object sender, EventArgs e)
        {

            TekScope.OnConnectedStateChanged += DMMTrimConnectionChanged;
            TekScope.OnVoltageChanged += DMMVoltagesChanged;

            if (TekScope.isConnected) btnConnectScope.Enabled = false;

            myFEB.GetVoltages(FEB.GetVoltageTypes.AllVoltages);

            //ScopeBias = new TekScope("Bias Scope", Properties.Settings.Default.ScopeBiasResourceString);
            //if (ScopeBias.isConnected == false)
            //{
            //    MessageBox.Show("Bias Scope could not be connected with " + Properties.Settings.Default.ScopeBiasResourceString);
            //}
            //else
            //{
            //    Properties.Settings.Default.ScopeBiasResourceString = ScopeBias.ResourceString;
            //    Properties.Settings.Default.Save();
            //    ScopeBias.OnConnectedStateChanged += ScopeBiasConnectionChanged;
            //    ScopeBias.OnVoltageChanged += ScopeBiasVoltageChanged;
            //    timerScopeBias.Enabled = true;
            //}

            //ScopeTrim = new TekScope("Trim Scope", Properties.Settings.Default.ScopeTrimResourceString);
            //if (ScopeTrim.isConnected == false)
            //{
            //    MessageBox.Show("Trim Scope could not be connected with " + Properties.Settings.Default.ScopeTrimResourceString);
            //}
            //else
            //{
            //    Properties.Settings.Default.ScopeTrimResourceString = ScopeTrim.ResourceString;
            //    Properties.Settings.Default.Save();
            //    ScopeTrim.OnConnectedStateChanged += ScopeTrimConnectionChanged;
            //    ScopeTrim.OnVoltageChanged += ScopeTrimVoltageChanged;
            //    timerScopeTrim.Enabled = true;
            //}

        }

        private void DMMVoltagesChanged(object sender, VoltageChangedEventsArgs e)
        {
            if (e.isValid && e.Voltage.Length == 6)
            {
                vScopeTrim0 = e.Voltage[0];
                txtTrimRB0.Text = vScopeTrim0.ToString("0.0000");
                vScopeTrim1 = e.Voltage[1];
                txtTrimRB1.Text = vScopeTrim1.ToString("0.0000");
                vScopeTrim2 = e.Voltage[2];
                txtTrimRB2.Text = vScopeTrim2.ToString("0.0000");
                vScopeTrim3 = e.Voltage[3];
                txtTrimRB3.Text = vScopeTrim3.ToString("0.0000");
                vScopeBias = e.Voltage[4];
                txtBiasRB0.Text = vScopeBias.ToString("0.000");
                vScopeLED = e.Voltage[5];
                txtLEDRB0.Text = vScopeLED.ToString("0.000");

                //tbVolts.Text = e.Voltage.ToString("0.00") + "V";
            }
            //else
            // tbVolts.Text = "x.xx";
        }

        //private void DMMBiasVoltageChanged(object sender, VoltageChangedEventsArgs e)
        //{
        //    if (DMM.inTestMode || e.isValid)
        //    {
        //        switch (e.channel)
        //        {
        //            case 1:

        //                break;
        //            default:
        //                break;
        //        }
        //        //tbVolts.Text = e.Voltage.ToString("0.00") + "V";
        //    }
        //    //else
        //    // tbVolts.Text = "x.xx";
        //}

        private void DMMBiasConnectionChanged(object sender, ConnectedStateEventArgs e)
        {

        }

        private void DMMTrimConnectionChanged(object sender, ConnectedStateEventArgs e)
        {

        }

        //private void ScopeTrimVoltageChanged(object sender, VoltageChangedEventsArgs e)
        //{
        //    if (ScopeTrim.inTestMode || e.isValid)
        //    {
        //        switch (e.channel)
        //        {
        //            case 1:
        //                vScopeTrim0 = e.Voltage;
        //                txtTrimRB0.Text = vScopeTrim0.ToString("0.00");
        //                break;
        //            case 2:
        //                vScopeTrim1 = e.Voltage;
        //                txtTrimRB1.Text = vScopeTrim1.ToString("0.00");
        //                break;
        //            case 3:
        //                vScopeTrim2 = e.Voltage;
        //                txtTrimRB2.Text = vScopeTrim2.ToString("0.00");
        //                break;
        //            case 4:
        //                vScopeTrim3 = e.Voltage;
        //                txtTrimRB3.Text = vScopeTrim3.ToString("0.00");
        //                break;
        //            default:
        //                break;
        //        }
        //        //tbVolts.Text = e.Voltage.ToString("0.00") + "V";
        //    }
        //    //else
        //    // tbVolts.Text = "x.xx";
        //    timerScopeTrim.Enabled = true;
        //    ScopeTrimVoltageUpdated = true;
        //}

        //private void ScopeBiasVoltageChanged(object sender, VoltageChangedEventsArgs e)
        //{
        //    if (ScopeBias.inTestMode || e.isValid)
        //    {
        //        switch (e.channel)
        //        {
        //            case 1:
        //                vScopeBias = e.Voltage;
        //                txtBiasRB0.Text = vScopeBias.ToString("0.00");
        //                break;
        //            case 2:
        //                vScopeLED = e.Voltage;
        //                txtLEDRB0.Text = vScopeLED.ToString("0.00");
        //                break;
        //            default:
        //                break;
        //        }
        //        //tbVolts.Text = e.Voltage.ToString("0.00") + "V";
        //    }
        //    //else
        //    // tbVolts.Text = "x.xx";
        //    timerScopeBias.Enabled = true;
        //    ScopeBiasVoltageUpdated = true;

        //}

        //private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (ScopeBias != null)
        //        ScopeBias.closeScope();
        //    if (ScopeTrim != null)
        //        ScopeTrim.closeScope();
        //}

        private void timerScopeTrim_Tick(object sender, EventArgs e)
        {
            //    timerScopeTrim.Enabled = false; //renabled in the voltageChagned call back
            //    if (ScopeTrim != null && ScopeTrim.isConnected == true)
            //         ScopeTrim.GetVoltage();
        }

        private void timerScopeBias_Tick(object sender, EventArgs e)
        {
            //    timerScopeBias.Enabled = false; //renabled in the voltageChagned call back
            //    if (ScopeBias != null && ScopeBias.isConnected == true) { 
            //        VoltageChangedEventsArgs voltArgs = ScopeBias.GetVoltage();
            //        Console.WriteLine("Here is an example where calling GetVoltage directly returns the reqested voltage."
            //                          + " Channel " + voltArgs.channel + " = " + voltArgs.Voltage);
            //        }
        }

        private void txtTrimSet3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string cmb_reg;
            myFEBclient.ReadCMB(out cmb_reg);
            label9.Text = cmb_reg;
            Application.DoEvents();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //UpdateDisplay();
            //Application.DoEvents();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked && checkBox5.Checked && checkBox6.Checked && checkBox7.Checked && checkBox8.Checked)
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
            if (checkBox9.Checked && checkBox10.Checked && checkBox11.Checked && checkBox12.Checked && checkBox13.Checked && checkBox14.Checked && checkBox15.Checked && checkBox16.Checked)
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

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSelLowHist_Click(object sender, EventArgs e)
        {
            if (chkBoxJ11Hist.Checked && chkBoxJ12Hist.Checked && chkBoxJ13Hist.Checked && chkBoxJ14Hist.Checked && chkBoxJ15Hist.Checked && chkBoxJ16Hist.Checked && chkBoxJ17Hist.Checked && chkBoxJ18Hist.Checked)
            {
                chkBoxJ11Hist.Checked = false;
                chkBoxJ12Hist.Checked = false;
                chkBoxJ13Hist.Checked = false;
                chkBoxJ14Hist.Checked = false;
                chkBoxJ15Hist.Checked = false;
                chkBoxJ16Hist.Checked = false;
                chkBoxJ17Hist.Checked = false;
                chkBoxJ18Hist.Checked = false;
            }
            else
            {
                chkBoxJ11Hist.Checked = true;
                chkBoxJ12Hist.Checked = true;
                chkBoxJ13Hist.Checked = true;
                chkBoxJ14Hist.Checked = true;
                chkBoxJ15Hist.Checked = true;
                chkBoxJ16Hist.Checked = true;
                chkBoxJ17Hist.Checked = true;
                chkBoxJ18Hist.Checked = true;
            }
        }

        private void btnSelHiHist_Click(object sender, EventArgs e)
        {
            if (chkBoxJ19Hist.Checked && chkBoxJ20Hist.Checked && chkBoxJ21Hist.Checked && chkBoxJ22Hist.Checked && chkBoxJ23Hist.Checked && chkBoxJ24Hist.Checked && chkBoxJ25Hist.Checked && chkBoxJ26Hist.Checked)
            {
                chkBoxJ19Hist.Checked = false;
                chkBoxJ20Hist.Checked = false;
                chkBoxJ21Hist.Checked = false;
                chkBoxJ22Hist.Checked = false;
                chkBoxJ23Hist.Checked = false;
                chkBoxJ24Hist.Checked = false;
                chkBoxJ25Hist.Checked = false;
                chkBoxJ26Hist.Checked = false;
            }
            else
            {
                chkBoxJ19Hist.Checked = true;
                chkBoxJ20Hist.Checked = true;
                chkBoxJ21Hist.Checked = true;
                chkBoxJ22Hist.Checked = true;
                chkBoxJ23Hist.Checked = true;
                chkBoxJ24Hist.Checked = true;
                chkBoxJ25Hist.Checked = true;
                chkBoxJ26Hist.Checked = true;
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            string cmb_reg;
            myFEBclient.ReadCMB(out cmb_reg);
            labelTempHist.Text = cmb_reg;
            Application.DoEvents();
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
                trimsig.calibration.Vlow = trimsig.SaveMeasurements();
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
                ts.Minutes, ts.Seconds, ts.Milliseconds);
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
            ZeroAllVoltages();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            btnMuxTest.Text = "SCANNING...";
            Application.DoEvents();

            //Must be a power of 2.
            //int gain = 8;
            int stime = 20;

            bool startingMode = TekScope.inTestMode;
            TekScope.inTestMode = true;

            myFEBclient.MuxTestSetup();

            foreach (TrimSignal trimsig in myFEB.Trims)
            { SetVoltage(trimsig, -2); }
            foreach (TrimSignal trimsig in myFEB.Trims)
            {
                //Wait 100ms to make sure voltages have ramped.
                System.Threading.Thread.Sleep(100);
                int fpga = trimsig.myFPGA_ID;
                int ch = trimsig.signalIndex;

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
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:000}",
                ts.Minutes, ts.Seconds, ts.Milliseconds);
            lblMuxTime.Text = "Scan time: " + elapsedTime;
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
            //activeVoltageSignal = null;
            //otherBias = null;
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
            foreach (TrimSignal trim in myFEB.Trims)
            {
                if (!trim.calibration.isTested)
                {
                    DialogResult result = MessageBox.Show(trim.name + " appears to be untested. Save anyway?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) { return; }
                }
                if (trim.isBad || trim.muxIsBad)
                {
                    DialogResult result = MessageBox.Show(trim.name + " appears to be bad. Save anyway?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) { return; }
                }
            }
            foreach (BiasChannel bias in myFEB.Biases)
            {
                if (!bias.calibration.isTested)
                {
                    DialogResult result = MessageBox.Show(bias.name + " appears to be untested. Save anyway?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) { return; }
                }
                if (bias.Biases[0].isBad || bias.Biases[1].isBad)
                {
                    DialogResult result = MessageBox.Show(bias.name + " appears to be bad. Save anyway?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) { return; }
                }
            }

            DateTime testDate = DateTime.Now;

            string dsfFileName = "";
            dsfFileName += "FEBdsf_";
            dsfFileName += txtSN.Text;
            dsfFileName += "_";
            dsfFileName += testDate.ToString("yyyyMMdd");
            saveFileCalibrations.FileName = dsfFileName;

            saveFileCalibrations.ShowDialog();
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
        }

        private void btnSaveDB_Click(object sender, EventArgs e)
        {
            bool hasBadChannel = false;
            bool hasUntestedChannel = false;
            string untestedChannelMessage = "";
            if (txtHVTestComments.Text.Length < 1)
            {
                DialogResult result = MessageBox.Show("Please enter a comment before saving", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK) { return; }
            }
            foreach (TrimSignal trim in myFEB.Trims)
            {
                if (!trim.calibration.isTested)
                {
                    untestedChannelMessage += "\n" + trim.name;
                    hasUntestedChannel = true;
                }
                if (trim.isBad || trim.muxIsBad) { hasBadChannel = true; }
            }
            foreach (BiasChannel bias in myFEB.Biases)
            {
                if (!bias.calibration.isTested)
                {
                    untestedChannelMessage += "\n" + bias.name;
                    hasUntestedChannel = true;
                }
                if (bias.Biases[0].isBad || bias.Biases[1].isBad) { hasBadChannel = true; }
            }
            foreach (LEDsignal led in myFEB.LEDs)
            {
                if (!led.calibration.isTested)
                {
                    untestedChannelMessage += "\n" + led.name;
                    hasUntestedChannel = true;
                }
                if (led.isBad) { hasBadChannel = true; }
            }
            if (hasUntestedChannel)
            {
                DialogResult result = MessageBox.Show(
                    "The following channels appear to be untested. Save anyway?" 
                    + untestedChannelMessage,"", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }
            }

            if (txtHVTestComments.Text == "All HV channels OK." && hasBadChannel)
            {
                DialogResult result = MessageBox.Show(
                    "One or more of the HV channels is flagged as bad. Please change the comments to indicate this.",
                    "", MessageBoxButtons.OK);
                if (result == DialogResult.OK) { return; }
            }

            DateTime testDate = DateTime.Now;

            string sn = myFEB.FEBserialNum.Replace("\r\n\r", "");
            string dbFileName = 
                "FEB_" + sn + "_" + 
                txtTestType.Text.Replace(" ", "") + 
                "_" + testDate.ToString("yyyyMMdd");
            saveFileDB.FileName = dbFileName;
            string FEBlocation = "KSU Test Stand";

            saveFileDB.ShowDialog();
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
                    dbStream.WriteLine();
                    dbStream.Write(txtHVTestComments.Text);
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

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void zedFEB1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            PP.FEB1.host_name_prop = txtFEBAddress.Text;
            Application.DoEvents();
            button1_Click((object)btnFEB1, e);
            Application.DoEvents();
            if (myFEBclient.ClientOpen)
            {
                myFEBclient.SendStr("SN");
                string snStr = "";
                string sn = "";
                int rt;
                myFEBclient.ReadStr(out snStr, out rt);
                sn = snStr.Replace("SerNumb=", "").TrimEnd('>');
                myFEB.FEBserialNum = sn;
                txtSN.Text = sn; 
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PP.FEB1.host_name_prop = txtFEBAddress.Text;
        }
    }

    public class ConnectAttemptEventArgs : EventArgs
    {
        public int ConnectAttempt { get; set; }
    }



}
