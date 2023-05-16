using DirectShowLib;
using Log;
using Microsoft.VisualBasic.Logging;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using RGB_V2.Forms;
using RGB_V2.Utilities;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace RGB_V2
{
    public partial class Main : Form
    {
        public string[] baudList = { "9600", "19200", "38400", "57600", "115200" };
        private int driveindex = 0;
        private int oldComboxDriveCamera = -1;
        private int oldComboxBaudList = -1;
        private int oldComboxCOMPort = -1;

        private readonly TCapture capture;

        private SerialPort serialPort;
        private LogWriter log;
        private Color_name.Color colorName;
        private string[] color_name;
        private Color pixelColor;

        private Image image;
        private Stopwatch sw;
        private Stopwatch sw_test;
        public Main()
        {
            InitializeComponent();



            serialPort = new SerialPort();
            serialPort.DataReceived += Serial_DataReceived;
            serialPort.ErrorReceived += Serial_ErrorReceived;
            log = new LogWriter(Properties.Resources.path);

            stopwatchFrame = new Stopwatch();

            capture = new TCapture();
            capture.OnFrameHeader += Capture_OnFrameHeader;
            capture.OnVideoStarted += Capture_OnVideoStarted;
            capture.OnError += Capture_OnError;
            capture.OnVideoStop += Capture_OnVideoStop;

            sw = new Stopwatch();

            sw_test = new Stopwatch();
        }



        private void Main_Load(object sender, EventArgs e)
        {
            btReload.PerformClick();
            cbAverageRGB.Checked = Properties.Settings.Default.isAverageRGB;
            colorName = new Color_name.Color();
        }

        private void btReload_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(Properties.Resources.path))
                Directory.CreateDirectory(Properties.Resources.path);

            var drive = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));

            cbDrive.Items.Clear();
            foreach (DsDevice device in drive)
            {
                cbDrive.Items.Add(device.Name);
            }
            drive.Clear();
            // Select Drive 
            if (cbDrive.Items.Count > 0)
                cbDrive.SelectedIndex = 0;

            cbBaud.Items.Clear();
            cbBaud.Items.AddRange(baudList);

            // Select Baud List
            if (cbBaud.Items.Count > 0)
                cbBaud.SelectedIndex = 0;

            cbCOM.Items.Clear();
            cbCOM.Items.AddRange(SerialPort.GetPortNames());
            if (cbCOM.Items.Count > 0)
                cbCOM.SelectedIndex = 0;


            if (oldComboxDriveCamera != -1 && oldComboxDriveCamera < cbDrive.Items.Count)
            {
                cbDrive.SelectedIndex = oldComboxDriveCamera;
            }
            if (oldComboxBaudList != -1 && oldComboxBaudList < cbBaud.Items.Count)
            {
                cbBaud.SelectedIndex = oldComboxBaudList;
            }
            if (oldComboxCOMPort != -1 && oldComboxCOMPort < cbCOM.Items.Count)
            {
                cbCOM.SelectedIndex = oldComboxCOMPort;
            }
        }

        private void Capture_OnVideoStop()
        {

        }

        private void Capture_OnError(string messages)
        {

        }

        private void Capture_OnVideoStarted()
        {

        }

        private void Capture_OnFrameHeader(Bitmap bitmap)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => Capture_OnFrameHeader(bitmap)));
                    return;
                }

                UpdatePictureBoxImage(bitmap);
                UpdateFrameRate();

                if (!Properties.Settings.Default.Rect.IsEmpty)
                {
                    //CropAndDisplayROI();
                    DrawROIOnImage();

                    if (sw.ElapsedMilliseconds > 500)
                    {
                        image?.Dispose();
                        image = bitmap?.Clone() as Image;

                        sw.Restart();

                        // CropAndDisplayROI_RGB(image);
                        StartProcessRGB(image);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePictureBoxImage(Bitmap bitmap)
        {
            pictureBoxCamera.Image?.Dispose();
            pictureBoxCamera.Image = bitmap?.Clone() as Image;

        }
        private Task task;
        private void StartProcessRGB(Image m)
        {
            if (task != null && task.Status == TaskStatus.Running)
            {
                return;
            }
            task = Task.Run(() => CropAndDisplayROI_RGB(m));
        }
        private void CropAndDisplayROI_RGB(Image m)
        {
            try
            {
                sw_test.Restart();
                using (var bmp = new Bitmap(Properties.Settings.Default.Rect.Width, Properties.Settings.Default.Rect.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(m, new Rectangle(0, 0, bmp.Width, bmp.Height), Properties.Settings.Default.Rect, GraphicsUnit.Pixel);
                    }

                    pixelColor = cbAverageRGB.Checked ? GetAverageRGB(bmp) : bmp.GetPixel(bmp.Width / 2, bmp.Height / 2);

                    UpdateDisplayLabels();



                    color_name = colorName.Name(colorName.RgbToHex(pixelColor.R, pixelColor.G, pixelColor.B));

                    UpdateSerialCommandAndResult();
                }
                sw_test.Stop();
                Debug.WriteLine("Time :" + sw_test.ElapsedMilliseconds + "ms");
                Debug.WriteLine("Thread :" + Thread.CurrentThread.ManagedThreadId);
                toolStripStatusLabelTimeRGB.Text = $"Time: {sw_test.ElapsedMilliseconds} ms";
            }
            catch (Exception ex)
            {
                log.SaveLog(ex.Message);
            }
        }

        private void UpdateDisplayLabels()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateDisplayLabels()));
                return;
            }
            toolStripStatusLabelRect.Text = $"X: {Properties.Settings.Default.Rect.X} Y: {Properties.Settings.Default.Rect.Y} W: {Properties.Settings.Default.Rect.Width} H: {Properties.Settings.Default.Rect.Height}";
            pictureBoxRGB.BackColor = pixelColor;
            UpdateLabel(lbR, pixelColor.R, Color.Red);
            UpdateLabel(lbG, pixelColor.G, Color.Green);
            UpdateLabel(lbB, pixelColor.B, Color.Blue);

            lbColor.BackColor = pixelColor;
        }

        private void UpdateLabel(Label label, int value, Color color)
        {
            label.Text = value.ToString();
            label.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
            label.BackColor = color;
        }

        private void UpdateSerialCommandAndResult()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateSerialCommandAndResult()));
                return;
            }

            string colorNameLower = color_name[3].ToLower();

            lbColor.Text = color_name[3];
            string command;
            string resultText;
            Color resultBackColor;

            if (colorNameLower == "black" || (pixelColor.R < 40 && pixelColor.G < 40 && pixelColor.B < 40))
            {
                command = "4";
                resultText = "WAIT";
                resultBackColor = Color.Yellow;
            }
            else if (colorNameLower == "red")
            {
                command = "2";
                resultText = "NG";
                resultBackColor = Color.Red;
            }
            else if (colorNameLower == "green")
            {
                command = "1";
                resultText = "OK";
                resultBackColor = Color.Green;
            }
            else
            {
                command = "4";
                resultText = "WAIT";
                resultBackColor = Color.Yellow;
            }

            serialCommand(command);
            lbResult.Text = resultText;
            lbResult.ForeColor = Color.Black;
            lbResult.BackColor = resultBackColor;
        }


        private void DrawROIOnImage()
        {
            using (Graphics g = Graphics.FromImage(pictureBoxCamera.Image))
            {
                g.DrawRectangle(new Pen(Color.Red, 2), Properties.Settings.Default.Rect);
            }
        }

        private Color GetAverageRGB(Image image)
        {
            if (image == null)
                return Color.Black;

            using (Bitmap bmp = new Bitmap(image))
            {
                int redSum = 0, greenSum = 0, blueSum = 0;
                int pixelCount = 0;

                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;

                int bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int totalBytes = bmpData.Stride * bmp.Height;
                byte[] rgbValues = new byte[totalBytes];

                Marshal.Copy(ptr, rgbValues, 0, totalBytes);

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int position = (y * bmpData.Stride) + (x * bytesPerPixel);
                        blueSum += rgbValues[position];
                        greenSum += rgbValues[position + 1];
                        redSum += rgbValues[position + 2];
                        pixelCount++;
                    }
                }
                bmp.UnlockBits(bmpData);

                int avgR = redSum / pixelCount;
                int avgG = greenSum / pixelCount;
                int avgB = blueSum / pixelCount;

                return Color.FromArgb(avgR, avgG, avgB);
            }
        }

        private Stopwatch stopwatchFrame;
        private long frameCount = 0;
        private double frameRate = 0;
        private void UpdateFrameRate()
        {
            frameCount++;

            if (!stopwatchFrame.IsRunning)
            {
                stopwatchFrame.Start();
            }
            else
            {
                double elapsedSeconds = stopwatchFrame.Elapsed.TotalSeconds;
                if (elapsedSeconds >= 1)
                {
                    frameRate = frameCount / elapsedSeconds;
                    frameCount = 0;
                    stopwatchFrame.Restart();

                    // Display frame rate in a label or another UI element
                    toolStripStatusFrameRate.Text = $"Frame Rate: {frameRate:0.0} fps";
                }
            }
        }

        private bool isConnect = false;
        private Task openTask;
        private int camIndex;

        private async void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (openTask != null && openTask.Status == TaskStatus.Running)
                {
                    Debug.WriteLine("Task is running");
                    return;
                }

                isConnect = !isConnect;
                if (isConnect)
                {
                    if (cbDrive.SelectedIndex == -1)
                    {
                        throw new Exception("Invalid drive camera!");
                    }

                    if (cbBaud.SelectedIndex == -1)
                    {
                        throw new Exception("Invalid baud!");
                    }

                    if (cbCOM.SelectedIndex == -1)
                    {
                        throw new Exception("Invalid COM Port!");
                    }

                    btConnect.Text = "Connecting";
                    pictureBoxCamera.Image = null;
                    pictureBoxCamera.Image = Properties.Resources.Spinner_0_4s_800px;
                    camIndex = cbDrive.SelectedIndex;
                    capture.frameRate = 10;
                    openTask = capture.StartAsync(camIndex);
                    await openTask;

                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }

                    // Connect serial port
                    serialPort.PortName = cbCOM.SelectedItem.ToString();
                    serialPort.BaudRate = int.Parse(cbBaud.SelectedItem.ToString());
                    serialPort.Open();

                    btConnect.Text = "Disconnect";
                    toolStripStatusLabelStatus.Text = "Status: Connected";
                    sw.Restart();
                }
                else
                {

                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    openTask = capture.StopAsync();
                    await openTask;

                    btConnect.Text = "Connect";
                    pictureBoxCamera.Image?.Dispose();
                    pictureBoxCamera.Image = null;

                    toolStripStatusLabelStatus.Text = "Status: Disconnected";
                }
            }
            catch (Exception ex)
            {
                isConnect = false;
                btConnect.Text = "Connect";
                pictureBoxCamera.Image?.Dispose();
                pictureBoxCamera.Image = null;
                openTask = capture.StopAsync();
                await openTask;

                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }


                log.SaveLog("E01 " + ex.Message);
                MessageBox.Show("E01 " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabelStatus.Text = "Status: Disconnected";
            }
        }

        private string readDataSerial = string.Empty;
        private string dataSerialReceived = string.Empty;

        private void Serial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                readDataSerial = serialPort.ReadLine();
                dataReceived();
            }
            catch (Exception ex)
            {
                log.SaveLog("Error at Serial_DataReceived :" + ex.Message);
                Debug.WriteLine("Error at Serial_DataReceived :" + ex.Message);
            }

        }


        private void dataReceived()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => dataReceived()));
                return;
            }

            this.dataSerialReceived += readDataSerial;
            if (dataSerialReceived.Contains(">") && dataSerialReceived.Contains("<"))
            {
                string data = this.dataSerialReceived.Replace("\r", string.Empty).Replace("\n", string.Empty);
                data = data.Substring(data.IndexOf(">") + 1, data.IndexOf("<") - data.IndexOf(">") - 1);
                this.dataSerialReceived = string.Empty;
                data = data.Replace(">", "").Replace("<", "");
                toolStripStatusSerialData.Text = "DATA :" + data;

            }
            else if (!dataSerialReceived.Contains(">"))
            {
                this.dataSerialReceived = string.Empty;
            }

        }

        public void serialCommand(string command)
        {
            if (this.serialPort.IsOpen)
            {
                this.serialPort.Write(">" + command + "<#");
                log.SaveLog("Serial send : " + command);
                toolStripStatusSentData.Text = "Send : " + command;
            }
        }


        private SelectXY selectXY;
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectXY != null)
            {
                selectXY.Close();
            }

            selectXY = new SelectXY(this);
            selectXY.Show();

        }


        private void cbAverageRGB_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAverageRGB = cbAverageRGB.Checked;
            Properties.Settings.Default.Save();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                capture.Stop();
            }
            catch
            {

            }
        }
    }
}