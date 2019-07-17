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
    public partial class AsignaciónDeProductos : Form
    {
        public AsignaciónDeProductos()
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
        }

        private void AsignaciónDeProductos_Load(object sender, EventArgs e)
        {

        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
