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
    public partial class MuestraDeCaso : UserControl
    {

        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;

        public MuestraDeCaso(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public void muestraCasos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_LLENAR_TABLA_CASO", conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvMostrar.DataSource = dt;
            dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[0].HeaderText = "Estado";
            dgvMostrar.Columns[1].HeaderText = "Número";
            dgvMostrar.Columns[2].HeaderText = "Nombre";
            dgvMostrar.Columns[3].HeaderText = "Cuenta";
            dgvMostrar.Columns[4].HeaderText = "Fecha";
            dgvMostrar.Columns[5].HeaderText = "SLA";
            dgvMostrar.Columns[6].HeaderText = "Sector";
            dgvMostrar.Columns[7].HeaderText = "ID Cliente";
            this.dgvMostrar.Columns[7].Visible = false;
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0) //numero de caso
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_NUMERO_DE_CASO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NUMERO", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Número";
                dgvMostrar.Columns[2].HeaderText = "Nombre";
                dgvMostrar.Columns[3].HeaderText = "Cuenta";
                dgvMostrar.Columns[4].HeaderText = "Fecha";
                dgvMostrar.Columns[5].HeaderText = "SLA";
                dgvMostrar.Columns[6].HeaderText = "Sector";
                dgvMostrar.Columns[7].HeaderText = "ID Cliente";
                this.dgvMostrar.Columns[7].Visible = false;

            }
            else if (cbBuscar.SelectedIndex == 1) // Cliente
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_NOMBRE", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Número";
                dgvMostrar.Columns[2].HeaderText = "Nombre";
                dgvMostrar.Columns[3].HeaderText = "Cuenta";
                dgvMostrar.Columns[4].HeaderText = "Fecha";
                dgvMostrar.Columns[5].HeaderText = "SLA";
                dgvMostrar.Columns[6].HeaderText = "Sector";
                dgvMostrar.Columns[7].HeaderText = "ID Cliente";
                this.dgvMostrar.Columns[7].Visible = false;
            }
            else if (cbBuscar.SelectedIndex == 2) // Cuenta
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_CUENTA", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Número";
                dgvMostrar.Columns[2].HeaderText = "Nombre";
                dgvMostrar.Columns[3].HeaderText = "Cuenta";
                dgvMostrar.Columns[4].HeaderText = "Fecha";
                dgvMostrar.Columns[5].HeaderText = "SLA";
                dgvMostrar.Columns[6].HeaderText = "Sector";
                dgvMostrar.Columns[7].HeaderText = "ID Cliente";
                this.dgvMostrar.Columns[7].Visible = false;

            }
            else if (cbBuscar.SelectedIndex == 3) // Sector
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_SECTOR", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@SECTOR", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Número";
                dgvMostrar.Columns[2].HeaderText = "Nombre";
                dgvMostrar.Columns[3].HeaderText = "Cuenta";
                dgvMostrar.Columns[4].HeaderText = "Fecha";
                dgvMostrar.Columns[5].HeaderText = "SLA";
                dgvMostrar.Columns[6].HeaderText = "Sector";
                dgvMostrar.Columns[7].HeaderText = "ID Cliente";
                this.dgvMostrar.Columns[7].Visible = false;
            }



        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            tabControl.SelectTab(tabInicio);
        }

        private void DgvMostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}