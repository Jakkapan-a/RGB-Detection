using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_V2.Forms
{
    public partial class SelectXY : Form
    {
        private Main main;
        public SelectXY(Main m)
        {
            InitializeComponent();
            main = m;
        }

        private void SelectXY_Load(object sender, EventArgs e)
        {
            if (main != null)
            {
                timer1.Start();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!scrollablePictureBox1.GetRect().IsEmpty)
            {
                Properties.Settings.Default.Rect = scrollablePictureBox1.GetRect();
                Properties.Settings.Default.Save();
                this.Close();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (main.pictureBoxCamera.Image != null)
            {
                scrollablePictureBox1.Image?.Dispose();
                scrollablePictureBox1.Image = (Image)main.pictureBoxCamera.Image.Clone();
            }

        }

        private void SelectXY_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void scrollablePictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
