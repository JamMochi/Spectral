using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Media;

namespace SoundProjectTwo
{
    public partial class Form1 : Form
    {
        private NAudio.Wave.WaveIn sourceStream = null;
        private NAudio.Wave.WaveFileWriter waveWriter = null;
        private NAudio.Wave.DirectSoundOut waveOut = null;

        private System.IO.MemoryStream ms = new System.IO.MemoryStream();
        private int sampleRate = 16000;
        private int window = 0;
        private float[] signal = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();
            for(int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));
            }
            sourceList.Items.Clear();
            foreach(var source in sources)
            {
                ListViewItem item = new ListViewItem(source.ProductName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));
                sourceList.Items.Add(item);
            }
        }

        private void Record_Click(object sender, EventArgs e)
        {
            try
            {
                int device = sourceList.SelectedItems[0].Index;
                sourceStream = new NAudio.Wave.WaveIn();
                sourceStream.DeviceNumber = device;
                sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(sampleRate, NAudio.Wave.WaveIn.GetCapabilities(device).Channels);
                sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
                waveWriter = new NAudio.Wave.WaveFileWriter(ms, sourceStream.WaveFormat);
                sourceStream.StartRecording();
            }
            catch
            {
                MessageBox.Show("Please Select An Audio Device", "Missing Audio Device", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (waveWriter == null) return;

            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if(waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }

            if(sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }

            if(waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
        }

        private void Display_Click(object sender, EventArgs e)
        {
            byte[] allByte = ms.ToArray();
            signal = new float[allByte.Length / 2];

            for (int i = 0; i < allByte.Length; i += 2)
            {
                short sample = (short)((allByte[i + 1] << 8) | allByte[i + 0]);
                float sample32 = sample / 32768f;
                signal[i / 2] = sample32;
            }

            sigChart.Series["Series1"].Points.Clear();
            ChartArea CA = sigChart.ChartAreas[0];
            CA.AxisX.ScaleView.Zoomable = true;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;
            for(int i = 0; i < signal.Length; i++)
            {
                if(i % 400 == 0)
                {
                    sigChart.Series["Series1"].Points.AddY(signal[i]);
                }
            }
        }

        private double[] Apply_Hamming_Code(double[] signalR)
        {
            double[] signalW = new double[signalR.Length];
            double[] signalQ = new double[signalR.Length];

            for(int i = 0; i < signalR.Length; i++)
            {
                signalW[i] = 0.54 - 0.46 * Math.Cos(2 * (Math.PI) * i / 399);
            }

            for(int i = 0; i < signalR.Length; i++)
            {
                signalQ[i] = signalR[i] * signalW[i];
            }

            return signalQ;
        }

        private double[] Apply_FFT(double[] signalQ)
        {
            double[] signalU = new double[signalQ.Length];
            double[] signalV = new double[signalQ.Length];
            double[] spectral_density = new double[signalQ.Length];

            for(int i = 0; i < 400; i++)
            {
                double U = 0;
                double V = 0;

                for(int j = 0; j < 400; j++)
                {
                    U += Math.Cos(2 * Math.PI * i * j / 400) * signalQ[j];
                    V += Math.Sin(2 * Math.PI * i * j / 400);
                }

                signalU[i] = U;
                signalV[i] = V;
                spectral_density[i] = Math.Pow(U, 2) + Math.Pow(V, 2);
            }

            return spectral_density;
        }

        private void CreateWindow_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            double[] signalR = new double[400];
            for(int i = 0; i < signalR.Length; i++)
            {
                signalR[i] = signal[i + this.window];
            }
            double[] signalQ = Apply_Hamming_Code(signalR);
            double[] spectral = Apply_FFT(signalQ);

            Chart newChart = new Chart();
            newChart.Size = new Size(934, 407);
            var chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.CursorX.AutoScroll = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            newChart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = "Series1";
            series.ChartType = SeriesChartType.FastLine;
            
            newChart.Series.Add(series);
            newChart.Series["Series1"].Points.Clear();

            for (int i = 0; i < spectral.Length; i++)
            {
                newChart.Series["Series1"].Points.AddY(spectral[i]);
            }
            form2.Controls.Add(newChart);
            form2.Show();
            this.window += 150;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            try
            {
                NAudio.Wave.IWaveProvider provider = new NAudio.Wave.RawSourceWaveStream(new System.IO.MemoryStream(ms.ToArray()), new NAudio.Wave.WaveFormat(sampleRate, 16, 2));
                waveOut = new NAudio.Wave.DirectSoundOut();
                waveOut.Init(provider);
                waveOut.Play();
            }
            catch
            {
                MessageBox.Show("Please Record Before Playing", "Missing Audio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
