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

namespace proyectoPantalla
{

    public partial class EliminaciónDeUsuario : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;

        public EliminaciónDeUsuario(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            mostrarDatos();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void mostrarDatos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvEliminar.DataSource = dt;
            dgvEliminar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEliminar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvEliminar.Columns[0].HeaderText = "Tipo";
            dgvEliminar.Columns[1].HeaderText = "Nombre";
            dgvEliminar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvEliminar.Columns[3].HeaderText = "Correo";

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();

                SqlCommand comando1 = new SqlCommand("SP_ELIMINACION_USUARIO", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@identificacion", dgvEliminar.CurrentRow.Cells[2].Value.ToString());
                comando1.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Usuario Eliminado Correctamente", "Usuario Eliminado");
                mostrarDatos();
            }
        }

        public void mostrarUsuarioPorNombre()
        {
            String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%" + tbBuscar.Text + "%' order by u.tipo;  ";
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO_NOMBRE", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@nombre", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvEliminar.DataSource = dt;
            dgvEliminar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEliminar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvEliminar.Columns[0].HeaderText = "Tipo";
            dgvEliminar.Columns[1].HeaderText = "Nombre";
            dgvEliminar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvEliminar.Columns[3].HeaderText = "Correo";
        }

        public void mostrarUsuarioPorIdentificacion()
        {
            String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%" + tbBuscar.Text + "%' order by u.tipo;";
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_USUARIO_IDENTIFICACION", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@identificacion", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvEliminar.DataSource = dt;

            dgvEliminar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEliminar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[0].HeaderText = "Tipo";
            dgvEliminar.Columns[1].HeaderText = "Nombre";
            dgvEliminar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvEliminar.Columns[3].HeaderText = "Correo";
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
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
