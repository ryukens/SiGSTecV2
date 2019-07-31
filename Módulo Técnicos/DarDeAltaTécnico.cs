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
    public partial class DarDeAltaTécnico : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public DarDeAltaTécnico(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            mostrarTecnicos();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            cbBuscar.SelectedIndex = 0;
        }

        public void mostrarTecnicos()
        {

            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_TECNICOS2", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAlzar.DataSource = dt;
            dgvAlzar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAlzar.Columns[0].HeaderText = "Estado";
            dgvAlzar.Columns[1].HeaderText = "Nombre";
            dgvAlzar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvAlzar.Columns[3].HeaderText = "Sector";
            dgvAlzar.Columns[4].HeaderText = "Alcance";

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }

        private void BAlzar_Click(object sender, EventArgs e)
        {
            if (dgvAlzar.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro que desea Dar de Alta este técnico?", "Dar de Alta Técnico", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conexion.Open();
                    SqlCommand comando1 = new SqlCommand("SP_DADO_DE_ALTA_TECNICO", conexion);
                    comando1.CommandType = CommandType.StoredProcedure;
                    comando1.Parameters.AddWithValue("@identificacion", dgvAlzar.CurrentRow.Cells[2].Value.ToString());
                    comando1.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Técnico Dado de Alta Correctamente", "Técnico Dado de Alta");
                    mostrarTecnicos();
                }
            }
        }

        public void buscarTecnicoPorNombre()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_TECNICOS_NOMBRE2", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@nombre", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAlzar.DataSource = dt;
            dgvAlzar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAlzar.Columns[0].HeaderText = "Estado";
            dgvAlzar.Columns[1].HeaderText = "Nombre";
            dgvAlzar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvAlzar.Columns[3].HeaderText = "Sector";
            dgvAlzar.Columns[4].HeaderText = "Alcance";

        }

        public void mostrarTecnicoPorCedula()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_TECNICOS_IDENTIFICACION2", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@identificacion", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAlzar.DataSource = dt;
            dgvAlzar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAlzar.Columns[0].HeaderText = "Estado";
            dgvAlzar.Columns[1].HeaderText = "Nombre";
            dgvAlzar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvAlzar.Columns[3].HeaderText = "Sector";
            dgvAlzar.Columns[4].HeaderText = "Alcance";
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                buscarTecnicoPorNombre();
            }
            else
            {
                mostrarTecnicoPorCedula();
            }
            if (dgvAlzar.RowCount == 0)
            {
                MessageBox.Show("Técnico no encontrado", "Error");
                tbBuscar.ResetText();
                mostrarTecnicos();
            }
        }
    }
}
