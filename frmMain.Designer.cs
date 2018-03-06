using System;

namespace TB_mu2e
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFEB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFEB2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWC = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRUN = new System.Windows.Forms.TabPage();
            this.lblRunLog = new System.Windows.Forms.Label();
            this.lblEventCount = new System.Windows.Forms.Label();
            this.groupBoxEvDisplay = new System.Windows.Forms.GroupBox();
            this.btnDisplaySpill = new System.Windows.Forms.Button();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.btnNextDisp = new System.Windows.Forms.Button();
            this.btnPrevDisp = new System.Windows.Forms.Button();
            this.ud_VertMin = new System.Windows.Forms.NumericUpDown();
            this.ud_VertMax = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnOneSpill = new System.Windows.Forms.Button();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.chkWC = new System.Windows.Forms.CheckBox();
            this.chkFEB2 = new System.Windows.Forms.CheckBox();
            this.chkFEB1 = new System.Windows.Forms.CheckBox();
            this.chkFakeIt = new System.Windows.Forms.CheckBox();
            this.lblWC_TotTrig = new System.Windows.Forms.Label();
            this.lblFEB2_TotTrig = new System.Windows.Forms.Label();
            this.lblFEB1_TotTrig = new System.Windows.Forms.Label();
            this.lblWCSpill = new System.Windows.Forms.Label();
            this.lblFEB2Spill = new System.Windows.Forms.Label();
            this.lblSpillTime = new System.Windows.Forms.Label();
            this.lblWCTrigNum = new System.Windows.Forms.Label();
            this.lblFEB2TrigNum = new System.Windows.Forms.Label();
            this.lblFEB1TrigNum = new System.Windows.Forms.Label();
            this.lblFEB1Spill = new System.Windows.Forms.Label();
            this.lblRunPrep = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSpillWC = new System.Windows.Forms.Label();
            this.lblSpillFEB2 = new System.Windows.Forms.Label();
            this.lblSpillFEB1 = new System.Windows.Forms.Label();
            this.lblRunName = new System.Windows.Forms.Label();
            this.btnStopRun = new System.Windows.Forms.Button();
            this.btnStartRun = new System.Windows.Forms.Button();
            this.btnPrepare = new System.Windows.Forms.Button();
            this.btnConnectAll = new System.Windows.Forms.Button();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.dbgWC = new System.Windows.Forms.Button();
            this.dbgFEB2 = new System.Windows.Forms.Button();
            this.dbgFEB1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnDebugLogging = new System.Windows.Forms.Button();
            this.lblConsole_disp = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabFEB1 = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnSaveHistos = new System.Windows.Forms.Button();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ShowSpect = new System.Windows.Forms.Button();
            this.ShowIV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTestSpill = new System.Windows.Forms.Button();
            this.zedFEB1 = new ZedGraph.ZedGraphControl();
            this.groupBoxSpillStat = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSpillMON = new System.Windows.Forms.Button();
            this.btnSpillWRITE = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSpillREAD = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBoxREG1 = new System.Windows.Forms.GroupBox();
            this.lblFPGA = new System.Windows.Forms.Label();
            this.btnCHANGE = new System.Windows.Forms.Button();
            this.udFPGA = new System.Windows.Forms.NumericUpDown();
            this.btnRegMON = new System.Windows.Forms.Button();
            this.btnRegWRITE = new System.Windows.Forms.Button();
            this.btnRegREAD = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.udInterval = new System.Windows.Forms.NumericUpDown();
            this.btnErase = new System.Windows.Forms.Button();
            this.lblInc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.udChan = new System.Windows.Forms.NumericUpDown();
            this.lblStop = new System.Windows.Forms.Label();
            this.udStop = new System.Windows.Forms.NumericUpDown();
            this.lblStart = new System.Windows.Forms.Label();
            this.udStart = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIntegral = new System.Windows.Forms.CheckBox();
            this.chkLogY = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtI = new System.Windows.Forms.TextBox();
            this.txtV = new System.Windows.Forms.TextBox();
            this.btnBiasREAD = new System.Windows.Forms.Button();
            this.btnBiasWRITE = new System.Windows.Forms.Button();
            this.btnBIAS_MON = new System.Windows.Forms.Button();
            this.lblI = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.groupBoxConn = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblActive = new System.Windows.Forms.Label();
            this.btnFEB2 = new System.Windows.Forms.Button();
            this.btnFEB1 = new System.Windows.Forms.Button();
            this.tabWC = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblWCmessage = new System.Windows.Forms.Label();
            this.btnWC = new System.Windows.Forms.Button();
            this.tabFEBtest = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnConnectScope = new System.Windows.Forms.Button();
            this.btnSnSave = new System.Windows.Forms.Button();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.DAC_Voltages = new System.Windows.Forms.GroupBox();
            this.btnZeroVoltages = new System.Windows.Forms.Button();
            this.txtMuxI3 = new System.Windows.Forms.TextBox();
            this.txtMuxI2 = new System.Windows.Forms.TextBox();
            this.txtMuxI1 = new System.Windows.Forms.TextBox();
            this.txtMuxI0 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.btnLoadCalib = new System.Windows.Forms.Button();
            this.txtTrim3Int = new System.Windows.Forms.TextBox();
            this.txtTrim3Slope = new System.Windows.Forms.TextBox();
            this.txtTrim2Int = new System.Windows.Forms.TextBox();
            this.txtTrim2Slope = new System.Windows.Forms.TextBox();
            this.txtTrim1Int = new System.Windows.Forms.TextBox();
            this.txtTrim1Slope = new System.Windows.Forms.TextBox();
            this.txtTrim0Int = new System.Windows.Forms.TextBox();
            this.txtTrim0Slope = new System.Windows.Forms.TextBox();
            this.txtBiasInt = new System.Windows.Forms.TextBox();
            this.txtBiasSlope = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtCalibComments = new System.Windows.Forms.TextBox();
            this.btnDacSave = new System.Windows.Forms.Button();
            this.btnJ26 = new System.Windows.Forms.Button();
            this.btnDacScan = new System.Windows.Forms.Button();
            this.btnJ25 = new System.Windows.Forms.Button();
            this.btnJ24 = new System.Windows.Forms.Button();
            this.btnDacWrite = new System.Windows.Forms.Button();
            this.btnJ23 = new System.Windows.Forms.Button();
            this.btnJ22 = new System.Windows.Forms.Button();
            this.btnJ21 = new System.Windows.Forms.Button();
            this.txtTrimRB3 = new System.Windows.Forms.TextBox();
            this.btnJ20 = new System.Windows.Forms.Button();
            this.txtTrimRB2 = new System.Windows.Forms.TextBox();
            this.btnJ19 = new System.Windows.Forms.Button();
            this.txtTrimRB1 = new System.Windows.Forms.TextBox();
            this.btnJ18 = new System.Windows.Forms.Button();
            this.txtTrimRB0 = new System.Windows.Forms.TextBox();
            this.btnJ17 = new System.Windows.Forms.Button();
            this.txtLEDRB0 = new System.Windows.Forms.TextBox();
            this.btnJ16 = new System.Windows.Forms.Button();
            this.txtBiasRB0 = new System.Windows.Forms.TextBox();
            this.btnJ15 = new System.Windows.Forms.Button();
            this.btnJ14 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btnJ13 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.btnJ12 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btnJ11 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTrimSet3 = new System.Windows.Forms.TextBox();
            this.txtTrimSet2 = new System.Windows.Forms.TextBox();
            this.txtTrimSet1 = new System.Windows.Forms.TextBox();
            this.txtTrimSet0 = new System.Windows.Forms.TextBox();
            this.txtLEDSet0 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBiasSet0 = new System.Windows.Forms.TextBox();
            this.tabIV = new System.Windows.Forms.TabPage();
            this.label33 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button18 = new System.Windows.Forms.Button();
            this.labelTempIV = new System.Windows.Forms.Label();
            this.btnSelHiIV = new System.Windows.Forms.Button();
            this.btnSelLowIV = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.chkBoxJ19IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ20IV = new System.Windows.Forms.CheckBox();
            this.btnIVScan = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.chkBoxJ21IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ22IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ23IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ24IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ25IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ26IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ15IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ16IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ17IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ18IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ13IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ14IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ12IV = new System.Windows.Forms.CheckBox();
            this.chkBoxJ11IV = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.zedGraphIV = new ZedGraph.ZedGraphControl();
            this.tabHist = new System.Windows.Forms.TabPage();
            this.button19 = new System.Windows.Forms.Button();
            this.labelTempHist = new System.Windows.Forms.Label();
            this.zedGraphHisto = new ZedGraph.ZedGraphControl();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSelHiHist = new System.Windows.Forms.Button();
            this.btnSelLowHist = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.chkBoxJ19Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ20Hist = new System.Windows.Forms.CheckBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.chkBoxJ21Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ22Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ23Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ24Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ25Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ26Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ15Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ16Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ17Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ18Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ13Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ14Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ12Hist = new System.Windows.Forms.CheckBox();
            this.chkBoxJ11Hist = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerScopeBias = new System.Windows.Forms.Timer(this.components);
            this.timerScopeTrim = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CalibPType = new System.Windows.Forms.TabPage();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabRUN.SuspendLayout();
            this.groupBoxEvDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_VertMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_VertMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabConsole.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabFEB1.SuspendLayout();
            this.groupBoxSpillStat.SuspendLayout();
            this.groupBoxREG1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udFPGA)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStart)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBoxConn.SuspendLayout();
            this.tabWC.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabFEBtest.SuspendLayout();
            this.DAC_Voltages.SuspendLayout();
            this.tabIV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.tabHist.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lblFEB1,
            this.lblFEB2,
            this.lblWC,
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 703);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(52, 20);
            this.toolStripStatusLabel2.Text = "Status:";
            // 
            // lblFEB1
            // 
            this.lblFEB1.Name = "lblFEB1";
            this.lblFEB1.Size = new System.Drawing.Size(41, 20);
            this.lblFEB1.Text = "FEB1";
            // 
            // lblFEB2
            // 
            this.lblFEB2.Name = "lblFEB2";
            this.lblFEB2.Size = new System.Drawing.Size(41, 20);
            this.lblFEB2.Text = "FEB2";
            // 
            // lblWC
            // 
            this.lblWC.Name = "lblWC";
            this.lblWC.Size = new System.Drawing.Size(32, 20);
            this.lblWC.Text = "WC";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(94, 20);
            this.lblMessage.Text = "last message";
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabRUN);
            this.tabControl.Controls.Add(this.tabConsole);
            this.tabControl.Controls.Add(this.tabFEB1);
            this.tabControl.Controls.Add(this.tabWC);
            this.tabControl.Controls.Add(this.tabFEBtest);
            this.tabControl.Controls.Add(this.tabIV);
            this.tabControl.Controls.Add(this.tabHist);
            this.tabControl.Controls.Add(this.CalibPType);
            this.tabControl.Location = new System.Drawing.Point(1, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1263, 701);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 1;
            // 
            // tabRUN
            // 
            this.tabRUN.Controls.Add(this.lblRunLog);
            this.tabRUN.Controls.Add(this.lblEventCount);
            this.tabRUN.Controls.Add(this.groupBoxEvDisplay);
            this.tabRUN.Controls.Add(this.groupBox1);
            this.tabRUN.Controls.Add(this.zg1);
            this.tabRUN.Location = new System.Drawing.Point(4, 32);
            this.tabRUN.Name = "tabRUN";
            this.tabRUN.Padding = new System.Windows.Forms.Padding(3);
            this.tabRUN.Size = new System.Drawing.Size(1255, 665);
            this.tabRUN.TabIndex = 0;
            this.tabRUN.Text = "RUN";
            this.tabRUN.UseVisualStyleBackColor = true;
            // 
            // lblRunLog
            // 
            this.lblRunLog.AutoSize = true;
            this.lblRunLog.BackColor = System.Drawing.SystemColors.Info;
            this.lblRunLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunLog.Location = new System.Drawing.Point(3, 459);
            this.lblRunLog.MinimumSize = new System.Drawing.Size(1240, 180);
            this.lblRunLog.Name = "lblRunLog";
            this.lblRunLog.Size = new System.Drawing.Size(1240, 221);
            this.lblRunLog.TabIndex = 3;
            this.lblRunLog.Text = "run log text goes here\r\n1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12";
            // 
            // lblEventCount
            // 
            this.lblEventCount.AutoEllipsis = true;
            this.lblEventCount.AutoSize = true;
            this.lblEventCount.Location = new System.Drawing.Point(7, 434);
            this.lblEventCount.MaximumSize = new System.Drawing.Size(620, 20);
            this.lblEventCount.Name = "lblEventCount";
            this.lblEventCount.Size = new System.Drawing.Size(125, 20);
            this.lblEventCount.TabIndex = 39;
            this.lblEventCount.Text = "Spill xxx, yyy ev";
            // 
            // groupBoxEvDisplay
            // 
            this.groupBoxEvDisplay.Controls.Add(this.btnDisplaySpill);
            this.groupBoxEvDisplay.Controls.Add(this.txtEvent);
            this.groupBoxEvDisplay.Controls.Add(this.btnNextDisp);
            this.groupBoxEvDisplay.Controls.Add(this.btnPrevDisp);
            this.groupBoxEvDisplay.Controls.Add(this.ud_VertMin);
            this.groupBoxEvDisplay.Controls.Add(this.ud_VertMax);
            this.groupBoxEvDisplay.Location = new System.Drawing.Point(620, 340);
            this.groupBoxEvDisplay.Name = "groupBoxEvDisplay";
            this.groupBoxEvDisplay.Size = new System.Drawing.Size(623, 114);
            this.groupBoxEvDisplay.TabIndex = 35;
            this.groupBoxEvDisplay.TabStop = false;
            this.groupBoxEvDisplay.Text = "EventDisplay";
            // 
            // btnDisplaySpill
            // 
            this.btnDisplaySpill.Location = new System.Drawing.Point(407, 78);
            this.btnDisplaySpill.Name = "btnDisplaySpill";
            this.btnDisplaySpill.Size = new System.Drawing.Size(102, 30);
            this.btnDisplaySpill.TabIndex = 40;
            this.btnDisplaySpill.Text = "DISPLAY";
            this.btnDisplaySpill.UseVisualStyleBackColor = true;
            this.btnDisplaySpill.Click += new System.EventHandler(this.btnDisplaySpill_Click);
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(517, 40);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(44, 27);
            this.txtEvent.TabIndex = 38;
            // 
            // btnNextDisp
            // 
            this.btnNextDisp.Location = new System.Drawing.Point(567, 37);
            this.btnNextDisp.Name = "btnNextDisp";
            this.btnNextDisp.Size = new System.Drawing.Size(50, 30);
            this.btnNextDisp.TabIndex = 37;
            this.btnNextDisp.Text = ">>>";
            this.btnNextDisp.UseVisualStyleBackColor = true;
            this.btnNextDisp.Click += new System.EventHandler(this.btnNextDisp_Click);
            // 
            // btnPrevDisp
            // 
            this.btnPrevDisp.Location = new System.Drawing.Point(466, 37);
            this.btnPrevDisp.Name = "btnPrevDisp";
            this.btnPrevDisp.Size = new System.Drawing.Size(50, 30);
            this.btnPrevDisp.TabIndex = 36;
            this.btnPrevDisp.Text = "<<<";
            this.btnPrevDisp.UseVisualStyleBackColor = true;
            this.btnPrevDisp.Click += new System.EventHandler(this.btnPrevDisp_Click);
            // 
            // ud_VertMin
            // 
            this.ud_VertMin.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ud_VertMin.Location = new System.Drawing.Point(515, 73);
            this.ud_VertMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ud_VertMin.Minimum = new decimal(new int[] {
            2500,
            0,
            0,
            -2147483648});
            this.ud_VertMin.Name = "ud_VertMin";
            this.ud_VertMin.Size = new System.Drawing.Size(66, 27);
            this.ud_VertMin.TabIndex = 35;
            this.ud_VertMin.Value = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            // 
            // ud_VertMax
            // 
            this.ud_VertMax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ud_VertMax.Location = new System.Drawing.Point(515, 7);
            this.ud_VertMax.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.ud_VertMax.Name = "ud_VertMax";
            this.ud_VertMax.Size = new System.Drawing.Size(66, 27);
            this.ud_VertMax.TabIndex = 34;
            this.ud_VertMax.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.btnOneSpill);
            this.groupBox1.Controls.Add(this.btnChangeName);
            this.groupBox1.Controls.Add(this.chkWC);
            this.groupBox1.Controls.Add(this.chkFEB2);
            this.groupBox1.Controls.Add(this.chkFEB1);
            this.groupBox1.Controls.Add(this.chkFakeIt);
            this.groupBox1.Controls.Add(this.lblWC_TotTrig);
            this.groupBox1.Controls.Add(this.lblFEB2_TotTrig);
            this.groupBox1.Controls.Add(this.lblFEB1_TotTrig);
            this.groupBox1.Controls.Add(this.lblWCSpill);
            this.groupBox1.Controls.Add(this.lblFEB2Spill);
            this.groupBox1.Controls.Add(this.lblSpillTime);
            this.groupBox1.Controls.Add(this.lblWCTrigNum);
            this.groupBox1.Controls.Add(this.lblFEB2TrigNum);
            this.groupBox1.Controls.Add(this.lblFEB1TrigNum);
            this.groupBox1.Controls.Add(this.lblFEB1Spill);
            this.groupBox1.Controls.Add(this.lblRunPrep);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblRunTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblSpillWC);
            this.groupBox1.Controls.Add(this.lblSpillFEB2);
            this.groupBox1.Controls.Add(this.lblSpillFEB1);
            this.groupBox1.Controls.Add(this.lblRunName);
            this.groupBox1.Controls.Add(this.btnStopRun);
            this.groupBox1.Controls.Add(this.btnStartRun);
            this.groupBox1.Controls.Add(this.btnPrepare);
            this.groupBox1.Controls.Add(this.btnConnectAll);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 418);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RUN CONTROL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "Fake Spill Len (s)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(534, 92);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(66, 27);
            this.numericUpDown1.TabIndex = 33;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnOneSpill
            // 
            this.btnOneSpill.Location = new System.Drawing.Point(6, 144);
            this.btnOneSpill.Name = "btnOneSpill";
            this.btnOneSpill.Size = new System.Drawing.Size(260, 52);
            this.btnOneSpill.TabIndex = 32;
            this.btnOneSpill.Tag = "";
            this.btnOneSpill.Text = "TAKE ONE SPILL";
            this.btnOneSpill.UseVisualStyleBackColor = true;
            this.btnOneSpill.Click += new System.EventHandler(this.btnOneSpill_Click);
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(500, 34);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(100, 33);
            this.btnChangeName.TabIndex = 31;
            this.btnChangeName.Tag = "";
            this.btnChangeName.Text = "CHANGE";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // chkWC
            // 
            this.chkWC.AutoSize = true;
            this.chkWC.Location = new System.Drawing.Point(440, 34);
            this.chkWC.Name = "chkWC";
            this.chkWC.Size = new System.Drawing.Size(59, 24);
            this.chkWC.TabIndex = 30;
            this.chkWC.Text = "WC";
            this.chkWC.UseVisualStyleBackColor = true;
            // 
            // chkFEB2
            // 
            this.chkFEB2.AutoSize = true;
            this.chkFEB2.Location = new System.Drawing.Point(365, 34);
            this.chkFEB2.Name = "chkFEB2";
            this.chkFEB2.Size = new System.Drawing.Size(73, 24);
            this.chkFEB2.TabIndex = 29;
            this.chkFEB2.Text = "FEB2";
            this.chkFEB2.UseVisualStyleBackColor = true;
            // 
            // chkFEB1
            // 
            this.chkFEB1.AutoSize = true;
            this.chkFEB1.Checked = true;
            this.chkFEB1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFEB1.Location = new System.Drawing.Point(290, 34);
            this.chkFEB1.Name = "chkFEB1";
            this.chkFEB1.Size = new System.Drawing.Size(73, 24);
            this.chkFEB1.TabIndex = 28;
            this.chkFEB1.Text = "FEB1";
            this.chkFEB1.UseVisualStyleBackColor = true;
            // 
            // chkFakeIt
            // 
            this.chkFakeIt.AutoSize = true;
            this.chkFakeIt.Checked = true;
            this.chkFakeIt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFakeIt.Location = new System.Drawing.Point(290, 92);
            this.chkFakeIt.Name = "chkFakeIt";
            this.chkFakeIt.Size = new System.Drawing.Size(76, 24);
            this.chkFakeIt.TabIndex = 27;
            this.chkFakeIt.Text = "FakeIt";
            this.chkFakeIt.UseVisualStyleBackColor = true;
            this.chkFakeIt.CheckedChanged += new System.EventHandler(this.chkFakeIt_CheckedChanged);
            // 
            // lblWC_TotTrig
            // 
            this.lblWC_TotTrig.AutoSize = true;
            this.lblWC_TotTrig.Location = new System.Drawing.Point(540, 305);
            this.lblWC_TotTrig.Name = "lblWC_TotTrig";
            this.lblWC_TotTrig.Size = new System.Drawing.Size(62, 20);
            this.lblWC_TotTrig.TabIndex = 26;
            this.lblWC_TotTrig.Text = "label14";
            // 
            // lblFEB2_TotTrig
            // 
            this.lblFEB2_TotTrig.AutoSize = true;
            this.lblFEB2_TotTrig.Location = new System.Drawing.Point(483, 305);
            this.lblFEB2_TotTrig.Name = "lblFEB2_TotTrig";
            this.lblFEB2_TotTrig.Size = new System.Drawing.Size(62, 20);
            this.lblFEB2_TotTrig.TabIndex = 25;
            this.lblFEB2_TotTrig.Text = "label14";
            // 
            // lblFEB1_TotTrig
            // 
            this.lblFEB1_TotTrig.AutoSize = true;
            this.lblFEB1_TotTrig.Location = new System.Drawing.Point(426, 305);
            this.lblFEB1_TotTrig.Name = "lblFEB1_TotTrig";
            this.lblFEB1_TotTrig.Size = new System.Drawing.Size(62, 20);
            this.lblFEB1_TotTrig.TabIndex = 24;
            this.lblFEB1_TotTrig.Text = "label14";
            // 
            // lblWCSpill
            // 
            this.lblWCSpill.AutoSize = true;
            this.lblWCSpill.Location = new System.Drawing.Point(540, 276);
            this.lblWCSpill.Name = "lblWCSpill";
            this.lblWCSpill.Size = new System.Drawing.Size(62, 20);
            this.lblWCSpill.TabIndex = 23;
            this.lblWCSpill.Text = "label14";
            // 
            // lblFEB2Spill
            // 
            this.lblFEB2Spill.AutoSize = true;
            this.lblFEB2Spill.Location = new System.Drawing.Point(483, 276);
            this.lblFEB2Spill.Name = "lblFEB2Spill";
            this.lblFEB2Spill.Size = new System.Drawing.Size(62, 20);
            this.lblFEB2Spill.TabIndex = 22;
            this.lblFEB2Spill.Text = "label14";
            // 
            // lblSpillTime
            // 
            this.lblSpillTime.AutoSize = true;
            this.lblSpillTime.Location = new System.Drawing.Point(426, 368);
            this.lblSpillTime.Name = "lblSpillTime";
            this.lblSpillTime.Size = new System.Drawing.Size(95, 20);
            this.lblSpillTime.TabIndex = 21;
            this.lblSpillTime.Text = "lblSpillTime";
            // 
            // lblWCTrigNum
            // 
            this.lblWCTrigNum.AutoSize = true;
            this.lblWCTrigNum.Location = new System.Drawing.Point(540, 334);
            this.lblWCTrigNum.Name = "lblWCTrigNum";
            this.lblWCTrigNum.Size = new System.Drawing.Size(53, 20);
            this.lblWCTrigNum.TabIndex = 20;
            this.lblWCTrigNum.Text = "label2";
            // 
            // lblFEB2TrigNum
            // 
            this.lblFEB2TrigNum.AutoSize = true;
            this.lblFEB2TrigNum.Location = new System.Drawing.Point(483, 334);
            this.lblFEB2TrigNum.Name = "lblFEB2TrigNum";
            this.lblFEB2TrigNum.Size = new System.Drawing.Size(53, 20);
            this.lblFEB2TrigNum.TabIndex = 19;
            this.lblFEB2TrigNum.Text = "label2";
            // 
            // lblFEB1TrigNum
            // 
            this.lblFEB1TrigNum.AutoSize = true;
            this.lblFEB1TrigNum.Location = new System.Drawing.Point(426, 334);
            this.lblFEB1TrigNum.Name = "lblFEB1TrigNum";
            this.lblFEB1TrigNum.Size = new System.Drawing.Size(53, 20);
            this.lblFEB1TrigNum.TabIndex = 18;
            this.lblFEB1TrigNum.Text = "label2";
            // 
            // lblFEB1Spill
            // 
            this.lblFEB1Spill.AutoSize = true;
            this.lblFEB1Spill.Location = new System.Drawing.Point(426, 276);
            this.lblFEB1Spill.Name = "lblFEB1Spill";
            this.lblFEB1Spill.Size = new System.Drawing.Size(62, 20);
            this.lblFEB1Spill.TabIndex = 17;
            this.lblFEB1Spill.Text = "label14";
            // 
            // lblRunPrep
            // 
            this.lblRunPrep.AutoSize = true;
            this.lblRunPrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunPrep.Location = new System.Drawing.Point(286, 119);
            this.lblRunPrep.Name = "lblRunPrep";
            this.lblRunPrep.Size = new System.Drawing.Size(85, 29);
            this.lblRunPrep.TabIndex = 16;
            this.lblRunPrep.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Last Spill Trig";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Total Num Trig";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Total Num Spills";
            // 
            // lblRunTime
            // 
            this.lblRunTime.AutoSize = true;
            this.lblRunTime.Location = new System.Drawing.Point(426, 214);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(0, 20);
            this.lblRunTime.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Time in run";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Spill Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Run Name";
            // 
            // lblSpillWC
            // 
            this.lblSpillWC.AutoSize = true;
            this.lblSpillWC.Location = new System.Drawing.Point(540, 185);
            this.lblSpillWC.Name = "lblSpillWC";
            this.lblSpillWC.Size = new System.Drawing.Size(53, 20);
            this.lblSpillWC.TabIndex = 8;
            this.lblSpillWC.Text = "label2";
            // 
            // lblSpillFEB2
            // 
            this.lblSpillFEB2.AutoSize = true;
            this.lblSpillFEB2.Location = new System.Drawing.Point(483, 185);
            this.lblSpillFEB2.Name = "lblSpillFEB2";
            this.lblSpillFEB2.Size = new System.Drawing.Size(53, 20);
            this.lblSpillFEB2.TabIndex = 7;
            this.lblSpillFEB2.Text = "label2";
            // 
            // lblSpillFEB1
            // 
            this.lblSpillFEB1.AutoSize = true;
            this.lblSpillFEB1.Location = new System.Drawing.Point(426, 185);
            this.lblSpillFEB1.Name = "lblSpillFEB1";
            this.lblSpillFEB1.Size = new System.Drawing.Size(53, 20);
            this.lblSpillFEB1.TabIndex = 6;
            this.lblSpillFEB1.Text = "label2";
            // 
            // lblRunName
            // 
            this.lblRunName.AutoSize = true;
            this.lblRunName.Location = new System.Drawing.Point(426, 156);
            this.lblRunName.Name = "lblRunName";
            this.lblRunName.Size = new System.Drawing.Size(100, 20);
            this.lblRunName.TabIndex = 5;
            this.lblRunName.Text = "lblRunName";
            // 
            // btnStopRun
            // 
            this.btnStopRun.Location = new System.Drawing.Point(6, 302);
            this.btnStopRun.Name = "btnStopRun";
            this.btnStopRun.Size = new System.Drawing.Size(260, 100);
            this.btnStopRun.TabIndex = 4;
            this.btnStopRun.Tag = "";
            this.btnStopRun.Text = "STOP RUN";
            this.btnStopRun.UseVisualStyleBackColor = true;
            this.btnStopRun.Click += new System.EventHandler(this.btnStopRun_Click);
            // 
            // btnStartRun
            // 
            this.btnStartRun.Location = new System.Drawing.Point(6, 199);
            this.btnStartRun.Name = "btnStartRun";
            this.btnStartRun.Size = new System.Drawing.Size(260, 100);
            this.btnStartRun.TabIndex = 3;
            this.btnStartRun.Tag = "";
            this.btnStartRun.Text = "START RUN";
            this.btnStartRun.UseVisualStyleBackColor = true;
            this.btnStartRun.Click += new System.EventHandler(this.btnStartRun_Click);
            // 
            // btnPrepare
            // 
            this.btnPrepare.Location = new System.Drawing.Point(6, 89);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(260, 52);
            this.btnPrepare.TabIndex = 2;
            this.btnPrepare.Tag = "";
            this.btnPrepare.Text = "PREPARE FOR RUN";
            this.btnPrepare.UseVisualStyleBackColor = true;
            this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
            // 
            // btnConnectAll
            // 
            this.btnConnectAll.Location = new System.Drawing.Point(6, 34);
            this.btnConnectAll.Name = "btnConnectAll";
            this.btnConnectAll.Size = new System.Drawing.Size(260, 52);
            this.btnConnectAll.TabIndex = 1;
            this.btnConnectAll.Tag = "";
            this.btnConnectAll.Text = "CONNECT ALL";
            this.btnConnectAll.UseVisualStyleBackColor = true;
            this.btnConnectAll.Click += new System.EventHandler(this.btnConnectAll_Click);
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(620, 8);
            this.zg1.Margin = new System.Windows.Forms.Padding(6);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(630, 342);
            this.zg1.TabIndex = 1;
            this.zg1.Load += new System.EventHandler(this.zg1_Load);
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.dbgWC);
            this.tabConsole.Controls.Add(this.dbgFEB2);
            this.tabConsole.Controls.Add(this.dbgFEB1);
            this.tabConsole.Controls.Add(this.groupBox3);
            this.tabConsole.Location = new System.Drawing.Point(4, 32);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Size = new System.Drawing.Size(1255, 665);
            this.tabConsole.TabIndex = 7;
            this.tabConsole.Text = "Debug Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // dbgWC
            // 
            this.dbgWC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbgWC.Location = new System.Drawing.Point(141, 3);
            this.dbgWC.Name = "dbgWC";
            this.dbgWC.Size = new System.Drawing.Size(63, 31);
            this.dbgWC.TabIndex = 8;
            this.dbgWC.Text = "WC";
            this.dbgWC.UseVisualStyleBackColor = true;
            this.dbgWC.Click += new System.EventHandler(this.dbgFEB_Click);
            // 
            // dbgFEB2
            // 
            this.dbgFEB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbgFEB2.Location = new System.Drawing.Point(72, 3);
            this.dbgFEB2.Name = "dbgFEB2";
            this.dbgFEB2.Size = new System.Drawing.Size(63, 31);
            this.dbgFEB2.TabIndex = 6;
            this.dbgFEB2.Text = "FEB2";
            this.dbgFEB2.UseVisualStyleBackColor = true;
            this.dbgFEB2.Click += new System.EventHandler(this.dbgFEB_Click);
            // 
            // dbgFEB1
            // 
            this.dbgFEB1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbgFEB1.Location = new System.Drawing.Point(3, 3);
            this.dbgFEB1.Name = "dbgFEB1";
            this.dbgFEB1.Size = new System.Drawing.Size(63, 31);
            this.dbgFEB1.TabIndex = 5;
            this.dbgFEB1.Text = "FEB1";
            this.dbgFEB1.UseVisualStyleBackColor = true;
            this.dbgFEB1.Click += new System.EventHandler(this.dbgFEB_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.btnDebugLogging);
            this.groupBox3.Controls.Add(this.lblConsole_disp);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(3, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1249, 626);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CONSOLE";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1066, 580);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "LOAD";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnDebugLogging
            // 
            this.btnDebugLogging.Location = new System.Drawing.Point(912, 580);
            this.btnDebugLogging.Name = "btnDebugLogging";
            this.btnDebugLogging.Size = new System.Drawing.Size(148, 25);
            this.btnDebugLogging.TabIndex = 2;
            this.btnDebugLogging.Text = "START LOG";
            this.btnDebugLogging.UseVisualStyleBackColor = true;
            this.btnDebugLogging.Click += new System.EventHandler(this.btnDebugLogging_Click);
            // 
            // lblConsole_disp
            // 
            this.lblConsole_disp.AutoSize = true;
            this.lblConsole_disp.BackColor = System.Drawing.SystemColors.Info;
            this.lblConsole_disp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsole_disp.Location = new System.Drawing.Point(0, 20);
            this.lblConsole_disp.Name = "lblConsole_disp";
            this.lblConsole_disp.Size = new System.Drawing.Size(151, 17);
            this.lblConsole_disp.TabIndex = 1;
            this.lblConsole_disp.Text = "console text goes here";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-3, 582);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(894, 24);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tabFEB1
            // 
            this.tabFEB1.Controls.Add(this.label27);
            this.tabFEB1.Controls.Add(this.textBox2);
            this.tabFEB1.Controls.Add(this.button8);
            this.tabFEB1.Controls.Add(this.button7);
            this.tabFEB1.Controls.Add(this.button6);
            this.tabFEB1.Controls.Add(this.label24);
            this.tabFEB1.Controls.Add(this.listBox1);
            this.tabFEB1.Controls.Add(this.checkBox9);
            this.tabFEB1.Controls.Add(this.checkBox10);
            this.tabFEB1.Controls.Add(this.btnScan);
            this.tabFEB1.Controls.Add(this.btnSaveHistos);
            this.tabFEB1.Controls.Add(this.checkBox11);
            this.tabFEB1.Controls.Add(this.checkBox12);
            this.tabFEB1.Controls.Add(this.checkBox13);
            this.tabFEB1.Controls.Add(this.checkBox14);
            this.tabFEB1.Controls.Add(this.checkBox15);
            this.tabFEB1.Controls.Add(this.checkBox16);
            this.tabFEB1.Controls.Add(this.checkBox5);
            this.tabFEB1.Controls.Add(this.checkBox6);
            this.tabFEB1.Controls.Add(this.checkBox7);
            this.tabFEB1.Controls.Add(this.checkBox8);
            this.tabFEB1.Controls.Add(this.checkBox3);
            this.tabFEB1.Controls.Add(this.checkBox4);
            this.tabFEB1.Controls.Add(this.checkBox2);
            this.tabFEB1.Controls.Add(this.checkBox1);
            this.tabFEB1.Controls.Add(this.label10);
            this.tabFEB1.Controls.Add(this.ShowSpect);
            this.tabFEB1.Controls.Add(this.ShowIV);
            this.tabFEB1.Controls.Add(this.button1);
            this.tabFEB1.Controls.Add(this.btnTestSpill);
            this.tabFEB1.Controls.Add(this.zedFEB1);
            this.tabFEB1.Controls.Add(this.groupBoxSpillStat);
            this.tabFEB1.Controls.Add(this.groupBoxREG1);
            this.tabFEB1.Controls.Add(this.panel2);
            this.tabFEB1.Controls.Add(this.panel1);
            this.tabFEB1.Controls.Add(this.groupBox7);
            this.tabFEB1.Controls.Add(this.groupBoxConn);
            this.tabFEB1.Location = new System.Drawing.Point(4, 32);
            this.tabFEB1.Name = "tabFEB1";
            this.tabFEB1.Size = new System.Drawing.Size(1255, 665);
            this.tabFEB1.TabIndex = 3;
            this.tabFEB1.Text = "FEB";
            this.tabFEB1.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(377, 33);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 20);
            this.label27.TabIndex = 88;
            this.label27.Text = "Bias";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(379, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 27);
            this.textBox2.TabIndex = 63;
            this.textBox2.Text = "56.1";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(379, 89);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 27);
            this.button8.TabIndex = 87;
            this.button8.Text = "Set All";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(485, 311);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(139, 39);
            this.button7.TabIndex = 86;
            this.button7.Text = "Select J19-J26";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(485, 266);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(139, 39);
            this.button6.TabIndex = 85;
            this.button6.Text = "Select J11-J18";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(374, 364);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(140, 20);
            this.label24.TabIndex = 84;
            this.label24.Text = "Histogram to Plot";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(378, 387);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(154, 64);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 83;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(549, 26);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(58, 24);
            this.checkBox9.TabIndex = 82;
            this.checkBox9.Text = "J19";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(549, 56);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(58, 24);
            this.checkBox10.TabIndex = 81;
            this.checkBox10.Text = "J20";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(538, 367);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(101, 39);
            this.btnScan.TabIndex = 54;
            this.btnScan.Text = "SCAN";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnSaveHistos
            // 
            this.btnSaveHistos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveHistos.Location = new System.Drawing.Point(538, 412);
            this.btnSaveHistos.Name = "btnSaveHistos";
            this.btnSaveHistos.Size = new System.Drawing.Size(101, 39);
            this.btnSaveHistos.TabIndex = 55;
            this.btnSaveHistos.Text = "SAVE";
            this.btnSaveHistos.UseVisualStyleBackColor = true;
            this.btnSaveHistos.Click += new System.EventHandler(this.btnSaveHistos_Click);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(549, 86);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(58, 24);
            this.checkBox11.TabIndex = 80;
            this.checkBox11.Text = "J21";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(549, 116);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(58, 24);
            this.checkBox12.TabIndex = 79;
            this.checkBox12.Text = "J22";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(549, 146);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(58, 24);
            this.checkBox13.TabIndex = 78;
            this.checkBox13.Text = "J23";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(549, 176);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(58, 24);
            this.checkBox14.TabIndex = 77;
            this.checkBox14.Text = "J24";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(549, 206);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(58, 24);
            this.checkBox15.TabIndex = 76;
            this.checkBox15.Text = "J25";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(549, 236);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(58, 24);
            this.checkBox16.TabIndex = 75;
            this.checkBox16.Text = "J26";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(485, 146);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(58, 24);
            this.checkBox5.TabIndex = 74;
            this.checkBox5.Text = "J15";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(485, 176);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(58, 24);
            this.checkBox6.TabIndex = 73;
            this.checkBox6.Text = "J16";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(485, 206);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(58, 24);
            this.checkBox7.TabIndex = 72;
            this.checkBox7.Text = "J17";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(485, 236);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(58, 24);
            this.checkBox8.TabIndex = 71;
            this.checkBox8.Text = "J18";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(485, 86);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(58, 24);
            this.checkBox3.TabIndex = 70;
            this.checkBox3.Text = "J13";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(485, 116);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(58, 24);
            this.checkBox4.TabIndex = 69;
            this.checkBox4.Text = "J14";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(485, 56);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(58, 24);
            this.checkBox2.TabIndex = 68;
            this.checkBox2.Text = "J12";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(485, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 24);
            this.checkBox1.TabIndex = 67;
            this.checkBox1.Text = "J11";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(481, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 20);
            this.label10.TabIndex = 66;
            this.label10.Text = "CMB CONNECTED";
            // 
            // ShowSpect
            // 
            this.ShowSpect.Location = new System.Drawing.Point(796, 522);
            this.ShowSpect.Name = "ShowSpect";
            this.ShowSpect.Size = new System.Drawing.Size(112, 42);
            this.ShowSpect.TabIndex = 64;
            this.ShowSpect.Tag = "";
            this.ShowSpect.Text = "PH Histo";
            this.ShowSpect.UseVisualStyleBackColor = true;
            this.ShowSpect.Visible = false;
            this.ShowSpect.Click += new System.EventHandler(this.ShowSpect_Click);
            // 
            // ShowIV
            // 
            this.ShowIV.Location = new System.Drawing.Point(678, 522);
            this.ShowIV.Name = "ShowIV";
            this.ShowIV.Size = new System.Drawing.Size(112, 42);
            this.ShowIV.TabIndex = 63;
            this.ShowIV.Tag = "";
            this.ShowIV.Text = "IV";
            this.ShowIV.UseVisualStyleBackColor = true;
            this.ShowIV.Click += new System.EventHandler(this.ShowIV_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 42);
            this.button1.TabIndex = 62;
            this.button1.Tag = "";
            this.button1.Text = "READ RDB";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnTestSpill
            // 
            this.btnTestSpill.Location = new System.Drawing.Point(379, 521);
            this.btnTestSpill.Name = "btnTestSpill";
            this.btnTestSpill.Size = new System.Drawing.Size(255, 42);
            this.btnTestSpill.TabIndex = 61;
            this.btnTestSpill.Tag = "";
            this.btnTestSpill.Text = "TEST SPILL";
            this.btnTestSpill.UseVisualStyleBackColor = true;
            this.btnTestSpill.Click += new System.EventHandler(this.btnTestSpill_Click);
            // 
            // zedFEB1
            // 
            this.zedFEB1.Location = new System.Drawing.Point(653, 3);
            this.zedFEB1.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.zedFEB1.Name = "zedFEB1";
            this.zedFEB1.ScrollGrace = 0D;
            this.zedFEB1.ScrollMaxX = 0D;
            this.zedFEB1.ScrollMaxY = 0D;
            this.zedFEB1.ScrollMaxY2 = 0D;
            this.zedFEB1.ScrollMinX = 0D;
            this.zedFEB1.ScrollMinY = 0D;
            this.zedFEB1.ScrollMinY2 = 0D;
            this.zedFEB1.Size = new System.Drawing.Size(602, 448);
            this.zedFEB1.TabIndex = 60;
            // 
            // groupBoxSpillStat
            // 
            this.groupBoxSpillStat.Controls.Add(this.label11);
            this.groupBoxSpillStat.Controls.Add(this.btnSpillMON);
            this.groupBoxSpillStat.Controls.Add(this.btnSpillWRITE);
            this.groupBoxSpillStat.Controls.Add(this.label17);
            this.groupBoxSpillStat.Controls.Add(this.btnSpillREAD);
            this.groupBoxSpillStat.Controls.Add(this.label18);
            this.groupBoxSpillStat.Controls.Add(this.label19);
            this.groupBoxSpillStat.Controls.Add(this.label20);
            this.groupBoxSpillStat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBoxSpillStat.Location = new System.Drawing.Point(8, 513);
            this.groupBoxSpillStat.Name = "groupBoxSpillStat";
            this.groupBoxSpillStat.Size = new System.Drawing.Size(364, 44);
            this.groupBoxSpillStat.TabIndex = 10;
            this.groupBoxSpillStat.TabStop = false;
            this.groupBoxSpillStat.Text = "SPILL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "UPTIME";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Visible = false;
            // 
            // btnSpillMON
            // 
            this.btnSpillMON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpillMON.Location = new System.Drawing.Point(275, 182);
            this.btnSpillMON.Name = "btnSpillMON";
            this.btnSpillMON.Size = new System.Drawing.Size(83, 23);
            this.btnSpillMON.TabIndex = 15;
            this.btnSpillMON.Text = "MONITOR";
            this.btnSpillMON.UseVisualStyleBackColor = true;
            this.btnSpillMON.Visible = false;
            this.btnSpillMON.Click += new System.EventHandler(this.btnSpillMON_Click);
            // 
            // btnSpillWRITE
            // 
            this.btnSpillWRITE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpillWRITE.Location = new System.Drawing.Point(194, 182);
            this.btnSpillWRITE.Name = "btnSpillWRITE";
            this.btnSpillWRITE.Size = new System.Drawing.Size(75, 23);
            this.btnSpillWRITE.TabIndex = 14;
            this.btnSpillWRITE.Text = "WRITE";
            this.btnSpillWRITE.UseVisualStyleBackColor = true;
            this.btnSpillWRITE.Click += new System.EventHandler(this.btnSpillWRITE_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 20);
            this.label17.TabIndex = 3;
            this.label17.Text = "SPILL STAT";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label17.Visible = false;
            // 
            // btnSpillREAD
            // 
            this.btnSpillREAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpillREAD.Location = new System.Drawing.Point(113, 182);
            this.btnSpillREAD.Name = "btnSpillREAD";
            this.btnSpillREAD.Size = new System.Drawing.Size(75, 23);
            this.btnSpillREAD.TabIndex = 13;
            this.btnSpillREAD.Text = "READ";
            this.btnSpillREAD.UseVisualStyleBackColor = true;
            this.btnSpillREAD.Click += new System.EventHandler(this.btnSpillREAD_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "TRIG COUNT";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label18.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(-1, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "WORD COUNT";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "SPILL COUNT";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Visible = false;
            // 
            // groupBoxREG1
            // 
            this.groupBoxREG1.Controls.Add(this.lblFPGA);
            this.groupBoxREG1.Controls.Add(this.btnCHANGE);
            this.groupBoxREG1.Controls.Add(this.udFPGA);
            this.groupBoxREG1.Controls.Add(this.btnRegMON);
            this.groupBoxREG1.Controls.Add(this.btnRegWRITE);
            this.groupBoxREG1.Controls.Add(this.btnRegREAD);
            this.groupBoxREG1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBoxREG1.Location = new System.Drawing.Point(0, 99);
            this.groupBoxREG1.Name = "groupBoxREG1";
            this.groupBoxREG1.Size = new System.Drawing.Size(368, 408);
            this.groupBoxREG1.TabIndex = 6;
            this.groupBoxREG1.TabStop = false;
            this.groupBoxREG1.Text = "REGISTERS";
            this.groupBoxREG1.Enter += new System.EventHandler(this.groupBoxREG1_Enter);
            // 
            // lblFPGA
            // 
            this.lblFPGA.AutoSize = true;
            this.lblFPGA.Location = new System.Drawing.Point(4, 380);
            this.lblFPGA.Name = "lblFPGA";
            this.lblFPGA.Size = new System.Drawing.Size(54, 20);
            this.lblFPGA.TabIndex = 63;
            this.lblFPGA.Text = "FPGA";
            // 
            // btnCHANGE
            // 
            this.btnCHANGE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCHANGE.Location = new System.Drawing.Point(279, 379);
            this.btnCHANGE.Name = "btnCHANGE";
            this.btnCHANGE.Size = new System.Drawing.Size(83, 23);
            this.btnCHANGE.TabIndex = 14;
            this.btnCHANGE.Tag = "0";
            this.btnCHANGE.Text = "CHANGE";
            this.btnCHANGE.UseVisualStyleBackColor = true;
            this.btnCHANGE.Click += new System.EventHandler(this.btnCHANGE_Click);
            // 
            // udFPGA
            // 
            this.udFPGA.Location = new System.Drawing.Point(61, 379);
            this.udFPGA.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.udFPGA.Name = "udFPGA";
            this.udFPGA.Size = new System.Drawing.Size(46, 27);
            this.udFPGA.TabIndex = 13;
            this.udFPGA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udFPGA.ValueChanged += new System.EventHandler(this.udFPGA_ValueChanged);
            // 
            // btnRegMON
            // 
            this.btnRegMON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegMON.Location = new System.Drawing.Point(279, 350);
            this.btnRegMON.Name = "btnRegMON";
            this.btnRegMON.Size = new System.Drawing.Size(83, 23);
            this.btnRegMON.TabIndex = 12;
            this.btnRegMON.Text = "MONITOR";
            this.btnRegMON.UseVisualStyleBackColor = true;
            this.btnRegMON.Visible = false;
            this.btnRegMON.Click += new System.EventHandler(this.btnRegMONITOR_Click);
            // 
            // btnRegWRITE
            // 
            this.btnRegWRITE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegWRITE.Location = new System.Drawing.Point(198, 380);
            this.btnRegWRITE.Name = "btnRegWRITE";
            this.btnRegWRITE.Size = new System.Drawing.Size(75, 23);
            this.btnRegWRITE.TabIndex = 11;
            this.btnRegWRITE.Text = "WRITE";
            this.btnRegWRITE.UseVisualStyleBackColor = true;
            this.btnRegWRITE.Click += new System.EventHandler(this.btnRegWRITE_Click);
            // 
            // btnRegREAD
            // 
            this.btnRegREAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegREAD.Location = new System.Drawing.Point(117, 380);
            this.btnRegREAD.Name = "btnRegREAD";
            this.btnRegREAD.Size = new System.Drawing.Size(75, 23);
            this.btnRegREAD.TabIndex = 10;
            this.btnRegREAD.Text = "READ";
            this.btnRegREAD.UseVisualStyleBackColor = true;
            this.btnRegREAD.Click += new System.EventHandler(this.btnRegREAD_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.udInterval);
            this.panel2.Controls.Add(this.btnErase);
            this.panel2.Controls.Add(this.lblInc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.udChan);
            this.panel2.Controls.Add(this.lblStop);
            this.panel2.Controls.Add(this.udStop);
            this.panel2.Controls.Add(this.lblStart);
            this.panel2.Controls.Add(this.udStart);
            this.panel2.Location = new System.Drawing.Point(970, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 148);
            this.panel2.TabIndex = 59;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // udInterval
            // 
            this.udInterval.Location = new System.Drawing.Point(118, 110);
            this.udInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udInterval.Name = "udInterval";
            this.udInterval.Size = new System.Drawing.Size(57, 27);
            this.udInterval.TabIndex = 52;
            this.udInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udInterval.ValueChanged += new System.EventHandler(this.udInterval_ValueChanged);
            // 
            // btnErase
            // 
            this.btnErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErase.Location = new System.Drawing.Point(181, 74);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(95, 33);
            this.btnErase.TabIndex = 58;
            this.btnErase.Text = "ERASE";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // lblInc
            // 
            this.lblInc.AutoSize = true;
            this.lblInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInc.Location = new System.Drawing.Point(3, 112);
            this.lblInc.Name = "lblInc";
            this.lblInc.Size = new System.Drawing.Size(86, 20);
            this.lblInc.TabIndex = 53;
            this.lblInc.Text = "Time (ms)";
            this.lblInc.Click += new System.EventHandler(this.lblInc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Chan";
            // 
            // udChan
            // 
            this.udChan.Location = new System.Drawing.Point(119, 76);
            this.udChan.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.udChan.Name = "udChan";
            this.udChan.Size = new System.Drawing.Size(57, 27);
            this.udChan.TabIndex = 56;
            this.udChan.ValueChanged += new System.EventHandler(this.udChan_ValueChanged);
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(5, 44);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(43, 20);
            this.lblStop.TabIndex = 51;
            this.lblStop.Text = "Stop";
            // 
            // udStop
            // 
            this.udStop.Location = new System.Drawing.Point(119, 42);
            this.udStop.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.udStop.Name = "udStop";
            this.udStop.Size = new System.Drawing.Size(57, 27);
            this.udStop.TabIndex = 50;
            this.udStop.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(5, 14);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(45, 20);
            this.lblStart.TabIndex = 49;
            this.lblStart.Text = "Start";
            // 
            // udStart
            // 
            this.udStart.Location = new System.Drawing.Point(119, 9);
            this.udStart.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.udStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udStart.Name = "udStart";
            this.udStart.Size = new System.Drawing.Size(56, 27);
            this.udStart.TabIndex = 48;
            this.udStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udStart.ValueChanged += new System.EventHandler(this.udStart_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkIntegral);
            this.panel1.Controls.Add(this.chkLogY);
            this.panel1.Location = new System.Drawing.Point(653, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 61);
            this.panel1.TabIndex = 58;
            // 
            // chkIntegral
            // 
            this.chkIntegral.AutoSize = true;
            this.chkIntegral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIntegral.Location = new System.Drawing.Point(3, 36);
            this.chkIntegral.Name = "chkIntegral";
            this.chkIntegral.Size = new System.Drawing.Size(148, 24);
            this.chkIntegral.TabIndex = 57;
            this.chkIntegral.Text = "Integral Spect";
            this.chkIntegral.UseVisualStyleBackColor = true;
            this.chkIntegral.CheckedChanged += new System.EventHandler(this.chkIntegral_CheckedChanged);
            // 
            // chkLogY
            // 
            this.chkLogY.AutoSize = true;
            this.chkLogY.Checked = true;
            this.chkLogY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLogY.Location = new System.Drawing.Point(3, 4);
            this.chkLogY.Name = "chkLogY";
            this.chkLogY.Size = new System.Drawing.Size(73, 24);
            this.chkLogY.TabIndex = 55;
            this.chkLogY.Text = "LogY";
            this.chkLogY.UseVisualStyleBackColor = true;
            this.chkLogY.CheckedChanged += new System.EventHandler(this.chkLogY_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtI);
            this.groupBox7.Controls.Add(this.txtV);
            this.groupBox7.Controls.Add(this.btnBiasREAD);
            this.groupBox7.Controls.Add(this.btnBiasWRITE);
            this.groupBox7.Controls.Add(this.btnBIAS_MON);
            this.groupBox7.Controls.Add(this.lblI);
            this.groupBox7.Controls.Add(this.lblV);
            this.groupBox7.Location = new System.Drawing.Point(8, 563);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(365, 87);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "BIAS";
            // 
            // txtI
            // 
            this.txtI.Enabled = false;
            this.txtI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtI.Location = new System.Drawing.Point(50, 56);
            this.txtI.Name = "txtI";
            this.txtI.Size = new System.Drawing.Size(55, 24);
            this.txtI.TabIndex = 62;
            this.txtI.Text = "0.000";
            this.txtI.TextChanged += new System.EventHandler(this.txtI_TextChanged);
            // 
            // txtV
            // 
            this.txtV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtV.Location = new System.Drawing.Point(50, 29);
            this.txtV.Name = "txtV";
            this.txtV.Size = new System.Drawing.Size(55, 24);
            this.txtV.TabIndex = 61;
            this.txtV.Text = "0.000";
            this.txtV.TextChanged += new System.EventHandler(this.txtV_TextChanged);
            // 
            // btnBiasREAD
            // 
            this.btnBiasREAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBiasREAD.Location = new System.Drawing.Point(114, 29);
            this.btnBiasREAD.Name = "btnBiasREAD";
            this.btnBiasREAD.Size = new System.Drawing.Size(75, 23);
            this.btnBiasREAD.TabIndex = 16;
            this.btnBiasREAD.Text = "READ";
            this.btnBiasREAD.UseVisualStyleBackColor = true;
            this.btnBiasREAD.Click += new System.EventHandler(this.btnBiasREAD_Click);
            // 
            // btnBiasWRITE
            // 
            this.btnBiasWRITE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBiasWRITE.Location = new System.Drawing.Point(195, 29);
            this.btnBiasWRITE.Name = "btnBiasWRITE";
            this.btnBiasWRITE.Size = new System.Drawing.Size(75, 23);
            this.btnBiasWRITE.TabIndex = 16;
            this.btnBiasWRITE.Text = "WRITE";
            this.btnBiasWRITE.UseVisualStyleBackColor = true;
            this.btnBiasWRITE.Click += new System.EventHandler(this.btnBiasWRITE_Click);
            // 
            // btnBIAS_MON
            // 
            this.btnBIAS_MON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBIAS_MON.Location = new System.Drawing.Point(276, 29);
            this.btnBIAS_MON.Name = "btnBIAS_MON";
            this.btnBIAS_MON.Size = new System.Drawing.Size(83, 23);
            this.btnBIAS_MON.TabIndex = 60;
            this.btnBIAS_MON.Text = "MONITOR";
            this.btnBIAS_MON.UseVisualStyleBackColor = true;
            this.btnBIAS_MON.Visible = false;
            this.btnBIAS_MON.Click += new System.EventHandler(this.btnBIAS_MON_Click);
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Location = new System.Drawing.Point(7, 58);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(23, 20);
            this.lblI.TabIndex = 5;
            this.lblI.Text = "I=";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Location = new System.Drawing.Point(7, 29);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(30, 20);
            this.lblV.TabIndex = 4;
            this.lblV.Text = "V=";
            // 
            // groupBoxConn
            // 
            this.groupBoxConn.Controls.Add(this.button2);
            this.groupBoxConn.Controls.Add(this.lblActive);
            this.groupBoxConn.Controls.Add(this.btnFEB2);
            this.groupBoxConn.Controls.Add(this.btnFEB1);
            this.groupBoxConn.Location = new System.Drawing.Point(3, 3);
            this.groupBoxConn.Name = "groupBoxConn";
            this.groupBoxConn.Size = new System.Drawing.Size(368, 90);
            this.groupBoxConn.TabIndex = 4;
            this.groupBoxConn.TabStop = false;
            this.groupBoxConn.Text = "CONNECTION";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(254, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 24);
            this.button2.TabIndex = 64;
            this.button2.Tag = "";
            this.button2.Text = "DISCONNECT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(210, 23);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(95, 20);
            this.lblActive.TabIndex = 63;
            this.lblActive.Text = "Display for:";
            // 
            // btnFEB2
            // 
            this.btnFEB2.Location = new System.Drawing.Point(105, 23);
            this.btnFEB2.Name = "btnFEB2";
            this.btnFEB2.Size = new System.Drawing.Size(99, 42);
            this.btnFEB2.TabIndex = 3;
            this.btnFEB2.Tag = "FEB2";
            this.btnFEB2.Text = "unkown";
            this.btnFEB2.UseVisualStyleBackColor = true;
            // 
            // btnFEB1
            // 
            this.btnFEB1.Location = new System.Drawing.Point(0, 23);
            this.btnFEB1.Name = "btnFEB1";
            this.btnFEB1.Size = new System.Drawing.Size(99, 42);
            this.btnFEB1.TabIndex = 0;
            this.btnFEB1.Tag = "FEB1";
            this.btnFEB1.Text = "unkown";
            this.btnFEB1.UseVisualStyleBackColor = true;
            this.btnFEB1.Click += new System.EventHandler(this.btnFEB1_Click);
            // 
            // tabWC
            // 
            this.tabWC.Controls.Add(this.groupBox6);
            this.tabWC.Location = new System.Drawing.Point(4, 32);
            this.tabWC.Name = "tabWC";
            this.tabWC.Size = new System.Drawing.Size(1255, 665);
            this.tabWC.TabIndex = 6;
            this.tabWC.Text = "WC";
            this.tabWC.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblWCmessage);
            this.groupBox6.Controls.Add(this.btnWC);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(611, 130);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "CONNECTIONS";
            // 
            // lblWCmessage
            // 
            this.lblWCmessage.AutoSize = true;
            this.lblWCmessage.Location = new System.Drawing.Point(-1, 87);
            this.lblWCmessage.Name = "lblWCmessage";
            this.lblWCmessage.Size = new System.Drawing.Size(53, 40);
            this.lblWCmessage.TabIndex = 2;
            this.lblWCmessage.Text = "label1\r\nlabel2";
            // 
            // btnWC
            // 
            this.btnWC.Location = new System.Drawing.Point(0, 23);
            this.btnWC.Name = "btnWC";
            this.btnWC.Size = new System.Drawing.Size(99, 42);
            this.btnWC.TabIndex = 0;
            this.btnWC.Tag = "";
            this.btnWC.Text = "WC";
            this.btnWC.UseVisualStyleBackColor = true;
            // 
            // tabFEBtest
            // 
            this.tabFEBtest.Controls.Add(this.button5);
            this.tabFEBtest.Controls.Add(this.label9);
            this.tabFEBtest.Controls.Add(this.btnConnectScope);
            this.tabFEBtest.Controls.Add(this.btnSnSave);
            this.tabFEBtest.Controls.Add(this.txtSN);
            this.tabFEBtest.Controls.Add(this.label26);
            this.tabFEBtest.Controls.Add(this.DAC_Voltages);
            this.tabFEBtest.Location = new System.Drawing.Point(4, 32);
            this.tabFEBtest.Name = "tabFEBtest";
            this.tabFEBtest.Padding = new System.Windows.Forms.Padding(3);
            this.tabFEBtest.Size = new System.Drawing.Size(1255, 665);
            this.tabFEBtest.TabIndex = 8;
            this.tabFEBtest.Text = "Calibration";
            this.tabFEBtest.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(107, 472);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(219, 35);
            this.button5.TabIndex = 67;
            this.button5.Text = "UPDATE TEMPERATURE";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 66;
            this.label9.Text = "label9";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnConnectScope
            // 
            this.btnConnectScope.Location = new System.Drawing.Point(359, 43);
            this.btnConnectScope.Name = "btnConnectScope";
            this.btnConnectScope.Size = new System.Drawing.Size(183, 37);
            this.btnConnectScope.TabIndex = 9;
            this.btnConnectScope.Text = "CONNECT SCOPE";
            this.btnConnectScope.UseVisualStyleBackColor = true;
            this.btnConnectScope.Click += new System.EventHandler(this.btnConnectScope_Click);
            // 
            // btnSnSave
            // 
            this.btnSnSave.Location = new System.Drawing.Point(431, 6);
            this.btnSnSave.Name = "btnSnSave";
            this.btnSnSave.Size = new System.Drawing.Size(111, 31);
            this.btnSnSave.TabIndex = 8;
            this.btnSnSave.Text = "SAVE";
            this.btnSnSave.UseVisualStyleBackColor = true;
            this.btnSnSave.Click += new System.EventHandler(this.btnSnSave_Click);
            // 
            // txtSN
            // 
            this.txtSN.Location = new System.Drawing.Point(210, 8);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(215, 27);
            this.txtSN.TabIndex = 5;
            this.txtSN.TextChanged += new System.EventHandler(this.txtSN_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label26.Location = new System.Drawing.Point(92, 6);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(112, 31);
            this.label26.TabIndex = 4;
            this.label26.Text = "FEB SN";
            // 
            // DAC_Voltages
            // 
            this.DAC_Voltages.Controls.Add(this.btnZeroVoltages);
            this.DAC_Voltages.Controls.Add(this.txtMuxI3);
            this.DAC_Voltages.Controls.Add(this.txtMuxI2);
            this.DAC_Voltages.Controls.Add(this.txtMuxI1);
            this.DAC_Voltages.Controls.Add(this.txtMuxI0);
            this.DAC_Voltages.Controls.Add(this.label36);
            this.DAC_Voltages.Controls.Add(this.btnLoadCalib);
            this.DAC_Voltages.Controls.Add(this.txtTrim3Int);
            this.DAC_Voltages.Controls.Add(this.txtTrim3Slope);
            this.DAC_Voltages.Controls.Add(this.txtTrim2Int);
            this.DAC_Voltages.Controls.Add(this.txtTrim2Slope);
            this.DAC_Voltages.Controls.Add(this.txtTrim1Int);
            this.DAC_Voltages.Controls.Add(this.txtTrim1Slope);
            this.DAC_Voltages.Controls.Add(this.txtTrim0Int);
            this.DAC_Voltages.Controls.Add(this.txtTrim0Slope);
            this.DAC_Voltages.Controls.Add(this.txtBiasInt);
            this.DAC_Voltages.Controls.Add(this.txtBiasSlope);
            this.DAC_Voltages.Controls.Add(this.label29);
            this.DAC_Voltages.Controls.Add(this.label28);
            this.DAC_Voltages.Controls.Add(this.label25);
            this.DAC_Voltages.Controls.Add(this.txtCalibComments);
            this.DAC_Voltages.Controls.Add(this.btnDacSave);
            this.DAC_Voltages.Controls.Add(this.btnJ26);
            this.DAC_Voltages.Controls.Add(this.btnDacScan);
            this.DAC_Voltages.Controls.Add(this.btnJ25);
            this.DAC_Voltages.Controls.Add(this.btnJ24);
            this.DAC_Voltages.Controls.Add(this.btnDacWrite);
            this.DAC_Voltages.Controls.Add(this.btnJ23);
            this.DAC_Voltages.Controls.Add(this.btnJ22);
            this.DAC_Voltages.Controls.Add(this.btnJ21);
            this.DAC_Voltages.Controls.Add(this.txtTrimRB3);
            this.DAC_Voltages.Controls.Add(this.btnJ20);
            this.DAC_Voltages.Controls.Add(this.txtTrimRB2);
            this.DAC_Voltages.Controls.Add(this.btnJ19);
            this.DAC_Voltages.Controls.Add(this.txtTrimRB1);
            this.DAC_Voltages.Controls.Add(this.btnJ18);
            this.DAC_Voltages.Controls.Add(this.txtTrimRB0);
            this.DAC_Voltages.Controls.Add(this.btnJ17);
            this.DAC_Voltages.Controls.Add(this.txtLEDRB0);
            this.DAC_Voltages.Controls.Add(this.btnJ16);
            this.DAC_Voltages.Controls.Add(this.txtBiasRB0);
            this.DAC_Voltages.Controls.Add(this.btnJ15);
            this.DAC_Voltages.Controls.Add(this.btnJ14);
            this.DAC_Voltages.Controls.Add(this.label23);
            this.DAC_Voltages.Controls.Add(this.btnJ13);
            this.DAC_Voltages.Controls.Add(this.label22);
            this.DAC_Voltages.Controls.Add(this.btnJ12);
            this.DAC_Voltages.Controls.Add(this.label21);
            this.DAC_Voltages.Controls.Add(this.btnJ11);
            this.DAC_Voltages.Controls.Add(this.label16);
            this.DAC_Voltages.Controls.Add(this.label15);
            this.DAC_Voltages.Controls.Add(this.label14);
            this.DAC_Voltages.Controls.Add(this.txtTrimSet3);
            this.DAC_Voltages.Controls.Add(this.txtTrimSet2);
            this.DAC_Voltages.Controls.Add(this.txtTrimSet1);
            this.DAC_Voltages.Controls.Add(this.txtTrimSet0);
            this.DAC_Voltages.Controls.Add(this.txtLEDSet0);
            this.DAC_Voltages.Controls.Add(this.label13);
            this.DAC_Voltages.Controls.Add(this.label12);
            this.DAC_Voltages.Controls.Add(this.txtBiasSet0);
            this.DAC_Voltages.Location = new System.Drawing.Point(557, 6);
            this.DAC_Voltages.Name = "DAC_Voltages";
            this.DAC_Voltages.Size = new System.Drawing.Size(692, 606);
            this.DAC_Voltages.TabIndex = 0;
            this.DAC_Voltages.TabStop = false;
            this.DAC_Voltages.Text = "DAC Voltages";
            // 
            // btnZeroVoltages
            // 
            this.btnZeroVoltages.Location = new System.Drawing.Point(299, 244);
            this.btnZeroVoltages.Name = "btnZeroVoltages";
            this.btnZeroVoltages.Size = new System.Drawing.Size(93, 29);
            this.btnZeroVoltages.TabIndex = 99;
            this.btnZeroVoltages.Text = "Zero All";
            this.btnZeroVoltages.UseVisualStyleBackColor = true;
            this.btnZeroVoltages.Click += new System.EventHandler(this.btnZeroVoltages_Click);
            // 
            // txtMuxI3
            // 
            this.txtMuxI3.Location = new System.Drawing.Point(583, 211);
            this.txtMuxI3.Name = "txtMuxI3";
            this.txtMuxI3.Size = new System.Drawing.Size(76, 27);
            this.txtMuxI3.TabIndex = 98;
            // 
            // txtMuxI2
            // 
            this.txtMuxI2.Location = new System.Drawing.Point(583, 178);
            this.txtMuxI2.Name = "txtMuxI2";
            this.txtMuxI2.Size = new System.Drawing.Size(76, 27);
            this.txtMuxI2.TabIndex = 97;
            // 
            // txtMuxI1
            // 
            this.txtMuxI1.Location = new System.Drawing.Point(583, 145);
            this.txtMuxI1.Name = "txtMuxI1";
            this.txtMuxI1.Size = new System.Drawing.Size(76, 27);
            this.txtMuxI1.TabIndex = 96;
            // 
            // txtMuxI0
            // 
            this.txtMuxI0.Location = new System.Drawing.Point(583, 112);
            this.txtMuxI0.Name = "txtMuxI0";
            this.txtMuxI0.Size = new System.Drawing.Size(76, 27);
            this.txtMuxI0.TabIndex = 95;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(579, 23);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(101, 20);
            this.label36.TabIndex = 94;
            this.label36.Text = "Mux Current";
            // 
            // btnLoadCalib
            // 
            this.btnLoadCalib.Location = new System.Drawing.Point(364, 458);
            this.btnLoadCalib.Name = "btnLoadCalib";
            this.btnLoadCalib.Size = new System.Drawing.Size(195, 43);
            this.btnLoadCalib.TabIndex = 93;
            this.btnLoadCalib.Text = "LOAD CALIBRATIONS";
            this.btnLoadCalib.UseVisualStyleBackColor = true;
            this.btnLoadCalib.Click += new System.EventHandler(this.btnLoadCalib_Click);
            // 
            // txtTrim3Int
            // 
            this.txtTrim3Int.Location = new System.Drawing.Point(483, 211);
            this.txtTrim3Int.Name = "txtTrim3Int";
            this.txtTrim3Int.Size = new System.Drawing.Size(76, 27);
            this.txtTrim3Int.TabIndex = 92;
            // 
            // txtTrim3Slope
            // 
            this.txtTrim3Slope.Location = new System.Drawing.Point(401, 211);
            this.txtTrim3Slope.Name = "txtTrim3Slope";
            this.txtTrim3Slope.Size = new System.Drawing.Size(76, 27);
            this.txtTrim3Slope.TabIndex = 91;
            // 
            // txtTrim2Int
            // 
            this.txtTrim2Int.Location = new System.Drawing.Point(483, 178);
            this.txtTrim2Int.Name = "txtTrim2Int";
            this.txtTrim2Int.Size = new System.Drawing.Size(76, 27);
            this.txtTrim2Int.TabIndex = 90;
            // 
            // txtTrim2Slope
            // 
            this.txtTrim2Slope.Location = new System.Drawing.Point(401, 178);
            this.txtTrim2Slope.Name = "txtTrim2Slope";
            this.txtTrim2Slope.Size = new System.Drawing.Size(76, 27);
            this.txtTrim2Slope.TabIndex = 89;
            // 
            // txtTrim1Int
            // 
            this.txtTrim1Int.Location = new System.Drawing.Point(483, 145);
            this.txtTrim1Int.Name = "txtTrim1Int";
            this.txtTrim1Int.Size = new System.Drawing.Size(76, 27);
            this.txtTrim1Int.TabIndex = 88;
            // 
            // txtTrim1Slope
            // 
            this.txtTrim1Slope.Location = new System.Drawing.Point(401, 145);
            this.txtTrim1Slope.Name = "txtTrim1Slope";
            this.txtTrim1Slope.Size = new System.Drawing.Size(76, 27);
            this.txtTrim1Slope.TabIndex = 87;
            // 
            // txtTrim0Int
            // 
            this.txtTrim0Int.Location = new System.Drawing.Point(483, 112);
            this.txtTrim0Int.Name = "txtTrim0Int";
            this.txtTrim0Int.Size = new System.Drawing.Size(76, 27);
            this.txtTrim0Int.TabIndex = 86;
            // 
            // txtTrim0Slope
            // 
            this.txtTrim0Slope.Location = new System.Drawing.Point(401, 112);
            this.txtTrim0Slope.Name = "txtTrim0Slope";
            this.txtTrim0Slope.Size = new System.Drawing.Size(76, 27);
            this.txtTrim0Slope.TabIndex = 85;
            // 
            // txtBiasInt
            // 
            this.txtBiasInt.Location = new System.Drawing.Point(483, 46);
            this.txtBiasInt.Name = "txtBiasInt";
            this.txtBiasInt.Size = new System.Drawing.Size(76, 27);
            this.txtBiasInt.TabIndex = 84;
            // 
            // txtBiasSlope
            // 
            this.txtBiasSlope.Location = new System.Drawing.Point(401, 46);
            this.txtBiasSlope.Name = "txtBiasSlope";
            this.txtBiasSlope.Size = new System.Drawing.Size(76, 27);
            this.txtBiasSlope.TabIndex = 83;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(479, 23);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(74, 20);
            this.label29.TabIndex = 82;
            this.label29.Text = "Intercept";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(397, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(51, 20);
            this.label28.TabIndex = 81;
            this.label28.Text = "Slope";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(137, 291);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(90, 20);
            this.label25.TabIndex = 80;
            this.label25.Text = "Comments";
            // 
            // txtCalibComments
            // 
            this.txtCalibComments.Location = new System.Drawing.Point(141, 314);
            this.txtCalibComments.Multiline = true;
            this.txtCalibComments.Name = "txtCalibComments";
            this.txtCalibComments.Size = new System.Drawing.Size(418, 138);
            this.txtCalibComments.TabIndex = 79;
            // 
            // btnDacSave
            // 
            this.btnDacSave.Location = new System.Drawing.Point(141, 458);
            this.btnDacSave.Name = "btnDacSave";
            this.btnDacSave.Size = new System.Drawing.Size(148, 43);
            this.btnDacSave.TabIndex = 78;
            this.btnDacSave.Text = "SAVE";
            this.btnDacSave.UseVisualStyleBackColor = true;
            this.btnDacSave.Click += new System.EventHandler(this.btnDacSave_Click);
            // 
            // btnJ26
            // 
            this.btnJ26.BackColor = System.Drawing.Color.Silver;
            this.btnJ26.Location = new System.Drawing.Point(6, 566);
            this.btnJ26.Name = "btnJ26";
            this.btnJ26.Size = new System.Drawing.Size(75, 30);
            this.btnJ26.TabIndex = 15;
            this.btnJ26.Text = "J26";
            this.btnJ26.UseVisualStyleBackColor = false;
            this.btnJ26.Click += new System.EventHandler(this.btnJ26_Click);
            // 
            // btnDacScan
            // 
            this.btnDacScan.Location = new System.Drawing.Point(460, 244);
            this.btnDacScan.Name = "btnDacScan";
            this.btnDacScan.Size = new System.Drawing.Size(93, 29);
            this.btnDacScan.TabIndex = 77;
            this.btnDacScan.Text = "SCAN";
            this.btnDacScan.UseVisualStyleBackColor = true;
            this.btnDacScan.Click += new System.EventHandler(this.btnDacScan_Click);
            // 
            // btnJ25
            // 
            this.btnJ25.BackColor = System.Drawing.Color.Silver;
            this.btnJ25.Location = new System.Drawing.Point(6, 530);
            this.btnJ25.Name = "btnJ25";
            this.btnJ25.Size = new System.Drawing.Size(75, 30);
            this.btnJ25.TabIndex = 14;
            this.btnJ25.Text = "J25";
            this.btnJ25.UseVisualStyleBackColor = false;
            this.btnJ25.Click += new System.EventHandler(this.btnJ25_Click);
            // 
            // btnJ24
            // 
            this.btnJ24.BackColor = System.Drawing.Color.Silver;
            this.btnJ24.Location = new System.Drawing.Point(6, 494);
            this.btnJ24.Name = "btnJ24";
            this.btnJ24.Size = new System.Drawing.Size(75, 30);
            this.btnJ24.TabIndex = 13;
            this.btnJ24.Text = "J24";
            this.btnJ24.UseVisualStyleBackColor = false;
            this.btnJ24.Click += new System.EventHandler(this.btnJ24_Click);
            // 
            // btnDacWrite
            // 
            this.btnDacWrite.Location = new System.Drawing.Point(200, 244);
            this.btnDacWrite.Name = "btnDacWrite";
            this.btnDacWrite.Size = new System.Drawing.Size(93, 29);
            this.btnDacWrite.TabIndex = 69;
            this.btnDacWrite.Text = "SET";
            this.btnDacWrite.UseVisualStyleBackColor = true;
            this.btnDacWrite.Click += new System.EventHandler(this.btnDacWrite_Click);
            // 
            // btnJ23
            // 
            this.btnJ23.BackColor = System.Drawing.Color.Silver;
            this.btnJ23.Location = new System.Drawing.Point(6, 458);
            this.btnJ23.Name = "btnJ23";
            this.btnJ23.Size = new System.Drawing.Size(75, 30);
            this.btnJ23.TabIndex = 12;
            this.btnJ23.Text = "J23";
            this.btnJ23.UseVisualStyleBackColor = false;
            this.btnJ23.Click += new System.EventHandler(this.btnJ23_Click);
            // 
            // btnJ22
            // 
            this.btnJ22.BackColor = System.Drawing.Color.Silver;
            this.btnJ22.Location = new System.Drawing.Point(6, 422);
            this.btnJ22.Name = "btnJ22";
            this.btnJ22.Size = new System.Drawing.Size(75, 30);
            this.btnJ22.TabIndex = 11;
            this.btnJ22.Text = "J22";
            this.btnJ22.UseVisualStyleBackColor = false;
            this.btnJ22.Click += new System.EventHandler(this.btnJ22_Click);
            // 
            // btnJ21
            // 
            this.btnJ21.BackColor = System.Drawing.Color.Silver;
            this.btnJ21.Location = new System.Drawing.Point(6, 386);
            this.btnJ21.Name = "btnJ21";
            this.btnJ21.Size = new System.Drawing.Size(75, 30);
            this.btnJ21.TabIndex = 10;
            this.btnJ21.Text = "J21";
            this.btnJ21.UseVisualStyleBackColor = false;
            this.btnJ21.Click += new System.EventHandler(this.btnJ21_Click);
            // 
            // txtTrimRB3
            // 
            this.txtTrimRB3.Location = new System.Drawing.Point(286, 211);
            this.txtTrimRB3.Name = "txtTrimRB3";
            this.txtTrimRB3.Size = new System.Drawing.Size(76, 27);
            this.txtTrimRB3.TabIndex = 21;
            // 
            // btnJ20
            // 
            this.btnJ20.BackColor = System.Drawing.Color.Silver;
            this.btnJ20.Location = new System.Drawing.Point(6, 350);
            this.btnJ20.Name = "btnJ20";
            this.btnJ20.Size = new System.Drawing.Size(75, 30);
            this.btnJ20.TabIndex = 9;
            this.btnJ20.Text = "J20";
            this.btnJ20.UseVisualStyleBackColor = false;
            this.btnJ20.Click += new System.EventHandler(this.btnJ20_Click);
            // 
            // txtTrimRB2
            // 
            this.txtTrimRB2.Location = new System.Drawing.Point(286, 178);
            this.txtTrimRB2.Name = "txtTrimRB2";
            this.txtTrimRB2.Size = new System.Drawing.Size(76, 27);
            this.txtTrimRB2.TabIndex = 20;
            // 
            // btnJ19
            // 
            this.btnJ19.BackColor = System.Drawing.Color.Silver;
            this.btnJ19.Location = new System.Drawing.Point(6, 314);
            this.btnJ19.Name = "btnJ19";
            this.btnJ19.Size = new System.Drawing.Size(75, 30);
            this.btnJ19.TabIndex = 8;
            this.btnJ19.Text = "J19";
            this.btnJ19.UseVisualStyleBackColor = false;
            this.btnJ19.Click += new System.EventHandler(this.btnJ19_Click);
            // 
            // txtTrimRB1
            // 
            this.txtTrimRB1.Location = new System.Drawing.Point(286, 145);
            this.txtTrimRB1.Name = "txtTrimRB1";
            this.txtTrimRB1.Size = new System.Drawing.Size(76, 27);
            this.txtTrimRB1.TabIndex = 19;
            // 
            // btnJ18
            // 
            this.btnJ18.BackColor = System.Drawing.Color.Silver;
            this.btnJ18.Location = new System.Drawing.Point(6, 278);
            this.btnJ18.Name = "btnJ18";
            this.btnJ18.Size = new System.Drawing.Size(75, 30);
            this.btnJ18.TabIndex = 7;
            this.btnJ18.Text = "J18";
            this.btnJ18.UseVisualStyleBackColor = false;
            this.btnJ18.Click += new System.EventHandler(this.btnJ18_Click);
            // 
            // txtTrimRB0
            // 
            this.txtTrimRB0.Location = new System.Drawing.Point(286, 112);
            this.txtTrimRB0.Name = "txtTrimRB0";
            this.txtTrimRB0.Size = new System.Drawing.Size(76, 27);
            this.txtTrimRB0.TabIndex = 18;
            this.txtTrimRB0.TextChanged += new System.EventHandler(this.txtTrimRB0_TextChanged);
            // 
            // btnJ17
            // 
            this.btnJ17.BackColor = System.Drawing.Color.Silver;
            this.btnJ17.Location = new System.Drawing.Point(6, 242);
            this.btnJ17.Name = "btnJ17";
            this.btnJ17.Size = new System.Drawing.Size(75, 30);
            this.btnJ17.TabIndex = 6;
            this.btnJ17.Text = "J17";
            this.btnJ17.UseVisualStyleBackColor = false;
            this.btnJ17.Click += new System.EventHandler(this.btnJ17_Click);
            // 
            // txtLEDRB0
            // 
            this.txtLEDRB0.Location = new System.Drawing.Point(286, 79);
            this.txtLEDRB0.Name = "txtLEDRB0";
            this.txtLEDRB0.Size = new System.Drawing.Size(76, 27);
            this.txtLEDRB0.TabIndex = 17;
            // 
            // btnJ16
            // 
            this.btnJ16.BackColor = System.Drawing.Color.Silver;
            this.btnJ16.Location = new System.Drawing.Point(6, 206);
            this.btnJ16.Name = "btnJ16";
            this.btnJ16.Size = new System.Drawing.Size(75, 30);
            this.btnJ16.TabIndex = 5;
            this.btnJ16.Text = "J16";
            this.btnJ16.UseVisualStyleBackColor = false;
            this.btnJ16.Click += new System.EventHandler(this.btnJ16_Click);
            // 
            // txtBiasRB0
            // 
            this.txtBiasRB0.Location = new System.Drawing.Point(286, 46);
            this.txtBiasRB0.Name = "txtBiasRB0";
            this.txtBiasRB0.Size = new System.Drawing.Size(76, 27);
            this.txtBiasRB0.TabIndex = 16;
            this.txtBiasRB0.TextChanged += new System.EventHandler(this.txtBiasRB0_TextChanged);
            // 
            // btnJ15
            // 
            this.btnJ15.BackColor = System.Drawing.Color.Silver;
            this.btnJ15.Location = new System.Drawing.Point(6, 170);
            this.btnJ15.Name = "btnJ15";
            this.btnJ15.Size = new System.Drawing.Size(75, 30);
            this.btnJ15.TabIndex = 4;
            this.btnJ15.Text = "J15";
            this.btnJ15.UseVisualStyleBackColor = false;
            this.btnJ15.Click += new System.EventHandler(this.btnJ15_Click);
            // 
            // btnJ14
            // 
            this.btnJ14.BackColor = System.Drawing.Color.Silver;
            this.btnJ14.Location = new System.Drawing.Point(6, 134);
            this.btnJ14.Name = "btnJ14";
            this.btnJ14.Size = new System.Drawing.Size(75, 30);
            this.btnJ14.TabIndex = 3;
            this.btnJ14.Text = "J14";
            this.btnJ14.UseVisualStyleBackColor = false;
            this.btnJ14.Click += new System.EventHandler(this.btnJ14_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(282, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(102, 20);
            this.label23.TabIndex = 15;
            this.label23.Text = "READBACK";
            // 
            // btnJ13
            // 
            this.btnJ13.BackColor = System.Drawing.Color.Silver;
            this.btnJ13.Location = new System.Drawing.Point(6, 98);
            this.btnJ13.Name = "btnJ13";
            this.btnJ13.Size = new System.Drawing.Size(75, 30);
            this.btnJ13.TabIndex = 2;
            this.btnJ13.Text = "J13";
            this.btnJ13.UseVisualStyleBackColor = false;
            this.btnJ13.Click += new System.EventHandler(this.btnJ13_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(196, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 20);
            this.label22.TabIndex = 14;
            this.label22.Text = "SETTING";
            // 
            // btnJ12
            // 
            this.btnJ12.BackColor = System.Drawing.Color.Silver;
            this.btnJ12.Location = new System.Drawing.Point(6, 62);
            this.btnJ12.Name = "btnJ12";
            this.btnJ12.Size = new System.Drawing.Size(75, 30);
            this.btnJ12.TabIndex = 1;
            this.btnJ12.Text = "J12";
            this.btnJ12.UseVisualStyleBackColor = false;
            this.btnJ12.Click += new System.EventHandler(this.btnJ12_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(137, 214);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 20);
            this.label21.TabIndex = 13;
            this.label21.Text = "Trim 3";
            // 
            // btnJ11
            // 
            this.btnJ11.BackColor = System.Drawing.Color.Silver;
            this.btnJ11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnJ11.Location = new System.Drawing.Point(6, 26);
            this.btnJ11.Name = "btnJ11";
            this.btnJ11.Size = new System.Drawing.Size(75, 30);
            this.btnJ11.TabIndex = 0;
            this.btnJ11.Text = "J11";
            this.btnJ11.UseVisualStyleBackColor = false;
            this.btnJ11.Click += new System.EventHandler(this.btnJ11_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(137, 178);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 20);
            this.label16.TabIndex = 12;
            this.label16.Text = "Trim 2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(137, 148);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 20);
            this.label15.TabIndex = 11;
            this.label15.Text = "Trim 1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(137, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 20);
            this.label14.TabIndex = 10;
            this.label14.Text = "Trim 0";
            // 
            // txtTrimSet3
            // 
            this.txtTrimSet3.Location = new System.Drawing.Point(200, 211);
            this.txtTrimSet3.Name = "txtTrimSet3";
            this.txtTrimSet3.Size = new System.Drawing.Size(76, 27);
            this.txtTrimSet3.TabIndex = 9;
            this.txtTrimSet3.TextChanged += new System.EventHandler(this.txtTrimSet3_TextChanged);
            // 
            // txtTrimSet2
            // 
            this.txtTrimSet2.Location = new System.Drawing.Point(200, 178);
            this.txtTrimSet2.Name = "txtTrimSet2";
            this.txtTrimSet2.Size = new System.Drawing.Size(76, 27);
            this.txtTrimSet2.TabIndex = 8;
            // 
            // txtTrimSet1
            // 
            this.txtTrimSet1.Location = new System.Drawing.Point(200, 145);
            this.txtTrimSet1.Name = "txtTrimSet1";
            this.txtTrimSet1.Size = new System.Drawing.Size(76, 27);
            this.txtTrimSet1.TabIndex = 7;
            // 
            // txtTrimSet0
            // 
            this.txtTrimSet0.Location = new System.Drawing.Point(200, 112);
            this.txtTrimSet0.Name = "txtTrimSet0";
            this.txtTrimSet0.Size = new System.Drawing.Size(76, 27);
            this.txtTrimSet0.TabIndex = 6;
            // 
            // txtLEDSet0
            // 
            this.txtLEDSet0.Location = new System.Drawing.Point(200, 79);
            this.txtLEDSet0.Name = "txtLEDSet0";
            this.txtLEDSet0.Size = new System.Drawing.Size(76, 27);
            this.txtLEDSet0.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(151, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "LED";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(151, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "Bias";
            // 
            // txtBiasSet0
            // 
            this.txtBiasSet0.Location = new System.Drawing.Point(200, 46);
            this.txtBiasSet0.Name = "txtBiasSet0";
            this.txtBiasSet0.Size = new System.Drawing.Size(76, 27);
            this.txtBiasSet0.TabIndex = 1;
            this.txtBiasSet0.TextChanged += new System.EventHandler(this.txtBiasSet1_TextChanged);
            // 
            // tabIV
            // 
            this.tabIV.Controls.Add(this.label33);
            this.tabIV.Controls.Add(this.numericUpDown2);
            this.tabIV.Controls.Add(this.label38);
            this.tabIV.Controls.Add(this.numericUpDown3);
            this.tabIV.Controls.Add(this.button18);
            this.tabIV.Controls.Add(this.labelTempIV);
            this.tabIV.Controls.Add(this.btnSelHiIV);
            this.tabIV.Controls.Add(this.btnSelLowIV);
            this.tabIV.Controls.Add(this.label34);
            this.tabIV.Controls.Add(this.listBox3);
            this.tabIV.Controls.Add(this.chkBoxJ19IV);
            this.tabIV.Controls.Add(this.chkBoxJ20IV);
            this.tabIV.Controls.Add(this.btnIVScan);
            this.tabIV.Controls.Add(this.button17);
            this.tabIV.Controls.Add(this.chkBoxJ21IV);
            this.tabIV.Controls.Add(this.chkBoxJ22IV);
            this.tabIV.Controls.Add(this.chkBoxJ23IV);
            this.tabIV.Controls.Add(this.chkBoxJ24IV);
            this.tabIV.Controls.Add(this.chkBoxJ25IV);
            this.tabIV.Controls.Add(this.chkBoxJ26IV);
            this.tabIV.Controls.Add(this.chkBoxJ15IV);
            this.tabIV.Controls.Add(this.chkBoxJ16IV);
            this.tabIV.Controls.Add(this.chkBoxJ17IV);
            this.tabIV.Controls.Add(this.chkBoxJ18IV);
            this.tabIV.Controls.Add(this.chkBoxJ13IV);
            this.tabIV.Controls.Add(this.chkBoxJ14IV);
            this.tabIV.Controls.Add(this.chkBoxJ12IV);
            this.tabIV.Controls.Add(this.chkBoxJ11IV);
            this.tabIV.Controls.Add(this.label35);
            this.tabIV.Controls.Add(this.zedGraphIV);
            this.tabIV.Location = new System.Drawing.Point(4, 32);
            this.tabIV.Name = "tabIV";
            this.tabIV.Padding = new System.Windows.Forms.Padding(3);
            this.tabIV.Size = new System.Drawing.Size(1255, 665);
            this.tabIV.TabIndex = 9;
            this.tabIV.Text = "IV";
            this.tabIV.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(314, 400);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(43, 20);
            this.label33.TabIndex = 120;
            this.label33.Text = "Stop";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(401, 398);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 27);
            this.numericUpDown2.TabIndex = 119;
            this.numericUpDown2.Value = new decimal(new int[] {
            57,
            0,
            0,
            0});
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(314, 367);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(45, 20);
            this.label38.TabIndex = 118;
            this.label38.Text = "Start";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(401, 365);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(56, 27);
            this.numericUpDown3.TabIndex = 117;
            this.numericUpDown3.Value = new decimal(new int[] {
            55,
            0,
            0,
            0});
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(11, 347);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(219, 35);
            this.button18.TabIndex = 116;
            this.button18.Text = "UPDATE TEMPERATURE";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // labelTempIV
            // 
            this.labelTempIV.AutoSize = true;
            this.labelTempIV.Location = new System.Drawing.Point(7, 12);
            this.labelTempIV.Name = "labelTempIV";
            this.labelTempIV.Size = new System.Drawing.Size(101, 20);
            this.labelTempIV.TabIndex = 115;
            this.labelTempIV.Text = "labelTempIV";
            // 
            // btnSelHiIV
            // 
            this.btnSelHiIV.Location = new System.Drawing.Point(318, 320);
            this.btnSelHiIV.Name = "btnSelHiIV";
            this.btnSelHiIV.Size = new System.Drawing.Size(139, 39);
            this.btnSelHiIV.TabIndex = 112;
            this.btnSelHiIV.Text = "Select J19-J26";
            this.btnSelHiIV.UseVisualStyleBackColor = true;
            this.btnSelHiIV.Click += new System.EventHandler(this.btnSelHiIV_Click);
            // 
            // btnSelLowIV
            // 
            this.btnSelLowIV.Location = new System.Drawing.Point(318, 275);
            this.btnSelLowIV.Name = "btnSelLowIV";
            this.btnSelLowIV.Size = new System.Drawing.Size(139, 39);
            this.btnSelLowIV.TabIndex = 111;
            this.btnSelLowIV.Text = "Select J11-J18";
            this.btnSelLowIV.UseVisualStyleBackColor = true;
            this.btnSelLowIV.Click += new System.EventHandler(this.btnSelLowIV_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(260, 440);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(140, 20);
            this.label34.TabIndex = 110;
            this.label34.Text = "Histogram to Plot";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(264, 463);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(208, 64);
            this.listBox3.Sorted = true;
            this.listBox3.TabIndex = 109;
            // 
            // chkBoxJ19IV
            // 
            this.chkBoxJ19IV.AutoSize = true;
            this.chkBoxJ19IV.Location = new System.Drawing.Point(382, 35);
            this.chkBoxJ19IV.Name = "chkBoxJ19IV";
            this.chkBoxJ19IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ19IV.TabIndex = 108;
            this.chkBoxJ19IV.Text = "J19";
            this.chkBoxJ19IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ20IV
            // 
            this.chkBoxJ20IV.AutoSize = true;
            this.chkBoxJ20IV.Location = new System.Drawing.Point(382, 65);
            this.chkBoxJ20IV.Name = "chkBoxJ20IV";
            this.chkBoxJ20IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ20IV.TabIndex = 107;
            this.chkBoxJ20IV.Text = "J20";
            this.chkBoxJ20IV.UseVisualStyleBackColor = true;
            // 
            // btnIVScan
            // 
            this.btnIVScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIVScan.Location = new System.Drawing.Point(264, 533);
            this.btnIVScan.Name = "btnIVScan";
            this.btnIVScan.Size = new System.Drawing.Size(101, 39);
            this.btnIVScan.TabIndex = 89;
            this.btnIVScan.Text = "SCAN";
            this.btnIVScan.UseVisualStyleBackColor = true;
            this.btnIVScan.Click += new System.EventHandler(this.btnIVScan_Click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(371, 533);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(101, 39);
            this.button17.TabIndex = 90;
            this.button17.Text = "SAVE";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ21IV
            // 
            this.chkBoxJ21IV.AutoSize = true;
            this.chkBoxJ21IV.Location = new System.Drawing.Point(382, 95);
            this.chkBoxJ21IV.Name = "chkBoxJ21IV";
            this.chkBoxJ21IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ21IV.TabIndex = 106;
            this.chkBoxJ21IV.Text = "J21";
            this.chkBoxJ21IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ22IV
            // 
            this.chkBoxJ22IV.AutoSize = true;
            this.chkBoxJ22IV.Location = new System.Drawing.Point(382, 125);
            this.chkBoxJ22IV.Name = "chkBoxJ22IV";
            this.chkBoxJ22IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ22IV.TabIndex = 105;
            this.chkBoxJ22IV.Text = "J22";
            this.chkBoxJ22IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ23IV
            // 
            this.chkBoxJ23IV.AutoSize = true;
            this.chkBoxJ23IV.Location = new System.Drawing.Point(382, 155);
            this.chkBoxJ23IV.Name = "chkBoxJ23IV";
            this.chkBoxJ23IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ23IV.TabIndex = 104;
            this.chkBoxJ23IV.Text = "J23";
            this.chkBoxJ23IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ24IV
            // 
            this.chkBoxJ24IV.AutoSize = true;
            this.chkBoxJ24IV.Location = new System.Drawing.Point(382, 185);
            this.chkBoxJ24IV.Name = "chkBoxJ24IV";
            this.chkBoxJ24IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ24IV.TabIndex = 103;
            this.chkBoxJ24IV.Text = "J24";
            this.chkBoxJ24IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ25IV
            // 
            this.chkBoxJ25IV.AutoSize = true;
            this.chkBoxJ25IV.Location = new System.Drawing.Point(382, 215);
            this.chkBoxJ25IV.Name = "chkBoxJ25IV";
            this.chkBoxJ25IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ25IV.TabIndex = 102;
            this.chkBoxJ25IV.Text = "J25";
            this.chkBoxJ25IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ26IV
            // 
            this.chkBoxJ26IV.AutoSize = true;
            this.chkBoxJ26IV.Location = new System.Drawing.Point(382, 245);
            this.chkBoxJ26IV.Name = "chkBoxJ26IV";
            this.chkBoxJ26IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ26IV.TabIndex = 101;
            this.chkBoxJ26IV.Text = "J26";
            this.chkBoxJ26IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ15IV
            // 
            this.chkBoxJ15IV.AutoSize = true;
            this.chkBoxJ15IV.Location = new System.Drawing.Point(318, 155);
            this.chkBoxJ15IV.Name = "chkBoxJ15IV";
            this.chkBoxJ15IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ15IV.TabIndex = 100;
            this.chkBoxJ15IV.Text = "J15";
            this.chkBoxJ15IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ16IV
            // 
            this.chkBoxJ16IV.AutoSize = true;
            this.chkBoxJ16IV.Location = new System.Drawing.Point(318, 185);
            this.chkBoxJ16IV.Name = "chkBoxJ16IV";
            this.chkBoxJ16IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ16IV.TabIndex = 99;
            this.chkBoxJ16IV.Text = "J16";
            this.chkBoxJ16IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ17IV
            // 
            this.chkBoxJ17IV.AutoSize = true;
            this.chkBoxJ17IV.Location = new System.Drawing.Point(318, 215);
            this.chkBoxJ17IV.Name = "chkBoxJ17IV";
            this.chkBoxJ17IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ17IV.TabIndex = 98;
            this.chkBoxJ17IV.Text = "J17";
            this.chkBoxJ17IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ18IV
            // 
            this.chkBoxJ18IV.AutoSize = true;
            this.chkBoxJ18IV.Location = new System.Drawing.Point(318, 245);
            this.chkBoxJ18IV.Name = "chkBoxJ18IV";
            this.chkBoxJ18IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ18IV.TabIndex = 97;
            this.chkBoxJ18IV.Text = "J18";
            this.chkBoxJ18IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ13IV
            // 
            this.chkBoxJ13IV.AutoSize = true;
            this.chkBoxJ13IV.Location = new System.Drawing.Point(318, 95);
            this.chkBoxJ13IV.Name = "chkBoxJ13IV";
            this.chkBoxJ13IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ13IV.TabIndex = 96;
            this.chkBoxJ13IV.Text = "J13";
            this.chkBoxJ13IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ14IV
            // 
            this.chkBoxJ14IV.AutoSize = true;
            this.chkBoxJ14IV.Location = new System.Drawing.Point(318, 125);
            this.chkBoxJ14IV.Name = "chkBoxJ14IV";
            this.chkBoxJ14IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ14IV.TabIndex = 95;
            this.chkBoxJ14IV.Text = "J14";
            this.chkBoxJ14IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ12IV
            // 
            this.chkBoxJ12IV.AutoSize = true;
            this.chkBoxJ12IV.Location = new System.Drawing.Point(318, 65);
            this.chkBoxJ12IV.Name = "chkBoxJ12IV";
            this.chkBoxJ12IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ12IV.TabIndex = 94;
            this.chkBoxJ12IV.Text = "J12";
            this.chkBoxJ12IV.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ11IV
            // 
            this.chkBoxJ11IV.AutoSize = true;
            this.chkBoxJ11IV.Location = new System.Drawing.Point(318, 35);
            this.chkBoxJ11IV.Name = "chkBoxJ11IV";
            this.chkBoxJ11IV.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ11IV.TabIndex = 93;
            this.chkBoxJ11IV.Text = "J11";
            this.chkBoxJ11IV.UseVisualStyleBackColor = true;
            this.chkBoxJ11IV.CheckedChanged += new System.EventHandler(this.checkBox48_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(314, 12);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(158, 20);
            this.label35.TabIndex = 92;
            this.label35.Text = "CMB CONNECTED";
            // 
            // zedGraphIV
            // 
            this.zedGraphIV.Location = new System.Drawing.Point(489, 12);
            this.zedGraphIV.Margin = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.zedGraphIV.Name = "zedGraphIV";
            this.zedGraphIV.ScrollGrace = 0D;
            this.zedGraphIV.ScrollMaxX = 0D;
            this.zedGraphIV.ScrollMaxY = 0D;
            this.zedGraphIV.ScrollMaxY2 = 0D;
            this.zedGraphIV.ScrollMinX = 0D;
            this.zedGraphIV.ScrollMinY = 0D;
            this.zedGraphIV.ScrollMinY2 = 0D;
            this.zedGraphIV.Size = new System.Drawing.Size(752, 560);
            this.zedGraphIV.TabIndex = 61;
            // 
            // tabHist
            // 
            this.tabHist.Controls.Add(this.button19);
            this.tabHist.Controls.Add(this.labelTempHist);
            this.tabHist.Controls.Add(this.zedGraphHisto);
            this.tabHist.Controls.Add(this.label30);
            this.tabHist.Controls.Add(this.textBox3);
            this.tabHist.Controls.Add(this.button3);
            this.tabHist.Controls.Add(this.btnSelHiHist);
            this.tabHist.Controls.Add(this.btnSelLowHist);
            this.tabHist.Controls.Add(this.label31);
            this.tabHist.Controls.Add(this.listBox2);
            this.tabHist.Controls.Add(this.chkBoxJ19Hist);
            this.tabHist.Controls.Add(this.chkBoxJ20Hist);
            this.tabHist.Controls.Add(this.button11);
            this.tabHist.Controls.Add(this.button12);
            this.tabHist.Controls.Add(this.chkBoxJ21Hist);
            this.tabHist.Controls.Add(this.chkBoxJ22Hist);
            this.tabHist.Controls.Add(this.chkBoxJ23Hist);
            this.tabHist.Controls.Add(this.chkBoxJ24Hist);
            this.tabHist.Controls.Add(this.chkBoxJ25Hist);
            this.tabHist.Controls.Add(this.chkBoxJ26Hist);
            this.tabHist.Controls.Add(this.chkBoxJ15Hist);
            this.tabHist.Controls.Add(this.chkBoxJ16Hist);
            this.tabHist.Controls.Add(this.chkBoxJ17Hist);
            this.tabHist.Controls.Add(this.chkBoxJ18Hist);
            this.tabHist.Controls.Add(this.chkBoxJ13Hist);
            this.tabHist.Controls.Add(this.chkBoxJ14Hist);
            this.tabHist.Controls.Add(this.chkBoxJ12Hist);
            this.tabHist.Controls.Add(this.chkBoxJ11Hist);
            this.tabHist.Controls.Add(this.label32);
            this.tabHist.Location = new System.Drawing.Point(4, 32);
            this.tabHist.Name = "tabHist";
            this.tabHist.Padding = new System.Windows.Forms.Padding(3);
            this.tabHist.Size = new System.Drawing.Size(1255, 665);
            this.tabHist.TabIndex = 10;
            this.tabHist.Text = "Histogram";
            this.tabHist.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(11, 350);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(219, 35);
            this.button19.TabIndex = 117;
            this.button19.Text = "UPDATE TEMPERATURE";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // labelTempHist
            // 
            this.labelTempHist.AutoSize = true;
            this.labelTempHist.Location = new System.Drawing.Point(7, 15);
            this.labelTempHist.Name = "labelTempHist";
            this.labelTempHist.Size = new System.Drawing.Size(117, 20);
            this.labelTempHist.TabIndex = 116;
            this.labelTempHist.Text = "labelTempHist";
            // 
            // zedGraphHisto
            // 
            this.zedGraphHisto.Location = new System.Drawing.Point(489, 15);
            this.zedGraphHisto.Margin = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.zedGraphHisto.Name = "zedGraphHisto";
            this.zedGraphHisto.ScrollGrace = 0D;
            this.zedGraphHisto.ScrollMaxX = 0D;
            this.zedGraphHisto.ScrollMaxY = 0D;
            this.zedGraphHisto.ScrollMaxY2 = 0D;
            this.zedGraphHisto.ScrollMinX = 0D;
            this.zedGraphHisto.ScrollMinY = 0D;
            this.zedGraphHisto.ScrollMinY2 = 0D;
            this.zedGraphHisto.Size = new System.Drawing.Size(752, 560);
            this.zedGraphHisto.TabIndex = 115;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(314, 365);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(43, 20);
            this.label30.TabIndex = 114;
            this.label30.Text = "Bias";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(318, 388);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 27);
            this.textBox3.TabIndex = 91;
            this.textBox3.Text = "56.1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(397, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 27);
            this.button3.TabIndex = 113;
            this.button3.Text = "Set All";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnSelHiHist
            // 
            this.btnSelHiHist.Location = new System.Drawing.Point(318, 323);
            this.btnSelHiHist.Name = "btnSelHiHist";
            this.btnSelHiHist.Size = new System.Drawing.Size(139, 39);
            this.btnSelHiHist.TabIndex = 112;
            this.btnSelHiHist.Text = "Select J19-J26";
            this.btnSelHiHist.UseVisualStyleBackColor = true;
            this.btnSelHiHist.Click += new System.EventHandler(this.btnSelHiHist_Click);
            // 
            // btnSelLowHist
            // 
            this.btnSelLowHist.Location = new System.Drawing.Point(318, 278);
            this.btnSelLowHist.Name = "btnSelLowHist";
            this.btnSelLowHist.Size = new System.Drawing.Size(139, 39);
            this.btnSelLowHist.TabIndex = 111;
            this.btnSelLowHist.Text = "Select J11-J18";
            this.btnSelLowHist.UseVisualStyleBackColor = true;
            this.btnSelLowHist.Click += new System.EventHandler(this.btnSelLowHist_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(260, 443);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(140, 20);
            this.label31.TabIndex = 110;
            this.label31.Text = "Histogram to Plot";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(264, 466);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(208, 64);
            this.listBox2.Sorted = true;
            this.listBox2.TabIndex = 109;
            // 
            // chkBoxJ19Hist
            // 
            this.chkBoxJ19Hist.AutoSize = true;
            this.chkBoxJ19Hist.Location = new System.Drawing.Point(382, 38);
            this.chkBoxJ19Hist.Name = "chkBoxJ19Hist";
            this.chkBoxJ19Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ19Hist.TabIndex = 108;
            this.chkBoxJ19Hist.Text = "J19";
            this.chkBoxJ19Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ20Hist
            // 
            this.chkBoxJ20Hist.AutoSize = true;
            this.chkBoxJ20Hist.Location = new System.Drawing.Point(382, 68);
            this.chkBoxJ20Hist.Name = "chkBoxJ20Hist";
            this.chkBoxJ20Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ20Hist.TabIndex = 107;
            this.chkBoxJ20Hist.Text = "J20";
            this.chkBoxJ20Hist.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(264, 536);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(101, 39);
            this.button11.TabIndex = 89;
            this.button11.Text = "SCAN";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(371, 536);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(101, 39);
            this.button12.TabIndex = 90;
            this.button12.Text = "SAVE";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ21Hist
            // 
            this.chkBoxJ21Hist.AutoSize = true;
            this.chkBoxJ21Hist.Location = new System.Drawing.Point(382, 98);
            this.chkBoxJ21Hist.Name = "chkBoxJ21Hist";
            this.chkBoxJ21Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ21Hist.TabIndex = 106;
            this.chkBoxJ21Hist.Text = "J21";
            this.chkBoxJ21Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ22Hist
            // 
            this.chkBoxJ22Hist.AutoSize = true;
            this.chkBoxJ22Hist.Location = new System.Drawing.Point(382, 128);
            this.chkBoxJ22Hist.Name = "chkBoxJ22Hist";
            this.chkBoxJ22Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ22Hist.TabIndex = 105;
            this.chkBoxJ22Hist.Text = "J22";
            this.chkBoxJ22Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ23Hist
            // 
            this.chkBoxJ23Hist.AutoSize = true;
            this.chkBoxJ23Hist.Location = new System.Drawing.Point(382, 158);
            this.chkBoxJ23Hist.Name = "chkBoxJ23Hist";
            this.chkBoxJ23Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ23Hist.TabIndex = 104;
            this.chkBoxJ23Hist.Text = "J23";
            this.chkBoxJ23Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ24Hist
            // 
            this.chkBoxJ24Hist.AutoSize = true;
            this.chkBoxJ24Hist.Location = new System.Drawing.Point(382, 188);
            this.chkBoxJ24Hist.Name = "chkBoxJ24Hist";
            this.chkBoxJ24Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ24Hist.TabIndex = 103;
            this.chkBoxJ24Hist.Text = "J24";
            this.chkBoxJ24Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ25Hist
            // 
            this.chkBoxJ25Hist.AutoSize = true;
            this.chkBoxJ25Hist.Location = new System.Drawing.Point(382, 218);
            this.chkBoxJ25Hist.Name = "chkBoxJ25Hist";
            this.chkBoxJ25Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ25Hist.TabIndex = 102;
            this.chkBoxJ25Hist.Text = "J25";
            this.chkBoxJ25Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ26Hist
            // 
            this.chkBoxJ26Hist.AutoSize = true;
            this.chkBoxJ26Hist.Location = new System.Drawing.Point(382, 248);
            this.chkBoxJ26Hist.Name = "chkBoxJ26Hist";
            this.chkBoxJ26Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ26Hist.TabIndex = 101;
            this.chkBoxJ26Hist.Text = "J26";
            this.chkBoxJ26Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ15Hist
            // 
            this.chkBoxJ15Hist.AutoSize = true;
            this.chkBoxJ15Hist.Location = new System.Drawing.Point(318, 158);
            this.chkBoxJ15Hist.Name = "chkBoxJ15Hist";
            this.chkBoxJ15Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ15Hist.TabIndex = 100;
            this.chkBoxJ15Hist.Text = "J15";
            this.chkBoxJ15Hist.UseVisualStyleBackColor = true;
            this.chkBoxJ15Hist.CheckedChanged += new System.EventHandler(this.checkBox25_CheckedChanged);
            // 
            // chkBoxJ16Hist
            // 
            this.chkBoxJ16Hist.AutoSize = true;
            this.chkBoxJ16Hist.Location = new System.Drawing.Point(318, 188);
            this.chkBoxJ16Hist.Name = "chkBoxJ16Hist";
            this.chkBoxJ16Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ16Hist.TabIndex = 99;
            this.chkBoxJ16Hist.Text = "J16";
            this.chkBoxJ16Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ17Hist
            // 
            this.chkBoxJ17Hist.AutoSize = true;
            this.chkBoxJ17Hist.Location = new System.Drawing.Point(318, 218);
            this.chkBoxJ17Hist.Name = "chkBoxJ17Hist";
            this.chkBoxJ17Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ17Hist.TabIndex = 98;
            this.chkBoxJ17Hist.Text = "J17";
            this.chkBoxJ17Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ18Hist
            // 
            this.chkBoxJ18Hist.AutoSize = true;
            this.chkBoxJ18Hist.Location = new System.Drawing.Point(318, 248);
            this.chkBoxJ18Hist.Name = "chkBoxJ18Hist";
            this.chkBoxJ18Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ18Hist.TabIndex = 97;
            this.chkBoxJ18Hist.Text = "J18";
            this.chkBoxJ18Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ13Hist
            // 
            this.chkBoxJ13Hist.AutoSize = true;
            this.chkBoxJ13Hist.Location = new System.Drawing.Point(318, 98);
            this.chkBoxJ13Hist.Name = "chkBoxJ13Hist";
            this.chkBoxJ13Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ13Hist.TabIndex = 96;
            this.chkBoxJ13Hist.Text = "J13";
            this.chkBoxJ13Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ14Hist
            // 
            this.chkBoxJ14Hist.AutoSize = true;
            this.chkBoxJ14Hist.Location = new System.Drawing.Point(318, 128);
            this.chkBoxJ14Hist.Name = "chkBoxJ14Hist";
            this.chkBoxJ14Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ14Hist.TabIndex = 95;
            this.chkBoxJ14Hist.Text = "J14";
            this.chkBoxJ14Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ12Hist
            // 
            this.chkBoxJ12Hist.AutoSize = true;
            this.chkBoxJ12Hist.Location = new System.Drawing.Point(318, 68);
            this.chkBoxJ12Hist.Name = "chkBoxJ12Hist";
            this.chkBoxJ12Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ12Hist.TabIndex = 94;
            this.chkBoxJ12Hist.Text = "J12";
            this.chkBoxJ12Hist.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ11Hist
            // 
            this.chkBoxJ11Hist.AutoSize = true;
            this.chkBoxJ11Hist.Location = new System.Drawing.Point(318, 38);
            this.chkBoxJ11Hist.Name = "chkBoxJ11Hist";
            this.chkBoxJ11Hist.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ11Hist.TabIndex = 93;
            this.chkBoxJ11Hist.Text = "J11";
            this.chkBoxJ11Hist.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(314, 15);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(158, 20);
            this.label32.TabIndex = 92;
            this.label32.Text = "CMB CONNECTED";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerScopeBias
            // 
            this.timerScopeBias.Interval = 55;
            this.timerScopeBias.Tick += new System.EventHandler(this.timerScopeBias_Tick);
            // 
            // timerScopeTrim
            // 
            this.timerScopeTrim.Interval = 50;
            this.timerScopeTrim.Tick += new System.EventHandler(this.timerScopeTrim_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CalibPType
            // 
            this.CalibPType.Location = new System.Drawing.Point(4, 32);
            this.CalibPType.Name = "CalibPType";
            this.CalibPType.Size = new System.Drawing.Size(1255, 665);
            this.CalibPType.TabIndex = 11;
            this.CalibPType.Text = "Prototype Calibration";
            this.CalibPType.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 728);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabRUN.ResumeLayout(false);
            this.tabRUN.PerformLayout();
            this.groupBoxEvDisplay.ResumeLayout(false);
            this.groupBoxEvDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_VertMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_VertMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabConsole.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabFEB1.ResumeLayout(false);
            this.tabFEB1.PerformLayout();
            this.groupBoxSpillStat.ResumeLayout(false);
            this.groupBoxSpillStat.PerformLayout();
            this.groupBoxREG1.ResumeLayout(false);
            this.groupBoxREG1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udFPGA)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBoxConn.ResumeLayout(false);
            this.groupBoxConn.PerformLayout();
            this.tabWC.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabFEBtest.ResumeLayout(false);
            this.tabFEBtest.PerformLayout();
            this.DAC_Voltages.ResumeLayout(false);
            this.DAC_Voltages.PerformLayout();
            this.tabIV.ResumeLayout(false);
            this.tabIV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.tabHist.ResumeLayout(false);
            this.tabHist.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtBiasRB0_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFEB1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRUN;
        private System.Windows.Forms.GroupBox groupBox1;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.TabPage tabFEB1;
        private System.Windows.Forms.GroupBox groupBoxConn;
        private System.Windows.Forms.Button btnFEB1;
        private System.Windows.Forms.TabPage tabWC;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblWCmessage;
        private System.Windows.Forms.Button btnWC;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblInc;
        private System.Windows.Forms.NumericUpDown udInterval;
        private System.Windows.Forms.Button btnSaveHistos;
        private System.Windows.Forms.Label lblStop;
        public System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.NumericUpDown udStop;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.NumericUpDown udStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkIntegral;
        private System.Windows.Forms.CheckBox chkLogY;
        private System.Windows.Forms.GroupBox groupBoxSpillStat;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnSpillMON;
        private System.Windows.Forms.Button btnSpillWRITE;
        private System.Windows.Forms.Button btnSpillREAD;
        private System.Windows.Forms.Button btnBIAS_MON;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Button btnBiasWRITE;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.Button dbgWC;
        private System.Windows.Forms.Button dbgFEB2;
        private System.Windows.Forms.Button dbgFEB1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblConsole_disp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBiasREAD;
        private System.Windows.Forms.TextBox txtI;
        private System.Windows.Forms.TextBox txtV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxREG1;
        private System.Windows.Forms.NumericUpDown udFPGA;
        private System.Windows.Forms.Button btnRegMON;
        private System.Windows.Forms.Button btnRegWRITE;
        private System.Windows.Forms.Button btnRegREAD;
        private ZedGraph.ZedGraphControl zedFEB1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown udChan;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Button btnCHANGE;
        private System.Windows.Forms.Button btnTestSpill;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFPGA;
        private System.Windows.Forms.Button btnFEB2;
        private System.Windows.Forms.ToolStripStatusLabel lblFEB1;
        private System.Windows.Forms.ToolStripStatusLabel lblFEB2;
        private System.Windows.Forms.ToolStripStatusLabel lblWC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ShowSpect;
        private System.Windows.Forms.Button ShowIV;
        private System.Windows.Forms.Button btnConnectAll;
        private System.Windows.Forms.Button btnStopRun;
        private System.Windows.Forms.Button btnStartRun;
        private System.Windows.Forms.Button btnPrepare;
        private System.Windows.Forms.Label lblRunLog;
        private System.Windows.Forms.Label lblRunName;
        private System.Windows.Forms.Label lblSpillTime;
        private System.Windows.Forms.Label lblWCTrigNum;
        private System.Windows.Forms.Label lblFEB2TrigNum;
        private System.Windows.Forms.Label lblFEB1TrigNum;
        private System.Windows.Forms.Label lblFEB1Spill;
        private System.Windows.Forms.Label lblRunPrep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRunTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSpillWC;
        private System.Windows.Forms.Label lblSpillFEB2;
        private System.Windows.Forms.Label lblSpillFEB1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblWCSpill;
        private System.Windows.Forms.Label lblFEB2Spill;
        private System.Windows.Forms.Label lblWC_TotTrig;
        private System.Windows.Forms.Label lblFEB2_TotTrig;
        private System.Windows.Forms.Label lblFEB1_TotTrig;
        private System.Windows.Forms.CheckBox chkFakeIt;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.CheckBox chkWC;
        private System.Windows.Forms.CheckBox chkFEB2;
        private System.Windows.Forms.CheckBox chkFEB1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnOneSpill;
        private System.Windows.Forms.NumericUpDown ud_VertMax;
        private System.Windows.Forms.GroupBox groupBoxEvDisplay;
        private System.Windows.Forms.Label lblEventCount;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Button btnNextDisp;
        private System.Windows.Forms.Button btnPrevDisp;
        private System.Windows.Forms.NumericUpDown ud_VertMin;
        private System.Windows.Forms.Button btnDisplaySpill;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnDebugLogging;
        private System.Windows.Forms.TabPage tabFEBtest;
        private System.Windows.Forms.GroupBox DAC_Voltages;
        private System.Windows.Forms.TextBox txtTrimRB3;
        private System.Windows.Forms.TextBox txtTrimRB2;
        private System.Windows.Forms.TextBox txtTrimRB1;
        private System.Windows.Forms.TextBox txtTrimRB0;
        private System.Windows.Forms.TextBox txtLEDRB0;
        private System.Windows.Forms.TextBox txtBiasRB0;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTrimSet3;
        private System.Windows.Forms.TextBox txtTrimSet2;
        private System.Windows.Forms.TextBox txtTrimSet1;
        private System.Windows.Forms.TextBox txtTrimSet0;
        private System.Windows.Forms.TextBox txtLEDSet0;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBiasSet0;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnDacWrite;
        private System.Windows.Forms.Button btnDacScan;
        private System.Windows.Forms.Button btnSnSave;
        private System.Windows.Forms.Button btnJ26;
        private System.Windows.Forms.Button btnJ25;
        private System.Windows.Forms.Button btnJ24;
        private System.Windows.Forms.Button btnJ23;
        private System.Windows.Forms.Button btnJ22;
        private System.Windows.Forms.Button btnJ21;
        private System.Windows.Forms.Button btnJ20;
        private System.Windows.Forms.Button btnJ19;
        private System.Windows.Forms.Button btnJ18;
        private System.Windows.Forms.Button btnJ17;
        private System.Windows.Forms.Button btnJ16;
        private System.Windows.Forms.Button btnJ15;
        private System.Windows.Forms.Button btnJ14;
        private System.Windows.Forms.Button btnJ13;
        private System.Windows.Forms.Button btnJ12;
        private System.Windows.Forms.Button btnJ11;
        private System.Windows.Forms.Button btnDacSave;
        private System.Windows.Forms.Button btnConnectScope;
        private System.Windows.Forms.Timer timerScopeBias;
        private System.Windows.Forms.Timer timerScopeTrim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtCalibComments;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtTrim3Int;
        private System.Windows.Forms.TextBox txtTrim3Slope;
        private System.Windows.Forms.TextBox txtTrim2Int;
        private System.Windows.Forms.TextBox txtTrim2Slope;
        private System.Windows.Forms.TextBox txtTrim1Int;
        private System.Windows.Forms.TextBox txtTrim1Slope;
        private System.Windows.Forms.TextBox txtTrim0Int;
        private System.Windows.Forms.TextBox txtTrim0Slope;
        private System.Windows.Forms.TextBox txtBiasInt;
        private System.Windows.Forms.TextBox txtBiasSlope;
        private System.Windows.Forms.Button btnLoadCalib;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabIV;
        private System.Windows.Forms.TabPage tabHist;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Label labelTempIV;
        private System.Windows.Forms.Button btnSelHiIV;
        private System.Windows.Forms.Button btnSelLowIV;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.CheckBox chkBoxJ19IV;
        private System.Windows.Forms.CheckBox chkBoxJ20IV;
        public System.Windows.Forms.Button btnIVScan;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.CheckBox chkBoxJ21IV;
        private System.Windows.Forms.CheckBox chkBoxJ22IV;
        private System.Windows.Forms.CheckBox chkBoxJ23IV;
        private System.Windows.Forms.CheckBox chkBoxJ24IV;
        private System.Windows.Forms.CheckBox chkBoxJ25IV;
        private System.Windows.Forms.CheckBox chkBoxJ26IV;
        private System.Windows.Forms.CheckBox chkBoxJ15IV;
        private System.Windows.Forms.CheckBox chkBoxJ16IV;
        private System.Windows.Forms.CheckBox chkBoxJ17IV;
        private System.Windows.Forms.CheckBox chkBoxJ18IV;
        private System.Windows.Forms.CheckBox chkBoxJ13IV;
        private System.Windows.Forms.CheckBox chkBoxJ14IV;
        private System.Windows.Forms.CheckBox chkBoxJ12IV;
        private System.Windows.Forms.CheckBox chkBoxJ11IV;
        private System.Windows.Forms.Label label35;
        private ZedGraph.ZedGraphControl zedGraphIV;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Label labelTempHist;
        private ZedGraph.ZedGraphControl zedGraphHisto;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSelHiHist;
        private System.Windows.Forms.Button btnSelLowHist;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox chkBoxJ19Hist;
        private System.Windows.Forms.CheckBox chkBoxJ20Hist;
        public System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.CheckBox chkBoxJ21Hist;
        private System.Windows.Forms.CheckBox chkBoxJ22Hist;
        private System.Windows.Forms.CheckBox chkBoxJ23Hist;
        private System.Windows.Forms.CheckBox chkBoxJ24Hist;
        private System.Windows.Forms.CheckBox chkBoxJ25Hist;
        private System.Windows.Forms.CheckBox chkBoxJ26Hist;
        private System.Windows.Forms.CheckBox chkBoxJ15Hist;
        private System.Windows.Forms.CheckBox chkBoxJ16Hist;
        private System.Windows.Forms.CheckBox chkBoxJ17Hist;
        private System.Windows.Forms.CheckBox chkBoxJ18Hist;
        private System.Windows.Forms.CheckBox chkBoxJ13Hist;
        private System.Windows.Forms.CheckBox chkBoxJ14Hist;
        private System.Windows.Forms.CheckBox chkBoxJ12Hist;
        private System.Windows.Forms.CheckBox chkBoxJ11Hist;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnZeroVoltages;
        private System.Windows.Forms.TextBox txtMuxI3;
        private System.Windows.Forms.TextBox txtMuxI2;
        private System.Windows.Forms.TextBox txtMuxI1;
        private System.Windows.Forms.TextBox txtMuxI0;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TabPage CalibPType;
    }
}