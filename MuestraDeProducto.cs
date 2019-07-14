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
    public partial class MuestraDeProducto : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public MuestraDeProducto(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            String consulta = "select codigo, descripcion, cantidad, precio from producto; ";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvMostrar.DataSource = dt;
            dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[0].HeaderText = "Código";
            dgvMostrar.Columns[1].HeaderText = "Descripción";
            dgvMostrar.Columns[2].HeaderText = "Cantidad";
            dgvMostrar.Columns[3].HeaderText = "Precio";
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {

                String consulta = "select codigo, descripcion, cantidad, precio from producto where codigo like '%" + tbBuscar.Text + "%'; ";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[0].HeaderText = "Código";
                dgvMostrar.Columns[1].HeaderText = "Descripción";
                dgvMostrar.Columns[2].HeaderText = "Cantidad";
                dgvMostrar.Columns[3].HeaderText = "Precio";
            }
            else
            {
                String consulta = "select codigo, descripcion, cantidad, precio from producto where descripcion like '%" + tbBuscar.Text + "%'; ";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[0].HeaderText = "Código";
                dgvMostrar.Columns[1].HeaderText = "Descripción";
                dgvMostrar.Columns[2].HeaderText = "Cantidad";
                dgvMostrar.Columns[3].HeaderText = "Precio";
            }
        }

        private void DgvMostrar_SelectionChanged(object sender, EventArgs e)
        {
            dgvMostrar.ClearSelection();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
