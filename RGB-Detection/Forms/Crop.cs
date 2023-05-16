using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Detection.Forms
{
    public partial class Crop : Form
    {
        private Main main;
        public Crop(Main main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void Crop_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(main.scrollPictureBox.Image == null)
            {
                return;
            }

            scrollablePictureBox1.Image?.Dispose();
            scrollablePictureBox1.Image = (Image)main.scrollPictureBox.Image.Clone();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!scrollablePictureBox1.GetRect().IsEmpty)
            {
                var rect =  scrollablePictureBox1.GetRect();
                main.SaveRectangle(rect);
                this.Close();
            }
        }
    }
}
