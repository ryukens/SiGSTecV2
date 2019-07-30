using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace proyectoPantalla
{
    public partial class RegistroDeProducto : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
   /*     bool flagCodigo = false;
        bool flagDescripción = false;
        bool flagPrecio = false;
        bool flagCantidad = false;
*/
        public RegistroDeProducto(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 1000;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            bool flagVacios = ValidarCamposVacios();
            if (flagVacios == true)
            {
                conexion.Open();
                SqlCommand comando1 = new SqlCommand("SP_REGISTRO_PRODUCTO", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@codigo", tbCodigo.Text);
                comando1.Parameters.AddWithValue("@descripcion", tbDescripcion.Text);
                comando1.Parameters.AddWithValue("@cantidad", nudCantidad.Value);
                comando1.Parameters.AddWithValue("@precio", tbPrecio.Text);
                comando1.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Producto Registrado Correctamente", "Producto Registrado");
                limpiarCampos();
            }
            else
            {
                conexion.Close();
                MessageBox.Show("Existen campos vacios", "Campos Vacios");
            }

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < tbPrecio.Text.Length; i++)
            {
                if (tbPrecio.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;

        }

        private void limpiarCampos()
        {
            tbCodigo.ResetText();
            tbDescripcion.ResetText();
            tbPrecio.ResetText();
            nudCantidad.Value = nudCantidad.Minimum;
        }

        public bool ValidarCamposVacios()
        {
            bool flag = true;
            if (tbCodigo.Text.Equals(""))
            {
                flag = false;
            }
            if (tbDescripcion.Text.Equals(""))
            {
                flag = false;
            }
            if (tbPrecio.Text.Equals(""))
            {
                flag = false;
            }
            if (nudCantidad.Text.Equals("0"))
            {
                flag = false;
            }

            return flag;
        }


        private void NudCantidad_ValueChanged(object sender, EventArgs e)
        {
            Validaciones.soloNumero(nudCantidad.ToString());
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            tabControl.SelectTab(tabInicio);
        }
    }
}


