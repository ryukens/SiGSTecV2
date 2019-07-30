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
using System.Security.Cryptography;

namespace proyectoPantalla
{
    public partial class RegistroDeUsuario : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source =.; Initial Catalog =SIGSTEC; Integrated Security = True");

        bool flagNombre = false;
        bool flagCedula = false;
        bool flagCorreo = false;
        bool errorCorreo = false;
        int errorCedula = -1;


        static string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }
            return res.ToString();
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        TabControl tabControl;
        TabPage tabInicio;
        public RegistroDeUsuario(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbTipo.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            
        }
        public bool validarEntrada()
        {
           
            if ( flagCedula && flagCorreo && flagNombre )
            {
                if (errorCedula == 1)
                {
                    MessageBox.Show("Cédula de ciudadanía ya registrada", "Error");
                    return false;
                }
                else if (errorCedula == 2)
                {
                    MessageBox.Show("Cédula de ciudadanía incorrecta", "Error");
                    return false;
                }
                if (errorCorreo)
                {

                    MessageBox.Show("Correo electrónico incorrecto", "Error");
                    return false;
                }
                
                return true;
            }
            else
            {
                MessageBox.Show("Existen campos vacíos", "Campos Vacíos");
                return false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            if (validarEntrada())
            {
                String salt = RandomString(64);
                conexion.Open();

                SqlCommand comando1 = new SqlCommand("SP_REGISTRO_USUARIO", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@nombre", tbNombre.Text);
                comando1.Parameters.AddWithValue("@correo", tbCorreo.Text);
                comando1.Parameters.AddWithValue("@identificacion", tbCedula.Text);
                comando1.Parameters.AddWithValue("@tipo", cbTipo.SelectedItem.ToString());

                comando1.Parameters.AddWithValue("@username", tbCedula.Text);
                comando1.Parameters.AddWithValue("@pass", MD5Hash(salt + "12345678"));
                comando1.Parameters.AddWithValue("@salt", salt);
                
                comando1.ExecuteNonQuery();

                conexion.Close();


                MessageBox.Show("Usuario Registrado Correctamente", "Usuario Registrado");
                limpiarCampos();
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (tbNombre.Text.Trim() == "")
            {
                flagNombre = false;
                cambiarBoton();

            }
            else
            {
                flagNombre = true;
                cambiarBoton();
            }
        }

        public void cambiarBoton()
        {
            if (flagNombre && flagCedula && flagCorreo)
            {
                bCrear.Enabled = true;
            }
            else
            {
                bCrear.Enabled = false;
            }
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TbCedula_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void TbCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = Validaciones.ComprobarFormatoEmail(tbCorreo.Text);
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

        private void TbCorreo_TextChanged(object sender, EventArgs e)
        {
            if (tbCorreo.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCorreo, null);
                flagCorreo = false;

            }
            else
            {
                flagCorreo = true;
                if (Validaciones.ComprobarFormatoEmail(tbCorreo.Text))
                {
                    errorProvider1.SetError(tbCorreo, null);
                    errorCorreo = false;


                }
                else
                {
                    errorProvider1.SetError(tbCorreo, "Ingrese un correo electrónico correcto");
                    errorCorreo = true;

                }
            }
        }

        private void TbCedula_TextChanged(object sender, EventArgs e)
        {
            if (tbCedula.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCedula, null);
                flagCedula = false;

            }

            else
            {
                flagCedula = true;
                if (Validaciones.VerificaCedula(tbCedula.Text))
                {

                    int r = Validaciones.verificarCedulaRepetida(tbCedula, conexion);
                    if (r != 0)
                    {
                        tbCedula.ForeColor = Color.Red;
                        errorProvider1.SetError(tbCedula, "Cédula de ciudadanía ya registrada");
                        errorCedula = 1;



                    }
                    else
                    {
                        errorProvider1.SetError(tbCedula, null);
                        tbCedula.ForeColor = Color.Green;
                        errorCedula = 0;

                    }

                }
                else
                {
                    errorProvider1.SetError(tbCedula, "Cédula de ciudadanía incorrecta");
                    tbCedula.ForeColor = Color.Red;
                    errorCedula = 2;


                }
            }

        }

        private void limpiarCampos()
        {
            tbCedula.ResetText();
            tbCorreo.ResetText();
            tbNombre.ResetText();
            cbTipo.SelectedIndex = 0;

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            tabControl.SelectTab(tabInicio);
        }

        private void TbNombre_TextChanged(object sender, EventArgs e)
        {
            if(tbNombre.Text.Trim() == "")
            {
                flagNombre = false;
                
            }
            else
            {
                flagNombre = true;
                
            }
        }

        private void RegistroDeUsuario_KeyPress(object sender, KeyPressEventArgs e)
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
}
