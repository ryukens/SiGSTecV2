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
        TabControl tabControl;
        TabPage tabInicio;
        bool flagCedula = false;
        bool flagMoviles = false;
        bool flagMoviles2 = true;
        bool flagTelefonos = false;
        bool flagTelefonos2 = true;
        bool flagCorreo = false;
        bool flagSector = false;
        bool flagAlcance = false;
        bool flagNombre = false;


        public RegistroDeTécnico(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            tbTelefono2.Enabled = false;
            tbCelular2.Enabled = false;

            bAceptar.Enabled = false;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }






        private void Button2_Click(object sender, EventArgs e)
        {
            bool flag = Validaciones.VerificaCedula(tbCedula.Text);
            bool flag2 = Validaciones.ComprobarFormatoEmail(tbCorreo.Text);
            if (flag && flag2)
            {
                conexion.Open();

                SqlCommand comando1 = new SqlCommand("SP_REGISTRO_TECNICO", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@nombre", tbNombre.Text);
                comando1.Parameters.AddWithValue("@correo", tbCorreo.Text);
                comando1.Parameters.AddWithValue("@identificacion", tbCedula.Text);
                comando1.Parameters.AddWithValue("@sector", tbSector.Text);
                comando1.Parameters.AddWithValue("@alcance", tbAlcance.Text);

                comando1.ExecuteNonQuery();


                if (!tbTelefono1.Text.Trim().Equals(""))
                {

                    SqlCommand comando2 = new SqlCommand("SP_REGISTRO_TELEFONO_CONVENCIONAL1", conexion);
                    comando2.CommandType = CommandType.StoredProcedure;
                    comando2.Parameters.AddWithValue("@telefono", tbTelefono1.Text);
                    comando2.ExecuteNonQuery();
                }

                if (!tbTelefono2.Text.Trim().Equals(""))
                {
                    SqlCommand comando3 = new SqlCommand("SP_REGISTRO_TELEFONO_CONVENCIONAL2", conexion);
                    comando3.CommandType = CommandType.StoredProcedure;
                    comando3.Parameters.AddWithValue("@telefono", tbTelefono2.Text);
                    comando3.ExecuteNonQuery();
                }

                if (!tbCelular1.Text.Trim().Equals(""))
                {

                    SqlCommand comando4 = new SqlCommand("SP_REGISTRO_CELULAR1", conexion);
                    comando4.CommandType = CommandType.StoredProcedure;
                    comando4.Parameters.AddWithValue("@telefono", tbCelular1.Text);
                    comando4.ExecuteNonQuery();
                }
                if (!tbCelular2.Text.Trim().Equals(""))
                {

                    SqlCommand comando5 = new SqlCommand("SP_REGISTRO_CELULAR2", conexion);
                    comando5.CommandType = CommandType.StoredProcedure;
                    comando5.Parameters.AddWithValue("@telefono", tbCelular2.Text);
                    comando5.ExecuteNonQuery();
                }
                conexion.Close();
                MessageBox.Show("Técnico Registrado Correctamente", "Técnico Registrado");
                limpiarCampos();
            }

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
            if (tbCorreo.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCorreo, null);
                flagCorreo = false;
                activarBoton();
            }
            else
            {
                if (Validaciones.ComprobarFormatoEmail(tbCorreo.Text))
                {
                    errorProvider1.SetError(tbCorreo, null);
                    flagCorreo = true;
                    activarBoton();
                }
                else
                {
                    errorProvider1.SetError(tbCorreo, "Ingrese un correo electrónico correcto");
                    flagCorreo = false;
                    activarBoton();
                }
            }
        }

        private void TbCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = Validaciones.ComprobarFormatoEmail(tbCorreo.Text);
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

            if (tbTelefono2.Text.Trim() == "")

            {
                errorProvider1.SetError(tbTelefono2, null);
                flagTelefonos2 = true;
                activarBoton();
            }
            else
            {


                if (Validaciones.formatoTelefono(tbTelefono2.Text))


                {
                    errorProvider1.SetError(tbTelefono2, null);
                    tbTelefono2.ForeColor = Color.Green;
                    flagTelefonos2 = true;
                    activarBoton();

                }
                else
                {
                    errorProvider1.SetError(tbTelefono2, "El teléfono debe:\r\n" +
                        "- Iniciar con prefijo (02 - 07)\r\n" +
                        "- Tener 9 dígitos");
                    tbTelefono2.ForeColor = Color.Red;
                    flagTelefonos2 = false;
                    activarBoton();
                }
            }
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

            if (tbCedula.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCedula, null);
                flagCedula = false;
                activarBoton();
            }

            else { 

                if (Validaciones.VerificaCedula(tbCedula.Text))
                {
                    int r = Validaciones.verificarCedulaRepetida(tbCedula , conexion);
                    if (r != 0)
                    {
                        tbCedula.ForeColor = Color.Red;
                        errorProvider1.SetError(tbCedula, "Esta cédula ya existe");
                        flagCedula = false;
                        activarBoton();

                    }
                    else
                    {
                        errorProvider1.SetError(tbCedula, null);
                        tbCedula.ForeColor = Color.Green;
                        flagCedula = true;
                        activarBoton();
                    }

                }
                else
                {
                    errorProvider1.SetError(tbCedula, "Ingrese una cédula correcta");
                    tbCedula.ForeColor = Color.Red;
                    flagCedula = false;
                    activarBoton();
                }
            }





        }

        public int verificarCedulaRepetida(String ced)
        {
            int result = -1;
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_VERIFICAR_CEDULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@identificacion", tbCedula.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            conexion.Close();
            return result;
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
            tbTelefono2.Enabled = false;
            tbCelular2.Enabled = false;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            tabControl.SelectTab(tabInicio);
        }

        private void TbTelefono1_TextChanged(object sender, EventArgs e)
        {
            if (tbTelefono1.Text.Trim() == "")
            {
                errorProvider1.SetError(tbTelefono1, null);
                flagTelefonos = false;
                activarBoton();
            }
            else
            {
                if (Validaciones.formatoTelefono(tbTelefono1.Text))
                {
                    errorProvider1.SetError(tbTelefono1, null);
                    tbTelefono1.ForeColor = Color.Green;
                    tbTelefono2.Enabled = true;
                    flagTelefonos = true;
                    activarBoton();
                }
                else
                {
                    errorProvider1.SetError(tbTelefono1, "El teléfono debe:\r\n" +
                        "- Iniciar con prefijo (02 - 07)\r\n" +
                        "- Tener 9 dígitos");
                    tbTelefono1.ForeColor = Color.Red;
                    tbTelefono2.Enabled = false;
                    flagTelefonos = false;
                    activarBoton();
                }
            }
        }

        private void TbCelular1_TextChanged(object sender, EventArgs e)
        {
            if (tbCelular1.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCelular1, null);
                flagMoviles = false;
                activarBoton();

            }
            else
            {


                if (Validaciones.formatoCelular(tbCelular1.Text))
                {
                    errorProvider1.SetError(tbCelular1, null);
                    tbCelular1.ForeColor = Color.Green;
                    tbCelular2.Enabled = true;
                    flagMoviles = true;
                    activarBoton();
                }
                else
                {
                    errorProvider1.SetError(tbCelular1, "El celular debe:\r\n" +
                        "- Iniciar con prefijo 09\r\n" +
                        "- Tener 10 dígitos");
                    tbCelular1.ForeColor = Color.Red;
                    tbCelular2.Enabled = false;
                    flagMoviles = false;
                    activarBoton();
                }
            }
        }

        private void TbCelular2_TextChanged(object sender, EventArgs e)
        {
            if (tbCelular2.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCelular2, null);

                flagMoviles2 = true;
                activarBoton();

                tbCelular2.ForeColor = Color.Green;


            }
            else
            {
                if (Validaciones.formatoCelular(tbCelular2.Text))
                {
                    errorProvider1.SetError(tbCelular2, null);
                    tbCelular2.ForeColor = Color.Green;
                    flagMoviles2 = true;
                    activarBoton();

                }
                else
                {
                    errorProvider1.SetError(tbCelular2, "El celular debe:\r\n" +
                        "- Iniciar con prefijo 09\r\n" +
                        "- Tener 10 dígitos");
                    tbCelular2.ForeColor = Color.Red;
                    flagMoviles2 = false;
                    activarBoton();
                }
            }
        }

        private void TbNombre_TextChanged(object sender, EventArgs e)
        {
            if (tbNombre.Text.Trim() == "")
            {
                flagNombre = false;
                activarBoton();
            }
            else
            {
                flagNombre = true;
                activarBoton();
            }
        }

        private void TbSector_TextChanged(object sender, EventArgs e)
        {
            if (tbSector.Text.Trim() == "")
            {
                flagSector = false;
                activarBoton();
            }
            else
            {
                flagSector = true;
                activarBoton();
            }

        }

        public void activarBoton()
        {
            //Console.WriteLine("alcance " + flagAlcance + "cedula " + flagCedula + "correo " + flagCorreo + "moviles " + flagMoviles + "nombre " + flagNombre + "sector " + flagSector + "telefonos " + flagTelefonos);
            if (flagAlcance && flagCedula && flagCorreo && flagMoviles && flagMoviles2 && flagNombre && flagSector && flagTelefonos &&flagTelefonos2)
            {
                bAceptar.Enabled = true;
            }
            else
            {
                bAceptar.Enabled = false;
            }
        }

        private void TbAlcance_TextChanged(object sender, EventArgs e)
        {
            if (tbSector.Text.Trim() == "")
            {
                flagAlcance = false;
                activarBoton();
            }
            else
            {
                flagAlcance = true;
                activarBoton();
            }
        }
    }
}
