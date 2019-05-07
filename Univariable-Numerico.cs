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
        DataGridView dgvaux;
        List<string[]> cabecera;

        public Univariable_Numerico(DataGridView dgv, List<string[]> header)
        {
            InitializeComponent();
            dgvaux = dgv;
            cabecera = header;
            labelMedia.Text = labelModa.Text = labelMediana.Text = labelDvStd.Text = "";

        }
        private void Univariable_Numerico_Load(object sender, EventArgs e)
        {
            for(int i = 1; i < cabecera.Count; i++)
            {
                if(cabecera[i][1] == "numeric" || cabecera[i][1] == "nominal")
                {
                    comboAtributo.Items.Add(cabecera[i][0]);
                    PrimerAcomboBox.Items.Add(cabecera[i][0]);
                    SegundoAcomboBox.Items.Add(cabecera[i][0]);

                }
            }
        }

        private void ComboAtributo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Creamos el arreglo en base a los datos del dgv
            string columna = comboAtributo.SelectedItem.ToString();
            int indiceCabecera = comboAtributo.SelectedIndex + 1;
            DataGridViewRow fila = new DataGridViewRow();
            if (cabecera[indiceCabecera][1] == "numeric") {
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

                //Calculamos Media
                double media = 0;

                foreach (double valor in elementos)
                {
                    media += valor;
                }
                media = media / elementos.Length;
                labelMedia.Text = "Media: " + media.ToString();

                //Calculamos mediana

                int ismediana = elementos.Length % 2;
                int indicemediana = elementos.Length / 2;
                double mediana = (ismediana == 1) ? elementos[Convert.ToInt16(indicemediana - 0.5)] : ((elementos[indicemediana - 1] + elementos[indicemediana]) / 2);
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
                double q1, q3;

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
            }
            else if (cabecera[indiceCabecera][1] == "nominal")
            {
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
            }
            else if (cabecera[indiCombo1][1] != cabecera[indiCombo2][1])
            {
                //Advertencia incompatibilidad de tipos
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

                for(int i = 1; i < elementos1.Length;i++)
                {
                    media1 += elementos1[i];
                    media2 += elementos2[i];
                }
                media1 = media1 / elementos1.Length;
                media2 = media2 / elementos2.Length;

                // Calculamos las desviaciones estándar

                double sumOfSqrs1, sumOfSqrs2, dvstd1, dvstd2,difMedia1, difMedia2, prodMedia, r;
                sumOfSqrs1 = sumOfSqrs2 = dvstd1 = dvstd2 = difMedia1 = difMedia2 = prodMedia = 0;


                for (int i = 0; i < elementos1.Length; i++)
                {
                    difMedia1 = (elementos1[i] - media1);
                    difMedia2 = (elementos2[i] - media2);
                    sumOfSqrs1 += Math.Pow(difMedia1, 2);
                    sumOfSqrs2 += Math.Pow(difMedia2, 2);
                    prodMedia += (difMedia1 * difMedia2);

                }
                dvstd1 = Math.Sqrt(sumOfSqrs1 / (elementos1.Length));
                dvstd2 = Math.Sqrt(sumOfSqrs2 / (elementos2.Length));

                r = prodMedia / (elementos1.Length * dvstd1 * dvstd2);
                labelCCP.Text = "Coeficiente de correlación de Pearson: " + Convert.ToString(r) + " " + Convert.ToString(dvstd1) + " " + Convert.ToString(dvstd2)+ " " + elementos1.Length.ToString();
            }
            else if (cabecera[indiCombo1][1] == "nominal")
            {
                //Chi cuadrada con contingencia de tschuprow
            }

        }
    }
}
