using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace proyectoPantalla
{
    public partial class CambioDeContraseña : Form
    {
        public int idUsuario;
        public String salt;
        SqlConnection conexion = new SqlConnection("Data Source =.; Initial Catalog = SIGSTEC; Integrated Security = True");

        InicioDeSesión inicioDeSesión;
        PantallaPrincipal pantallaPrincipal;

        bool flagCorrecto = false;
        bool flagIguales = false;
        bool vacios1 = true;
        bool vacios2 = true;
        public CambioDeContraseña()
        {
            InitializeComponent();
        }

        public CambioDeContraseña(String salt, int id, InicioDeSesión ids)
        {
            InitializeComponent();
            this.salt = salt;
            this.idUsuario = id;
            inicioDeSesión = ids;

            pantallaPrincipal = new PantallaPrincipal(inicioDeSesión);


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


        private void BIngresar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_CAMBIO_DE_PASSWORD", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            if (vacios1 || vacios2)
            {
                MessageBox.Show("Existen campos vacíos", "Error");
            }
            else
            {


                if (!flagCorrecto)
                {
                    MessageBox.Show("Contraseña incorrecta", "Error");
                    tbContraseña1.ResetText();
                    tbContraseña2.ResetText();
                    errorProvider1.SetError(tbContraseña1, null);
                }
                else if (!flagIguales)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error");
                    tbContraseña2.ResetText();
                }
                else
                {

                    

                    SqlCommand comando1 = new SqlCommand("SP_CAMBIO_DE_PASSWORD", conexion);
                    comando1.CommandType = CommandType.StoredProcedure;

                    comando1.Parameters.AddWithValue("@pass", MD5Hash(salt + tbContraseña1.Text));
                    comando1.Parameters.AddWithValue("@id", idUsuario);

                    comando1.ExecuteNonQuery();

                    conexion.Close();
                    MessageBox.Show("Contraseña cambiada correctamente", "Cambio de contraseña");

                    this.Hide();
                    inicioDeSesión.Hide();
                    pantallaPrincipal.Show();
                }
            }
            
        }


        private void TbContraseña2_TextChanged(object sender, EventArgs e)
        {
            if (tbContraseña2.Text.Trim() == "")
            {
                vacios2 = true;
                errorProvider1.SetError(tbContraseña2, null);
            }
            else
            {

                vacios2 = false;
                if (flagCorrecto)
                {
                    if (tbContraseña2.Text.Equals(tbContraseña1.Text))
                    {
                        errorProvider1.SetError(tbContraseña2, null);
                        flagIguales = true;
                    }
                    else
                    {
                        errorProvider1.SetError(tbContraseña2, "Las contraseñas no coinciden");
                        flagIguales = false;
                    }
                }
            }
            /*if (tbContraseña2.Text.Equals(tbContraseña1.Text))
            {
                errorProvider1.SetError(tbContraseña2, null);
                bGuardar.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(tbContraseña2, "Las Contraseñas no coinciden");
                bGuardar.Enabled = false;
            }
            if (Validaciones.formatoContraseña(tbContraseña2.Text))
            {
                //errorProvider1.SetError(tbContraseña2, null);
            }
            else
            {
                bGuardar.Enabled = false;
            }*/
        }

        private void TbContraseña1_TextChanged(object sender, EventArgs e)
        {
            if (tbContraseña1.Text.Trim() == "")
            {
                vacios1 = true;
                errorProvider1.SetError(tbContraseña1, null);
            }
            else
            {
                vacios1 = false;

                if (Validaciones.formatoContraseña(tbContraseña1.Text))
                {
                    errorProvider1.SetError(tbContraseña1, null);
                    flagCorrecto = true;
                }
                else
                {
                    errorProvider1.SetError(tbContraseña1, "Contraseña incorrecta");
                    flagCorrecto = false;
                }
            }
            /*if (tbContraseña1.Text.Equals(tbContraseña2.Text))
            {
                errorProvider1.SetError(tbContraseña2, null);
                
                flagIguales = true;
            }
            else
            {
                errorProvider1.SetError(tbContraseña2, "Las Contraseñas no coinciden");
                
                flagIguales = false;
            }
            if (Validaciones.formatoContraseña(tbContraseña1.Text))
            {
                errorProvider1.SetError(tbContraseña1, null);
            }
            else
            {
                errorProvider1.SetError(tbContraseña1, "La contraseña debe tener:\r\n" +
                    "- Almenos una letra mayúscula\r\n" +
                    "- Almenos una letra minúscula\r\n" +
                    "- Almenos un dígito\r\n" +
                    "- Entre 8 a 16 caracteres");
                bGuardar.Enabled = false;
            }*/
        }



        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TbContraseña1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
