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
    public partial class GeneraciónDeInforme : UserControl
    {
        TabControl tabControl;
        TabPage tabInicio;
        public GeneraciónDeInforme(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ReporteGenerado reporteGenerado = new ReporteGenerado();
            reporteGenerado.Show();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
