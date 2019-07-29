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
    public partial class FinalizaciónDeCaso : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;


        public FinalizaciónDeCaso(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            muestraCasos();

        }

        public void muestraCasos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_LLENAR_TABLA_CASO_PORFACTURAR", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        }

        

        private void FinalizaciónDeCaso_Load(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            tbFactura.ResetText();
            tabControl.SelectTab(tabInicio);
        }

        public bool ValidarCamposVacios()
        {
            bool flag = true;
            if (tbFactura.Text.Equals(""))
            {
                flag = false;
            }
            return flag;
        }

        private void BFinalizar_Click(object sender, EventArgs e)
        {
            bool flagVacios = ValidarCamposVacios();
            if (flagVacios == true)
            {
                if (MessageBox.Show("¿Está seguro que desea finalizar este caso?", "Finalizar Caso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conexion.Open();

                    String idcaso = dgvMostrar.CurrentRow.Cells[7].Value.ToString();

                    String numeroFactura = tbFactura.ToString();

                    SqlCommand comando1 = new SqlCommand("SP_FINALIZAR_CASO", conexion);
                    comando1.CommandType = CommandType.StoredProcedure;
                    comando1.Parameters.AddWithValue("@IDCASO", idcaso);
                    comando1.Parameters.AddWithValue("@NUMEROFACTURA", numeroFactura);
                    comando1.ExecuteNonQuery();
                    MessageBox.Show("Caso Finalizado Correctamente", "Caso Finalizado");
                    conexion.Close();
                    SqlDataAdapter sda = new SqlDataAdapter("SP_LLENAR_TABLA_CASO_PORFACTURAR", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
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
                }
            }
            else
            {
                limpiarCampos();
                MessageBox.Show("Ingrese un número de factura", "Campos Vacios");
            }

            conexion.Close();
            limpiarCampos();
        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0) //numero de caso
            {

                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_PORFACTURAR_POR_NUMERO_DE_CASO", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NUMERO", tbBuscar.Text);
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
            }
            else if (cbBuscar.SelectedIndex == 1) // Cliente
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_PORFACTURAR_POR_NOMBRE", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
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
            }
            else if (cbBuscar.SelectedIndex == 2) // Cuenta
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_PORFACTURAR_POR_CUENTA", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
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
            }
            else if (cbBuscar.SelectedIndex == 3) // Sector
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_BUSCAR_CASO_PORFACTURAR_POR_SECTOR", conexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@SECTOR", tbBuscar.Text);
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
            }



        }

        private void limpiarCampos()
        {
            tbFactura.ResetText();
        }

        private void TbFactura_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


