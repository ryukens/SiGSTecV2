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
    public partial class EliminaciónDeTécnico : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public EliminaciónDeTécnico(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();

            cbBuscar.SelectedIndex = 0;
            mostrarTecnicos();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void mostrarTecnicos()
        {
            String consulta = "select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA;";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvEliminar.DataSource = dt;
            dgvEliminar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEliminar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEliminar.Columns[0].HeaderText = "Estado";
            dgvEliminar.Columns[1].HeaderText = "Nombre";
            dgvEliminar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvEliminar.Columns[3].HeaderText = "Sector";
            dgvEliminar.Columns[4].HeaderText = "Alcance";
        }


        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este técnico?", "Eliminar Técnico", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();

                String consulta1 = "delete from persona where identificacion = @identificacion;";
                SqlCommand comando1 = new SqlCommand(consulta1, conexion);
                comando1.Parameters.AddWithValue("@identificacion", dgvEliminar.CurrentRow.Cells[2].Value.ToString());

                comando1.ExecuteNonQuery();


                conexion.Close();


                MessageBox.Show("Técnico Eliminado Correctamente", "Técnico Eliminado");
                mostrarTecnicos();
            }
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {

                String consulta = "select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%" + tbBuscar.Text + "%' order by t.sector;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvEliminar.DataSource = dt;
                dgvEliminar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvEliminar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvEliminar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvEliminar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvEliminar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEliminar.Columns[0].HeaderText = "Estado";
                dgvEliminar.Columns[1].HeaderText = "Nombre";
                dgvEliminar.Columns[2].HeaderText = "Cédula de Ciudadanía";
                dgvEliminar.Columns[3].HeaderText = "Sector";
                dgvEliminar.Columns[4].HeaderText = "Alcance";
            }
            else
            {




                String consulta = "select t.estado, p.nombre, p.identificacion,  t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where p.identificacion like '%" + tbBuscar.Text + "%' order by t.sector;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvEliminar.DataSource = dt;
                dgvEliminar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvEliminar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvEliminar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvEliminar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvEliminar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEliminar.Columns[0].HeaderText = "Estado";
                dgvEliminar.Columns[1].HeaderText = "Nombre";
                dgvEliminar.Columns[2].HeaderText = "Cédula de Ciudadanía";
                dgvEliminar.Columns[3].HeaderText = "Sector";
                dgvEliminar.Columns[4].HeaderText = "Alcance";

            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
