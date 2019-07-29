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
        public String salt = "salt";
        public String password = "pass";
        public int idUsuario = 0;
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
            iniciarSesión();
        }

        public void iniciarSesión()
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal(this);
            conexion.Open();
            SqlCommand comando1 = new SqlCommand("SP_INICIO_DE_SESION", conexion);
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@username", tbUsuario.Text);
            SqlDataReader dr = comando1.ExecuteReader();
            while (dr.Read())
            {
                password = dr.GetString(0);
                salt = dr.GetString(1);
                idUsuario = (int)dr.GetDecimal(2);
            }
            conexion.Close();
            if (idUsuario != 0)
            {
                if (MD5Hash(salt + tbContraseña.Text).Equals(password))
                {
                    if (MD5Hash(salt + tbContraseña.Text).Equals(MD5Hash(salt + "12345678")))
                    {
                        MessageBox.Show("Primer ingreso, cambie su contraseña", "Primer Ingreso");
                        CambioDeContraseña cambioDeContraseña = new CambioDeContraseña(salt, idUsuario, this);
                        cambioDeContraseña.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ingreso Exitoso", "Ingreso al Sistema");
                        this.Hide();
                        pantallaPrincipal.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Credenciales Incorrectas", "Error de Ingreso al Sistema");
                    tbUsuario.ResetText();
                    tbContraseña.ResetText();
                }
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
             Application.Exit();
            //PantallaPrincipal pantallaprincipal = new PantallaPrincipal();
            //pantallaprincipal.Show();
            //this.Hide();
        }

        private void TbContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                iniciarSesión();
            }
        }
    }
}
