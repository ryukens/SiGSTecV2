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

namespace proyectoPantalla.Módulo_Casos
{
    public partial class AsignaciónDeProductos : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public AsignaciónDeProductos(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;

            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_LLENAR_TABLA_CASO_PARA_ASIGANCION_PRODUCTO", conexion);

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
            dgvMostrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[0].HeaderText = "Estado";
            dgvMostrar.Columns[1].HeaderText = "Número";
            dgvMostrar.Columns[2].HeaderText = "Nombre";
            dgvMostrar.Columns[3].HeaderText = "Cuenta";
            dgvMostrar.Columns[4].HeaderText = "Fecha";
            dgvMostrar.Columns[5].HeaderText = "SLA";
            dgvMostrar.Columns[6].HeaderText = "Sector";
            dgvMostrar.Columns[7].HeaderText = "ID Cliente";
            this.dgvMostrar.Columns[7].Visible = false;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String numero = dgvMostrar.SelectedRows[0].Cells[1].Value.ToString();
            String cliente = dgvMostrar.SelectedRows[0].Cells[2].Value.ToString();
           // MessageBox.Show(numero, cliente);
            SelecciónDeProductos selecciónDeProductos = new SelecciónDeProductos(numero, cliente);
            selecciónDeProductos.ShowDialog();
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
                SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_NUMERO_DE_CASO_PARA_ASIGANCION_PRODUCTO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NUMERO", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                llenarTabla();
            }
            else if (cbBuscar.SelectedIndex == 1) // Cliente
            {

                SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_NOMBRE_PARA_ASIGANCION_PRODUCTO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                llenarTabla();
            }
            else if (cbBuscar.SelectedIndex == 2) // Cuenta
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_CUENTA_PARA_ASIGANCION_PRODUCTO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                llenarTabla();
            }
            else if (cbBuscar.SelectedIndex == 3) // Sector
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_SECTOR_PARA_ASIGANCION_PRODUCTO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@SECTOR", tbBuscar.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                llenarTabla();
            }
        }

        public void llenarTabla()
        {
            dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[0].HeaderText = "Estado";
            dgvMostrar.Columns[1].HeaderText = "Número";
            dgvMostrar.Columns[2].HeaderText = "Nombre";
            dgvMostrar.Columns[3].HeaderText = "Cuenta";
            dgvMostrar.Columns[4].HeaderText = "Fecha";
            dgvMostrar.Columns[5].HeaderText = "SLA";
            dgvMostrar.Columns[6].HeaderText = "Sector";
            dgvMostrar.Columns[7].HeaderText = "ID Cliente";
            this.dgvMostrar.Columns[7].Visible = false;
        }
    }
}
