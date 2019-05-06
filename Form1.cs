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
using System.Text.RegularExpressions;

namespace DMApp
{
    public partial class Form1 : Form
    {
        List<string> atributo = new List<string>();
        List<string> faltante = new List<string>();
        List<string[]> cabecera = new List<string[]>();
        string filepath = "";
        int nInstancia;
        int faltantes;
        public int indexCB = 0;
        bool modificaciones = false;
        int sal = 0;

        public Form1()
        {
            InitializeComponent();
            guardarToolStripMenuItem.Enabled = false;
            guardarComoToolStripMenuItem.Enabled = false;
        }

        private void CargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Vaciamos las listas
            atributo.Clear();
            faltante.Clear();
            cabecera.Clear();
            faltantes = 0;
            atributoscomboBox.Items.Clear();

            openFileDialog1.Title = "Abrir archivo";
            openFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv|Archivos DATA(*.data)|*.data";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\dev\\DMApp\\files";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guardarToolStripMenuItem.Enabled = true;
                guardarComoToolStripMenuItem.Enabled = true;
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
                {
                    dataGridView1.DataSource = dt;
                    if (filepath.Contains(".data"))
                    {
                        //EvalRegex();
                        //label8.Text = pruebaRegx.ToString();
                    }
                    this.Text = "DMApp - " + Path.GetFileName(filepath);
                    MessageBox.Show("El archivo ha sido cargado correctamente", "Aviso");
                    //Actualizar info de labels y textbox sobre el dataset
                }
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
                string[] copia = new string[3];
                copia[0] = "Instancia";
                cabecera.Add(copia);
                string[] headerLabels = firstLine.Split(',');
                //Obtener no.atributos

                foreach (string headerWord in headerLabels)
                {
                    string[] copia2 = new string[3];
                    dt.Columns.Add(new DataColumn(headerWord));
                    atributo.Add(headerWord + " " + "." + " " + ".");
                    copia2[0] = headerWord;
                    copia2[1] = ".";
                    copia2[2] = ".";
                    if (headerWord != "Instancia")
                    {
                        atributoscomboBox.Items.Add(headerWord);
                        cabecera.Add(copia2);
                    }
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
                            if(headerWord[0] != "Instancia")
                                atributoscomboBox.Items.Add(headerWord[0]);
                        }
                    }
                }
                label5.Text = "Valores faltantes\n" + faltantes;
                label6.Text = "Proporción de valores faltantes\n" + ((faltantes * 100) / ((nInstancia - 1) * (cabecera.Count() - 1))) + "%";

            }
            return dt;
        }
        public void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
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
                    if ((cabecera[i][1].Length > 0) || (cabecera[i][2].Length > 0))
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
        private void EditarAtributosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void AtributoscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion;
            seleccion= Convert.ToString(atributoscomboBox.SelectedItem);
            indexCB = atributoscomboBox.SelectedIndex;
            string nuevo = " ";
            string old = "";
            
            
            
            string copia;
            if (seleccion != " ")
            {
                int o = 0;

                /*Comparación de atributo seleccionado con la lista de atributos
                previamente tuve que hacer que los csv tambien tuvieran una lista 
                de atributos, en ellos cada elemento solamente tiene el nombre del atributo
                La comparación toma el nombre del atributo y lo compara cada elemento de la
                lista de atributos hasta el primer espacio (para que compare con csv y data)
                   
                    */
                o = 0;
                foreach(string seleccionado in atributo)
                {
                    //encuentra el nombre
                    int a = 0;
                    for (int i = 0; i < seleccionado.Length; i++)
                    {
                        if (seleccionado[i] != ' ')
                        {
                            a++;

                        }
                        else
                            break;
                    }
                    
                    //lo compara con el seleccionado
                    copia = seleccionado.Substring(0,a);
                    if(copia == seleccion)
                    {
                        old = copia;
                        DataGridView dgv = dataGridView1;
                        AtributosForm frm = new AtributosForm(seleccionado,dgv,indexCB,modificaciones);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            nuevo = frm.atributo;
                            modificaciones = frm.modificado;
                            /**/
                            break;
                            /**/

                        }
                        else
                        {
                            modificaciones = frm.modificado; ;
                            dataGridView1 = frm.dgv;
                            indexCB = frm.index;
                            cabecera.RemoveAt(frm.index2);
                            atributoscomboBox.Items.RemoveAt(frm.index);
                            
                            return;
                        }
                        //"nuevo" corresponde a el nuevo atributo modificado en el form de atributos
                    }
                    //o es usado para contar en que lugar se encuetra ese atributo
                    o++;
                }

                if (modificaciones)
                {
                    //Guardar modificación del atributo
                    atributo[o] = nuevo;
                    string[] spliter = atributo[o].Split(' ');
                    cabecera[o][0] = spliter[0];
                    cabecera[o][1] = spliter[1];
                    cabecera[o][2] = atributo[o].Substring((spliter[0].Length + spliter[1].Length) + 2);


                    //prueba de almacenamiento de cambios
                    label8.Text = cabecera[o][0] + ' ' + cabecera[o][1] + ' ' + cabecera[o][2];
                    atributoscomboBox.Items.RemoveAt(indexCB);
                    atributoscomboBox.Items.Insert(indexCB, cabecera[o][0]);

                    Update_Grid_Header(old, cabecera[o][0]);
                    // Aqui la funcion esta hecha pero falta ver como llamarla en el mismo form del edit, aunque no jale nada
                    //delete_atributo(1);
                }

            }
        }
        private void Update_Grid_Header(string oldname, string newname)
        {
            for(int i = 0;i < dataGridView1.ColumnCount; i++)
            {
                if (dataGridView1.Columns[i].HeaderText == oldname)
                {
                    dataGridView1.Columns[i].HeaderText = newname;
                    break;
                }
            }
            EvalRegex();
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //if(this.dataGridView1.Columns[e.ColumnIndex].Name == "Nombre")
            /*if(Convert.ToString(e.Value) == "")
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.BackColor = Color.Red;
            }*/
            
            Regex rgx;
            int pruebaRegx = 0;
            DataGridViewRow actualRow;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == cabecera[e.ColumnIndex][0] && e.ColumnIndex != 0)
            {
                rgx = new Regex(cabecera[e.ColumnIndex][2]);
                actualRow = dataGridView1.Rows[e.RowIndex];
                if (!actualRow.IsNewRow)
                {
                    if (!rgx.IsMatch(actualRow.Cells[e.ColumnIndex].Value.ToString()))
                    {
                        pruebaRegx++;
                        e.CellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                }
                label8.Text = pruebaRegx.ToString();
            }
        }
        public void Delete_Atributo()
        {
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                if (dataGridView1.Columns[i].Index == indexCB)
                {
                    dataGridView1.Columns.RemoveAt(indexCB);
                    cabecera.RemoveAt(i);
                    break;
                }
            }
        }
        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modificaciones == true)
            {
                SalirForm frm = new SalirForm();
                if (frm.ShowDialog() == DialogResult.OK)

                {
                    sal=frm.salir;
                }

                if (sal == 0)
                    this.Close();
                else if (sal == 1)
                {
                    GuardarToolStripMenuItem_Click(sender,e);
                    this.Close();
                    
                }
                else if (sal ==2)
                {

                    GuardarComoToolStripMenuItem_Click(sender, e);
                    this.Close();                    
                }
            }
            else
                this.Close();
        }
        private void EvalRegex()
        {
            Regex rgx;
            int pruebaRegx = 0;
            DataGridViewRow actualRow;
            for (int i = 1; i < cabecera.Count; i++)
            {
                rgx = new Regex(cabecera[i][2]);
                for (int j = 0; j<dataGridView1.Rows.Count; j++)
                {
                    actualRow = dataGridView1.Rows[j];
                    if (!actualRow.IsNewRow)
                    {
                        if (!rgx.IsMatch(actualRow.Cells[i].Value.ToString()))
                        {
                            actualRow.Cells[i].Style.BackColor = Color.Red;
                            pruebaRegx++;
                            
                        }
                        else
                        {
                            actualRow.Cells[i].Style.BackColor = Color.White;
                        }
                    }
                }

            }
            label8.Text = pruebaRegx.ToString();
        }

        private void DataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(e.RowIndex) == "")
            {
                faltantes++;
            }
            label5.Text = "Valores faltantes\n" + faltantes;
            label6.Text = "Proporción de valores faltantes\n" + ((faltantes * 100) / ((nInstancia - 1) * (cabecera.Count - 1))) + "%";
        }
    }
}
