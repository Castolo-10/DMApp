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
        List<string[]> cabecera = new List<string[]>();
        string filepath;
        int nInstancia;
        int faltantes;


        public Form1()
        {
            InitializeComponent();
        }

        private void CargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Vaciamos las listas
            atributo.Clear();
            faltante.Clear();
            cabecera.Clear();
            faltantes = 0;

            openFileDialog1.Title = "Abrir archivo";
            openFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv|Archivos DATA(*.data)|*.data";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
                DataTable dt = new DataTable();
                dataGridView1.DataSource = null;
                label1.Text = "Información general\n";
                label2.Text = "Nombre del conjunto de datos\n";
                label3.Text = "Cantidad de instancias\n";
                label4.Text = "Cantidad de atributos\n";
                label5.Text = "Valores faltantes\n";
                label6.Text = "Proporción de valores faltantes\n";
                if (filepath.Contains(".csv"))
                    dt = LeerCSV(dt);
                else if (filepath.Contains(".data"))
                    dt = LeerDATA(dt);
                if (dt.Rows.Count >= 0)
                    dataGridView1.DataSource = dt;
                    this.Text = "DMApp - " + Path.GetFileName(filepath);
                    MessageBox.Show("El archivo ha sido cargado correctamente","Aviso");
                    //Actualizar info de labels y textbox sobre el dataset
            }
        }
        private DataTable LeerCSV(DataTable dt)
        {
            nInstancia = 1;
            string[] lines = File.ReadAllLines(filepath);
            if (lines.Length > 0)
            {
                // Leemos el header
                string firstLine = "Instancia,"+lines[0];
                string[] headerLabels = firstLine.Split(',');
                //Obtener no.atributos
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                //Leemos los datos
                for (int r = 1; r < lines.Length; r++)
                {
                    string instance = nInstancia.ToString() + ',' + lines[r];
                    string[] dataWords = instance.Split(',');
                    nInstancia++;
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    dr[0] = nInstancia;
                    
                    foreach (string headerWord in headerLabels)
                    {
                        //Validar missingvalue
                        if (dataWords[columnIndex].Equals(""))
                        {
                            faltantes++;
                        }
                        dr[headerWord] = dataWords[columnIndex++];
                        
                    }
                    dt.Rows.Add(dr);
                    // Aqui nInstancia vale el no. de instancias totales mas el identificador (restar 1)
                    label3.Text = "Cantidad de instancias\n" + (nInstancia-1); 

                }
                label4.Text = "Cantidad de atributos\n" + (headerLabels.LongCount()-1);
                label5.Text = "Valores faltantes\n" + faltantes;
                label6.Text = "Proporción de valores faltantes\n" + ((faltantes * 100) / ( (nInstancia - 1) * (headerLabels.LongCount() - 1))) + "%";
            }
            return dt;
        }
        private DataTable LeerDATA(DataTable dt)
        {
            string[] lines = File.ReadAllLines(filepath);
            if (lines.Length > 0)
            {
                int x = 0;
                int y = 0;
                nInstancia = 1;
                bool df = false;
                // Leemos la info general
                string[] copia = new string[3];
                copia[0] = "Instancia";
                cabecera.Add(copia);
                foreach (string lin in File.ReadAllLines(filepath))
                {
                    //leer los datos y situarlos en la tabla
                    if (df == true)
                    {
                        string instance = nInstancia.ToString() + ',' + lin;
                        nInstancia++;
                        string[] dataWords = instance.Split(',');
                        DataRow dr = dt.NewRow();
                        int columnIndex = 0;
                        

                        foreach (string[] headerWord in cabecera)
                        {
                            foreach (string aux in faltante)
                            {
                                if (dataWords[columnIndex] == aux)
                                {
                                    faltantes++;
                                }
                            }
                            dr[headerWord[0]] = dataWords[columnIndex++];

                            
                        }
                        dt.Rows.Add(dr);

                    }
                    label3.Text = "Cantidad de instancias\n"+ (nInstancia-1);

                    //Leer información general
                    if (lin.Substring(0, 3) == "%% ")
                    {
                        label1.Text += lin.Substring(3)+'\n';
                    }

                    //Leer nombre del conjunto de datos
                    if (lin.Substring(0, 5) == "@rela")
                    {
                        label2.Text = "Nombre del conjunto de datos\n" + lin.Substring(10);
                    }

                    //Leer atributos, y guardarlos en una lista de strings (toda la
                    //linea correspondiente al dato
                    if (lin.Substring(0, 5) == "@attr")
                    {

                        atributo.Add(lin.Substring(11));

                        //Crear cabecera

                        int a = 0;
                        for (int i = 0; i < atributo[x].Length; i++)
                        {
                            if (atributo[x][i] != ' ')
                            {
                                a++;

                            }
                            else
                                break;
                        }
                        copia = new string[3];
                        copia[0] = atributo[x].Substring(0, a);
                        string subSatrib = atributo[x].Substring(a + 1);
                        int b = 0;
                        for (int i = 0; i < subSatrib.Length; i++)
                        {
                            if (subSatrib[i] != ' ')
                            {
                                b++;

                            }
                            else
                                break;
                        }
                        copia[1] = subSatrib.Substring(0, b);
                        copia[2] = subSatrib.Substring(b + 1);
                        cabecera.Add(copia);

                        x++;
                    }
                    label4.Text = "Cantidad de atributos\n" + (cabecera.Count()-1);

                    //leer valores faltantes y guardarlos en una lista de faltantes
                    if (lin.Substring(0, 5) == "@miss")
                    {
                        faltante.Add(lin.Substring(14));
                        y++;
                    }

                    //localiza la línea @data para a partir de esta leer los datos
                    if (lin.Substring(0, 5) == "@data")
                    {
                        df = true;
                        //falta leer cabecera con atributo list
                        foreach (string[] headerWord in cabecera)
                        {
                            dt.Columns.Add(new DataColumn(headerWord[0]));
                        }
                    }
                }
                label5.Text = "Valores faltantes\n" + faltantes;
                label6.Text = "Proporción de valores faltantes\n" + ((faltantes * 100) / ((nInstancia - 1) * (cabecera.LongCount() - 1))) + "%";

            }
            return dt;
        }
        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (filepath.Contains(".csv")) {
                flag = SaveCSV();
            }
            else if (filepath.Contains(".data"))
            {
                flag = SaveDATA();
            }
            if(flag)
                MessageBox.Show("El archivo ha sido guardado correctamente", "Aviso");
        }
        private bool SaveCSV()
        {
            try
            {
                System.IO.StreamWriter csvFileWriter = new StreamWriter(filepath, false);

                string columnHeaderText = "";

                int countColumn = dataGridView1.ColumnCount - 1;
                //Guardamos el header en un string
                if (countColumn >= 0)
                {
                    columnHeaderText = dataGridView1.Columns[1].HeaderText;
                }

                for (int i = 2; i <= countColumn; i++)
                {
                    columnHeaderText = columnHeaderText + ',' + dataGridView1.Columns[i].HeaderText;
                }

                //Guarda el string del header en el csv
                csvFileWriter.WriteLine(columnHeaderText);

                //Leer los datos
                foreach (DataGridViewRow dataRowObject in dataGridView1.Rows)
                {
                    if (!dataRowObject.IsNewRow)
                    {
                        string dataFromGrid = "";

                        //Para cada fila genera la cadena con el formato
                        for (int i = 1; i <= countColumn; i++)
                        {
                            if (i != countColumn)
                                dataFromGrid += dataRowObject.Cells[i].Value.ToString() + ',';
                            else if (i == countColumn)
                                dataFromGrid += dataRowObject.Cells[i].Value.ToString();

                        }
                        //Escribe la fila al archivo
                        csvFileWriter.WriteLine(dataFromGrid);
                    }
                }
                csvFileWriter.Flush();
                csvFileWriter.Close();
            }
            catch (Exception exceptionObject)
            {
                MessageBox.Show(exceptionObject.ToString());
                return false;
            }
            return true;
        }
        private bool SaveDATA()
        {
            try
            {
                System.IO.StreamWriter csvFileWriter = new StreamWriter(filepath, false);

                string[] rowInfo = label1.Text.Substring(19).Split('\n');
                    foreach (string strInfo in rowInfo)
                    {
                        if(strInfo != "")
                            csvFileWriter.WriteLine("%% " + strInfo);
                    }
                if(label2.Text.Substring(29) != "")
                    csvFileWriter.WriteLine("@relation " + label2.Text.Substring(29));

                int countColumn = dataGridView1.ColumnCount - 1;
                //Guardamos el header
                for (int i = 1; i <= countColumn; i++)
                {
                    if (cabecera.Count != 0)
                        csvFileWriter.WriteLine("@attribute " + cabecera[i][0] + ' ' + cabecera[i][1] + ' ' + cabecera[i][2]);
                    else
                        csvFileWriter.WriteLine("@attribute " + dataGridView1.Columns[i].HeaderText + " unknown ");
                }

                //Guardar missingvalues
                int miss_cont = 0;
                if (faltante.Count != 0)
                    foreach (string miss in faltante)
                    {
                        csvFileWriter.WriteLine("@missingValue " + faltante[miss_cont]);
                        miss_cont++;
                    }

                //Guardar los datos
                csvFileWriter.WriteLine("@data");
                foreach (DataGridViewRow dataRowObject in dataGridView1.Rows)
                {
                    if (!dataRowObject.IsNewRow)
                    {
                        string dataFromGrid = "";

                        //Para cada fila genera la cadena con el formato
                        for (int i = 1; i <= countColumn; i++)
                        {
                            if (i != countColumn)
                                dataFromGrid += dataRowObject.Cells[i].Value.ToString() + ',';
                            else if (i == countColumn)
                                dataFromGrid += dataRowObject.Cells[i].Value.ToString();

                        }
                        //Escribe la fila al archivo
                        csvFileWriter.WriteLine(dataFromGrid);
                    }
                }
                csvFileWriter.Flush();
                csvFileWriter.Close();
            }
            catch (Exception exceptionObject)
            {
                MessageBox.Show(exceptionObject.ToString());
                return false;
            }
            return true;
        }
        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Abrir archivo";
            saveFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv|Archivos DATA(*.data)|*.data";
            saveFileDialog1.FileName = "";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\dev\\DMApp\\files";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = saveFileDialog1.FileName;
                label1.Text = "Información general\n";
                label2.Text = "Nombre del conjunto de datos\n";
                if (filepath.Contains(".csv"))
                    SaveCSV();
                else if (filepath.Contains(".data"))
                    SaveDATA();
                this.Text = "DMApp - " + Path.GetFileName(filepath);
                MessageBox.Show("El archivo ha sido guardado correctamente", "Aviso");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
