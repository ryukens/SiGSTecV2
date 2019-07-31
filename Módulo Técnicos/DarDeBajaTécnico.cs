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
    public partial class DarDeBajaTécnico : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public DarDeBajaTécnico(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            mostrarTecnicos();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public void mostrarTecnicos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_TECNICOS", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            if(dgvEliminar.CurrentRow != null) {
                if (MessageBox.Show("¿Está seguro de que desea dar de baja este técnico?", "Dar de Baja Técnico", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conexion.Open();
                    SqlCommand comando1 = new SqlCommand("SP_DADO_DE_BAJA_TECNICO", conexion);
                    comando1.CommandType = CommandType.StoredProcedure;
                    comando1.Parameters.AddWithValue("@identificacion", dgvEliminar.CurrentRow.Cells[2].Value.ToString());
                    comando1.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Técnico Dado de Baja Correctamente", "Técnico Dado de Baja");
                    tbBuscar.ResetText();
                    mostrarTecnicos();
                }
            }
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void MostrarTecnicoPorCedula()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_TECNICOS_IDENTIFICACION", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@identificacion", tbBuscar.Text);
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
        public void mostraTecnicoPorNombre()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_TECNICOS_NOMBRE", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@nombre", tbBuscar.Text);
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

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                mostraTecnicoPorNombre();
           
               
            }
            else
            {
                MostrarTecnicoPorCedula();

            }
            if (dgvEliminar.RowCount == 0)
            {
                MessageBox.Show("Técnico no encontrado", "Error");
                tbBuscar.ResetText();
                mostrarTecnicos();
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
