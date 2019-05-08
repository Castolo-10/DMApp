using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMApp
{
    public partial class Univariable_Numerico : Form
    {
        public DataGridView dgvaux { get; set; }
        List<string[]> cabecera = new List<string[]>();
        List<string[]> cabeceraaux;
        double riq = 0;
        int count1, count3;
        List<int> posiciones_out1 = new List<int>();
        List<int> posiciones_out3 = new List<int>();
        double nuevo1 = 0;
        double nuevo3 = 0;
        double media = 0;
        double mediana = 0;
        double q1 = 0;
        double q3 = 0;
        List<double> elementosCpy = new List<double>();
        int indiceCabecera = 0;
        string columna = "";

        public Univariable_Numerico(DataGridView dgv, List<string[]> header)
        {
            InitializeComponent();
            dgvaux = dgv;
            cabeceraaux = header;
            labelMedia.Text = labelModa.Text = labelMediana.Text = labelDvStd.Text = labelCCP.Text = "";
            button1.Enabled = false;
            panel1.Hide();
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;

        }
        private void Univariable_Numerico_Load(object sender, EventArgs e)
        {
            cabecera.Add(cabeceraaux[0]);
            for(int i = 1; i < cabeceraaux.Count; i++)
            {
                if(cabeceraaux[i][1] == "numeric" || cabeceraaux[i][1] == "nominal")
                {
                    comboAtributo.Items.Add(cabeceraaux[i][0]);
                    PrimerAcomboBox.Items.Add(cabeceraaux[i][0]);
                    SegundoAcomboBox.Items.Add(cabeceraaux[i][0]);
                    cabecera.Add(cabeceraaux[i]);

                }
            }
        }

        private void ComboAtributo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Creamos el arreglo en base a los datos del dgv
            columna = comboAtributo.SelectedItem.ToString();
            indiceCabecera = comboAtributo.SelectedIndex + 1;
            DataGridViewRow fila = new DataGridViewRow();
            if (cabecera[indiceCabecera][1] == "numeric") {
                panel1.Show();
                double[] elementos = new double[dgvaux.RowCount - 1];
                int indice;

                for (indice = 1; indice < dgvaux.ColumnCount; indice++)
                {
                    if (dgvaux.Columns[indice].HeaderText == columna)
                    {
                        break;
                    }
                }
                for (int i = 0; i < dgvaux.RowCount - 1; i++)
                {
                    fila = dgvaux.Rows[i];
                    elementos[i] = Convert.ToDouble(fila.Cells[indice].Value);
                }

                //Ordenamos el arreglo
                double val;
                int flag;
                for (int i = 1; i < elementos.Length; i++)
                {
                    val = elementos[i];
                    flag = 0;
                    for (int j = i - 1; j >= 0 && flag != 1;)
                    {
                        if (val < elementos[j])
                        {
                            elementos[j + 1] = elementos[j];
                            j--;
                            elementos[j + 1] = val;
                        }
                        else flag = 1;
                    }
                }

                //Copiamos elementos
                for(int i = 0; i < elementos.Length; i++)
                {
                    elementosCpy.Add(elementos[i]);
                }

                //Calculamos Media
                media = 0;

                foreach (double valor in elementos)
                {
                    media += valor;
                }
                media = media / elementos.Length;
                labelMedia.Text = "Media: " + media.ToString();

                //Calculamos mediana

                int ismediana = elementos.Length % 2;
                int indicemediana = elementos.Length / 2;
                mediana = (ismediana == 1) ? elementos[Convert.ToInt16(indicemediana - 0.5)] : ((elementos[indicemediana - 1] + elementos[indicemediana]) / 2);
                labelMediana.Text = "Mediana: " + mediana.ToString();

                //Lista de valores únicos

                List<double> ListaU = new List<double>();

                //Calculamos moda
                int conteo;
                int previomax = 0;
                double aux;
                double moda = 0;
                int repeated;

                for (int i = 0; i < elementos.Length; i++)
                {
                    repeated = 0;
                    aux = elementos[i];
                    conteo = 0;
                    foreach (double elem in ListaU)
                    {
                        if (aux == elem)
                        {
                            repeated = 1;
                            break;
                        }
                    }
                    if (repeated == 0)
                    {
                        ListaU.Add(aux);
                        for (int j = 0; j < elementos.Length; j++)
                        {
                            if (aux == elementos[j])
                                conteo++;
                        }
                        if (conteo > previomax)
                        {
                            moda = aux;
                            previomax = conteo;
                        }
                    }
                }
                labelModa.Text = "Moda: " + moda.ToString();

                //Calculamos desviación estándar

                double sumOfSqrs = 0;
                double dvstd = 0;

                for (int i = 0; i < elementos.Length; i++)
                {
                    sumOfSqrs += Math.Pow((elementos[i] - media), 2);
                }
                dvstd = Math.Sqrt(sumOfSqrs / (elementos.Length - 1));

                labelDvStd.Text = "Desviación estándar: " + dvstd.ToString();

                //Cuartiles

                q1 = elementos[(elementos.Length / 4) - 1];
                q3 = elementos[((elementos.Length / 4) * 3) - 1];

                //BoxPlot

                chart1.Show();
                chart2.Hide();

                double rango = elementos[elementos.Length - 1] - elementos[0];
                double varianza = Math.Pow(dvstd, 2);

                chart1.Series.Clear();

                chart1.Series.Add(columna);
                chart1.Series[columna].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
                chart1.Series[columna].XValueMember = columna;

                chart1.Series[columna].Points.AddXY(0, elementos[0], elementos[elementos.Length - 1], q1, q3, media, mediana);

                // Detección de outliers

                riq = q3 - q1;

                nuevo1 = q1 - (3 * riq);
                nuevo3 = q3 + (3 * riq);

                for (indice = 1; indice < dgvaux.ColumnCount; indice++)
                {
                    if (dgvaux.Columns[indice].HeaderText == columna)
                    {
                        break;
                    }
                }
                for (int i = 0; i < dgvaux.RowCount - 1; i++)
                {
                    fila = dgvaux.Rows[i];
                    if (Convert.ToDouble(fila.Cells[indice].Value) > nuevo3 || Convert.ToDouble(fila.Cells[indice].Value) < nuevo1)
                    {
                        count3++;
                        posiciones_out3.Add(i);
                    }
                }

                nuevo1 = q1 - (1.5 * riq);
                nuevo3 = q3 + (1.5 * riq);

                for (indice = 1; indice < dgvaux.ColumnCount; indice++)
                {
                    if (dgvaux.Columns[indice].HeaderText == columna)
                    {
                        break;
                    }
                }
                for (int i = 0; i < dgvaux.RowCount - 1; i++)
                {
                    fila = dgvaux.Rows[i];
                    if (Convert.ToDouble(fila.Cells[indice].Value) > nuevo3 || Convert.ToDouble(fila.Cells[indice].Value) < nuevo1)
                    {
                        count1++;
                        posiciones_out1.Add(i);
                    }
                }
                if(count1 > 0)
                {
                    radioButton1.Enabled = true;
                }
                if(count3 > 0)
                {
                    radioButton2.Enabled = true;
                }
            }
            else if (cabecera[indiceCabecera][1] == "nominal")
            {
                panel1.Hide();
                string[] elementos = new string[dgvaux.RowCount - 1];
                int indice;

                for (indice = 1; indice < dgvaux.ColumnCount; indice++)
                {
                    if (dgvaux.Columns[indice].HeaderText == columna)
                    {
                        break;
                    }
                }
                for (int i = 0; i < dgvaux.RowCount - 1; i++)
                {
                    fila = dgvaux.Rows[i];
                    elementos[i] = fila.Cells[indice].Value.ToString();
                }
                //Lista de valores únicos

                List<string> ListaU = new List<string>();
                List<int> Frecuencias = new List<int>();

                //Calculamos moda
                int conteo;
                string aux;
                int repeated;

                for (int i = 0; i < elementos.Length; i++)
                {
                    repeated = 0;
                    aux = elementos[i];
                    conteo = 0;
                    foreach (string elem in ListaU)
                    {
                        if (aux == elem)
                        {
                            repeated = 1;
                            break;
                        }
                    }
                    if (repeated == 0)
                    {
                        ListaU.Add(aux);
                        for (int j = 0; j < elementos.Length; j++)
                        {
                            if (aux == elementos[j])
                                conteo++;
                        }
                        Frecuencias.Add(conteo);
                    }
                }
                // Hacemos la gráfica de barras para las frcuencias

                //Limpia el chart
                chart1.Hide();
                chart2.Show();

                /*for (int i = 0; i < chart2.Series.Count; i++)
                {
                    chart2.Series.RemoveAt(i);
                }*/
                chart2.Series.Clear();
                for(int i = 0; i < ListaU.Count; i++)
                {
                    chart2.Series.Add(ListaU[i]);
                    chart2.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                    chart2.Series[i].XValueMember = ListaU[i];
                    chart2.Series[i].Points.AddY(Frecuencias[i]);
                }
                labelMedia.Text = labelModa.Text = labelMediana.Text = labelDvStd.Text = "";
            }
        }

        private void PrimerAcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SegundoAcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Calcularbutton_Click(object sender, EventArgs e)
        {
            int indiCombo1 = PrimerAcomboBox.SelectedIndex + 1;
            int indiCombo2 = SegundoAcomboBox.SelectedIndex + 1;
            if (indiCombo1 == indiCombo2)
            {
                // Label advertencia mismo combo
                labelCCP.Text = "Selecciona atributos diferentes";
            }
            else if (cabecera[indiCombo1][1] != cabecera[indiCombo2][1])
            {
                //Advertencia incompatibilidad de tipos
                labelCCP.Text = "Selecciona atributos de igual tipo";
            }
            else if (cabecera[indiCombo1][1] == "numeric")
            {
                //correlación Pearson
                DataGridViewRow fila = new DataGridViewRow();

                //Creamos el arreglo en base a los datos del dgv

                double[] elementos1 = new double[dgvaux.RowCount - 1];
                double[] elementos2 = new double[dgvaux.RowCount - 1];
                int columna1, columna2;

                for (columna1 = 1; columna1 < dgvaux.ColumnCount; columna1++)
                {
                    if (dgvaux.Columns[columna1].HeaderText == cabecera[indiCombo1][0])
                    {
                        break;
                    }
                }
                for (columna2 = 1; columna2 < dgvaux.ColumnCount; columna2++)
                {
                    if (dgvaux.Columns[columna2].HeaderText == cabecera[indiCombo2][0])
                    {
                        break;
                    }
                }
                for (int i = 0; i < dgvaux.RowCount - 1; i++)
                {
                    fila = dgvaux.Rows[i];
                    elementos1[i] = Convert.ToDouble(fila.Cells[columna1].Value);
                    elementos2[i] = Convert.ToDouble(fila.Cells[columna2].Value);
                }

                double media1, media2;
                media1 = media2 = 0;

                for (int i = 0; i < elementos1.Length; i++)
                {
                    media1 += elementos1[i];
                    media2 += elementos2[i];
                }
                media1 = media1 / elementos1.Length;
                media2 = media2 / elementos2.Length;

                // Calculamos las desviaciones estándar

                double sumOfSqrs1, sumOfSqrs2, dvstd1, dvstd2, difMedia1, difMedia2, prodMedia, r;
                sumOfSqrs1 = sumOfSqrs2 = dvstd1 = dvstd2 = difMedia1 = difMedia2 = prodMedia = 0;


                for (int i = 0; i < elementos1.Length; i++)
                {

                    difMedia1 = (elementos1[i] - media1);
                    difMedia2 = (elementos2[i] - media2);

                    //arriba
                    prodMedia += (difMedia1 * difMedia2);

                    sumOfSqrs1 += Math.Pow(difMedia1, 2);
                    sumOfSqrs2 += Math.Pow(difMedia2, 2);


                }

                dvstd1 = Math.Sqrt(sumOfSqrs1 / (elementos1.Length));
                dvstd2 = Math.Sqrt(sumOfSqrs2 / (elementos2.Length));


                r = prodMedia / (elementos1.Length * dvstd1 * dvstd2);

                r = 1;
                labelCCP.Text = "Coeficiente de correlación de Pearson: " + r;
                if (r == -1)
                {
                    labelCCP.Text += "\nCorrelación lineal negativa perfecta";
                }
                else if (r < 0)
                {
                    labelCCP.Text += "\nCorrelación lineal negativa";
                }
                else if (r == 0)
                {
                    labelCCP.Text += "\nNo correlacionados";
                }
                else if (r < 1)
                {
                    labelCCP.Text += "\nCorrelación lineal positiva";
                }
                else if (r == 1)
                {
                    labelCCP.Text += "\nCorrelación lineal positiva perfecta";
                }
                //labelCCP.Text = "Coeficiente de correlación de Pearson: " + Convert.ToString(r) + " " + Convert.ToString(dvstd1) + " " + Convert.ToString(dvstd2)+ " " + elementos1.Length.ToString();
            }
            else if (cabecera[indiCombo1][1] == "nominal")
            {
                //Crear arreglo para las columnas
                DataGridViewRow fila = new DataGridViewRow();

                //Creamos el arreglo en base a los datos del dgv

                string[] elementos1 = new string[dgvaux.RowCount - 1];
                string[] elementos2 = new string[dgvaux.RowCount - 1];
                int columna1, columna2;


                for (columna1 = 1; columna1 < dgvaux.ColumnCount; columna1++)
                {
                    if (dgvaux.Columns[columna1].HeaderText == cabecera[indiCombo1][0])
                    {
                        break;
                    }
                }
                for (columna2 = 1; columna2 < dgvaux.ColumnCount; columna2++)
                {
                    if (dgvaux.Columns[columna2].HeaderText == cabecera[indiCombo2][0])
                    {
                        break;
                    }
                }
                for (int i = 0; i < dgvaux.RowCount - 1; i++)
                {
                    fila = dgvaux.Rows[i];
                    elementos1[i] = fila.Cells[columna1].Value.ToString();
                    elementos2[i] = fila.Cells[columna2].Value.ToString();
                }


                //Lista de valores unicos con frecuencia
                List<string> ListaU1 = new List<string>();
                List<int> Frecuencias1 = new List<int>();

                List<string> ListaU2 = new List<string>();
                List<int> Frecuencias2 = new List<int>();

                //
                int conteo;
                string aux1, aux2;
                int repeated1, repeated2;

                for (int i = 0; i < elementos1.Length; i++)
                {
                    repeated1 = 0;
                    aux1 = elementos1[i];
                    conteo = 0;
                    foreach (string elem in ListaU1)
                    {
                        if (aux1 == elem)
                        {
                            repeated1 = 1;
                            break;
                        }
                    }
                    if (repeated1 == 0)
                    {
                        ListaU1.Add(aux1);
                        for (int j = 0; j < elementos1.Length; j++)
                        {
                            if (aux1 == elementos1[j])
                                conteo++;
                        }
                        Frecuencias1.Add(conteo);
                    }
                }

                for (int i = 0; i < elementos2.Length; i++)
                {
                    repeated2 = 0;
                    aux2 = elementos2[i];
                    conteo = 0;
                    foreach (string elem in ListaU2)
                    {
                        if (aux2 == elem)
                        {
                            repeated2 = 1;
                            break;
                        }
                    }
                    if (repeated2 == 0)
                    {
                        ListaU2.Add(aux2);
                        for (int j = 0; j < elementos2.Length; j++)
                        {
                            if (aux2 == elementos2[j])
                                conteo++;
                        }
                        Frecuencias2.Add(conteo);
                    }
                }
                //Crear tabla de contingencia

                double[,] mfrecuencia = new double[ListaU1.Count + 1, ListaU2.Count + 1];
                int contador = 0;

                for (int a = 0; a < ListaU1.Count; a++)
                {
                    for (int b = 0; b < ListaU2.Count; b++)
                    {
                        contador = 0;

                        for (int c = 0; c < elementos1.Length; c++)
                        {
                            if (elementos1[c] == ListaU1[a] && elementos2[c] == ListaU2[b])
                            {
                                contador++;
                            }
                        }
                        mfrecuencia[a, b] = contador;
                    }
                }

                double totalFila = 0;

                //Lista U1 Columnas
                for (int a = 0; a < ListaU1.Count; a++)
                {
                    totalFila = 0;

                    for (int b = 0; b < ListaU2.Count; b++)
                    {
                        totalFila += mfrecuencia[a, b];
                    }

                    mfrecuencia[a, ListaU2.Count] = totalFila;

                }

                //Lista U2 Filas
                double totalColumna = 0;
                for (int a = 0; a < ListaU2.Count; a++)
                {
                    totalColumna = 0;

                    for (int b = 0; b < ListaU1.Count; b++)
                    {
                        totalColumna += mfrecuencia[b, a];
                    }

                    mfrecuencia[ListaU1.Count, a] = totalColumna;
                }
                mfrecuencia[ListaU1.Count, ListaU2.Count] = elementos1.Length;
                //U1 columnas, U2 filas
                double[] FrecR = new double[ListaU1.Count * ListaU2.Count];
                int contFrecR = 0;
                double p1 = 0;
                for (int i = 0; i < ListaU1.Count; i++)
                {
                    for (int j = 0; j < ListaU2.Count; j++)
                    {
                        p1 = (mfrecuencia[i, ListaU2.Count] * mfrecuencia[ListaU1.Count, j])/ elementos1.Length;

                        FrecR[contFrecR] = (Math.Pow((mfrecuencia[i, j] - p1), 2)) / p1;
                        contFrecR++;
                    }
                }
                double chicuadrada = 0;
                foreach(double frecr in FrecR)
                {
                    chicuadrada += frecr;
                }
                double cct = 0;

                cct = Math.Sqrt(chicuadrada / (Math.Sqrt((ListaU1.Count - 1) * (ListaU2.Count - 1)) * elementos1.Length));

                labelCCP.Text = "Coeficiente de contingencia de Tschuprow: "+ cct +'\n';

                if(cct >= 0.5)
                {
                    labelCCP.Text += "Completa dependencia entre valores";
                }
                else if(cct<0.5)
                {
                    labelCCP.Text += "Completa independencia";
                }
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)//1.5 IQR
            {
                for(int i = 0; i<elementosCpy.Count;i++)
                {
                    foreach(int value in posiciones_out1)
                    {
                        if(i == value)
                        {
                            elementosCpy[i] = (elementosCpy[i] - media) / Math.Pow((elementosCpy[i] - media), 2);
                        }
                    }
                }
            }
            else if (radioButton2.Checked == false)//3 IQR
            {
                for (int i = 0; i < elementosCpy.Count; i++)
                {
                    foreach (int value in posiciones_out3)
                    {
                        if (i == value)
                        {
                            elementosCpy[i] = (elementosCpy[i] - media) / Math.Pow((elementosCpy[i] - media), 2);
                            
                        }
                    }
                }
            }
            DataGridViewRow row = new DataGridViewRow();
            for(int i = 0; i < dgvaux.RowCount - 1;i++) {
                row = dgvaux.Rows[i];
                row.Cells[indiceCabecera].Value = elementosCpy[i];
            }
            //Actualizamos el boxplot
            //BoxPlot

            chart1.Show();
            chart2.Hide();

            chart1.Series.Clear();

            chart1.Series.Add(columna);
            chart1.Series[columna].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            chart1.Series[columna].XValueMember = columna;

            chart1.Series[columna].Points.AddXY(0, elementosCpy[0], elementosCpy[elementosCpy.Count - 1], q1, q3, media, mediana);

            this.DialogResult = DialogResult.OK;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        
    }
}
