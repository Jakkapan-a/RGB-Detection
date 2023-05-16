namespace RGB_V2
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            menuStrip1 = new MenuStrip();
            systemToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusFrameRate = new ToolStripStatusLabel();
            toolStripStatusSerialData = new ToolStripStatusLabel();
            toolStripStatusLabelStatus = new ToolStripStatusLabel();
            toolStripStatusSentData = new ToolStripStatusLabel();
            toolStripStatusLabelRect = new ToolStripStatusLabel();
            toolStripStatusLabelTimeRGB = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            pictureBoxCamera = new PictureBox();
            lbResult = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            lbR = new Label();
            label5 = new Label();
            panel2 = new Panel();
            lbG = new Label();
            label6 = new Label();
            panel3 = new Panel();
            lbB = new Label();
            label7 = new Label();
            pictureBoxRGB = new PictureBox();
            groupBox1 = new GroupBox();
            cbAverageRGB = new CheckBox();
            pictureBox1 = new PictureBox();
            btReload = new Button();
            btConnect = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbCOM = new ComboBox();
            cbBaud = new ComboBox();
            cbDrive = new ComboBox();
            lbColor = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRGB).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { systemToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1040, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editToolStripMenuItem });
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            systemToolStripMenuItem.Size = new Size(57, 20);
            systemToolStripMenuItem.Text = "System";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.edit_property_32;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(180, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusFrameRate, toolStripStatusSerialData, toolStripStatusLabelStatus, toolStripStatusSentData, toolStripStatusLabelRect, toolStripStatusLabelTimeRGB });
            statusStrip1.Location = new Point(0, 623);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1040, 24);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusFrameRate
            // 
            toolStripStatusFrameRate.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusFrameRate.Name = "toolStripStatusFrameRate";
            toolStripStatusFrameRate.Size = new Size(16, 19);
            toolStripStatusFrameRate.Text = "-";
            // 
            // toolStripStatusSerialData
            // 
            toolStripStatusSerialData.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusSerialData.Name = "toolStripStatusSerialData";
            toolStripStatusSerialData.Size = new Size(16, 19);
            toolStripStatusSerialData.Text = "-";
            // 
            // toolStripStatusLabelStatus
            // 
            toolStripStatusLabelStatus.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            toolStripStatusLabelStatus.Size = new Size(16, 19);
            toolStripStatusLabelStatus.Text = "-";
            // 
            // toolStripStatusSentData
            // 
            toolStripStatusSentData.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusSentData.Name = "toolStripStatusSentData";
            toolStripStatusSentData.Size = new Size(16, 19);
            toolStripStatusSentData.Text = "-";
            // 
            // toolStripStatusLabelRect
            // 
            toolStripStatusLabelRect.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusLabelRect.Name = "toolStripStatusLabelRect";
            toolStripStatusLabelRect.Size = new Size(16, 19);
            toolStripStatusLabelRect.Text = "-";
            // 
            // toolStripStatusLabelTimeRGB
            // 
            toolStripStatusLabelTimeRGB.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusLabelTimeRGB.Name = "toolStripStatusLabelTimeRGB";
            toolStripStatusLabelTimeRGB.Size = new Size(16, 19);
            toolStripStatusLabelTimeRGB.Text = "-";
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBoxCamera);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lbResult);
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel2.Controls.Add(pictureBoxRGB);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2.Controls.Add(lbColor);
            splitContainer1.Size = new Size(1040, 599);
            splitContainer1.SplitterDistance = 791;
            splitContainer1.TabIndex = 2;
            // 
            // pictureBoxCamera
            // 
            pictureBoxCamera.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxCamera.BackColor = Color.Black;
            pictureBoxCamera.Location = new Point(12, 19);
            pictureBoxCamera.Name = "pictureBoxCamera";
            pictureBoxCamera.Size = new Size(765, 565);
            pictureBoxCamera.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCamera.TabIndex = 0;
            pictureBoxCamera.TabStop = false;
            // 
            // lbResult
            // 
            lbResult.Anchor = AnchorStyles.Top;
            lbResult.BackColor = Color.Yellow;
            lbResult.BorderStyle = BorderStyle.FixedSingle;
            lbResult.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lbResult.Location = new Point(9, 211);
            lbResult.Name = "lbResult";
            lbResult.Size = new Size(231, 138);
            lbResult.TabIndex = 7;
            lbResult.Text = "Wait";
            lbResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 2, 0);
            tableLayoutPanel1.Location = new Point(9, 135);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(222, 71);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(lbR);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(63, 59);
            panel1.TabIndex = 0;
            // 
            // lbR
            // 
            lbR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbR.BackColor = SystemColors.ButtonFace;
            lbR.Location = new Point(0, 28);
            lbR.Name = "lbR";
            lbR.Size = new Size(65, 31);
            lbR.TabIndex = 7;
            lbR.Text = "-";
            lbR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(22, 6);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 0;
            label5.Text = "R";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Controls.Add(lbG);
            panel2.Controls.Add(label6);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(78, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(63, 59);
            panel2.TabIndex = 0;
            // 
            // lbG
            // 
            lbG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbG.BackColor = SystemColors.ButtonFace;
            lbG.Location = new Point(-3, 28);
            lbG.Name = "lbG";
            lbG.Size = new Size(66, 31);
            lbG.TabIndex = 7;
            lbG.Text = "-";
            lbG.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(20, 6);
            label6.Name = "label6";
            label6.Size = new Size(15, 15);
            label6.TabIndex = 0;
            label6.Text = "G";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Controls.Add(lbB);
            panel3.Controls.Add(label7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(150, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(66, 59);
            panel3.TabIndex = 0;
            // 
            // lbB
            // 
            lbB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbB.BackColor = SystemColors.ButtonFace;
            lbB.Location = new Point(0, 28);
            lbB.Name = "lbB";
            lbB.Size = new Size(66, 31);
            lbB.TabIndex = 7;
            lbB.Text = "-";
            lbB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(24, 6);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 0;
            label7.Text = "B";
            // 
            // pictureBoxRGB
            // 
            pictureBoxRGB.Anchor = AnchorStyles.Top;
            pictureBoxRGB.BackColor = Color.Black;
            pictureBoxRGB.Location = new Point(77, 19);
            pictureBoxRGB.Name = "pictureBoxRGB";
            pictureBoxRGB.Size = new Size(88, 80);
            pictureBoxRGB.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRGB.TabIndex = 4;
            pictureBoxRGB.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(cbAverageRGB);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(btReload);
            groupBox1.Controls.Add(btConnect);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbCOM);
            groupBox1.Controls.Add(cbBaud);
            groupBox1.Controls.Add(cbDrive);
            groupBox1.Location = new Point(3, 353);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(237, 215);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "SETTING";
            // 
            // cbAverageRGB
            // 
            cbAverageRGB.AutoSize = true;
            cbAverageRGB.Location = new Point(71, 80);
            cbAverageRGB.Name = "cbAverageRGB";
            cbAverageRGB.Size = new Size(91, 19);
            cbAverageRGB.TabIndex = 8;
            cbAverageRGB.Text = "AverageRGB";
            cbAverageRGB.UseVisualStyleBackColor = true;
            cbAverageRGB.CheckedChanged += cbAverageRGB_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImage = Properties.Resources.camera_logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(73, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(106, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btReload
            // 
            btReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btReload.BackgroundImage = Properties.Resources._refresh_32;
            btReload.BackgroundImageLayout = ImageLayout.Zoom;
            btReload.Location = new Point(6, 186);
            btReload.Name = "btReload";
            btReload.Size = new Size(24, 23);
            btReload.TabIndex = 3;
            btReload.UseVisualStyleBackColor = true;
            btReload.Click += btReload_Click;
            // 
            // btConnect
            // 
            btConnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btConnect.Location = new Point(156, 186);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(75, 23);
            btConnect.TabIndex = 4;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += btConnect_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 157);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 1;
            label4.Text = "COM :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 128);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 1;
            label3.Text = "Baud :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 102);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 1;
            label2.Text = "Drive :";
            // 
            // cbCOM
            // 
            cbCOM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCOM.FormattingEnabled = true;
            cbCOM.Location = new Point(71, 157);
            cbCOM.Name = "cbCOM";
            cbCOM.Size = new Size(158, 23);
            cbCOM.TabIndex = 2;
            // 
            // cbBaud
            // 
            cbBaud.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbBaud.FormattingEnabled = true;
            cbBaud.Location = new Point(71, 128);
            cbBaud.Name = "cbBaud";
            cbBaud.Size = new Size(158, 23);
            cbBaud.TabIndex = 1;
            // 
            // cbDrive
            // 
            cbDrive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbDrive.FormattingEnabled = true;
            cbDrive.Location = new Point(71, 99);
            cbDrive.Name = "cbDrive";
            cbDrive.Size = new Size(158, 23);
            cbDrive.TabIndex = 0;
            // 
            // lbColor
            // 
            lbColor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbColor.BorderStyle = BorderStyle.Fixed3D;
            lbColor.Location = new Point(64, 102);
            lbColor.Name = "lbColor";
            lbColor.Size = new Size(115, 30);
            lbColor.TabIndex = 5;
            lbColor.Text = "-";
            lbColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 647);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1056, 686);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "731TMCx";
            WindowState = FormWindowState.Maximized;
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRGB).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem systemToolStripMenuItem;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Button btReload;
        private Button btConnect;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cbCOM;
        private ComboBox cbBaud;
        private ComboBox cbDrive;
        private PictureBox pictureBoxRGB;
        private Label lbColor;
        private ToolStripStatusLabel toolStripStatusFrameRate;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lbR;
        private Label lbG;
        private Label lbB;
        private Label lbResult;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusSerialData;
        private ToolStripStatusLabel toolStripStatusLabelStatus;
        public PictureBox pictureBoxCamera;
        private CheckBox cbAverageRGB;
        private ToolStripStatusLabel toolStripStatusSentData;
        private ToolStripStatusLabel toolStripStatusLabelRect;
        private ToolStripStatusLabel toolStripStatusLabelTimeRGB;
    }
}