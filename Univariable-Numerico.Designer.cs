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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            chartArea13.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chart1.Legends.Add(legend13);
            this.chart1.Location = new System.Drawing.Point(279, 32);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            series13.YValuesPerPoint = 6;
            this.chart1.Series.Add(series13);
            this.chart1.Size = new System.Drawing.Size(341, 300);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea14.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chart2.Legends.Add(legend14);
            this.chart2.Location = new System.Drawing.Point(279, 32);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            series14.YValuesPerPoint = 6;
            this.chart2.Series.Add(series14);
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
            this.label2.Size = new System.Drawing.Size(843, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Univariable _____________________________________________________________________" +
    "________________________  Detección de Outliers___________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(620, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bivariable ______________________________________________________________________" +
    "________________________";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Aplicar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Evaluar con:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Location = new System.Drawing.Point(634, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 76);
            this.panel1.TabIndex = 16;
            this.panel1.Tag = "";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1.5 IQR";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "3 IQR";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Buscar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Reemplazar por:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.radioButton5);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(626, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 164);
            this.panel2.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Aplicar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(14, 135);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(52, 17);
            this.radioButton5.TabIndex = 25;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Moda";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.RadioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(14, 112);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(66, 17);
            this.radioButton4.TabIndex = 24;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Mediana";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.RadioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(14, 89);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(54, 17);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Media";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Búsqueda y Reemplazo_________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(626, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Errores Tipográficos__________________";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(626, 288);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 24;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(626, 315);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.radioButton6);
            this.panel3.Controls.Add(this.radioButton7);
            this.panel3.Controls.Add(this.radioButton8);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Location = new System.Drawing.Point(626, 342);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 164);
            this.panel3.TabIndex = 26;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(132, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Aplicar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(3, 115);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(129, 17);
            this.radioButton6.TabIndex = 25;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Z-Score DStandarAbs";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.RadioButton6_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(3, 92);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(111, 17);
            this.radioButton7.TabIndex = 24;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Z-Score DStandar";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.RadioButton7_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(3, 69);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(65, 17);
            this.radioButton8.TabIndex = 23;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Min-Max";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.RadioButton8_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(217, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Normalización________________________";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Nuevo Mínimo";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(113, 44);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 27;
            this.textBox3.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(114, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Nuevo Máximo";
            // 
            // Univariable_Numerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 504);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
    }
}