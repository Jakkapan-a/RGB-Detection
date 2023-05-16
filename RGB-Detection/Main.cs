using DirectShowLib;
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
using TClass;
using TConstrols;

namespace RGB_Detection
{
    public partial class Main : Form
    {
        private bool isConnect = false;
        public string[] baudList = { "9600", "19200", "38400", "57600", "115200" };
        private int driveindex = 0;
        private TCapture.Capture capture;
        Rectangle rect;

        private LogWriter LogWriter;
        private Color_name.Color colorName_;
        private string[] color_name;
        public Main()
        {
            InitializeComponent();
            colorName_ = new Color_name.Color();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Status tool strip clear
            foreach (ToolStripItem item in statusStrip1.Items)
            {
                item.Text = "";
            }
            capture = new TCapture.Capture();
            capture.OnFrameHeader += Capture_OnFrameHeader;
            capture.OnVideoStarted += Capture_OnVideoStarted;
            capture.OnVideoStop += Capture_OnVideoStop;
            btRefresh.PerformClick();

            loadRectangle();

            if (rect != Rectangle.Empty)
            {
            }
            LogWriter = new LogWriter("./system");
            LogWriter.SaveLog("Satrting...");
        }
        public void SaveRectangle(Rectangle r)
        {
            Properties.Settings.Default.rect_x = r.X;
            Properties.Settings.Default.rect_y = r.Y;
            Properties.Settings.Default.rect_width = r.Width;
            Properties.Settings.Default.rect_height = r.Height;

            Properties.Settings.Default.Save();
            loadRectangle();
        }

        public void loadRectangle()
        {
            if (Properties.Settings.Default.rect_x != 0 && Properties.Settings.Default.rect_y != 0 && Properties.Settings.Default.rect_width != 0 && Properties.Settings.Default.rect_height != 0)
            {
                rect = new Rectangle(Properties.Settings.Default.rect_x, Properties.Settings.Default.rect_y, Properties.Settings.Default.rect_width, Properties.Settings.Default.rect_height);
                toolStripStatusParameter.Text = "Rectangle: X=" + rect.X + ", Y=" + rect.Y + ", Width=" + rect.Width + ", Height=" + rect.Height;
            }
        }
        private void Capture_OnVideoStop()
        {

            if (scrollPictureBox.InvokeRequired)
            {
                scrollPictureBox.Invoke(new Action(() =>
                {
                    scrollPictureBox.Image = null;
                    timer_get.Stop();
                }));
                return;
            }
            scrollPictureBox.Image = null;
        }

        private void Capture_OnVideoStarted()
        {
            Invoke(new Action(() =>
            {
                timer_get.Start();
            }));
        }

        private delegate void FrameVideo(Bitmap bitmap);
        Bitmap bmp;
        private void Capture_OnFrameHeader(Bitmap bitmap)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Capture_OnFrameHeader(bitmap)));
                return;
            }
            scrollPictureBox.Image?.Dispose();
            scrollPictureBox.Image = (Image)bitmap.Clone();

            if (rect != Rectangle.Empty)
            {
                // Crop image to picture box RGB

                this.bmp?.Dispose();
                this.bmp = new Bitmap(rect.Width, rect.Height);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(scrollPictureBox.Image, new Rectangle(0, 0, bmp.Width, bmp.Height), rect, GraphicsUnit.Pixel);
                }
                pictureBoxRGB.Image?.Dispose();
                pictureBoxRGB.Image = (Image)bmp.Clone();
                // Draw Rectangle to Image
                using (Graphics g = Graphics.FromImage(scrollPictureBox.Image))
                {
                    g.DrawRectangle(new Pen(Color.Red, 2), rect);
                }

            }
        }
        private void timer_get_Tick(object sender, EventArgs e)
        {
            try
            {
                if (bmp != null && rect != Rectangle.Empty)
                {
                    //Center of the picture box
                    int x = bmp.Width / 2;
                    int y = bmp.Height / 2;
                    Color pixelColor = ((Bitmap)bmp).GetPixel(x, y);
                    // Get the RGB values
                    txtRed.Text = pixelColor.R.ToString();
                    txtGreen.Text = pixelColor.G.ToString();
                    txtBlue.Text = pixelColor.B.ToString();


                    color_name = colorName_.Name(colorName_.RgbToHex(pixelColor.R, pixelColor.G, pixelColor.B));
                    lbColor.Text = color_name[3];
                    if (color_name[3].ToLower() == "black" || (pixelColor.R < 40 && pixelColor.G < 40 && pixelColor.B < 40))
                    {
                        serialCommand("4");
                        //Console.WriteLine("Black");
                        lbResult.Text = "WAIT";
                        lbResult.ForeColor = Color.Black;
                        lbResult.BackColor = Color.Yellow;
                    }
                    else
                    if (color_name[3].ToLower() == "red")
                    {
                        serialCommand("2");
                        //Console.WriteLine("Red");
                        lbResult.Text = "NG";
                        lbResult.ForeColor = Color.Black;
                        lbResult.BackColor = Color.Red;
                    }
                    else
                    if (color_name[3].ToLower() == "green")
                    {
                        serialCommand("1");
                        //Console.WriteLine("Green");
                        lbResult.Text = "OK";
                        lbResult.ForeColor = Color.Black;
                        lbResult.BackColor = Color.Green;
                    }
                    else
                    {
                        serialCommand("4");
                        lbResult.Text = "WAIT";
                        lbResult.ForeColor = Color.Black;
                        lbResult.BackColor = Color.Yellow;
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.SaveLog(ex.Message);
            }

        }

        private Task openTask;
        private async void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (openTask != null && openTask.Status == TaskStatus.Running)
                {
                    Console.WriteLine("Task is running");
                    return;
                }
                btConnect.Text = "Connecting..";
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
                    btConnect.Text = "Connecting..";
                    scrollPictureBox.Image?.Dispose();
                    scrollPictureBox.Image = Properties.Resources.Spinner_0_4s_800px;
                    driveindex = comboBoxCamera.SelectedIndex;

                    openTask = Task.Run(() =>
                    {
                        capture.Start(driveindex);
                    });

                    await openTask;

                    btConnect.Text = "Disconnect";
                }
                else
                {
                    openTask = Task.Run(() =>
                    {
                        capture.Stop();
                    });

                    await openTask;

                    btConnect.Text = "Connect";

                    scrollPictureBox.Image?.Dispose();
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
            if (capture.IsOpened)
            {
                capture.Stop();
                capture.Dispose();
            }
        }
        Forms._Login login;
        private Crop crop;
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crop?.Close();

            crop = new Crop(this);
            crop.Show();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                toolStripStatusSentData.Text = "Send : " + command;
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
