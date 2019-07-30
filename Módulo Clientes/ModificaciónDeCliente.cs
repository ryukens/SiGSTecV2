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
    public partial class ModificaciónDeCliente : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public ModificaciónDeCliente(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            mostrarCliente();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public void mostrarCliente()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_LLENADO_TABLA_CLIENTE", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvModificar.DataSource = dt;
            dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[0].HeaderText = "Tipo";
            dgvModificar.Columns[1].HeaderText = "Nombre";
            dgvModificar.Columns[2].HeaderText = "Cuenta";
            dgvModificar.Columns[3].HeaderText = "Identificación";
            dgvModificar.Columns[4].HeaderText = "SLA";
        }


        private void Button2_Click_1(object sender, EventArgs e)
        {
            String cedula = dgvModificar.SelectedRows[0].Cells[3].Value.ToString();
            //MessageBox.Show(cedula);
            CambioDeDatosCliente cambioDeDatosCliente = new CambioDeDatosCliente(cedula);
            cambioDeDatosCliente.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.ResetText();
        }

        private void TbBuscar_TextChanged_1(object sender, EventArgs e)
        {
            if (tbBuscar.Text.Trim() != "")
            {
                if (cbBuscar.SelectedIndex == 0)
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_NOMBRE", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvModificar.DataSource = dt;
                    dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[0].HeaderText = "Tipo";
                    dgvModificar.Columns[1].HeaderText = "Nombre";
                    dgvModificar.Columns[2].HeaderText = "Cuenta";
                    dgvModificar.Columns[3].HeaderText = "Identificación";
                    dgvModificar.Columns[4].HeaderText = "SLA";
                }
                else if (cbBuscar.SelectedIndex == 1) // cedula
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CEDULA", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@CEDULA", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvModificar.DataSource = dt;
                    dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[0].HeaderText = "Tipo";
                    dgvModificar.Columns[1].HeaderText = "Nombre";
                    dgvModificar.Columns[2].HeaderText = "Cuenta";
                    dgvModificar.Columns[3].HeaderText = "Identificación";
                    dgvModificar.Columns[4].HeaderText = "SLA";
                }
                else if (cbBuscar.SelectedIndex == 2) // ruc
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_RUC", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@RUC", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvModificar.DataSource = dt;
                    dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[0].HeaderText = "Tipo";
                    dgvModificar.Columns[1].HeaderText = "Nombre";
                    dgvModificar.Columns[2].HeaderText = "Cuenta";
                    dgvModificar.Columns[3].HeaderText = "Identificación";
                    dgvModificar.Columns[4].HeaderText = "SLA";
                }
                else if (cbBuscar.SelectedIndex == 3) // cuenta
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CUENTA", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvModificar.DataSource = dt;
                    dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvModificar.Columns[0].HeaderText = "Tipo";
                    dgvModificar.Columns[1].HeaderText = "Nombre";
                    dgvModificar.Columns[2].HeaderText = "Cuenta";
                    dgvModificar.Columns[3].HeaderText = "Identificación";
                    dgvModificar.Columns[4].HeaderText = "SLA";
                }

                if (dgvModificar.RowCount == 0)
                {

                    MessageBox.Show("Cliente no encontrado", "Error");
                    tbBuscar.ResetText();
                    mostrarCliente();
                    
                }
            }
        }
    }
}
