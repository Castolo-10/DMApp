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
        }
        private void Univariable_Numerico_Load(object sender, EventArgs e)
        {
            for(int i = 1; i < cabecera.Count; i++)
            {
                if(cabecera[i][1] == "numeric")
                    comboAtributo.Items.Add(cabecera[i][0]);
            }
        }

        private void ComboAtributo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Creamos el arreglo en base a los datos del dgv
            string columna = comboAtributo.SelectedItem.ToString();
            DataGridViewRow fila = new DataGridViewRow();
            double[] elementos = new double[dgvaux.RowCount - 1];
            int indice;

            for(indice = 1;indice<dgvaux.ColumnCount;indice++)
            {
                if(dgvaux.Columns[indice].HeaderText == columna)
                {
                    break;
                }
            }
            for(int i = 0; i < dgvaux.RowCount - 1; i++)
            {
                fila = dgvaux.Rows[i];
                elementos[i] = Convert.ToDouble(fila.Cells[indice].Value);
            }
            //Ordenamos la lista
            /*double temp = 0;

            for (int write = 0; write < elementos.Length; write++)
            {
                for (int sort = 0; sort < elementos.Length - 1; sort++)
                {
                    if (elementos[sort] > elementos[sort + 1])
                    {
                        temp = elementos[sort + 1];
                        elementos[sort + 1] = elementos[sort];
                        elementos[sort] = temp;
                    }
                }
            }*/
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

            foreach(double valor in elementos)
            {
                media += valor;
            }
            media = media/elementos.Length;
            labelMedia.Text = "Media: " + media.ToString();

            //Calculamos mediana

            int ismediana = elementos.Length % 2;
            int indicemediana = elementos.Length / 2;
            double mediana = (ismediana == 1) ? elementos[Convert.ToInt16(indicemediana - 0.5)] : ((elementos[indicemediana - 1] + elementos[indicemediana])/2);
            labelMediana.Text = "Mediana: " + mediana.ToString();

            //Lista de valores únicos

            List<double> ListaU = new List<double>();

            /*foreach(double value in elementos)
            {
                ListaU.Find(value)
            }*/

            //Calculamos moda
            int conteo;
            int previomax = 0;
            double aux;
            double moda = 0;
            int repeated;

            for (int i=0;i<elementos.Length;i++)
            {
                repeated = 0;
                aux = elementos[i];
                conteo = 0;
                foreach (double elem in ListaU)
                {
                    if(aux == elem)
                    {
                        repeated = 1;
                        break;
                    }
                }
                if(repeated == 0)
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
            q3 = elementos[((elementos.Length / 4)*3) - 1];

            //BoxPlot
            
            double rango = elementos[elementos.Length - 1] - elementos[0];
            double varianza = Math.Pow(dvstd,2);
            double[,] boxplot = new double[1,6];
            boxplot[0,0] = elementos[0];
            boxplot[0,1] = elementos[elementos.Length - 1];
            boxplot[0,2] = q1;
            boxplot[0,3] = q3;
            boxplot[0,4] = media;
            boxplot[0,5] = mediana;

            chart1.Series.RemoveAt(0);
            chart1.Series.Add(columna);
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            chart1.Series[0].XValueMember = columna;

            chart1.Series[columna].Points.AddXY(0, elementos[0], elementos[elementos.Length - 1], q1, q3, media, mediana);
        }
    }
}
