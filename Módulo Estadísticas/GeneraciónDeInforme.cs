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
    public partial class GeneraciónDeInforme : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;

        public GeneraciónDeInforme(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
   
            //SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_LLENAR_TABLA_CASO", conexion);
            //sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            

            DataTable dt = new DataTable();
          //  sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Estado";
            dataGridView1.Columns[1].HeaderText = "Número";
            dataGridView1.Columns[2].HeaderText = "Nombre";
            dataGridView1.Columns[3].HeaderText = "Cuenta";
            dataGridView1.Columns[4].HeaderText = "Fecha";
            dataGridView1.Columns[5].HeaderText = "SLA";
            dataGridView1.Columns[6].HeaderText = "Sector";
            
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            
         

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter sda = new SqlDataAdapter("SP_GENERAR_INFORME_FINAL", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DateTime datei = DateTime.Parse(dtFechaInicio.Text);
            DateTime datef = DateTime.Parse(dtFechaFinal.Text);
            sda.SelectCommand.Parameters.AddWithValue("@FECHAI", datei);
            sda.SelectCommand.Parameters.AddWithValue("@FECHAF", datef);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Estado";
            dataGridView1.Columns[1].HeaderText = "Número";
            dataGridView1.Columns[2].HeaderText = "Nombre";
            dataGridView1.Columns[3].HeaderText = "Cuenta";
            dataGridView1.Columns[4].HeaderText = "Fecha";
            dataGridView1.Columns[5].HeaderText = "SLA";
            dataGridView1.Columns[6].HeaderText = "Sector";
            dataGridView1.Columns[7].HeaderText = "ID Cliente";
            this.dataGridView1.Columns[7].Visible = false;





        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }

        private void DtFechaFinal_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
