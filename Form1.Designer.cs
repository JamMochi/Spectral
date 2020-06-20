namespace SoundProjectTwo
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Refresh = new System.Windows.Forms.Button();
            this.Record = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.sourceList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Display = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.sigChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CreateWindow = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sigChart)).BeginInit();
            this.SuspendLayout();
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(580, 3);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(180, 37);
            this.Refresh.TabIndex = 0;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Record
            // 
            this.Record.Location = new System.Drawing.Point(12, 3);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(180, 37);
            this.Record.TabIndex = 1;
            this.Record.Text = "Record";
            this.Record.UseVisualStyleBackColor = true;
            this.Record.Click += new System.EventHandler(this.Record_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(12, 46);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(180, 37);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // sourceList
            // 
            this.sourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.sourceList.HideSelection = false;
            this.sourceList.Location = new System.Drawing.Point(580, 46);
            this.sourceList.Name = "sourceList";
            this.sourceList.Size = new System.Drawing.Size(366, 102);
            this.sourceList.TabIndex = 3;
            this.sourceList.UseCompatibleStateImageBehavior = false;
            this.sourceList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Source";
            this.columnHeader2.Width = 176;
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(198, 46);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(180, 37);
            this.Display.TabIndex = 4;
            this.Display.Text = "Display";
            this.Display.UseVisualStyleBackColor = true;
            this.Display.Click += new System.EventHandler(this.Display_Click);
            // 
            // sigChart
            // 
            chartArea1.Name = "ChartArea1";
            this.sigChart.ChartAreas.Add(chartArea1);
            this.sigChart.Location = new System.Drawing.Point(12, 154);
            this.sigChart.Name = "sigChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.sigChart.Series.Add(series1);
            this.sigChart.Size = new System.Drawing.Size(934, 407);
            this.sigChart.TabIndex = 5;
            this.sigChart.Text = "chart1";
            // 
            // CreateWindow
            // 
            this.CreateWindow.Location = new System.Drawing.Point(198, 3);
            this.CreateWindow.Name = "CreateWindow";
            this.CreateWindow.Size = new System.Drawing.Size(180, 37);
            this.CreateWindow.TabIndex = 6;
            this.CreateWindow.Text = "Next Window";
            this.CreateWindow.UseVisualStyleBackColor = true;
            this.CreateWindow.Click += new System.EventHandler(this.CreateWindow_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(766, 3);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(180, 37);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(12, 89);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(180, 37);
            this.Play.TabIndex = 8;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 573);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.CreateWindow);
            this.Controls.Add(this.sigChart);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.sourceList);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.Refresh);
            this.Name = "Form1";
            this.Text = "Signal Project";
            ((System.ComponentModel.ISupportInitialize)(this.sigChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button Record;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.ListView sourceList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button Display;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart sigChart;
        private System.Windows.Forms.Button CreateWindow;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Play;
    }
}

