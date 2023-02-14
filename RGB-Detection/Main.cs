using DirectShowLib;
using LogWriter;
using RGB_Detection.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
        Rectangle rect;

        private LogFile LogWriter;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            scrollPictureBox.isScroll= false;
            capture = new TCapture.Capture();
            capture.OnFrameHeadler += Capture_OnFrameHeadler;
            capture.OnVideoStarted += Capture_OnVideoStarted;
            capture.OnVideoStop += Capture_OnVideoStop;
            btRefresh.PerformClick();
       
            loadRectangle();
            if(rect != Rectangle.Empty)
            {
                scrollPictureBox.SetRectangle(rect);
            }
            LogWriter = new LogFile();
            LogWriter.SaveLog("Satrting...");

        
            // Status tool strip clear
            foreach (ToolStripItem item in statusStrip1.Items)
            {
                item.Text = "";
            }
        }
        private void SaveRectangle()
        {
            rect = scrollPictureBox.Rect;
            if (rect != Rectangle.Empty && scrollPictureBox.isScroll)
            {
                Properties.Settings.Default.rect_x = rect.X;
                Properties.Settings.Default.rect_y = rect.Y;
                Properties.Settings.Default.rect_width = rect.Width;
                Properties.Settings.Default.rect_height = rect.Height;
                Properties.Settings.Default.Save();

                scrollPictureBox.isScroll = false;
                loginToolStripMenuItem.Text = "Login";
                toolStripStatusLogin.Text = "Logout";
                saveToolStripMenuItem.Visible = false;
                MessageBox.Show("Save Rectangle Success", "Save Rectangle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Please select a rectangle or login", "Save Rectangle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadRectangle(){
            if(Properties.Settings.Default.rect_x != 0 && Properties.Settings.Default.rect_y != 0 && Properties.Settings.Default.rect_width != 0 && Properties.Settings.Default.rect_height != 0)
            {
                rect = new Rectangle(Properties.Settings.Default.rect_x, Properties.Settings.Default.rect_y, Properties.Settings.Default.rect_width, Properties.Settings.Default.rect_height);
                toolStripStatusParameter.Text = "Rectangle: X=" + rect.X + ", Y=" + rect.Y + ", Width=" + rect.Width + ", Height=" + rect.Height;
            }
        }
        private void Capture_OnVideoStop()
        {
           
            if (scrollPictureBox.InvokeRequired)
            {
                scrollPictureBox.Invoke(new Action(()=>{
                    scrollPictureBox.Image = null;
                    timer_get.Stop();
                }));
                return;
            }
            scrollPictureBox.Image = null;
  
        }
            
        private void Capture_OnVideoStarted()
        {
            Invoke(new Action(() => {
                timer_get.Start();
            }));
        }

        private delegate void FrameVideo(Bitmap bitmap);
        Bitmap bmp;
        private void Capture_OnFrameHeadler(Bitmap bitmap)
        {
            if (scrollPictureBox.InvokeRequired)
            {
                scrollPictureBox.Invoke(new FrameVideo(Capture_OnFrameHeadler), bitmap);
                return;
            }
            scrollPictureBox.SuspendLayout();
            scrollPictureBox.Image = (Image)bitmap.Clone();
            if (scrollPictureBox.isScroll)
            {
                rect = scrollPictureBox._Rectangle;
            }
            if (rect != Rectangle.Empty){
                // Crop image to picture box RGB
                if(bmp != null)
                {
                    bmp.Dispose();  
                }
                bmp = new Bitmap(rect.Width, rect.Height);
                
                using(Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(scrollPictureBox.Image, new Rectangle(0, 0, bmp.Width, bmp.Height), rect, GraphicsUnit.Pixel);
                }
                pictureBoxRGB.Image = (Image)bmp.Clone();
            }
            scrollPictureBox.ResumeLayout();
        }
        private int isColorChange = 0;
        private void timer_get_Tick(object sender, EventArgs e)
        {
            if (bmp != null && scrollPictureBox._Rectangle != Rectangle.Empty && rect != Rectangle.Empty)
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
                // Green color
                if (pixelColor.R < 130 && pixelColor.G > 125 && pixelColor.B < 130)
                {
                    // Send data to Arduino
                    // ...
                    lbColor.Text = "Green";
                    // if(isColorChange != 1)
                    // {
                    //     serialCommand("1");
                    //     isColorChange = 1;
                    // }
                    serialCommand("1");
                }else
                // Red color
                if (pixelColor.R > 150 && pixelColor.G < 120 && pixelColor.B < 140)
                {
                    // Send data to Arduino
                    // ...
                    lbColor.Text = "Red";
                    serialCommand("2");
                    isColorChange = 2;
                }else
                // Red color
                if (pixelColor.R > 80 && pixelColor.R < 140 && pixelColor.G < 90 && pixelColor.B < 90)
                {
                    // Send data to Arduino
                    // ...
                    lbColor.Text = "Red";
                    serialCommand("2");
                    isColorChange = 2;
                }else
                // Blue color
                if (pixelColor.R < 100 && pixelColor.G < 100 && pixelColor.B > 100)
                {
                    // Send data to Arduino
                    // ...
                    lbColor.Text = "Blue";
                    serialCommand("3");
                    isColorChange = 3;
                }
                else
                // Black color
                if (pixelColor.R < 50 && pixelColor.G < 50 && pixelColor.B < 50)
                {
                    // Send data to Arduino
                    // ...
                    lbColor.Text = "Black";
                    serialCommand("4");
                    isColorChange = 4;
                }

                // White color'
                //if (pixelColor.R > 100 && pixelColor.G > 100 && pixelColor.B > 100)
                //{
                //    // Send data to Arduino
                //    // ...
                //    lbColor.Text = "White";
                //    serialCommand("5");
                //    isColorChange = 5;
                //}
                //// Yellow color
                //if (pixelColor.R > 100 && pixelColor.G > 100 && pixelColor.B < 100)
                //{
                //    // Send data to Arduino
                //    // ...
                //    lbColor.Text = "Yellow";
                //    serialCommand("6");
                //    isColorChange = 6;
                //}

                //// Pink color
                //if (pixelColor.R > 100 && pixelColor.G < 100 && pixelColor.B > 100)
                //{
                //    // Send data to Arduino
                //    // ...
                //    lbColor.Text = "Pink";
                //    serialCommand("7");
                //    isColorChange = 7;
                //}
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

                this.serialportName = comboBoxCOMPort.Text;
                this.baudrate = comboBoxBaud.Text;
                    serialConnect();

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
                comboBoxBaud.SelectedIndex = 0;

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
        Forms._Login login;

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!scrollPictureBox.isScroll)
            {
                if(login != null)
                {
                    login.Close();
                    login = null;
                }

                login = new Forms._Login(this);
                login.Show();
            }
            else
            {
                scrollPictureBox.isScroll = false;
                loginToolStripMenuItem.Text = "Login";
                toolStripStatusLogin.Text = "Logout";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRectangle();
        }

         #region Serial Port 
        public string serialportName = string.Empty;

        public string baudrate = string.Empty;

        public string readDataSerial = string.Empty;

        public string dataSerialReceived = string.Empty;

        public bool is_Blink_NG = false;

        public void setSerialPort(string portName, string baud)
        {
            this.serialportName = portName;
            this.baudrate = baud;

        }

        private void serialConnect(string portName, int baud)
        {
            try
            {
                if (this.serialPort.IsOpen)
                {
                    this.serialPort.Close();
                }

                this.serialPort.PortName = portName;
                this.serialPort.BaudRate = baud;
                this.serialPort.Open();
                this.serialCommand("conn");
                Thread.Sleep(50);
                this.serialCommand("conn");
                this.toolStripStatusConnectSerialPort.Text = "Serial Connected";
                this.toolStripStatusConnectSerialPort.ForeColor = Color.Green;

            }
            catch (Exception ex)
            {
                LogWriter.SaveLog("Error :" + ex.Message);
                this.toolStripStatusConnectSerialPort.Text = "Serial Port: Disconnect";
                this.toolStripStatusConnectSerialPort.ForeColor = Color.Red;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void serialConnect()
        {

            if (this.serialportName == string.Empty || this.baudrate == string.Empty)
            {
                MessageBox.Show("Please select serial port and baud rate", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.serialConnect(this.serialportName, int.Parse(this.baudrate));
        }

        public void serialCommand(string command)
        {
            if (this.serialPort.IsOpen)
            {
                this.serialPort.Write(">" + command + "<#");
                LogWriter.SaveLog("Serial send : " + command);
                toolStripStatusSentData.Text = "Send : "+ command;
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                readDataSerial = this.serialPort.ReadExisting();
                this.Invoke(new EventHandler(dataReceived));
            }
            catch (Exception ex)
            {
                LogWriter.SaveLog("Error Serial :" + ex.Message);
                //MessageBox.Show(ex.Message, "Error Serial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataReceived(object sender, EventArgs e)
        {
            this.dataSerialReceived += readDataSerial;
            if (dataSerialReceived.Contains(">") && dataSerialReceived.Contains("<"))
            {
                string data = this.dataSerialReceived.Replace("\r", string.Empty).Replace("\n", string.Empty);
                data = data.Substring(data.IndexOf(">") + 1, data.IndexOf("<") - 1);
                this.dataSerialReceived = string.Empty;
                data = data.Replace(">", "").Replace("<", "");
                toolStripStatusSerialData.Text = "DATA :" + data;
                LogWriter.SaveLog("Serial Received : " + data);
                if (data == "rst" || data.Contains("rst"))
                {
                }
            }
            else if (!dataSerialReceived.Contains(">"))
            {
                this.dataSerialReceived = string.Empty;
            }
        }
        #endregion
    }
}
