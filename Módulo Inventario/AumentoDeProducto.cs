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
    public partial class AumentoDeProducto : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;

        public AumentoDeProducto(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            mostrarProducto();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public void mostrarProducto()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAumentar.DataSource = dt;
            dgvAumentar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAumentar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[0].HeaderText = "Código";
            dgvAumentar.Columns[1].HeaderText = "Descripción";
            dgvAumentar.Columns[2].HeaderText = "Cantidad";
            dgvAumentar.Columns[3].HeaderText = "Precio";

        }

        public void mostrarProductoPorCodigo()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO_CODIGO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@codigo", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAumentar.DataSource = dt;
            dgvAumentar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAumentar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[0].HeaderText = "Código";
            dgvAumentar.Columns[1].HeaderText = "Descripción";
            dgvAumentar.Columns[2].HeaderText = "Cantidad";
            dgvAumentar.Columns[3].HeaderText = "Precio";
        }

        public void mostrarProductoPorDescripcion()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO_DESCRIPCION", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@descripcion", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAumentar.DataSource = dt;
            dgvAumentar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAumentar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAumentar.Columns[0].HeaderText = "Código";
            dgvAumentar.Columns[1].HeaderText = "Descripción";
            dgvAumentar.Columns[2].HeaderText = "Cantidad";
            dgvAumentar.Columns[3].HeaderText = "Precio";
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value == 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Error en Cantidad");
            }
            else
            {
                conexion.Open();


                SqlCommand comando1 = new SqlCommand("SP_AUMENTO_PRODUCTO", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@codigo", dgvAumentar.SelectedRows[0].Cells[0].Value);
                comando1.Parameters.AddWithValue("@cantidad", nudCantidad.Value);


                comando1.ExecuteNonQuery();


                conexion.Close();
                MessageBox.Show("Producto Aumentado Correctamente", "Producto Aumentado");
                mostrarProducto();
            }





        }

        private void NumericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.ResetText();
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {

                mostrarProductoPorCodigo();

            }
            else
            {
                mostrarProductoPorDescripcion();

            }

            if (dgvAumentar.RowCount == 0)
            {
                MessageBox.Show("Producto no encontrado", "Error");
                tbBuscar.ResetText();
                mostrarProducto();
            }
        }
    }
}
