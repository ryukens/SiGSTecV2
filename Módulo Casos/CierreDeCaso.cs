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
        DataGridView dgv;

        public CierreDeCaso(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            

            SqlDataAdapter sda = new SqlDataAdapter("SP_LLENAR_TABLA_CASO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public void actualizarAnterior()
        {

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
          

            
            SqlCommand comando2 = new SqlCommand("SP_SELECCION_TECNICO_PARA_CASO1", conexion);
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.AddWithValue("@IDCASO", idcaso);
            comando2.ExecuteNonQuery();
            SqlDataReader reader = comando2.ExecuteReader();

            while (reader.Read())
            {
                nombreTecnico = reader.GetString(0);
            }

            conexion.Close();
            conexion.Open();

            SqlCommand comando3 = new SqlCommand("SP_SELECCION_TECNICO_PARA_CASO2", conexion);
            comando3.CommandType = CommandType.StoredProcedure;
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
            tbBuscar.ResetText();
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0) //numero de caso
            {

                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_POR_NUMERO_DE_CASO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NUMERO", tbBuscar.Text);
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
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_POR_NOMBRE", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
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
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_POR_CUENTA", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
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
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_POR_SECTOR", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@SECTOR", tbBuscar.Text);
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

        private void DgvCerrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
