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
    public partial class CancelaciónDeCaso : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public CancelaciónDeCaso(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            muestraCasos();
        }

        public void muestraCasos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_LLENAR_TABLA_CASO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvCancelar.DataSource = dt;
            dgvCancelar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCancelar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCancelar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCancelar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCancelar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCancelar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCancelar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCancelar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCancelar.Columns[0].HeaderText = "Estado";
            dgvCancelar.Columns[1].HeaderText = "Número";
            dgvCancelar.Columns[2].HeaderText = "Nombre";
            dgvCancelar.Columns[3].HeaderText = "Cuenta";
            dgvCancelar.Columns[4].HeaderText = "Fecha";
            dgvCancelar.Columns[5].HeaderText = "SLA";
            dgvCancelar.Columns[6].HeaderText = "Sector";
            dgvCancelar.Columns[7].HeaderText = "ID Cliente";
            this.dgvCancelar.Columns[7].Visible = false;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar este caso?", "Cancelar Caso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();

                String idcaso = dgvCancelar.CurrentRow.Cells[7].Value.ToString();

                SqlCommand comando1 = new SqlCommand("SP_CANCELAR_CASO", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@IDCASO", idcaso);
                comando1.ExecuteNonQuery();


                MessageBox.Show("Caso Cancelado Correctamente", "Caso Cancelado");

                conexion.Close();

                SqlDataAdapter sda = new SqlDataAdapter("SP_LLENAR_TABLA_CASO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvCancelar.DataSource = dt;
                dgvCancelar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCancelar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCancelar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCancelar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCancelar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCancelar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCancelar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCancelar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCancelar.Columns[0].HeaderText = "Estado";
                dgvCancelar.Columns[1].HeaderText = "Número";
                dgvCancelar.Columns[2].HeaderText = "Nombre";
                dgvCancelar.Columns[3].HeaderText = "Cuenta";
                dgvCancelar.Columns[4].HeaderText = "Fecha";
                dgvCancelar.Columns[5].HeaderText = "SLA";
                dgvCancelar.Columns[6].HeaderText = "Sector";
                dgvCancelar.Columns[7].HeaderText = "ID Cliente";
                this.dgvCancelar.Columns[7].Visible = false;

            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.ResetText();
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbBuscar.Text.Trim() != "")
            {

                if (cbBuscar.SelectedIndex == 0) //numero de caso
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_POR_NUMERO_DE_CASO", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@NUMERO", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvCancelar.DataSource = dt;
                    dgvCancelar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCancelar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCancelar.Columns[0].HeaderText = "Estado";
                    dgvCancelar.Columns[1].HeaderText = "Número";
                    dgvCancelar.Columns[2].HeaderText = "Nombre";
                    dgvCancelar.Columns[3].HeaderText = "Cuenta";
                    dgvCancelar.Columns[4].HeaderText = "Fecha";
                    dgvCancelar.Columns[5].HeaderText = "SLA";
                    dgvCancelar.Columns[6].HeaderText = "Sector";
                    dgvCancelar.Columns[7].HeaderText = "ID Cliente";
                    this.dgvCancelar.Columns[7].Visible = false;

                }
                else if (cbBuscar.SelectedIndex == 1) // Cliente
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_POR_NOMBRE", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvCancelar.DataSource = dt;
                    dgvCancelar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCancelar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCancelar.Columns[0].HeaderText = "Estado";
                    dgvCancelar.Columns[1].HeaderText = "Número";
                    dgvCancelar.Columns[2].HeaderText = "Nombre";
                    dgvCancelar.Columns[3].HeaderText = "Cuenta";
                    dgvCancelar.Columns[4].HeaderText = "Fecha";
                    dgvCancelar.Columns[5].HeaderText = "SLA";
                    dgvCancelar.Columns[6].HeaderText = "Sector";
                    dgvCancelar.Columns[7].HeaderText = "ID Cliente";
                    this.dgvCancelar.Columns[7].Visible = false;
                }
                else if (cbBuscar.SelectedIndex == 2) // Cuenta
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_POR_CUENTA", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvCancelar.DataSource = dt;
                    dgvCancelar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCancelar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCancelar.Columns[0].HeaderText = "Estado";
                    dgvCancelar.Columns[1].HeaderText = "Número";
                    dgvCancelar.Columns[2].HeaderText = "Nombre";
                    dgvCancelar.Columns[3].HeaderText = "Cuenta";
                    dgvCancelar.Columns[4].HeaderText = "Fecha";
                    dgvCancelar.Columns[5].HeaderText = "SLA";
                    dgvCancelar.Columns[6].HeaderText = "Sector";
                    dgvCancelar.Columns[7].HeaderText = "ID Cliente";
                    this.dgvCancelar.Columns[7].Visible = false;
                }
                else if (cbBuscar.SelectedIndex == 3) // Sector
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_POR_SECTOR", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@SECTOR", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvCancelar.DataSource = dt;
                    dgvCancelar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvCancelar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCancelar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCancelar.Columns[0].HeaderText = "Estado";
                    dgvCancelar.Columns[1].HeaderText = "Número";
                    dgvCancelar.Columns[2].HeaderText = "Nombre";
                    dgvCancelar.Columns[3].HeaderText = "Cuenta";
                    dgvCancelar.Columns[4].HeaderText = "Fecha";
                    dgvCancelar.Columns[5].HeaderText = "SLA";
                    dgvCancelar.Columns[6].HeaderText = "Sector";
                    dgvCancelar.Columns[7].HeaderText = "ID Cliente";
                    this.dgvCancelar.Columns[7].Visible = false;
                }
                if (dgvCancelar.RowCount == 0)
                {
                    MessageBox.Show("Caso no encontrado", "Error");
                    tbBuscar.ResetText();
                    muestraCasos();
                }
            }
        }

        
    }
}
