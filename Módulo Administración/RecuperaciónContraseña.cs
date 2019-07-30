using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace proyectoPantalla.Módulo_Administración
{
    public partial class RecuperaciónContraseña : UserControl
    {
        
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");

        TabControl tabControl;
        TabPage tabInicio;
        public RecuperaciónContraseña(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }
        public RecuperaciónContraseña()
        {
            InitializeComponent();
            
        }

        public void mostrarUsuarioPorNombre()
        {
            String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%" + tbBuscar.Text + "%' order by u.tipo;  ";
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO_NOMBRE_ACTIVO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@nombre", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sda.Fill(dt);
            dgvDarDeAlta.DataSource = dt;
            dgvDarDeAlta.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDarDeAlta.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDarDeAlta.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDarDeAlta.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvDarDeAlta.Columns[0].HeaderText = "Tipo";
            dgvDarDeAlta.Columns[1].HeaderText = "Nombre";
            dgvDarDeAlta.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvDarDeAlta.Columns[3].HeaderText = "Correo";
        }

        public void mostrarUsuarioPorIdentificacion()
        {
            String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%" + tbBuscar.Text + "%' order by u.tipo;";
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO_IDENTIFICACION_ACTIVO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@identificacion", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvDarDeAlta.DataSource = dt;
            dgvDarDeAlta.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDarDeAlta.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDarDeAlta.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDarDeAlta.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvDarDeAlta.Columns[0].HeaderText = "Tipo";
            dgvDarDeAlta.Columns[1].HeaderText = "Nombre";
            dgvDarDeAlta.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvDarDeAlta.Columns[3].HeaderText = "Correo";
        }

        public void mostrarDatos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO_ACTIVO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvDarDeAlta.DataSource = dt;
            dgvDarDeAlta.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDarDeAlta.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDarDeAlta.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDarDeAlta.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvDarDeAlta.Columns[0].HeaderText = "Tipo";
            dgvDarDeAlta.Columns[1].HeaderText = "Nombre";
            dgvDarDeAlta.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvDarDeAlta.Columns[3].HeaderText = "Correo";

        }


        private void BRecuperar_Click(object sender, EventArgs e)
        {
            String salt="";
            if (MessageBox.Show("¿Está seguro que desea recuperar la contraseña de este usuario?", "Recuperar Contraseña", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("SP_OBTENER_SALT", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@identificacion", dgvDarDeAlta.CurrentRow.Cells[2].Value.ToString());
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    salt = dr.GetString(0);
                }

                conexion.Close();

                conexion.Open();

                SqlCommand comando1 = new SqlCommand("SP_RECUPERAR_CONTRASEÑA", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@identificacion", dgvDarDeAlta.CurrentRow.Cells[2].Value.ToString());
                comando1.Parameters.AddWithValue("@pass", MD5Hash(salt + "12345678"));
                comando1.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Contraseña cambiada. Se pedirá el cambio de contraseña en el siguiente ingreso", "Recuperar Contraseña");
                mostrarDatos();
            }
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

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                mostrarUsuarioPorNombre();
            }
            else
            {
                mostrarUsuarioPorIdentificacion();
            }
            if (dgvDarDeAlta.RowCount == 0)
            {
                MessageBox.Show("Usuario no encontrado", "Error");
                tbBuscar.ResetText();
                mostrarDatos();
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            tabControl.SelectTab(tabInicio);
        }
    }
}
