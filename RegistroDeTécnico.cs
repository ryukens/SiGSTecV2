using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyectoPantalla
{
    public partial class RegistroDeTécnico : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
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

        public RegistroDeTécnico()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }




        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool flag = VerificaCedula(tbCedula.Text);
            bool flag2 = ComprobarFormatoEmail(tbCorreo.Text);
            if (flag && flag2)
            {
                conexion.Open();

                String consulta1 = "insert into persona (nombre, correo, identificacion) values (@nombre, @correo,@identificacion); insert into tecnico(idpersona, sector, alcance, estado) values((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @sector,@alcance,'DISPONIBLE');";
                SqlCommand comando1 = new SqlCommand(consulta1, conexion);
                comando1.Parameters.AddWithValue("@nombre", tbNombre.Text);
                comando1.Parameters.AddWithValue("@correo", tbCorreo.Text);
                comando1.Parameters.AddWithValue("@identificacion", tbCedula.Text);
                comando1.Parameters.AddWithValue("@sector", tbSector.Text);
                comando1.Parameters.AddWithValue("@alcance", tbAlcance.Text);

                comando1.ExecuteNonQuery();


                if (!tbTelefono1.Text.Trim().Equals(""))
                {

                    consulta1 = "insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CONVENCIONAL1');";
                    SqlCommand comando2 = new SqlCommand(consulta1, conexion);

                    comando2.Parameters.AddWithValue("@telefono", tbTelefono1.Text);
                    comando2.ExecuteNonQuery();
                }

                if (!tbTelefono2.Text.Trim().Equals(""))
                {

                    consulta1 = "insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CONVENCIONAL2');";
                    SqlCommand comando3 = new SqlCommand(consulta1, conexion);

                    comando3.Parameters.AddWithValue("@telefono", tbTelefono2.Text);
                    comando3.ExecuteNonQuery();
                }

                if (!tbCelular1.Text.Trim().Equals(""))
                {

                    consulta1 = "insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CELULAR1');";
                    SqlCommand comando4 = new SqlCommand(consulta1, conexion);

                    comando4.Parameters.AddWithValue("@telefono", tbCelular1.Text);
                    comando4.ExecuteNonQuery();
                }
                if (!tbCelular2.Text.Trim().Equals(""))
                {

                    consulta1 = "insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CELULAR2');";
                    SqlCommand comando5 = new SqlCommand(consulta1, conexion);

                    comando5.Parameters.AddWithValue("@telefono", tbCelular2.Text);
                    comando5.ExecuteNonQuery();
                }
                conexion.Close();
                MessageBox.Show("Técnico Registrado Correctamente", "Técnico Registrado");
                limpiarCampos();
            }

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }


        public bool VerificaCedula(string ced)
        {
            int isNumeric;
            var total = 0;
            const int tamanoLongitudCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numeroProvincia = 24;
            const int tercerDigito = 6;

            if (int.TryParse(ced, out isNumeric) && ced.Length == tamanoLongitudCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(ced[0], ced[1], string.Empty));
                var digitoTres = Convert.ToInt32(ced[2] + string.Empty);
                if ((provincia > 0 && provincia <= numeroProvincia) && digitoTres < tercerDigito)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(ced[9] + string.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) * Convert.ToInt32(ced[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ? 10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorObtenido == digitoVerificadorRecibido;
                }
                return false;
            }
            return false;
        }


        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


            if (!(char.IsLetter(e.KeyChar)) && !(Char.IsSeparator(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                // MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }


        }

        private void TbCedula_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = VerificaCedula(tbCedula.Text);
            if (flag)
            {
                tbCedula.ForeColor = Color.Green;

            }
            else
            {
                tbCedula.ForeColor = Color.Red;
            }


        }

        private void TbCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TbCorreo_TextChanged(object sender, EventArgs e)
        {
            if (ComprobarFormatoEmail(tbCorreo.Text))
            {
                errorProvider1.SetError(tbCorreo, null);
            }
            else
            {
                errorProvider1.SetError(tbCorreo, "Ingrese un correo electrónico correcto");
            }
        }

        private void TbCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = ComprobarFormatoEmail(tbCorreo.Text);
            if (flag)
            {
                tbCorreo.ForeColor = Color.Green;

            }
            else
            {
                tbCorreo.ForeColor = Color.Red;
            }

        }

        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TbCedula_TextChanged(object sender, EventArgs e)
        {
            if (VerificaCedula(tbCedula.Text))
            {
                errorProvider1.SetError(tbCedula, null);
            }
            else
            {
                errorProvider1.SetError(tbCedula, "Ingrese una cédula correcta");
            }


        }

        private void LTelfCelular_Click(object sender, EventArgs e)
        {

        }

        public void limpiarCampos()
        {
            tbAlcance.ResetText();
            tbCedula.ResetText();
            tbCelular1.ResetText();
            tbCelular2.ResetText();
            tbCorreo.ResetText();
            tbNombre.ResetText();
            tbSector.ResetText();
            tbTelefono1.ResetText();
            tbTelefono2.ResetText();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
