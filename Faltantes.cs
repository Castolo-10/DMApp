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
    public partial class Faltantes : Form
    {
        List<string[]> cabecera = new List<string[]>();
        List<string[]> cabeceraaux = new List<string[]>();
        List<string> faltante = new List<string>();
        public int faltantes1 { get; set; }
        public DataGridView dgv { get; set; }
        public bool modificado {get; set;}
        bool isNumeric = false;
        string filepath;
        public Faltantes(DataGridView data, bool mod, List<string[]> header, string path, List<string> faltantes, int numfaltante)
        {
            InitializeComponent();
            cabeceraaux = header;
            dgv = data;
            modificado = mod;
            button1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            filepath = path;
            faltante = faltantes;
            faltantes1 = numfaltante;
        }

        private void Falantes_Load(object sender, EventArgs e)
        {
            cabecera.Add(cabeceraaux[0]);
            for (int i = 1; i < cabeceraaux.Count; i++)
            {
                if (cabeceraaux[i][1] == "numeric" || cabeceraaux[i][1] == "nominal")
                {
                    comboBox1.Items.Add(cabeceraaux[i][0]);
                    cabecera.Add(cabeceraaux[i]);
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceCabecera = comboBox1.SelectedIndex + 1;
            if (cabecera[indiceCabecera][1] == "numeric")
            {
                radioButton1.Select();
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                isNumeric = true;
            }
            else if (cabecera[indiceCabecera][1] == "nominal")
            {
                radioButton2.Select();
                radioButton2.Enabled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int indiceCabecera = comboBox1.SelectedIndex + 1;
            if(isNumeric)//Si es numerico y quiere Mediana
            {
                double medmoda=0;
                List<double> elementos = new List<double>();

                //Llenamos arreglo
                int indice;
                double elemaux = 0;
                bool flag1 = false;
                string columna = comboBox1.SelectedItem.ToString();
                DataGridViewRow fila = new DataGridViewRow();

                for (indice = 1; indice < dgv.ColumnCount; indice++)
                {
                    if (dgv.Columns[indice].HeaderText == columna)
                    {
                        break;
                    }
                }
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    fila = dgv.Rows[i];
                    if(filepath.Contains(".csv") && fila.Cells[indice].Value.ToString() != "")
                    {
                        elementos.Add(Convert.ToDouble(fila.Cells[indice].Value));
                    }
                    else
                    {
                        flag1 = false;
                        foreach (string miss in faltante)
                        {
                            if (fila.Cells[indice].Value.ToString() != miss)
                            {
                                flag1 = true;
                                elemaux = Convert.ToDouble(fila.Cells[indice].Value);
                            }
                            else
                            {
                                flag1 = false;
                                break;
                            }
                        }
                        if (flag1)
                        {
                            elementos.Add(elemaux);
                        }
                    }

                }

                //Ordenamos el arreglo
                double val;
                int flag = 0;
                for (int i = 1; i < elementos.Count; i++)
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

                if (radioButton1.Checked == true)//Si es numerico y quiere Mediana
                {
                    // Calculamos mediana
                    int ismediana = elementos.Count % 2;
                    int indicemediana = elementos.Count / 2;
                    medmoda = (ismediana == 1) ? elementos[Convert.ToInt16(indicemediana - 0.5)] : ((elementos[indicemediana - 1] + elementos[indicemediana]) / 2);
                }
                else//Si es numerico y quiere Moda
                {
                    //Lista de valores únicos

                    List<double> ListaU = new List<double>();

                    //Calculamos moda
                    int conteo;
                    int previomax = 0;
                    double aux;
                    int repeated;

                    for (int i = 0; i < elementos.Count; i++)
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
                            for (int j = 0; j < elementos.Count; j++)
                            {
                                if (aux == elementos[j])
                                    conteo++;
                            }
                            if (conteo > previomax)
                            {
                                medmoda = aux;
                                previomax = conteo;
                            }
                        }
                    }
                }

                //Rellenar vacios
                DataGridViewRow row = new DataGridViewRow();
                if (filepath.Contains(".data"))
                {
                    for (int i = 0; i < dgv.RowCount-1; i++)
                    {
                        row = dgv.Rows[i];
                        foreach(string miss in faltante)
                        {
                            if (row.Cells[indiceCabecera].Value.ToString() == miss)
                            {
                                row.Cells[indiceCabecera].Value = medmoda;
                                faltantes1--;
                            }
                        }
                    }
                }
                else if (filepath.Contains(".csv"))
                {
                    for (int i = 0; i < dgv.RowCount-1; i++)
                    {
                        row = dgv.Rows[i];
                        if (row.Cells[indiceCabecera].Value.ToString() == "")
                        {
                            row.Cells[indiceCabecera].Value = medmoda;
                            faltantes1--;
                        }
                    }
                }
            }
            else
            {
                if (radioButton2.Checked == true)//Si es nominal y quiere Moda
                {
                    string moda = "";
                    List<string> elementos = new List<string>();

                    //Llenamos arreglo
                    int indice;
                    string elemaux = "";
                    bool flag1 = false;
                    string columna = comboBox1.SelectedItem.ToString();
                    DataGridViewRow fila = new DataGridViewRow();

                    for (indice = 1; indice < dgv.ColumnCount; indice++)
                    {
                        if (dgv.Columns[indice].HeaderText == columna)
                        {
                            break;
                        }
                    }
                    for (int i = 0; i < dgv.RowCount - 1; i++)
                    {
                        fila = dgv.Rows[i];
                        if (filepath.Contains(".csv") && fila.Cells[indice].Value.ToString() != "")
                        {
                            elementos.Add(Convert.ToString(fila.Cells[indice].Value));
                        }
                        else
                        {
                            flag1 = false;
                            foreach (string miss in faltante)
                            {
                                if (fila.Cells[indice].Value.ToString() != miss)
                                {
                                    flag1 = true;
                                    elemaux = Convert.ToString(fila.Cells[indice].Value);
                                }
                                else
                                {
                                    flag1 = false;
                                    break;
                                }
                            }
                            if (flag1)
                            {
                                elementos.Add(elemaux);
                            }
                        }
                    }

                    //Lista de valores únicos

                    List<string> ListaU = new List<string>();
                    List<int> Frecuencias = new List<int>();

                    //Calculamos moda
                    int conteo;
                    string aux;
                    int repeated;

                    for (int i = 0; i < elementos.Count; i++)
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
                            for (int j = 0; j < elementos.Count; j++)
                            {
                                if (aux == elementos[j])
                                    conteo++;
                            }
                            Frecuencias.Add(conteo);
                        }
                    }
                    int max=0;
                    int indiceMediana=0;
                    for(int i = 0;i<Frecuencias.Count;i++)
                    {
                        if (Frecuencias[i] > max)
                        {
                            max = Frecuencias[i];
                            indiceMediana = i;
                        }
                    }

                    //**//
                    //Rellenar vacios
                    DataGridViewRow row = new DataGridViewRow();
                    if (filepath.Contains(".data"))
                    {
                        for (int i = 0; i < dgv.RowCount - 1; i++)
                        {
                            row = dgv.Rows[i];
                            foreach (string miss in faltante)
                            {
                                if (row.Cells[indiceCabecera].Value.ToString() == miss)
                                {
                                    row.Cells[indiceCabecera].Value = ListaU[indiceMediana];
                                    faltantes1--;
                                }
                            }
                        }
                    }
                    else if (filepath.Contains(".csv"))
                    {
                        for (int i = 0; i < dgv.RowCount - 1; i++)
                        {
                            row = dgv.Rows[i];
                            if (row.Cells[indiceCabecera+1].Value.ToString() == "")
                            {
                                row.Cells[indiceCabecera+1].Value = ListaU[indiceMediana].ToString();
                                faltantes1--;
                            }
                        }
                    }
                }
            }
            modificado = true;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
