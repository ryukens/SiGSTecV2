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
    public partial class DarDeAltaCliente : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        public DarDeAltaCliente()
        {
            InitializeComponent();
        }

        TabControl tabControl;
        TabPage tabInicio;
        public DarDeAltaCliente(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.ResetText();
        }

        public void mostrarDatosCompleto() {

            SqlDataAdapter sda = new SqlDataAdapter("SP_LLENADO_TABLA_CLIENTE2", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAlzar.DataSource = dt;
            dgvAlzar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAlzar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAlzar.Columns[0].HeaderText = "Tipo";
            dgvAlzar.Columns[1].HeaderText = "Nombre";
            dgvAlzar.Columns[2].HeaderText = "Cuenta";
            dgvAlzar.Columns[3].HeaderText = "Identificación";
            dgvAlzar.Columns[4].HeaderText = "SLA";
        }

        private void BAlzar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea Dar de Alta este Cliente?", "Dar de Alta Cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();
                SqlCommand comando1 = new SqlCommand("SP_DADO_DE_ALTA", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@identificacion", dgvAlzar.CurrentRow.Cells[3].Value.ToString());
                comando1.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Cliente Dado de Alta Correctamente", "Cliente Dado de Alta");
                mostrarDatosCompleto();
            }
        }

        private void TbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_NOMBRE2", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvAlzar.DataSource = dt;
                dgvAlzar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAlzar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[0].HeaderText = "Tipo";
                dgvAlzar.Columns[1].HeaderText = "Nombre";
                dgvAlzar.Columns[2].HeaderText = "Cuenta";
                dgvAlzar.Columns[3].HeaderText = "Identificación";
                dgvAlzar.Columns[4].HeaderText = "SLA";
            }
            else if (cbBuscar.SelectedIndex == 1) // cedula
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CEDULA2", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CEDULA", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvAlzar.DataSource = dt;
                dgvAlzar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAlzar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[0].HeaderText = "Tipo";
                dgvAlzar.Columns[1].HeaderText = "Nombre";
                dgvAlzar.Columns[2].HeaderText = "Cuenta";
                dgvAlzar.Columns[3].HeaderText = "Identificación";
                dgvAlzar.Columns[4].HeaderText = "SLA";
            }
            else if (cbBuscar.SelectedIndex == 2) // ruc
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_RUC2", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@RUC", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvAlzar.DataSource = dt;
                dgvAlzar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAlzar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[0].HeaderText = "Tipo";
                dgvAlzar.Columns[1].HeaderText = "Nombre";
                dgvAlzar.Columns[2].HeaderText = "Cuenta";
                dgvAlzar.Columns[3].HeaderText = "Identificación";
                dgvAlzar.Columns[4].HeaderText = "SLA";
            }
            else // cuenta
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CUENTA2", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvAlzar.DataSource = dt;
                dgvAlzar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAlzar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAlzar.Columns[0].HeaderText = "Tipo";
                dgvAlzar.Columns[1].HeaderText = "Nombre";
                dgvAlzar.Columns[2].HeaderText = "Cuenta";
                dgvAlzar.Columns[3].HeaderText = "Identificación";
                dgvAlzar.Columns[4].HeaderText = "SLA";
            }
        }
    }
}
