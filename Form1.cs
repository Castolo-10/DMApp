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
        public Form1()
        {
            InitializeComponent();
        }

        private void CargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Abrir archivo";
            openFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv|Archivos DATA(.data)|*.data";
            //openFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filepath = openFileDialog1.FileName;
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
                else if(filepath.Contains(".data"))
                {

                }
                if (dt.Rows.Count > 0)
                    dataGridView1.DataSource = dt;
            }
        }
    }
}
