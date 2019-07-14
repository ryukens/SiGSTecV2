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
    public partial class CierreDeCaso : UserControl
    {
        TabControl tabControl;
        TabPage tabInicio;
        public CierreDeCaso(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FlowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RegistroDeInformeFinal cambioDeDatosCaso = new RegistroDeInformeFinal();
            cambioDeDatosCaso.ShowDialog();
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
