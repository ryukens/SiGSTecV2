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
    public partial class SelecciónDeProductos : UserControl
    {
        public SelecciónDeProductos()
        {
            InitializeComponent();
        }

        private void BAsignar_Click(object sender, EventArgs e)
        {
            new AsignaciónDeProductos().ShowDialog();
        }
    }
}
