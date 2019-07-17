using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla.Módulo_Casos
{
    public partial class AsignaciónMuestraCaso : UserControl
    {
        public AsignaciónMuestraCaso()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SelecciónDeProductos selecciónDeProductos = new SelecciónDeProductos();
            selecciónDeProductos.ShowDialog();
        }
    }
}
