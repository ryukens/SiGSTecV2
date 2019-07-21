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
    public partial class DisminuciónDeProducto : UserControl
    {
        TabControl tabControl;
        TabPage tabInicio;
        public DisminuciónDeProducto(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void BCancelar_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbFactura.ResetText();
        }

    }
}
