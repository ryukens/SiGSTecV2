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
    public partial class MuestraDeTécnico : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public MuestraDeTécnico(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;

            String consulta = "select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA;";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvMostrar.DataSource = dt;
            dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[0].HeaderText = "Estado";
            dgvMostrar.Columns[1].HeaderText = "Nombre";
            dgvMostrar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvMostrar.Columns[3].HeaderText = "Sector";
            dgvMostrar.Columns[4].HeaderText = "Alcance";
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.SelectedIndex == 0)
            {

                String consulta = "select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%" + tbBuscar.Text + "%' order by t.sector;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Nombre";
                dgvMostrar.Columns[2].HeaderText = "Cédula de Ciudadanía";
                dgvMostrar.Columns[3].HeaderText = "Sector";
                dgvMostrar.Columns[4].HeaderText = "Alcance";
            }
            else
            {




                String consulta = "select t.estado, p.nombre, p.identificacion,  t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where p.identificacion like '%" + tbBuscar.Text + "%' order by t.sector;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMostrar.DataSource = dt;
                dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMostrar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMostrar.Columns[0].HeaderText = "Estado";
                dgvMostrar.Columns[1].HeaderText = "Nombre";
                dgvMostrar.Columns[2].HeaderText = "Cédula de Ciudadanía";
                dgvMostrar.Columns[3].HeaderText = "Sector";
                dgvMostrar.Columns[4].HeaderText = "Alcance";
            }

        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
        }
    }
}
