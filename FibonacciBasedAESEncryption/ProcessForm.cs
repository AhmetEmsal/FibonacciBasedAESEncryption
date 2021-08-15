using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;

namespace FibonacciBasedAESEncryption
{
    public partial class ProcessForm : MetroFramework.Forms.MetroForm
    {
        public string pbarText = "Process";

        public ProcessForm()
        {
            InitializeComponent();
        }
        private int ProgressMinimum = 0;
        private int ProgressMaximum = 100;
        private int ProgressValue = 0;
        private void ProcessForm_Load(object sender, EventArgs e)
        {
            lbl_blockLength.Text = "?";
            lbl_processedBlock.Text = "?";
            lbl_remainingTime.Text = "?";

            if (!lbl_imageSize.Visible)
            {
                lbl_imageSizeHeader.Visible = false;
                int diff = pnl_labels.Top - lbl_imageSize.Top;
                pnl_labels.Top -= diff;
                this.Height -= diff;
                this.Top = Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            }

            pbar.Width = this.Width;
            pbar.Top = this.Height - pbar.Height;
            pbar.Left = 0;

        }


        public void startProcess(
            Faes faes, 
            Stopwatch sw, 
            CancellationTokenSource source,
            Process encryptProcess,
            Action Finished = null
        ) {

            //PerformanceCounter theCPUCounter = new PerformanceCounter("Process", "% Processor Time", encryptProcess.ProcessName);
            //PerformanceCounter theMemCounter = new PerformanceCounter("Process", "Working Set", encryptProcess.ProcessName);

            this.FormClosing += (object sender, FormClosingEventArgs ee) =>
            {
                if (ee.CloseReason == CloseReason.UserClosing)
                { //If user click the close button
                    faes.stopped = true;
                    Console.WriteLine("Çıkış düğmesine tıklandı!");
                    return;
                }
            };
             
            //Tick Handler
            byte counter = 0;
            EventHandler processUntilFinish = (object ss, EventArgs ee) =>
            {
                uint processedBlock = faes.processedBlock;
                //Console.WriteLine("processUntilFinish: " + workingOnBlock.ToString() + "/" + faes.blockCount.ToString());
                lbl_processedBlock.Text = processedBlock.ToString("#,##0");
                {
                    if (processedBlock != 0)
                    {
                        float msPerBlock = (float)sw.ElapsedMilliseconds / processedBlock;
                        lbl_msPerBlock.Text = msPerBlock.ToString("0.##") + " ms";
                        lbl_remainingTime.Text = secondsToTime(Convert.ToInt32((faes.blockCount - processedBlock) * msPerBlock / 1000));
                        lbl_algSpeed.Text = SizeSuffix(Convert.ToInt32((double)1000 / msPerBlock) * (Faes.blockSize / 8)) + "/sec";
                    }
                }
                lbl_passingTime.Text = secondsToTime(Convert.ToInt32(sw.ElapsedMilliseconds / 1000));
                ProgressValue = Convert.ToInt32((double)processedBlock / faes.blockCount * 100.0);
                pbar.Refresh();
                //Console.WriteLine(theCPUCounter.NextValue() + " - " + theMemCounter.NextValue());
                if (faes.stopped)
                {
                    sw.Stop();
                    source.Cancel();
                    Console.WriteLine("process interrupted");
                    timer1.Stop();

                }
                else if (!faes.working)
                {
                    Console.WriteLine("process finished");
                    timer1.Stop();

                    Finished();

                    return;
                }
            };
            EventHandler waitUntilWork = null;
            waitUntilWork = (object ss, EventArgs ee) =>
            {
                Console.WriteLine("waituntilworking");
                if (faes.working || ++counter == 2)
                {
                    Console.WriteLine("process start to work.");
                    lbl_blockLength.Text = faes.blockCount.ToString("#,##0");
                    timer1.Tick -= waitUntilWork;
                    timer1.Tick += processUntilFinish;
                }
            };


            //Timer start
            timer1.Interval = 200;
            timer1.Tick += waitUntilWork;
            timer1.Start();
            Console.WriteLine("timer1.Started");
        }

        private void MetroProgressBar1_CustomPaint(object sender, MetroFramework.Drawing.MetroPaintEventArgs e)
        {
            MetroFramework.Controls.MetroProgressBar pbar = sender as MetroFramework.Controls.MetroProgressBar;
            // Clear the background.
            e.Graphics.Clear(pbar.BackColor);

            // Draw the progress bar.
            float fraction =
                (float)(pbar.Value - pbar.Minimum) /
                (pbar.Maximum - pbar.Minimum);
            int wid = (int)(fraction * pbar.ClientSize.Width);

            e.Graphics.FillRectangle(
                Brushes.LightGreen, 
                0, 
                0, 
                wid,
                pbar.ClientSize.Height
            );

            // Draw the text.
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                int percent = (int)(fraction * 100);
                e.Graphics.DrawString(
                    pbarText + ": " + percent.ToString() + "%",
                    this.Font,
                    Brushes.Black,
                    pbar.ClientRectangle,
                    sf
                );
            }

        }

        private string secondsToTime(int sec)
        {
            int min, hour, day;
            if (sec > 59)
            {
                min = Convert.ToInt32(sec / 60);
                sec %= 60;
                if (min > 59)
                {
                    hour = Convert.ToInt32(min / 60);
                    min %= 60;
                    if (hour > 23)
                    {
                        day = Convert.ToInt32(hour / 24);
                        min %= 24;
                        return $"{day + (day == 1 ? "Day" : "Days")} {pad2(hour)}:{pad2(min)}:{pad2(sec)}";
                    }
                    else return $"{hour}:{pad2(min)}:{pad2(sec)}";
                }
                else return $"{pad2(min)}:{pad2(sec)}";
            }
            else return $"{sec} sec";
        }
        private string pad2(int n, char chr='0')
        {
            return n.ToString().PadLeft(2, chr);
        }

        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
        }

        private void drawingProgressBar(object sender, PaintEventArgs e)
        {
            // Clear the background.
            e.Graphics.Clear(pbar.BackColor);

            // Draw the progress bar.
            float fraction =
                (float)(ProgressValue - ProgressMinimum) /
                (ProgressMaximum - ProgressMinimum);
            int wid = (int)(fraction * pbar.ClientSize.Width);
            e.Graphics.FillRectangle(
                Brushes.LightGreen, 0, 0, wid,
                pbar.ClientSize.Height);

            // Draw the text.
            e.Graphics.TextRenderingHint =
                TextRenderingHint.AntiAliasGridFit;
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                int percent = (int)(fraction * 100);
                e.Graphics.DrawString(
                    pbarText + ": " + percent.ToString() + "%",
                    this.Font, Brushes.Black,
                    pbar.ClientRectangle, sf);
            }
        }
    }
}