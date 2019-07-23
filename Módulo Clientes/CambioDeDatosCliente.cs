using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla
{
    public partial class CambioDeDatosCliente : Form
    {
        int ippersona;
        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public CambioDeDatosCliente(String cedula)
        {
            InitializeComponent();
            consultaCliente(cedula);

        }

        private void consultaCliente(String cedula)
        {
            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
            SqlCommand command;
            SqlDataReader lector;
            conexion.Open();
            command = new SqlCommand("select CLIENTE.IDPERSONA, NOMBRE, CORREO, IDENTIFICACION, NOMBRE_CONTACTO, DESCRIPCION_CONTACTO,SLA,CUENTA,TIPO_PAGO,TIPO from PERSONA, CLIENTE where PERSONA.IDPERSONA=CLIENTE.IDPERSONA;", conexion);
            lector = command.ExecuteReader();
            while (lector.Read())
            {
                tbNombre.Text = lector.GetValue(1).ToString();
                tbCorreo.Text = lector.GetValue(2).ToString(); ;
                tbCedula.Text = lector.GetValue(3).ToString(); ;
                tbNombreCont.Text = lector.GetValue(4).ToString(); ;
                tbDescripcion.Text = lector.GetValue(5).ToString(); ;
                cbSLA.Text = lector.GetValue(6).ToString(); ;
                tbCuenta.Text = lector.GetValue(7).ToString(); ;
                if (lector.GetValue(8).ToString().Equals("Acordado con cliente"))
                {
                    rbAcordado.Checked = true;
                }
                else
                {
                    rbDefinido.Checked = true;
                }
                if (lector.GetValue(9).ToString().Equals("Persona"))
                {
                    rbPersona.Checked = true;
                }
                else
                {
                    rbEmpresa.Checked = true;
                }
                ippersona = Int32.Parse(lector.GetValue(0).ToString());
            }
            lector.Close();
            conexion.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String tipo, tipoPago;
            if (rbEmpresa.Checked)
            {
                tipo = rbEmpresa.Text;
            }
            else
            {
                tipo = rbPersona.Text;
            }
            if (rbAcordado.Checked)
            {
                tipoPago = rbAcordado.Text;
            }
            else
            {
                tipoPago = rbDefinido.Text;
            }
            try
            {
                SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
                conexion.Open();
                SqlCommand command;
                command = new SqlCommand("update PERSONA set CORREO = '" + tbCorreo.Text + "' where " +
                    "IDPERSONA = " + ippersona + ";" +
                    "UPDATE CLIENTE SET " +
                    "NOMBRE_CONTACTO = '" + tbNombreCont.Text + "'," +
                    " DESCRIPCION_CONTACTO = '" + tbDescripcion.Text + "'," +
                    " SLA = '" + cbSLA.Text + "'," +
                    "CUENTA = '" + tbCuenta.Text + "'," +
                    " TIPO_PAGO = '" + tipoPago + "'," +
                    " TIPO = '" + tipo + "' WHERE" +
                    " IDPERSONA = " + ippersona + "; ", conexion);
                command.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Cliente Modificado Correctamente", "Cliente Modificado");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base:" + ex);
            }
        }

        private void CambioDeDatosCliente_Load(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void TableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox4_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = ComprobarFormatoEmail(tbCorreo.Text);
            if (flag)
            {
                Console.WriteLine("CORREO BUENO");
                tbCorreo.ForeColor = Color.Green;

            }
            else
            {
                tbCorreo.ForeColor = Color.Red;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (formatoCelular(tbCelular1.Text))
            {
                errorProvider1.SetError(tbCelular1, null);
                tbCelular1.ForeColor = Color.Green;
            }
            else
            {
                errorProvider1.SetError(tbCelular1, "El celular debe:\r\n" +
                    "- Iniciar con prefijo 09\r\n" +
                    "- Tener 10 dígitos");
                tbCelular1.ForeColor = Color.Red;
            }
        }

        private void TextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TextBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (ComprobarFormatoEmail(tbCorreo.Text))
            {
                errorProvider1.SetError(tbCorreo, null);
            }
            else
            {
                errorProvider1.SetError(tbCorreo, "Ingrese correo electrónico correctamente");
            }
        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void TbTelefono1_TextChanged(object sender, EventArgs e)
        {
            if (formatoTelefono(tbTelefono1.Text))
            {
                errorProvider1.SetError(tbTelefono1, null);
                tbTelefono1.ForeColor = Color.Green;
            }
            else
            {
                errorProvider1.SetError(tbTelefono1, "El teléfono debe:\r\n" +
                    "- Iniciar con prefijo (02 - 07)\r\n" +
                    "- Tener 9 dígitos");
                tbTelefono1.ForeColor = Color.Red;
            }
        }

        private void TbTelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbTelefono2_TextChanged_1(object sender, EventArgs e)
        {
            if (formatoTelefono(tbTelefono2.Text))
            {
                errorProvider1.SetError(tbTelefono2, null);
                tbTelefono2.ForeColor = Color.Green;
            }
            else
            {
                errorProvider1.SetError(tbTelefono2, "El teléfono debe:\r\n" +
                    "- Iniciar con prefijo (02 - 07)\r\n" +
                    "- Tener 9 dígitos");
                tbTelefono2.ForeColor = Color.Red;
            }
        }

        private void TbTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbCelular1_TextChanged(object sender, EventArgs e)
        {
            if (formatoCelular(tbCelular1.Text))
            {
                errorProvider1.SetError(tbCelular1, null);
                tbCelular1.ForeColor = Color.Green;
            }
            else
            {
                errorProvider1.SetError(tbCelular1, "El celular debe:\r\n" +
                    "- Iniciar con prefijo 09\r\n" +
                    "- Tener 10 dígitos");
                tbCelular1.ForeColor = Color.Red;
            }
        }

        private void TbCelular1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //               MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TbCelular2_TextChanged_1(object sender, EventArgs e)
        {
            if (formatoCelular(tbCelular2.Text))
            {
                errorProvider1.SetError(tbCelular2, null);
                tbCelular2.ForeColor = Color.Green;
            }
            else
            {
                errorProvider1.SetError(tbCelular2, "El celular debe:\r\n" +
                    "- Iniciar con prefijo 09\r\n" +
                    "- Tener 10 dígitos");
                tbCelular2.ForeColor = Color.Red;
            }
        }

        public static bool formatoTelefono(string telefono)
        {
            String formato;
            formato = "^0([2-7])([0-9]{7})$";
            if (Regex.IsMatch(telefono, formato))
            {
                if (Regex.Replace(telefono, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool formatoCelular(string celular)
        {
            String formato;
            formato = "^09([0-9]{8})$";
            if (Regex.IsMatch(celular, formato))
            {
                if (Regex.Replace(celular, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
