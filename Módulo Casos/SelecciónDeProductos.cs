using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla
{
    public partial class SelecciónDeProductos : Form
    {
        public SelecciónDeProductos()
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
