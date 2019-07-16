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
            String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA   order by c.tipo;";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public ModificaciónDeCliente()
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            String cedula = dgvModificar.CurrentRow.Cells[3].Value.ToString();
            CambioDeDatosCliente cambioDeDatosCliente = new CambioDeDatosCliente(cedula);
            cambioDeDatosCliente.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.nombre like '%" + tbBuscar.Text + "%' order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.identificacion like '%" + tbBuscar.Text + "%'  and c.tipo = Persona order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.identificacion like '%" + tbBuscar.Text + "%'  and c.tipo = Empresa order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
            else // cuenta
            {
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where c.cuenta like '%" + tbBuscar.Text + "%'  and c.tipo = Empresa order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
