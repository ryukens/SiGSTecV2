using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla
{
    public partial class VistaDeDetalles : UserControl
    {
        TabControl tabControl;
        TabPage tabInicio;
        public VistaDeDetalles(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GeneraciónDelInforme ordenDeFacturación = new GeneraciónDelInforme();
            ordenDeFacturación.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            tabControl.SelectTab(tabInicio);

        }
    }
}
