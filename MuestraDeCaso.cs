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

            String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA order by c.estado;";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
            dgvMostrar.Columns[0].HeaderText = "Estado";
            dgvMostrar.Columns[1].HeaderText = "Número";
            dgvMostrar.Columns[2].HeaderText = "Nombre";
            dgvMostrar.Columns[3].HeaderText = "Cuenta";
            dgvMostrar.Columns[4].HeaderText = "Fecha";
            dgvMostrar.Columns[5].HeaderText = "SLA";
            dgvMostrar.Columns[6].HeaderText = "Sector";
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;


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
                String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA where c.numero like '%" + tbBuscar.Text + "%'  order by c.estado;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Número";
                dgvMostrar.Columns[2].HeaderText = "Nombre";
                dgvMostrar.Columns[3].HeaderText = "Cuenta";
                dgvMostrar.Columns[4].HeaderText = "Fecha";
                dgvMostrar.Columns[5].HeaderText = "SLA";
                dgvMostrar.Columns[6].HeaderText = "Sector";

            }
            else if (cbBuscar.SelectedIndex == 1) // Cliente
            {
                String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA where p.nombre like '%" + tbBuscar.Text + "%'  order by c.estado;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Número";
                dgvMostrar.Columns[2].HeaderText = "Nombre";
                dgvMostrar.Columns[3].HeaderText = "Cuenta";
                dgvMostrar.Columns[4].HeaderText = "Fecha";
                dgvMostrar.Columns[5].HeaderText = "SLA";
                dgvMostrar.Columns[6].HeaderText = "Sector";

            }
            else if (cbBuscar.SelectedIndex == 2) // Cuenta
            {
                String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA where cl.cuenta like '%" + tbBuscar.Text + "%'  order by c.estado;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Número";
                dgvMostrar.Columns[2].HeaderText = "Nombre";
                dgvMostrar.Columns[3].HeaderText = "Cuenta";
                dgvMostrar.Columns[4].HeaderText = "Fecha";
                dgvMostrar.Columns[5].HeaderText = "SLA";
                dgvMostrar.Columns[6].HeaderText = "Sector";
            }
            else if (cbBuscar.SelectedIndex == 3) // Sector
            {
                String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA where c.sector like '%" + tbBuscar.Text + "%'  order by c.estado;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Número";
                dgvMostrar.Columns[2].HeaderText = "Nombre";
                dgvMostrar.Columns[3].HeaderText = "Cuenta";
                dgvMostrar.Columns[4].HeaderText = "Fecha";
                dgvMostrar.Columns[5].HeaderText = "SLA";
                dgvMostrar.Columns[6].HeaderText = "Sector";

            }



        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
