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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboAtributo = new System.Windows.Forms.ComboBox();
            this.labelMedia = new System.Windows.Forms.Label();
            this.labelMediana = new System.Windows.Forms.Label();
            this.labelModa = new System.Windows.Forms.Label();
            this.labelDvStd = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PrimerAcomboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SegundoAcomboBox = new System.Windows.Forms.ComboBox();
            this.Calcularbutton = new System.Windows.Forms.Button();
            this.labelCCP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboAtributo
            // 
            this.comboAtributo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.chart1.Location = new System.Drawing.Point(279, 32);
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
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(279, 32);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 6;
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(341, 300);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chart2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selecciona atributo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(711, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Univariable _____________________________________________________________________" +
    "_______________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(716, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bivariable ______________________________________________________________________" +
    "________________________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Selecciona primer atributo";
            // 
            // PrimerAcomboBox
            // 
            this.PrimerAcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrimerAcomboBox.FormattingEnabled = true;
            this.PrimerAcomboBox.Location = new System.Drawing.Point(14, 394);
            this.PrimerAcomboBox.Name = "PrimerAcomboBox";
            this.PrimerAcomboBox.Size = new System.Drawing.Size(121, 21);
            this.PrimerAcomboBox.TabIndex = 10;
            this.PrimerAcomboBox.SelectedIndexChanged += new System.EventHandler(this.PrimerAcomboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Selecciona segundo atributo";
            // 
            // SegundoAcomboBox
            // 
            this.SegundoAcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SegundoAcomboBox.FormattingEnabled = true;
            this.SegundoAcomboBox.Location = new System.Drawing.Point(14, 459);
            this.SegundoAcomboBox.Name = "SegundoAcomboBox";
            this.SegundoAcomboBox.Size = new System.Drawing.Size(121, 21);
            this.SegundoAcomboBox.TabIndex = 12;
            this.SegundoAcomboBox.SelectedIndexChanged += new System.EventHandler(this.SegundoAcomboBox_SelectedIndexChanged);
            // 
            // Calcularbutton
            // 
            this.Calcularbutton.Location = new System.Drawing.Point(189, 459);
            this.Calcularbutton.Name = "Calcularbutton";
            this.Calcularbutton.Size = new System.Drawing.Size(75, 23);
            this.Calcularbutton.TabIndex = 14;
            this.Calcularbutton.Text = "Calcular";
            this.Calcularbutton.UseVisualStyleBackColor = true;
            this.Calcularbutton.Click += new System.EventHandler(this.Calcularbutton_Click);
            // 
            // labelCCP
            // 
            this.labelCCP.AutoSize = true;
            this.labelCCP.Location = new System.Drawing.Point(195, 402);
            this.labelCCP.Name = "labelCCP";
            this.labelCCP.Size = new System.Drawing.Size(187, 13);
            this.labelCCP.TabIndex = 15;
            this.labelCCP.Text = "Coeficiente de correlación de Pearson";
            // 
            // Univariable_Numerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 504);
            this.Controls.Add(this.labelCCP);
            this.Controls.Add(this.Calcularbutton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SegundoAcomboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PrimerAcomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelDvStd);
            this.Controls.Add(this.labelModa);
            this.Controls.Add(this.labelMediana);
            this.Controls.Add(this.labelMedia);
            this.Controls.Add(this.comboAtributo);
            this.Name = "Univariable_Numerico";
            this.Text = "Análisis Estadístico";
            this.Load += new System.EventHandler(this.Univariable_Numerico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox PrimerAcomboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SegundoAcomboBox;
        private System.Windows.Forms.Button Calcularbutton;
        private System.Windows.Forms.Label labelCCP;
    }
}