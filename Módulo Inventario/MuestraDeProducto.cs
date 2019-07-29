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
    public partial class MuestraDeProducto : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        public MuestraDeProducto(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbBuscar.SelectedIndex = 0;
            mostrarProductos();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public void mostrarProductos()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgvMostrar.DataSource = dt;
            dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[0].HeaderText = "Código";
            dgvMostrar.Columns[1].HeaderText = "Descripción";
            dgvMostrar.Columns[2].HeaderText = "Cantidad";
            dgvMostrar.Columns[3].HeaderText = "Precio";

        }

        public void mostrarProductosPorCodigo()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO_CODIGO", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@codigo", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvMostrar.DataSource = dt;
            dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[0].HeaderText = "Código";
            dgvMostrar.Columns[1].HeaderText = "Descripción";
            dgvMostrar.Columns[2].HeaderText = "Cantidad";
            dgvMostrar.Columns[3].HeaderText = "Precio";
        }

        public void mostrarProductoPorDescripcion()
        {

            SqlDataAdapter sda = new SqlDataAdapter("SP_MUESTRA_PRODUCTO_DESCRIPCION", conexion);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@descripcion", tbBuscar.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvMostrar.DataSource = dt;
            dgvMostrar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMostrar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMostrar.Columns[0].HeaderText = "Código";
            dgvMostrar.Columns[1].HeaderText = "Descripción";
            dgvMostrar.Columns[2].HeaderText = "Cantidad";
            dgvMostrar.Columns[3].HeaderText = "Precio";
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            if(dgvMostrar.RowCount == 0)
            {
                MessageBox.Show("Producto no encontrado", "Error");
                tbBuscar.ResetText();
                mostrarProductos();
            }
        }

        private void DgvMostrar_SelectionChanged(object sender, EventArgs e)
        {
            dgvMostrar.ClearSelection();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.ResetText();
        }
    }
}
