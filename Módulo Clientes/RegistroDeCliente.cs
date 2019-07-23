using System;
using System.Collections;
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
    public partial class RegistroDeCliente : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;

        public RegistroDeCliente(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbSLA.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool flagVacios = ValidarCamposVacios();
            if (!flagVacios)
            {
                MessageBox.Show("Cliente Registrado Correctamente", "Cliente Registrado");
            }
            else
            {
                //MessageBox.Show("Existen campos vacios", "Campos Vacios");
            }

            conexion.Open();
            SqlCommand comando1 = new SqlCommand("SP_REGISTRO_CLIENTE", conexion);
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@nombre", tbNombre.Text);
            comando1.Parameters.AddWithValue("@correo", tbCorreo.Text);
            comando1.Parameters.AddWithValue("@identificacion", tbCedula.Text);
            comando1.Parameters.AddWithValue("@nombre_contacto", tbNombreCont.Text);
            comando1.Parameters.AddWithValue("@descripcion_contacto", tbDescripcion.Text);
            comando1.Parameters.AddWithValue("@sla", cbSLA.SelectedItem.ToString());
            comando1.Parameters.AddWithValue("@cuenta", tbCuenta.Text);


            if (rbAcordado.Checked)
            {
                comando1.Parameters.AddWithValue("@tipo_pago", rbAcordado.Text);
            }
            else
            {
                comando1.Parameters.AddWithValue("@tipo_pago", rbDefinido.Text);
            }
            if (rbEmpresa.Checked)
            {
                comando1.Parameters.AddWithValue("@tipo", rbEmpresa.Text);
            }
            else
            {
                comando1.Parameters.AddWithValue("@tipo", rbPersona.Text);
            }

            comando1.ExecuteNonQuery();


            String consulta1;

            if (!tbTelefono1.Text.Trim().Equals(""))
            {

                SqlCommand comando3 = new SqlCommand("SP_REGISTRO_TELEFONO_CONVENCIONAL1", conexion);
                comando3.CommandType = CommandType.StoredProcedure;
                comando3.Parameters.AddWithValue("@telefono", tbTelefono1.Text);
                comando3.ExecuteNonQuery();
            }

            if (!tbTelefono2.Text.Trim().Equals(""))
            {
                SqlCommand comando4 = new SqlCommand("SP_REGISTRO_TELEFONO_CONVENCIONAL2", conexion);
                comando4.CommandType = CommandType.StoredProcedure;
                comando4.Parameters.AddWithValue("@telefono", tbTelefono2.Text);
                comando4.ExecuteNonQuery();
            }

            if (!tbCelular1.Text.Trim().Equals(""))
            {
                SqlCommand comando5 = new SqlCommand("SP_REGISTRO_CELULAR1", conexion);
                comando5.CommandType = CommandType.StoredProcedure;
                comando5.Parameters.AddWithValue("@telefono", tbCelular1.Text);
                comando5.ExecuteNonQuery();
            }
            if (!tbCelular2.Text.Trim().Equals(""))
            {
                SqlCommand comando6 = new SqlCommand("SP_REGISTRO_CELULAR2", conexion);
                comando6.CommandType = CommandType.StoredProcedure;
                comando6.Parameters.AddWithValue("@telefono", tbCelular2.Text);
                comando6.ExecuteNonQuery();
            }

            conexion.Close();
            MessageBox.Show("Cliente Registrado Correctamente", "Cliente Registrado");
            limpiarCampos();


        }


        private void RbPersona_CheckedChanged(object sender, EventArgs e)
        {
            tbCuenta.Text = "N/A";
            tbCedula.MaxLength = 10;
            tbCedula.ResetText();
        }

        private void RbEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            tbCuenta.Enabled = rbEmpresa.Checked;
            tbCuenta.Text = "";
            tbCedula.MaxLength = 13;
            tbCedula.ResetText();
        }

        private void TbCedula_TextChanged(object sender, EventArgs e)
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

        public bool RucPersonaNatural(string ruc)
        {
            long isNumeric;
            const int tamanoLongitudRuc = 13;
            const string establecimiento = "001";
            if (long.TryParse(ruc, out isNumeric) && ruc.Length.Equals(tamanoLongitudRuc))
            {
                var numeroProvincia = Convert.ToInt32(string.Concat(ruc[0] + string.Empty, ruc[1] + string.Empty));
                var personaNatural = Convert.ToInt32(ruc[2] + string.Empty);
                if ((numeroProvincia >= 1 && numeroProvincia <= 24) && (personaNatural >= 0 && personaNatural < 6))
                {
                    return ruc.Substring(10, 3) == establecimiento && VerificaCedula(ruc.Substring(0, 10));
                }
                return false;
            }
            return false;
        }

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

        public bool ValidarCamposVacios()
        {
            bool flag = true;
            List<TextBox> lista = GenerarLista();
            foreach (TextBox text in lista)
            {
                if (text.Text.Equals(""))
                {
                    flag = false;
                }
            }
            return flag;
        }

        public List<TextBox> GenerarLista()
        {
            var al = new List<TextBox>();
            al.Add(tbNombre);
            al.Add(tbCuenta);
            al.Add(tbCedula);
            al.Add(tbCorreo);
            al.Add(tbCelular1);
            al.Add(tbTelefono1);
            al.Add(tbNombreCont);
            al.Add(tbDescripcion);
            //int tam = al.Count;
            return al;
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

        private void TbCorreo_TextChanged(object sender, EventArgs e)
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

        private void TbTelf1_TextChanged(object sender, EventArgs e)
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

        private void TbTelf1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbTelf2_TextChanged(object sender, EventArgs e)
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

        private void TbTelf2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbCel1_TextChanged(object sender, EventArgs e)
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

        private void TbCel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //               MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TbCel2_TextChanged(object sender, EventArgs e)
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

        private void TbCel2_KeyPress(object sender, KeyPressEventArgs e)
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
            if (VerificaCedula(tbCedula.Text) || RucPersonaNatural(tbCedula.Text))
            {
                errorProvider1.SetError(tbCedula, null);
                tbCedula.ForeColor = Color.Green;

            }
            else
            {
                errorProvider1.SetError(tbCedula, "Ingrese cédula o RUC correctamente");
                tbCedula.ForeColor = Color.Red;
            }
        }

        private void Panel10_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TbNombreCont_TextChanged(object sender, EventArgs e)
        {

        }

        public void limpiarCampos()
        {
            tbCedula.ResetText();
            tbCelular1.ResetText();
            tbCelular2.ResetText();
            tbCorreo.ResetText();
            tbCuenta.Text = "N/A";
            tbDescripcion.ResetText();
            tbNombre.ResetText();
            tbNombreCont.ResetText();
            tbTelefono1.ResetText();
            tbTelefono2.ResetText();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            tabControl.SelectTab(tabInicio);
        }

        private void TbNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void TbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbPersona.Checked)
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
