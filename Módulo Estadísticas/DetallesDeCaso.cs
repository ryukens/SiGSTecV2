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
    public partial class DetallesDeCaso : Form
    {
        public DetallesDeCaso(String numero, String sector, String fecha)
        {
            InitializeComponent();
            TopMost = true;

            this.numero = numero;
            this.sector = sector;
            this.fecha = fecha;

            label7.Text = numero;
            label9.Text = fecha;
            label10.Text = sector;

        }

        String numero;
        String sector;
        String fecha;

        private void OrdenDeFacturación_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
