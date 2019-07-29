using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla.Módulo_Administración
{
    public partial class DadaDeAltaUsuario : UserControl
    {
        TabControl tabControl;
        TabPage tabInicio;

        public DadaDeAltaUsuario(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            tabControl.SelectTab(tabInicio);
        }
    }
}
