﻿using System;
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
    public partial class VistaDeDetalles : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public VistaDeDetalles(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            muestraCasos();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //  , tecnico, vendedor


            String numero = dgvVerDetalles.CurrentRow.Cells[1].Value.ToString();
            String sector = dgvVerDetalles.CurrentRow.Cells[6].Value.ToString();
            String fecha = dgvVerDetalles.CurrentRow.Cells[4].Value.ToString();


            DetallesDeCaso detallesDeCaso = new DetallesDeCaso(numero, sector, fecha);
            detallesDeCaso.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tbBuscar.ResetText();
            tabControl.SelectTab(tabInicio);

        }

        public void muestraCasos()
        {

            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_LLENAR_VISTA_DETALLES", conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvVerDetalles.DataSource = dt;
            dgvVerDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVerDetalles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVerDetalles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVerDetalles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVerDetalles.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVerDetalles.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVerDetalles.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVerDetalles.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVerDetalles.Columns[0].HeaderText = "Estado";
            dgvVerDetalles.Columns[1].HeaderText = "Número";
            dgvVerDetalles.Columns[2].HeaderText = "Nombre";
            dgvVerDetalles.Columns[3].HeaderText = "Cuenta";
            dgvVerDetalles.Columns[4].HeaderText = "Fecha";
            dgvVerDetalles.Columns[5].HeaderText = "SLA";
            dgvVerDetalles.Columns[6].HeaderText = "Sector";
            dgvVerDetalles.Columns[7].HeaderText = "ID Cliente";
            this.dgvVerDetalles.Columns[7].Visible = false;
        }

        private void DgvVerDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbBuscar.Text.Trim() != "")
            {
                if (cbBuscar.SelectedIndex == 0) //numero de caso
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_NUMERO_DE_CASO_FINALIZADO", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@NUMERO", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvVerDetalles.DataSource = dt;
                    dgvVerDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvVerDetalles.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[0].HeaderText = "Estado";
                    dgvVerDetalles.Columns[1].HeaderText = "Número";
                    dgvVerDetalles.Columns[2].HeaderText = "Nombre";
                    dgvVerDetalles.Columns[3].HeaderText = "Cuenta";
                    dgvVerDetalles.Columns[4].HeaderText = "Fecha";
                    dgvVerDetalles.Columns[5].HeaderText = "SLA";
                    dgvVerDetalles.Columns[6].HeaderText = "Sector";
                    dgvVerDetalles.Columns[7].HeaderText = "ID Cliente";
                    this.dgvVerDetalles.Columns[7].Visible = false;

                }
                else if (cbBuscar.SelectedIndex == 1) // Cliente
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_NOMBRE_FINALIZADO", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@NOMBRE", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvVerDetalles.DataSource = dt;
                    dgvVerDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvVerDetalles.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[0].HeaderText = "Estado";
                    dgvVerDetalles.Columns[1].HeaderText = "Número";
                    dgvVerDetalles.Columns[2].HeaderText = "Nombre";
                    dgvVerDetalles.Columns[3].HeaderText = "Cuenta";
                    dgvVerDetalles.Columns[4].HeaderText = "Fecha";
                    dgvVerDetalles.Columns[5].HeaderText = "SLA";
                    dgvVerDetalles.Columns[6].HeaderText = "Sector";
                    dgvVerDetalles.Columns[7].HeaderText = "ID Cliente";
                    this.dgvVerDetalles.Columns[7].Visible = false;
                }
                else if (cbBuscar.SelectedIndex == 2) // Cuenta
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_CUENTA_FINALIZADO", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@CUENTA", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvVerDetalles.DataSource = dt;
                    dgvVerDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvVerDetalles.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[0].HeaderText = "Estado";
                    dgvVerDetalles.Columns[1].HeaderText = "Número";
                    dgvVerDetalles.Columns[2].HeaderText = "Nombre";
                    dgvVerDetalles.Columns[3].HeaderText = "Cuenta";
                    dgvVerDetalles.Columns[4].HeaderText = "Fecha";
                    dgvVerDetalles.Columns[5].HeaderText = "SLA";
                    dgvVerDetalles.Columns[6].HeaderText = "Sector";
                    dgvVerDetalles.Columns[7].HeaderText = "ID Cliente";
                    this.dgvVerDetalles.Columns[7].Visible = false;

                }
                else if (cbBuscar.SelectedIndex == 3) // Sector
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_BUSCAR_CASO_POR_SECTOR_FINALIZADO", conexion);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@SECTOR", tbBuscar.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvVerDetalles.DataSource = dt;
                    dgvVerDetalles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvVerDetalles.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvVerDetalles.Columns[0].HeaderText = "Estado";
                    dgvVerDetalles.Columns[1].HeaderText = "Número";
                    dgvVerDetalles.Columns[2].HeaderText = "Nombre";
                    dgvVerDetalles.Columns[3].HeaderText = "Cuenta";
                    dgvVerDetalles.Columns[4].HeaderText = "Fecha";
                    dgvVerDetalles.Columns[5].HeaderText = "SLA";
                    dgvVerDetalles.Columns[6].HeaderText = "Sector";
                    dgvVerDetalles.Columns[7].HeaderText = "ID Cliente";
                    this.dgvVerDetalles.Columns[7].Visible = false;
                }
                if(dgvVerDetalles.RowCount == 0)
                {
                    MessageBox.Show("Caso no encontrado", "Error");
                    tbBuscar.ResetText();
                    muestraCasos();
                }
            }
        }
    }
}
