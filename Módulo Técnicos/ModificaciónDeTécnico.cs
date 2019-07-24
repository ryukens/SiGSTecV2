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
    public partial class ModificaciónDeTécnico : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public ModificaciónDeTécnico(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            mostrarTecnicos();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }
        public void mostrarTecnicos()
        {
            String consulta = "select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA;";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvModificar.DataSource = dt;
            dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvModificar.Columns[0].HeaderText = "Estado";
            dgvModificar.Columns[1].HeaderText = "Nombre";
            dgvModificar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvModificar.Columns[3].HeaderText = "Sector";
            dgvModificar.Columns[4].HeaderText = "Alcance";
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            String cedula = dgvModificar.CurrentRow.Cells[2].Value.ToString();
            CambioDeDatosTécnico cambioDeDatosTécnico = new CambioDeDatosTécnico(cedula);
            cambioDeDatosTécnico.ShowDialog();
            mostrarTecnicos();
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

                String consulta = "select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%" + tbBuscar.Text + "%' order by t.sector;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvModificar.DataSource = dt;
                dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvModificar.Columns[0].HeaderText = "Estado";
                dgvModificar.Columns[1].HeaderText = "Nombre";
                dgvModificar.Columns[2].HeaderText = "Cédula de Ciudadanía";
                dgvModificar.Columns[3].HeaderText = "Sector";
                dgvModificar.Columns[4].HeaderText = "Alcance";
            }
            else
            {




                String consulta = "select t.estado, p.nombre, p.identificacion,  t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where p.identificacion like '%" + tbBuscar.Text + "%' order by t.sector;";
                SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvModificar.DataSource = dt;
                dgvModificar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvModificar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvModificar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvModificar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvModificar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvModificar.Columns[0].HeaderText = "Estado";
                dgvModificar.Columns[1].HeaderText = "Nombre";
                dgvModificar.Columns[2].HeaderText = "Cédula de Ciudadanía";
                dgvModificar.Columns[3].HeaderText = "Sector";
                dgvModificar.Columns[4].HeaderText = "Alcance";

            }
        }
    }
}
