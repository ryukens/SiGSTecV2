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
    public partial class DisminuciónDeProducto : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public DisminuciónDeProducto(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            cbBuscar.SelectedIndex = 0;
            llenarTablaProductos();
            copiarFormatoTabla();
        }

        public void llenarTablaProductos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO_DISMINUCION", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgvAsignar.DataSource = dt;
            dgvAsignar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAsignar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAsignar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvAsignar.Columns[0].HeaderText = "Código";
            dgvAsignar.Columns[1].HeaderText = "Descripción";
            dgvAsignar.Columns[2].HeaderText = "Cantidad";



        }

        public void copiarFormatoTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());

            dgvDisminuir.DataSource = dt;
            dgvDisminuir.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDisminuir.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDisminuir.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvDisminuir.Columns[0].HeaderText = "Código";
            dgvDisminuir.Columns[1].HeaderText = "Descripción";
            dgvDisminuir.Columns[2].HeaderText = "Cantidad";

        }

        public void mostrarProductosPorCodigo()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO_CODIGO_DISMINUCION", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@codigo", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAsignar.DataSource = dt;
            dgvAsignar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAsignar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAsignar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvAsignar.Columns[0].HeaderText = "Código";
            dgvAsignar.Columns[1].HeaderText = "Descripción";
            dgvAsignar.Columns[2].HeaderText = "Cantidad";

        }

        public void mostrarProductoPorDescripcion()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO_DESCRIPCION_DISMINUCION", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@descripcion", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAsignar.DataSource = dt;
            dgvAsignar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAsignar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAsignar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvAsignar.Columns[0].HeaderText = "Código";
            dgvAsignar.Columns[1].HeaderText = "Descripción";
            dgvAsignar.Columns[2].HeaderText = "Cantidad";

        }

        public void limpiarCampos()
        {
            llenarTablaProductos();
            copiarFormatoTabla();
            tbBuscar.Text = "";
            nudCantidad.Value = 0;
            tbFactura.Text = "";

        }

        public int encontrarIndiceAsignar(String codigo)
        {
            int indice = -1;
            for (int i = 0; i < dgvDisminuir.Rows.Count; i++)
            {

                if (dgvDisminuir.Rows[i].Cells[0].Value.ToString() == codigo)
                {
                    indice = i;
                    break;
                }
            }

            return indice;
        }
        public int encontrarIndiceQuitar(String codigo)
        {
            int indice = -1;
            for (int i = 0; i < dgvAsignar.Rows.Count; i++)
            {

                if (dgvAsignar.Rows[i].Cells[0].Value.ToString() == codigo)
                {
                    indice = i;
                    break;
                }
            }

            return indice;
        }



        private void BCancelar_Click_1(object sender, EventArgs e)
        {
            limpiarCampos();
            tabControl.SelectTab(tabInicio);
            tbFactura.ResetText();
        }

        private void BAsignar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value == 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Error en la Cantidad");
            }
            else
            {
                if (nudCantidad.Value > Convert.ToInt32(dgvAsignar.SelectedRows[0].Cells[2].Value))
                {
                    MessageBox.Show("La cantidad excede a la cantidad disponible", "Error en la Cantidad");
                }
                else
                {

                    int indice = encontrarIndiceAsignar(dgvAsignar.SelectedRows[0].Cells[0].Value.ToString());

                    if (indice == -1)
                    {



                        DataTable dt = (DataTable)dgvDisminuir.DataSource;
                        dgvDisminuir.DataSource = dt;
                        dt.Rows.Add(dgvAsignar.SelectedRows[0].Cells[0].Value, dgvAsignar.SelectedRows[0].Cells[1].Value, nudCantidad.Value);
                        dgvDisminuir.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgvDisminuir.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvDisminuir.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgvAsignar.SelectedRows[0].Cells[2].Value = Convert.ToInt32(dgvAsignar.SelectedRows[0].Cells[2].Value) - Convert.ToInt32(nudCantidad.Value);
                    }
                    else
                    {
                        dgvDisminuir.Rows[indice].Cells[2].Value = Convert.ToInt32(dgvDisminuir.Rows[indice].Cells[2].Value) + Convert.ToInt32(nudCantidad.Value);
                        dgvAsignar.SelectedRows[0].Cells[2].Value = Convert.ToInt32(dgvAsignar.SelectedRows[0].Cells[2].Value) - Convert.ToInt32(nudCantidad.Value);
                    }
                }
            }



        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                mostrarProductosPorCodigo();
            }
            else
            {
                mostrarProductoPorDescripcion();
            }
        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value == 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Error en la Cantidad");
            }
            else
            {
                if (nudCantidad.Value > Convert.ToInt32(dgvDisminuir.SelectedRows[0].Cells[2].Value))
                {
                    MessageBox.Show("La cantidad excede a la cantidad disponible", "Error en la Cantidad");
                }
                else
                {

                    int indice = encontrarIndiceQuitar(dgvDisminuir.SelectedRows[0].Cells[0].Value.ToString());

                    if (indice == -1)
                    {

                        MessageBox.Show("Seleccione una fila", "Error de Selección");


                    }
                    else
                    {
                        dgvDisminuir.SelectedRows[0].Cells[2].Value = Convert.ToInt32(dgvDisminuir.SelectedRows[0].Cells[2].Value) - Convert.ToInt32(nudCantidad.Value);
                        dgvAsignar.Rows[indice].Cells[2].Value = Convert.ToInt32(dgvAsignar.Rows[indice].Cells[2].Value) + Convert.ToInt32(nudCantidad.Value);

                        if (Convert.ToInt32(dgvDisminuir.SelectedRows[0].Cells[2].Value) == 0)
                        {
                            dgvDisminuir.Rows.RemoveAt(dgvDisminuir.SelectedRows[0].Index);
                        }

                    }
                }
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (tbFactura.Text == "")
            {
                MessageBox.Show("Ingrese número de Orden de Entrega", "Error de número de Orden de Entrega");
            }
            else
            {
                if (dgvDisminuir.Rows.Count > 0)
                {
                    conexion.Open();
                    SqlCommand comando1 = new SqlCommand("SP_REGISTRO_ENTREGA", conexion);
                    comando1.CommandType = CommandType.StoredProcedure;
                    comando1.Parameters.AddWithValue("@entrega", tbFactura.Text);
                    comando1.ExecuteNonQuery();

                    for (int i = 0; i < dgvDisminuir.Rows.Count; i++)
                    {
                        comando1 = new SqlCommand("SP_DISMINUCION_PRODUCTO", conexion);
                        comando1.CommandType = CommandType.StoredProcedure;
                        comando1.Parameters.AddWithValue("@codigo", dgvDisminuir.Rows[i].Cells[0].Value.ToString());
                        comando1.Parameters.AddWithValue("@cantidad", Convert.ToInt32(dgvDisminuir.Rows[i].Cells[2].Value));
                        comando1.ExecuteNonQuery();

                    }


                    conexion.Close();
                    MessageBox.Show("Productos Disminuidos Correctamente", "Producto Disminuido");
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Seleccione uno o más Productos", "Error de Asignación de Productos");
                }

            }
        }
    }
}
