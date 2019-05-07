namespace DMApp
{
    partial class Univariable_Numerico
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboAtributo = new System.Windows.Forms.ComboBox();
            this.labelMedia = new System.Windows.Forms.Label();
            this.labelMediana = new System.Windows.Forms.Label();
            this.labelModa = new System.Windows.Forms.Label();
            this.labelDvStd = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboAtributo
            // 
            this.comboAtributo.FormattingEnabled = true;
            this.comboAtributo.Location = new System.Drawing.Point(25, 47);
            this.comboAtributo.Name = "comboAtributo";
            this.comboAtributo.Size = new System.Drawing.Size(121, 21);
            this.comboAtributo.TabIndex = 0;
            this.comboAtributo.SelectedIndexChanged += new System.EventHandler(this.ComboAtributo_SelectedIndexChanged);
            // 
            // labelMedia
            // 
            this.labelMedia.AutoSize = true;
            this.labelMedia.Location = new System.Drawing.Point(22, 96);
            this.labelMedia.Name = "labelMedia";
            this.labelMedia.Size = new System.Drawing.Size(36, 13);
            this.labelMedia.TabIndex = 1;
            this.labelMedia.Text = "Media";
            // 
            // labelMediana
            // 
            this.labelMediana.AutoSize = true;
            this.labelMediana.Location = new System.Drawing.Point(22, 124);
            this.labelMediana.Name = "labelMediana";
            this.labelMediana.Size = new System.Drawing.Size(48, 13);
            this.labelMediana.TabIndex = 2;
            this.labelMediana.Text = "Mediana";
            // 
            // labelModa
            // 
            this.labelModa.AutoSize = true;
            this.labelModa.Location = new System.Drawing.Point(22, 149);
            this.labelModa.Name = "labelModa";
            this.labelModa.Size = new System.Drawing.Size(34, 13);
            this.labelModa.TabIndex = 3;
            this.labelModa.Text = "Moda";
            // 
            // labelDvStd
            // 
            this.labelDvStd.AutoSize = true;
            this.labelDvStd.Location = new System.Drawing.Point(22, 171);
            this.labelDvStd.Name = "labelDvStd";
            this.labelDvStd.Size = new System.Drawing.Size(104, 13);
            this.labelDvStd.TabIndex = 4;
            this.labelDvStd.Text = "Desviación estándar";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(269, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 6;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(341, 300);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // Univariable_Numerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelDvStd);
            this.Controls.Add(this.labelModa);
            this.Controls.Add(this.labelMediana);
            this.Controls.Add(this.labelMedia);
            this.Controls.Add(this.comboAtributo);
            this.Name = "Univariable_Numerico";
            this.Text = "Univariable_Numerico";
            this.Load += new System.EventHandler(this.Univariable_Numerico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAtributo;
        private System.Windows.Forms.Label labelMedia;
        private System.Windows.Forms.Label labelMediana;
        private System.Windows.Forms.Label labelModa;
        private System.Windows.Forms.Label labelDvStd;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}