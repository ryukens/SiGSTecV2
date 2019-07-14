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
            if (cbBuscar.SelectedIndex == 0)
            {
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla, c.idcliente  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.nombre like '%" + tbBuscar.Text + "%' order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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

            }
            else if (cbBuscar.SelectedIndex == 1) // cedula
            {
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla, c.idcliente  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.identificacion like '%" + tbBuscar.Text + "%'  and c.tipo = Persona order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
            }
            else if (cbBuscar.SelectedIndex == 2) // ruc
            {
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla, c.idcliente  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.identificacion like '%" + tbBuscar.Text + "%'  and c.tipo = Empresa order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
            }
            else // cuenta
            {
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla, c.idcliente  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where c.cuenta like '%" + tbBuscar.Text + "%'  and c.tipo = Empresa order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
            }
        }

        private void CbBuscar_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            this.Dispose();
        }
    }
}
