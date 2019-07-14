using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace proyectoPantalla
{
    public partial class InicioDeSesión : Form
    {
        String salt = "salt";
        String password = "pass";
        SqlConnection conexion = new SqlConnection("Data Source =.; Initial Catalog = SIGSTEC; Integrated Security = True");
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


        public InicioDeSesión()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal(this);
            conexion.Open();
            String consulta1 = "select [password] , salt from usuario where username = @username; ";
            SqlCommand comando1 = new SqlCommand(consulta1, conexion);
            comando1.Parameters.AddWithValue("@username", tbUsuario.Text);
            SqlDataReader dr = comando1.ExecuteReader();
            while (dr.Read())
            {
                password = dr.GetString(0);
                salt = dr.GetString(1);
            }

            conexion.Close();

            if (MD5Hash(salt + tbContraseña.Text).Equals(MD5Hash(salt + "12345678")))
            {
                MessageBox.Show("Primer ingreso, por favor cambie su contraseña");
                CambioDeContraseña cambioDeContraseña = new CambioDeContraseña();
                cambioDeContraseña.ShowDialog();
                this.Hide();
                pantallaPrincipal.Show();
            }
            else if (MD5Hash(salt + tbContraseña.Text).Equals(password))
            {
                MessageBox.Show("Ingreso Exitoso");
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas");
                CambioDeContraseña cambioDeContraseña = new CambioDeContraseña();
                cambioDeContraseña.ShowDialog();
            }
            this.Hide();
            pantallaPrincipal.Show();
        }

        private void InicioDeSesión_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TbContraseña_TextChanged(object sender, EventArgs e)
        {

        }


    }

}
