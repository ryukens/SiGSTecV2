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
    public partial class ModificaciónDeTécnico : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public ModificaciónDeTécnico(TabControl tabControl, TabPage tabInicio)
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
            dgvModificar.DataSource = dt;
            dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvModificar.Columns[0].HeaderText = "Estado";
            dgvModificar.Columns[1].HeaderText = "Nombre";
            dgvModificar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvModificar.Columns[3].HeaderText = "Sector";
            dgvModificar.Columns[4].HeaderText = "Alcance";
        }

        public void MostrarTecnicoPorCedula()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_TECNICOS_IDENTIFICACION", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@identificacion", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvModificar.DataSource = dt;
            dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvModificar.Columns[0].HeaderText = "Estado";
            dgvModificar.Columns[1].HeaderText = "Nombre";
            dgvModificar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvModificar.Columns[3].HeaderText = "Sector";
            dgvModificar.Columns[4].HeaderText = "Alcance";
        }
        public void mostraTecnicoPorNombre()
        {

            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_TECNICOS_NOMBRE", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@nombre", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgvModificar.DataSource = dt;
            dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvModificar.Columns[0].HeaderText = "Estado";
            dgvModificar.Columns[1].HeaderText = "Nombre";
            dgvModificar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvModificar.Columns[3].HeaderText = "Sector";
            dgvModificar.Columns[4].HeaderText = "Alcance";
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            if (dgvModificar.CurrentRow != null)
            {
                String cedula = dgvModificar.CurrentRow.Cells[2].Value.ToString();
                CambioDeDatosTécnico cambioDeDatosTécnico = new CambioDeDatosTécnico(cedula);
                cambioDeDatosTécnico.ShowDialog();
                mostrarTecnicos();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.Text = "";
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
            if (dgvModificar.RowCount == 0)
            {
                MessageBox.Show("Técnico no encontrado", "Error");
                tbBuscar.ResetText();
                mostrarTecnicos();
            }
        }

        private void TbBuscar_Enter(object sender, EventArgs e)
        {

        }

        private void TbBuscar_Leave(object sender, EventArgs e)
        {

        }
    }
}
