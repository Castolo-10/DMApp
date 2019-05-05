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
    public partial class SalirForm : Form
    {
        public int salir { get; set; }

        public SalirForm()
        {
            InitializeComponent();
            salir = 0;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Nobutton_Click(object sender, EventArgs e)
        {
            salir = 0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            salir = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void Guardarcomobutton_Click(object sender, EventArgs e)
        {
            salir = 2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
