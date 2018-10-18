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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Connect the two ethernet cables.");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Make sure the FEB address is 172.16.10.10.");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Connect the application to the FEB.");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Enter the serial number if it does not already appear.");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Check that the test information is correct.");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Start", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Run the multiplexer (\"mux\") test.");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Connect the HDMI cables from the DMM to the FEB.");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Initialize the voltage readings.");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("(optional) Set the number of samples per channel.");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Run the calibration test.");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Check results, add comments, and save.");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("HV Calibration", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Change HDMI cables to dark box.");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Check temperature and CMB ID readback.");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Set test voltage.");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("(optional) Select HDMI channels to test.");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Visually inspect all histograms.");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Enter comments and save.");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("SiPM Histograms", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Click disconnect button.");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Disconnect all cables.");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Move FEB to the appropriate pile.");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Finish", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("FPGA 0", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("FPGA 1", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("FPGA 2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("FPGA 3", System.Windows.Forms.HorizontalAlignment.Left);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFEB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFEB2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWC = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStart = new System.Windows.Forms.TabPage();
            this.label48 = new System.Windows.Forms.Label();
            this.txtTestLocation = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.btnDisconnectFEB = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtTestType = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtFEBseries = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label34 = new System.Windows.Forms.Label();
            this.txtFEBAddress = new System.Windows.Forms.TextBox();
            this.btnConnectFEB = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.btnSnSave = new System.Windows.Forms.Button();
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
            this.tabHist = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.udHistIntegralTime = new System.Windows.Forms.NumericUpDown();
            this.chkLogYHist = new System.Windows.Forms.CheckBox();
            this.labelTempHist = new System.Windows.Forms.Label();
            this.zedGraphHisto = new ZedGraph.ZedGraphControl();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnSetV = new System.Windows.Forms.Button();
            this.btnSelHiHist = new System.Windows.Forms.Button();
            this.btnSelLowHist = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.listBoxHistos = new System.Windows.Forms.ListBox();
            this.chkBoxJ19 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ20 = new System.Windows.Forms.CheckBox();
            this.btnHistoScan = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.chkBoxJ21 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ22 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ23 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ24 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ25 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ26 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ15 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ16 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ17 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ18 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ13 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ14 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ12 = new System.Windows.Forms.CheckBox();
            this.chkBoxJ11 = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.CalibPType = new System.Windows.Forms.TabPage();
            this.txtHVTestComments = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.btnSaveDB = new System.Windows.Forms.Button();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.btnBuildListView = new System.Windows.Forms.Button();
            this.lblMuxTime = new System.Windows.Forms.Label();
            this.lblScanTime = new System.Windows.Forms.Label();
            this.lblScanSamples = new System.Windows.Forms.Label();
            this.UpDnSamples = new System.Windows.Forms.NumericUpDown();
            this.btnZeroVoltages = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.lblSelectedChan = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.txtVSet = new System.Windows.Forms.TextBox();
            this.btnMuxTest = new System.Windows.Forms.Button();
            this.btnSaveVScan = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.btnFullVScan = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Channel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HDMI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Setting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Measurement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsCalibrated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MuxCurrent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.dbgWC = new System.Windows.Forms.Button();
            this.dbgFEB2 = new System.Windows.Forms.Button();
            this.dbgFEB1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnDebugLogging = new System.Windows.Forms.Button();
            this.lblConsole_disp = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.tabWC = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblWCmessage = new System.Windows.Forms.Label();
            this.btnWC = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileCalibrations = new System.Windows.Forms.SaveFileDialog();
            this.saveFileMeasurements = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDB = new System.Windows.Forms.SaveFileDialog();
            this.timerTempRB = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabStart.SuspendLayout();
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
            this.tabHist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHistIntegralTime)).BeginInit();
            this.CalibPType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDnSamples)).BeginInit();
            this.tabConsole.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabRUN.SuspendLayout();
            this.groupBoxEvDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_VertMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_VertMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabWC.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.tabControl.Controls.Add(this.tabStart);
            this.tabControl.Controls.Add(this.CalibPType);
            this.tabControl.Controls.Add(this.tabHist);
            this.tabControl.Controls.Add(this.tabRUN);
            this.tabControl.Controls.Add(this.tabFEB1);
            this.tabControl.Controls.Add(this.tabWC);
            this.tabControl.Controls.Add(this.tabConsole);
            this.tabControl.Location = new System.Drawing.Point(1, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1263, 701);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 1;
            // 
            // tabStart
            // 
            this.tabStart.Controls.Add(this.label48);
            this.tabStart.Controls.Add(this.txtTestLocation);
            this.tabStart.Controls.Add(this.txtUser);
            this.tabStart.Controls.Add(this.label46);
            this.tabStart.Controls.Add(this.btnDisconnectFEB);
            this.tabStart.Controls.Add(this.btnDisconnect);
            this.tabStart.Controls.Add(this.txtTestType);
            this.tabStart.Controls.Add(this.label45);
            this.tabStart.Controls.Add(this.txtFEBseries);
            this.tabStart.Controls.Add(this.label38);
            this.tabStart.Controls.Add(this.label35);
            this.tabStart.Controls.Add(this.treeView1);
            this.tabStart.Controls.Add(this.label34);
            this.tabStart.Controls.Add(this.txtFEBAddress);
            this.tabStart.Controls.Add(this.btnConnectFEB);
            this.tabStart.Controls.Add(this.label33);
            this.tabStart.Controls.Add(this.txtSN);
            this.tabStart.Controls.Add(this.btnSnSave);
            this.tabStart.Location = new System.Drawing.Point(4, 32);
            this.tabStart.Name = "tabStart";
            this.tabStart.Size = new System.Drawing.Size(1255, 665);
            this.tabStart.TabIndex = 12;
            this.tabStart.Text = "Start";
            this.tabStart.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(35, 346);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(164, 29);
            this.label48.TabIndex = 26;
            this.label48.Text = "Test Location:";
            // 
            // txtTestLocation
            // 
            this.txtTestLocation.AutoCompleteCustomSource.AddRange(new string[] {
            "KSU",
            "FNAL"});
            this.txtTestLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTestLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTestLocation.Location = new System.Drawing.Point(290, 350);
            this.txtTestLocation.Name = "txtTestLocation";
            this.txtTestLocation.Size = new System.Drawing.Size(199, 27);
            this.txtTestLocation.TabIndex = 25;
            this.txtTestLocation.Text = "KSU";
            // 
            // txtUser
            // 
            this.txtUser.AutoCompleteCustomSource.AddRange(new string[] {
            "Kreswell Neely",
            "Kaitlyn Smallfoot",
            "Glenn Horton-Smith",
            "Yurii Maravin",
            "Tim Bolton",
            "Stephen Corkill"});
            this.txtUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUser.Location = new System.Drawing.Point(290, 383);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(199, 27);
            this.txtUser.TabIndex = 24;
            this.txtUser.Text = "Kaitlyn Smallfoot";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(35, 379);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(249, 29);
            this.label46.TabIndex = 23;
            this.label46.Text = "Operator (your name):";
            // 
            // btnDisconnectFEB
            // 
            this.btnDisconnectFEB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnectFEB.Location = new System.Drawing.Point(306, 120);
            this.btnDisconnectFEB.Name = "btnDisconnectFEB";
            this.btnDisconnectFEB.Size = new System.Drawing.Size(200, 40);
            this.btnDisconnectFEB.TabIndex = 22;
            this.btnDisconnectFEB.Text = "DISCONNECT";
            this.btnDisconnectFEB.UseVisualStyleBackColor = true;
            this.btnDisconnectFEB.Visible = false;
            this.btnDisconnectFEB.Click += new System.EventHandler(this.btnDisconnectFEB_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(612, 416);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(179, 72);
            this.btnDisconnect.TabIndex = 21;
            this.btnDisconnect.Text = "Disconnect and Reset";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtTestType
            // 
            this.txtTestType.AutoCompleteCustomSource.AddRange(new string[] {
            "Production QC",
            "Software Test",
            "Test Run",
            "Retest"});
            this.txtTestType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTestType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTestType.Location = new System.Drawing.Point(290, 317);
            this.txtTestType.Name = "txtTestType";
            this.txtTestType.Size = new System.Drawing.Size(199, 27);
            this.txtTestType.TabIndex = 20;
            this.txtTestType.Text = "Test Run";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(35, 313);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(195, 29);
            this.label45.TabIndex = 19;
            this.label45.Text = "Test Description:";
            // 
            // txtFEBseries
            // 
            this.txtFEBseries.AutoCompleteCustomSource.AddRange(new string[] {
            "prototype",
            "preproduction batch 1",
            "preproduction batch 2",
            "production pilot",
            "production"});
            this.txtFEBseries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFEBseries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFEBseries.Location = new System.Drawing.Point(290, 284);
            this.txtFEBseries.Name = "txtFEBseries";
            this.txtFEBseries.Size = new System.Drawing.Size(199, 27);
            this.txtFEBseries.TabIndex = 18;
            this.txtFEBseries.Text = "preproduction batch 2";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(35, 280);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(142, 29);
            this.label38.TabIndex = 17;
            this.label38.Text = "FEB Series:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(606, 48);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(172, 32);
            this.label35.TabIndex = 16;
            this.label35.Text = "Instructions";
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(612, 83);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node4";
            treeNode1.Text = "Connect the two ethernet cables.";
            treeNode2.Name = "Node5";
            treeNode2.Text = "Make sure the FEB address is 172.16.10.10.";
            treeNode3.Name = "Node6";
            treeNode3.Text = "Connect the application to the FEB.";
            treeNode4.Name = "Node7";
            treeNode4.Text = "Enter the serial number if it does not already appear.";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Check that the test information is correct.";
            treeNode6.Name = "Node0";
            treeNode6.Text = "Start";
            treeNode7.Name = "Node8";
            treeNode7.Text = "Run the multiplexer (\"mux\") test.";
            treeNode8.Name = "Node9";
            treeNode8.Text = "Connect the HDMI cables from the DMM to the FEB.";
            treeNode9.Name = "Node12";
            treeNode9.Text = "Initialize the voltage readings.";
            treeNode10.Name = "Node10";
            treeNode10.Text = "(optional) Set the number of samples per channel.";
            treeNode11.Name = "Node11";
            treeNode11.Text = "Run the calibration test.";
            treeNode12.Name = "Node13";
            treeNode12.Text = "Check results, add comments, and save.";
            treeNode13.Name = "Node1";
            treeNode13.Text = "HV Calibration";
            treeNode14.Name = "Node14";
            treeNode14.Text = "Change HDMI cables to dark box.";
            treeNode15.Name = "Node16";
            treeNode15.Text = "Check temperature and CMB ID readback.";
            treeNode16.Name = "Node17";
            treeNode16.Text = "Set test voltage.";
            treeNode17.Name = "Node18";
            treeNode17.Text = "(optional) Select HDMI channels to test.";
            treeNode18.Name = "Node19";
            treeNode18.Text = "Visually inspect all histograms.";
            treeNode19.Name = "Node20";
            treeNode19.Text = "Enter comments and save.";
            treeNode20.Name = "Node2";
            treeNode20.Text = "SiPM Histograms";
            treeNode21.Name = "Node21";
            treeNode21.Text = "Click disconnect button.";
            treeNode22.Name = "Node22";
            treeNode22.Text = "Disconnect all cables.";
            treeNode23.Name = "Node23";
            treeNode23.Text = "Move FEB to the appropriate pile.";
            treeNode24.Name = "Node3";
            treeNode24.Text = "Finish";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode13,
            treeNode20,
            treeNode24});
            this.treeView1.Size = new System.Drawing.Size(635, 327);
            this.treeView1.TabIndex = 15;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(34, 66);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(201, 32);
            this.label34.TabIndex = 14;
            this.label34.Text = "FEB Address:";
            // 
            // txtFEBAddress
            // 
            this.txtFEBAddress.Location = new System.Drawing.Point(241, 71);
            this.txtFEBAddress.Name = "txtFEBAddress";
            this.txtFEBAddress.Size = new System.Drawing.Size(188, 27);
            this.txtFEBAddress.TabIndex = 12;
            this.txtFEBAddress.Enter += new System.EventHandler(this.txtFEBAddress_Enter);
            // 
            // btnConnectFEB
            // 
            this.btnConnectFEB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectFEB.Location = new System.Drawing.Point(40, 106);
            this.btnConnectFEB.Name = "btnConnectFEB";
            this.btnConnectFEB.Size = new System.Drawing.Size(260, 64);
            this.btnConnectFEB.TabIndex = 11;
            this.btnConnectFEB.Text = "Connect to FEB";
            this.btnConnectFEB.UseVisualStyleBackColor = true;
            this.btnConnectFEB.Click += new System.EventHandler(this.btnConnectFEB_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(35, 210);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(228, 29);
            this.label33.TabIndex = 10;
            this.label33.Text = "FEB Serial Number:";
            // 
            // txtSN
            // 
            this.txtSN.Location = new System.Drawing.Point(290, 214);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(199, 27);
            this.txtSN.TabIndex = 5;
            this.txtSN.TextChanged += new System.EventHandler(this.txtSN_TextChanged);
            // 
            // btnSnSave
            // 
            this.btnSnSave.Enabled = false;
            this.btnSnSave.Location = new System.Drawing.Point(290, 247);
            this.btnSnSave.Name = "btnSnSave";
            this.btnSnSave.Size = new System.Drawing.Size(111, 31);
            this.btnSnSave.TabIndex = 8;
            this.btnSnSave.Text = "SAVE";
            this.btnSnSave.UseVisualStyleBackColor = true;
            this.btnSnSave.Click += new System.EventHandler(this.btnSnSave_Click);
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
            this.button6.Click += new System.EventHandler(this.button6_Click);
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
            // 
            // txtV
            // 
            this.txtV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtV.Location = new System.Drawing.Point(50, 29);
            this.txtV.Name = "txtV";
            this.txtV.Size = new System.Drawing.Size(55, 24);
            this.txtV.TabIndex = 61;
            this.txtV.Text = "0.000";
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
            // tabHist
            // 
            this.tabHist.Controls.Add(this.label9);
            this.tabHist.Controls.Add(this.udHistIntegralTime);
            this.tabHist.Controls.Add(this.chkLogYHist);
            this.tabHist.Controls.Add(this.labelTempHist);
            this.tabHist.Controls.Add(this.zedGraphHisto);
            this.tabHist.Controls.Add(this.label30);
            this.tabHist.Controls.Add(this.textBox3);
            this.tabHist.Controls.Add(this.btnSetV);
            this.tabHist.Controls.Add(this.btnSelHiHist);
            this.tabHist.Controls.Add(this.btnSelLowHist);
            this.tabHist.Controls.Add(this.label31);
            this.tabHist.Controls.Add(this.listBoxHistos);
            this.tabHist.Controls.Add(this.chkBoxJ19);
            this.tabHist.Controls.Add(this.chkBoxJ20);
            this.tabHist.Controls.Add(this.btnHistoScan);
            this.tabHist.Controls.Add(this.button12);
            this.tabHist.Controls.Add(this.chkBoxJ21);
            this.tabHist.Controls.Add(this.chkBoxJ22);
            this.tabHist.Controls.Add(this.chkBoxJ23);
            this.tabHist.Controls.Add(this.chkBoxJ24);
            this.tabHist.Controls.Add(this.chkBoxJ25);
            this.tabHist.Controls.Add(this.chkBoxJ26);
            this.tabHist.Controls.Add(this.chkBoxJ15);
            this.tabHist.Controls.Add(this.chkBoxJ16);
            this.tabHist.Controls.Add(this.chkBoxJ17);
            this.tabHist.Controls.Add(this.chkBoxJ18);
            this.tabHist.Controls.Add(this.chkBoxJ13);
            this.tabHist.Controls.Add(this.chkBoxJ14);
            this.tabHist.Controls.Add(this.chkBoxJ12);
            this.tabHist.Controls.Add(this.chkBoxJ11);
            this.tabHist.Controls.Add(this.label32);
            this.tabHist.Location = new System.Drawing.Point(4, 32);
            this.tabHist.Name = "tabHist";
            this.tabHist.Padding = new System.Windows.Forms.Padding(3);
            this.tabHist.Size = new System.Drawing.Size(1255, 665);
            this.tabHist.TabIndex = 10;
            this.tabHist.Text = "Histogram";
            this.tabHist.UseVisualStyleBackColor = true;
            this.tabHist.Enter += new System.EventHandler(this.tabHist_Enter);
            this.tabHist.Leave += new System.EventHandler(this.tabHist_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(485, 592);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 20);
            this.label9.TabIndex = 119;
            this.label9.Text = "Integration Time (ms)";
            // 
            // udHistIntegralTime
            // 
            this.udHistIntegralTime.Location = new System.Drawing.Point(660, 590);
            this.udHistIntegralTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udHistIntegralTime.Name = "udHistIntegralTime";
            this.udHistIntegralTime.Size = new System.Drawing.Size(57, 27);
            this.udHistIntegralTime.TabIndex = 118;
            this.udHistIntegralTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chkLogYHist
            // 
            this.chkLogYHist.AutoSize = true;
            this.chkLogYHist.Checked = true;
            this.chkLogYHist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogYHist.Location = new System.Drawing.Point(1172, 591);
            this.chkLogYHist.Name = "chkLogYHist";
            this.chkLogYHist.Size = new System.Drawing.Size(69, 24);
            this.chkLogYHist.TabIndex = 117;
            this.chkLogYHist.Text = "LogY";
            this.chkLogYHist.UseVisualStyleBackColor = true;
            this.chkLogYHist.CheckStateChanged += new System.EventHandler(this.chkLogYHist_CheckStateChanged);
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
            this.label30.Size = new System.Drawing.Size(104, 20);
            this.label30.TabIndex = 114;
            this.label30.Text = "Bias Voltage";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(318, 388);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 27);
            this.textBox3.TabIndex = 91;
            this.textBox3.Text = "56.1";
            // 
            // btnSetV
            // 
            this.btnSetV.Location = new System.Drawing.Point(397, 388);
            this.btnSetV.Name = "btnSetV";
            this.btnSetV.Size = new System.Drawing.Size(75, 27);
            this.btnSetV.TabIndex = 113;
            this.btnSetV.Text = "Set All";
            this.btnSetV.UseVisualStyleBackColor = true;
            this.btnSetV.Click += new System.EventHandler(this.btnSetV_Click);
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
            this.label31.Location = new System.Drawing.Point(208, 423);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(140, 20);
            this.label31.TabIndex = 110;
            this.label31.Text = "Histogram to Plot";
            // 
            // listBoxHistos
            // 
            this.listBoxHistos.FormattingEnabled = true;
            this.listBoxHistos.ItemHeight = 20;
            this.listBoxHistos.Location = new System.Drawing.Point(212, 446);
            this.listBoxHistos.Name = "listBoxHistos";
            this.listBoxHistos.Size = new System.Drawing.Size(260, 84);
            this.listBoxHistos.Sorted = true;
            this.listBoxHistos.TabIndex = 109;
            this.listBoxHistos.SelectedIndexChanged += new System.EventHandler(this.listBoxHistos_SelectedIndexChanged);
            // 
            // chkBoxJ19
            // 
            this.chkBoxJ19.AutoSize = true;
            this.chkBoxJ19.Checked = true;
            this.chkBoxJ19.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ19.Location = new System.Drawing.Point(382, 38);
            this.chkBoxJ19.Name = "chkBoxJ19";
            this.chkBoxJ19.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ19.TabIndex = 108;
            this.chkBoxJ19.Text = "J19";
            this.chkBoxJ19.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ20
            // 
            this.chkBoxJ20.AutoSize = true;
            this.chkBoxJ20.Checked = true;
            this.chkBoxJ20.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ20.Location = new System.Drawing.Point(382, 68);
            this.chkBoxJ20.Name = "chkBoxJ20";
            this.chkBoxJ20.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ20.TabIndex = 107;
            this.chkBoxJ20.Text = "J20";
            this.chkBoxJ20.UseVisualStyleBackColor = true;
            // 
            // btnHistoScan
            // 
            this.btnHistoScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoScan.Location = new System.Drawing.Point(212, 536);
            this.btnHistoScan.Name = "btnHistoScan";
            this.btnHistoScan.Size = new System.Drawing.Size(127, 39);
            this.btnHistoScan.TabIndex = 89;
            this.btnHistoScan.Text = "SCAN";
            this.btnHistoScan.UseVisualStyleBackColor = true;
            this.btnHistoScan.Click += new System.EventHandler(this.btnHistoScan_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(345, 536);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(127, 39);
            this.button12.TabIndex = 90;
            this.button12.Text = "SAVE";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ21
            // 
            this.chkBoxJ21.AutoSize = true;
            this.chkBoxJ21.Checked = true;
            this.chkBoxJ21.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ21.Location = new System.Drawing.Point(382, 98);
            this.chkBoxJ21.Name = "chkBoxJ21";
            this.chkBoxJ21.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ21.TabIndex = 106;
            this.chkBoxJ21.Text = "J21";
            this.chkBoxJ21.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ22
            // 
            this.chkBoxJ22.AutoSize = true;
            this.chkBoxJ22.Checked = true;
            this.chkBoxJ22.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ22.Location = new System.Drawing.Point(382, 128);
            this.chkBoxJ22.Name = "chkBoxJ22";
            this.chkBoxJ22.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ22.TabIndex = 105;
            this.chkBoxJ22.Text = "J22";
            this.chkBoxJ22.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ23
            // 
            this.chkBoxJ23.AutoSize = true;
            this.chkBoxJ23.Checked = true;
            this.chkBoxJ23.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ23.Location = new System.Drawing.Point(382, 158);
            this.chkBoxJ23.Name = "chkBoxJ23";
            this.chkBoxJ23.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ23.TabIndex = 104;
            this.chkBoxJ23.Text = "J23";
            this.chkBoxJ23.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ24
            // 
            this.chkBoxJ24.AutoSize = true;
            this.chkBoxJ24.Checked = true;
            this.chkBoxJ24.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ24.Location = new System.Drawing.Point(382, 188);
            this.chkBoxJ24.Name = "chkBoxJ24";
            this.chkBoxJ24.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ24.TabIndex = 103;
            this.chkBoxJ24.Text = "J24";
            this.chkBoxJ24.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ25
            // 
            this.chkBoxJ25.AutoSize = true;
            this.chkBoxJ25.Checked = true;
            this.chkBoxJ25.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ25.Location = new System.Drawing.Point(382, 218);
            this.chkBoxJ25.Name = "chkBoxJ25";
            this.chkBoxJ25.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ25.TabIndex = 102;
            this.chkBoxJ25.Text = "J25";
            this.chkBoxJ25.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ26
            // 
            this.chkBoxJ26.AutoSize = true;
            this.chkBoxJ26.Checked = true;
            this.chkBoxJ26.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ26.Location = new System.Drawing.Point(382, 248);
            this.chkBoxJ26.Name = "chkBoxJ26";
            this.chkBoxJ26.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ26.TabIndex = 101;
            this.chkBoxJ26.Text = "J26";
            this.chkBoxJ26.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ15
            // 
            this.chkBoxJ15.AutoSize = true;
            this.chkBoxJ15.Checked = true;
            this.chkBoxJ15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ15.Location = new System.Drawing.Point(318, 158);
            this.chkBoxJ15.Name = "chkBoxJ15";
            this.chkBoxJ15.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ15.TabIndex = 100;
            this.chkBoxJ15.Text = "J15";
            this.chkBoxJ15.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ16
            // 
            this.chkBoxJ16.AutoSize = true;
            this.chkBoxJ16.Checked = true;
            this.chkBoxJ16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ16.Location = new System.Drawing.Point(318, 188);
            this.chkBoxJ16.Name = "chkBoxJ16";
            this.chkBoxJ16.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ16.TabIndex = 99;
            this.chkBoxJ16.Text = "J16";
            this.chkBoxJ16.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ17
            // 
            this.chkBoxJ17.AutoSize = true;
            this.chkBoxJ17.Checked = true;
            this.chkBoxJ17.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ17.Location = new System.Drawing.Point(318, 218);
            this.chkBoxJ17.Name = "chkBoxJ17";
            this.chkBoxJ17.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ17.TabIndex = 98;
            this.chkBoxJ17.Text = "J17";
            this.chkBoxJ17.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ18
            // 
            this.chkBoxJ18.AutoSize = true;
            this.chkBoxJ18.Checked = true;
            this.chkBoxJ18.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ18.Location = new System.Drawing.Point(318, 248);
            this.chkBoxJ18.Name = "chkBoxJ18";
            this.chkBoxJ18.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ18.TabIndex = 97;
            this.chkBoxJ18.Text = "J18";
            this.chkBoxJ18.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ13
            // 
            this.chkBoxJ13.AutoSize = true;
            this.chkBoxJ13.Checked = true;
            this.chkBoxJ13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ13.Location = new System.Drawing.Point(318, 98);
            this.chkBoxJ13.Name = "chkBoxJ13";
            this.chkBoxJ13.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ13.TabIndex = 96;
            this.chkBoxJ13.Text = "J13";
            this.chkBoxJ13.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ14
            // 
            this.chkBoxJ14.AutoSize = true;
            this.chkBoxJ14.Checked = true;
            this.chkBoxJ14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ14.Location = new System.Drawing.Point(318, 128);
            this.chkBoxJ14.Name = "chkBoxJ14";
            this.chkBoxJ14.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ14.TabIndex = 95;
            this.chkBoxJ14.Text = "J14";
            this.chkBoxJ14.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ12
            // 
            this.chkBoxJ12.AutoSize = true;
            this.chkBoxJ12.Checked = true;
            this.chkBoxJ12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ12.Location = new System.Drawing.Point(318, 68);
            this.chkBoxJ12.Name = "chkBoxJ12";
            this.chkBoxJ12.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ12.TabIndex = 94;
            this.chkBoxJ12.Text = "J12";
            this.chkBoxJ12.UseVisualStyleBackColor = true;
            // 
            // chkBoxJ11
            // 
            this.chkBoxJ11.AutoSize = true;
            this.chkBoxJ11.Checked = true;
            this.chkBoxJ11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxJ11.Location = new System.Drawing.Point(318, 38);
            this.chkBoxJ11.Name = "chkBoxJ11";
            this.chkBoxJ11.Size = new System.Drawing.Size(58, 24);
            this.chkBoxJ11.TabIndex = 93;
            this.chkBoxJ11.Text = "J11";
            this.chkBoxJ11.UseVisualStyleBackColor = true;
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
            // CalibPType
            // 
            this.CalibPType.Controls.Add(this.txtHVTestComments);
            this.CalibPType.Controls.Add(this.label44);
            this.CalibPType.Controls.Add(this.label43);
            this.CalibPType.Controls.Add(this.label42);
            this.CalibPType.Controls.Add(this.label41);
            this.CalibPType.Controls.Add(this.label40);
            this.CalibPType.Controls.Add(this.label39);
            this.CalibPType.Controls.Add(this.btnSaveDB);
            this.CalibPType.Controls.Add(this.btnCalibrate);
            this.CalibPType.Controls.Add(this.btnBuildListView);
            this.CalibPType.Controls.Add(this.lblMuxTime);
            this.CalibPType.Controls.Add(this.lblScanTime);
            this.CalibPType.Controls.Add(this.lblScanSamples);
            this.CalibPType.Controls.Add(this.UpDnSamples);
            this.CalibPType.Controls.Add(this.btnZeroVoltages);
            this.CalibPType.Controls.Add(this.btnUpdateList);
            this.CalibPType.Controls.Add(this.lblSelectedChan);
            this.CalibPType.Controls.Add(this.label95);
            this.CalibPType.Controls.Add(this.txtVSet);
            this.CalibPType.Controls.Add(this.btnMuxTest);
            this.CalibPType.Controls.Add(this.btnSaveVScan);
            this.CalibPType.Controls.Add(this.label47);
            this.CalibPType.Controls.Add(this.btnFullVScan);
            this.CalibPType.Controls.Add(this.label37);
            this.CalibPType.Controls.Add(this.listView1);
            this.CalibPType.Location = new System.Drawing.Point(4, 32);
            this.CalibPType.Name = "CalibPType";
            this.CalibPType.Size = new System.Drawing.Size(1255, 665);
            this.CalibPType.TabIndex = 11;
            this.CalibPType.Text = "Calibration";
            this.CalibPType.UseVisualStyleBackColor = true;
            // 
            // txtHVTestComments
            // 
            this.txtHVTestComments.Location = new System.Drawing.Point(41, 403);
            this.txtHVTestComments.Multiline = true;
            this.txtHVTestComments.Name = "txtHVTestComments";
            this.txtHVTestComments.Size = new System.Drawing.Size(390, 126);
            this.txtHVTestComments.TabIndex = 32;
            this.txtHVTestComments.Text = "All HV channels OK.";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(7, 550);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(28, 25);
            this.label44.TabIndex = 29;
            this.label44.Text = "7.";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(7, 350);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(292, 50);
            this.label43.TabIndex = 28;
            this.label43.Text = "6.    Check the results.    -------->\r\n       Comments:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(7, 275);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(28, 25);
            this.label42.TabIndex = 27;
            this.label42.Text = "5.";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(7, 225);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(28, 25);
            this.label41.TabIndex = 26;
            this.label41.Text = "4.";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(7, 175);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(404, 25);
            this.label40.TabIndex = 25;
            this.label40.Text = "3.    Connect the HDMI cables from the DMM.";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(7, 125);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(28, 25);
            this.label39.TabIndex = 24;
            this.label39.Text = "2.";
            // 
            // btnSaveDB
            // 
            this.btnSaveDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDB.Location = new System.Drawing.Point(238, 543);
            this.btnSaveDB.Name = "btnSaveDB";
            this.btnSaveDB.Size = new System.Drawing.Size(146, 38);
            this.btnSaveDB.TabIndex = 23;
            this.btnSaveDB.Text = "Save DB File";
            this.btnSaveDB.UseVisualStyleBackColor = true;
            this.btnSaveDB.Click += new System.EventHandler(this.btnSaveDB_Click);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibrate.Location = new System.Drawing.Point(1020, 7);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(227, 40);
            this.btnCalibrate.TabIndex = 21;
            this.btnCalibrate.Text = "Load Calibrations";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            // 
            // btnBuildListView
            // 
            this.btnBuildListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuildListView.Location = new System.Drawing.Point(41, 218);
            this.btnBuildListView.Name = "btnBuildListView";
            this.btnBuildListView.Size = new System.Drawing.Size(219, 38);
            this.btnBuildListView.TabIndex = 20;
            this.btnBuildListView.Text = "Initialize Voltage List";
            this.btnBuildListView.UseVisualStyleBackColor = true;
            this.btnBuildListView.Click += new System.EventHandler(this.btnBuildListView_Click);
            // 
            // lblMuxTime
            // 
            this.lblMuxTime.AutoSize = true;
            this.lblMuxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMuxTime.Location = new System.Drawing.Point(157, 130);
            this.lblMuxTime.Name = "lblMuxTime";
            this.lblMuxTime.Size = new System.Drawing.Size(151, 18);
            this.lblMuxTime.TabIndex = 19;
            this.lblMuxTime.Text = "Scan Time: 00:00.000";
            // 
            // lblScanTime
            // 
            this.lblScanTime.AutoSize = true;
            this.lblScanTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanTime.Location = new System.Drawing.Point(197, 280);
            this.lblScanTime.Name = "lblScanTime";
            this.lblScanTime.Size = new System.Drawing.Size(151, 18);
            this.lblScanTime.TabIndex = 18;
            this.lblScanTime.Text = "Scan Time: 00:00.000";
            // 
            // lblScanSamples
            // 
            this.lblScanSamples.AutoSize = true;
            this.lblScanSamples.Location = new System.Drawing.Point(37, 309);
            this.lblScanSamples.Name = "lblScanSamples";
            this.lblScanSamples.Size = new System.Drawing.Size(174, 20);
            this.lblScanSamples.TabIndex = 17;
            this.lblScanSamples.Text = "Samples per Channel:";
            // 
            // UpDnSamples
            // 
            this.UpDnSamples.Location = new System.Drawing.Point(217, 307);
            this.UpDnSamples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDnSamples.Name = "UpDnSamples";
            this.UpDnSamples.Size = new System.Drawing.Size(54, 27);
            this.UpDnSamples.TabIndex = 16;
            this.UpDnSamples.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnZeroVoltages
            // 
            this.btnZeroVoltages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroVoltages.Location = new System.Drawing.Point(1123, 586);
            this.btnZeroVoltages.Name = "btnZeroVoltages";
            this.btnZeroVoltages.Size = new System.Drawing.Size(124, 36);
            this.btnZeroVoltages.TabIndex = 15;
            this.btnZeroVoltages.Text = "ZERO ALL";
            this.btnZeroVoltages.UseVisualStyleBackColor = true;
            this.btnZeroVoltages.Click += new System.EventHandler(this.btnZeroVoltages_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateList.Location = new System.Drawing.Point(912, 586);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(124, 36);
            this.btnUpdateList.TabIndex = 14;
            this.btnUpdateList.Text = "UPDATE";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // lblSelectedChan
            // 
            this.lblSelectedChan.AutoSize = true;
            this.lblSelectedChan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedChan.Location = new System.Drawing.Point(646, 592);
            this.lblSelectedChan.Name = "lblSelectedChan";
            this.lblSelectedChan.Size = new System.Drawing.Size(154, 25);
            this.lblSelectedChan.TabIndex = 13;
            this.lblSelectedChan.Text = "None Selected";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.Location = new System.Drawing.Point(432, 592);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(208, 25);
            this.label95.TabIndex = 12;
            this.label95.Text = "New Voltage Setting";
            // 
            // txtVSet
            // 
            this.txtVSet.Location = new System.Drawing.Point(806, 590);
            this.txtVSet.Name = "txtVSet";
            this.txtVSet.Size = new System.Drawing.Size(100, 27);
            this.txtVSet.TabIndex = 11;
            // 
            // btnMuxTest
            // 
            this.btnMuxTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuxTest.Location = new System.Drawing.Point(41, 118);
            this.btnMuxTest.Name = "btnMuxTest";
            this.btnMuxTest.Size = new System.Drawing.Size(110, 38);
            this.btnMuxTest.TabIndex = 8;
            this.btnMuxTest.Text = "Mux Test";
            this.btnMuxTest.UseVisualStyleBackColor = true;
            this.btnMuxTest.Click += new System.EventHandler(this.btnMuxTest_Click);
            // 
            // btnSaveVScan
            // 
            this.btnSaveVScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveVScan.Location = new System.Drawing.Point(41, 543);
            this.btnSaveVScan.Name = "btnSaveVScan";
            this.btnSaveVScan.Size = new System.Drawing.Size(191, 38);
            this.btnSaveVScan.TabIndex = 7;
            this.btnSaveVScan.Text = "Save Calibrations";
            this.btnSaveVScan.UseVisualStyleBackColor = true;
            this.btnSaveVScan.Click += new System.EventHandler(this.btnSaveVScan_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(432, 13);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(204, 29);
            this.label47.TabIndex = 3;
            this.label47.Text = "Voltage Settings";
            // 
            // btnFullVScan
            // 
            this.btnFullVScan.Enabled = false;
            this.btnFullVScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullVScan.Location = new System.Drawing.Point(41, 268);
            this.btnFullVScan.Name = "btnFullVScan";
            this.btnFullVScan.Size = new System.Drawing.Size(150, 38);
            this.btnFullVScan.TabIndex = 1;
            this.btnFullVScan.Text = "Voltage Scan";
            this.btnFullVScan.UseVisualStyleBackColor = true;
            this.btnFullVScan.Click += new System.EventHandler(this.btnFullVScan_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(7, 50);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(382, 50);
            this.label37.TabIndex = 22;
            this.label37.Text = "1.    Make sure the FEB is connected\r\n       but the HDMI cables are disconnected" +
    ".";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Channel,
            this.HDMI,
            this.Setting,
            this.Measurement,
            this.IsCalibrated,
            this.Gain,
            this.Offset,
            this.MuxCurrent});
            listViewGroup1.Header = "FPGA 0";
            listViewGroup1.Name = "fpga0";
            listViewGroup2.Header = "FPGA 1";
            listViewGroup2.Name = "fpga1";
            listViewGroup3.Header = "FPGA 2";
            listViewGroup3.Name = "fpga2";
            listViewGroup4.Header = "FPGA 3";
            listViewGroup4.Name = "fpga3";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.listView1.Location = new System.Drawing.Point(437, 53);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(810, 527);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // Channel
            // 
            this.Channel.Text = "Channel";
            this.Channel.Width = 100;
            // 
            // HDMI
            // 
            this.HDMI.Text = "HDMI";
            // 
            // Setting
            // 
            this.Setting.Text = "Setting";
            this.Setting.Width = 70;
            // 
            // Measurement
            // 
            this.Measurement.Text = "Measurement";
            this.Measurement.Width = 120;
            // 
            // IsCalibrated
            // 
            this.IsCalibrated.Text = "Calibrations Applied?";
            this.IsCalibrated.Width = 180;
            // 
            // Gain
            // 
            this.Gain.Text = "Gain";
            // 
            // Offset
            // 
            this.Offset.Text = "Offset";
            // 
            // MuxCurrent
            // 
            this.MuxCurrent.Text = "Mux Current (nA)";
            this.MuxCurrent.Width = 150;
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileCalibrations
            // 
            this.saveFileCalibrations.DefaultExt = "\"dsf\"";
            this.saveFileCalibrations.Filter = "\"FEB calibration files (*.dsf)|*.dsf|All files (*.*)|*.*\"";
            this.saveFileCalibrations.FilterIndex = 2;
            this.saveFileCalibrations.InitialDirectory = "\"c:\\\\data\\\\\"";
            this.saveFileCalibrations.RestoreDirectory = true;
            // 
            // saveFileMeasurements
            // 
            this.saveFileMeasurements.DefaultExt = "\"txt\"";
            this.saveFileMeasurements.FilterIndex = 2;
            this.saveFileMeasurements.InitialDirectory = "\"c:\\\\data\\\\\"";
            this.saveFileMeasurements.RestoreDirectory = true;
            // 
            // saveFileDB
            // 
            this.saveFileDB.DefaultExt = "csv";
            this.saveFileDB.FilterIndex = 2;
            this.saveFileDB.InitialDirectory = "\"c:\\\\data\\\\\"";
            this.saveFileDB.RestoreDirectory = true;
            // 
            // timerTempRB
            // 
            this.timerTempRB.Interval = 1000;
            this.timerTempRB.Tick += new System.EventHandler(this.timerTempRB_Tick);
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
            this.tabStart.ResumeLayout(false);
            this.tabStart.PerformLayout();
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
            this.tabHist.ResumeLayout(false);
            this.tabHist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHistIntegralTime)).EndInit();
            this.CalibPType.ResumeLayout(false);
            this.CalibPType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDnSamples)).EndInit();
            this.tabConsole.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabRUN.ResumeLayout(false);
            this.tabRUN.PerformLayout();
            this.groupBoxEvDisplay.ResumeLayout(false);
            this.groupBoxEvDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_VertMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_VertMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabWC.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.Button btnSnSave;
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
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabHist;
        private System.Windows.Forms.Label labelTempHist;
        private ZedGraph.ZedGraphControl zedGraphHisto;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnSetV;
        private System.Windows.Forms.Button btnSelHiHist;
        private System.Windows.Forms.Button btnSelLowHist;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ListBox listBoxHistos;
        private System.Windows.Forms.CheckBox chkBoxJ19;
        private System.Windows.Forms.CheckBox chkBoxJ20;
        public System.Windows.Forms.Button btnHistoScan;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.CheckBox chkBoxJ21;
        private System.Windows.Forms.CheckBox chkBoxJ22;
        private System.Windows.Forms.CheckBox chkBoxJ23;
        private System.Windows.Forms.CheckBox chkBoxJ24;
        private System.Windows.Forms.CheckBox chkBoxJ25;
        private System.Windows.Forms.CheckBox chkBoxJ26;
        private System.Windows.Forms.CheckBox chkBoxJ15;
        private System.Windows.Forms.CheckBox chkBoxJ16;
        private System.Windows.Forms.CheckBox chkBoxJ17;
        private System.Windows.Forms.CheckBox chkBoxJ18;
        private System.Windows.Forms.CheckBox chkBoxJ13;
        private System.Windows.Forms.CheckBox chkBoxJ14;
        private System.Windows.Forms.CheckBox chkBoxJ12;
        private System.Windows.Forms.CheckBox chkBoxJ11;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TabPage CalibPType;
        private System.Windows.Forms.Button btnFullVScan;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button btnSaveVScan;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Channel;
        private System.Windows.Forms.ColumnHeader Gain;
        private System.Windows.Forms.ColumnHeader Offset;
        private System.Windows.Forms.ColumnHeader IsCalibrated;
        private System.Windows.Forms.ColumnHeader MuxCurrent;
        private System.Windows.Forms.Button btnMuxTest;
        private System.Windows.Forms.ColumnHeader Setting;
        private System.Windows.Forms.ColumnHeader Measurement;
        private System.Windows.Forms.ColumnHeader HDMI;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.TextBox txtVSet;
        private System.Windows.Forms.Label lblSelectedChan;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.Button btnZeroVoltages;
        private System.Windows.Forms.Label lblScanSamples;
        private System.Windows.Forms.NumericUpDown UpDnSamples;
        private System.Windows.Forms.Label lblMuxTime;
        private System.Windows.Forms.Label lblScanTime;
        private System.Windows.Forms.Button btnBuildListView;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Button btnSaveDB;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.SaveFileDialog saveFileCalibrations;
        private System.Windows.Forms.TextBox txtHVTestComments;
        private System.Windows.Forms.SaveFileDialog saveFileMeasurements;
        private System.Windows.Forms.SaveFileDialog saveFileDB;
        private System.Windows.Forms.TabPage tabStart;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnConnectFEB;
        private System.Windows.Forms.TextBox txtFEBAddress;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtFEBseries;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtTestType;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnDisconnectFEB;
        private System.Windows.Forms.Timer timerTempRB;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtTestLocation;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.CheckBox chkLogYHist;
        private System.Windows.Forms.NumericUpDown udHistIntegralTime;
        private System.Windows.Forms.Label label9;
    }
}