﻿using System;
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
            String consulta = "update usuario set [password] = @pass where idusuario = @id; ";
            SqlCommand comando = new SqlCommand("SP_CAMBIO_DE_PASSWORD", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@pass", MD5Hash(salt + tbContraseña1.Text));
            comando.Parameters.AddWithValue("@id", idUsuario);

            comando.ExecuteNonQuery();

            conexion.Close();
            MessageBox.Show("Contraseña cambiada correctamente", "Cambio de contraseña");

            this.Hide();
            inicioDeSesión.Hide();
            pantallaPrincipal.Show();

        }


        private void TbContraseña2_TextChanged(object sender, EventArgs e)
        {
            if (tbContraseña2.Text.Equals(tbContraseña1.Text))
            {
                errorProvider1.SetError(tbContraseña2, null);
                bGuardar.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(tbContraseña2, "Las Contraseñas no coinciden");
                bGuardar.Enabled = false;
            }
            if (formatoContraseña(tbContraseña2.Text))
            {
                //errorProvider1.SetError(tbContraseña2, null);
            }
            else
            {
                bGuardar.Enabled = false;
            }
        }

        private void TbContraseña1_TextChanged(object sender, EventArgs e)
        {
            if (tbContraseña1.Text.Equals(tbContraseña2.Text))
            {
                errorProvider1.SetError(tbContraseña2, null);
                bGuardar.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(tbContraseña2, "Las Contraseñas no coinciden");
                bGuardar.Enabled = false;
            }
            if (formatoContraseña(tbContraseña1.Text))
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
            }
        }

        public static bool formatoContraseña(string contraseña)
        {
            String formato;
            //sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            formato = "^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$";
            if (Regex.IsMatch(contraseña, formato))
            {
                if (Regex.Replace(contraseña, formato, String.Empty).Length == 0)
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

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
