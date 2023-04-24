namespace RGB_V2.Forms
{
    partial class SelectXY
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectXY));
            statusStrip1 = new StatusStrip();
            panel1 = new Panel();
            scrollablePictureBox1 = new Constrols.ScrollablePictureBox();
            btSave = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scrollablePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 604);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(956, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(scrollablePictureBox1);
            panel1.Location = new Point(16, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(928, 539);
            panel1.TabIndex = 1;
            // 
            // scrollablePictureBox1
            // 
            scrollablePictureBox1.Location = new Point(3, 3);
            scrollablePictureBox1.Name = "scrollablePictureBox1";
            scrollablePictureBox1.SegmentedRegions = null;
            scrollablePictureBox1.Size = new Size(905, 524);
            scrollablePictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            scrollablePictureBox1.TabIndex = 0;
            scrollablePictureBox1.TabStop = false;
            scrollablePictureBox1.MouseUp += scrollablePictureBox1_MouseUp;
            // 
            // btSave
            // 
            btSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btSave.Location = new Point(869, 570);
            btSave.Name = "btSave";
            btSave.Size = new Size(75, 23);
            btSave.TabIndex = 2;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // SelectXY
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 626);
            Controls.Add(btSave);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectXY";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectXY";
            FormClosing += SelectXY_FormClosing;
            Load += SelectXY_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scrollablePictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private Panel panel1;
        private Button btSave;
        private Constrols.ScrollablePictureBox scrollablePictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}