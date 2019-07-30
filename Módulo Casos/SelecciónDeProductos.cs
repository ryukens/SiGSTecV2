using proyectoPantalla.Módulo_Casos;
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
    public partial class SelecciónDeProductos : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");

        public SelecciónDeProductos(String numero, String cliente, AsignaciónDeProductos asignaciónDeProductos)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.numero = numero;
            this.cliente = cliente;
            this.asignaciónDeProductos = asignaciónDeProductos;
            llenarTablaProductos();
            copiarFormatoTabla();
            lNumCaso.Text = numero;
            lNombreCliente.Text = cliente;


        }

        String numero;
        String cliente;
        AsignaciónDeProductos asignaciónDeProductos;

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

        public void limpiarCampos()
        {
            llenarTablaProductos();
            copiarFormatoTabla();
            tbBuscar.Text = "";
            nudCantidad.Value = 0;

        }

        public int encontrarIndiceAsignar(String codigo)
        {
            int indice = -1;
            for (int i = 0; i < dgvDisminuir.Rows.Count; i++)
            {
                //  MessageBox.Show(dgvDisminuir.Rows[i].Cells[0].Value.ToString());
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
                //  MessageBox.Show(i.ToString());

                if (dgvAsignar.Rows[i].Cells[0].Value.ToString() == codigo)
                {
                    indice = i;
                    break;
                }
            }

            return indice;
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



        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BAceptar_Click_1(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DgvDisminuir_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BAsignar_Click_1(object sender, EventArgs e)
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

        private void BQuitar_Click_1(object sender, EventArgs e)
        {
            if (dgvDisminuir.RowCount == 0)
            {
                MessageBox.Show("No hay productos por quitar", "Error");
            }
            else
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
        }

        private void BCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click_1(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        public void filtrarProductoPorCodigo()
        {
            DataTable dt = (DataTable)dgvAsignar.DataSource;
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "codigo", tbBuscar.Text);
            dgvAsignar.DataSource = dt;

        }
        public void filtrarProductoPorDescripcion()
        {
            DataTable dt = (DataTable)dgvAsignar.DataSource;
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "descripcion", tbBuscar.Text);
            dgvAsignar.DataSource = dt;

        }


        private void TbBuscar_TextChanged_1(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {
                filtrarProductoPorCodigo();
            }
            else
            {
                filtrarProductoPorDescripcion();
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {


            if (dgvDisminuir.Rows.Count > 0)
            {
                conexion.Open();

                for (int i = 0; i < dgvDisminuir.Rows.Count; i++)
                {
                    SqlCommand comando1 = new SqlCommand("SP_ASIGNACION_PRODUCTO_CASO", conexion);
                    comando1.CommandType = CommandType.StoredProcedure;
                    comando1.Parameters.AddWithValue("@numero", lNumCaso.Text);
                    comando1.Parameters.AddWithValue("@codigo", dgvDisminuir.Rows[i].Cells[0].Value.ToString());
                    comando1.Parameters.AddWithValue("@cantidad", Convert.ToInt32(dgvDisminuir.Rows[i].Cells[2].Value));
                    comando1.ExecuteNonQuery();

                }

                conexion.Close();
                MessageBox.Show("Productos Disminuidos Correctamente", "Producto Disminuido");
                limpiarCampos();

                asignaciónDeProductos.llenarTablaPublico();
                this.Dispose();



            }
            else
            {
                MessageBox.Show("Seleccione uno o más Productos", "Error de Asignación de Productos");
            }


        }

    }
}
