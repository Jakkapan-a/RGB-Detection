using DirectShowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Detection
{
    public partial class Main : Form
    {
        private bool isConnect = false;
        public string[] baudList = { "9600", "19200", "38400", "57600", "115200" };
        private int driveindex = 0;
        private TCapture.Capture capture;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            scrolPictureBox.isScrol= true;
            capture = new TCapture.Capture();
            capture.OnFrameHeadler += Capture_OnFrameHeadler;
            capture.OnVideoStarted += Capture_OnVideoStarted;
            capture.OnVideoStop += Capture_OnVideoStop;
            // Set size capture
            capture.frameRate = 100;
            btRefresh.PerformClick();
            timer_get.Interval = 1000;
            timer_get.Start();
        }

        private void Capture_OnVideoStop()
        {
            if (scrolPictureBox.InvokeRequired)
            {
                scrolPictureBox.Invoke(new Action(()=>scrolPictureBox.Image = null));
                return;
            }
            scrolPictureBox.Image = null;
        }

        Rectangle rect = new Rectangle();
        private void Capture_OnVideoStarted()
        {
            //rect = scrolPictureBox.Rect;
        }

        private delegate void FrameVideo(Bitmap bitmap);
        Bitmap bmp;
        private void Capture_OnFrameHeadler(Bitmap bitmap)
        {
            if (scrolPictureBox.InvokeRequired)
            {
                scrolPictureBox.Invoke(new FrameVideo(Capture_OnFrameHeadler), bitmap);
                return;
            }
            scrolPictureBox.SuspendLayout();
            scrolPictureBox.Image = (Image)bitmap.Clone();
            rect = scrolPictureBox._Rectangle;
            if (rect != Rectangle.Empty){
                // Crop image to picture box RGB
                bmp = new Bitmap(rect.Width, rect.Height);
                
                using(Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(scrolPictureBox.Image, new Rectangle(0, 0, bmp.Width, bmp.Height), rect, GraphicsUnit.Pixel);
                }
                pictureBoxRGB.Image = (Image)bmp.Clone();
                // Center of the picture box
            }
            scrolPictureBox.ResumeLayout();
        }

        private void timer_get_Tick(object sender, EventArgs e)
        {
            if (bmp != null && scrolPictureBox._Rectangle != Rectangle.Empty && rect != Rectangle.Empty)
            {
                //Center of the picture box
                int x = bmp.Width / 2;
                int y = bmp.Height / 2;
                Color pixelColor = ((Bitmap)bmp.Clone()).GetPixel(x, y);
                // Get the RGB values
                txtRed.Text = pixelColor.R.ToString();
                txtGreen.Text = pixelColor.G.ToString();
                txtBlue.Text = pixelColor.B.ToString();
                // Test Process
                    
                //
            }        
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                isConnect = !isConnect;
                if (isConnect)
                {
                // Check if the camera is connected
                if (comboBoxCamera.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a camera");
                    return;
                }

                // Check if the COM port is connected
                if (comboBoxCOMPort.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a COM port");
                    return;
                }

                // Check if the baud rate is selected
                if (comboBoxBaud.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a baud rate");
                    return;
                }

                if (capture.IsOpened)
                {
                    capture.Stop();
                }
                driveindex = comboBoxCamera.SelectedIndex;

                Task.Factory.StartNew(() => capture.Start(driveindex));

                btConnect.Text = "Disconnect";
                }
                else
                {
                if (capture.IsOpened)
                {
                    capture.Stop();
                }
                btConnect.Text = "Connect";
                }
            }
            catch (Exception ex)
            {
                isConnect = false;
                Console.WriteLine(ex.Message);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            var videoDevices = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));
            comboBoxCamera.Items.Clear();
            foreach (DsDevice device in videoDevices)
            {
                comboBoxCamera.Items.Add(device.Name);
            }

            if (comboBoxCamera.Items.Count > 0)
            {
                comboBoxCamera.SelectedIndex = 0;
            }

            comboBoxBaud.Items.Clear();
            comboBoxBaud.Items.AddRange(this.baudList);
            if (comboBoxBaud.Items.Count > 0)
                comboBoxBaud.SelectedIndex = comboBoxBaud.Items.Count - 1;

            comboBoxCOMPort.Items.Clear();
            comboBoxCOMPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxCOMPort.Items.Count > 0)
                comboBoxCOMPort.SelectedIndex = 0;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(capture.IsOpened)
            {
                capture.Stop();
                capture.Dispose();
            }
        }
    }
}
