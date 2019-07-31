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
    public partial class DarDeBajaCliente : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public DarDeBajaCliente(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            mostrarDatosCompleto();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public void mostrarDatosCompleto()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_LLENADO_TABLA_CLIENTE", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvBajar.DataSource = dt;
            dgvBajar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBajar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBajar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBajar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBajar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBajar.Columns[0].HeaderText = "Tipo";
            dgvBajar.Columns[1].HeaderText = "Nombre";
            dgvBajar.Columns[2].HeaderText = "Cuenta";
            dgvBajar.Columns[3].HeaderText = "Identificación";
            dgvBajar.Columns[4].HeaderText = "SLA";

        }


        private void EliminarCliente_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            if (dgvBajar.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro que desea Dar de Baja este Cliente?", "Dar de Baja Cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conexion.Open();
                    SqlCommand comando1 = new SqlCommand("SP_DADO_DE_BAJA", conexion);
                    comando1.CommandType = CommandType.StoredProcedure;
                    comando1.Parameters.AddWithValue("@identificacion", dgvBajar.CurrentRow.Cells[3].Value.ToString());
                    comando1.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Cliente Dado de Baja Correctamente", "Cliente Dado de Baja");
                    mostrarDatosCompleto();
                }
            }
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
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
                    dgvBajar.DataSource = dt;
                    dgvBajar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvBajar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[0].HeaderText = "Tipo";
                    dgvBajar.Columns[1].HeaderText = "Nombre";
                    dgvBajar.Columns[2].HeaderText = "Cuenta";
                    dgvBajar.Columns[3].HeaderText = "Identificación";
                    dgvBajar.Columns[4].HeaderText = "SLA";
                }
                else if (cbBuscar.SelectedIndex == 1) // cedula
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CEDULA", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@CEDULA", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvBajar.DataSource = dt;
                    dgvBajar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvBajar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[0].HeaderText = "Tipo";
                    dgvBajar.Columns[1].HeaderText = "Nombre";
                    dgvBajar.Columns[2].HeaderText = "Cuenta";
                    dgvBajar.Columns[3].HeaderText = "Identificación";
                    dgvBajar.Columns[4].HeaderText = "SLA";
                }
                else if (cbBuscar.SelectedIndex == 2) // ruc
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_RUC", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@RUC", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvBajar.DataSource = dt;
                    dgvBajar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvBajar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[0].HeaderText = "Tipo";
                    dgvBajar.Columns[1].HeaderText = "Nombre";
                    dgvBajar.Columns[2].HeaderText = "Cuenta";
                    dgvBajar.Columns[3].HeaderText = "Identificación";
                    dgvBajar.Columns[4].HeaderText = "SLA";
                }
                else // cuenta
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CUENTA", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvBajar.DataSource = dt;
                    dgvBajar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvBajar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvBajar.Columns[0].HeaderText = "Tipo";
                    dgvBajar.Columns[1].HeaderText = "Nombre";
                    dgvBajar.Columns[2].HeaderText = "Cuenta";
                    dgvBajar.Columns[3].HeaderText = "Identificación";
                    dgvBajar.Columns[4].HeaderText = "SLA";
                }
                if (dgvBajar.RowCount == 0)
                {

                    tbBuscar.ResetText();
                    mostrarDatosCompleto();
                    MessageBox.Show("Cliente no encontrado", "Error");
                }
            }
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.ResetText();
        }

        private void DgvBajar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
