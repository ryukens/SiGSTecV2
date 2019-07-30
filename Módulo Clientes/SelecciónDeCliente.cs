using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla
{
    public partial class SelecciónDeCliente : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");


        /// <param name="lClienteSeleccionado"></param>
        public SelecciónDeCliente(Label lClienteSeleccionado, Label lIdCliente)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.lClienteSeleccionado = lClienteSeleccionado;
            this.lIdCliente = lIdCliente;

            String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla, c.idcliente  from persona as p join cliente as c on p.idpersona = c.IDPERSONA   order by c.tipo;";
             SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             dgvSeleccionar.DataSource = dt;
             var topLeftHeaderCell = dgvSeleccionar.TopLeftHeaderCell;
             dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
             dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
             dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
             dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
             dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
             dgvSeleccionar.Columns[0].HeaderText = "Tipo";
             dgvSeleccionar.Columns[1].HeaderText = "Nombre";
             dgvSeleccionar.Columns[2].HeaderText = "Cuenta";
             dgvSeleccionar.Columns[3].HeaderText = "Identificación";
             dgvSeleccionar.Columns[4].HeaderText = "SLA";
             dgvSeleccionar.Columns[5].HeaderText = "Id Cliente";

        }

        Label lClienteSeleccionado;
        Label lIdCliente;

        private void FormBusquedaDeCliente_Load(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            String nombreCliente = dgvSeleccionar.CurrentRow.Cells[1].Value.ToString();
            lClienteSeleccionado.Text = nombreCliente;

            String IdCliente = dgvSeleccionar.CurrentRow.Cells[5].Value.ToString();
            lIdCliente.Text = IdCliente;


            this.Dispose();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void DgvSeleccionar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvSeleccionar_SelectionChanged(object sender, EventArgs e)
        {
            

        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CbBuscar_TextChanged(object sender, EventArgs e)
        {
            llenarCampos();
        }

        private void CbBuscar_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            this.Dispose();
        }

        public void llenarCampos()
        {
            //String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA   order by c.tipo;";
            SqlDataAdapter sda = new SqlDataAdapter("SP_LLENADO_TABLA_CLIENTE_SELECCION_PARA_CASO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            var topLeftHeaderCell = dgvSeleccionar.TopLeftHeaderCell;
            sda.Fill(dt);
            dgvSeleccionar.DataSource = dt;
            dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[0].HeaderText = "Tipo";
            dgvSeleccionar.Columns[1].HeaderText = "Nombre";
            dgvSeleccionar.Columns[2].HeaderText = "Cuenta";
            dgvSeleccionar.Columns[3].HeaderText = "Identificación";
            dgvSeleccionar.Columns[4].HeaderText = "SLA";
            dgvSeleccionar.Columns[5].HeaderText = "Id Cliente";
            this.dgvSeleccionar.Columns[5].Visible = false;
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_NOMBRE_SELECCION_PARA_CASO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvSeleccionar.DataSource = dt;
                dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[0].HeaderText = "Tipo";
                dgvSeleccionar.Columns[1].HeaderText = "Nombre";
                dgvSeleccionar.Columns[2].HeaderText = "Cuenta";
                dgvSeleccionar.Columns[3].HeaderText = "Identificación";
                dgvSeleccionar.Columns[4].HeaderText = "SLA";
                dgvSeleccionar.Columns[5].HeaderText = "Id Cliente";
                this.dgvSeleccionar.Columns[5].Visible = false;
            }
            else if (cbBuscar.SelectedIndex == 1) // cedula
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CEDULA_SELECCION_PARA_CASO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CEDULA", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvSeleccionar.DataSource = dt;
                dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[0].HeaderText = "Tipo";
                dgvSeleccionar.Columns[1].HeaderText = "Nombre";
                dgvSeleccionar.Columns[2].HeaderText = "Cuenta";
                dgvSeleccionar.Columns[3].HeaderText = "Identificación";
                dgvSeleccionar.Columns[4].HeaderText = "SLA";
                dgvSeleccionar.Columns[5].HeaderText = "Id Cliente";
                this.dgvSeleccionar.Columns[5].Visible = false;
            }
            else if (cbBuscar.SelectedIndex == 2) // ruc
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_RUC_SELECCION_PARA_CASO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@RUC", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvSeleccionar.DataSource = dt;
                dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[0].HeaderText = "Tipo";
                dgvSeleccionar.Columns[1].HeaderText = "Nombre";
                dgvSeleccionar.Columns[2].HeaderText = "Cuenta";
                dgvSeleccionar.Columns[3].HeaderText = "Identificación";
                dgvSeleccionar.Columns[4].HeaderText = "SLA";
                dgvSeleccionar.Columns[5].HeaderText = "Id Cliente";
                this.dgvSeleccionar.Columns[5].Visible = false;
            }
            else // cuenta
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CLIENTE_POR_CUENTA_SELECCION_PARA_CASO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvSeleccionar.DataSource = dt;
                dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvSeleccionar.Columns[0].HeaderText = "Tipo";
                dgvSeleccionar.Columns[1].HeaderText = "Nombre";
                dgvSeleccionar.Columns[2].HeaderText = "Cuenta";
                dgvSeleccionar.Columns[3].HeaderText = "Identificación";
                dgvSeleccionar.Columns[4].HeaderText = "SLA";
                dgvSeleccionar.Columns[5].HeaderText = "Id Cliente";
                this.dgvSeleccionar.Columns[5].Visible = false;
            }
            if (dgvSeleccionar.RowCount == 0)
            {
                MessageBox.Show("Cliente no encontrado", "Error");
                tbBuscar.ResetText();
                llenarCampos();
            }
        }
    }
}
