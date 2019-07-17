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


        public RegistroDeUsuario()
        {
            InitializeComponent();
            cbTipo.SelectedIndex = 0;
        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool flag = VerificaCedula(tbCedula.Text);
            bool flag2 = ComprobarFormatoEmail(tbCorreo.Text);
            if (flag && flag2)
            {

                String salt = RandomString(64);


                conexion.Open();

                String consulta1 = "insert into persona(nombre, correo, identificacion) values(@nombre, @correo, @identificacion); insert into usuario(idpersona, tipo, username, [password], salt) values((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @tipo,@username,@pass, @salt); ";
                SqlCommand comando1 = new SqlCommand(consulta1, conexion);
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
            }
        }

        private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Panel17_Paint(object sender, PaintEventArgs e)
        {

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

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

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
            bool flag = VerificaCedula(tbCedula.Text);
            if (flag)
            {
                Console.WriteLine("Cédula correcta");
                tbCedula.ForeColor = Color.Green;

            }
            else
            {
                tbCedula.ForeColor = Color.Red;
            }


        }

        private void TbCorreo_KeyUp(object sender, KeyEventArgs e)
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

        private void TbCedula_TextChanged(object sender, EventArgs e)
        {
            if (VerificaCedula(tbCedula.Text))
            {
                errorProvider1.SetError(tbCedula, null);
            }
            else
            {
                errorProvider1.SetError(tbCedula, "Ingrese cédula correctamente");
            }
        }

        private void limpiarCampos()
        {
            tbCedula.ResetText();
            tbCorreo.ResetText();
            tbNombre.ResetText();

        }

        private void CbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
