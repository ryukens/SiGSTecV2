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
    public partial class DetallesDeCaso : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");

        public DetallesDeCaso(String numero, String sector, String fecha)
        {
            InitializeComponent();
            
            TopMost = true;

            this.numero = numero;
            this.sector = sector;
            this.fecha = fecha;

            label7.Text = numero;
            label9.Text = fecha;
            label10.Text = sector;
            muestraCasos();

            obtenerNombreTecnico(this.numero);
            label8.Text = nombreTecnico;
            obtenerNombreVendedor(this.numero);
            label11.Text = nombreVendedor;

        }


        public void obtenerNombreTecnico(String numCaso)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_NOMBRE_TECNICO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NUMERO", numCaso);
            nombreTecnico = Convert.ToString(cmd.ExecuteScalar());
            conexion.Close();
        }

        public void obtenerNombreVendedor(String numCaso)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_NOMBRE_VENDEDOR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NUMERO", numCaso);
            nombreVendedor = Convert.ToString(cmd.ExecuteScalar());
            conexion.Close();
        }

        String numero;
        String sector;
        String fecha;
        String nombreTecnico = "";
        String nombreVendedor = "";


        public void muestraCasos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_DETALLES_PRODUCTOS_CASO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@NUMERO", label7.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[0].HeaderText = "Código";
            dataGridView1.Columns[1].HeaderText = "Descripción";
            dataGridView1.Columns[2].HeaderText = "Cantidad";



        }




        private void OrdenDeFacturación_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



