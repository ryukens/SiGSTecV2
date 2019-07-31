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
    public partial class SelecciónDeTécnico : Form
    {

        SqlConnection conexion = new SqlConnection("Data Source =.; Initial Catalog = sigstec; Integrated Security = True");

        public SelecciónDeTécnico(Label lTecnicoSeleccionado, Label lIdTecnico)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.lTecnicoSeleccionado = lTecnicoSeleccionado;
            this.lIdTecnico = lIdTecnico;
            muestraTecnicos();


        }

        public void muestraTecnicos()
        {
            String consulta = "select t.estado, p.nombre, p.identificacion, t.sector, t.alcance, t.idtecnico from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%" + tbBuscar.Text + "%' order by t.sector;";
            SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvSeleccionar.DataSource = dt;
            dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSeleccionar.Columns[0].HeaderText = "Estado";
            dgvSeleccionar.Columns[1].HeaderText = "Nombre";
            dgvSeleccionar.Columns[2].HeaderText = "Cédula de Ciudadanía";
            dgvSeleccionar.Columns[3].HeaderText = "Sector";
            dgvSeleccionar.Columns[4].HeaderText = "Alcance";
            dgvSeleccionar.Columns[5].HeaderText = "Id";
            this.dgvSeleccionar.Columns[5].Visible = false;

        }

        Label lTecnicoSeleccionado;
        Label lIdTecnico;


        private void BusquedaDeTécnico_Load(object sender, EventArgs e)
        {

        }

        private void BSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvSeleccionar.CurrentRow != null)
            {
                if (dgvSeleccionar.SelectedRows[0].Cells[0].Value.ToString() == "OCUPADO")
                {
                    MessageBox.Show("No se puede asignar un técnico ocupado", "Error");
                }
                else
                {
                    String nombreTecnico = dgvSeleccionar.CurrentRow.Cells[1].Value.ToString();
                    lTecnicoSeleccionado.Text = nombreTecnico;
                    String IdTecnico = dgvSeleccionar.CurrentRow.Cells[5].Value.ToString();
                    lIdTecnico.Text = IdTecnico;
                    this.Dispose();
                }
            }
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbBuscar.Text.Trim() != "")
            {


                if (cbBuscar.SelectedIndex == 0)
                {

                    String consulta = "select t.estado, p.nombre, p.identificacion, t.sector, t.alcance, t.idtecnico from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%" + tbBuscar.Text + "%' order by t.sector;";
                    SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvSeleccionar.DataSource = dt;
                    dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[0].HeaderText = "Estado";
                    dgvSeleccionar.Columns[1].HeaderText = "Nombre";
                    dgvSeleccionar.Columns[2].HeaderText = "Cédula de Ciudadanía";
                    dgvSeleccionar.Columns[3].HeaderText = "Sector";
                    dgvSeleccionar.Columns[4].HeaderText = "Alcance";
                    dgvSeleccionar.Columns[5].HeaderText = "Id";
                    this.dgvSeleccionar.Columns[5].Visible = false;


                }
                else
                {


                    String consulta = "select t.estado, p.nombre, p.identificacion,  t.sector,t.alcance, t.idtecnico from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where p.identificacion like '%" + tbBuscar.Text + "%' order by t.sector;";
                    SqlDataAdapter sda = new SqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvSeleccionar.DataSource = dt;
                    dgvSeleccionar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvSeleccionar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvSeleccionar.Columns[0].HeaderText = "Estado";
                    dgvSeleccionar.Columns[1].HeaderText = "Nombre";
                    dgvSeleccionar.Columns[2].HeaderText = "Cédula de Ciudadanía";
                    dgvSeleccionar.Columns[3].HeaderText = "Sector";
                    dgvSeleccionar.Columns[4].HeaderText = "Alcance";
                    dgvSeleccionar.Columns[5].HeaderText = "Id";
                    this.dgvSeleccionar.Columns[5].Visible = false;

                }
                if (dgvSeleccionar.RowCount == 0)
                {
                    MessageBox.Show("Técnico no encontrado", "Error");
                    tbBuscar.ResetText();
                    muestraTecnicos();
                }
            }

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            this.Dispose();
        }

        private void DgvSeleccionar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

