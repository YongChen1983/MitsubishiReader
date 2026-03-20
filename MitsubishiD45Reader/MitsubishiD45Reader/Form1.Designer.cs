namespace MitsubishiD45Reader
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblStation = new System.Windows.Forms.Label();
            this.numStation = new System.Windows.Forms.NumericUpDown();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnExportAllRecipes = new System.Windows.Forms.Button();
            this.grpDevice = new System.Windows.Forms.GroupBox();
            this.lblDevice = new System.Windows.Forms.Label();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblCurrentValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblWriteValue = new System.Windows.Forms.Label();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAsciiInline = new System.Windows.Forms.Label();
            this.grpBit = new System.Windows.Forms.GroupBox();
            this.lblX1396 = new System.Windows.Forms.Label();
            this.txtX1396 = new System.Windows.Forms.TextBox();
            this.lblX1396Block = new System.Windows.Forms.Label();
            this.txtX1396Block = new System.Windows.Forms.TextBox();
            this.lblX1396Bit = new System.Windows.Forms.Label();
            this.numX1396Bit = new System.Windows.Forms.NumericUpDown();
            this.btnReadX1396 = new System.Windows.Forms.Button();
            this.chkXUseHex = new System.Windows.Forms.CheckBox();
            this.lblBitDevice = new System.Windows.Forms.Label();
            this.txtBitDevice = new System.Windows.Forms.TextBox();
            this.lblBitValue = new System.Windows.Forms.Label();
            this.txtBitValue = new System.Windows.Forms.TextBox();
            this.btnReadBit = new System.Windows.Forms.Button();
            this.lblBitWriteValue = new System.Windows.Forms.Label();
            this.txtBitWriteValue = new System.Windows.Forms.TextBox();
            this.btnWriteBit = new System.Windows.Forms.Button();
            this.grpFixedMonitor = new System.Windows.Forms.GroupBox();
            this.lblD6202 = new System.Windows.Forms.Label();
            this.lblExportStyle = new System.Windows.Forms.Label();
            this.txtD6202 = new System.Windows.Forms.TextBox();
            this.txtExportStyle = new System.Windows.Forms.TextBox();
            this.lblExportCode = new System.Windows.Forms.Label();
            this.lblD6005 = new System.Windows.Forms.Label();
            this.txtExportCode = new System.Windows.Forms.TextBox();
            this.txtD6005 = new System.Windows.Forms.TextBox();
            this.btnModelLoginMode = new System.Windows.Forms.Button();
            this.btnModelCfgRead = new System.Windows.Forms.Button();
            this.btnModelCfgWrite = new System.Windows.Forms.Button();
            this.btnExportMonitorExcel = new System.Windows.Forms.Button();
            this.grpD2460Ascii = new System.Windows.Forms.GroupBox();
            this.lblExportFieldsHint = new System.Windows.Forms.Label();
            this.lblD2460AsciiHint = new System.Windows.Forms.Label();
            this.lblDStart = new System.Windows.Forms.Label();
            this.txtDStart = new System.Windows.Forms.TextBox();
            this.lblDEnd = new System.Windows.Forms.Label();
            this.txtDEnd = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.numIntervalMs = new System.Windows.Forms.NumericUpDown();
            this.chkD2460HiByteFirst = new System.Windows.Forms.CheckBox();
            this.btnReadD2460Ascii = new System.Windows.Forms.Button();
            this.btnStartTimerRead = new System.Windows.Forms.Button();
            this.btnStopTimerRead = new System.Windows.Forms.Button();
            this.txtD2460Ascii = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numStation)).BeginInit();
            this.grpDevice.SuspendLayout();
            this.grpBit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numX1396Bit)).BeginInit();
            this.grpFixedMonitor.SuspendLayout();
            this.grpD2460Ascii.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalMs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(21, 25);
            this.lblStation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(139, 15);
            this.lblStation.TabIndex = 0;
            this.lblStation.Text = "逻辑站号 (1-256):";
            // 
            // numStation
            // 
            this.numStation.Location = new System.Drawing.Point(152, 23);
            this.numStation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numStation.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numStation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStation.Name = "numStation";
            this.numStation.Size = new System.Drawing.Size(96, 25);
            this.numStation.TabIndex = 1;
            this.numStation.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(267, 20);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 30);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(375, 20);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(100, 30);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnExportAllRecipes
            // 
            this.btnExportAllRecipes.Enabled = false;
            this.btnExportAllRecipes.Location = new System.Drawing.Point(436, 38);
            this.btnExportAllRecipes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExportAllRecipes.Name = "btnExportAllRecipes";
            this.btnExportAllRecipes.Size = new System.Drawing.Size(226, 34);
            this.btnExportAllRecipes.TabIndex = 20;
            this.btnExportAllRecipes.Text = "读取全部配方并导出 Excel";
            this.btnExportAllRecipes.UseVisualStyleBackColor = true;
            this.btnExportAllRecipes.Click += new System.EventHandler(this.btnExportAllRecipes_Click);
            // 
            // grpDevice
            // 
            this.grpDevice.Controls.Add(this.lblDevice);
            this.grpDevice.Controls.Add(this.txtDevice);
            this.grpDevice.Controls.Add(this.btnRead);
            this.grpDevice.Controls.Add(this.lblCurrentValue);
            this.grpDevice.Controls.Add(this.txtValue);
            this.grpDevice.Controls.Add(this.lblWriteValue);
            this.grpDevice.Controls.Add(this.txtWriteValue);
            this.grpDevice.Controls.Add(this.btnWrite);
            this.grpDevice.Location = new System.Drawing.Point(20, 58);
            this.grpDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpDevice.Name = "grpDevice";
            this.grpDevice.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpDevice.Size = new System.Drawing.Size(837, 100);
            this.grpDevice.TabIndex = 4;
            this.grpDevice.TabStop = false;
            this.grpDevice.Text = "字软元件 (D/R/W 等)";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(14, 32);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(90, 15);
            this.lblDevice.TabIndex = 0;
            this.lblDevice.Text = "存储器地址:";
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(113, 29);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(88, 25);
            this.txtDevice.TabIndex = 1;
            this.txtDevice.Text = "D45";
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(213, 27);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(82, 28);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblCurrentValue
            // 
            this.lblCurrentValue.AutoSize = true;
            this.lblCurrentValue.Location = new System.Drawing.Point(14, 68);
            this.lblCurrentValue.Name = "lblCurrentValue";
            this.lblCurrentValue.Size = new System.Drawing.Size(60, 15);
            this.lblCurrentValue.TabIndex = 2;
            this.lblCurrentValue.Text = "当前值:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(111, 64);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(88, 25);
            this.txtValue.TabIndex = 3;
            this.txtValue.Text = "--";
            // 
            // lblWriteValue
            // 
            this.lblWriteValue.AutoSize = true;
            this.lblWriteValue.Location = new System.Drawing.Point(211, 68);
            this.lblWriteValue.Name = "lblWriteValue";
            this.lblWriteValue.Size = new System.Drawing.Size(60, 15);
            this.lblWriteValue.TabIndex = 5;
            this.lblWriteValue.Text = "写入值:";
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(274, 64);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(88, 25);
            this.txtWriteValue.TabIndex = 6;
            this.txtWriteValue.Text = "0";
            // 
            // btnWrite
            // 
            this.btnWrite.Enabled = false;
            this.btnWrite.Location = new System.Drawing.Point(303, 27);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(82, 28);
            this.btnWrite.TabIndex = 7;
            this.btnWrite.Text = "写入";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(20, 656);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(98, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "状态: 未连接";
            // 
            // lblAsciiInline
            // 
            this.lblAsciiInline.AutoSize = true;
            this.lblAsciiInline.ForeColor = System.Drawing.Color.Red;
            this.lblAsciiInline.Location = new System.Drawing.Point(125, 656);
            this.lblAsciiInline.Name = "lblAsciiInline";
            this.lblAsciiInline.Size = new System.Drawing.Size(79, 15);
            this.lblAsciiInline.TabIndex = 8;
            this.lblAsciiInline.Text = "ASCII: --";
            // 
            // grpBit
            // 
            this.grpBit.Controls.Add(this.lblX1396);
            this.grpBit.Controls.Add(this.txtX1396);
            this.grpBit.Controls.Add(this.lblX1396Block);
            this.grpBit.Controls.Add(this.txtX1396Block);
            this.grpBit.Controls.Add(this.lblX1396Bit);
            this.grpBit.Controls.Add(this.numX1396Bit);
            this.grpBit.Controls.Add(this.btnReadX1396);
            this.grpBit.Controls.Add(this.chkXUseHex);
            this.grpBit.Controls.Add(this.lblBitDevice);
            this.grpBit.Controls.Add(this.txtBitDevice);
            this.grpBit.Controls.Add(this.lblBitValue);
            this.grpBit.Controls.Add(this.txtBitValue);
            this.grpBit.Controls.Add(this.btnReadBit);
            this.grpBit.Controls.Add(this.lblBitWriteValue);
            this.grpBit.Controls.Add(this.txtBitWriteValue);
            this.grpBit.Controls.Add(this.btnWriteBit);
            this.grpBit.Location = new System.Drawing.Point(20, 168);
            this.grpBit.Name = "grpBit";
            this.grpBit.Size = new System.Drawing.Size(837, 88);
            this.grpBit.TabIndex = 6;
            this.grpBit.TabStop = false;
            this.grpBit.Text = "位软元件 (X/M/Y 等)";
            this.grpBit.Enter += new System.EventHandler(this.grpBit_Enter);
            // 
            // lblX1396
            // 
            this.lblX1396.AutoSize = true;
            this.lblX1396.Location = new System.Drawing.Point(14, 28);
            this.lblX1396.Name = "lblX1396";
            this.lblX1396.Size = new System.Drawing.Size(55, 15);
            this.lblX1396.TabIndex = 0;
            this.lblX1396.Text = "X1396:";
            // 
            // txtX1396
            // 
            this.txtX1396.Location = new System.Drawing.Point(79, 25);
            this.txtX1396.Name = "txtX1396";
            this.txtX1396.ReadOnly = true;
            this.txtX1396.Size = new System.Drawing.Size(72, 25);
            this.txtX1396.TabIndex = 1;
            this.txtX1396.Text = "--";
            // 
            // lblX1396Block
            // 
            this.lblX1396Block.AutoSize = true;
            this.lblX1396Block.Location = new System.Drawing.Point(158, 28);
            this.lblX1396Block.Name = "lblX1396Block";
            this.lblX1396Block.Size = new System.Drawing.Size(60, 15);
            this.lblX1396Block.TabIndex = 13;
            this.lblX1396Block.Text = "块地址:";
            // 
            // txtX1396Block
            // 
            this.txtX1396Block.Location = new System.Drawing.Point(224, 25);
            this.txtX1396Block.Name = "txtX1396Block";
            this.txtX1396Block.Size = new System.Drawing.Size(58, 25);
            this.txtX1396Block.TabIndex = 14;
            this.txtX1396Block.Text = "X1396";
            // 
            // lblX1396Bit
            // 
            this.lblX1396Bit.AutoSize = true;
            this.lblX1396Bit.Location = new System.Drawing.Point(290, 25);
            this.lblX1396Bit.Name = "lblX1396Bit";
            this.lblX1396Bit.Size = new System.Drawing.Size(85, 15);
            this.lblX1396Bit.TabIndex = 10;
            this.lblX1396Bit.Text = "X1396取位:";
            // 
            // numX1396Bit
            // 
            this.numX1396Bit.Location = new System.Drawing.Point(392, 18);
            this.numX1396Bit.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numX1396Bit.Name = "numX1396Bit";
            this.numX1396Bit.Size = new System.Drawing.Size(48, 25);
            this.numX1396Bit.TabIndex = 11;
            // 
            // btnReadX1396
            // 
            this.btnReadX1396.Enabled = false;
            this.btnReadX1396.Location = new System.Drawing.Point(484, 23);
            this.btnReadX1396.Name = "btnReadX1396";
            this.btnReadX1396.Size = new System.Drawing.Size(100, 28);
            this.btnReadX1396.TabIndex = 2;
            this.btnReadX1396.Text = "读取 X1396";
            this.btnReadX1396.UseVisualStyleBackColor = true;
            this.btnReadX1396.Click += new System.EventHandler(this.btnReadX1396_Click);
            // 
            // chkXUseHex
            // 
            this.chkXUseHex.AutoSize = true;
            this.chkXUseHex.Location = new System.Drawing.Point(590, 27);
            this.chkXUseHex.Name = "chkXUseHex";
            this.chkXUseHex.Size = new System.Drawing.Size(112, 19);
            this.chkXUseHex.TabIndex = 12;
            this.chkXUseHex.Text = "X用十六进制";
            this.chkXUseHex.UseVisualStyleBackColor = true;
            // 
            // lblBitDevice
            // 
            this.lblBitDevice.AutoSize = true;
            this.lblBitDevice.Location = new System.Drawing.Point(14, 58);
            this.lblBitDevice.Name = "lblBitDevice";
            this.lblBitDevice.Size = new System.Drawing.Size(60, 15);
            this.lblBitDevice.TabIndex = 3;
            this.lblBitDevice.Text = "位地址:";
            // 
            // txtBitDevice
            // 
            this.txtBitDevice.Location = new System.Drawing.Point(79, 54);
            this.txtBitDevice.Name = "txtBitDevice";
            this.txtBitDevice.Size = new System.Drawing.Size(72, 25);
            this.txtBitDevice.TabIndex = 4;
            this.txtBitDevice.Text = "M1";
            // 
            // lblBitValue
            // 
            this.lblBitValue.AutoSize = true;
            this.lblBitValue.Location = new System.Drawing.Point(152, 58);
            this.lblBitValue.Name = "lblBitValue";
            this.lblBitValue.Size = new System.Drawing.Size(30, 15);
            this.lblBitValue.TabIndex = 5;
            this.lblBitValue.Text = "值:";
            // 
            // txtBitValue
            // 
            this.txtBitValue.Location = new System.Drawing.Point(199, 54);
            this.txtBitValue.Name = "txtBitValue";
            this.txtBitValue.ReadOnly = true;
            this.txtBitValue.Size = new System.Drawing.Size(88, 25);
            this.txtBitValue.TabIndex = 6;
            this.txtBitValue.Text = "--";
            // 
            // btnReadBit
            // 
            this.btnReadBit.Enabled = false;
            this.btnReadBit.Location = new System.Drawing.Point(303, 54);
            this.btnReadBit.Name = "btnReadBit";
            this.btnReadBit.Size = new System.Drawing.Size(72, 28);
            this.btnReadBit.TabIndex = 7;
            this.btnReadBit.Text = "读取";
            this.btnReadBit.UseVisualStyleBackColor = true;
            this.btnReadBit.Click += new System.EventHandler(this.btnReadBit_Click);
            // 
            // lblBitWriteValue
            // 
            this.lblBitWriteValue.AutoSize = true;
            this.lblBitWriteValue.Location = new System.Drawing.Point(389, 58);
            this.lblBitWriteValue.Name = "lblBitWriteValue";
            this.lblBitWriteValue.Size = new System.Drawing.Size(60, 15);
            this.lblBitWriteValue.TabIndex = 8;
            this.lblBitWriteValue.Text = "写入值:";
            // 
            // txtBitWriteValue
            // 
            this.txtBitWriteValue.Location = new System.Drawing.Point(540, 54);
            this.txtBitWriteValue.Name = "txtBitWriteValue";
            this.txtBitWriteValue.Size = new System.Drawing.Size(42, 25);
            this.txtBitWriteValue.TabIndex = 9;
            this.txtBitWriteValue.Text = "0";
            // 
            // btnWriteBit
            // 
            this.btnWriteBit.Enabled = false;
            this.btnWriteBit.Location = new System.Drawing.Point(590, 52);
            this.btnWriteBit.Name = "btnWriteBit";
            this.btnWriteBit.Size = new System.Drawing.Size(72, 28);
            this.btnWriteBit.TabIndex = 10;
            this.btnWriteBit.Text = "写入";
            this.btnWriteBit.UseVisualStyleBackColor = true;
            this.btnWriteBit.Click += new System.EventHandler(this.btnWriteBit_Click);
            // 
            // grpFixedMonitor
            // 
            this.grpFixedMonitor.Controls.Add(this.lblD6202);
            this.grpFixedMonitor.Controls.Add(this.lblExportStyle);
            this.grpFixedMonitor.Controls.Add(this.txtD6202);
            this.grpFixedMonitor.Controls.Add(this.txtExportStyle);
            this.grpFixedMonitor.Controls.Add(this.lblExportCode);
            this.grpFixedMonitor.Controls.Add(this.lblD6005);
            this.grpFixedMonitor.Controls.Add(this.btnExportAllRecipes);
            this.grpFixedMonitor.Controls.Add(this.txtExportCode);
            this.grpFixedMonitor.Controls.Add(this.txtD6005);
            this.grpFixedMonitor.Controls.Add(this.btnModelLoginMode);
            this.grpFixedMonitor.Controls.Add(this.btnModelCfgRead);
            this.grpFixedMonitor.Controls.Add(this.btnModelCfgWrite);
            this.grpFixedMonitor.Controls.Add(this.btnExportMonitorExcel);
            this.grpFixedMonitor.Location = new System.Drawing.Point(20, 262);
            this.grpFixedMonitor.Name = "grpFixedMonitor";
            this.grpFixedMonitor.Size = new System.Drawing.Size(837, 158);
            this.grpFixedMonitor.TabIndex = 7;
            this.grpFixedMonitor.TabStop = false;
            this.grpFixedMonitor.Text = "定点监视 (定时读取时自动刷新)";
            // 
            // lblD6202
            // 
            this.lblD6202.AutoSize = true;
            this.lblD6202.Location = new System.Drawing.Point(14, 27);
            this.lblD6202.Name = "lblD6202";
            this.lblD6202.Size = new System.Drawing.Size(93, 15);
            this.lblD6202.TabIndex = 0;
            this.lblD6202.Text = "编号 D6202:";
            // 
            // lblExportStyle
            // 
            this.lblExportStyle.AutoSize = true;
            this.lblExportStyle.Location = new System.Drawing.Point(10, 94);
            this.lblExportStyle.Name = "lblExportStyle";
            this.lblExportStyle.Size = new System.Drawing.Size(156, 15);
            this.lblExportStyle.TabIndex = 15;
            this.lblExportStyle.Text = "样式 (D6010～6017):";
            // 
            // txtD6202
            // 
            this.txtD6202.Location = new System.Drawing.Point(117, 23);
            this.txtD6202.Name = "txtD6202";
            this.txtD6202.ReadOnly = true;
            this.txtD6202.Size = new System.Drawing.Size(70, 25);
            this.txtD6202.TabIndex = 1;
            this.txtD6202.Text = "--";
            // 
            // txtExportStyle
            // 
            this.txtExportStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportStyle.Location = new System.Drawing.Point(172, 91);
            this.txtExportStyle.Name = "txtExportStyle";
            this.txtExportStyle.ReadOnly = true;
            this.txtExportStyle.Size = new System.Drawing.Size(509, 25);
            this.txtExportStyle.TabIndex = 16;
            this.txtExportStyle.Text = "--";
            // 
            // lblExportCode
            // 
            this.lblExportCode.AutoSize = true;
            this.lblExportCode.Location = new System.Drawing.Point(10, 124);
            this.lblExportCode.Name = "lblExportCode";
            this.lblExportCode.Size = new System.Drawing.Size(156, 15);
            this.lblExportCode.TabIndex = 17;
            this.lblExportCode.Text = "代码 (D6020～6027):";
            // 
            // lblD6005
            // 
            this.lblD6005.AutoSize = true;
            this.lblD6005.Location = new System.Drawing.Point(14, 57);
            this.lblD6005.Name = "lblD6005";
            this.lblD6005.Size = new System.Drawing.Size(93, 15);
            this.lblD6005.TabIndex = 2;
            this.lblD6005.Text = "车型 D6005:";
            // 
            // txtExportCode
            // 
            this.txtExportCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportCode.Location = new System.Drawing.Point(172, 121);
            this.txtExportCode.Name = "txtExportCode";
            this.txtExportCode.ReadOnly = true;
            this.txtExportCode.Size = new System.Drawing.Size(509, 25);
            this.txtExportCode.TabIndex = 18;
            this.txtExportCode.Text = "--";
            // 
            // txtD6005
            // 
            this.txtD6005.Location = new System.Drawing.Point(117, 53);
            this.txtD6005.Name = "txtD6005";
            this.txtD6005.ReadOnly = true;
            this.txtD6005.Size = new System.Drawing.Size(70, 25);
            this.txtD6005.TabIndex = 3;
            this.txtD6005.Text = "--";
            // 
            // btnModelLoginMode
            // 
            this.btnModelLoginMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModelLoginMode.Enabled = false;
            this.btnModelLoginMode.FlatAppearance.BorderSize = 0;
            this.btnModelLoginMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelLoginMode.Location = new System.Drawing.Point(697, 18);
            this.btnModelLoginMode.Name = "btnModelLoginMode";
            this.btnModelLoginMode.Size = new System.Drawing.Size(128, 32);
            this.btnModelLoginMode.TabIndex = 8;
            this.btnModelLoginMode.Text = "车型登陆模式";
            this.btnModelLoginMode.UseVisualStyleBackColor = false;
            this.btnModelLoginMode.Click += new System.EventHandler(this.btnModelLoginMode_Click);
            // 
            // btnModelCfgRead
            // 
            this.btnModelCfgRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModelCfgRead.Enabled = false;
            this.btnModelCfgRead.Location = new System.Drawing.Point(697, 56);
            this.btnModelCfgRead.Name = "btnModelCfgRead";
            this.btnModelCfgRead.Size = new System.Drawing.Size(128, 28);
            this.btnModelCfgRead.TabIndex = 9;
            this.btnModelCfgRead.Text = "读取";
            this.btnModelCfgRead.UseVisualStyleBackColor = true;
            this.btnModelCfgRead.Click += new System.EventHandler(this.btnModelCfgRead_Click);
            // 
            // btnModelCfgWrite
            // 
            this.btnModelCfgWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModelCfgWrite.Enabled = false;
            this.btnModelCfgWrite.Location = new System.Drawing.Point(697, 90);
            this.btnModelCfgWrite.Name = "btnModelCfgWrite";
            this.btnModelCfgWrite.Size = new System.Drawing.Size(128, 28);
            this.btnModelCfgWrite.TabIndex = 10;
            this.btnModelCfgWrite.Text = "写入";
            this.btnModelCfgWrite.UseVisualStyleBackColor = true;
            this.btnModelCfgWrite.Click += new System.EventHandler(this.btnModelCfgWrite_Click);
            // 
            // btnExportMonitorExcel
            // 
            this.btnExportMonitorExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportMonitorExcel.Enabled = false;
            this.btnExportMonitorExcel.Location = new System.Drawing.Point(697, 124);
            this.btnExportMonitorExcel.Name = "btnExportMonitorExcel";
            this.btnExportMonitorExcel.Size = new System.Drawing.Size(128, 32);
            this.btnExportMonitorExcel.TabIndex = 11;
            this.btnExportMonitorExcel.Text = "读取并导出 excel";
            this.btnExportMonitorExcel.UseVisualStyleBackColor = true;
            this.btnExportMonitorExcel.Click += new System.EventHandler(this.btnExportMonitorExcel_Click);
            // 
            // grpD2460Ascii
            // 
            this.grpD2460Ascii.Controls.Add(this.lblExportFieldsHint);
            this.grpD2460Ascii.Controls.Add(this.lblD2460AsciiHint);
            this.grpD2460Ascii.Controls.Add(this.lblDStart);
            this.grpD2460Ascii.Controls.Add(this.txtDStart);
            this.grpD2460Ascii.Controls.Add(this.lblDEnd);
            this.grpD2460Ascii.Controls.Add(this.txtDEnd);
            this.grpD2460Ascii.Controls.Add(this.lblInterval);
            this.grpD2460Ascii.Controls.Add(this.numIntervalMs);
            this.grpD2460Ascii.Controls.Add(this.chkD2460HiByteFirst);
            this.grpD2460Ascii.Controls.Add(this.btnReadD2460Ascii);
            this.grpD2460Ascii.Controls.Add(this.btnStartTimerRead);
            this.grpD2460Ascii.Controls.Add(this.btnStopTimerRead);
            this.grpD2460Ascii.Controls.Add(this.txtD2460Ascii);
            this.grpD2460Ascii.Location = new System.Drawing.Point(20, 428);
            this.grpD2460Ascii.Name = "grpD2460Ascii";
            this.grpD2460Ascii.Size = new System.Drawing.Size(837, 218);
            this.grpD2460Ascii.TabIndex = 7;
            this.grpD2460Ascii.TabStop = false;
            this.grpD2460Ascii.Text = "D 区间 ASCII 显示/定时读取";
            // 
            // lblExportFieldsHint
            // 
            this.lblExportFieldsHint.AutoSize = true;
            this.lblExportFieldsHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblExportFieldsHint.Location = new System.Drawing.Point(14, 200);
            this.lblExportFieldsHint.Name = "lblExportFieldsHint";
            this.lblExportFieldsHint.Size = new System.Drawing.Size(956, 15);
            this.lblExportFieldsHint.TabIndex = 14;
            this.lblExportFieldsHint.Text = "导出用：D 区间读取/定时时读 D6010～6017、D6020～6027；显示时去掉尾部空字节占位「·」与空白，遇英文句点「.」则句点及之后不显示";
            // 
            // lblD2460AsciiHint
            // 
            this.lblD2460AsciiHint.AutoSize = true;
            this.lblD2460AsciiHint.Location = new System.Drawing.Point(14, 28);
            this.lblD2460AsciiHint.Name = "lblD2460AsciiHint";
            this.lblD2460AsciiHint.Size = new System.Drawing.Size(439, 15);
            this.lblD2460AsciiHint.TabIndex = 0;
            this.lblD2460AsciiHint.Text = "默认与 GX「W+ASC」相同：先低字节再高字节；不可显显示为 ·";
            // 
            // lblDStart
            // 
            this.lblDStart.AutoSize = true;
            this.lblDStart.Location = new System.Drawing.Point(14, 58);
            this.lblDStart.Name = "lblDStart";
            this.lblDStart.Size = new System.Drawing.Size(91, 15);
            this.lblDStart.TabIndex = 4;
            this.lblDStart.Text = "起始地址 D:";
            // 
            // txtDStart
            // 
            this.txtDStart.Location = new System.Drawing.Point(113, 54);
            this.txtDStart.Name = "txtDStart";
            this.txtDStart.Size = new System.Drawing.Size(60, 25);
            this.txtDStart.TabIndex = 5;
            this.txtDStart.Text = "2460";
            // 
            // lblDEnd
            // 
            this.lblDEnd.AutoSize = true;
            this.lblDEnd.Location = new System.Drawing.Point(220, 58);
            this.lblDEnd.Name = "lblDEnd";
            this.lblDEnd.Size = new System.Drawing.Size(91, 15);
            this.lblDEnd.TabIndex = 6;
            this.lblDEnd.Text = "结束地址 D:";
            // 
            // txtDEnd
            // 
            this.txtDEnd.Location = new System.Drawing.Point(317, 54);
            this.txtDEnd.Name = "txtDEnd";
            this.txtDEnd.Size = new System.Drawing.Size(60, 25);
            this.txtDEnd.TabIndex = 7;
            this.txtDEnd.Text = "2472";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(394, 58);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(107, 15);
            this.lblInterval.TabIndex = 8;
            this.lblInterval.Text = "定时周期(ms):";
            // 
            // numIntervalMs
            // 
            this.numIntervalMs.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numIntervalMs.Location = new System.Drawing.Point(510, 54);
            this.numIntervalMs.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numIntervalMs.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numIntervalMs.Name = "numIntervalMs";
            this.numIntervalMs.Size = new System.Drawing.Size(80, 25);
            this.numIntervalMs.TabIndex = 9;
            this.numIntervalMs.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // chkD2460HiByteFirst
            // 
            this.chkD2460HiByteFirst.AutoSize = true;
            this.chkD2460HiByteFirst.Location = new System.Drawing.Point(436, 27);
            this.chkD2460HiByteFirst.Name = "chkD2460HiByteFirst";
            this.chkD2460HiByteFirst.Size = new System.Drawing.Size(134, 19);
            this.chkD2460HiByteFirst.TabIndex = 1;
            this.chkD2460HiByteFirst.Text = "每字高字节在前";
            this.chkD2460HiByteFirst.UseVisualStyleBackColor = true;
            // 
            // btnReadD2460Ascii
            // 
            this.btnReadD2460Ascii.Enabled = false;
            this.btnReadD2460Ascii.Location = new System.Drawing.Point(606, 52);
            this.btnReadD2460Ascii.Name = "btnReadD2460Ascii";
            this.btnReadD2460Ascii.Size = new System.Drawing.Size(58, 28);
            this.btnReadD2460Ascii.TabIndex = 10;
            this.btnReadD2460Ascii.Text = "读取";
            this.btnReadD2460Ascii.UseVisualStyleBackColor = true;
            this.btnReadD2460Ascii.Click += new System.EventHandler(this.btnReadD2460Ascii_Click);
            // 
            // btnStartTimerRead
            // 
            this.btnStartTimerRead.Enabled = false;
            this.btnStartTimerRead.Location = new System.Drawing.Point(668, 52);
            this.btnStartTimerRead.Name = "btnStartTimerRead";
            this.btnStartTimerRead.Size = new System.Drawing.Size(58, 28);
            this.btnStartTimerRead.TabIndex = 11;
            this.btnStartTimerRead.Text = "开始";
            this.btnStartTimerRead.UseVisualStyleBackColor = true;
            this.btnStartTimerRead.Click += new System.EventHandler(this.btnStartTimerRead_Click);
            // 
            // btnStopTimerRead
            // 
            this.btnStopTimerRead.Enabled = false;
            this.btnStopTimerRead.Location = new System.Drawing.Point(730, 52);
            this.btnStopTimerRead.Name = "btnStopTimerRead";
            this.btnStopTimerRead.Size = new System.Drawing.Size(56, 28);
            this.btnStopTimerRead.TabIndex = 12;
            this.btnStopTimerRead.Text = "停止";
            this.btnStopTimerRead.UseVisualStyleBackColor = true;
            this.btnStopTimerRead.Click += new System.EventHandler(this.btnStopTimerRead_Click);
            // 
            // txtD2460Ascii
            // 
            this.txtD2460Ascii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtD2460Ascii.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD2460Ascii.Location = new System.Drawing.Point(14, 86);
            this.txtD2460Ascii.Multiline = true;
            this.txtD2460Ascii.Name = "txtD2460Ascii";
            this.txtD2460Ascii.ReadOnly = true;
            this.txtD2460Ascii.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtD2460Ascii.Size = new System.Drawing.Size(806, 101);
            this.txtD2460Ascii.TabIndex = 13;
            this.txtD2460Ascii.Text = "（连接后点击「读取」）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 688);
            this.Controls.Add(this.grpD2460Ascii);
            this.Controls.Add(this.grpFixedMonitor);
            this.Controls.Add(this.grpBit);
            this.Controls.Add(this.lblAsciiInline);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpDevice);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.numStation);
            this.Controls.Add(this.lblStation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "三菱 MX Component - 存储器读写";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numStation)).EndInit();
            this.grpDevice.ResumeLayout(false);
            this.grpDevice.PerformLayout();
            this.grpBit.ResumeLayout(false);
            this.grpBit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numX1396Bit)).EndInit();
            this.grpFixedMonitor.ResumeLayout(false);
            this.grpFixedMonitor.PerformLayout();
            this.grpD2460Ascii.ResumeLayout(false);
            this.grpD2460Ascii.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalMs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.NumericUpDown numStation;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnExportAllRecipes;
        private System.Windows.Forms.GroupBox grpDevice;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.Label lblCurrentValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblWriteValue;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAsciiInline;
        private System.Windows.Forms.GroupBox grpBit;
        private System.Windows.Forms.GroupBox grpFixedMonitor;
        private System.Windows.Forms.Label lblX1396;
        private System.Windows.Forms.TextBox txtX1396;
        private System.Windows.Forms.Label lblX1396Block;
        private System.Windows.Forms.TextBox txtX1396Block;
        private System.Windows.Forms.Label lblX1396Bit;
        private System.Windows.Forms.NumericUpDown numX1396Bit;
        private System.Windows.Forms.Button btnReadX1396;
        private System.Windows.Forms.CheckBox chkXUseHex;
        private System.Windows.Forms.Label lblBitDevice;
        private System.Windows.Forms.TextBox txtBitDevice;
        private System.Windows.Forms.Label lblBitValue;
        private System.Windows.Forms.TextBox txtBitValue;
        private System.Windows.Forms.Button btnReadBit;
        private System.Windows.Forms.Label lblBitWriteValue;
        private System.Windows.Forms.TextBox txtBitWriteValue;
        private System.Windows.Forms.Button btnWriteBit;
        private System.Windows.Forms.GroupBox grpD2460Ascii;
        private System.Windows.Forms.Label lblD2460AsciiHint;
        private System.Windows.Forms.Label lblDStart;
        private System.Windows.Forms.TextBox txtDStart;
        private System.Windows.Forms.Label lblDEnd;
        private System.Windows.Forms.TextBox txtDEnd;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown numIntervalMs;
        private System.Windows.Forms.CheckBox chkD2460HiByteFirst;
        private System.Windows.Forms.Button btnReadD2460Ascii;
        private System.Windows.Forms.Button btnStartTimerRead;
        private System.Windows.Forms.Button btnStopTimerRead;
        private System.Windows.Forms.TextBox txtD2460Ascii;
        private System.Windows.Forms.Label lblD6202;
        private System.Windows.Forms.TextBox txtD6202;
        private System.Windows.Forms.Label lblD6005;
        private System.Windows.Forms.TextBox txtD6005;
        private System.Windows.Forms.Label lblExportFieldsHint;
        private System.Windows.Forms.Label lblExportStyle;
        private System.Windows.Forms.TextBox txtExportStyle;
        private System.Windows.Forms.Label lblExportCode;
        private System.Windows.Forms.TextBox txtExportCode;
        private System.Windows.Forms.Button btnModelLoginMode;
        private System.Windows.Forms.Button btnModelCfgRead;
        private System.Windows.Forms.Button btnModelCfgWrite;
        private System.Windows.Forms.Button btnExportMonitorExcel;
    }
}
