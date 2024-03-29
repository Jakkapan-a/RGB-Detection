﻿namespace RGB_Detection
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scrollPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.cbAv = new System.Windows.Forms.CheckBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.txtBlue = new System.Windows.Forms.TextBox();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.lbB = new System.Windows.Forms.Label();
            this.lbG = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbR = new System.Windows.Forms.Label();
            this.pictureBoxRGB = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCamera = new System.Windows.Forms.ComboBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusConnectSerialPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSentData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusParameter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSerialData = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_get = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollPictureBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.scrollPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(892, 504);
            this.splitContainer1.SplitterDistance = 655;
            this.splitContainer1.TabIndex = 0;
            // 
            // scrollPictureBox
            // 
            this.scrollPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollPictureBox.BackColor = System.Drawing.Color.Black;
            this.scrollPictureBox.Location = new System.Drawing.Point(17, 14);
            this.scrollPictureBox.Name = "scrollPictureBox";
            this.scrollPictureBox.Size = new System.Drawing.Size(621, 465);
            this.scrollPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.scrollPictureBox.TabIndex = 0;
            this.scrollPictureBox.TabStop = false;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.cbAv);
            this.groupBox.Controls.Add(this.lbResult);
            this.groupBox.Controls.Add(this.txtBlue);
            this.groupBox.Controls.Add(this.txtGreen);
            this.groupBox.Controls.Add(this.txtRed);
            this.groupBox.Controls.Add(this.lbB);
            this.groupBox.Controls.Add(this.lbG);
            this.groupBox.Controls.Add(this.lbColor);
            this.groupBox.Controls.Add(this.lbR);
            this.groupBox.Controls.Add(this.pictureBoxRGB);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(225, 306);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Setting";
            // 
            // cbAv
            // 
            this.cbAv.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbAv.AutoSize = true;
            this.cbAv.Checked = true;
            this.cbAv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAv.Location = new System.Drawing.Point(71, 285);
            this.cbAv.Name = "cbAv";
            this.cbAv.Size = new System.Drawing.Size(89, 17);
            this.cbAv.TabIndex = 5;
            this.cbAv.Text = "AverageRGB";
            this.cbAv.UseVisualStyleBackColor = true;
            this.cbAv.CheckedChanged += new System.EventHandler(this.cbAv_CheckedChanged);
            // 
            // lbResult
            // 
            this.lbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbResult.BackColor = System.Drawing.Color.Yellow;
            this.lbResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResult.Location = new System.Drawing.Point(33, 208);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(161, 69);
            this.lbResult.TabIndex = 4;
            this.lbResult.Text = "WAIT";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBlue
            // 
            this.txtBlue.Location = new System.Drawing.Point(47, 165);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(77, 20);
            this.txtBlue.TabIndex = 3;
            // 
            // txtGreen
            // 
            this.txtGreen.Location = new System.Drawing.Point(47, 136);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(77, 20);
            this.txtGreen.TabIndex = 3;
            // 
            // txtRed
            // 
            this.txtRed.Location = new System.Drawing.Point(48, 110);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(76, 20);
            this.txtRed.TabIndex = 3;
            // 
            // lbB
            // 
            this.lbB.AutoSize = true;
            this.lbB.Location = new System.Drawing.Point(17, 168);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(14, 13);
            this.lbB.TabIndex = 2;
            this.lbB.Text = "B";
            // 
            // lbG
            // 
            this.lbG.AutoSize = true;
            this.lbG.Location = new System.Drawing.Point(16, 139);
            this.lbG.Name = "lbG";
            this.lbG.Size = new System.Drawing.Size(15, 13);
            this.lbG.TabIndex = 2;
            this.lbG.Text = "G";
            // 
            // lbColor
            // 
            this.lbColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbColor.Location = new System.Drawing.Point(88, 75);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(45, 20);
            this.lbColor.TabIndex = 2;
            this.lbColor.Text = "-------";
            this.lbColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbR
            // 
            this.lbR.AutoSize = true;
            this.lbR.Location = new System.Drawing.Point(16, 111);
            this.lbR.Name = "lbR";
            this.lbR.Size = new System.Drawing.Size(15, 13);
            this.lbR.TabIndex = 2;
            this.lbR.Text = "R";
            // 
            // pictureBoxRGB
            // 
            this.pictureBoxRGB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxRGB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRGB.Location = new System.Drawing.Point(60, 19);
            this.pictureBoxRGB.Name = "pictureBoxRGB";
            this.pictureBoxRGB.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxRGB.TabIndex = 0;
            this.pictureBoxRGB.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxCOMPort);
            this.groupBox1.Controls.Add(this.comboBoxBaud);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxCamera);
            this.groupBox1.Controls.Add(this.btConnect);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.btRefresh);
            this.groupBox1.Location = new System.Drawing.Point(3, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "COM Port :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Baud :";
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(99, 117);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(111, 21);
            this.comboBoxCOMPort.TabIndex = 18;
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(99, 88);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(111, 21);
            this.comboBoxBaud.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Drive Camera :";
            // 
            // comboBoxCamera
            // 
            this.comboBoxCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCamera.FormattingEnabled = true;
            this.comboBoxCamera.Location = new System.Drawing.Point(99, 57);
            this.comboBoxCamera.Name = "comboBoxCamera";
            this.comboBoxCamera.Size = new System.Drawing.Size(111, 21);
            this.comboBoxCamera.TabIndex = 16;
            // 
            // btConnect
            // 
            this.btConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btConnect.Location = new System.Drawing.Point(144, 155);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackgroundImage = global::RGB_Detection.Properties.Resources.camera_logo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(71, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 37);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.BackgroundImage = global::RGB_Detection.Properties.Resources._refresh_32;
            this.btRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btRefresh.Location = new System.Drawing.Point(6, 155);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(25, 23);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLogin,
            this.toolStripStatusConnectSerialPort,
            this.toolStripStatusSentData,
            this.toolStripStatusParameter,
            this.toolStripStatusSerialData});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(916, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLogin
            // 
            this.toolStripStatusLogin.Name = "toolStripStatusLogin";
            this.toolStripStatusLogin.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusLogin.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusConnectSerialPort
            // 
            this.toolStripStatusConnectSerialPort.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusConnectSerialPort.Name = "toolStripStatusConnectSerialPort";
            this.toolStripStatusConnectSerialPort.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusConnectSerialPort.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusSentData
            // 
            this.toolStripStatusSentData.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusSentData.Name = "toolStripStatusSentData";
            this.toolStripStatusSentData.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusSentData.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusParameter
            // 
            this.toolStripStatusParameter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusParameter.Name = "toolStripStatusParameter";
            this.toolStripStatusParameter.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusParameter.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusSerialData
            // 
            this.toolStripStatusSerialData.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusSerialData.Name = "toolStripStatusSerialData";
            this.toolStripStatusSerialData.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusSerialData.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.parameterToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Image = global::RGB_Detection.Properties.Resources._password_32;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.loginToolStripMenuItem.Text = "Set";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Visible = false;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // parameterToolStripMenuItem
            // 
            this.parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            this.parameterToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.parameterToolStripMenuItem.Text = "Parameter";
            this.parameterToolStripMenuItem.Visible = false;
            // 
            // timer_get
            // 
            this.timer_get.Interval = 500;
            this.timer_get.Tick += new System.EventHandler(this.timer_get_Tick);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 578);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(932, 575);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "731TMCx";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrollPictureBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxRGB;
        private System.Windows.Forms.Label lbB;
        private System.Windows.Forms.Label lbG;
        private System.Windows.Forms.Label lbR;
        private System.Windows.Forms.TextBox txtBlue;
        private System.Windows.Forms.TextBox txtGreen;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCOMPort;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCamera;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer_get;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.ToolStripMenuItem parameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusConnectSerialPort;
        public System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSentData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusParameter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSerialData;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLogin;
        private System.Windows.Forms.Label lbResult;
        public System.Windows.Forms.PictureBox scrollPictureBox;
        private System.Windows.Forms.CheckBox cbAv;
    }
}

