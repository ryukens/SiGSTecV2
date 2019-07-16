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
    public partial class CierreDeCaso : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;


        public CierreDeCaso(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;

            String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA WHERE c.estado = 'ABIERTO' order by c.estado;";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvCerrar.DataSource = dt;
            dgvCerrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCerrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCerrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCerrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCerrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCerrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCerrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCerrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCerrar.Columns[0].HeaderText = "Estado";
            dgvCerrar.Columns[1].HeaderText = "Número";
            dgvCerrar.Columns[2].HeaderText = "Nombre";
            dgvCerrar.Columns[3].HeaderText = "Cuenta";
            dgvCerrar.Columns[4].HeaderText = "Fecha";
            dgvCerrar.Columns[5].HeaderText = "SLA";
            dgvCerrar.Columns[6].HeaderText = "Sector";
            dgvCerrar.Columns[7].HeaderText = "ID Cliente";
            this.dgvCerrar.Columns[7].Visible = false;
        }

        public CierreDeCaso()
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FlowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonEliminar_Click(object sender, EventArgs e)
        {

            conexion.Open();
            String nombreCliente = dgvCerrar.CurrentRow.Cells[2].Value.ToString();
            String numeroCaso = dgvCerrar.CurrentRow.Cells[1].Value.ToString();
            String idcaso = dgvCerrar.CurrentRow.Cells[7].Value.ToString();
            String nombreTecnico = "";
            String nombreVendedor = "";

            String consulta2 = "select p.nombre from PERSONA as p join TECNICO as t on p.idpersona = t.idpersona join CASO as c on c.IDTECNICO = t.IDTECNICO where idcaso = @IDCASO";
            SqlCommand comando2 = new SqlCommand(consulta2, conexion);
            comando2.Parameters.AddWithValue("@IDCASO", idcaso);
            comando2.ExecuteNonQuery();
            SqlDataReader reader = comando2.ExecuteReader();

            while (reader.Read())
            {
                nombreTecnico = reader.GetString(0);
            }

            conexion.Close();
            conexion.Open();

            String consulta3 = "select p.nombre from PERSONA as p join USUARIO as u on p.idpersona = u.idpersona join CASO as c on c.IDUSUARIO = u.IDUSUARIO where idcaso = @IDCASO";
            SqlCommand comando3 = new SqlCommand(consulta3, conexion);
            comando3.Parameters.AddWithValue("@IDCASO", idcaso);
            comando3.ExecuteNonQuery();
            SqlDataReader read = comando3.ExecuteReader();

            while (read.Read())
            {
                nombreVendedor = read.GetString(0);
            }




            conexion.Close();

            RegistroDeInformeFinal cambioDeDatosCaso = new RegistroDeInformeFinal(idcaso, nombreCliente, numeroCaso, nombreTecnico, nombreVendedor);
            cambioDeDatosCaso.ShowDialog();


        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }

        private void DgvCerrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0) //numero de caso
            {
                String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA where c.numero like '%" + tbBuscar.Text + "%' and c.estado = 'ABIERTO' order by c.estado;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvCerrar.DataSource = dt;
                dgvCerrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCerrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCerrar.Columns[0].HeaderText = "Estado";
                dgvCerrar.Columns[1].HeaderText = "Número";
                dgvCerrar.Columns[2].HeaderText = "Nombre";
                dgvCerrar.Columns[3].HeaderText = "Cuenta";
                dgvCerrar.Columns[4].HeaderText = "Fecha";
                dgvCerrar.Columns[5].HeaderText = "SLA";
                dgvCerrar.Columns[6].HeaderText = "Sector";
                dgvCerrar.Columns[7].HeaderText = "ID Cliente";
                this.dgvCerrar.Columns[7].Visible = false;
            }
            else if (cbBuscar.SelectedIndex == 1) // Cliente
            {
                String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA where p.nombre like '%" + tbBuscar.Text + "%' and c.estado = 'ABIERTO' order by c.estado;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dgvCerrar.DataSource = dt;
                dgvCerrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCerrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCerrar.Columns[0].HeaderText = "Estado";
                dgvCerrar.Columns[1].HeaderText = "Número";
                dgvCerrar.Columns[2].HeaderText = "Nombre";
                dgvCerrar.Columns[3].HeaderText = "Cuenta";
                dgvCerrar.Columns[4].HeaderText = "Fecha";
                dgvCerrar.Columns[5].HeaderText = "SLA";
                dgvCerrar.Columns[6].HeaderText = "Sector";
                dgvCerrar.Columns[7].HeaderText = "ID Cliente";
                this.dgvCerrar.Columns[7].Visible = false;
            }
            else if (cbBuscar.SelectedIndex == 2) // Cuenta
            {
                String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA where cl.cuenta like '%" + tbBuscar.Text + "%' and c.estado = 'ABIERTO' order by c.estado;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dgvCerrar.DataSource = dt;
                dgvCerrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCerrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCerrar.Columns[0].HeaderText = "Estado";
                dgvCerrar.Columns[1].HeaderText = "Número";
                dgvCerrar.Columns[2].HeaderText = "Nombre";
                dgvCerrar.Columns[3].HeaderText = "Cuenta";
                dgvCerrar.Columns[4].HeaderText = "Fecha";
                dgvCerrar.Columns[5].HeaderText = "SLA";
                dgvCerrar.Columns[6].HeaderText = "Sector";
                dgvCerrar.Columns[7].HeaderText = "ID Cliente";
                this.dgvCerrar.Columns[7].Visible = false;
            }
            else if (cbBuscar.SelectedIndex == 3) // Sector
            {
                String consulta = "select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA where c.sector like '%" + tbBuscar.Text + "%' and c.estado = 'ABIERTO' order by c.estado;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dgvCerrar.DataSource = dt;
                dgvCerrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvCerrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCerrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCerrar.Columns[0].HeaderText = "Estado";
                dgvCerrar.Columns[1].HeaderText = "Número";
                dgvCerrar.Columns[2].HeaderText = "Nombre";
                dgvCerrar.Columns[3].HeaderText = "Cuenta";
                dgvCerrar.Columns[4].HeaderText = "Fecha";
                dgvCerrar.Columns[5].HeaderText = "SLA";
                dgvCerrar.Columns[6].HeaderText = "Sector";
                dgvCerrar.Columns[7].HeaderText = "ID Cliente";
                this.dgvCerrar.Columns[7].Visible = false;
            }



        }
    }
}
