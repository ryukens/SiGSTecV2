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

namespace proyectoPantalla.Módulo_Administración
{
    public partial class DadaDeAltaUsuario : UserControl
    {
        TabControl tabControl;
        TabPage tabInicio;
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");

        public DadaDeAltaUsuario(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            tabControl.SelectTab(tabInicio);
        }
        public void mostrarDatos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO_INACTIVO", conexion);
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

        private void BDarDeAlta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea dar de alta este usuario?", "Dar de alte Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();

                SqlCommand comando1 = new SqlCommand("SP_DAR_DE_ALTA_USUARIO", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@identificacion", dgvDarDeAlta.CurrentRow.Cells[2].Value.ToString());
                comando1.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Usuario dado de alta correctamente", "Usuario Dado de alta");
                mostrarDatos();
            }
        }


        public void mostrarUsuarioPorNombre()
        {
            String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%" + tbBuscar.Text + "%' order by u.tipo;  ";
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO_NOMBRE_INACTIVO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@nombre", tbBuscar.Text);
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

        public void mostrarUsuarioPorIdentificacion()
        {
            String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%" + tbBuscar.Text + "%' order by u.tipo;";
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO_IDENTIFICACION_INACTIVO", conexion);
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

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbBuscar.Text.Trim() != "")
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
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
