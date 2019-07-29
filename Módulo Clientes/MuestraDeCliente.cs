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
    public partial class MuestraDeCliente : UserControl
    {

        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public MuestraDeCliente(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            llenarCampos();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public void llenarCampos()
        {
            //String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA   order by c.tipo;";
            SqlDataAdapter sda = new SqlDataAdapter("SP_LLENADO_TABLA_CLIENTE", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            var topLeftHeaderCell = dgvMostrar.TopLeftHeaderCell;
            sda.Fill(dt);
            dgvMostrar.DataSource = dt;
            dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[0].HeaderText = "Tipo";
            dgvMostrar.Columns[1].HeaderText = "Nombre";
            dgvMostrar.Columns[2].HeaderText = "Cuenta";
            dgvMostrar.Columns[3].HeaderText = "Identificación";
            dgvMostrar.Columns[4].HeaderText = "SLA";
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_NOMBRE", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[0].HeaderText = "Tipo";
                dgvMostrar.Columns[1].HeaderText = "Nombre";
                dgvMostrar.Columns[2].HeaderText = "Cuenta";
                dgvMostrar.Columns[3].HeaderText = "Identificación";
                dgvMostrar.Columns[4].HeaderText = "SLA";
            }
            else if (cbBuscar.SelectedIndex == 1) // cedula
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CEDULA", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CEDULA", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[0].HeaderText = "Tipo";
                dgvMostrar.Columns[1].HeaderText = "Nombre";
                dgvMostrar.Columns[2].HeaderText = "Cuenta";
                dgvMostrar.Columns[3].HeaderText = "Identificación";
                dgvMostrar.Columns[4].HeaderText = "SLA";
            }
            else if (cbBuscar.SelectedIndex == 2) // ruc
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_RUC", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@RUC", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[0].HeaderText = "Tipo";
                dgvMostrar.Columns[1].HeaderText = "Nombre";
                dgvMostrar.Columns[2].HeaderText = "Cuenta";
                dgvMostrar.Columns[3].HeaderText = "Identificación";
                dgvMostrar.Columns[4].HeaderText = "SLA";
            }
            else // cuenta
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CUENTA", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[0].HeaderText = "Tipo";
                dgvMostrar.Columns[1].HeaderText = "Nombre";
                dgvMostrar.Columns[2].HeaderText = "Cuenta";
                dgvMostrar.Columns[3].HeaderText = "Identificación";
                dgvMostrar.Columns[4].HeaderText = "SLA";
            }
            if (dgvMostrar.RowCount == 0)
            {
                MessageBox.Show("Cliente no encontrado", "Error");
                tbBuscar.ResetText();
                llenarCampos();
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

        private void DgvMostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
