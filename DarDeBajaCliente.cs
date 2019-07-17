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

        public DarDeBajaCliente()
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
        }

        public void mostrarDatosCompleto()
        {

            String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA   order by c.tipo;";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
            if (MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();

                String consulta1 = "delete from persona where identificacion = @identificacion;";
                SqlCommand comando1 = new SqlCommand(consulta1, conexion);
                comando1.Parameters.AddWithValue("@identificacion", dgvBajar.CurrentRow.Cells[3].Value.ToString());

                comando1.ExecuteNonQuery();


                conexion.Close();

                MessageBox.Show("Cliente Eliminado Correctamente", "Cliente Eliminado");
                mostrarDatosCompleto();
            }
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.nombre like '%" + tbBuscar.Text + "%' order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.identificacion like '%" + tbBuscar.Text + "%'  and c.tipo = Persona order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where p.identificacion like '%" + tbBuscar.Text + "%'  and c.tipo = Empresa order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
                String consulta = "select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  where c.cuenta like '%" + tbBuscar.Text + "%'  and c.tipo = Empresa order by c.tipo;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
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
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
