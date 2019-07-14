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
            String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona order by u.tipo;  ";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                conexion.Open();

                String consulta1 = "delete from persona where identificacion = @identificacion;";
                SqlCommand comando1 = new SqlCommand(consulta1, conexion);
                comando1.Parameters.AddWithValue("@identificacion", dgvEliminar.CurrentRow.Cells[2].Value.ToString());

                comando1.ExecuteNonQuery();


                conexion.Close();


                MessageBox.Show("Usuario Eliminado Correctamente", "Usuario Eliminado");
                mostrarDatos();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {

                String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%" + tbBuscar.Text + "%' order by u.tipo;  ";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
            else
            {




                String consulta = "select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%" + tbBuscar.Text + "%' order by u.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
