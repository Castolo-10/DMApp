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
     public partial class AtributosForm : Form
    {
        public string atributo { get; set; }
        public DataGridView dgv { get; set; }
        public int index2 { get; set; }
        public int index { get; set; }
        string nombre;
        string tipo;
        string er;
        bool disponible = false;
        

        public AtributosForm( string atr, DataGridView data, int indexCB)
        {
            dgv = data;
            index = indexCB;
            index2 = 0;
            InitializeComponent();
            atributo = atr;
        }

        

        private void AtributosForm_Load(object sender, EventArgs e)
        {
            int a = 0;
            for (int i = 0; i < atributo.Length; i++)
            {
                if (atributo[i] != ' ')
                {
                    a++;

                }
                else
                    break;
            }
            
            nombre = atributo.Substring(0, a);

            string subSatrib = atributo.Substring(a);
            int b = 0;
            for (int i = 1; i < subSatrib.Length; i++)
            {
                if (subSatrib[i] != ' ')
                {
                    b++;
                    disponible = true;
                }
                else
                    break;
            }

            if(disponible == true)
            tipo = subSatrib.Substring(1, b);
            //er = subSatrib.Substring(b);

            string subSatrib2 = subSatrib.Substring(b);

            if (disponible == true)
                er = subSatrib2.Substring(2);

            nombretextBox.Text = nombre;
            tipotextBox.Text = tipo;
            ertextBox.Text = er;
        }

        private void NombretextBox_TextChanged(object sender, EventArgs e)
        {
            if (nombretextBox.Text == "")
                salvarbutton.Enabled = false;
            else
                salvarbutton.Enabled = true;
        }

        private void Salvarbutton_Click(object sender, EventArgs e)
        {
            if (nombretextBox.Text != "")
                nombre = nombretextBox.Text;
            else
                salvarbutton.Enabled = false;

            if (tipotextBox.Text != "")
                tipo = tipotextBox.Text;
            else
                tipo = " ";

            if (ertextBox.Text != "")
                er = ertextBox.Text;
            else
                er = " ";
                      
            nombre = nombre.Replace(' ', '_');

            atributo = nombre + " " + tipo + " " + er;
            label1.Text = atributo;
            this.DialogResult = DialogResult.OK;
            this.Close();

            // this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            for (int i = 1; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Index == index+1)
                {
                    dgv.Columns.RemoveAt(index+1);
                    index2 = index+1;
                    break;
                }
            }
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
