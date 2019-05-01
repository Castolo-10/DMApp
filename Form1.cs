using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DMApp
{
    public partial class Form1 : Form
    {
        List<string> atributo = new List<string>();
        List<string> faltante = new List<string>();
        List<string> cabecera = new List<string>();
        string filepath;

        public Form1()
        {
            InitializeComponent();
        }

        private void CargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            openFileDialog1.Title = "Abrir archivo";
            openFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv|Archivos DATA(*.data)|*.data";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
                DataTable dt = new DataTable();
                if (filepath.Contains(".csv"))
                {
                    string[] lines = File.ReadAllLines(filepath);
                    if (lines.Length > 0)
                    {
                        // Leemos el header
                        string firstLine = lines[0];
                        string[] headerLabels = firstLine.Split(',');

                        foreach (string headerWord in headerLabels)
                        {
                            dt.Columns.Add(new DataColumn(headerWord));
                        }

                        //Leemos los datos
                        for (int r = 1; r < lines.Length; r++)
                        {
                            string[] dataWords = lines[r].Split(',');
                            DataRow dr = dt.NewRow();
                            int columnIndex = 0;
                            foreach (string headerWord in headerLabels)
                            {
                                dr[headerWord] = dataWords[columnIndex++];
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                }
                else if (filepath.Contains(".data"))
                {

                    string[] lines = File.ReadAllLines(filepath);
                    if (lines.Length > 0)
                    {
                        int x = 0;
                        int y = 0;
                        bool df = false;
                        // Leemos la info general
                        string firstLine = lines[0];
                        
                        List<string> headerLabels = new List<string>();


                        foreach (string lin in File.ReadAllLines(filepath))
                        {
                            //leer los datos y situarlos en la tabla
                            if (df == true)
                            {
                                string[] dataWords = lin.Split(',');
                                DataRow dr = dt.NewRow();
                                int columnIndex = 0;

                                foreach (string headerWord in cabecera)
                                {
                                    dr[headerWord] = dataWords[columnIndex++];
                                }
                                dt.Rows.Add(dr);

                            }

                            //Leer información general
                            if (lin.Substring(0, 2) == "%%")
                            {
                                InformaciontextBox.Text += "\n" + lin.Substring(2);
                            }

                            //Leer nombre del conjunto de datos
                            if (lin.Substring(0, 5) == "@rela")
                            {
                                NombreConjuntoDtextBox.Text += "\n" + lin.Substring(10);
                            }

                            //Leer atributos, y guardarlos en una lista de strings (toda la
                            //linea correspondiente al dato
                            if (lin.Substring(0, 5) == "@attr")
                            {
                                
                                
                                atributo.Add(lin.Substring(11));
                                Pruebastext.Text += "\n" + atributo[x];

                                //Crear cabecera
                                
                                 int a =0;
                                 for (int i=0; i< atributo[x].Length; i++)
                                 {
                                     if (atributo[x][i] != ' ')
                                     {
                                         a++;

                                     }
                                     else
                                         i=atributo[x].Count() + 1;
                                 }
                                 


                                string copia = atributo[x].Substring(0,a);
                                cabecera.Add(copia);
                                //headerLabels[x] = copia;

                                x++;
                            }

                            //leer valores faltantes y guardarlos en una lista de faltantes
                            if (lin.Substring(0, 5) == "@miss")
                            {

                                
                                faltante.Add(lin.Substring(13));
                                Pruebastext.Text += "\n" + faltante[y];
                                y++;
                            }

                            //localiza la línea @data para a partir de esta leer los datos
                            if (lin.Substring(0, 5) == "@data")
                            {
                                df = true;
                                //falta leer cabecera con atributo list
                                foreach (string headerWord in cabecera)
                                {
                                    dt.Columns.Add(new DataColumn(headerWord));
                                }
                            }
                        }
                        
                    }


                }
                if (dt.Rows.Count >= 0)
                    dataGridView1.DataSource = dt;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.StreamWriter csvFileWriter = new StreamWriter(filepath, false);

                string columnHeaderText = "";

                int countColumn = dataGridView1.ColumnCount - 1;

                if (countColumn >= 0)
                {
                    columnHeaderText = dataGridView1.Columns[0].HeaderText;
                }

                for (int i = 1; i <= countColumn; i++)
                {
                    columnHeaderText = columnHeaderText + ',' + dataGridView1.Columns[i].HeaderText;
                }


                csvFileWriter.WriteLine(columnHeaderText);

                foreach (DataGridViewRow dataRowObject in dataGridView1.Rows)
                {
                    if (!dataRowObject.IsNewRow)
                    {
                        string dataFromGrid = "";

                        for (int i = 0; i <= countColumn; i++)
                        {
                            if (i != countColumn)
                                dataFromGrid += dataRowObject.Cells[i].Value.ToString() + ',';
                            else if (i == countColumn)
                                dataFromGrid += dataRowObject.Cells[i].Value.ToString();

                        }
                        csvFileWriter.WriteLine(dataFromGrid);
                    }
                }
                csvFileWriter.Flush();
                csvFileWriter.Close();
            }
            catch (Exception exceptionObject)
            {
                MessageBox.Show(exceptionObject.ToString());
            }
        }
    }
}
