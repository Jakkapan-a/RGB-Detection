using DirectShowLib;
using Log;
using Microsoft.VisualBasic.Logging;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using RGB_V2.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace RGB_V2
{
    public partial class Main : Form
    {
        public string[] baudList = { "9600", "19200", "38400", "57600", "115200" };
        private int driveindex = 0;
        private int oldComboxDriveCamera = -1;
        private int oldComboxBaudList = -1;
        private int oldComboxCOMPort = -1;


        private readonly BackgroundWorker bgVideo;
        private readonly BackgroundWorker bgRGB;
        private readonly VideoCapture capture;
        private SerialPort serialPort;
        private LogWriter log;
        private Color_name.Color colorName;
        private string[] color_name;
        private Color pixelColor;
        public Main()
        {
            InitializeComponent();
            bgVideo = new BackgroundWorker();
            bgVideo.DoWork += BgVideo_DoWork;
            bgVideo.RunWorkerCompleted += BgVideo_RunWorkerCompleted;
            bgVideo.WorkerSupportsCancellation = true;
            bgVideo.WorkerReportsProgress = true;
            bgVideo.ProgressChanged += BgVideo_ProgressChanged;

            bgRGB = new BackgroundWorker();
            bgRGB.DoWork += BgRGB_DoWork;
            bgRGB.RunWorkerCompleted += BgRGB_RunWorkerCompleted;
            bgRGB.WorkerSupportsCancellation = true;
            bgRGB.WorkerReportsProgress = true;
            bgRGB.ProgressChanged += BgRGB_ProgressChanged;


            serialPort = new SerialPort();
            serialPort.DataReceived += Serial_DataReceived;
            serialPort.ErrorReceived += Serial_ErrorReceived;
            log = new LogWriter(Properties.Resources.path);

            capture = new VideoCapture();
            stopwatchFrame = new Stopwatch();
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

        private Bitmap bmp;
        private Rectangle rect;
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
                    CropAndDisplayROI();
                    DrawROIOnImage();

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

        private void CropAndDisplayROI()
        {

            try
            {
                bmp?.Dispose();
                bmp = new Bitmap(Properties.Settings.Default.Rect.Width, Properties.Settings.Default.Rect.Height);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(pictureBoxCamera.Image, new Rectangle(0, 0, bmp.Width, bmp.Height), Properties.Settings.Default.Rect, GraphicsUnit.Pixel);
                }
                pictureBoxRGB.Image?.Dispose();
                pictureBoxRGB.Image = (Image)bmp.Clone();

                if (cbAverageRGB.Checked)
                {

                    pixelColor = GetAverageRGB(pictureBoxRGB.Image);

                }
                else
                {
                    int x = bmp.Width / 2;
                    int y = bmp.Height / 2;
                    pixelColor = bmp.GetPixel(x, y);

                }


                toolStripStatusLabelRect.Text = $"X: {Properties.Settings.Default.Rect.X} Y: {Properties.Settings.Default.Rect.Y} W: {Properties.Settings.Default.Rect.Width} H: {Properties.Settings.Default.Rect.Height}";
                lbR.Text = pixelColor.R.ToString();
                lbR.ForeColor = Color.FromArgb(255 - pixelColor.R, 255 - 0, 255 - 0);
                lbR.BackColor = Color.FromArgb(pixelColor.R, 0, 0);

                lbG.Text = pixelColor.G.ToString();
                lbG.ForeColor = Color.FromArgb(255 - 0, 255 - pixelColor.G, 255 - 0);
                lbG.BackColor = Color.FromArgb(0, pixelColor.G, 0);

                lbB.Text = pixelColor.B.ToString();
                lbB.ForeColor = Color.FromArgb(255 - 0, 255 - 0, 255 - pixelColor.B);
                lbB.BackColor = Color.FromArgb(0, 0, pixelColor.B);

                lbColor.BackColor = pixelColor;

                color_name = colorName.Name(colorName.RgbToHex(pixelColor.R, pixelColor.G, pixelColor.B));
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
                    lbResult.Text = "NG";
                    lbResult.ForeColor = Color.Black;
                    lbResult.BackColor = Color.Red;
                }
                else
                if (color_name[3].ToLower() == "green")
                {
                    serialCommand("1");
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
            catch (Exception ex)
            {
                log.SaveLog(ex.Message);
            }

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

        private void BgVideo_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            // var frameBitmap = (Bitmap)e.UserState;
            using (var frameBitmap = e.UserState as Bitmap)
            {
                Capture_OnFrameHeader(frameBitmap);
            }
        }

        private void BgVideo_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            isConnect = false;
            btConnect.Text = "Connect";
            pictureBoxCamera.Image?.Dispose();
            pictureBoxCamera.Image = null;
        }

        private void BgVideo_DoWork(object? sender, DoWorkEventArgs e)
        {
            var bgWorker = sender as BackgroundWorker;

            try
            {
                while (!bgWorker.CancellationPending)
                {
                    using (var frameMat = capture.RetrieveMat())
                    {
                        var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                        bgWorker.ReportProgress(0, frameBitmap);
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                log.SaveLog(ex.Message);
            }

            capture.Release();
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

                    openTask = Task.Run(() =>
                    {
                        //capture.Start(camIndex);
                        capture.Open(camIndex, VideoCaptureAPIs.ANY);
                        capture.FrameHeight = 1920;
                        capture.FrameWidth = 1080;
                    });
                    await openTask;

                    // Connect serial port
                    serialPort.PortName = cbCOM.SelectedItem.ToString();
                    serialPort.BaudRate = int.Parse(cbBaud.SelectedItem.ToString());
                    serialPort.Open();


                    if (bgVideo.IsBusy)
                        bgVideo.CancelAsync();

                    if (!bgVideo.IsBusy)
                        bgVideo.RunWorkerAsync();

                    btConnect.Text = "Disconnect";
                    toolStripStatusLabelStatus.Text = "Status: Connected";
                }
                else
                {
                    if (bgVideo.IsBusy)
                        bgVideo.CancelAsync();

                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }

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
                if (bgVideo.IsBusy)
                    bgVideo.CancelAsync();

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
            readDataSerial = serialPort.ReadLine();
            dataReceived();
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

        private void BgRGB_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {

        }
        private void BgRGB_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void BgRGB_DoWork(object? sender, DoWorkEventArgs e)
        {

        }

        private void cbAverageRGB_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAverageRGB = cbAverageRGB.Checked;
            Properties.Settings.Default.Save();
        }
    }
}